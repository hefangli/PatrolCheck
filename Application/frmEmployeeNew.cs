﻿using System;
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
    public partial class frmEmployeeNew : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public frmEmployeeNew()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {   
       
            if (this.txtName.Text == "")
            {
                MessageBox.Show("人员名称不能为空", "友情提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.txtName.Focus();
            }
            else if (txtAlias.Text == "")
            {
                MessageBox.Show("人员别名不能为空", "友情提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.txtAlias.Focus();
            }           
            else if (this.cboPost.SelectedValue == null )
            {
                MessageBox.Show("所属岗位不能为空", "友情提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.cboPost.Focus();
            }
            else if(this.cboState.SelectedValue == null)
            {
                MessageBox.Show("有效状态不能为空", "友情提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

                else
                {
                    if((int)(SqlHelper.ExecuteScalar("select count(*) from employee where name='"+this.txtName.Text+"'"))>0)
                    {
                        MessageBox.Show("人员名称已存在，请重新输入！");
                        this.txtName.Focus();
                        return;
                    }
                    else
                    {
                    string insertEmpoyee = "insert into Employee(Name,Alias,Rfid_ID,ValidState) values(@name,@alias,@rfid_id,@ValidState);select  @@identity";
                    string insertEmpoyeePost = "insert into Post_Employee(Employee_ID,Post_ID) values(@em_id,@id)";
                    SqlParameter[] par = new SqlParameter[]{ new SqlParameter("@name",SqlDbType.NVarChar),
                                                             new SqlParameter("@alias",SqlDbType.NVarChar), 
                                                             new SqlParameter("@rfid_id",SqlDbType.NVarChar),
                                                             new SqlParameter("@ValidState",SqlDbType.Int)};
                    par[0].Value = this.txtName.Text;
                    par[1].Value = this.txtAlias.Text;                    
                    if ((int)SqlHelper.ExecuteScalar("Select Count(1) From Rfid Where Purpose=1 and validstate=1 and ID='" + this.txtRelation.Tag + "'") == 1)
                    {

                        par[2].Value = this.txtRelation.Tag;
                    }
                    else
                    {
                        MessageBox.Show("请确保存在此标签卡");
                        return;
                    }
                    par[3].Value = this.cboState.SelectedValue.ToString();
                    string id = SqlHelper.ExecuteScalar(insertEmpoyee, par).ToString();                  
                    if (id != null )
                    {
                        MessageBox.Show("保存成功！");
                    }
                    else
                    {
                        MessageBox.Show("保存失败！");
                    }
                    SqlParameter[] par1 = new SqlParameter[]{ new SqlParameter("@em_id",SqlDbType.Int),             
                                                              new SqlParameter("@id",SqlDbType.Int) };

                    par1[0].Value = id;
                    par1[1].Value = this.cboPost.SelectedValue.ToString();
                    int i = SqlHelper.ExecuteNonQuery( insertEmpoyeePost, par1);
                }
            }
            BindEmployee(); 
           
        }
        /// <summary>
        /// 数据绑定
        /// </summary>
        public void BindEmployee()
        { 
            string selectEmployee = "select Employee.ID,Employee.Name emName,Employee.Alias as alias ,Rfid.Name as Name,Post.Name postName,(select meaning from codes where code=Employee.validstate and purpose='validstate') as ValidState from Employee,Rfid,Post,Post_Employee where Employee.ID=Post_Employee.Employee_ID and Employee.Rfid_ID=Rfid.ID and Post_Employee.Post_ID=Post.ID";
           //string selectEmployee = "select Employee.ID,Employee.Name emName,Employee.Alias as alias ,Rfid.Name as Name,Post.Name postName,(select meaning from codes where code=Employee.validstate and purpose='validstate') as ValidState from Employee left join Rfid on Employee.Rfid_ID=Rfid.ID left join Post on Post_Employee.Post_ID=Post.ID left join Post_Employee on Employee.ID=Post_Employee.Employee_ID ";
            DataSet ds = SqlHelper.ExecuteDataset(selectEmployee);
            gridControl1.DataSource = ds.Tables[0];
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 数据加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAddEmployee_Load(object sender, EventArgs e)
        {
            string selectPost = "select * from Post where ValidState=1";
            DataSet ds = SqlHelper.ExecuteDataset(selectPost);
            cboPost.DataSource = ds.Tables[0];
            cboPost.DisplayMember = "Name";
            cboPost.ValueMember = "ID";

            //string selectCard = "select * from Rfid where ValidState=1";
            //DataSet dsd = SqlHelper.ExecuteDataset(selectCard);
            //cboCard.DataSource = dsd.Tables[0];
            //cboCard.DisplayMember = "Name";
            //cboCard.ValueMember = "ID";

            string selectState = "select Code,Meaning from Codes where Purpose='ValidState' ";
            DataSet dse = SqlHelper.ExecuteDataset(selectState);
            cboState.DataSource = dse.Tables[0];
            cboState.DisplayMember = "Meaning";
            cboState.ValueMember = "Code";
            BindEmployee();
        }    

        private void btnChose_Click(object sender, EventArgs e)
        {
            frmPointChoseRfid f = new frmPointChoseRfid();
            f.SelIndex = 1;
            f.ShowDialog();
            this.txtRelation.Text = f.RFID_Name == null ? null : f.RFID_Name.ToString();
            this.txtRelation.Tag = f.RFID_ID;
            this.btnSave.Enabled = true;
            this.txtRelation.ReadOnly = false;

        }
    }
}
