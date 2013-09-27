using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraBars.Docking;
namespace WorkStation
{
    public partial class frmUserInfo : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public frmUserInfo()
        {
            InitializeComponent();
        }
        public void Bind()
        {

            string SelectUser = "select 'False' As IsCheck,ID,UserName,Password,(select name from Employee where ID=Employee_ID)as Employee_ID from UserInfo where 1=1";
            if(this.txtName.Text.Trim() !="")
            {                
                SelectUser+=" and username like '%"+txtName.Text +"%'";
            }
            if(this.cboEmployee.SelectedValue!=null)
            {
                SelectUser += " and Employee_ID="+this.cboEmployee.SelectedValue;

            }
            DataSet ds = SqlHelper.ExecuteDataset(SelectUser);
            this.gridControl1.DataSource = ds.Tables[0];

        }

        private void frmUserInfoNew_Load(object sender, EventArgs e)
        {
            Bind();
            BindEmployee();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmUserInfoNew info = new frmUserInfoNew();
            info.IsEdit = false;
            info.ShowDialog();
            Bind();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int rowindex = gvUserInfo.FocusedRowHandle;
            if (rowindex>=0)
            {
               frmUserInfoNew info = new frmUserInfoNew();
               info.IsEdit = true;
               info.UserId = gvUserInfo.GetRowCellDisplayText(rowindex, "ID");
               info.ShowDialog();
               Bind();
            }

        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {          
            SendKeys.SendWait("{TAB}"); SendKeys.SendWait("+{TAB}");
            string Del = "";
            string strsql = "Delete From userinfo where ID in(";
            for (int i = 0; i < gvUserInfo.RowCount; i++)
            {
                object isCheck = gvUserInfo.GetRowCellValue(i, "IsCheck");
                if (Convert.ToBoolean(isCheck) == true)
                {
                    Del += gvUserInfo.GetRowCellValue(i, "ID") + ",";
                }
            }
            if (Del != "")
            {
                if (MessageBox.Show("您确定删除该信息吗？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    strsql = strsql + Del.TrimEnd(',') + ")";
                    SqlHelper.ExecuteNonQuery(strsql);
                    Bind();
                }
            }
            else
            {
                MessageBox.Show("请选择要删除的项。");
            }            

        }

        private void gvUserInfo_DoubleClick(object sender, EventArgs e)
        {
            int rowindex = gvUserInfo.FocusedRowHandle;
            if (rowindex >= 0)
            {
                frmUserInfoNew info = new frmUserInfoNew();
                info.IsEdit = true;
                info.UserId = gvUserInfo.GetRowCellDisplayText(rowindex, "ID");
                info.ShowDialog();
                Bind();
            }

        }

        private void barSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dpSearch.Visibility == DockVisibility.Hidden)
            {
                dpSearch.Show();
            }
            else
            {
                dpSearch.Close();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Bind();
        }
      
        public void BindEmployee()
        {
            string SelectEmployee = "select * from Employee";
            DataSet ds = SqlHelper.ExecuteDataset(SelectEmployee);
            //DataRow dr = ds.Tables[0].NewRow();
            //dr[0] = -1; 
            //dr[1] = "全部";
            //ds.Tables[0].Rows.InsertAt(dr, 0);
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    if (ds.Tables[0].Rows[i]["ID"].ToString() == "0")
            //    {
            //        ds.Tables[0].Rows.RemoveAt(i);
            //        break;
            //    }
            //}                    
            this.cboEmployee.DisplayMember = "Name";
            this.cboEmployee.ValueMember = "ID";
            this.cboEmployee.DataSource = ds.Tables[0];
            this.cboEmployee.SelectedIndex = -1;

        }
      
    }
}
