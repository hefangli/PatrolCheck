using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace WorkStation
{
    public partial class ReportSearchByPoint : DevExpress.XtraReports.UI.XtraReport
    {
        
        public ReportSearchByPoint(string sqlpoint,string sqlitem)
        {
            InitializeComponent();
            SqlDataAdapter ada1 = new SqlDataAdapter(sqlpoint,SqlHelper.sqlConnectionStr);
            ada1.Fill(reportSearchByPoint1.PointChecking);
            ada1 = new SqlDataAdapter(sqlitem, SqlHelper.sqlConnectionStr);
            ada1.Fill(reportSearchByPoint1.ItemChecking);
            ada1.Dispose();
            reportSearchByPoint1.PointChecking.WriteXml("11.xml", XmlWriteMode.WriteSchema);
            reportSearchByPoint1.ItemChecking.WriteXml("22.xml",XmlWriteMode.WriteSchema);
        }
        const string sShowDetail = "显示巡检项信息";
        const string sHideDetail = "隐藏巡检项信息";

        ArrayList expandedValues = new ArrayList();

        bool ShouldShowDetail(object catID)
        {
            return expandedValues.Contains(catID);
        }

        private void ShowDetail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            if (label.Tag == null) return; 
            if (ShouldShowDetail(label.Tag))
            {
                label.Text = sHideDetail;
            }
            else
            {
                label.Text = sShowDetail;
            }

        }

        private void ShowDetail_PreviewMouseMove(object sender, PreviewMouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void ShowDetail_PreviewClick(object sender, PreviewMouseEventArgs e)
        {
            object index = e.Brick.Value;

            bool showDetail = ShouldShowDetail(index);
            if (showDetail)
            {
                expandedValues.Remove(index);
            }
            else
            {
                expandedValues.Add(index);
            }
            CreateDocument();

        }

        private void DetailReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (GetCurrentColumnValue("ID") != null)
            {
                e.Cancel = !ShouldShowDetail(GetCurrentColumnValue("ID"));
            }
        }

    }
}
