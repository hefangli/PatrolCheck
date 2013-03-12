using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars.Docking;
using System.Data.SqlClient;

namespace WorkStation
{
    public partial class frmCheckPlan : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public frmCheckPlan()
        {
            InitializeComponent();
            BindTreeList();
        }

        private void frmCheckPlan_Load(object sender, EventArgs e)
        {
            BindComboBox();
        }

        private void BindTreeList()
        {
            DataSet ds = SqlHelper.ExecuteDataset(@"Select *,(select meaning from codes where code=Post.ValidState and Purpose='ValidState') as ValidStateMeaning 
                      from Post Where ValidState=" + (Int32)CodesValidState.Exit);
            tlOrganization.DataSource = ds.Tables[0];
        }

        private void BindComboBox()
        {
            using (SqlDataReader dr = SqlHelper.ExecuteReader("Select Code,Meaning from Codes Where Purpose='ValidState'"))
            {
                cboValidState.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem("全选", -1, -1));
                while (dr.Read())
                {
                    cboValidState.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr["Meaning"].ToString(), dr["Code"], -1));
                }
                cboValidState.EditValue = 1;
            }
        }

        private void getDgvPlan()
        {
            string sql = @"Select                   'False' as isCheck,
                                                    c.ID,
                                                    c.Name,
                                                    c.StartTime,  
                                                    c.Duration,
                                                    c.EndTime,
                                                    p.Name as PostName,
                                                    p.ID as Post_ID,
                                                    r.Name as RouteName, 
                                                    r.ID as Route_ID,
                                                    (select name from employee where id=c.operator) as OperatorName,
                                                    c.operator as Operator,
                                                    c.Interval,
                                                    c.TimeDeviation,
                                                    (select meaning from codes where code= IntervalUnit and purpose='intervalunit') as IntervalUnitName,
                                                    c.intervalunit as IntervalUnit,
                                                    c.EffectiveTime,
                                                    c.IneffectiveTime,
                                                    c.Planner,
                                                    (select meaning from codes where code= planstate and purpose='planstate') as PlanState  
                                                     From Checkplan as  c left join CheckRoute  as r on c.route_id=r.id 
                                                              left join Post p on c.post_id=p.id 
                                                              where 1=1 ";
            if (tlOrganization.FocusedNode != null)
            {
                sql += " and c.post_id="+tlOrganization.FocusedNode.GetDisplayText("ID");
            }
            DataSet ds = SqlHelper.ExecuteDataset(sql);
            this.gridControlPlan.DataSource = ds.Tables[0];
        }

        private void tlOrganization_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            getDgvPlan();
        }

        private void barButtonItemNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tlOrganization.FocusedNode != null)
            {
                frmCheckPlanNew planNew = new frmCheckPlanNew();
                planNew.Left = this.Left + (this.Width - planNew.Width) / 2;
                planNew.Top = this.Top + (this.Height - planNew.Height) / 2;
                planNew.IsEdit = false;
                planNew.PostID = tlOrganization.FocusedNode.GetDisplayText("ID");
                planNew.PlanID = null;
                planNew.ShowDialog();
                getDgvPlan();
            }
        }

        private void barButtonItemEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int rowindex = gvPlan.FocusedRowHandle;
            if (rowindex < 0||tlOrganization.FocusedNode==null)
            {
                return;
            }
            frmCheckPlanNew planEdit = new frmCheckPlanNew();
            planEdit.Left = this.Left + (this.Width - planEdit.Width) / 2;
            planEdit.Top = this.Top + (this.Height - planEdit.Height) / 2;
            planEdit.IsEdit = true;
            planEdit.PostID = tlOrganization.FocusedNode.GetDisplayText("ID");
            planEdit.PlanID = gvPlan.GetRowCellValue(rowindex, "ID").ToString();
            planEdit.ShowDialog();
            getDgvPlan();
        }

        private void barButtonItemDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SendKeys.SendWait("{TAB}"); SendKeys.SendWait("+{TAB}");
            string Del = "";
            string strsql = "Delete From CheckPlan Where ID in(";
            for (int i = 0; i < gvPlan.RowCount; i++)
            {
                object isCheck = gvPlan.GetRowCellValue(i, "isCheck");
                if (Convert.ToBoolean(isCheck) == true)
                {
                    Del += gvPlan.GetRowCellValue(i, "ID") + ",";
                }
            }
            if (Del != "")
            {
                strsql = strsql + Del.TrimEnd(',')+")";
                SqlHelper.ExecuteNonQuery(strsql);
                getDgvPlan();
            }
            else
            {
                MessageBox.Show("请选择要删除的项。");
            }            
        }

        private void barButtonItemSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = @"Select                   'False' as isCheck,
                                                    c.ID,
                                                    c.Name,
                                                    c.StartTime,  
                                                    c.Duration,
                                                    c.EndTime,
                                                    p.Name as PostName,
                                                    p.ID as Post_ID,
                                                    r.Name as RouteName, 
                                                    r.ID as Route_ID,
                                                    (select name from employee where id=c.operator) as OperatorName,
                                                    c.operator as Operator,
                                                    c.Interval,
                                                    c.TimeDeviation,
                                                    (select meaning from codes where code= IntervalUnit and purpose='intervalunit') as IntervalUnitName,
                                                    c.intervalunit as IntervalUnit,
                                                    c.EffectiveTime,
                                                    c.IneffectiveTime,
                                                    c.Planner,
                                                    (select meaning from codes where code= planstate and purpose='planstate') as PlanState  
                                                     From Checkplan as  c left join CheckRoute  as r on c.route_id=r.id 
                                                              left join Post p on c.post_id=p.id 
                                                              where 1=1  ";
            if (tbName.Text != "")
            {
                sql += " and c.Name like '%"+tbName.Text.Trim()+"%'";
            }
            if (chkAll.Checked != true && tlOrganization.FocusedNode!=null)
            {
                sql += " and c.Post_ID="+tlOrganization.FocusedNode.GetDisplayText("ID");
            }
            if (Convert.ToInt32(cboValidState.EditValue) != (int)CodesValidState.ChoseAll)
            {
                sql += " and c.validstate=" + cboValidState.EditValue;
            }
            DataSet ds = SqlHelper.ExecuteDataset(sql);
            gridControlPlan.DataSource = ds.Tables[0];
        }

        private void gvPlan_DoubleClick(object sender, EventArgs e)
        {
            int rowindex = gvPlan.FocusedRowHandle;
            if (rowindex < 0 || tlOrganization.FocusedNode == null)
            {
                return;
            }
            frmCheckPlanNew planEdit = new frmCheckPlanNew();
            planEdit.Left = this.Left + (this.Width - planEdit.Width) / 2;
            planEdit.Top = this.Top + (this.Height - planEdit.Height) / 2;
            planEdit.IsEdit = true;
            planEdit.PostID = tlOrganization.FocusedNode.GetDisplayText("ID");
            planEdit.PlanID = gvPlan.GetRowCellValue(rowindex, "ID").ToString();
            planEdit.ShowDialog();
            getDgvPlan();
        }

        
    }   
}
