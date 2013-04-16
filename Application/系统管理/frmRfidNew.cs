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
    public partial class frmRfidNew : Form
    {
        public frmRfidNew()
        {
            InitializeComponent();
        }
        bool isFirstOpenCardReader = false; //是否第一次打开读卡器
        public bool IsEdit = false;         //是否是编辑
        public object RfidID = null;        //Rfid表编号

        private void frmRfidNew_Load(object sender, EventArgs e)
        {
            bindComboBox();
            if (IsEdit)
            {
                if (RfidID != null)
                {
                    this.Text = "编辑RFID";
                    using (SqlDataReader dr = SqlHelper.ExecuteReader("Select * From Rfid Where Id=" + RfidID))
                    {
                        while (dr.Read())
                        {
                            this.tbName.Text = dr["Name"].ToString();
                            this.tbRfid.Text = dr["RFID"].ToString();
                            this.cboPurpose.EditValue = dr["Purpose"];
                            this.cboValidState.EditValue = dr["ValidState"];
                        }
                    }
                }
            }
            else
            {
                this.Text = "新建RFID";
            }            
        }

        private void bindComboBox()
        {
            using (SqlDataReader dr = SqlHelper.ExecuteReader("SELECT * FROM dbo.Codes WHERE Purpose='RfidPurpose'"))
            {
                while (dr.Read())
                {
                    cboPurpose.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr["Meaning"].ToString(), dr["Code"], -1));
                }
                cboPurpose.EditValue = 1;
            }
            using (SqlDataReader dr = SqlHelper.ExecuteReader("SELECT * FROM dbo.Codes WHERE Purpose='ValidState'"))
            {
                while (dr.Read())
                {
                    cboValidState.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr["Meaning"].ToString(), dr["Code"], -1));
                }
                cboValidState.EditValue = 1;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            if (isFirstOpenCardReader == true)
            {
                if (YW605Helper.YW605_Init() > 0)
                {
                    YW605Helper.Timer_Start(timer1);
                    isFirstOpenCardReader = false;
                }
            }
            int _ret = YW605Helper.YW605_WriteToTextBox(this.tbRfid);
            if (_ret < 0)
            {
                MessageBox.Show("读卡失败.错误代码:" + _ret);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql = "Insert Into Rfid(Name,RFID,Purpose,ValidState) Values(@name,@rfid,@purpose,@validstate)";
            if (IsEdit)
            {
                sql = "Update RFID Set Name=@name,RFID=@Rfid,Purpose=@purpose,ValidState=@validstate where ID=@id";
            }
            SqlParameter[] pars = new SqlParameter[] { 
               new SqlParameter("@name",tbName.Text),
               new SqlParameter("@Rfid",tbRfid.Text),
               new SqlParameter("@purpose",cboPurpose.EditValue),
               new SqlParameter("@validstate",cboValidState.EditValue),
               new SqlParameter("@id",RfidID)
            };
            if (SqlHelper.ExecuteNonQuery(sql, pars) == 1)
            {
                MessageBox.Show("保存成功");
            }    
        }
    }
}
