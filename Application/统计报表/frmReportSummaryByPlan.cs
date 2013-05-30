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
using DevExpress.XtraCharts;

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
            string sql = @"DECLARE @maxPostID INT "
                        + "SELECT @maxPostID=MAX(ID) FROM dbo.Post;"
                        + "SELECT ID,NULL AS ParentID,Name,"
                        + "(SELECT Name FROM dbo.organization WHERE ID=dbo.Post.organization_ID) AS OrganizationName,"
                        + "ID AS TID,'True' AS IsPost,'False' AS IsCheckPlan  FROM dbo.Post Where ValidState=" + (Int32)CodesValidState.Exit
+ " UNION ALL "
+ "SELECT @maxPostID+ID,Post_ID,Name,NULL,"
+ "ID AS TID,'False','True' "
+ "FROM dbo.CheckPlan Where ValidState=" + (Int32)CodesValidState.Exit;
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
            if (ds != null)
            {
                this.gridControl1.DataSource = ds.Tables[0];
            }

            if (ds != null)
            {
                chartControl1.Series.Clear();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Series series1 = new Series(row["TaskName"].ToString(), ViewType.Pie);

                    series1.Points.Add(new SeriesPoint("未执行", row["NoRunning"]));
                    series1.Points.Add(new SeriesPoint("准时", row["OnTime"]));
                    series1.Points.Add(new SeriesPoint("早到", row["Early"]));
                    series1.Points.Add(new SeriesPoint("晚到", row["Late"]));
                    series1.Points.Add(new SeriesPoint("超时", row["TimeOut"]));

                    series1.PointOptions.PointView = PointView.ArgumentAndValues;
                    series1.PointOptions.ValueNumericOptions.Format = NumericFormat.Percent;
                    chartControl1.Series.Add(series1);
                }

                for (int i = 0; i < chartControl1.Series.Count; i++)
                {
                    SeriesPointAnchorPoint anchorPoint = new SeriesPointAnchorPoint();
                    anchorPoint.SeriesPoint = chartControl1.Series[i].Points[0];
                    (chartControl1.Series[i].Label as PieSeriesLabel).Position = PieSeriesLabelPosition.Inside;
                    TextAnnotation txtAnnotation = new TextAnnotation();
                    txtAnnotation.RuntimeRotation = true;
                    txtAnnotation.RuntimeResizing = true;
                    txtAnnotation.RuntimeMoving = true;
                    txtAnnotation.RuntimeAnchoring = true;

                    txtAnnotation.Text = ds.Tables[0].Rows[i]["TaskName"].ToString();
                    txtAnnotation.ShapePosition = new RelativePosition(500, -30);
                    txtAnnotation.AnchorPoint = anchorPoint;

                    chartControl1.AnnotationRepository.Add(txtAnnotation);
                }
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
            saveFileDialog1.Filter = "PDF文档|*.pdf";
            saveFileDialog1.ShowDialog();
            string filePath = saveFileDialog1.FileName;
            if (filePath != "")
            {
                gvRouteChecking.ExportToPdf(filePath);
            }
        }

        private void barExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            saveFileDialog1.Filter = "Xlsx文档|*.Xlsx";
            saveFileDialog1.ShowDialog();
            string filePath = saveFileDialog1.FileName;
            if (filePath != "")
            {
                gvRouteChecking.ExportToPdf(filePath);
            }

        }

        private void barCheckItemGrid_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (barCheckItemGrid.Checked)
            {
                barCheckItemPie.Checked = false;
                gridControl1.Visible = true;
                gridControl1.Dock = DockStyle.Fill;
            }
            else
            {
                gridControl1.Visible = false;

            }
        }

        private void barCheckItemPie_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (barCheckItemPie.Checked)
            {
                barCheckItemGrid.Checked = false;
                chartControl1.Visible = true;
                chartControl1.Dock = DockStyle.Fill;
            }
            else
            {
                chartControl1.Visible = false;
            }
        }

        private void frmReportSummaryByPlan_Load(object sender, EventArgs e)
        {
            this.barCheckItemGrid.Checked = true;
        }

        private void barButtonItemExportPie_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            saveFileDialog1.Filter = "PDF文档|*.pdf";
            saveFileDialog1.ShowDialog();
            string filePath = saveFileDialog1.FileName;
            if (filePath != "")
            {
                chartControl1.ExportToPdf(filePath);
            }
        }

    }
}
