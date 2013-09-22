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
    public partial class frmPostSchedulesSetNew : Form
    {
        public frmPostSchedulesSetNew()
        {
            InitializeComponent();
        }
        private bool isEdit = false;
        //true为编辑，false为新建
        public bool IsEdit
        {
            get { return isEdit; }
            set { isEdit = value; }
        }
        //班组编号：
        private object team_id;

        public object Team_id
        {
            get { return team_id; }
            set { team_id = value; }
        }
        //班次编号：
        private object shifts_id;

        public object Shifts_id
        {
            get { return shifts_id; }
            set { shifts_id = value; }
        }
        //岗位编号：
        private object post_id;

        public object Post_id
        {
            get { return post_id; }
            set { post_id = value; }
        }
        //规则编号：
        private object schedules_id;

        public object Schedules_id
        {
            get { return schedules_id; }
            set { schedules_id = value; }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {            
            if(this.txtName.Text=="")
            {
                MessageBox.Show("请确保没有空值！");
            }  
            string sql = "insert into Schedules(name,team_id,post_id,shifts_id,date,validstate) values(@name,@team_id,@post_id,@shifts_id,@date,@validstate)";
            if (IsEdit)
            {
                sql = "update Schedules set name=@name,team_id=@team_id,post_id=@post_id,shifts_id=@shifts_id,date=@date,validstate=@validstate where id=@id";
            }
            SqlParameter[] pars = new SqlParameter[] { 
              new SqlParameter("@id",Schedules_id),
              new SqlParameter("@name",txtName.Text),
              new SqlParameter("@team_id",cboTeam.EditValue),
              new SqlParameter("@post_id",cboPostName.EditValue),
              new SqlParameter("@shifts_id",cboShifts.EditValue),
              new SqlParameter("@date",dtTime.EditValue),
              new SqlParameter("@validstate",cboValidState.EditValue)
            };
            if (SqlHelper.ExecuteNonQuery(sql, pars) == 1)
            {
                MessageBox.Show("保存成功");
            }

        }
        private void BindComoboBox()
        {
            using (SqlDataReader dr = SqlHelper.ExecuteReader("Select Code,Meaning from Codes Where Purpose='ValidState'"))
            {
                while (dr.Read())
                {
                    cboValidState.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr["Meaning"].ToString(), dr["Code"], -1));
                }
                cboValidState.EditValue = 1;
            }
            //绑定岗位信息
            using (SqlDataReader dr = SqlHelper.ExecuteReader("select * from post where id=" + Post_id))
            {

                while (dr.Read())
                {
                    cboPostName.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr["Name"].ToString(), dr["ID"], -1));                   
                }
                cboPostName.EditValue = 1;
            }
            //绑定班次
            using (SqlDataReader dr = SqlHelper.ExecuteReader("select * from shifts"))
            {
                while (dr.Read())
                {

                    cboShifts.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr["Name"].ToString(), dr["ID"], -1));
                }
                cboShifts.EditValue = 1;
            }

           //绑定班组

            using (SqlDataReader dr = SqlHelper.ExecuteReader("select *from Team"))
            {

                while (dr.Read())
                {
                    cboTeam.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr["Name"].ToString(),dr["ID"],-1));
                }
                cboTeam.EditValue = 1;

            }


        }
        private void frmPostSchedulesSetNew_Load(object sender, EventArgs e)
        {
            BindComoboBox();
            //BindShifts();
           //BindTeam();
            if(IsEdit)
            {
                 //SqlDataReader dr = SqlHelper.ExecuteReader("select*,(select Name from post where id=Schedules.Post_ID) as postname,(select Name from Team where id=Schedules.Team_ID) as teamname,(select Name from shifts where id=Schedules.Shifts_ID) as shiftsname from Schedules where id=" + Schedules_id);
                 using (SqlDataReader dr = SqlHelper.ExecuteReader("select*,Post_ID,Team_ID,Shifts_ID from Schedules where id=" + Schedules_id))
                 {
                    while(dr.Read())
                    {
                        this.txtName.Text=dr["Name"].ToString();
                        this.cboPostName.EditValue = dr["Post_ID"];                      
                        this.cboShifts.EditValue = dr["Shifts_ID"];
                        this.cboTeam.EditValue = dr["Team_ID"];
                        this.dtTime.EditValue=dr["Date"];
                        this.cboValidState.EditValue = dr["ValidState"]; 
                    }


                }


            }
          

        }
       //关闭
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //绑定班次：
        //private void BindShifts()
        //{
        //    string sqlShifts = "select * from shifts";
        //    DataSet ds=SqlHelper.ExecuteDataset(sqlShifts);
        //    this.cboShifts.ValueMember = "ID";
        //    this.cboShifts.DisplayMember = "Name";
        //    this.cboShifts.DataSource=ds.Tables[0];

        //}
        ////绑定班组：
        //private void BindTeam()
        //{
        //    string sqlTeam = "select *from Team";
        //    DataSet ds = SqlHelper.ExecuteDataset(sqlTeam);
        //    this.cboTeam.ValueMember = "ID";
        //    this.cboTeam.DisplayMember = "Name";
        //    this.cboTeam.DataSource=ds.Tables[0];
        //}
    }
}
