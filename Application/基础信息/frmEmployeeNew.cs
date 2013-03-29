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
    public partial class frmEmployeeNew : Form
    {
        public frmEmployeeNew()
        {
            InitializeComponent();
        }

        private bool isFirstOpenCardReader = true; //是否第一次读卡
        private object employeeID = null;

        /// <summary>
        /// 人员编号
        /// </summary>
        public object EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }
        private bool isEdit = false;
        /// <summary>
        /// 是否编辑，默认为False
        /// </summary>
        public bool IsEdit
        {
            get { return isEdit; }
            set { isEdit = value; }
        }
        private object orgID = null;
        /// <summary>
        /// 组织ID
        /// </summary>
        public object OrgID
        {
            get { return orgID; }
            set { orgID = value; }
        }
        private void frmEmployeeNew_Load(object sender, EventArgs e)
        {
            this.Text = this.IsEdit == true ? "编辑人员" : "新建人员";
            BindComboBox();
            if (IsEdit)
            {
                using (SqlDataReader dr = SqlHelper.ExecuteReader("Select *,(select name from rfid where id=Rfid_ID) as RfidName from Employee where id=" + EmployeeID))
                {
                    if (dr != null)
                    {
                        while (dr.Read())
                        {
                            tbName.Text = dr["Name"].ToString();
                            cboCraft.EditValue = dr["Specialty"];
                            cboValidState.EditValue = dr["ValidState"];
                            txtRelation.Text = dr["RfidName"].ToString();
                            txtRelation.Tag = dr["Rfid_ID"];
                        }
                    }
                }
            }
        }

        private void BindComboBox()
        {
            using (SqlDataReader dr = SqlHelper.ExecuteReader("Select Code,Meaning from Codes Where Purpose='ValidState'"))
            {
                while (dr.Read())
                {
                    cboValidState.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr["Meaning"].ToString(), dr["Code"], -1));
                }
                cboValidState.EditValue = 1;
            }

            using (SqlDataReader dr = SqlHelper.ExecuteReader("Select Code,Meaning from Codes Where Purpose='Specialty'"))
            {
                while (dr.Read())
                {
                    cboCraft.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr["Meaning"].ToString(), dr["Code"], -1));
                }
                cboValidState.EditValue = 1;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (tbName.Text == "") { MessageBox.Show("请确定无空值"); return; }
            string sql = "Insert Into Employee(Name,Specialty,Organization_ID,Rfid_ID,ValidState) Values(@name,@specialty,@organization_id,@rfid_id,@validstate)";
            if (IsEdit)
            {
                sql = "Update Employee Set Name=@name,Organization_ID=@organization_id,Rfid_ID=@rfid_id,Specialty=@specialty,ValidState=@validstate Where ID=@id";
            }
            SqlParameter[] pars = new SqlParameter[]{
               new SqlParameter("@name",tbName.Text),
               new SqlParameter("@specialty",cboCraft.EditValue==null?null:cboCraft.EditValue),
               new SqlParameter("@validstate",cboValidState.EditValue),
               new SqlParameter("@id",EmployeeID),
               new SqlParameter("@organization_id",OrgID),
               new SqlParameter("@rfid_id",SqlDbType.BigInt)
            };
            if (txtRelation.Tag != null && txtRelation.Tag.ToString() != "")
            {
                if ((int)SqlHelper.ExecuteScalar("Select Count(1) From Rfid Where Purpose=2 and validstate=1 and ID=" + this.txtRelation.Tag + "") != 1)
                {

                    MessageBox.Show("请确保存在此标签卡");
                    return;
                }
                else
                {
                    pars[5].Value = this.txtRelation.Tag;
                }
            }
            if (SqlHelper.ExecuteNonQuery(sql, pars) > 0)
            {
                MessageBox.Show("保存成功");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChose_Click(object sender, EventArgs e)
        {
            frmPointChoseRfid f = new frmPointChoseRfid();
            f.SelIndex = 1;
            f.ShowDialog();
            this.txtRelation.Text = f.RFID_Name == null ? null : f.RFID_Name.ToString();
            this.txtRelation.Tag = f.RFID_ID;
            this.txtRelation.ReadOnly = false;
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
            int _ret = YW605Helper.YW605_WriteToTextBox(this.txtRelation);
            if (_ret < 0)
            {
                MessageBox.Show("读卡失败.错误代码:" + _ret);
            }
        }

        private void frmEmployeeNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            YW605Helper.Timer_Stop(timer1);
        }
    }
}
