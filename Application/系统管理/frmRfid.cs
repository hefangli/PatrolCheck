using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraBars.Docking;

namespace WorkStation
{
    public partial class frmRfid : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public frmRfid()
        {
            InitializeComponent();
        }

        private void frmRFid_Load(object sender, EventArgs e)
        {
            bindComboBox();
            bindGvRfid();
        }

        private void bindComboBox()
        {
            using (SqlDataReader dr = SqlHelper.ExecuteReader("SELECT * FROM dbo.Codes WHERE Purpose='RfidPurpose'"))
            {
                cboPurpose.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem("全部", -1, -1));
                while (dr.Read())
                {
                    cboPurpose.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr["Meaning"].ToString(), dr["Code"], -1));
                }
                cboPurpose.EditValue = -1;
            }
            using (SqlDataReader dr = SqlHelper.ExecuteReader("SELECT * FROM dbo.Codes WHERE Purpose='ValidState'"))
            {
                cboValidState.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem("全部", -1, -1));
                while (dr.Read())
                {
                    cboValidState.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr["Meaning"].ToString(), dr["Code"], -1));
                }
                cboValidState.EditValue = -1;
            }
            using (SqlDataReader dr = SqlHelper.ExecuteReader("SELECT * FROM dbo.Codes WHERE Purpose='RfidUsed'"))
            {
                cboUsed.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem("全部", -1, -1));
                while (dr.Read())
                {
                    cboUsed.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr["Meaning"].ToString(), dr["Code"], -1));
                }
                cboUsed.EditValue = -1;
            }
        }

        private void bindGvRfid()
        {

            string sql = @"SELECT ID,Name,RFID,'False' As IsCheck,
  (SELECT meaning FROM dbo.Codes WHERE Code=RFID.Purpose AND Purpose='RfidPurpose') AS PurposeMeaning,
  (SELECT meaning FROM dbo.Codes WHERE Code=RFID.ValidState AND Purpose='ValidState') AS ValidStateMeaning,
   (SELECT meaning FROM dbo.Codes WHERE Code=RFID.Used AND Purpose='RfidUsed') AS UsedMeaning 
 FROM dbo.Rfid where 1=1 ";
            if (cboValidState.EditValue.ToString() != "-1")
            {
                sql += " and ValidState=" + cboValidState.EditValue;
            }
            if (cboPurpose.EditValue.ToString() != "-1")
            {
                sql += " and Purpose=" + cboPurpose.EditValue;
            }
            if (cboUsed.EditValue.ToString() != "-1")
            {
                sql += " and Used=" + cboUsed.EditValue;
            }
            if (tbName.Text.Trim() != "")
            {
                sql += " and Name like '%"+tbName.Text.Trim()+"%'";
            }
            sql += " order by ID";
            DataSet ds = SqlHelper.ExecuteDataset(sql);
            this.gridControl1.DataSource = ds.Tables[0];

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bindGvRfid();
        }

        private void gvRfid_DoubleClick(object sender, EventArgs e)
        {
            int rowIndex = gvRfid.FocusedRowHandle;
            if (rowIndex >= 0)
            {
                frmRfidNew rfidNew = new frmRfidNew();
                rfidNew.IsEdit = true;
                rfidNew.RfidID = gvRfid.GetRowCellDisplayText(rowIndex,"ID");
                rfidNew.ShowDialog();
                bindGvRfid();
            }
        }

        private void barEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int rowIndex = gvRfid.FocusedRowHandle;
            if (rowIndex >= 0)
            {
                frmRfidNew rfidNew = new frmRfidNew();
                rfidNew.IsEdit = true;
                rfidNew.RfidID = gvRfid.GetRowCellDisplayText(rowIndex,"ID");
                rfidNew.ShowDialog();
                bindGvRfid();
            }
        }

        private void barNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
                frmRfidNew rfidNew = new frmRfidNew();
                rfidNew.IsEdit = false;
                rfidNew.ShowDialog();
                bindGvRfid();
        }

        private void barDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SendKeys.SendWait("{Tab}"); SendKeys.SendWait("+{Tab}");
            string sqlDel = "Delete From RFID where ID in(";
            string ids = "";
            for (int i = 0; i < gvRfid.RowCount; i++)
            {
                object isCheck = gvRfid.GetRowCellValue(i,"IsCheck");
                if (isCheck != null && Convert.ToBoolean(isCheck) == true)
                {
                    ids += gvRfid.GetRowCellValue(i,"ID")+",";
                }
            }
            if (ids.Trim() != "")
            {
                if(MessageBox.Show("您确定删除该信息吗？","提示信息",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.OK)
                {
                    sqlDel += ids.TrimEnd(',')+")";
                    SqlHelper.ExecuteNonQuery(sqlDel);
                    bindGvRfid();
                }
            }          
        }

        private void barSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
    }
}
