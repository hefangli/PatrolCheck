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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string Username = this.txtName.Text.Trim();
                string Password = this.txtPassword.Text.Trim();
                if (Username =="")
                {
                    MessageBox.Show("请输入用户名！");
                }
                else if (Password =="")
                {

                    MessageBox.Show("请输入密码！");
                }
                else
                {
                    string SelectCount = "select count(*) from userinfo where username='" + Username + "'and password='" + 
Password + "'";     
                    int i = (int)SqlHelper.ExecuteScalar(SelectCount);
                    if (i >= 1)
                    {
                        string SelectUserInfo = "select *  from UserInfo where username='" + Username + "'and password='" + Password + "'";
                        SqlDataReader dr = SqlHelper.ExecuteReader(SelectUserInfo);
                        if (dr.Read())
                        {
                            this.txtName.Text = dr["username"].ToString();
                            this.txtPassword.Text = dr["password"].ToString();
                            this.Hide();
                            Program.MainForm.ShowDialog();
                            this.Close();
                        }


                    }
                    else
                    {
                        MessageBox.Show("用户名或密码错误，请重新输入！");
                    }


                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }
        /// <summary>
        /// 系统退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("你确定要退出本系统吗？","确定",MessageBoxButtons.OKCancel,MessageBoxIcon.Exclamation)==DialogResult.OK)
            {
                Application.Exit();
            }

        }
    }
}
