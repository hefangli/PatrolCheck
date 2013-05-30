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
using DevExpress.XtraBars.Docking;
using DevExpress.XtraCharts;

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

        private void bindGvReportSum()
        {
            SqlParameter[] pars = new SqlParameter[] { 
               new SqlParameter("@StartTime",SqlDbType.DateTime),
               new SqlParameter("@EndTime",SqlDbType.DateTime),
               new SqlParameter("@EmployeeIDs",SqlDbType.VarChar)
            };
            string employeeIDs = "";
            if (chkAll.Checked)
            {
                foreach (TreeListNode Node in tlEmployee.Nodes)
                {
                    employeeIDs += treeVisitor(Node);
                }
            }
            else
            {
                TreeListNode node = tlEmployee.FocusedNode;
                if (node != null)
                {
                    employeeIDs += treeVisitor(node);
                }
            }
            DataSet ds = null;
            if (employeeIDs.Trim() != "")
            {
                pars[0].Value = dtStartTime.EditValue != null ? dtStartTime.EditValue : "1753/1/1";
                pars[1].Value = dtEndTime.EditValue != null ? dtEndTime.EditValue : "9999/12/31";
                pars[2].Value = employeeIDs.TrimEnd(',');
                ds = SqlHelper.ExecuteDataset("GetSumByEmployee",CommandType.StoredProcedure,pars);
                this.gridControl1.DataSource=ds.Tables[0];
            }

            if (ds != null)
            {
                chartControl1.Series.Clear();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Series series1 = new Series(row["Name"].ToString(), ViewType.Pie);

                    series1.Points.Add(new SeriesPoint("准时", row["OnTime"]));
                    series1.Points.Add(new SeriesPoint("早到", row["Early"]));
                    series1.Points.Add(new SeriesPoint("晚到", row["Late"]));
                    series1.Points.Add(new SeriesPoint("超时", row["TimeOut"]));
                    series1.Points.Add(new SeriesPoint("漏检", row["HaveMiss"]));

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

                    txtAnnotation.Text = ds.Tables[0].Rows[i]["Name"].ToString();
                    txtAnnotation.ShapePosition = new RelativePosition(500, -30);
                    txtAnnotation.AnchorPoint = anchorPoint;

                    chartControl1.AnnotationRepository.Add(txtAnnotation);
                }
            }
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
            bindGvReportSum();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bindGvReportSum();
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

        private void barPDF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            saveFileDialog1.Filter = "PDF文档|*.pdf";
            saveFileDialog1.ShowDialog();
            string filePath = saveFileDialog1.FileName;
            if (filePath != "")
            {
                gvReportSumByEmployee.ExportToPdf(filePath);
            }
        }

        private void barExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            saveFileDialog1.Filter = "Xlsx文档|*.Xlsx";
            saveFileDialog1.ShowDialog();
            string filePath = saveFileDialog1.FileName;
            if (filePath != "")
            {
                gvReportSumByEmployee.ExportToPdf(filePath);
            }

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

        private void frmReportSummaryByEmployee_Load(object sender, EventArgs e)
        {
            barCheckItemGrid.Checked = true;
        }

      
    }
}
