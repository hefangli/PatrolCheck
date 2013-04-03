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

namespace WorkStation
{
    public partial class frmReportSummaryByPoint : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public frmReportSummaryByPoint()
        {
            InitializeComponent();
            this.dtStartTime.EditValue = (DateTime.Now.AddDays(-1).ToShortDateString() + " 00:00");
            this.dtEndTime.EditValue = (DateTime.Now.ToShortDateString() + " 23:59");
            bindTlPoint();
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

        private void bindGvPoingCheckingSum()
        {
            string[] retStrs = new string[2] { "", "" };
            if (chkAll.Checked)
            {
                foreach (TreeListNode fn in tlPoint.Nodes)
                {
                    string[] _ret = treeVisitor(fn);
                    retStrs[0] += _ret[0].Trim() == "" ? "" : _ret[0];
                    retStrs[1] += _ret[1].Trim() == "" ? "" : _ret[1];
                }
            }
            else
            {
                TreeListNode fn = tlPoint.FocusedNode;
                if (fn != null)
                {
                    if (fn.GetDisplayText("IsItem") == "True")
                    {
                        if (fn.ParentNode != null)
                        {
                            retStrs[0] = fn.ParentNode.GetDisplayText("PID") + ",";
                        }
                        retStrs[1] = fn.GetDisplayText("IID") + ",";
                    }
                    else
                    {
                        retStrs = treeVisitor(fn);
                    }
                }
            }
            
            SqlParameter[] pars = new SqlParameter[] { 
              new SqlParameter("@StartTime",SqlDbType.DateTime),
              new SqlParameter("@EndTime",SqlDbType.DateTime),
              new SqlParameter("@PointIDs",SqlDbType.VarChar)
            };
            DataSet ds =null;
            if (retStrs[0].Trim() != "")
            {
                pars[0].Value = dtStartTime.EditValue != null ? dtStartTime.EditValue : "1753/1/1";
                pars[1].Value = dtEndTime.EditValue != null ? dtEndTime.EditValue : "9999/12/31";
                pars[2].Value = retStrs[0].TrimEnd(',');
                ds = SqlHelper.ExecuteDataset("GetSumByPoint", CommandType.StoredProcedure, pars);
                this.gridControl1.DataSource=ds.Tables[0];
            } 
        }

        private string[] treeVisitor(TreeListNode areaNode)
        {
            string[] _ret = new string[2]; _ret[0] = ""; _ret[1] = "";
            if (areaNode.GetDisplayText("IsPoint") == "True")
            {
                _ret[0] += areaNode.GetDisplayText("PID") + ",";
            }
            if (areaNode.GetDisplayText("IsItem") == "True")
            {
                _ret[1] += areaNode.GetDisplayText("IID") + ",";
            }
            foreach (TreeListNode n in areaNode.Nodes)
            {
                string[] ret1 = treeVisitor(n);
                _ret[0] += ret1[0].Trim() == "" ? "" : ret1[0];
                _ret[1] += ret1[1].Trim() == "" ? "" : ret1[1];
            }
            return _ret;
        }

        private void tlPoint_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            bindGvPoingCheckingSum();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bindGvPoingCheckingSum();
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

        private void barPDF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            saveFileDialog1.Filter = "PDF文档|*.pdf";
            saveFileDialog1.ShowDialog();
            string filePath = saveFileDialog1.FileName;
            if (filePath != "")
            {
                gvPoingChecking.ExportToPdf(filePath);
            }
        }

        private void barExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            saveFileDialog1.Filter = "Xlsx文档|*.Xlsx";
            saveFileDialog1.ShowDialog();
            string filePath = saveFileDialog1.FileName;
            if (filePath != "")
            {
                gvPoingChecking.ExportToPdf(filePath);
            }

        }
    }
}
