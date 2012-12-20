using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using System.Data.SqlClient;
using DevExpress.XtraEditors.Controls;

namespace WorkStation
{
    public partial class frmTaskAssignment : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public frmTaskAssignment()
        {
            InitializeComponent();
        }
        private void frmTaskAssignment_Load(object sender, EventArgs e)
        {
            this.dtpStart.Value = DateTime.Parse((DateTime.Now.ToShortDateString() + " 00:00"));
            this.dtpEnd.Value = DateTime.Parse((DateTime.Now.ToShortDateString() + " 23:59"));
            this.checkBox1.Checked = false;
            getDgvTask(null, null);
            bindCboPlan(null,null);
            SqlDataReader dr = SqlHelper.ExecuteReader("select e.name as OperatorName,e.id as OperatorID from post_employee pe left join employee e on pe.employee_id=e.id where e.validstate=1" );
            while (dr.Read())
            {
                repositoryItemImageComboBox1.Items.Add(new ImageComboBoxItem(dr["OperatorName"].ToString(), dr["OperatorID"], 0));
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                getDgvTask(dtpStart.Value, dtpEnd.Value);
            }
            else
            {
                getDgvTask(null,null);
            }
        }
       
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            bindCboPlan(null, null);
            getDgvTask(null, null);
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            bindCboPlan(dtpStart.Value, dtpEnd.Value);
        }
        private void cboPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPlan.SelectedValue != null && cboPlan.SelectedValue.ToString() != "-1")
            {
                bindCboTask(cboPlan.SelectedValue);
            }
            else
            {
                cboTask.DataSource = null;
                cboTask.Items.Clear();
                cboTask.Items.Add("全部");
                cboTask.SelectedIndex = 0;
            }
        }

        DataSet dsGvSource=null;
        private void getDgvTask(object starttime, object endtime)
        {
            string sql = @"select 
                    t.ID,P.Name as PlanName,t.Name ,t.Alias,t.StartTime,
                    t.EndTime,t.Duration,t.TimeDeviation,
                    (select Name From Post where id=t.Post) as PostName,
                    t.Post as PostID,
                    (select Name from employee where id=t.operator) as OperatorName,
                     t.Operator as OperatorID,
                    (select Name from checkroute where id=t.route_id) as RouteName,
                     t.Interval,
                    (select Meaning from codes where code=t.Intervalunit and purpose='intervalunit') as IntervalUnit,
                    (select name from employee where validstate=1 and id=p.planner) as Planner,                           
                    p.EffectiveTime,p.IneffectiveTime,
                     (select meaning from codes where code=t.taskstate and purpose='taskstate') as TaskState 
                    From checktask t left join checkplan p on t.plan_id=p.id Where p.planstate=16 and t.taskstate=1";
            if (cboPlan.SelectedValue != null && cboPlan.SelectedValue.ToString() != "-1")
            {
                sql += " and t.plan_id=" + cboPlan.SelectedValue;
            }
            if (cboTask.SelectedValue != null && cboTask.SelectedValue.ToString() != "-1")
            {
                sql += " and t.id=" + cboTask.SelectedValue;
            }
            if (starttime != null && endtime != null)
            {
                //sql += " and ((p.effectivetime<='" + starttime + "' and p.ineffectivetime>='" + endtime + "') or (p.effectivetime>'" + starttime + "' and p.effectivetime<'" + endtime + "') or (p.ineffectivetime>'" + starttime + "' and p.ineffectivetime<'" + endtime + "'))";
                sql += " and t.starttime>='"+starttime+"' and t.endtime<='"+endtime+"'";
            }
            dsGvSource=new DataSet ();
            dsGvSource = SqlHelper.ExecuteDataset(sql);
            if (dsGvSource != null)
            {
                dsGvSource.Tables[0].Columns.Add(new DataColumn("isChose",typeof(System.Boolean)));
                for (int i = 0; i < dsGvSource.Tables[0].Rows.Count; i++)
                {
                    dsGvSource.Tables[0].Rows[i]["isChose"] = false;
                }
                gridControlPlan.DataSource = dsGvSource.Tables[0];
            }
        }

        private void bindCboPlan(object start, object end)
        {
            string sql = "Select ID,Name From CheckPlan where PlanState=16"; // 
            if (start != null && end != null)
            {
                sql += " and ((effectivetime<='" + start + "' and ineffectivetime>='" + end + "') or (effectivetime>'" + start + "' and effectivetime<'" + end + "') or (ineffectivetime>'" + start + "' and ineffectivetime<'" + end + "'))";
            }
            DataSet ds = SqlHelper.ExecuteDataset(sql);
            DataRow dr = ds.Tables[0].NewRow();
            dr[0] = -1;
            dr[1] = "全部";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            cboPlan.ValueMember = "ID";
            cboPlan.DisplayMember = "Name";
            cboPlan.DataSource = ds.Tables[0];
        }
        private void bindCboTask(object planID)
        {
            string sql = "";
            if (checkBox1.Checked)
            {
                sql = "select ID,Name From CheckTask where StartTime>='" + dtpStart.Value + "' and EndTime<='" + dtpEnd.Value + "'and plan_id=" + planID;
            }
            else
            {
                sql = "select ID,Name From CheckTask where plan_id="+planID;
            }
            sql += " and taskstate=1";
            DataSet ds = SqlHelper.ExecuteDataset(sql);
            DataRow dr = ds.Tables[0].NewRow();
            dr[0] = -1;
            dr[1] = "全部";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            cboTask.ValueMember = "ID";
            cboTask.DisplayMember = "Name";
            cboTask.DataSource = ds.Tables[0];
        }

        private void gvPlan_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == "OperatorID")
            {
                object postid = gvPlan.GetRowCellValue(e.RowHandle, "PostID");
                if (postid == null) return;
                SqlDataReader dr = SqlHelper.ExecuteReader("select e.name as OperatorName,e.id as OperatorID from post_employee pe left join employee e on pe.employee_id=e.id where pe.post_id=" + postid);
                repositoryItemImageComboBox2_Edit.Items.Clear();
                while (dr.Read())
                {
                    repositoryItemImageComboBox2_Edit.Items.Add(new ImageComboBoxItem(dr["OperatorName"].ToString(), dr["OperatorID"], 0));
                }
                e.RepositoryItem= repositoryItemImageComboBox2_Edit;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable tbChange = dsGvSource.Tables[0].GetChanges();
            if (tbChange == null)
                return;
            string[] strSqls=new string[tbChange.Rows.Count];
            for (int i = 0; i < tbChange.Rows.Count; i++)
            {
                strSqls[i] = "Update CheckTask Set Operator="+tbChange.Rows[i]["OperatorID"] +" Where taskstate=1 and ID="+tbChange.Rows[i]["ID"];
            }
            int _ret =SqlHelper.ExecuteSqls(strSqls);
            if (_ret != 0)
            {
                MessageBox.Show("保存成功");
            }
            dsGvSource.AcceptChanges();
        }

        private void btnShowToDay_Click(object sender, EventArgs e)
        {
            this.dtpStart.Value = DateTime.Parse((DateTime.Now.ToShortDateString() + " 00:00"));
            this.dtpEnd.Value = DateTime.Parse((DateTime.Now.ToShortDateString() + " 23:59"));
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                dtpStart.Enabled = true;
                dtpEnd.Enabled = true;
                btnShowToDay.Enabled = true;
            }
            else
            {
                dtpStart.Enabled = false;
                dtpEnd.Enabled = false;
                btnShowToDay.Enabled = false;     
            }

            bindCboPlan(dtpStart.Value,dtpEnd.Value);
        }

        bool m_checkStatus = false;
        private void gvPlan_Click(object sender, EventArgs e)
        {
            bool result = false;
            if (gvPlan != null)
            {
                gvPlan.ClearSorting();//禁止排序

                gvPlan.PostEditor();
                DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo info;
                Point pt = gvPlan.GridControl.PointToClient(Control.MousePosition);
                info = gvPlan.CalcHitInfo(pt);
                if (info.InColumn && info.Column != null && info.Column.FieldName == "isChose")
                {
                    for (int i = 0; i < gvPlan.RowCount; i++)
                    {
                        gvPlan.SetRowCellValue(i, "isChose", !m_checkStatus);
                    }
                    result= true;
                }
            }
            if (result)
            {
                m_checkStatus = !m_checkStatus;
            }
        }

        private void gvPlan_CustomDrawColumnHeader(object sender, DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column != null && e.Column.FieldName == "isChose")
            {
                e.Info.InnerElements.Clear();
                e.Painter.DrawObject(e.Info);

                RepositoryItemCheckEdit repositoryCheck = e.Column.ColumnEdit as RepositoryItemCheckEdit;
                if (repositoryCheck != null)
                {
                    Graphics g = e.Graphics;
                    Rectangle r = e.Bounds;

                    DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo info;
                    DevExpress.XtraEditors.Drawing.CheckEditPainter painter;
                    DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs args;
                    info = repositoryCheck.CreateViewInfo() as DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo;

                    painter = repositoryCheck.CreatePainter() as DevExpress.XtraEditors.Drawing.CheckEditPainter;
                    info.EditValue = m_checkStatus;
                    info.Bounds = r;
                    info.CalcViewInfo(g);
                    args = new DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs(info, new DevExpress.Utils.Drawing.GraphicsCache(g), r);
                    painter.Draw(args);
                    args.Cache.Dispose();
                }

                e.Handled = true;
            }
        }


        public static void DrawCheckBox(DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs e, bool chk)
        {
            RepositoryItemCheckEdit repositoryCheck = e.Column.ColumnEdit as RepositoryItemCheckEdit;
            if (repositoryCheck != null)
            {
                Graphics g = e.Graphics;
                Rectangle r = e.Bounds;

                DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo info;
                DevExpress.XtraEditors.Drawing.CheckEditPainter painter;
                DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs args;
                info = repositoryCheck.CreateViewInfo() as DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo;

                painter = repositoryCheck.CreatePainter() as DevExpress.XtraEditors.Drawing.CheckEditPainter;
                info.EditValue = chk;
                info.Bounds = r;
                info.CalcViewInfo(g);
                args = new DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs(info, new DevExpress.Utils.Drawing.GraphicsCache(g), r);
                painter.Draw(args);
                args.Cache.Dispose();
            }
        }

        public static bool ClickGridCheckBox(DevExpress.XtraGrid.Views.Grid.GridView gridView, string fieldName, bool currentStatus)
        {
            bool result = false;
            if (gridView != null)
            {
                gridView.ClearSorting();//禁止排序

                gridView.PostEditor();
                DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo info;
                Point pt = gridView.GridControl.PointToClient(Control.MousePosition);
                info = gridView.CalcHitInfo(pt);
                if (info.InColumn && info.Column != null && info.Column.FieldName == fieldName)
                {
                    for (int i = 0; i < gridView.RowCount; i++)
                    {
                        gridView.SetRowCellValue(i, fieldName, !currentStatus);
                    }
                    return true;
                }
            }
            return result;
        }

        private void btnAllowGet_Click(object sender, EventArgs e)
        {
            string taskids = "";
            for (int i = 0; i < gvPlan.RowCount; i++)
            {
                object isChose = gvPlan.GetRowCellValue(i, "isChose");
                if (isChose != null && (bool)isChose == true)
                {
                    taskids += gvPlan.GetRowCellValue(i, "ID") + ",";
                }
            }
            if (taskids != "")
            {
                taskids = taskids.Substring(0, taskids.Length - 1);
            }
            else
            {
                MessageBox.Show("请选择允许执行的任务");
                return;
            }
            string sql = "update checktask set taskstate=2 where taskstate=1 and id in("+taskids+")";
            if (SqlHelper.ExecuteNonQuery(sql) > 0)
            {
                MessageBox.Show("修改成功");
            }
            else
            {
                MessageBox.Show("出错了。");
            }
            if (checkBox1.Checked)
            {
                getDgvTask(dtpStart.Value, dtpEnd.Value);
            }
            else
            {
                getDgvTask(null,null);
            }
        }


    }
}
