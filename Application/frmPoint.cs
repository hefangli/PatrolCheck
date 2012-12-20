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
    public partial class frmPoint : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public frmPoint()
        {
            InitializeComponent();
        }

        private void frmAddPoint_Load(object sender, EventArgs e)
        {
            this.labID.Text = "";
            getDgvPoint();
            getCboSite();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //注释掉 方便调试 
            if (txtName.Text == string.Empty || txtRelation.Text == string.Empty)
            {
                MessageBox.Show("请确保没有空值！");
                return;
            }
            if ((int)SqlHelper.ExecuteScalar("Select Count(1) From PhysicalCheckPoint Where [Name]='" + this.txtName.Text.Trim() + "'") > 0)
            {
                MessageBox.Show("已存在巡检点名称.");
                this.txtName.Focus();
                return;
            }
            SqlParameter[] pars = new SqlParameter[] { 
                    new SqlParameter("@name",SqlDbType.NVarChar),
                    new SqlParameter("@alias",SqlDbType.NVarChar),
                    new SqlParameter("@siteid",SqlDbType.BigInt),
                    new SqlParameter("@rfid_id",SqlDbType.BigInt),
                    new SqlParameter("@validstate",SqlDbType.Int)
            };
            pars[0].Value = this.txtName.Text.Trim();
            pars[1].Value = this.txtAlias.Text.Trim();
            pars[2].Value = this.cboSite.SelectedValue;
            pars[4].Value = this.cboState.SelectedValue;

            if ((int)SqlHelper.ExecuteScalar("Select Count(1) From Rfid Where Purpose=2 and validstate=1 and ID='" + this.txtRelation.Tag + "'") == 1)
            {
                pars[3].Value = this.txtRelation.Tag;
            }
            else
            {
                MessageBox.Show("请确保存在此标签卡");
                return;
            }
            string str_insert = "Insert Into PhysicalCheckPoint([Name],Alias,Site_ID,rfid_id,validstate) values(@name,@alias,@siteid,@rfid_id,@validstate)";

            Object obj_ret = SqlHelper.ExecuteNonQuery(str_insert,pars);
            if (obj_ret.ToString() == "1")
            {
                MessageBox.Show("保存成功");
            }
            getDgvPoint();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            MessageBox.Show("为实现此功能");
        }

        private void getDgvPoint()
        {
            DataSet ds = SqlHelper.ExecuteDataset("Select P.ID ,P.Name ,P.Alias,R.Name as RName,R.RFID,R.ID as RID,S.Name as SiteName,s.ID as SiteID,(select meaning from codes where code=P.validstate and purpose='ValidState') as ValidStateMeaning,P.ValidState as ValidState  from PhysicalCheckPoint as P left  join  Rfid as R on P.Rfid_ID=R.ID Left Join Site S on P.Site_ID=S.ID");
            if (ds == null) return; 
            ds.Tables[0].Columns.Add(new DataColumn("isCheck",typeof(System.Boolean)));
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["isCheck"] = false;
            }
            gridControlPoint.DataSource = ds.Tables[0];
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (labID.Text == "")
                return;
            if (txtName.Text == string.Empty || txtRelation.Text == string.Empty)
            {
                MessageBox.Show("请确保没有空值！");
                return;
            }
            if ((int)SqlHelper.ExecuteScalar("Select Count(1) From PhysicalCheckPoint Where ID!="+labID.Text.Trim()+" and [Name]='" + this.txtName.Text.Trim() + "'") > 0)
            {
                MessageBox.Show("已存在巡检点名称.");
                this.txtName.Focus();
                return;
            }
            SqlParameter[] pars = new SqlParameter[] { 
                    new SqlParameter("@name",SqlDbType.NVarChar),
                    new SqlParameter("@alias",SqlDbType.NVarChar),
                    new SqlParameter("@rfid_id",SqlDbType.BigInt),
                    new SqlParameter("@siteid",SqlDbType.BigInt),
                    new SqlParameter("@validstate",SqlDbType.BigInt)
            };
            pars[0].Value = this.txtName.Text.Trim();
            pars[1].Value = this.txtAlias.Text.Trim();
            pars[3].Value = this.cboSite.SelectedValue;
            pars[4].Value = this.cboState.SelectedValue;

            if ((int)SqlHelper.ExecuteScalar("Select Count(1) From Rfid Where validstate=1 and Purpose=2 and ID='" + this.txtRelation.Tag+ "'") == 1)
            {
                pars[2].Value = this.txtRelation.Tag;
            }
            else
            {
                MessageBox.Show("请确保有此标签卡");
                return;
            }

            string str_insert = "Update PhysicalCheckPoint set [Name]=@name,Alias=@alias,Rfid_Id=@rfid_id,Site_ID=@siteid,validstate=@validstate where ID=" + labID.Text.Trim();

            Object obj_ret = SqlHelper.ExecuteNonQuery(str_insert,pars);
            if (obj_ret.ToString() == "1")
            {
                MessageBox.Show("修改成功");
            }
            getDgvPoint();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            string Del = "";
            string strsql = "Delete From PhysicalCheckPoint Where ID in(";
            for (int i = 0; i < gvPoint.RowCount; i++)
            {
                object isCheck = gvPoint.GetRowCellValue(i,"isCheck");
                if (isCheck != null && (bool)isCheck == true)
                {
                    Del += gvPoint.GetRowCellValue(i,"ID")+",";
                }
            }
            if (Del != "")
            {
                Del = Del.Substring(0, Del.Length - 1);
                strsql += Del + ")";
                SqlHelper.ExecuteNonQuery(strsql);
                getDgvPoint();
            }
            else
            {
                MessageBox.Show("请选择要删除的项。");
            }            
        }

        private void txtRelation_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.txtRelation.ReadOnly = false;
        }

        private void getCboSite()
        {
            DataSet dsSite;
            if ((int)SqlHelper.ExecuteScalar("select count(1) From company") == 1)
            {
                string companyid = SqlHelper.ExecuteScalar("Select ID from company").ToString();
                dsSite=SqlHelper.ExecuteDataset("select ID,Name From Site Where Company_ID="+companyid);
            }
            else
            {
                dsSite = SqlHelper.ExecuteDataset("select ID,Name From Site");
            }
            cboSite.DataSource=dsSite.Tables[0];
            cboSite.DisplayMember = "Name";
            cboSite.ValueMember = "ID";
            this.cboSite.SelectedIndex = cboSite.Items.Count > 0 ? 0 : -1;
            dsSite.Dispose();

            DataSet dsState = SqlHelper.ExecuteDataset("select code,meaning from codes where purpose='validstate'");
            cboState.DisplayMember = "Meaning";
            cboState.ValueMember = "Code";
            this.cboState.DataSource=dsState.Tables[0];
            this.cboState.SelectedValue = 1;
            dsState.Dispose();

        }

        private void gvPoint_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle < 0) return;
            labID.Text = gvPoint.GetRowCellValue(e.RowHandle, "ID").ToString();
            txtName.Text = gvPoint.GetRowCellValue(e.RowHandle, "Name").ToString();
            txtAlias.Text = gvPoint.GetRowCellValue(e.RowHandle, "Alias").ToString();
            txtRelation.Text = gvPoint.GetRowCellValue(e.RowHandle, "RName").ToString();
            txtRelation.Tag = gvPoint.GetRowCellValue(e.RowHandle, "RID");
            cboSite.SelectedValue = gvPoint.GetRowCellValue(e.RowHandle, "SiteID");
            cboState.SelectedValue = gvPoint.GetRowCellValue(e.RowHandle, "ValidState");
        }

        private void btnChose_Click(object sender, EventArgs e)
        {
            frmPointChoseRfid f = new frmPointChoseRfid();
            f.ShowDialog();
            this.txtRelation.Text = f.RFID_Name == null ? null : f.RFID_Name.ToString();
            this.txtRelation.Tag = f.RFID_ID;
            this.btnSave.Enabled = true;
            this.txtRelation.ReadOnly = false;
        }

     
       
    }
}
