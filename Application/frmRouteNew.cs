using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WorkStation
{
    public partial class frmRouteNew : Form
    {
        private Boolean isShow = false;//是否展开了添加巡检点案板
        public Boolean isEdit = false;
        public object routeID;
        List<TreeNode> listPhy = new List<TreeNode>();
        List<TreeNode> listLogical = new List<TreeNode>();

        public frmRouteNew()
        {
            InitializeComponent();
        }

        private void cboinit()
        {
            DataSet dsCboinorder = SqlHelper.ExecuteDataset("Select Code,Meaning From Codes where purpose='CheckSequence' ");
            this.cboInOrder.DataSource = dsCboinorder.Tables[0];
            this.cboInOrder.DisplayMember = "Meaning";
            this.cboInOrder.ValueMember = "Code";
            this.cboInOrder.SelectedIndex = this.cboInOrder.Items.Count > 0 ? 0 : -1;
            dsCboinorder.Dispose();

            DataSet dsCboSitearea = SqlHelper.ExecuteDataset("Select Id,Name From Site where validstate=1");
            cboSiteArea.DisplayMember = "Name";
            cboSiteArea.ValueMember = "ID";
            cboSiteArea.DataSource = dsCboSitearea.Tables[0];
            dsCboSitearea.Dispose();

            DataSet dsCboState = SqlHelper.ExecuteDataset("Select Code,Meaning from codes where purpose='ValidState'");
            cboState.DisplayMember = "Meaning";
            cboState.ValueMember = "Code";
            this.cboState.DataSource = dsCboState.Tables[0];
            this.cboState.SelectedValue = 1;
        }

        //获取逻辑巡检点
        private void GetLogicalPoint()
        {
            if (routeID != null)
            {
                tvLogicalPoint.Nodes.Clear();
                SqlDataReader dr = SqlHelper.ExecuteReader("Select PhysicalPoint_ID,Name,ID From LogicalCheckPoint where route_ID=" + routeID + " order by ordernumber");
                if (dr == null) return;
                while (dr.Read())
                {
                    TreeNode tnode = new TreeNode();
                    tnode.Text = dr["Name"].ToString();
                    tnode.Tag = dr["PhysicalPoint_ID"].ToString();
                    tnode = tvNodeAdd(tnode, @"select  l.Item_ID as ID,c.Name as Name 
from LogicalPoint_Item l left join CheckItem c on l.Item_id=c.id
where LogicPoint_ID=" + dr["ID"].ToString().Trim() + " order by l.ordernumber");
                    tvLogicalPoint.Nodes.Add(tnode);
                }
                tvLogicalPoint.ExpandAll();
            }
        }

        //获取物理巡检点
        private void getTvPhysicalPoint()
        {
            tvPhysicalPoint.Nodes.Clear();
            SqlDataReader dr = SqlHelper.ExecuteReader("Select ID,Name From PhysicalCheckPoint Where validstate=1 and Site_ID=" + cboSiteArea.SelectedValue);
            if (dr == null) { dr.Dispose(); return; }
            while (dr.Read())
            {
                TreeNode tnode = new TreeNode();
                tnode.Text = dr["Name"].ToString();
                tnode.Tag = dr["ID"].ToString();
                tnode = tvNodeAdd(tnode, "Select ID,Name From CheckItem Where validstate=1 and Phy_ID=" + dr["ID"].ToString().Trim());
                this.BeginInvoke((Action)delegate
                {
                    tvPhysicalPoint.Nodes.Add(tnode);
                });

            }
            dr.Close();
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

        private void frmAddRoutName_Load(object sender, EventArgs e)
        {
            this.Size = new Size(315, 455);
            cboinit();
            if (isEdit)
            {
                this.btnTrue.Text = "修改";
                this.Text = "修改巡检路线";
                SqlDataReader dr = SqlHelper.ExecuteReader("Select Site_ID,Name,Alias,Sequence,ValidState,Comment From CheckRoute Where ID=" + routeID);
                if (dr == null) return;
                while (dr.Read())
                {
                    this.cboSiteArea.SelectedValue = dr["Site_ID"];
                    this.tbRouteName.Text = dr["Name"].ToString();
                    this.tbRouteAlias.Text = dr["Alias"].ToString();
                    this.cboInOrder.SelectedValue = dr["Sequence"];
                    this.cboState.SelectedValue = dr["ValidState"];
                    this.tbComment.Text = dr["Comment"].ToString();
                }
                dr.Dispose();
                GetLogicalPoint();
            }
        }

        private void btnTrue_Click(object sender, EventArgs e)
        {
            if (cboSiteArea.SelectedValue == null || cboInOrder.SelectedValue == null || cboState.SelectedValue == null)
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
            int _ret = (int)SqlHelper.ExecuteScalar("Select Count(1) From CheckRoute Where Name='" + this.tbRouteName.Text.Trim() + "' and Site_ID=" + cboSiteArea.SelectedValue.ToString());
            if (isEdit == false && _ret != 0)
            {
                MessageBox.Show("请确保路线名称的唯一性");
                return;
            }
            string strsql = "";
            SqlParameter[] pars = new SqlParameter[] { 
               new SqlParameter("@id",SqlDbType.BigInt),
               new SqlParameter("@name",this.tbRouteName.Text.Trim().ToString()),
               new SqlParameter("@alias",this.tbRouteAlias.Text.Trim().ToString()),
               new SqlParameter("@routeid",SqlDbType.BigInt),
               new SqlParameter("@sequence",SqlDbType.Int),
               new SqlParameter("@ValidState",SqlDbType.Int),
               new SqlParameter("@Comment",SqlDbType.Text)
            };
            if (isEdit)
            {
                strsql = "Update CheckRoute Set Site_ID=@id,[Name]=@name,Alias=@alias,Sequence=@sequence,ValidState=@ValidState,Comment=@Comment Where ID=@routeid";
            }
            else
            {
                strsql = "Insert Into CheckRoute(Site_ID,[Name],Alias,Sequence,ValidState,Comment) Values(@id,@name,@alias,@sequence,@ValidState,@Comment);select scope_identity()";
            }
            pars[0].Value = cboSiteArea.SelectedValue.ToString();
            pars[3].Value = routeID;
            pars[4].Value = this.cboInOrder.SelectedValue;
            pars[5].Value = this.cboState.SelectedValue;
            pars[6].Value = this.tbComment.Text;
            if (isEdit)
            {
                SqlHelper.ExecuteNonQuery(strsql, pars);
            }
            else
            {
                routeID = SqlHelper.ExecuteScalar(strsql, pars);
            }

            //保存巡检项
            #region 保存巡检项
            if (ItemIDs != "")
            {
                ItemIDs = ItemIDs.Substring(0, ItemIDs.Length - 1);
            }
            SqlParameter[] pro_par = new SqlParameter[] { 
                     new SqlParameter("@Route_ID",routeID),
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

        private void cboSiteArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            getTvPhysicalPoint();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //listLogical = listPhy;
            foreach (TreeNode node in listPhy)
            {
                if (node.Parent != null) //node有上级
                {
                    bool isExit = false;
                    foreach (TreeNode no in tvLogicalPoint.Nodes)
                    {
                        if (no.Parent == null && no.Tag.ToString() == node.Parent.Tag.ToString()) //如果存在node的上级
                        {
                            bool isChild = false;
                            foreach (TreeNode t in no.Nodes)
                            {
                                if (t.Tag.ToString() == node.Tag.ToString() && t.Text == node.Text)
                                {
                                    isChild = true; break;
                                }
                            }
                            if (isChild == false)
                            {
                                no.Nodes.Add((TreeNode)node.Clone());
                            }
                            isExit = true;
                            break;
                        }
                    }
                    if (isExit == false)//不存在，则新建node的上级
                    {
                        TreeNode tn = new TreeNode();
                        tn.Text = node.Parent.Text;
                        tn.Tag = node.Parent.Tag;
                        tn.Nodes.Add((TreeNode)node.Clone());
                        tvLogicalPoint.Nodes.Add(tn);
                    }
                }
                else //node没有上级
                {
                    bool isExitNode = false;
                    foreach (TreeNode no in tvLogicalPoint.Nodes)
                    {
                        if (no.Parent == null && no.Tag.ToString() == node.Tag.ToString())
                        {
                            isExitNode = true;
                            break;
                        }
                    }
                    if (isExitNode == false)
                    {
                        //TreeNode tn = new TreeNode();
                        //tn.Text = node.Text;
                        //tn.Tag = node.Tag;
                        tvLogicalPoint.Nodes.Add((TreeNode)(node.Clone()));
                    }
                }
            }

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
            PaintSelectedNode(tvPhysicalPoint, listPhy);
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
