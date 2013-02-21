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

namespace WorkStation
{
    public partial class DefectType : Form
    {
        public DefectType()
        {
            InitializeComponent();
        }
        object defectTypeId = null;
        public object DefectID = null;
        private void DefectType_Load(object sender, EventArgs e)
        {
            BindTreeList();
            BindDgv();
            using (SqlDataReader drDefectLevel = SqlHelper.ExecuteReader("select * from codes where purpose='DefectLevel'"))
            {
                while (drDefectLevel.Read())
                {
                    repositoryItemImageComboBox1_DefectLevel.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(drDefectLevel["Meaning"].ToString(),drDefectLevel["Code"],0));
                }
            }
            using (SqlDataReader drValidState = SqlHelper.ExecuteReader("select * from codes where purpose='ValidState'"))
            {
                while (drValidState.Read())
                {
                    repositoryItemImageComboBox2_ValidState.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(drValidState["Meaning"].ToString(),drValidState["Code"],0));
                }
            }
        }

        //绑定树
        private void BindTreeList()
        {
            DataSet ds = SqlHelper.ExecuteDataset("select * from defecttype ");
            treeList1.DataSource=ds.Tables[0];
        }
       
        private void BindDgv()
        {
            if (treeList1.FocusedNode!= null)
            {
                DataSet ds = SqlHelper.ExecuteDataset("select ID,DefectType_ID,Name,DefectLevel,ValidState from defect where defecttype_id=" + treeList1.FocusedNode.GetDisplayText("ID"));
                this.gridControl1.DataSource = ds.Tables[0];
            }
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
           //MessageBox.Show(treeList1.FocusedNode.GetDisplayText("ID"));
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
        //编辑缺陷类型
        private void barCheckItem2_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            treeList1.OptionsBehavior.Editable = barCheckItem2.Checked;
        }
        //编辑缺陷
        private void barCheckItem3_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.OptionsBehavior.Editable = barCheckItem3.Checked;
        }
     
        //删除缺陷类型
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (treeList1.FocusedNode == null) return;
            string del = "delete from defecttype where id="+treeList1.FocusedNode.GetDisplayText("ID");
            SqlHelper.ExecuteNonQuery(del);
            BindTreeList();
        }
        //删除缺陷
        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0) return;
            string del = "delete from defect where id=" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID");
            SqlHelper.ExecuteNonQuery(del);
            BindDgv();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0) return;
            this.DefectID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID");
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

      

       
    }
}
