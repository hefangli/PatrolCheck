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
    public partial class frmReportRunSituation : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public frmReportRunSituation()
        {
            InitializeComponent();
            bindComboBox();
            this.dtStartTime.EditValue = (DateTime.Now.AddDays(-1).ToShortDateString() + " 00:00");
            this.dtEndTime.EditValue = DateTime.Parse((DateTime.Now.ToShortDateString() + " 23:59"));
            bindTreelistCheckPlan();
        }

        private void bindComboBox()
        {
            using (SqlDataReader dr = SqlHelper.ExecuteReader("Select Code,Meaning from Codes Where Purpose='OnTime'"))
            {
                cboState.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem("全选", -1, -1));
                while (dr.Read())
                {
                    cboState.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr["Meaning"].ToString(), dr["Code"], -1));
                }
                cboState.EditValue = -1;
            }
        }

        private void bindTreelistCheckPlan()
        {
            tlCheckPlan.BeginUnboundLoad();
            string sql = @"Declare @maxOrgID Int Select @maxOrgID=Max(ID) From organization;
                           Declare @maxPostID Int Select @maxPostID=Max(ID) From Post;
                           Select ID,Organization_ID as ParentID,Name,ID as TID,
                                  'True' as IsOrganization,'False' as IsPost,'False' as IsCheckPlan 
                           From Organization Where OrgType<>8 and ValidState=" + (Int32)CodesValidState.Exit
                           + " Union All "
                           + "Select @maxOrgID+ID,Organization_ID,Name,ID,'False','True','False' From Post Where ValidState=" + (Int32)CodesValidState.Exit
                           + " Union All "
                           + "Select @maxOrgID+@maxPostID+ID,@maxOrgID+Post_ID,Name,ID,'False','False','True' "
                           + "From CheckPlan Where ValidState=" + (Int32)CodesValidState.Exit;
            DataSet ds = SqlHelper.ExecuteDataset(sql);
            tlCheckPlan.DataSource = ds.Tables[0];
            tlCheckPlan.EndUnboundLoad();
        }

        private void bindGvRouteChecking()
        {
            string sqlSelect = @"select ID,PercentComplete,
 (Select Name From CheckRoute Where ID=CheckRoute_ID) as CheckRouteName,
 (Select Name From CheckPlan where ID=CheckPlan_ID) as CheckPlanName,
 (Select Name From Organization where ID=Organization_ID) as OrganizationName,
 (Select Name From Employee Where ID=Employee_ID) as EmployeeName,
 (Select Meaning From codes where code=OnTime and Purpose='OnTime') as OnTimeMeaning 
from routechecking Where 1=1 ";
            string planIDs = "";
            if (chkAll.Checked)
            {
                foreach (TreeListNode node in tlCheckPlan.Nodes)
                {
                    planIDs += treeVisitor(node);
                }
            }
            else
            {
                TreeListNode node = tlCheckPlan.FocusedNode;
                if (node != null)
                {
                    planIDs += treeVisitor(node);
                }
            }
            if (planIDs.Trim() != "")
            {
                sqlSelect += " and CheckPlan_ID in("+planIDs.TrimEnd(',')+")";
                if (dtStartTime.EditValue != null)
                {
                    sqlSelect += " and StartTime>='"+dtStartTime.EditValue+"'";
                }
                if (dtEndTime.EditValue != null)
                {
                    sqlSelect += " and EndTime<='"+dtEndTime.EditValue+"'";
                }
                if (cboState.EditValue.ToString() != "-1")
                {
                    sqlSelect += " and OnTime=" + cboState.EditValue;
                }
                DataSet ds = SqlHelper.ExecuteDataset(sqlSelect);
                this.gridControl1.DataSource = ds.Tables[0];
            }
        }

        private string treeVisitor(TreeListNode areaNode)
        {
            string pids = "";
            if (areaNode.GetDisplayText("IsCheckPlan") == "True")
            {
                pids += areaNode.GetDisplayText("TID") + ",";
            }
            foreach (TreeListNode n in areaNode.Nodes)
            {
                pids += treeVisitor(n);
            }
            return pids;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bindGvRouteChecking();
        }

        private void tlCheckPlan_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            bindGvRouteChecking();
        }

        private void gvRouteChecking_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            object PercentComplete = this.gvRouteChecking.GetRowCellValue(e.RowHandle, "PercentComplete");
            if (PercentComplete != null && Convert.ToDouble(PercentComplete) != 1)
            {
                e.Appearance.ForeColor = Color.Red;
            }
        }

        private void barPDF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            string path = folderBrowserDialog1.SelectedPath;
            if (path != "")
            {
                string fileName = path + "\\Defect" + DateTime.Now.Year.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + ".pdf";
                gvRouteChecking.ExportToPdf(fileName);
            }
        }

        private void barExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            string path = folderBrowserDialog1.SelectedPath;
            if (path != "")
            {
                string fileName = path + "\\Defect" + DateTime.Now.Year.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + ".Xlsx";
                gvRouteChecking.ExportToXlsx(fileName);
            }
        }
    }
}
