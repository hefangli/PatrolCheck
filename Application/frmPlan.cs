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
using WeifenLuo.WinFormsUI.Docking;

namespace WorkStation
{
    public partial class frmPlan : DockContent
    {
        public frmPlan()
        {
            InitializeComponent();
        }

        private void frmAddPlan_Load(object sender, EventArgs e)
        {         
            this.labState.Visible = false;
            this.labState.Text = "";
            cboInit();
            SetDateTimePicker();
            getDgvPlan();
        }
        private void SetDateTimePicker()
        {
            string day = "30";
            switch(DateTime.Now.Month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    {
                        day = "31";
                        break;
                    }
                default:
                    {
                        day="30";
                        break;
                    }
            }
            this.dtpStart.Value = DateTime.Parse(DateTime.Now.Year.ToString()+"-"+DateTime.Now.Month.ToString()+"-1 00:00");
            this.dtpEnd.Value = DateTime.Parse(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + day + " 23:59");
        }
        private void cboShow_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboShow.SelectedValue == null) return;
            this.labState.Text = cboShow.SelectedValue.ToString() == "-1" ? "1,2,4,6,8,16,32" : cboShow.SelectedValue.ToString();
            switch(this.cboShow.SelectedValue.ToString())
            {
                case "-1":
                case "8"://通过
                case "16"://已下发
                case "32"://丢弃
                    {
                        this.btnNew.Enabled = false;
                        this.btnEdit.Enabled = false;
                        this.btnDel.Enabled = false;
                        this.btnSubmit.Enabled = false;
                        this.btnUnSub.Enabled = false;
                        break;
                    }
                case "1": //新建
                    {
                        this.btnNew.Enabled = true;
                        this.btnEdit.Enabled = true;
                        this.btnDel.Enabled = true;
                        this.btnSubmit.Enabled = true;
                        this.btnUnSub.Enabled = false;
                        break;
                    }
                case "2"://提交 请求审核
                    {
                        this.btnNew.Enabled = false;
                        this.btnEdit.Enabled = false;
                        this.btnDel.Enabled = false;
                        this.btnSubmit.Enabled = false;
                        this.btnUnSub.Enabled = true;
                        break;
                    }
                case "4": //未通过 否决
                    {
                        this.btnNew.Enabled = false;
                        this.btnEdit.Enabled = true;
                        this.btnDel.Enabled = true;
                        this.btnSubmit.Enabled = true;
                        this.btnUnSub.Enabled = false;
                        break;
                    }

            }
            getDgvPlan();
        }      
        private void getDgvPlan()
        {
            string sql = @"Select 
                                                    c.ID,
                                                    c.Name,
                                                    c.Alias,
                                                    c.StartTime,  
                                                    c.Duration,
                                                    c.EndTime,
                                                    p.Name as PostName,
                                                    p.ID as PostID,
                                                    r.Name as RouteName, 
                                                    r.ID as RouteID,
                                                    (select name from employee where id=c.operator) as OperatorName,
                                                    c.operator as OperatorID,
                                                    c.Interval,
                                                    c.TimeDeviation,
                                                    (select meaning from codes where code= IntervalUnit and purpose='intervalunit') as IntervalUnit,
                                                    c.intervalunit as IntervalUnitID,
                                                    c.EffectiveTime,
                                                    c.IneffectiveTime,
                                                    c.Planner,
                                                    (select meaning from codes where code= planstate and purpose='planstate') as PlanState  
                                                     From Checkplan as  c left join CheckRoute  as r on c.route_id=r.id 
                                                              left join Post p on c.post=p.id 
                                                              where ";
            sql += "  ((c.effectivetime<='" + dtpStart.Value + "' and c.ineffectivetime>='" + dtpEnd.Value + "') or (c.effectivetime>'" + dtpStart.Value + "' and c.effectivetime<'" + dtpEnd.Value + "') or (c.ineffectivetime>'" + dtpStart.Value + "' and c.ineffectivetime<'" + dtpEnd.Value + "'))";
            sql += " and c.PlanState in (" + this.labState.Text + ")";
            DataSet ds = SqlHelper.ExecuteDataset(sql);
            ds.Tables[0].Columns.Add(new DataColumn("isCheck",typeof(System.Boolean)));
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["isCheck"] = false;
            }
            this.gridControlPlan.DataSource = ds.Tables[0];
        }

        private void cboInit()
        {
            DataSet ds = SqlHelper.ExecuteDataset("Select Code,Meaning From Codes Where Purpose='PlanState'");
            DataRow dr=ds.Tables[0].NewRow();
            dr[0] = -1;
            dr[1] = "全部";
            ds.Tables[0].Rows.InsertAt(dr,0);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["Code"].ToString() == "0")
                {
                    ds.Tables[0].Rows.RemoveAt(i);
                    break;
                }
            }            
            cboShow.DisplayMember = "Meaning";
            cboShow.ValueMember = "Code";
            cboShow.DataSource=ds.Tables[0];
            cboShow.SelectedIndex = 1;
        }

        //新建
        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmPlanAdd add = new frmPlanAdd();
            add.Left = this.Left + (this.Width - add.Width) / 2;
            add.Top = this.Top + (this.Height - add.Height) / 2;
            add.dgv = this.gridControlPlan;
            add.ShowDialog();
            getDgvPlan();
        }
        //编辑
        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int rowindex = gvPlan.FocusedRowHandle;
            if (rowindex < 0)
            {
                MessageBox.Show("请选择一个要编辑的计划");
                return;
            }
            frmPlanAdd add = new frmPlanAdd();
            add.Left = this.Left + (this.Width - add.Width) / 2;
            add.Top = this.Top + (this.Height - add.Height) / 2;
            add.isEdit = true;
            add.dgv = this.gridControlPlan;
            add.planID = gvPlan.GetRowCellValue(rowindex, "ID").ToString();
            add.ShowDialog();
            getDgvPlan();
        }
        //删除
        private void btnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnSearch.Focus();
            string Del = "";
            string strsql = "Delete From CheckPlan Where ID in(";
            for (int i = 0; i < gvPlan.RowCount; i++)
            {
                object isCheck = gvPlan.GetRowCellValue(i, "isCheck");
                if ((bool)isCheck == true)
                {
                    Del += gvPlan.GetRowCellValue(i, "ID") + ",";
                }
            }
            if (Del != "")
            {
                Del = Del.Substring(0, Del.Length - 1);
                strsql += Del + ") and PlanState in (1,4)";//状态为1和4的可以删除
                SqlHelper.ExecuteNonQuery(strsql);
                getDgvPlan();
            }
            else
            {
                MessageBox.Show("请选择要删除的项。");
            }            
        }
        //请求审核
        private void btnSubmit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnSearch.Focus();
            string update = "";
            string strUpdae = "Update CheckPlan Set PlanState=2 where Id in(";
            for (int i = 0; i < gvPlan.RowCount; i++)
            {
                object isCheck = gvPlan.GetRowCellValue(i, "isCheck");
                if ((bool)isCheck == true)
                {
                    update += gvPlan.GetRowCellValue(i, "ID") + ",";
                }
            }
            if (update != "")
            {
                update = update.Substring(0, update.Length - 1);
                strUpdae += update + ") and PlanState in (1,4)";//状态为1.新建4.否决的可以提交
                SqlHelper.ExecuteNonQuery(strUpdae);
                getDgvPlan();
            }
            else
            {
                MessageBox.Show("请选择要提交的项");
            }
        }
        //撤销提交
        private void btnUnSub_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnSearch.Focus();
            string update = "";
            string strUpdae = "Update CheckPlan Set PlanState=1 where Id in(";
            for (int i = 0; i < gvPlan.RowCount; i++)
            {
                object isCheck = gvPlan.GetRowCellValue(i, "isCheck");
                if ((bool)isCheck == true)
                {
                    update += gvPlan.GetRowCellValue(i, "ID") + ",";
                }
            }
            if (update != "")
            {
                update = update.Substring(0, update.Length - 1);
                strUpdae += update + ") and PlanState=2";
                SqlHelper.ExecuteNonQuery(strUpdae);
                getDgvPlan();
            }
            else
            {
                MessageBox.Show("请选择要撤销提交的项");
            }
        }
        //查询
        private void btnSearch_Click(object sender, EventArgs e)
        {
            getDgvPlan();
        }

        private void gvPlan_DoubleClick(object sender, EventArgs e)
        {
            if (cboShow.SelectedValue != null && (cboShow.SelectedValue.ToString() == "1" || cboShow.SelectedValue.ToString()=="4"))
            {
                frmPlanAdd add = new frmPlanAdd();
                add.Left = this.Left + (this.Width - add.Width) / 2;
                add.Top = this.Top + (this.Height - add.Height) / 2;
                add.isEdit = true;
                add.dgv = this.gridControlPlan;
                add.planID = gvPlan.GetRowCellValue(gvPlan.FocusedRowHandle, "ID").ToString();
                add.ShowDialog();
                getDgvPlan();
            }
        }
    }
}
