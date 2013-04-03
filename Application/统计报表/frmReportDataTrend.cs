using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WorkStation
{
    public partial class frmReportDataTrend : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public frmReportDataTrend()
        {
            InitializeComponent();
            this.dtStartTime.EditValue = (DateTime.Now.AddDays(-1).ToShortDateString() + " 00:00");
            this.dtEndTime.EditValue = (DateTime.Now.ToShortDateString() + " 23:59");
            bindTlPoint();
        }

        private void frmReportDataTrend_Load(object sender, EventArgs e)
        {
            
        }

        private void bindTlPoint()
        {
            string sqlRoute = @"Declare @MaxAID BIGINT; Select @MaxAID=Max(ID) From Area Where ValidState=" + (Int32)CodesValidState.Exit
                              + " Declare @MaxPID BIGINT; Select @MaxPID=MAX(ID) From Physicalcheckpoint Where  ValidState=" + (Int32)CodesValidState.Exit
                              + " Select ID,Area_ID,Name,Null as PID,Null as IID,'True' as IsArea,'False' as IsPoint,'False' as IsItem  from Area Where ValidState=" + (Int32)CodesValidState.Exit
                              + " union "
                              + " Select @MaxAID+ID,Area_ID,Name,ID,Null,'False','True','False' from PhysicalcheckPoint Where ValidState=" + (Int32)CodesValidState.Exit
                              + " union "
                              + " Select @MaxAID+@MaxPID+ID,@MaxAID+PhysicalcheckPoint_ID,Name,Null,ID,'False','False','True'  from CheckItem Where ValidState=" + (Int32)CodesValidState.Exit;
            DataSet ds = SqlHelper.ExecuteDataset(sqlRoute);
            tlPoint.DataSource = ds.Tables[0];
        }

        private void bindChart()
        {
            string sql = @"SELECT i.NumericalValue,c.DefaultValue,p.StartTime,p.EndTime 
FROM dbo.ItemChecking i LEFT JOIN dbo.CheckItem c ON i.CheckItem_ID=c.ID
                        LEFT JOIN dbo.PointChecking p ON i.PointChecking_ID=p.ID
WHERE   c.ValueType=2  ";
            if (dtStartTime.EditValue != null)
            {
                sql += " AND p.StartTime>='"+dtStartTime.EditValue+"'";
            }
            if (dtEndTime.EditValue != null)
            {
                sql += " AND p.StartTime<='"+dtEndTime.EditValue+"'";
            }
            if (tlPoint.FocusedNode != null)
            {
                if (tlPoint.FocusedNode.GetDisplayText("IsItem") == "True")
                {
                    sql += " AND i.CheckItem_ID=" + tlPoint.FocusedNode.GetDisplayText("IID");
                    DataSet ds = SqlHelper.ExecuteDataset(sql);
                    this.chartControl1.DataSource = ds.Tables[0];
                }
            }
           
        }

        private void tlPoint_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            bindChart();
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            bindChart();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dpSearch.Visibility == DevExpress.XtraBars.Docking.DockVisibility.Hidden)
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
