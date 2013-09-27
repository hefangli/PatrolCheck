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
    public partial class frmPostShiftsSet : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public frmPostShiftsSet()
        {
            InitializeComponent();
            BindTreeList();
        }

        private void BindTreeList()
        {
            DataSet ds = SqlHelper.ExecuteDataset(@"Select *,(select meaning from codes where code=Post.ValidState and Purpose='ValidState') as ValidStateMeaning 
                      from Post Where ValidState=" + (Int32)CodesValidState.Exit);
            tlOrganization.DataSource = ds.Tables[0];
        }

        private void BindGvShifts()
        {
            if (tlOrganization.FocusedNode != null)
            {
                string sql = "Select *,(select name from post where id=shifts.post_id) as PostName From Shifts where Post_ID=" + tlOrganization.FocusedNode.GetDisplayText("ID") + " order by ID asc";
                DataSet ds = SqlHelper.ExecuteDataset(sql);
                this.gridControl1.DataSource = ds.Tables[0];
            }
            else
            {
                this.gridControl1.DataSource = null;
            }
        }

        private void barButtonItemNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (tlOrganization.FocusedNode != null)
            //{
            //    string sqlInsert = "Insert Into Shifts(Post_ID,Name) values(" + tlOrganization.FocusedNode.GetDisplayText("ID") + ",'新建班次')";
            //    SqlHelper.ExecuteNonQuery(sqlInsert);
            //    BindGvShifts();
            //}
            //新建班次：
            if(tlOrganization .FocusedNode !=null)
            {
                frmPostShiftsSetNew setnew = new frmPostShiftsSetNew();
                setnew.IsEdit = false;
                setnew.Post_id = tlOrganization.FocusedNode.GetDisplayText("ID");
                setnew.ShowDialog();
                BindGvShifts();
            }
        }

        private void gvShifts_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
             int rowIndex = gvShifts.FocusedRowHandle;
             string sql = "Update Shifts Set Name=@name,StartTime=@starttime,EndTime=@endtime where id=" + gvShifts.GetRowCellValue(rowIndex, "ID");
                SqlParameter[] pars = new SqlParameter[] {
                new SqlParameter("@name",gvShifts.GetRowCellValue(rowIndex,"Name")),
                new SqlParameter("@starttime",gvShifts.GetRowCellValue(rowIndex,"StartTime")),
                new SqlParameter("@endtime",gvShifts.GetRowCellValue(rowIndex,"EndTime"))
            };
             if (SqlHelper.ExecuteNonQuery(sql, pars) != 1)
             {
                 MessageBox.Show("修改失败，请稍后再试");
             }
          
        }

        private void barButtonItemDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int rowIndex = gvShifts.FocusedRowHandle;
            string sql = "Delete From Shifts where id=" + gvShifts.GetRowCellValue(rowIndex, "ID");
            if (MessageBox.Show("您确定删除该信息吗？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (SqlHelper.ExecuteNonQuery(sql) != 1)
                {
                    MessageBox.Show("删除失败，请稍后再试");
                }
                BindGvShifts();
            }
        }
        private bool isEdit = false;
        private void barButtonItemEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (!isEdit)
            //{
            //    barButtonItemEdit.Caption = "取消修改";
            //    isEdit = true;

            //    gridColumnName.OptionsColumn.AllowEdit = true;
            //    gridColumnEndTime.OptionsColumn.AllowEdit = true;
            //    gridColumnStartTime.OptionsColumn.AllowEdit = true;
            //}
            //else
            //{
            //     barButtonItemEdit.Caption = "修改";
            //     isEdit = false;

            //     gridColumnName.OptionsColumn.AllowEdit = false;
            //     gridColumnEndTime.OptionsColumn.AllowEdit = false;
            //     gridColumnStartTime.OptionsColumn.AllowEdit = false;
            //}

            //编辑班次：         
            if (tlOrganization.FocusedNode != null)
            {
                frmPostShiftsSetNew setnew = new frmPostShiftsSetNew();
                setnew.IsEdit = true;
                setnew.Shift_id = gvShifts.GetRowCellValue(gvShifts.FocusedRowHandle, "ID");
                setnew.Post_id = tlOrganization.FocusedNode.GetDisplayText("ID");
                setnew.ShowDialog();
                BindGvShifts();
            }
        }
        
        //private void frmPostShiftsSet_Load(object sender, EventArgs e)
        //{
             
        //}
        private void tlOrganization_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            BindGvShifts();
        }
    }
}
