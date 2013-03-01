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
    public partial class frmCraft : Form
    {
        public frmCraft()
        {
            InitializeComponent();
        }

        private void frmCraft_Load(object sender, EventArgs e)
        {
            BindComboBox();
            BindGvCraft();
        }

        private void BindComboBox()
        {
            using (SqlDataReader dr = SqlHelper.ExecuteReader("Select Code,Meaning from Codes Where Purpose='ValidState'"))
            {
                cboSearchValidState.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem("全选", -1, -1));
                while (dr.Read())
                {
                    cboSearchValidState.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr["Meaning"].ToString(), dr["Code"], -1));
                    cboValidState.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr["Meaning"].ToString(), dr["Code"], -1));
                }
                cboValidState.EditValue = (int)CodesValidState.Exit;
                cboSearchValidState.EditValue = (int)CodesValidState.ChoseAll;
            }
        }

        private void BindGvCraft()
        {
            string sql = "select 'False' as IsCheck,*,(Select Meaning From codes where Code=craft.ValidState and purpose='ValidState') as ValidStateMeaning from craft";
            DataSet ds = SqlHelper.ExecuteDataset(sql);
            gridControl1.DataSource=ds.Tables[0];
        }

        private void gvCraft_DoubleClick(object sender, EventArgs e)
        {
            if (dpNew.Visibility==DevExpress.XtraBars.Docking.DockVisibility.Hidden)
            {
                dpNew.Show();
            }
            if (gvCraft.FocusedRowHandle >= 0)
            {
                tbCraftName.Text = gvCraft.GetRowCellDisplayText(gvCraft.FocusedRowHandle, "Name");
                tbCraftName.Tag = gvCraft.GetRowCellDisplayText(gvCraft.FocusedRowHandle, "ID");
                cboValidState.EditValue = Int32.Parse(gvCraft.GetRowCellDisplayText(gvCraft.FocusedRowHandle, "ValidState"));
            }
            btnNew.Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = "select 'False' as IsCheck,*,(Select Meaning From codes where Code=craft.ValidState and purpose='ValidState') as ValidStateMeaning from craft where 1=1";
            if (cboSearchValidState.EditValue != (object)CodesValidState.ChoseAll)
            {
                sql += " and validstate="+cboValidState.EditValue;
            }
            if (tbSearchCraftName.Text != "")
            {
                sql += " and name like'%"+tbSearchCraftName.Text.Trim()+"%'";
            }
            DataSet ds = SqlHelper.ExecuteDataset(sql);
            gridControl1.DataSource = ds.Tables[0];
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if(tbCraftName.Text=="") return;
            string sql = "insert into Craft(Name,ValidState) Values(@name,@validstate)";
            SqlParameter[] pars = new SqlParameter[] {
               new SqlParameter("@name",tbCraftName.Text.Trim()),
               new SqlParameter("@validstate",cboValidState.EditValue)
            };
            if (SqlHelper.ExecuteNonQuery(sql, pars) > 0)
            {
                MessageBox.Show("保存成功");
                BindGvCraft();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (tbCraftName.Text == "") return;
            string sql = "Update Craft set Name=@name,ValidState=@validstate Where ID=@id";
            SqlParameter[] pars = new SqlParameter[] {
               new SqlParameter("@name",tbCraftName.Text.Trim()),
               new SqlParameter("@validstate",cboValidState.EditValue),
               new SqlParameter("@id",tbCraftName.Tag)
            };
            if (SqlHelper.ExecuteNonQuery(sql, pars) > 0)
            {
                MessageBox.Show("保存成功");
                BindGvCraft();
            }
        }

        private void barButtonItemNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dpNew.Show();
            btnEdit.Visible = false;
            btnNew.Visible = true;

            cboValidState.EditValue = (Int32)CodesValidState.Exit;
            tbCraftName.Text = "";
             tbCraftName.Tag = null;
        }

        private void barButtonItemEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        { 
            if (dpNew.Visibility == DevExpress.XtraBars.Docking.DockVisibility.Hidden)
            {
                dpNew.Show();
            }
            if (gvCraft.FocusedRowHandle >= 0)
            {
                tbCraftName.Text = gvCraft.GetRowCellDisplayText(gvCraft.FocusedRowHandle, "Name");
                tbCraftName.Tag = gvCraft.GetRowCellDisplayText(gvCraft.FocusedRowHandle, "ID");
                cboValidState.EditValue = Int32.Parse(gvCraft.GetRowCellDisplayText(gvCraft.FocusedRowHandle, "ValidState"));
                btnEdit.Visible = true;
                btnNew.Visible = false;
            }
        }

        private void barButtonItemDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SendKeys.SendWait("{TAB}"); SendKeys.SendWait("+{TAB}"); //Tab ,Shit+Tab
            string Del = "";
            string strsql = "Delete From Craft Where ID in(";
            for (int i = 0; i < gvCraft.RowCount; i++)
            {
                object isCheck = gvCraft.GetRowCellValue(i, "IsCheck");
                if (isCheck != null && Convert.ToBoolean(isCheck) == true)
                {
                    Del += gvCraft.GetRowCellValue(i, "ID") + ",";
                }
            }
            if (Del != "")
            {
                Del = Del.Substring(0, Del.Length - 1);
                strsql += Del + ")";
                SqlHelper.ExecuteNonQuery(strsql);
                BindGvCraft();
            }
            else
            {
                MessageBox.Show("请选择要删除的项。");
            }
        }

        private void barButtonItemSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dpSearch.Visibility == DevExpress.XtraBars.Docking.DockVisibility.Hidden)
            {
                dpSearch.Show();
            }
        }
    }
}
