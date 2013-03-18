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
using DevExpress.XtraBars.Docking;

namespace WorkStation
{
    public partial class frmReportSearchByPlan : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public frmReportSearchByPlan()
        {
            InitializeComponent();
            bindTreelistCheckPlan();
        }

        private void frmReportSearch_Load(object sender, EventArgs e)
        {
            this.dtStartTime.EditValue = (DateTime.Now.AddDays(-1).ToShortDateString() + " 00:00");
            this.dtEndTime.EditValue = DateTime.Parse((DateTime.Now.ToShortDateString() + " 23:59"));
        }

        private void bindTreelistCheckPlan()
        {
            tlCheckPlan.BeginUnboundLoad();
            string sql = @"Declare @maxOrgID Int Select @maxOrgID=Max(ID) From organization;
                           Declare @maxPostID Int Select @maxPostID=Max(ID) From Post;
                           Select ID,Organization_ID as ParentID,Name,ID as TID,
                                  'True' as IsOrganization,'False' as IsPost,'False' as IsCheckPlan 
                           From Organization Where OrgType<>8 and ValidState="+(Int32)CodesValidState.Exit
                           +" Union All "
                           +"Select @maxOrgID+ID,Organization_ID,Name,ID,'False','True','False' From Post Where ValidState="+(Int32)CodesValidState.Exit
                           +" Union All "
                           +"Select @maxOrgID+@maxPostID+ID,@maxOrgID+Post_ID,Name,ID,'False','False','True' "  
                           +"From CheckPlan Where ValidState="+(Int32)CodesValidState.Exit;
            DataSet ds = SqlHelper.ExecuteDataset(sql);
            tlCheckPlan.DataSource=ds.Tables[0];
            tlCheckPlan.EndUnboundLoad();
        }

        private void bindGvItemChecking()
        {
            //默认查询昨天和今天的数据
            //Nullable<DateTime> timeNull = null;
            DateTime? startTime = null, endTime = null;
            if (dtStartTime.EditValue != null)
            {
                startTime = DateTime.Parse(dtStartTime.EditValue.ToString());
            }
            if (dtEndTime.EditValue != null)
            {
                endTime = DateTime.Parse(dtEndTime.EditValue.ToString());
            }
            string sqlSelect = "Select * From V_ItemChecking Where 1=1 ";
            if (startTime != null)
            {
                sqlSelect += " and PStartTime>='" + startTime + "'";
            }
            if (endTime != null)
            {
                sqlSelect += "and PEndTime<='" + endTime + "'";
            }

            sqlSelect += " and CheckPlan_ID In(";
            if (chkAll.Checked)
            {
                string planIDs = "";
                foreach (TreeListNode node in tlCheckPlan.Nodes)
                {
                    planIDs += treeVisitor(node);
                }
                if (planIDs != "")
                {
                    sqlSelect += planIDs.TrimEnd(',') + ")";
                }
            }
            else
            {
                string planIDs = "";
                if (tlCheckPlan.FocusedNode != null)
                {
                    planIDs += treeVisitor(tlCheckPlan.FocusedNode);
                }
                if (planIDs != "")
                {
                    sqlSelect += planIDs.TrimEnd(',') + ")";
                }
            }
            if (tbCheckPlan.Text != "")
            {
                sqlSelect += " and CheckPlanName like '%" + tbCheckPlan.Text.Trim() + "%'";
            }
            if (tbCheckPoint.Text != "")
            {
                sqlSelect += " and PhysicalCheckPointName like '%" + tbCheckPoint.Text.Trim() + "%'";
            }
            if (tbCheckItem.Text != "")
            {
                sqlSelect += " and CheckItemName like '%" + tbCheckItem.Text.Trim() + "%'";
            }           
            DataSet ds = SqlHelper.ExecuteDataset(sqlSelect);
            this.gridControl1.DataSource = ds.Tables[0];
        }

        private string treeVisitor(TreeListNode areaNode)
        {
            string pids = "";
            pids += areaNode.GetDisplayText("ID") + ",";
            foreach (TreeListNode n in areaNode.Nodes)
            {
                pids += treeVisitor(n);
            }
            return pids;
        }

        private void bindComboBox()
        {
            //状态
        }

        private void tlCheckPlan_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            bindGvItemChecking();
        }

        private void gvItemChecking_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            object id = this.gvItemChecking.GetRowCellValue(e.RowHandle, "CheckRouteName");
            if (id != null && id.ToString() == "测试路线")
            {
                e.Appearance.ForeColor = Color.Red;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
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

        private void dpSearch_Click(object sender, EventArgs e)
        {

        }

    }
}
