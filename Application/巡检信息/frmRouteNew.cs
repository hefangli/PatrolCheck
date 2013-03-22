using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraTreeList.Nodes;

namespace WorkStation
{
    public partial class frmRouteNew : Form
    {
        private Boolean isShow = false;    //是否展开了添加巡检点案板
        public Boolean IsEdit = false;     //True 新建 False 编辑
        public object AreaID = null;       //新建-地点ID
        public object RouteID=null;        //路线ID
        List<TreeNode> listPhy = new List<TreeNode>();
        List<TreeNode> listLogical = new List<TreeNode>();

        public frmRouteNew()
        {
            InitializeComponent();
        }

        private void frmAddRoutName_Load(object sender, EventArgs e)
        {
            this.Size = new Size(315, 455);
            BindComboBox();
            if (IsEdit)
            {
                this.btnTrue.Text = "修改";
                this.Text = "修改巡检路线";
                SqlDataReader dr = SqlHelper.ExecuteReader("Select *,(select name from Area where ID=CheckRoute.Area_ID) as AreaName From CheckRoute Where ID=" + RouteID);
                if (dr == null) return;
                while (dr.Read())
                {
                    this.AreaID = dr["Area_ID"];
                    this.tbAreaName.Text = dr["AreaName"].ToString();
                    this.tbRouteName.Text = dr["Name"].ToString();
                    this.chkSequence.Checked= Convert.ToInt32(dr["Sequence"])==(Int32)CodesCheckSequence.InOrder?true:false;
                    this.cboState.SelectedValue = dr["ValidState"];
                    this.tbComment.Text = dr["Comment"].ToString();
                }
                dr.Dispose();
                GetLogicalPoint();
            }
            else
            {
                this.tbAreaName.Text =AreaID==null?"":SqlHelper.ExecuteScalar("Select Name from Area where id="+AreaID).ToString();
            }
            GetTvPhysicalPoint();
        }

        private void BindComboBox()
        {
            DataSet dsCboState = SqlHelper.ExecuteDataset("Select Code,Meaning from codes where purpose='ValidState'");
            cboState.DisplayMember = "Meaning";
            cboState.ValueMember = "Code";
            this.cboState.DataSource = dsCboState.Tables[0];
            this.cboState.SelectedValue = 1;
        }

        //获取逻辑巡检点
        private void GetLogicalPoint()
        {
            if (RouteID != null)
            {
                tvLogicalPoint.Nodes.Clear();
                SqlDataReader dr = SqlHelper.ExecuteReader("Select PhysicalPoint_ID,Name,ID From LogicalCheckPoint where route_ID=" + RouteID + " order by OrderNumber");
                if (dr == null) return;
                while (dr.Read())
                {
                    TreeNode tnode = new TreeNode();
                    tnode.Text = dr["Name"].ToString();
                    tnode.Tag = dr["PhysicalPoint_ID"].ToString();
                    tnode = tvNodeAdd(tnode, @"select  l.Item_ID as ID,c.Name as Name 
from LogicalPoint_Item l left join CheckItem c on l.Item_id=c.id
where l.LogicPoint_ID=" + dr["ID"].ToString().Trim() + " order by l.InOrder");
                    tvLogicalPoint.Nodes.Add(tnode);
                }
                tvLogicalPoint.ExpandAll();
            }
        }

        //获取物理巡检点
        private void GetTvPhysicalPoint()
        {
            tvPhysicalPoint.Nodes.Clear();
            string selectID = " with parent(ID,Area_ID,Name) as( select ID,Area_ID,Name From Area where id=" + AreaID + " union all select c.ID,c.Area_ID,c.Name from area c  join  parent p  on c.area_id=p.id  ) select ID from parent";
            string sqlSelect = "Select ID,Name From PhysicalCheckPoint Where validstate=1 ";
            SqlDataReader drIDs = SqlHelper.ExecuteReader(selectID);
            string ids = "";
            while (drIDs.Read())
            {
                ids += drIDs["ID"].ToString() + ",";
            }
            if (ids != "")
            {
                ids = ids.TrimEnd(new char[] { ',' });
                sqlSelect += " and Area_ID IN(" + ids + ")";
            }
            SqlDataReader dr = SqlHelper.ExecuteReader(sqlSelect);
            if (dr == null) { dr.Dispose(); return; }
            while (dr.Read())
            {
                TreeNode tnode = new TreeNode();
                tnode.Text = dr["Name"].ToString();
                tnode.Tag = dr["ID"].ToString();
                tnode = tvNodeAdd(tnode, "Select ID,Name From CheckItem Where validstate=1 and PhysicalCheckPoint_ID=" + dr["ID"].ToString().Trim());
                this.BeginInvoke((Action)delegate
                {
                    tvPhysicalPoint.Nodes.Add(tnode);
                });

            }
            dr.Close();

            //Dev TreeListView
             BindTL2();
        }

        private void BindTL()
        {
            string selectID = " with parent(ID,Area_ID,Name) as( select ID,Area_ID,Name From Area where id=" + AreaID + " union all select c.ID,c.Area_ID,c.Name from area c  join  parent p  on c.area_id=p.id  ) select ID from parent";
            string selectPoint = "Select ID,Name,(Select Name From Area Where ID=PhysicalCheckPoint.Area_ID) as AreaName From PhysicalCheckPoint Where validstate=1 ";
            string selectItem = "Select ID,PhysicalCheckPoint_ID as PhysicalCheckPointID,Name From CheckItem Where ValidState=1 ";
            using (SqlDataReader drAreaIDs = SqlHelper.ExecuteReader(selectID))
            {
                string AreaIDs = "";
                while (drAreaIDs.Read())
                {
                    AreaIDs += drAreaIDs["ID"].ToString() + ",";
                }
                if (AreaIDs != "")
                {
                    AreaIDs = AreaIDs.TrimEnd(new char[] { ',' });
                    selectPoint += " and Area_ID IN(" + AreaIDs + ")";
                }
            }
            using (SqlDataReader drPointIDs=SqlHelper.ExecuteReader(selectPoint))
            {
                string pointIDs="";
                while (drPointIDs.Read())
                {
                    pointIDs += drPointIDs["ID"].ToString() + ",";
                }
                if (pointIDs != "")
                {
                    selectItem += " and PhysicalCheckPoint_ID in("+pointIDs.TrimEnd(new char[]{','})+")";
                }
            }
            DataSet ds = SqlHelper.ExecuteDataset(selectPoint+";"+selectItem);
            ds.Relations.Add(new DataRelation("PointToItem",ds.Tables[0].Columns["ID"],ds.Tables[1].Columns["PhysicalCheckPointID"]));

        }

        private void BindTL2()
        {
            string selectID = " with parent(ID,Area_ID,Name) as( select ID,Area_ID,Name From Area where id=" + AreaID + " union all select c.ID,c.Area_ID,c.Name from area c  join  parent p  on c.area_id=p.id  ) select ID from parent";
            string selectPoint = "Select ID,Name,(Select Name From Area Where ID=PhysicalCheckPoint.Area_ID) as AreaName From PhysicalCheckPoint Where validstate=1 ";
            using (SqlDataReader drAreaIDs = SqlHelper.ExecuteReader(selectID))
            {
                string AreaIDs = "";
                while (drAreaIDs.Read())
                {
                    AreaIDs += drAreaIDs["ID"].ToString() + ",";
                }
                if (AreaIDs != "")
                {
                    AreaIDs = AreaIDs.TrimEnd(new char[] { ',' });
                    selectPoint += " and Area_ID IN(" + AreaIDs + ")";
                }
            }
            using (SqlDataReader drPointIDs = SqlHelper.ExecuteReader(selectPoint))
            {
                if (drPointIDs != null)
                {
                    TreeListNode node;
                    while (drPointIDs.Read())
                    {
                        node = tlPhysicalPoint.AppendNode(new object[]{drPointIDs["ID"],drPointIDs["Name"],drPointIDs["AreaName"]},null);
                        //if (Convert.ToInt32(SqlHelper.ExecuteScalar("select count(1) From checkitem where physicalcheckpoint_id=" + drPointIDs["ID"])) > 0)
                        //{
                        //    node.HasChildren = true;
                        //}
                        string sql = "select * from checkitem where physicalcheckpoint_id=" + drPointIDs["ID"];
                        using (SqlDataReader dr = SqlHelper.ExecuteReader(sql))
                        {
                            while (dr.Read())
                            {
                                tlPhysicalPoint.AppendNode(new object[] { dr["ID"], dr["Name"], null }, node).HasChildren = false;
                            }
                        }
                    }
                }
            }

        }

        private static TreeNode tvNodeAdd(TreeNode node, string comstr)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(comstr);
            if (dr == null)
            {
                dr.Dispose();
                return null;
            }
            while (dr.Read())
            {
                TreeNode tn = new TreeNode();
                tn.Text = dr["Name"].ToString();
                tn.Tag = dr["ID"];
                node.Nodes.Add(tn);
            }
            dr.Close();
            return node;
        } 

        private void btnTrue_Click(object sender, EventArgs e)
        {
            if (tbRouteName.Text==""&&cboState.SelectedValue == null)
            {
                MessageBox.Show("请确保没有空值");
                return;
            }
            string ItemIDs = "";
            if (tvLogicalPoint.Nodes.Count > 0)
            {
                foreach (TreeNode node in tvLogicalPoint.Nodes)
                {
                    if (node.Level == 0 && node.Nodes.Count != 0)
                    {
                        foreach (TreeNode child in node.Nodes)
                        {
                            ItemIDs += child.Tag + ",";
                        }
                    }
                    else
                    {
                        MessageBox.Show("请确保每个巡检点下有巡检项");
                        return;
                    }
                }
            }
            int _ret = (int)SqlHelper.ExecuteScalar("Select Count(1) From CheckRoute Where Name='" + this.tbRouteName.Text.Trim() + "' and Area_ID=" + AreaID);
            if (IsEdit == false && _ret != 0)
            {
                MessageBox.Show("请确保路线名称的唯一性");
                return;
            }
            string strsql = "";
            SqlParameter[] pars = new SqlParameter[] { 
               new SqlParameter("@areaid",SqlDbType.BigInt),
               new SqlParameter("@name",this.tbRouteName.Text.Trim().ToString()),
               new SqlParameter("@alias",null),
               new SqlParameter("@routeid",SqlDbType.BigInt),
               new SqlParameter("@sequence",SqlDbType.Int),
               new SqlParameter("@ValidState",SqlDbType.Int),
               new SqlParameter("@Comment",SqlDbType.Text)
            };
            if (IsEdit)
            {
                strsql = "Update CheckRoute Set Area_ID=@areaid,[Name]=@name,Alias=@alias,Sequence=@sequence,ValidState=@ValidState,Comment=@Comment Where ID=@routeid";
            }
            else
            {
                strsql = "Insert Into CheckRoute(Area_ID,[Name],Alias,Sequence,ValidState,Comment) Values(@areaid,@name,@alias,@sequence,@ValidState,@Comment);select scope_identity()";
            }
            pars[0].Value = AreaID;
            pars[3].Value = RouteID;
            pars[4].Value = chkSequence.Checked == true ? (Int32)CodesCheckSequence.InOrder : (Int32)CodesCheckSequence.UnInOrder;
            pars[5].Value = this.cboState.SelectedValue;
            pars[6].Value = this.tbComment.Text;
            if (IsEdit)
            {
                SqlHelper.ExecuteNonQuery(strsql, pars);
            }
            else
            {
                RouteID = SqlHelper.ExecuteScalar(strsql, pars);
            }

            //保存巡检项
            #region 保存巡检项
            if (ItemIDs != "")
            {
                ItemIDs = ItemIDs.Substring(0, ItemIDs.Length - 1);
            }
            SqlParameter[] pro_par = new SqlParameter[] { 
                     new SqlParameter("@Route_ID",RouteID),
                     new SqlParameter("@ItemIDs",ItemIDs)
                };
            SqlHelper.ExecuteNonQuery("LogicalPointItemControl", CommandType.StoredProcedure, pro_par);
            #endregion

            MessageBox.Show("保存成功");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShowAdd_Click(object sender, EventArgs e)
        {
            if (isShow == false)
            {
                this.Size = new Size(799, 455);
                isShow = true;
                btnShowAdd.Text = "关闭……";
            }
            else
            {
                this.Size = new Size(315, 455);
                isShow = false;
                btnShowAdd.Text = "设置巡检点";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (TreeListNode node in tlPhysicalPoint.Selection)
            {
                if (node.ParentNode != null) //node有上级,查找上级是否已经存在树中
                {
                    bool isExit = false;
                    foreach (TreeNode no in tvLogicalPoint.Nodes)
                    {
                        if (no.Parent == null && no.Tag.ToString() == node.ParentNode.GetDisplayText("ID").ToString()) //如果存在node的上级
                        {
                            bool isChild = false; //是否已经存在此节点
                            foreach (TreeNode t in no.Nodes)
                            {
                                if (t.Tag.ToString() == node.GetDisplayText("ID").ToString() && t.Text == node.GetDisplayText("Name").ToString())
                                {
                                    isChild = true; break;
                                }
                            }
                            if (isChild == false)
                            {
                                TreeNode tnChild = new TreeNode(node.GetDisplayText("Name")); tnChild.Tag = node.GetDisplayText("ID");
                                no.Nodes.Add(tnChild);
                            }
                            isExit = true;
                            break;
                        }
                    }
                    if (isExit == false)//不存在，则新建node的上级
                    {
                        TreeNode tn = new TreeNode();
                        tn.Text = node.ParentNode.GetDisplayText("Name");
                        tn.Tag = node.ParentNode.GetDisplayText("ID");
                        TreeNode tnChild = new TreeNode(node.GetDisplayText("Name"));
                        tnChild.Tag = node.GetDisplayText("ID");
                        tn.Nodes.Add(tnChild);
                        tvLogicalPoint.Nodes.Add(tn);
                    }
                }
                else //node没有上级
                {
                    bool isExitNode = false;
                    foreach (TreeNode no in tvLogicalPoint.Nodes)
                    {
                        if (no.Parent == null && no.Tag.ToString() == node.GetDisplayText("ID").ToString())
                        {
                            isExitNode = true;
                            break;
                        }
                    }
                    if (isExitNode == false)
                    {
                        TreeNode tn = new TreeNode();
                        tn.Text = node.GetDisplayText("Name");
                        tn.Tag = node.GetDisplayText("ID");

                        if (node.HasChildren)
                        {
                            foreach (TreeListNode child in node.Nodes)
                            {
                                TreeNode tnChild = new TreeNode();
                                tnChild.Text = child.GetDisplayText("Name");
                                tnChild.Tag = child.GetDisplayText("ID");
                                tn.Nodes.Add(tnChild);
                            }
                        }
                        tvLogicalPoint.Nodes.Add(tn);
                    }
                }
            }
            tlPhysicalPoint.Selection.Clear();
            #region Old
            //listLogical = listPhy;
            //foreach (TreeNode node in listPhy)
            //{
            //    if (node.Parent != null) //node有上级
            //    {
            //        bool isExit = false;
            //        foreach (TreeNode no in tvLogicalPoint.Nodes)
            //        {
            //            if (no.Parent == null && no.Tag.ToString() == node.Parent.Tag.ToString()) //如果存在node的上级
            //            {
            //                bool isChild = false;
            //                foreach (TreeNode t in no.Nodes)
            //                {
            //                    if (t.Tag.ToString() == node.Tag.ToString() && t.Text == node.Text)
            //                    {
            //                        isChild = true; break;
            //                    }
            //                }
            //                if (isChild == false)
            //                {
            //                    no.Nodes.Add((TreeNode)node.Clone());
            //                }
            //                isExit = true;
            //                break;
            //            }
            //        }
            //        if (isExit == false)//不存在，则新建node的上级
            //        {
            //            TreeNode tn = new TreeNode();
            //            tn.Text = node.Parent.Text;
            //            tn.Tag = node.Parent.Tag;
            //            tn.Nodes.Add((TreeNode)node.Clone());
            //            tvLogicalPoint.Nodes.Add(tn);
            //        }
            //    }
            //    else //node没有上级
            //    {
            //        bool isExitNode = false;
            //        foreach (TreeNode no in tvLogicalPoint.Nodes)
            //        {
            //            if (no.Parent == null && no.Tag.ToString() == node.Tag.ToString())
            //            {
            //                isExitNode = true;
            //                break;
            //            }
            //        }
            //        if (isExitNode == false)
            //        {
            //            //TreeNode tn = new TreeNode();
            //            //tn.Text = node.Text;
            //            //tn.Tag = node.Tag;
            //            tvLogicalPoint.Nodes.Add((TreeNode)(node.Clone()));
            //        }
            //    }
            //}
#endregion end

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            foreach (TreeNode node in listLogical)
            {
                tvLogicalPoint.Nodes.Remove(node);
            }
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if (listLogical.Count == 0) return;
            TreeNode selnode = listLogical[0];
            TreeNode prenode = selnode.PrevNode;
            TreeNode newnode = selnode.Clone() as TreeNode;
            if (prenode != null)
            {
                if (selnode.Parent != null)
                {
                    selnode.Parent.Nodes.Insert(prenode.Index, newnode);
                }
                else
                {
                    tvLogicalPoint.Nodes.Insert(prenode.Index, newnode);
                }
                selnode.Remove();
                tvLogicalPoint.SelectedNode = newnode;
            }
            else
            {
                MessageBox.Show("已经到顶"); return;
            }
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            TreeNode selnode = listLogical[0];
            TreeNode nextnode = selnode.NextNode;
            TreeNode newnode = selnode.Clone() as TreeNode;
            if (nextnode != null)
            {
                if (selnode.Parent != null)
                {
                    selnode.Parent.Nodes.Insert(nextnode.Index + 1, newnode);
                }
                else
                {
                    tvLogicalPoint.Nodes.Insert(nextnode.Index + 1, newnode);
                }
                selnode.Remove();
                tvLogicalPoint.SelectedNode = newnode;
            }
            else
            {
                MessageBox.Show("已经到底"); return;
            }
        }

        private void tvLogicalPoint_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (ModifierKeys == Keys.Control)
            {
                if (listLogical.Contains(e.Node))
                {
                    listLogical.Remove(e.Node);
                }
                else
                {
                    listLogical.Add(e.Node);
                }
            }
            else
            {
                listLogical.Clear();
                listLogical.Add(e.Node);
            }
            PaintSelectedNode(tvLogicalPoint, listLogical);
            listPhy.Clear();
           // PaintSelectedNode(tvPhysicalPoint, listPhy);
            e.Cancel = true;
        }

        private void tvPhysicalPoint_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (ModifierKeys == Keys.Control)
            {
                if (listPhy.Contains(e.Node))
                {
                    listPhy.Remove(e.Node);
                }
                else
                {
                    listPhy.Add(e.Node);
                }
            }
            else
            {
                listPhy.Clear();
                listPhy.Add(e.Node);
            }
            PaintSelectedNode(tvPhysicalPoint, listPhy);
            listLogical.Clear();
            PaintSelectedNode(tvLogicalPoint, listLogical);
            e.Cancel = true;
        }

        public void PaintSelectedNode(TreeView tv, List<TreeNode> listNodes)
        {
            foreach (TreeNode trNode in tv.Nodes)
            {
                trNode.BackColor = tv.BackColor;
                trNode.ForeColor = tv.ForeColor;
                ClearSelectedNode(tv, trNode);
            }
            foreach (TreeNode node in listNodes)
            {
                node.BackColor = SystemColors.Highlight;
                node.ForeColor = SystemColors.HighlightText;
            }
        }

        public void ClearSelectedNode(TreeView tv, TreeNode tr)
        {
            foreach (TreeNode node in tr.Nodes)
            {
                node.BackColor = tv.BackColor;
                node.ForeColor = tv.ForeColor;
                ClearSelectedNode(tv, node);
            }
        }

        private void tvLogicalPoint_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            listLogical.Clear();
            listLogical.Add(e.Node);
            PaintSelectedNode(tvLogicalPoint, listLogical);
        }

        private void tvPhysicalPoint_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            listPhy.Clear();
            listPhy.Add(e.Node);
            PaintSelectedNode(tvPhysicalPoint, listPhy);
        }
    }
}
