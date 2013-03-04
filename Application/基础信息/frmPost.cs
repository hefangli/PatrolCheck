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
    public partial class frmPost : Form
    {
        public frmPost()
        {
            InitializeComponent();
        }

        private void frmPost_Load(object sender, EventArgs e)
        {
            BindGvPost();
            BindComboBox();
        }

        private void BindGvPost()
        {
            string sql = @"Select *,'False' as IsCheck,
                     (Select Meaning From Codes where code=post.validstate and purpose='ValidState') as ValidStateMeaning,
                      (select name from organization where id=post.organization_id) as OrgName From Post";
            DataSet ds = SqlHelper.ExecuteDataset(sql);
            gridControl1.DataSource=ds.Tables[0];
        }

        private void BindComboBox()
        {
            using (SqlDataReader dr = SqlHelper.ExecuteReader("Select Code,Meaning from Codes Where Purpose='ValidState'"))
            {
                cboValidState.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem("全选", -1, -1));
                while (dr.Read())
                {
                    cboValidState.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr["Meaning"].ToString(), dr["Code"], -1));
                }
                cboValidState.EditValue = 1;
            }
        }

        private void barButtonItemNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmPostNew post = new frmPostNew();
            post.IsEdit = false;
            post.ShowDialog();
            BindGvPost();
        }

        private void barButtonItemEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gvPost.FocusedRowHandle >= 0)
            {
                frmPostNew post = new frmPostNew();
                post.IsEdit = true;
                post.PostID = gvPost.GetRowCellValue(gvPost.FocusedRowHandle,"ID");
                post.ShowDialog();
            }
        }

        private void gvPost_DoubleClick(object sender, EventArgs e)
        {
            if (gvPost.FocusedRowHandle >= 0)
            {
                frmPostNew post = new frmPostNew();
                post.IsEdit = true;
                post.PostID = gvPost.GetRowCellValue(gvPost.FocusedRowHandle, "ID");
                post.ShowDialog();
            }
        }

        private void barButtonItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SendKeys.SendWait("{TAB}"); SendKeys.SendWait("+{TAB}"); //Tab ,Shit+Tab
            string Del = "";
            string strsql = "Delete From Post Where ID in(";
            for (int i = 0; i < gvPost.RowCount; i++)
            {
                object isCheck = gvPost.GetRowCellValue(i, "IsCheck");
                if (isCheck != null && Convert.ToBoolean(isCheck) == true)
                {
                    Del += gvPost.GetRowCellValue(i, "ID") + ",";
                }
            }
            if (Del != "")
            {
                Del = Del.Substring(0, Del.Length - 1);
                strsql += Del + ")";
                SqlHelper.ExecuteNonQuery(strsql);
                BindGvPost();
            }
            else
            {
                MessageBox.Show("请选择要删除的项。");
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dpSearch.Visibility == DevExpress.XtraBars.Docking.DockVisibility.Hidden)
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
            string sql = @"Select *,'False' as IsCheck,
                     (Select Meaning From Codes where code=post.validstate and purpose='ValidState') as ValidStateMeaning,
                      (select name from organization where id=post.organization_id) as OrgName From Post where 1=1";
            if (tbName.Text != "")
            {
                sql += " and Name like'%"+tbName.Text.Trim()+"%'";
            }
            if (Convert.ToInt32(cboValidState.EditValue) != (int)CodesValidState.ChoseAll)
            {
                sql += " and validstate="+cboValidState.EditValue;
            }
            DataSet ds = SqlHelper.ExecuteDataset(sql);
            gridControl1.DataSource=ds.Tables[0];
        }

        
    }
}
