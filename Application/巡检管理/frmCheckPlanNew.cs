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
    public partial class frmCheckPlanNew : Form
    {
        public frmCheckPlanNew()
        {
            InitializeComponent();
        }
        public bool IsEdit = false;            //是否是编辑 True:真
        public object PlanID = null;           //计划ID
        public object PostID = null;           //岗位ID    
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbName.Text.Trim() == "" || txtInterval.Text.Trim() == "" || txtTimeDeviation.Text.Trim() == "" || txtDuration.Text.Trim() == "")
            {
                MessageBox.Show("请确保没有空值");
                return;
            }
            if (dtpStart.Value.AddMinutes(double.Parse(txtDuration.Text)) < dtpEnd.Value)
            {
                MessageBox.Show("请确第一次结束的时候大于第一次开始时间加上持续时间之和");
                return;
            }

            if (dtpStart.Value < dtpEffect.Value || dtpStart.Value > dtpIneffect.Value || dtpEnd.Value < dtpEffect.Value || dtpEnd.Value > dtpIneffect.Value || dtpStart.Value > dtpEnd.Value || dtpEffect.Value > dtpIneffect.Value)
            {
                MessageBox.Show("请确保第一次开始结束时间在事物生效时间之内。");
                return;
            }
            string strInsert;
            if (IsEdit)
            {
                strInsert = @"Update CheckPlan set Name=@Name,StartTime=@StartTime,TimeDeviation=@TimeDeviation,Operator=@Operator,Duration=@Duration,EndTime=@EndTime,Post_ID=@Post,Route_ID=@Route_ID,Interval=@Interval,IntervalUnit=@IntervalUnit,EffectiveTime=@EffectiveTime,IneffectiveTime=@IneffectiveTime,Planner=@Planner,PlanState=@PlanState where id=" + PlanID;
            }
            else
            {
                strInsert = @"Insert into CheckPlan(Name,StartTime,Duration,EndTime,Post_ID,Route_ID,Interval,IntervalUnit,EffectiveTime,IneffectiveTime,Planner,PlanState,TimeDeviation,Operator) values
                                                      (@Name,@StartTime,@Duration,@EndTime,@Post,@Route_ID,@Interval,@IntervalUnit,@EffectiveTime,@IneffectiveTime,@Planner,@PlanState,@TimeDeviation,@Operator)";
            }
            SqlParameter[] pars = new SqlParameter[] { 
                new SqlParameter("@Name",SqlDbType.VarChar),
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
            pars[0].Value = this.tbName.Text.Trim();
            pars[1].Value = this.dtpStart.Value;
            pars[2].Value = this.txtDuration.Text;
            pars[3].Value = this.dtpEnd.Value;
            pars[4].Value = this.tbPost.Tag;
            pars[5].Value = this.cboRoute.SelectedValue;
            pars[6].Value = this.txtInterval.Text.Trim();
            pars[7].Value = this.cboUnit.SelectedValue;
            pars[8].Value = this.dtpEffect.Value;
            pars[9].Value = this.dtpIneffect.Value;
            pars[10].Value = 88888888;
            pars[11].Value = 1;
            pars[12].Value = cboOperator.SelectedValue;
            pars[13].Value = txtTimeDeviation.Text;
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

        private void frmCheckPlanNew_Load(object sender, EventArgs e)
        {
            this.tbPost.Properties.ReadOnly = true;
            this.cboInit();
            if (IsEdit)
            {
                SqlDataReader dr = SqlHelper.ExecuteReader("select *,(select Name from post where ID=checkplan.post_id) as PostName From Checkplan where  ID=" + PlanID);
                if (dr.Read())
                {
                    this.tbName.Text = dr["Name"].ToString();
                    this.txtInterval.Text = dr["Interval"].ToString();
                    this.tbPost.Tag = dr["Post_ID"].ToString();
                    this.tbPost.Text = dr["PostName"].ToString();
                    this.cboOperator.SelectedValue = dr["Operator"].ToString() == "" ? "-1" : dr["Operator"].ToString();
                    this.cboRoute.SelectedValue = dr["Route_ID"];
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
            else
            {
                SqlDataReader dr = SqlHelper.ExecuteReader("Select * from Post where id="+PostID);
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        this.tbPost.Text = dr["Name"].ToString();
                        this.tbPost.Tag = dr["ID"];
                    }
                }
                
            }
        }

        private void cboInit()
        {
            DataSet ds = SqlHelper.ExecuteDataset("Select Code,Meaning From Codes Where Purpose='IntervalUnit'");
            cboUnit.DisplayMember = "Meaning";
            cboUnit.ValueMember = "Code";
            cboUnit.DataSource = ds.Tables[0];
            ds.Dispose();
            
            ds = SqlHelper.ExecuteDataset("Select ID,Name From CheckRoute where validstate=1");
            cboRoute.DisplayMember = "Name";
            cboRoute.ValueMember = "ID";
            cboRoute.DataSource = ds.Tables[0];
            ds.Dispose();           
        }
    }
}
