using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraGrid;

namespace WorkStation
{
    public partial class frmPlanAdd : Form
    {
        public frmPlanAdd()
        {
            InitializeComponent();
        }
        public GridControl dgv = null;
        public bool isEdit = false;
        public string planID="";
        private void frmAddPlan_Add_Load(object sender, EventArgs e)
        {
            this.cboInit();
            if (isEdit)
            {
                SqlDataReader dr = SqlHelper.ExecuteReader("select * From Checkplan where  ID="+planID);
                if (dr.Read())
                {
                    this.txtName.Text = dr["Name"].ToString();
                    this.txtAlias.Text = dr["Alias"].ToString();
                    this.txtInterval.Text = dr["Interval"].ToString();
                    this.cboPost.SelectedValue = dr["Post"].ToString();
                    this.cboOperator.SelectedValue = dr["Operator"].ToString() == "" ? "-1" : dr["Operator"].ToString();
                    this.cboRoute.SelectedValue = dr["Route_ID"].ToString();
                    this.cboUnit.SelectedValue = dr["IntervalUnit"].ToString();
                    this.dtpStart.Value = DateTime.Parse(dr["StartTime"].ToString());
                    this.txtDuration.Text = dr["Duration"].ToString();
                    this.txtTimeDeviation.Text = dr["TimeDeviation"].ToString();
                    this.dtpEnd.Value = DateTime.Parse(dr["EndTime"].ToString());
                    this.dtpEffect.Value = DateTime.Parse(dr["EffectiveTime"].ToString());
                    this.dtpIneffect.Value = DateTime.Parse(dr["IneffectiveTime"].ToString());
                    this.Text = "修改计划";
                    this.btnSave.Text = "修改";
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {                           
            if (txtName.Text.Trim() == "" || txtInterval.Text.Trim() == ""||txtTimeDeviation.Text.Trim()==""||txtDuration.Text.Trim()=="")
            {
                MessageBox.Show("请确保没有空值");
                return;
            }
            if (cboPost.SelectedValue == null)
            {
                MessageBox.Show("请选择岗位");
                return;
            }
            if (dtpStart.Value.AddMinutes(double.Parse(txtDuration.Text)) < dtpEnd.Value)
            {
                MessageBox.Show("请确第一次结束的时候大于第一次开始时间加上持续时间之和");
                return;
            }

            if (dtpStart.Value < dtpEffect.Value || dtpStart.Value > dtpIneffect.Value || dtpEnd.Value < dtpEffect.Value || dtpEnd.Value > dtpIneffect.Value || dtpStart.Value >dtpEnd.Value || dtpEffect.Value > dtpIneffect.Value)
            {
                MessageBox.Show("请确保第一次开始结束时间在事物生效时间之内。");
                return;
            }
            if (isEdit==false&&SqlHelper.ExecuteScalar("Select count(1) From CheckPlan Where Name='" + this.txtName.Text.Trim() + "'").ToString() != "0")
            {
                MessageBox.Show("请确保计划名称的唯一性");
                return;
            }
            string strInsert;
            if (isEdit)
            {
                strInsert = @"Update CheckPlan set Name=@Name,Alias=@Alias,StartTime=@StartTime,TimeDeviation=@TimeDeviation,Operator=@Operator,Duration=@Duration,EndTime=@EndTime,Post=@Post,Route_ID=@Route_ID,Interval=@Interval,IntervalUnit=@IntervalUnit,EffectiveTime=@EffectiveTime,IneffectiveTime=@IneffectiveTime,Planner=@Planner,PlanState=@PlanState where id="+planID;
            }
            else
            {
                strInsert = @"Insert into CheckPlan(Name,Alias,StartTime,Duration,EndTime,Post,Route_ID,Interval,IntervalUnit,EffectiveTime,IneffectiveTime,Planner,PlanState,TimeDeviation,Operator) values
                                                      (@Name,@Alias,@StartTime,@Duration,@EndTime,@Post,@Route_ID,@Interval,@IntervalUnit,@EffectiveTime,@IneffectiveTime,@Planner,@PlanState,@TimeDeviation,@Operator)";
            }
            SqlParameter[] pars = new SqlParameter[] { 
                new SqlParameter("@Name",SqlDbType.VarChar),
                new SqlParameter("@Alias",SqlDbType.VarChar),
                new SqlParameter("@StartTime",SqlDbType.DateTime),
                new SqlParameter("@Duration",SqlDbType.Int),
                new SqlParameter("@EndTime",SqlDbType.DateTime),
                new SqlParameter("@Post",SqlDbType.BigInt),
                new SqlParameter("@Route_ID",SqlDbType.BigInt),
                new SqlParameter("@Interval",SqlDbType.Int),
                new SqlParameter("@IntervalUnit",SqlDbType.Char),
                new SqlParameter("@EffectiveTime",SqlDbType.DateTime),
                new SqlParameter("@IneffectiveTime",SqlDbType.DateTime),
                new SqlParameter("@Planner",SqlDbType.Float),
                new SqlParameter("@PlanState",SqlDbType.Int),
                new SqlParameter("@Operator",SqlDbType.BigInt),
                new SqlParameter("@TimeDeviation",SqlDbType.BigInt)
            };
            pars[0].Value = this.txtName.Text.Trim();
            pars[1].Value = this.txtAlias.Text.Trim();
            pars[2].Value = this.dtpStart.Value;
            pars[3].Value = this.txtDuration.Text;
            pars[4].Value = this.dtpEnd.Value;
            pars[5].Value = this.cboPost.SelectedValue.ToString() == "-1" ? null : this.cboPost.SelectedValue;
            pars[6].Value = this.cboRoute.SelectedValue;
            pars[7].Value = this.txtInterval.Text.Trim();
            pars[8].Value = this.cboUnit.SelectedValue;
            pars[9].Value = this.dtpEffect.Value;
            pars[10].Value = this.dtpIneffect.Value;
            pars[11].Value = 88888888;
            pars[12].Value = 1;
            pars[13].Value = cboOperator.SelectedValue.ToString() == "-1" ? null : cboOperator.SelectedValue;
            pars[14].Value = txtTimeDeviation.Text;
            if (SqlHelper.ExecuteNonQuery(strInsert, pars) != 1)
            {
                MessageBox.Show("保存失败，请稍后再试！");
            }
            else
            {
                MessageBox.Show("保存成功。");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {           
            this.Close();
        }

        private void cboInit()
        {
            DataSet ds = SqlHelper.ExecuteDataset("Select Code,Meaning From Codes Where Purpose='IntervalUnit'");
            cboUnit.DataSource = ds.Tables[0];
            cboUnit.DisplayMember = "Meaning";
            cboUnit.ValueMember = "Code";

            ds.Dispose();
            ds = SqlHelper.ExecuteDataset("Select ID,Name From CheckRoute where validstate=1");
            cboRoute.DisplayMember = "Name";
            cboRoute.ValueMember = "ID";
            cboRoute.DataSource = ds.Tables[0];

            ds.Dispose();
            //ds = SqlHelper.ExecuteDataset("Select ID,Name From Post where validstate=1");
            //cboPost.DisplayMember = "Name";
            //cboPost.ValueMember = "ID";
            //cboPost.DataSource = ds.Tables[0];
            //ds.Dispose();
        }

        private void cboPost_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select e.ID,e.Name From Employee e left join Post_Employee p on e.id=p.employee_id where validstate=1";
            if (cboPost.SelectedValue != null )
            {
                sql += " and p.post_id="+cboPost.SelectedValue;
            }
            DataSet ds = SqlHelper.ExecuteDataset(sql);
            DataRow dr = ds.Tables[0].NewRow();
            dr[0] = -1; dr[1] = "未选择";
            ds.Tables[0].Rows.InsertAt(dr,0);
            cboOperator.ValueMember = "ID";
            cboOperator.DisplayMember = "Name";
            cboOperator.DataSource=ds.Tables[0];
            ds.Dispose(); 
        }

        private void cboOperator_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboOperator.SelectedValue != null && cboOperator.SelectedValue.ToString() != "-1")
            {
                object postid = SqlHelper.ExecuteScalar("select post_id From post_employee where  employee_id=" + cboOperator.SelectedValue);
                cboPost.SelectedValue = postid == null ? "-1" : postid;
            }
        }

        private void cboRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
            //路线在一个厂区下 岗位也在某个厂区下。两者联系在厂区
            if (cboRoute.SelectedValue != null)
            {
                object site_id = SqlHelper.ExecuteScalar("select site_id from checkroute where validstate=1 and id="+cboRoute.SelectedValue);
                if (site_id != null)
                {
                    DataSet ds = SqlHelper.ExecuteDataset("Select ID,Name From Post where validstate=1 and site_id="+site_id);
                    cboPost.DisplayMember = "Name";
                    cboPost.ValueMember = "ID";
                    cboPost.DataSource = ds.Tables[0];
                    ds.Dispose();
                }
            }
        }

        private void txtDuration_EditValueChanged(object sender, EventArgs e)
        {
            if (txtDuration.Text != "")
            {
                dtpEnd.Value = dtpStart.Value.AddMinutes(double.Parse(txtDuration.Text));
            }
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            if (txtDuration.Text != "")
            {
                dtpEnd.Value = dtpStart.Value.AddMinutes(double.Parse(txtDuration.Text));
            }
        }
    }
}
