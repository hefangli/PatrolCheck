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
    public partial class frmReportSummaryByPlan : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public frmReportSummaryByPlan()
        {
            InitializeComponent();
            this.dtStartTime.EditValue = (DateTime.Now.AddDays(-1).ToShortDateString() + " 00:00");
            this.dtEndTime.EditValue = DateTime.Parse((DateTime.Now.ToShortDateString() + " 23:59"));
            bindTreelistCheckPlan();
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

        private void bindGvPlanChecking()
        {
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
                if (tlCheckPlan.FocusedNode != null)
                {
                    planIDs += treeVisitor(tlCheckPlan.FocusedNode);
                }
            }
            planIDs = planIDs == "" ? "" : planIDs.TrimEnd(',');
            SqlParameter[] pars = new SqlParameter[]{
               new SqlParameter("@StartTime",SqlDbType.DateTime),
               new SqlParameter("@EndTime",SqlDbType.DateTime),
               new SqlParameter("@PlanIDs",SqlDbType.VarChar)
            };
            pars[0].Value = dtStartTime.EditValue != null ? dtStartTime.EditValue : "1753/1/1";
            pars[1].Value = dtEndTime.EditValue != null ? dtEndTime.EditValue : "9999/12/31";
            pars[2].Value = planIDs;
            DataSet ds = SqlHelper.ExecuteDataset("GetSumByPlan", CommandType.StoredProcedure, pars);
            this.gridControl1.DataSource=ds.Tables[0];
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

        private void tlCheckPlan_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            bindGvPlanChecking();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bindGvPlanChecking();
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
