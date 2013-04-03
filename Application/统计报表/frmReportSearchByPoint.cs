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
    public partial class frmReportSearchByPoint : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public frmReportSearchByPoint()
        {
            InitializeComponent();
            this.dtStartTime.EditValue = (DateTime.Now.AddDays(-1).ToShortDateString() + " 00:00");
            this.dtEndTime.EditValue = (DateTime.Now.ToShortDateString() + " 23:59");
            bindTlPoint();
        }

        private void frmReportSearchByPoint_Load(object sender, EventArgs e)
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

        private void bindGvItemChecking()
        {
            //DateTime? startTime = null, endTime = null;
            string sqlSelect = "Select * From V_ItemChecking Where 1=1 ";
            if (dtStartTime.EditValue != null)
            {
                sqlSelect += "and PStartTime>='" + dtStartTime.EditValue + "'";
            }
            if (dtEndTime.EditValue != null)
            {
                sqlSelect += "and PEndTime<='" + dtEndTime.EditValue + "'";
            }
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
            sqlSelect += " and PhysicalCheckPoint_ID in (" + (retStrs[0].Trim() == "" ? "null" : (retStrs[0].TrimEnd(','))) + ")";
            sqlSelect += " and CheckItem_ID In (" + (retStrs[1].Trim() == "" ? "null" : (retStrs[1].TrimEnd(','))) + ")";

            if (tbCheckPoint.Text != "")
            {
                sqlSelect += " and PhysicalCheckPointName like '%" + tbCheckPoint.Text.Trim() + "%'";
            }
            if (tbCheckItem.Text != "")
            {
                sqlSelect += " and CheckItemName like '%" + tbCheckItem.Text.Trim() + "%'";
            }
            string pointIDs = "", itemIDs = "";

            sqlSelect += pointIDs == "" ? "" : ("and PhysicalCheckPoint_ID in (" + pointIDs.TrimEnd(',') + ")");
            sqlSelect += itemIDs == "" ? "" : (" and CheckItem_ID In (" + itemIDs + ")");
            DataSet ds = SqlHelper.ExecuteDataset(sqlSelect);
            this.gridControl1.DataSource = ds.Tables[0];
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bindGvItemChecking();
        }

        private void tlPoint_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
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

        private void gvItemChecking_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            object id = this.gvItemChecking.GetRowCellValue(e.RowHandle, "HasDefect");
            if (id != null && id.ToString() == "1")
            {
                e.Appearance.ForeColor = Color.Red;
            }
        }
    }
}
