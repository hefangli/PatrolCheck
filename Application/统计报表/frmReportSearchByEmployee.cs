using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraBars.Docking;

namespace WorkStation
{
    public partial class frmReportSearchByEmployee : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public frmReportSearchByEmployee()
        {
            InitializeComponent();
            this.dtStartTime.EditValue = (DateTime.Now.AddDays(-1).ToShortDateString() + " 00:00");
            this.dtEndTime.EditValue = (DateTime.Now.ToShortDateString() + " 23:59");
            bindTlEmployee();
        }

        private void frmReportSearchByEmployee_Load(object sender, EventArgs e)
        {

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

        private void bindGvItemChecking()
        {
            string sqlSelect = "Select * From V_ItemChecking Where 1=1 ";
            if (dtStartTime.EditValue != null)
            {
                sqlSelect += " and PStartTime>='" + dtStartTime.EditValue + "'";
            }
            if (dtEndTime.EditValue != null)
            {
                sqlSelect += "and PEndTime<='" + dtEndTime.EditValue + "'";
            }
            string employeeIds = "";
            TreeListNode fn = tlEmployee.FocusedNode;
            if (fn != null)
            {
                employeeIds = treeVisitor(fn);
            }
            sqlSelect += employeeIds == "" ? "" : ("and Employee_ID in (" + employeeIds.TrimEnd(',') + ")");

            DataSet ds = SqlHelper.ExecuteDataset(sqlSelect);
            this.gridControl1.DataSource = ds.Tables[0];
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bindGvItemChecking();
        }

        private void tlEmployee_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            bindGvItemChecking();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
    }
}
