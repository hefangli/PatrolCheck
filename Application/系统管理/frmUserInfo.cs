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
    public partial class frmUserInfo : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public frmUserInfo()
        {
            InitializeComponent();
            Bind();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if(this.txtUserName.Text.Trim()==""||this.txtPassword.Text.Trim()==""||this.txtPassword2.Text.Trim()=="")
            {
                if (this.txtUserName.Text.Trim() == "")
                {
                    this.lblName.Visible = true;
                    this.Focus();
                   
                }
                if(this.txtPassword.Text.Trim()=="")
                {
                    this.lblPass.Visible = true;
                    this.Focus();
                   
                }
                if (this.txtPassword2.Text.Trim() == "")
                {
                    this.lblPass2.Visible = true;
                    this.Focus();
            
                }
            }
            else if (this.txtPassword.Text.Trim() != this.txtPassword2.Text.Trim())
            {
                MessageBox.Show("密码输入不一致，请重新输入!", "友情提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                //string SelectUser = "select count(*) from UserInfo where UserName='" + this.txtUserName.Text + "'and Employee_ID='"+this.comboBox1.SelectedValue.ToString()+"'";
                string SelectUser = "select count(*) from UserInfo where UserName='" + this.txtUserName.Text + "'";
                int i = (int)SqlHelper.ExecuteScalar(SelectUser);
                if (i >=1)
                {
                    MessageBox.Show("该用户已存在，请重新输入！", "友情提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtUserName.Text = "";
                    this.txtPassword.Text = "";
                    this.txtPassword2.Text = "";
                }
                else
                {
                    string insertUser = "insert into UserInfo(UserName,Password,Employee_ID) values('" + this.txtUserName.Text + "','" + this.txtPassword.Text + "','"+this.comboBox1.SelectedValue.ToString()+"')";
                    int a = SqlHelper.ExecuteNonQuery(insertUser);
                    if (a > 0)
                    {
                        MessageBox.Show("用户注册成功！");

                    }
                    else
                    {
                        MessageBox.Show("用户注册失败，请重新注册！");
                    }
                }


            }

        }
        public void Bind()
        {
            string SelectEmployee = "select * from Employee";
            DataSet ds = SqlHelper.ExecuteDataset(SelectEmployee);
            this.comboBox1.DataSource = ds.Tables[0];
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.ValueMember = "ID";       
        }
        private void btnQuery_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
