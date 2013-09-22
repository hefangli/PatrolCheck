using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WorkStation
{
    public partial class frmPoint : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public frmPoint()
        {
            InitializeComponent();
            BindComoBox();
            BindTreeList();
        }

        private void frmCheckPoint_Load(object sender, EventArgs e)
        { 
            this.dockPanelFind.Close();
        }

        private void BindTreeList()
        {
            DataSet ds = SqlHelper.ExecuteDataset("Select *,(select meaning from codes where code=Area.ValidState and Purpose='ValidState') as ValidStateMeaning from Area where validstate=" + (Int32)CodesValidState.Exit);
            tlArea.DataSource = ds.Tables[0];
        }

        private void BindGvPoint()
        {
            string sqlSelect = @"Select 'False' as isCheck,P.ID as PointID ,P.Name as PointName ,P.alias as PointAlias,R.Name as RfidName,
                              R.Rfid as RfidRFID,R.ID as RfidID,A.Name as AreaName,A.ID as AreaID,
                              (select meaning from codes where code=P.validstate and purpose='ValidState') as PointValidStateMeaning,
                              P.ValidState as PointValidState  
                              from PhysicalCheckPoint as P left  join  Rfid as R on P.Rfid_ID=R.ID 
                                           Left Join Area A on P.Area_ID=A.ID Where 1=1";
            if (cboValidState.EditValue.ToString() != "-1")
            {
                sqlSelect += " and P.ValidState=" + cboValidState.EditValue;
            }
            if (this.tbName.Text != "")
            {
                sqlSelect += " and P.Name Like '%" + tbName.Text.Trim() + "%'";
            }
            if (!chkAll.Checked)
            {
                if (tlArea.FocusedNode == null) { MessageBox.Show("请选择位置"); return; }
                string selectID = " with parent(ID,Area_ID,Name) as( select ID,Area_ID,Name From Area where id=" + tlArea.FocusedNode.GetDisplayText("ID") + " union all select c.ID,c.Area_ID,c.Name from area c  join  parent p  on c.area_id=p.id  ) select ID from parent";
                SqlDataReader dr = SqlHelper.ExecuteReader(selectID);
                string ids = "";
                while (dr.Read())
                {
                    ids += dr["ID"].ToString() + ",";
                }
                if (ids != "")
                {
                    ids = ids.TrimEnd(new char[] { ',' });
                    sqlSelect += " and P.Area_ID IN(" + ids + ")";
                }
            }
            DataSet ds = SqlHelper.ExecuteDataset(sqlSelect);
            gridControlPoint.DataSource = ds == null ? null : ds.Tables[0];
        }

        private void BindComoBox()
        {
            using (SqlDataReader dr = SqlHelper.ExecuteReader("Select Code,Meaning from Codes Where Purpose='ValidState'"))
            {
                cboValidState.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem("全部", -1, -1));
                while (dr.Read())
                {
                    cboValidState.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr["Meaning"].ToString(), dr["Code"], -1));
                }
                cboValidState.EditValue = -1;
            }
        }

        private void barButtonItemNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tlArea.FocusedNode != null)
            {
                frmPointNew pointNew = new frmPointNew();
                pointNew.IsEdit = false;
                pointNew.AreaID = tlArea.FocusedNode.GetDisplayText("ID");
                pointNew.ShowDialog();
                BindGvPoint();
            }
        }

        private void barButtonItemEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gvPoint.FocusedRowHandle >= 0)
            {               
                frmPointNew pointNew = new frmPointNew();
                pointNew.IsEdit = true;
                pointNew.AreaID = tlArea.FocusedNode.GetDisplayText("ID");
                pointNew.CheckPointID = gvPoint.GetRowCellValue(gvPoint.FocusedRowHandle,"PointID");
                pointNew.ShowDialog();
                BindGvPoint();
            }
        }

        private void barButtonItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SendKeys.SendWait("{TAB}"); SendKeys.SendWait("+{TAB}"); //Tab ,Shit+Tab
            string Del = "";
            string strsql = "Delete From PhysicalCheckPoint Where ID in(";
            for (int i = 0; i < gvPoint.RowCount; i++)
            {
                object isCheck = gvPoint.GetRowCellValue(i, "isCheck");
                if (isCheck != null && Convert.ToBoolean(isCheck) == true)
                {
                    Del += gvPoint.GetRowCellValue(i, "PointID") + ",";
                }
            }
            if (Del != "")
            {
                Del = Del.Substring(0, Del.Length - 1);
                strsql += Del + ")";
                SqlHelper.ExecuteNonQuery(strsql);
                BindGvPoint();
            }
            else
            {
                MessageBox.Show("请选择要删除的项。");
            }
        }

        private void gvPoint_DoubleClick(object sender, EventArgs e)
        {
            if (gvPoint.FocusedRowHandle >= 0)
            {
                frmPointNew pointNew = new frmPointNew();
                pointNew.IsEdit = true;
                pointNew.AreaID = tlArea.FocusedNode.GetDisplayText("ID");
                pointNew.CheckPointID = gvPoint.GetRowCellValue(gvPoint.FocusedRowHandle,"PointID");
                pointNew.ShowDialog();
                BindGvPoint();
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            dockPanelFind.Show();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            BindGvPoint();
        }

        private void tlArea_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            BindGvPoint();
        }

    }
}
