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
        /// <summary>
        /// datagridview的显示
        /// </summary>
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
                    pars[0].Value = this.txtName.Text.Trim();
                    pars[1].Value = this.txtAlias.Text.Trim();
                    pars[2].Value = this.txtCard.Text.Trim();
                    pars[3].Value = this.comboBox1.SelectedValue;
                    pars[4].Value = this.cboState.SelectedValue;
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
            }
        }


        private void frmAddCard_Load(object sender, EventArgs e)
        {
            bwkLoadData.RunWorkerAsync();
        }
        DataSet dsRfidPurpose = null;
        DataSet dsRfid = null;
        DataSet dse = null;
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

        private void YW605_Init()
        {
            if (YW605Helper.YW_USBHIDInitial() > 0)
            {
                if (YW605Helper.YW_AntennaStatus(1, true) >= 0)
                {
                    if (YW605Helper.YW_SearchCardMode(1, YW605Helper.SEARCHMODE_14443A) > 0)
                    {
                        BtnRead.Enabled = true;
                        btnAdd.Enabled = true;
                        timer1.Start();
                    }
                    else
                    {
                        MessageBox.Show("读写器初始化失败");
                        BtnRead.Enabled = false;
                        btnAdd.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("读写器初始化失败");
                    BtnRead.Enabled = false;
                    btnAdd.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("读写器初始化失败");
                BtnRead.Enabled = false;
                btnAdd.Enabled = false;
            }
        }

        private void BtnRead_Click(object sender, EventArgs e)
        {
            short CardType = 0;
            int CardNoLen = 0;
            char CardMem = (char)0;
            //扇区0的块0是特殊的, 是厂商代码, 已固化, 不可改写. 其中, 第0~ 4个字节为卡的序列号, 第5个字节为序列号的校验码; 第6个字节为
            //卡片的容量􀀁 SIZE 􀀁字节; 第7, 8个字节为卡片的类型号字节, 即Tag type字节; 其它字节由厂商另加定义.
            byte[] SN = new byte[4];
            if (YW605Helper.YW_RequestCard(1, YW605Helper.REQUESTMODE_ALL, ref CardType) > 0)
            {
                if (YW605Helper.YW_AntiCollideAndSelect(1, (char)0, ref CardMem, ref CardNoLen, ref SN[0]) > 0)
                {
                    string rfid = "";
                    for (int i = 0; i < 4; i++)
                    {
                        rfid = rfid + SN[i].ToString("X2");
                    }
                    int _ret=Convert.ToInt32(SqlHelper.ExecuteScalar("select count(1) From rfid where validstate in (0,1) and rfid='" + rfid+"'"));
                    if ( _ret== 0)
                    {
                        txtCard.Text = rfid;
                    }
                    else
                    {
                        MessageBox.Show("已存在此RFID");
                    }
                }
                else
                {
                    MessageBox.Show("读卡失败");
                }
            }
            else
            {
                MessageBox.Show("寻卡失败");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            short CardType = 0;
            int CardNoLen = 0;
            char CardMem = (char)0;
            byte[] SN = new byte[4];
            if (YW605Helper.YW_RequestCard(1, YW605Helper.REQUESTMODE_ALL, ref CardType) > 0)
            {
                if (YW605Helper.YW_AntiCollideAndSelect(1, (char)0, ref CardMem, ref CardNoLen, ref SN[0]) > 0)
                {
                    YW605Helper.YW_Led(1, YW605Helper.LED_GREEN, 2, 2, 0, YW605Helper.LED_GREEN);
                }
                else
                {
                    YW605Helper.YW_Led(1, YW605Helper.LED_RED, 2, 2, 0, YW605Helper.LED_RED);
                }
            }
            else
            {
                YW605Helper.YW_Led(1, YW605Helper.LED_RED, 2, 2, 0, YW605Helper.LED_RED);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            YW605_Init();
        }

    }
}
