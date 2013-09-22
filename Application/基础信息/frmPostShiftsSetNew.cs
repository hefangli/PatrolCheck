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
    public partial class frmPostShiftsSetNew : Form
    {
        public frmPostShiftsSetNew()
        {
            InitializeComponent();
        }
        private object shift_id = null;
        //班次编号：
        public object Shift_id
        {
            get { return shift_id; }
            set { shift_id = value; }
        }
        private object post_id = null;
        //岗位编号：
        public object Post_id
        {
            get { return post_id; }
            set { post_id = value; }
        }
        private bool isEdit = false;
        //true为编辑，false为新建
        public bool IsEdit
        {
            get { return isEdit; }
            set { isEdit = value; }
        }
        //开始时间：
        private object starttime;

        public object Starttime
        {
            get { return starttime; }
            set { starttime = value; }
        }
        //结束时间：
        private object endtime;

        public object Endtime
        {
            get { return endtime; }
            set { endtime = value; }
        }        
        private void btnSave_Click(object sender, EventArgs e)
        {
           if(txtShiftsName.Text=="")
           {
               MessageBox.Show("请确保没有空值！");
           }
           string sql = "insert into shifts(name,post_id,starttime,endtime,validstate) values(@name,@post_id,@starttime,@endtime,@validstate)";      
           if(IsEdit)
           {
               sql = "update shifts set name=@name,post_id=@post_id,starttime=@starttime,endtime=@endtime,validstate=@validstate where id=@id";
           }

           SqlParameter[] pars = new SqlParameter[] { 
              new SqlParameter("@id",Shift_id),
              new SqlParameter("@name",txtShiftsName.Text),
              new SqlParameter("@post_id",cboPostName.EditValue),
              new SqlParameter("@starttime",dtStartTime.EditValue),
              new SqlParameter("@endtime",dtEndTime.EditValue),
              new SqlParameter("@validstate",cboValidState.EditValue)
            };
           if (SqlHelper.ExecuteNonQuery(sql, pars) == 1)
           {
               MessageBox.Show("保存成功");
           }

        }

        private void frmPostShiftsSetNew_Load(object sender, EventArgs e)
        {
            BindComoboBox();
            if (IsEdit)
            {
                using (SqlDataReader dr = SqlHelper.ExecuteReader("select * from Shifts where id=" + Shift_id))
                {
                    while (dr.Read())
                    {
                        this.txtShiftsName.Text = dr["Name"].ToString();
                        this.cboPostName.EditValue = dr["post_id"];                                       
                        this.dtStartTime.EditValue = dr["StartTime"];
                        this.dtEndTime.EditValue = dr["EndTime"];
                        this.cboValidState.EditValue=dr["validstate"];
                    }

                }

            }
            else
            {
                this.Text = "编辑班次";
                string shiftsInfo = SqlHelper.ExecuteScalar("select name from post where id=" + Post_id).ToString();
                this.cboPostName.EditValue = shiftsInfo;
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
            using (SqlDataReader dr = SqlHelper.ExecuteReader("select * from post where id=" + Post_id ))
            {
              
                while (dr.Read())
                {
                    cboPostName.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr["Name"].ToString(), dr["ID"], -1));
                }
                cboPostName.EditValue = 1;

            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        


    }
}
