using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;

namespace WorkStation
{
    public partial class frmReportSearchByPlan : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public frmReportSearchByPlan()
        {
            InitializeComponent();       
        }

        private void frmReportSearchByPlan_Load(object sender, EventArgs e)
        { 
            this.BeginInvoke((Action)delegate
            {
                bindRoute();
                this.dtpStart.Value = DateTime.Parse((DateTime.Now.AddDays(-1).ToShortDateString() + " 00:00"));
                this.dtpEndTime.Value = DateTime.Parse((DateTime.Now.AddDays(-1).ToShortDateString() + " 23:59"));
            });
            bindPost();
            bindState();
           
        }

        private void bindState()
        {
            BoxItem item_0 = new BoxItem("全部","0,1");
            BoxItem item_1 = new BoxItem("正常","1");
            BoxItem item_2 = new BoxItem("不正常","0");
            cboState.Items.AddRange(new object[] { item_0,item_1,item_2});
            cboState.SelectedIndex = 0;
        }
        private void bindRoute()
        {
            DataSet ds = SqlHelper.ExecuteDataset("select ID,Name From CheckRoute where validstate=1");
            DataRow dr = ds.Tables[0].NewRow();
            dr[0] = -1;
            dr[1] = "全部";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            cboRoute.DataSource = ds.Tables[0];        
            ds.Dispose();

        }
        private void bindEmployee(object postid)
        {
            string sql = "select e.ID,e.Name from employee e left join post_employee pe  on pe.employee_id=e.id where pe.post_id=" + postid;
            DataSet ds = SqlHelper.ExecuteDataset(sql);
            DataRow dr = ds.Tables[0].NewRow();
            dr[0] = "-1";
            dr[1] = "全部";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            cboOperator.DisplayMember = "Name";
            cboOperator.ValueMember = "ID";
            cboOperator.DataSource = ds.Tables[0];
        }
        private void bindPost()
        {
            string sql = "select ID,Name From Post where validstate=1";
            DataSet ds = SqlHelper.ExecuteDataset(sql);
            DataRow dr = ds.Tables[0].NewRow();
            dr[0] = -1; dr[1] = "全部";
            ds.Tables[0].Rows.InsertAt(dr,0);
            cboPost.DisplayMember = "Name";
            cboPost.ValueMember = "ID";
            cboPost.DataSource=ds.Tables[0];
        }
        private void bindPlan(object routeid,DateTime start,DateTime end)
        {
            string sql = "Select ID,Name from checkplan where  PlanState=16";
            sql += " and ((StartTime<='" + start + "' and EndTime>='" + end + "') or (StartTime>'" + start + "' and StartTime<'" + end + "') or (EndTime>'" + start + "' and EndTime<'" + end + "'))";
            if (routeid.ToString() != "-1")
            {
                sql += " and route_Id=" + routeid ;
            }
            DataSet ds = SqlHelper.ExecuteDataset(sql);
            DataRow dr = ds.Tables[0].NewRow();
            dr[0] = -1;
            dr[1] = "全部";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            cboPlan.DisplayMember = "Name";
            cboPlan.ValueMember = "ID";
            cboPlan.DataSource = ds.Tables[0];
            ds.Dispose();
        }
        private void bindTask(object planid,DateTime start,DateTime end)
        {
            string sql = "Select ID,Name From CheckTask Where taskstate in(8,16) and StartTime>='"+start+"' and EndTime<='"+end+"' and plan_id="+planid;
            DataSet ds = SqlHelper.ExecuteDataset(sql);
            DataRow dr = ds.Tables[0].NewRow();
            dr[0] = -1;
            dr[1] = "全部";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            cboTask.DisplayMember = "Name";
            cboTask.ValueMember = "ID";
            cboTask.DataSource = ds.Tables[0];
            ds.Dispose();
        }

        private void cboRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindPlan(cboRoute.SelectedValue,dtpStart.Value,dtpEndTime.Value);
        }
        private void cboPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPlan.SelectedValue == null) return;
            bindTask(cboPlan.SelectedValue, dtpStart.Value, dtpEndTime.Value);
            object postid = SqlHelper.ExecuteScalar("Select post from checkplan where id="+cboPlan.SelectedValue);
            cboPost.SelectedValue = postid == null ? "-1" : postid;
        }
        private void cboPost_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPost.SelectedValue != null)
            {
                bindEmployee(cboPost.SelectedValue);
            }
        }
        private void cboOperator_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboOperator.SelectedValue != null && cboOperator.SelectedValue.ToString()!="-1")
            {
                string sql = "select post_id From post_employee where employee_id="+cboOperator.SelectedValue;
                object postid = SqlHelper.ExecuteScalar(sql);
                cboPost.SelectedValue = postid == null ? "-1" : postid;
            }
        }
        private void dtpValueChanged(object sender, EventArgs e)
        {
            bindPlan(cboRoute.SelectedValue, dtpStart.Value, dtpEndTime.Value);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sqlTask = @"select 
                       r.id as RouteChecking_ID,
                       c.name as TaskName,
                       (select name from checkroute where id=c.route_id) as RouteName,
                       (select name from checkplan where id=c.plan_id) as PlanName,
                       c.StartTime ,c.EndTime ,r.starttime as ActualStartTime,r.endtime as ActualEndTime,
                       r.PercentComplete as PercentComplete,
                       (select Name From Employee where id=c.operator) as Operator
                       From routechecking r,checktask c where r.task_id=c.id and r.starttime>= '"+dtpStart.Value+
                       "' and r.endtime<='"+dtpEndTime.Value+"'";
            string sqlPoint = @"select 
                                   R.ID as RouteChecking_ID,p.ID as PointChecking_ID,
                                  (select name from PhysicalCheckPoint where  id=l.physicalPoint_id) as PointName,
                                   p.StartTime,p.EndTime,p.Duration
                              From PointChecking p 
                                   left join LogicalCheckPoint l on p.LogicPoint_ID=l.id
                                   left join Routechecking r on p.routechecking_id=r.id 
                              where p.StartTime>='" + dtpStart.Value + "' and p.EndTime<='" + dtpEndTime.Value+"'";
            string sqlItem = @"select 
                                 P.ID as PointChecking_ID,i.ID as ItemID,c.name as ItemName,
                                 i.BooleanValue,i.NumericalValue,i.TextValue,i.PictureFile ,
                                 (select meaning from codes where code=c.valuetype and purpose='valuetype') as ValueType 
                               from itemchecking i 
                                    left join pointchecking p  on i.pointchecking_id=p.id
                                    left join checkitem c on i.item_id=c.id where p.StartTime>='" + dtpStart.Value + "' and p.EndTime<='" + dtpEndTime.Value+"'";
            if (cboState.SelectedItem != null)
            {
                //巡检项 是否正常
                sqlItem += " and i.booleanvalue in ("+(cboState.SelectedItem as BoxItem).Value+")";
            }
            else if (cboState.SelectedValue != null && cboState.SelectedValue.ToString() == "-1")
            {
                sqlTask += " and c.taskstate in(select code from codes where purpose='taskstate')";
            }
            if (cboPlan.SelectedValue!=null&&cboRoute.SelectedValue.ToString() != "-1")
            {
                sqlTask += " and c.route_id=" + cboRoute.SelectedValue;
            }
            if (cboPlan.SelectedValue!=null&&cboPlan.SelectedValue.ToString() != "-1")
            {
                sqlTask += " and c.plan_id=" + cboPlan.SelectedValue;
            }
            if (cboTask.SelectedValue!=null&&cboTask.SelectedValue.ToString() != "-1")
            {
                sqlTask += " and c.id=" + cboTask.SelectedValue;
            }
            if (cboPost.SelectedValue != null && cboPost.SelectedValue.ToString() != "-1")
            {
                sqlTask += " and c.post=" + cboPost.SelectedValue;
            }
            if (cboOperator.SelectedValue!=null&&cboOperator.SelectedValue.ToString() != "-1")
            {
                sqlTask += " and c.Operator="+cboOperator.SelectedValue;
            }
            DataSet dsTables = new DataSet();
            dsTables = SqlHelper.ExecuteDataset(sqlTask+";"+sqlPoint+";"+sqlItem);

            dsTables.Relations.Add(new DataRelation("巡检点", dsTables.Tables[0].Columns["RouteChecking_ID"], dsTables.Tables[1].Columns["RouteChecking_ID"], false));
            dsTables.Relations.Add(new DataRelation("巡检项", dsTables.Tables[1].Columns["PointChecking_ID"], dsTables.Tables[2].Columns["PointChecking_ID"], false));
            gridControl1.DataSource = dsTables.Tables[0];
        } 
      
    }
}
