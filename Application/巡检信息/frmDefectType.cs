using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Nodes;
using System.Data.SqlClient;
using DevExpress.XtraBars.Docking;

namespace WorkStation
{
    public partial class frmDefectType : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public frmDefectType()
        {
            InitializeComponent();
            BindComobox();
            BindTreeList();
        }
        object defectTypeId = null;     //缺陷类型的编号，用于新建缺陷类型。
        object nodeid = null;           //treelist 节点编号
        private void frmDefectType_Load(object sender, EventArgs e)
        {
            using (SqlDataReader drDefectLevel = SqlHelper.ExecuteReader("select * from codes where purpose='DefectLevel'"))
            {
                while (drDefectLevel.Read())
                {
                    riicboDefectDefectLevel.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(drDefectLevel["Meaning"].ToString(), drDefectLevel["Code"], 0));
                }
            }
            using (SqlDataReader drValidState = SqlHelper.ExecuteReader("select * from codes where purpose='ValidState'"))
            {
                while (drValidState.Read())
                {
                    riicboDefectValidState.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(drValidState["Meaning"].ToString(), drValidState["Code"], 0));
                    riicboDefectTypeValidstate.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(drValidState["Meaning"].ToString(), drValidState["Code"], 0));
                }
            }

            this.dpSearch.Close();
            
        }

        private void BindComobox()
        {
            using (SqlDataReader dr = SqlHelper.ExecuteReader("SELECT * FROM dbo.Codes WHERE Purpose='ValidState'"))
            {
                cboValidState.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem("全部", -1, -1));
                while (dr.Read())
                {
                    cboValidState.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr["Meaning"].ToString(), dr["Code"], -1));
                }
                cboValidState.EditValue = -1;
            }
        }

        //绑定树
        private void BindTreeList()
        {
            DataSet ds = SqlHelper.ExecuteDataset("select * from defecttype order by ID");
            treeList1.DataSource=ds.Tables[0];

            if(defectTypeId!=null)
            {
                 treeList1.FindNodeByID(Convert.ToInt32(nodeid)).ExpandAll();
            }
        }
       
        private void BindDgv()
        {
            string sql = "select ID,DefectType_ID,Name,DefectLevel,ValidState,(Select Name From DefectType Where ID=defect.ID) as DefectTypeName from defect where 1=1 ";
            string ids = "";
            if (chkAll.Checked)
            {
                foreach (TreeListNode node in treeList1.Nodes)
                {
                    ids += treeVisitor(node);
                }
            }
            else
            {
                if (treeList1.FocusedNode != null)
                {
                    ids += treeVisitor(treeList1.FocusedNode);
                }
            }
            if (ids.Trim() != "")
            {
                sql += " and DefectType_ID in ("+ids.TrimEnd(',')+")";
            }
            if (cboValidState.EditValue.ToString() != "-1")
            {
                sql += " and ValidState="+cboValidState.EditValue;
            }
            if (tbName.Text.Trim() != "")
            {
                sql += " and Name Like '%"+tbName.Text.Trim()+"%'";
            }
            if (treeList1.FocusedNode!= null)
            {
                DataSet ds = SqlHelper.ExecuteDataset(sql);
                this.gridControl1.DataSource = ds.Tables[0];
            }
        }

        private string treeVisitor(TreeListNode areaNode)
        {
            string id = "";
            id += areaNode.GetDisplayText("ID") + ",";
            
            foreach (TreeListNode n in areaNode.Nodes)
            {
                 id += treeVisitor(n);
            }
            return id;
        }

        private void treeList1_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            if (e.Node != null)
            {
                defectTypeId = e.Node.GetDisplayText("ID");
                BindDgv();
            }
        }
 
        private void treeList1_Leave(object sender, EventArgs e)
        {
            defectTypeId = null;
        }

        //新建缺陷类型
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string insert = null;
            if (defectTypeId != null)
            {
                insert = @"Insert into DefectType(DefectType_ID,Name,ValidState) 
                        Values(" + defectTypeId + ",'新建巡检类型',1)";
            }
            else
            {
                insert = @"Insert into DefectType(Name,ValidState) 
                        Values('新建巡检类型',1)";
            }
            SqlHelper.ExecuteNonQuery(insert);
            BindTreeList();
        }
 
        //新建缺陷
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!treeList1.FocusedNode.HasChildren)
            {
                string sql = @"insert into Defect(defecttype_id,name,defectlevel,validstate) 
                               values("+treeList1.FocusedNode.GetDisplayText("ID")+",'新建缺陷',1,1)";
                SqlHelper.ExecuteNonQuery(sql);
                BindDgv();
            }
        }
  
        //启/停用编辑缺陷类型
        private void barCheckItem2_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            treeList1.OptionsBehavior.Editable = barCheckItem2.Checked;
        }
 
        //启/停用编辑缺陷
        private void barCheckItem3_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.OptionsBehavior.Editable = barCheckItem3.Checked;
        }
     
        //删除缺陷类型
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (treeList1.FocusedNode == null) return;
            string del = "delete from defecttype where id="+treeList1.FocusedNode.GetDisplayText("ID");
            if (SqlHelper.ExecuteNonQuery(del) != 1)
            {
                MessageBox.Show("删除失败，稍后再试！");
            }
            BindTreeList();
        }
    
        //删除缺陷
        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0) return;
            string del = "delete from defect where id=" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID");
            if (SqlHelper.ExecuteNonQuery(del) != 1)
            {
                MessageBox.Show("删除失败，稍后再试！");
            }
            BindDgv();
        }

        //编辑缺陷类型
        private void treeList1_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            object name=e.Value;
            SqlHelper.ExecuteNonQuery("Update DefectType Set Name='"+name+"' where ID="+e.Node.GetDisplayText("ID"));
            BindTreeList();
        }

        //编辑缺陷
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            string sql = @"Update Defect Set Name='" + gridView1.GetRowCellValue(e.RowHandle, "Name") + "',DefectLevel=" + gridView1.GetRowCellValue(e.RowHandle, "DefectLevel")
                           +",ValidState="+gridView1.GetRowCellValue(e.RowHandle,"ValidState")+" where ID="+gridView1.GetRowCellValue(e.RowHandle,"ID");
            SqlHelper.ExecuteNonQuery(sql);
            BindDgv();
        }
        //查找
        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindDgv();
        }
        //查找窗体
        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dpSearch.Visibility == DockVisibility.Hidden)
            {
                dpSearch.Show();
            }
            else
            {
                dpSearch.Close();
            }
        }
       
    }
}
