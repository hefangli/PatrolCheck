using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using WorkStation;
using System.Configuration;
namespace WorkStation
{

    public partial class frmCardNew : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public frmCardNew()
        {
            InitializeComponent();
        }
        DataSet dsRfidPurpose = null;
        DataSet dsRfid = null;
        DataSet dse = null;


        public void Bind()
        {
            string sql2 = "select ID,Name,Alias,RFID,Meaning,(select meaning from codes where code=validstate and purpose='validstate') as ValidState from Rfid left join RfidPurpose on Rfid.Purpose = RfidPurpose.Code";
            dsRfid.Clear();
            dsRfid = SqlHelper.ExecuteDataset(sql2);
            this.gridControl1.DataSource = dsRfid.Tables[0];
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.txtName.Text == "")
            {
                MessageBox.Show("卡片名称不能为空", "友情提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.txtName.Focus();
            }
            else if (txtAlias.Text == "")
            {
                MessageBox.Show("卡片别名不能为空", "友情提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.txtAlias.Focus();
            }
            else if (txtCard.Text == "")
            {
                MessageBox.Show("标签卡唯一码不能为空", "友情提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.txtCard.Focus();
            }
            else if (this.comboBox1.SelectedValue == null)
            {
                MessageBox.Show("用途不能为空", "友情提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.comboBox1.Focus();
            }
            else
            {
                if (Convert.ToInt32(SqlHelper.ExecuteScalar("select count(1) From rfid where validstate in (0,1) and rfid='" + this.txtCard.Text + "'")) != 0)
                {
                    MessageBox.Show("已存在此卡片");
                    return;
                }
                if ((int)(SqlHelper.ExecuteScalar("select count(*) from rfid where name='" + this.txtName.Text + "'")) > 0)
                {
                    MessageBox.Show("该卡片名称已存在，请重新输入！");
                    this.txtName.Focus();
                    return;
                }
                else
                {
                    string sql = "insert into Rfid([Name],Alias,RFID,Purpose,ValidState) values(@name,@alias,@rFID,@RfidPurpose,@ValidState)";
                    SqlParameter[] pars = new SqlParameter[] { 
                    new SqlParameter("@name", SqlDbType.NVarChar),
                    new SqlParameter("@alias", SqlDbType.NVarChar),
                    new SqlParameter("@rFID", SqlDbType.NVarChar),  
                    new SqlParameter("@RfidPurpose", SqlDbType.Int),
                    new SqlParameter("@ValidState",SqlDbType.Int)};
                    try
                    {

                        pars[0].Value = this.txtName.Text.Trim();
                        pars[1].Value = this.txtAlias.Text.Trim();
                        pars[2].Value = this.txtCard.Text.Trim();
                        pars[3].Value = this.comboBox1.SelectedValue;
                        pars[4].Value = this.cboState.SelectedValue;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    int n = SqlHelper.ExecuteNonQuery(sql, pars);
                    if (n > 0)
                    {
                        MessageBox.Show("保存成功！");
                    }
                    else
                    {
                        MessageBox.Show("保存失败！");
                    }
                }
                Bind();
                this.txtCard.Text = "";
                this.txtName.Text = "";
                this.txtAlias.Text = "";
            }
        }

        private void frmAddCard_Load(object sender, EventArgs e)
        {
            bwkLoadData.RunWorkerAsync();
        }

        private void bwkLoadData_DoWork(object sender, DoWorkEventArgs e)
        {
            string sql2 = "select * from RfidPurpose ";
            dsRfidPurpose = SqlHelper.ExecuteDataset(sql2);
            sql2 = "select ID,Name,Alias,RFID,Meaning,(select meaning from codes where code=validstate and purpose='validstate') as ValidState from Rfid left join RfidPurpose on Rfid.Purpose = RfidPurpose.Code";
            dsRfid = SqlHelper.ExecuteDataset(sql2);
            sql2 = "select Code,Meaning from Codes where Purpose='ValidState'";
            dse = SqlHelper.ExecuteDataset(sql2);
        }

        private void bwkLoadData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            comboBox1.DataSource = dsRfidPurpose.Tables[0];
            comboBox1.DisplayMember = "Meaning";
            comboBox1.ValueMember = "Code";

            cboState.DataSource = dse.Tables[0];
            cboState.DisplayMember = "Meaning";
            cboState.ValueMember = "Code";
            this.gridControl1.DataSource = dsRfid.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bind();
        }

        private void BtnRead_Click(object sender, EventArgs e)
        {
            int _ret=YW605Helper.YW605_WriteToTextBox(this.txtCard);
            if (_ret < 0)
            {
                MessageBox.Show("读卡失败，错误代码："+_ret);
            }           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (YW605Helper.YW605_Init() > 0)
            {
                btnAdd.Enabled = true;
                BtnRead.Enabled = true;
                YW605Helper.Timer_Start(timer1);
            }
            else
            {
                btnAdd.Enabled = false;
                BtnRead.Enabled = false;
                YW605Helper.Timer_Stop(timer1);
                MessageBox.Show("初始化失败");
            }
        }

        private void frmCardNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            YW605Helper.Timer_Stop(timer1);
        }

    }
}
