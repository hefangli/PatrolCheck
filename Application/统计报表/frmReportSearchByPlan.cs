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
            this.dtStartTime.EditValue = (DateTime.Now.AddDays(-1).ToShortDateString() + " 00:00");
            this.dtEndTime.EditValue = DateTime.Parse((DateTime.Now.ToShortDateString() + " 23:59"));
            bindTreelistCheckPlan();
        }

        private void frmReportSearch_Load(object sender, EventArgs e)
        {

        }

        private void bindTreelistCheckPlan()
        {
            tlCheckPlan.BeginUnboundLoad();
//            string sql = @"Declare @maxOrgID Int Select @maxOrgID=Max(ID) From organization;
//                           Declare @maxPostID Int Select @maxPostID=Max(ID) From Post;
//                           Select ID,Organization_ID as ParentID,Name,ID as TID,
//                                  'True' as IsOrganization,'False' as IsPost,'False' as IsCheckPlan 
//                           From Organization Where OrgType<>8 and ValidState=" + (Int32)CodesValidState.Exit
//                           + " Union All "
//                           + "Select @maxOrgID+ID,Organization_ID,Name,ID,'False','True','False' From Post Where ValidState=" + (Int32)CodesValidState.Exit
//                           + " Union All "
//                           + "Select @maxOrgID+@maxPostID+ID,@maxOrgID+Post_ID,Name,ID,'False','False','True' "
//                           + "From CheckPlan Where ValidState=" + (Int32)CodesValidState.Exit;


            string sql = @"DECLARE @maxPostID INT "
                         +"SELECT @maxPostID=MAX(ID) FROM dbo.Post;"                           
                         +"SELECT ID,NULL AS ParentID,Name,"
                         +"(SELECT Name FROM dbo.organization WHERE ID=dbo.Post.organization_ID) AS OrganizationName,"
                         + "ID AS TID,'True' AS IsPost,'False' AS IsCheckPlan  FROM  dbo.Post Where ValidState=" + (Int32)CodesValidState.Exit
+" UNION ALL "
+"SELECT @maxPostID+ID,Post_ID,Name,NULL,"
+"ID AS TID,'False','True' "
+"FROM dbo.CheckPlan Where ValidState="+(Int32)CodesValidState.Exit;

            DataSet ds = SqlHelper.ExecuteDataset(sql);
            tlCheckPlan.DataSource = ds.Tables[0];
            tlCheckPlan.EndUnboundLoad();
        }

        private void bindGvItemChecking()
        {
            //默认查询昨天和今天的数据
            //Nullable<DateTime> timeNull = null;
            //DateTime? startTime = null, endTime = null;
            string sqlSelect = "Select * From V_ItemChecking Where 1=1 ";
            if (dtStartTime.EditValue != null)
            {
                sqlSelect += " and PStartTime>='" + dtStartTime.EditValue + "'";
            }
            if (dtEndTime.EditValue != null)
            {
                sqlSelect += "and PEndTime<='" + dtEndTime.EditValue + "'";
            }

            sqlSelect += " and CheckPlan_ID In(";
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
            if (planIDs != "")
            {
                sqlSelect += planIDs.TrimEnd(',') + ")";
            }
            else
            {
                sqlSelect += " Null )";
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
            bindGvItemChecking();
        }

        private void gvItemChecking_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            object id = this.gvItemChecking.GetRowCellValue(e.RowHandle, "HasDefect");
            if (id != null && id.ToString() == "1")
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
            bindGvItemChecking();
        }

        private void barPDF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            saveFileDialog1.Filter = "PDF文档|*.pdf";
            saveFileDialog1.ShowDialog();
            string filePath = saveFileDialog1.FileName;
            if (filePath != "")
            {
                gvItemChecking.ExportToPdf(filePath);
            }
        }

        private void barExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            saveFileDialog1.Filter = "Xlsx文档|*.Xlsx";
            saveFileDialog1.ShowDialog();
            string filePath = saveFileDialog1.FileName;
            if (filePath != "")
            {
                gvItemChecking.ExportToPdf(filePath);
            }

        }

    }
}
