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
    public partial class frmReportSummaryByPlan : Form
    {
        public frmReportSummaryByPlan()
        {
            InitializeComponent();
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
            
        }

        private void tlCheckPlan_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {

        }
    }
}
