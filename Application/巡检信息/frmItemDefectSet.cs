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
    public partial class frmItemDefectSet : WeifenLuo.WinFormsUI.Docking.DockContent//Form
    {
        public frmItemDefectSet()
        {
            InitializeComponent();
        }

        object defectTypeId = null;
        public object DefectID = null;              //调用-返回缺陷ID
        public object DefectName = null;            //调用-返回缺陷Name

        private void DefectSet_Load(object sender, EventArgs e)
        {
            BindTreeList();
            using (SqlDataReader drDefectLevel = SqlHelper.ExecuteReader("select * from codes where purpose='DefectLevel'"))
            {
                while (drDefectLevel.Read())
                {
                    repositoryItemImageComboBox1_DefectLevel.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(drDefectLevel["Meaning"].ToString(), drDefectLevel["Code"], 0));
                }
            }
            using (SqlDataReader drValidState = SqlHelper.ExecuteReader("select * from codes where purpose='ValidState'"))
            {
                while (drValidState.Read())
                {
                    repositoryItemImageComboBox2_ValidState.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(drValidState["Meaning"].ToString(), drValidState["Code"], 0));
                }
            }
        }

        private void BindDgv()
        {
            
            if (treeList1.FocusedNode == null) return;
            DataSet ds = SqlHelper.ExecuteDataset("select 'False' as isChose,* from defect where validstate="+(Int32)CodesValidState.Exit+" and defecttype_id="+treeList1.FocusedNode.GetDisplayText("ID"));
            this.gridControl1.DataSource = ds==null?null:ds.Tables[0];
        }

        //绑定树
        private void BindTreeList()
        {
            object oo = CodesValidState.Exit;
            DataSet ds = SqlHelper.ExecuteDataset("select * from defecttype where validstate="+(Int32)CodesValidState.Exit);
            treeList1.DataSource = ds.Tables[0];
        }

        private void treeList1_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            BindDgv();
            defectTypeId = e.Node.GetDisplayText("ID");
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0) return;
            this.DefectID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle,"ID");
            this.DefectName = gridView1.GetRowCellValue(gridView1.FocusedRowHandle,"Name");
            this.Close();
        }

        //选择按钮
        private void barButtonItemChose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0) return;
            this.DefectID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID");
            this.DefectName = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Name");
            this.Close();
        }
      
    }
}
