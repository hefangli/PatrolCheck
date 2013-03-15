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
    public partial class frmReportSearchByPlan : Form
    {
        public frmReportSearchByPlan()
        {
            InitializeComponent();
            bindTreelistCheckPlan();
        }

        private void frmReportSearch_Load(object sender, EventArgs e)
        {
            bindGvItemChecking(false);
        }

        private void bindTreelistCheckPlan()
        {
            tlCheckPlan.BeginUnboundLoad();
            using (SqlDataReader drPost = SqlHelper.ExecuteReader("Select * from post where  validstate=" + (Int32)CodesValidState.Exit))
            {
                TreeListNode nodeParent;
                while (drPost.Read())
                {
                    nodeParent = tlCheckPlan.AppendNode(new object[] { drPost["ID"], drPost["Name"] }, null);
                    using (SqlDataReader drCheckPlan = SqlHelper.ExecuteReader("Select * from checkplan where post_id=" + drPost["id"]))//" and validstate=" + (Int32)CodesValidState.Exit))
                    {
                        if (drCheckPlan.HasRows)
                        {
                            nodeParent.HasChildren = true;
                            while (drCheckPlan.Read())
                            {
                                tlCheckPlan.AppendNode(new object[] { drCheckPlan["ID"], drCheckPlan["Name"] }, nodeParent);
                            }
                        }
                        else
                        {
                            nodeParent.HasChildren = false;
                        }
                    }
                }
            }
            tlCheckPlan.EndUnboundLoad();
        }

        private void bindGvItemChecking(bool isSearch)
        {
            //默认查询昨天和今天的数据
            //Nullable<DateTime> timeNull = null;
            DateTime? startTime = null, endTime = null;
            if (!isSearch)
            {
                startTime = DateTime.Parse((DateTime.Now.AddDays(-1).ToShortDateString() + " 00:00"));
                endTime = DateTime.Parse((DateTime.Now.ToShortDateString() + " 23:59"));
            }
            else
            {
                if (dtStartTime.EditValue != null)
                {
                    startTime = DateTime.Parse(dtStartTime.EditValue.ToString());
                }
                if (dtEndTime.EditValue != null)
                {
                    endTime = DateTime.Parse(dtEndTime.EditValue.ToString());
                }
            }
            string sqlSelect = "Select * From V_ItemChecking Where 1=1 ";
            if(startTime!=null)
            {
              sqlSelect+=" and PStartTime>='" + startTime + "'";
            }
            if(endTime!=null)
            {
                sqlSelect += "and PEndTime<='" + endTime + "'";
            }
            if (isSearch)
            {

                if (!chkAll.Checked)
                {
                    sqlSelect += " and CheckPlan_ID In(";
                    string planIDs = "";
                    if (tlCheckPlan.FocusedNode.HasChildren)
                    {
                        foreach (TreeListNode node in tlCheckPlan.FocusedNode.Nodes)
                        {
                            planIDs += node.GetDisplayText("ID") + ",";
                        }
                    }
                    else
                    {
                        planIDs += tlCheckPlan.FocusedNode.GetDisplayText("ID") + ",";
                    }
                    sqlSelect += planIDs.TrimEnd(',') + ")";
                }
                if (tbCheckPlan.Text != "")
                {
                    sqlSelect += " and CheckPlanName like '%" + tbCheckPlan.Text.Trim() + "%'";
                }
                if (tbCheckPoint.Text != "")
                {
                    sqlSelect += " and LogicalCheckPointName like '%" + tbCheckPoint.Text.Trim() + "%'";
                }
                if (tbCheckItem.Text != "")
                {
                    sqlSelect += " and CheckItemName like '%" + tbCheckItem.Text.Trim() + "%'";
                }
            }
            else
            {
                if (tlCheckPlan.FocusedNode != null)
                {
                    sqlSelect += " and CheckPlan_ID In(";
                    string planIDs = "";
                    if (tlCheckPlan.FocusedNode.HasChildren)
                    {
                        foreach (TreeListNode node in tlCheckPlan.FocusedNode.Nodes)
                        {
                            planIDs += node.GetDisplayText("ID") + ",";
                        }
                    }
                    else
                    {
                        planIDs += tlCheckPlan.FocusedNode.GetDisplayText("ID") + ",";
                    }
                    sqlSelect += planIDs.TrimEnd(',') + ")";
                }
            }
            DataSet ds = SqlHelper.ExecuteDataset(sqlSelect);
            this.gridControl1.DataSource = ds.Tables[0];
        }

        private void bindComboBox()
        {
            //状态
        }

        private void tlCheckPlan_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            bindGvItemChecking(false);
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
            bindGvItemChecking(true);
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
