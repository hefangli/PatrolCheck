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
    public partial class frmReportDefectSearch : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public frmReportDefectSearch()
        {
            InitializeComponent();

            bindTlRoute();
        }

        private void frmReportDefectSearch_Load(object sender, EventArgs e)
        {
        }

        private void bindTlRoute()
        {
            string sqlRoute = @"Declare @MaxAID BIGINT; Select @MaxAID=Max(ID) From Area Where ValidState=" + (Int32)CodesValidState.Exit
                                + " Declare @MaxPID BIGINT; Select @MaxPID=MAX(ID) From Physicalcheckpoint Where  ValidState=" + (Int32)CodesValidState.Exit
                                + " Select ID,Area_ID,Name,Null as PID,Null as IID,'True' as IsArea,'False' as IsPoint,'False' as IsItem  from Area Where ValidState=" + (Int32)CodesValidState.Exit
                                + " union "
                                + " Select @MaxAID+ID,Area_ID,Name,ID,Null,'False','True','False' from PhysicalcheckPoint Where ValidState=" + (Int32)CodesValidState.Exit
                                + " union "
                                + " Select @MaxAID+@MaxPID+ID,@MaxAID+PhysicalcheckPoint_ID,Name,Null,ID,'False','False','True'  from CheckItem Where ValidState=" + (Int32)CodesValidState.Exit;
            DataSet ds = SqlHelper.ExecuteDataset(sqlRoute);
            tlRoute.DataSource = ds.Tables[0];
        }

        private void bindGvDefectChecking(bool isSearch)
        {
            DateTime? startTime = null, endTime = null;
            string sqlSelect = "Select * From V_DefectChecking Where 1=1 ";
            string pointIDs = "",itemIDs="";
            TreeListNode fn=tlRoute.FocusedNode;
            if (fn != null)
            {
                if (fn.GetDisplayText("IsItem") == "True")
                {
                    itemIDs = fn.GetDisplayText("IID");
                }
                else
                {
                    pointIDs = treeVisitor(fn);
                }
            }
            sqlSelect +=pointIDs == "" ? "" : ("and PhysicalCheckPoint_ID in ("+pointIDs.TrimEnd(',')+")");
            sqlSelect += itemIDs==""? "":(" and CheckItem_ID In ("+itemIDs+")");
            DataSet ds = SqlHelper.ExecuteDataset(sqlSelect);
            this.gridControl1.DataSource=ds.Tables[0];
        }

        private string treeVisitor(TreeListNode areaNode)
        {
            string pids = "";
            if (areaNode.GetDisplayText("IsPoint") == "True")
            {
                pids += areaNode.GetDisplayText("PID") + ",";
            }
            foreach (TreeListNode n in areaNode.Nodes)
            {
                pids += treeVisitor(n);
            }
            return pids;
        }

        private void tlRoute_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            bindGvDefectChecking(false);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime? startTime = null, endTime = null;
            if(dtStartTime.EditValue!=null)
            {
                startTime=Convert.ToDateTime(dtStartTime.EditValue);
            }
            if (dtEndTime.EditValue != null)
            {
                endTime = Convert.ToDateTime(dtEndTime.EditValue);
            }

            string sqlSelect = "Select * From V_DefectChecking Where 1=1 ";
            string pointIDs = "", itemIDs = "";
            if (!chkAll.Checked)
            {
                TreeListNode fn = tlRoute.FocusedNode;
                if (fn != null)
                {
                    if (fn.GetDisplayText("IsItem") == "True")
                    {
                        itemIDs = fn.GetDisplayText("IID");
                    }
                    else
                    {
                        pointIDs = treeVisitor(fn);
                    }
                }
                sqlSelect += pointIDs == "" ? "" : (" and PhysicalCheckPoint_ID in (" + pointIDs.TrimEnd(',') + ")");
                sqlSelect += itemIDs == "" ? "" : (" and CheckItem_ID In (" + itemIDs + ")");
            }
            sqlSelect += tbCheckPoint.Text.Trim()==""?"":" and PhysicalCheckPointName like '%"+tbCheckPoint.Text.Trim()+"%'";
            sqlSelect += tbCheckItem.Text.Trim() == "" ? "" : " and CheckItemName like '%" + tbCheckItem.Text.Trim() + "%'";
            sqlSelect += tbDefectName.Text.Trim() == "" ? "" : " and DefectName Like '%"+tbDefectName.Text.Trim()+"%'";
            DataSet ds = SqlHelper.ExecuteDataset(sqlSelect);
            this.gridControl1.DataSource = ds.Tables[0];
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
            folderBrowserDialog1.ShowDialog();
           string path= folderBrowserDialog1.SelectedPath;
           if (path != "")
           {
               string fileName = path + "\\Defect" + DateTime.Now.Year.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + ".pdf";
               gvDefectChecking.ExportToPdf(fileName);
           }
        }

        private void barExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            string path = folderBrowserDialog1.SelectedPath;
            if (path != "")
            {
                string fileName = path + "\\Defect" + DateTime.Now.Year.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + ".Xlsx";
                gvDefectChecking.ExportToXlsx(fileName);
            }
        }
    }
}
