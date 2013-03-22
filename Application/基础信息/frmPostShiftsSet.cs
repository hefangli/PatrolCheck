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
    public partial class frmPostShiftsSet : Form
    {
        public frmPostShiftsSet()
        {
            InitializeComponent();
        }
        public object Post_ID = null;

        private void BindGvShifts()
        {
            string sql = "Select *,(select name from post where id=shifts.post_id) as PostName From Shifts where Post_ID=" + Post_ID + " order by ID asc";
            DataSet ds = SqlHelper.ExecuteDataset(sql);
            this.gridControl1.DataSource = ds.Tables[0];
        }

        private void barButtonItemNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string sqlInsert = "Insert Into Shifts(Post_ID,Name) values(" + Post_ID + ",'新建班次')";
            SqlHelper.ExecuteNonQuery(sqlInsert);
            BindGvShifts();
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
            BindGvShifts();
        }

        private void barButtonItemDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int rowIndex = gvShifts.FocusedRowHandle;
            string sql = "Delete From Shifts where id=" + gvShifts.GetRowCellValue(rowIndex, "ID");
            if (SqlHelper.ExecuteNonQuery(sql) != 1)
            {
                MessageBox.Show("删除失败，请稍后再试");
            }
            BindGvShifts();
        }
        private bool isEdit = true;
        private void barButtonItemEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (isEdit)
            {
                barButtonItemEdit.Caption = "取消修改";
                isEdit = false;

                gridColumnName.OptionsColumn.AllowEdit = true;
                gridColumnEndTime.OptionsColumn.AllowEdit = true;
                gridColumnStartTime.OptionsColumn.AllowEdit = true;
            }
            else
            {
                 barButtonItemEdit.Caption = "修改";
                 isEdit = true;

                 gridColumnName.OptionsColumn.AllowEdit = false;
                 gridColumnEndTime.OptionsColumn.AllowEdit = false;
                 gridColumnStartTime.OptionsColumn.AllowEdit = false;
            }
        }

        private void frmPostShiftsSet_Load(object sender, EventArgs e)
        {
            BindGvShifts();
        }
    }
}
