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
    public partial class frmPostSchedulesSet : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public frmPostSchedulesSet()
        {
            InitializeComponent();
            BindTreeList();
        }

        bool isEdit = false; //是否启用编辑

        private void BindTreeList()
        {
            DataSet ds = SqlHelper.ExecuteDataset(@"Select *,(select meaning from codes where code=Post.ValidState and Purpose='ValidState') as ValidStateMeaning 
                      from Post Where ValidState=" + (Int32)CodesValidState.Exit);
            tlOrganization.DataSource = ds.Tables[0];
        }

        private void bindGvSchedules()
        {
            if (tlOrganization.FocusedNode == null) return;
            string strSql = "Select * from Schedules where post_id ="+tlOrganization.FocusedNode.GetDisplayText("ID");
            DataSet ds = SqlHelper.ExecuteDataset(strSql);
            this.gridControl1.DataSource=ds.Tables[0];
        }

        private void bindRepository()
        {
            using (SqlDataReader dr = SqlHelper.ExecuteReader("Select * From Shifts Where Post_ID=" + tlOrganization.FocusedNode.GetDisplayText("ID")))
            {
                while (dr.Read())
                {
                    riicboShifts.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr["Name"].ToString(), dr["ID"], -1));
                }
            }
            using (SqlDataReader dr = SqlHelper.ExecuteReader("Select * From Team Where Post_ID=" + tlOrganization.FocusedNode.GetDisplayText("ID")))
            {
                while (dr.Read())
                {
                    riicboTeam.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr["Name"].ToString(), dr["ID"], -1));
                }
            }
        }

        private void barAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string insertSql = "INSERT dbo.Schedules (Team_ID,Shifts_ID,Post_ID,Name,Date) VALUES (null,null,"+tlOrganization.FocusedNode.GetDisplayText("ID")+",'新建','"+DateTime.Now+"')";
            SqlHelper.ExecuteNonQuery(insertSql);
            bindGvSchedules();
        }

        private void barEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!isEdit)
            {
                barEdit.Caption = "取消编辑";
                isEdit = true;
                this.gvSchedules.OptionsBehavior.Editable = true;
                this.gridColumnTeam_ID.OptionsColumn.AllowEdit = true;
                this.gridColumnShifts_ID.OptionsColumn.AllowEdit = true;
                this.gridColumnDate.OptionsColumn.AllowEdit = true;
            }
            else
            {
                barEdit.Caption = "编辑";
                isEdit = false;
                this.gvSchedules.OptionsBehavior.Editable = false;
                this.gridColumnTeam_ID.OptionsColumn.AllowEdit = false;
                this.gridColumnShifts_ID.OptionsColumn.AllowEdit = false;
                this.gridColumnDate.OptionsColumn.AllowEdit = false;
            }
        }

        private void barDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gvSchedules.FocusedRowHandle < 0) return;
            string delSql = "Delete From Schedules Where ID=" + gvSchedules.GetRowCellDisplayText(gvSchedules.FocusedRowHandle, "ID");
            SqlHelper.ExecuteNonQuery(delSql);
            bindGvSchedules();
        }

        private void tlOrganization_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            bindGvSchedules();
        }

        private void frmPostSchedulesSet_Load(object sender, EventArgs e)
        {
            bindRepository();
        }

        private void gvSchedules_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            object teamID = gvSchedules.GetRowCellValue(e.RowHandle, "Team_ID");
            object shiftsID = gvSchedules.GetRowCellValue(e.RowHandle, "Shifts_ID");
            string id = gvSchedules.GetRowCellDisplayText(e.RowHandle, "ID");
            object date = gvSchedules.GetRowCellValue(e.RowHandle,"Date");
            string updateSql = "Update Schedules Set Team_ID=@teamid,Shifts_ID=@shiftsid,Date=@date where id=@id";
            SqlParameter[] pars = new SqlParameter[] { 
               new SqlParameter("@teamid",teamID),
               new SqlParameter("@shiftsid",shiftsID),
               new SqlParameter("@date",date),
               new SqlParameter("@id",id)
            };

            SqlHelper.ExecuteNonQuery(updateSql, pars);
            bindGvSchedules();
        }
    }
}
