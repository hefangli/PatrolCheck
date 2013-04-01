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
    public partial class frmPointChoseRfid : Form
    {
        public frmPointChoseRfid()
        {
            InitializeComponent();
        }
        private int selIndex = 2;
        private object rfid_id = null;
        private object rfid_name = null;
        /// <summary>
        /// 0为全部 1为人员 2为地点。默认为2
        /// </summary>
        public int SelIndex
        {
            get { return selIndex; }
            set { selIndex = value; }
        }
        /// <summary>
        /// RFID的编号(ID)
        /// </summary>
        public object RFID_ID
        {
            get { return rfid_id; }
            set { rfid_id = value; }
        }
        /// <summary>
        /// RFID的名称
        /// </summary>
        public object RFID_Name
        {
            get { return rfid_name; }
            set { rfid_name = value; }
        }

        private void frmChoseRfid_Load(object sender, EventArgs e)
        {
            Cbo_Init();
            this.cboItem.EditValue = selIndex;
            getDgvRfid();
        }

        private void getDgvRfid()
        {
//            string strSql = @"select ID,Name,Alias,RFID, (select meaning from codes where code=rfid.Purpose and codes.purpose='rfidpurpose')as Purpose,ValidState 
//from rfid 
//where (id not in(select distinct isnull(rfid_id,-1) from physicalcheckpoint where physicalcheckpoint.validstate in (0,1))) 
//and (id not  in (select distinct isnull(rfid_id,-1) from employee where employee.validstate in(0,1)))";
            string strSql = @"select 'False' as IsCheck,ID,Name,Alias,RFID, 
(select Meaning from dbo.Codes where Code=rfid.Purpose and codes.purpose='rfidpurpose')as PurposeMeaning 
from rfid 
WHERE Used=0";
            string val = cboItem.EditValue.ToString().Trim();
            if (val == "0")
            {
                strSql += " and validstate=1";
            }
            else if (val == "1")
            {
                strSql += " and Purpose=1 and validstate =1";
            }
            else if (val == "2")
            {
                strSql += " and Purpose=2 and validstate=1";
            }
            DataSet ds = SqlHelper.ExecuteDataset(strSql);
            if (ds != null)
            {
                this.gridControl1.DataSource = ds.Tables[0];
            }
        }

        private void Cbo_Init()
        {
            cboItem.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem("全部",0,-1));
            cboItem.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem("人员", 1, -1));
            cboItem.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem("地点", 2, -1));
        }
        private void btnChose_Click(object sender, EventArgs e)
        {
            int count = 0;
            object id = null, name = null;
            for (int i = 0; i < dgvRfid.RowCount; i++)
            {
                object isCheck = dgvRfid.GetRowCellValue(i, "IsCheck");
                if (isCheck != null && Convert.ToBoolean(isCheck) == true)
                {
                    id = dgvRfid.GetRowCellValue(i, "ID");
                    name = dgvRfid.GetRowCellValue(i, "Name");
                    count++;
                    break;
                }
            }
            if (count != 1)
            {
                MessageBox.Show("请选择一项");
                return;
            }
            else
            {
                this.RFID_ID = id;
                this.RFID_Name = name;
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvRfid_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            dgvRfid.SetRowCellValue(e.RowHandle, "IsCheck", "False");
        }

        private void dgvRfid_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            object IsCheck = dgvRfid.GetRowCellValue(e.RowHandle, "IsCheck");
            if (IsCheck != null && Convert.ToBoolean(IsCheck) == true)
            {
                dgvRfid.SetRowCellValue(e.RowHandle, "IsCheck", "False");
            }
        }

        private void dgvRfid_DoubleClick(object sender, EventArgs e)
        {
            if (dgvRfid.FocusedRowHandle < 0) return;
            this.RFID_ID = dgvRfid.GetRowCellValue(dgvRfid.FocusedRowHandle, "ID");
            this.RFID_Name = dgvRfid.GetRowCellValue(dgvRfid.FocusedRowHandle, "Name");
        }

        private void cboItem_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            getDgvRfid();
        }

    }
}
