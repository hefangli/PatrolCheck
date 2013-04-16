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
                    string SelectCount = "select count(1) from userinfo where username='" + Username+"' and 1=1"; 
                    int i = (int)SqlHelper.ExecuteScalar(SelectCount);
                    if (i == 1)
                    {
                        string SelectUserInfo = "select ID,UserName,Employee_ID,(Select Name From Employee Where ID=UserInfo.Employee_ID) as EmployeeName  from UserInfo where username='" + Username + "'and password='" + Password + "'";
                        using (SqlDataReader dr= SqlHelper.ExecuteReader(SelectUserInfo))
                        {
                           if(dr.Read())
                            {
                                LoginEmployee.ID = dr["ID"];
                                LoginEmployee.LoginName = dr["UserName"];
                                LoginEmployee.EmployeeID = dr["Employee_ID"];
                                LoginEmployee.EmployeeName = dr["EmployeeName"];
                                this.Text = "登录人:"+LoginEmployee.EmployeeName;
                            }
                            this.Hide();
                            Program.MainForm.Text += "   用户:" + LoginEmployee.EmployeeName;
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
