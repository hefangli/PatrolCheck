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

        private void frmCheckPlanNew_Load(object sender, EventArgs e)
        {
            if (!LoginEmployee.HasNull)
            {
                this.tbPlanner.Tag = LoginEmployee.EmployeeID;
                this.tbPlanner.Text = LoginEmployee.EmployeeName.ToString();
            }
            else
            {
                MessageBox.Show("请先登录");
                this.Close();
            }
            if (PostID == null)
            {
                return;
            }
            this.bindCombobox();
            if (IsEdit)
            {
                SqlDataReader dr = SqlHelper.ExecuteReader("select *,(select Name from post where ID=checkplan.post_id) as PostName From Checkplan where  ID=" + PlanID);
                if (dr.Read())
                {
                    this.tbName.Text = dr["Name"].ToString();
                    this.tbInterval.Text = dr["Interval"].ToString();
                    this.tbPost.Tag = PostID;
                    this.tbPost.Text = dr["PostName"].ToString();
                    this.cboValidState.EditValue = dr["ValidState"];
                    this.cboCheckRoute.EditValue = dr["CheckRoute_ID"];
                    this.cboUnit.EditValue = dr["IntervalUnit"];
                    this.cboPlanType.EditValue = dr["PlanType"];
                    this.dtStartTime.EditValue = dr["StartTime"];
                    this.tbDuration.Text = dr["Duration"].ToString();
                    this.tbTimeDeviation.Text = dr["TimeDeviation"].ToString();
                    this.dtEndTime.EditValue = dr["EndTime"];
                    this.dtpEffect.EditValue = dr["EffectiveTime"];
                    this.dtpIneffect.EditValue = dr["IneffectiveTime"];
                    this.Text = "修改计划";
                    this.labPlanner.Text = "修改人";
                }
            }
            else
            {
                SqlDataReader dr = SqlHelper.ExecuteReader("Select * from Post where id=" + PostID);
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        this.tbPost.Text = dr["Name"].ToString();
                        this.tbPost.Tag = PostID;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbName.Text.Trim() == "" || tbInterval.Text.Trim() == "" || tbTimeDeviation.Text.Trim() == "" || tbDuration.Text.Trim() == "")
            {
                MessageBox.Show("请确保没有空值");
                return;
            }
            object startTime = dtStartTime.EditValue;
            object endTime = dtEndTime.EditValue;
            object effectTime = dtpEffect.EditValue;
            object ineffectTime = dtpIneffect.EditValue;
            if (startTime == null || endTime == null || effectTime == null)
            {
                MessageBox.Show("请确定时间有效");
                return;
            }
            if (DateTime.Parse(startTime.ToString()).AddMinutes(double.Parse(tbDuration.Text)) < DateTime.Parse(endTime.ToString()))
            {
                MessageBox.Show("请确第一次结束的时候大于第一次开始时间加上持续时间之和");
                return;
            }

            if (DateTime.Parse(startTime.ToString()) < DateTime.Parse(effectTime.ToString()) || DateTime.Parse(endTime.ToString()) < DateTime.Parse(effectTime.ToString()) || DateTime.Parse(startTime.ToString()) > DateTime.Parse(endTime.ToString()))
            {
                MessageBox.Show("请确保第一次开始结束时间在事物生效时间之内。");
                return;
            }
            string strInsert;
            if (IsEdit)
            {
                strInsert = @"Update CheckPlan set Name=@Name,StartTime=@StartTime,TimeDeviation=@TimeDeviation,Duration=@Duration,EndTime=@EndTime,Post_ID=@Post,CheckRoute_ID=@Route_ID,Interval=@Interval,IntervalUnit=@IntervalUnit,EffectiveTime=@EffectiveTime,IneffectiveTime=@IneffectiveTime,Planner=@Planner,PlanState=@PlanState,PlanType=@PlanType,ValidState=@ValidState where id=" + PlanID;
            }
            else
            {
                strInsert = @"Insert into CheckPlan(Name,StartTime,Duration,EndTime,Post_ID,CheckRoute_ID,Interval,IntervalUnit,EffectiveTime,IneffectiveTime,Planner,PlanState,TimeDeviation,PlanType,ValidState) values
                                                      (@Name,@StartTime,@Duration,@EndTime,@Post,@Route_ID,@Interval,@IntervalUnit,@EffectiveTime,@IneffectiveTime,@Planner,@PlanState,@TimeDeviation,@PlanType,@ValidState)";
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
                new SqlParameter("@TimeDeviation",SqlDbType.BigInt),
                new SqlParameter("@PlanType",SqlDbType.Int),
                new SqlParameter("@ValidState",SqlDbType.Int),
            };
            pars[0].Value = this.tbName.Text.Trim();
            pars[1].Value = startTime;
            pars[2].Value = this.tbDuration.Text;
            pars[3].Value = endTime;
            pars[4].Value = this.tbPost.Tag;
            pars[5].Value = this.cboCheckRoute.EditValue;
            pars[6].Value = this.tbInterval.Text.Trim();
            pars[7].Value = this.cboUnit.EditValue;
            pars[8].Value = effectTime;
            pars[9].Value = ineffectTime;
            pars[10].Value = tbPlanner.Tag;
            pars[11].Value = 1;
            pars[12].Value = tbTimeDeviation.Text;
            pars[13].Value = this.cboPlanType.EditValue;
            pars[14].Value = this.cboValidState.EditValue;
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
            if (tbDuration.Text != "" && dtStartTime.EditValue!=null)
            {
                dtEndTime.EditValue = DateTime.Parse(dtStartTime.EditValue.ToString()).AddMinutes(double.Parse(tbDuration.Text));
            }
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            if (tbDuration.Text != "")
            {
                dtEndTime.EditValue = DateTime.Parse(dtStartTime.EditValue.ToString()).AddMinutes(double.Parse(tbDuration.Text));
            }
        }

        private void bindCombobox()
        {
            using (SqlDataReader dr = SqlHelper.ExecuteReader("Select Code,Meaning From Codes Where Purpose='IntervalUnit'"))
            {
                while (dr.Read())
                {
                    cboUnit.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr["Meaning"].ToString(), dr["Code"], -1));
                }
            }

            using (SqlDataReader dr = SqlHelper.ExecuteReader("Select Code,Meaning From Codes Where Purpose='PlanType'"))
            {
                while (dr.Read())
                {
                    cboPlanType.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr["Meaning"].ToString(), dr["Code"], -1));
                }
            }

            using (SqlDataReader dr = SqlHelper.ExecuteReader("Select Code,Meaning From Codes Where Purpose='ValidState'"))
            {
                while (dr.Read())
                {
                    cboValidState.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr["Meaning"].ToString(), dr["Code"], -1));
                }
            }

            string sql = @"WITH parent(id) as
 (
   SELECT id FROM dbo.Area WHERE ID  in (SELECT ID FROM dbo.Area WHERE organization_ID IN ((SELECT organization_ID FROM dbo.Post WHERE id="+PostID+"))) "
   +" UNION ALL "
   +" SELECT A.ID FROM Area A,parent b "
   +" where a.area_id = b.id "
 +") SELECT id from parent ";
            //using (SqlDataReader dr = SqlHelper.ExecuteReader("Select *,ID as RID From CheckRoute"))
            //{
            //    while (dr.Read())
            //    {
            //        cboCheckRoute.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr["Name"].ToString(), dr["RID"], -1));
            //    }
            //}
            using (SqlDataReader dr = SqlHelper.ExecuteReader(sql))
            {
                string areaIds = "";
                while (dr.Read())
                {
                    areaIds += dr["ID"] + ",";
                }
                if (areaIds.Trim() != "")
                {
                    string selectAreaIDs = "Select * From CheckRoute where Area_ID in (" + areaIds.TrimEnd(',') + ")";
                    using (SqlDataReader dr2 = SqlHelper.ExecuteReader(selectAreaIDs))
                    {
                        while (dr2.Read())
                        {
                            cboCheckRoute.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr2["Name"].ToString(), dr2["ID"], -1));
                        }

                    }
                }
            }           
        }
    }
}
