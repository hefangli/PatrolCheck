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
    public partial class frmReportSummaryByEmployee : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public frmReportSummaryByEmployee()
        {
            InitializeComponent();
            this.dtStartTime.EditValue = (DateTime.Now.AddDays(-1).ToShortDateString() + " 00:00");
            this.dtEndTime.EditValue = (DateTime.Now.ToShortDateString() + " 23:59");
            bindTlEmployee();
        }

        private void bindTlEmployee()
        {
            string sql = @"Declare @MaxOrgID Int;Select @MaxOrgID=max(ID) From Organization;"
                           + "Select ID,Organization_ID,null as EmployeeID,Name,"
                                + "(Case OrgType When 8 Then 'True' Else 'False' End) as IsGroup,"
                                + "'False' as IsEmployee from Organization Where ValidState=" + (Int32)CodesValidState.Exit
                           + "Union All "
                           + " Select @MaxOrgID+ID,Organization_ID,ID,Name,'False','True' From Employee Where ValidState=" + (Int32)CodesValidState.Exit;
            DataSet ds = SqlHelper.ExecuteDataset(sql);
            tlEmployee.DataSource = ds.Tables[0];
        }

        private string treeVisitor(TreeListNode areaNode)
        {
            string ids = "";
            if (areaNode.GetDisplayText("IsEmployee") == "True")
            {
                ids += areaNode.GetDisplayText("EmployeeID") + ",";
            }
            foreach (TreeListNode n in areaNode.Nodes)
            {
                ids += treeVisitor(n);
            }
            return ids;
        }

        private void tlEmployee_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            SqlParameter[] pars = new SqlParameter[] { 
               new SqlParameter("@StartTime",SqlDbType.DateTime),
               new SqlParameter("@EndTime",SqlDbType.DateTime),
               new SqlParameter("@EmployeeIDs",SqlDbType.VarChar)
            };
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItemSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
