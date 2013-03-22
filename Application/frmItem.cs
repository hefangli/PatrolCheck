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
    public partial class frmItem : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public frmItem()
        {
            InitializeComponent();
           
        }

        private void frmAddItem_Load(object sender, EventArgs e)
        {
            this.labID.Text = "";
            bkwItem.RunWorkerAsync();
            bindDgvItems();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtRemarks.Text == "")
            {
                MessageBox.Show("请确保没有空值");
                return;
            }
            if (SqlHelper.ExecuteScalar("Select count(1) From CheckItem Where Name='" + this.txtName.Text.Trim() + "'").ToString() != "0")
            {
                MessageBox.Show("请确保名称的唯一性");
                return;
            }
            if (txtDefault.Enabled == true)
            {
                try
                {
                    Convert.ToDouble(txtDefault.Text);
                }
                catch
                {
                    MessageBox.Show("请输入默认值");
                    return;
                }
            }
            string str_insert = "Insert into CheckItem([Name],Alias,Comment,validstate"; 
            string str_value="Values(@name,@alias,@comment,@validstate";
            SqlParameter[] pars = new SqlParameter[]{
                new SqlParameter("@name",SqlDbType.NVarChar),
                new SqlParameter("@alias",SqlDbType.NVarChar),
                new SqlParameter("@machineid",SqlDbType.Int),
                new SqlParameter("@valuetype",SqlDbType.Int),
                new SqlParameter("@pointid",SqlDbType.Int),              
                new SqlParameter("@comment",SqlDbType.NText),
                new SqlParameter("@validState",SqlDbType.Int),
                new SqlParameter("@defaultValue",SqlDbType.Int)
            };
            if (cboMachine.SelectedValue!=null&&cboMachine.SelectedValue.ToString() != "-1")
            {               
                str_insert += ",Machine_ID";
                str_value += ",@machineid";
                
            }
            if (cboValue.SelectedValue!=null&&cboValue.SelectedValue.ToString() != "-1")
            {
                str_insert += ",ValueType";
                str_value += ",@valuetype";
            }
            if (cboPoint.SelectedValue!=null&&cboPoint.SelectedValue.ToString() != "-1")
            {
                str_insert += ",Phy_ID";
                str_value += ",@pointid";
            }
            if (txtDefault.Enabled == true)
            {
                str_insert += ",DefaultValue";
                str_value += ",@defaultvalue";
            }
           
            pars[0].Value = this.txtName.Text.ToString().Trim();
            pars[1].Value = this.txtAlias.Text.ToString().Trim();
            pars[2].Value = ((cboMachine.SelectedValue==null||cboMachine.SelectedValue.ToString() == "-1" ) ? null : cboMachine.SelectedValue);
            pars[3].Value = ((cboValue.SelectedValue == null || cboValue.SelectedValue.ToString() == "-1") ? null : cboValue.SelectedValue);
            pars[4].Value = ((cboPoint.SelectedValue ==null||cboPoint.SelectedValue.ToString() == "-1" )? null : cboPoint.SelectedValue);
            pars[5].Value = this.txtRemarks.Text;
            pars[6].Value = cboState.SelectedValue == null ? null : cboState.SelectedValue;
            pars[7].Value = (txtDefault.Text==null||txtDefault.Text=="")?null:txtDefault.Text;

            string sql_insert = str_insert + ") " + str_value + ")";
            int _ret = SqlHelper.ExecuteNonQuery(sql_insert, pars);
            if (_ret == 1)
            {
                MessageBox.Show("保存成功");
                clearValue();
            }
            bindDgvItems();
        }   

        private void bindDgvItems()
        {
            string str_select = @"select 
                        c.ID,
                        c.Name,
                        c.Alias,
                        c.DefaultValue,
                        (select meaning from codes where code= c.ValidState and purpose='ValidState') as ValidStateMeaning,
                        c.ValidState,
                        (select meaning from codes where code=c.valuetype and purpose='valuetype') as ValueTypeMeaning,
                        c.ValueType,
                        m.ID as MachineID,
                        m.name as MachineName,
                        p.ID as PointID,
                        p.name as PointName,
                        c.Comment 
                        from checkitem c  left join Machine m on c.machine_id=m.id
                                          left join PhysicalCheckPoint p  on c.Phy_ID=p.id";
            DataSet ds = SqlHelper.ExecuteDataset(str_select);
            if (ds == null) return;
            ds.Tables[0].Columns.Add(new DataColumn("isCheck",typeof(System.Boolean)));
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["isCheck"] = false;
            }
            gridControlItems.DataSource = ds.Tables[0];
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (labID.Text == "")
            {
                return;
            }
            if (txtName.Text == "" || txtRemarks.Text == "" || cboMachine.SelectedIndex < 0 || cboPoint.SelectedIndex < 0 || cboValue.SelectedIndex < 0)
            {
                MessageBox.Show("请确保没有空值");
                return;
            }
            if (SqlHelper.ExecuteScalar("Select count(1) From CheckItem Where id!=" + labID.Text.Trim() + " and name='" + this.txtName.Text.Trim() + "'").ToString() != "0")
            {
                MessageBox.Show("请确保名称的唯一性" );
                return;
            }
            if (txtDefault.Enabled == true)
            {
                try
                {
                    Convert.ToDouble(txtDefault.Text);
                }
                catch
                {
                    MessageBox.Show("请输入数字");
                    return;
                }
            }
            string str_insert = "Update CheckItem set [Name]=@name,Alias=@alias,Machine_ID=@machineid,ValueType=@valuetype,Phy_ID=@phyid,Comment=@comment,validstate=@validstate,defaultvalue=@defaultvalue where ID=" + labID.Text.Trim();
            SqlParameter[] pars = new SqlParameter[]{
                new SqlParameter("@name",SqlDbType.NVarChar),
                new SqlParameter("@alias",SqlDbType.NVarChar),
                new SqlParameter("@machineid",SqlDbType.Int),
                new SqlParameter("@phyid",SqlDbType.Int),
                new SqlParameter("@valuetype",SqlDbType.Int),
                new SqlParameter("@comment",SqlDbType.NText),
                new SqlParameter("@validstate",SqlDbType.Int),
                new SqlParameter("@defaultvalue",SqlDbType.Int)
            };
            pars[0].Value = this.txtName.Text.ToString().Trim();
            pars[1].Value = this.txtAlias.Text.ToString().Trim();
            pars[2].Value = ((cboMachine.SelectedValue == null || cboMachine.SelectedValue.ToString() == "-1") ? null : cboMachine.SelectedValue);
            pars[3].Value = ((cboPoint.SelectedValue == null || cboPoint.SelectedValue.ToString() == "-1") ? null : cboPoint.SelectedValue);
            pars[4].Value = ((cboValue.SelectedValue == null || cboValue.SelectedValue.ToString() == "-1") ? null : cboValue.SelectedValue);
            pars[5].Value = this.txtRemarks.Text;
            pars[6].Value = ((cboState.SelectedValue == null || cboState.SelectedValue.ToString() == "-1") ? null : cboState.SelectedValue);
            pars[7].Value = (txtDefault.Text == null || txtDefault.Text == "") ? null : txtDefault.Text;

            int _ret = SqlHelper.ExecuteNonQuery(str_insert, pars);
            if (_ret == 1)
            {
                MessageBox.Show("保存成功");
                clearValue();
            }
            bindDgvItems();
        }
        private void btnDel_Click(object sender, EventArgs e)
        {   
            string Del = "";
            string strsql = "Delete From CheckItem Where ID in(";
            for (int i = 0; i < gvItems.RowCount; i++)
            {
                object isCheck = gvItems.GetRowCellValue(i,"isCheck");
                if (isCheck != null && (bool)isCheck == true)
                {
                    Del += gvItems.GetRowCellValue(i, "ID") + ",";
                }
            }
            if (Del != "")
            {
                Del = Del.Substring(0, Del.Length - 1);
                strsql += Del + ")";
                SqlHelper.ExecuteNonQuery(strsql);
                clearValue();
                bindDgvItems();
            }
            else
            {
                MessageBox.Show("请选择要删除的项");
            }
        }

        DataSet dsMachine, dsValueType, dsPoint, dsState;
        private void bkwItem_DoWork(object sender, DoWorkEventArgs e)
        {
            dsMachine = SqlHelper.ExecuteDataset("select ID,Name From Machine where validstate=1");
            dsValueType = SqlHelper.ExecuteDataset("Select Code,Meaning From Codes where Purpose='ValueType'");
            dsPoint = SqlHelper.ExecuteDataset("select ID,Name From PhysicalCheckPoint where validstate=1");
            dsState = SqlHelper.ExecuteDataset("Select Code,Meaning From Codes where Purpose='ValidState'");
        }

        private void bkwItem_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DataRow dr = dsMachine.Tables[0].NewRow();
            dr[0] = "-1"; dr[1] = "不选择";
            dsMachine.Tables[0].Rows.InsertAt(dr,0);
            cboMachine.ValueMember = "ID";
            cboMachine.DisplayMember = "Name";
            cboMachine.DataSource = dsMachine.Tables[0];
            dsMachine.Dispose();

            DataRow dr1 = dsPoint.Tables[0].NewRow();
            dr1[0] = "-1"; dr1[1] = "不选择";
            dsPoint.Tables[0].Rows.InsertAt(dr1, 0);
            cboPoint.ValueMember = "ID";
            cboPoint.DisplayMember = "Name";
            cboPoint.DataSource = dsPoint.Tables[0];
            dsPoint.Dispose();

            DataRow dr2 = dsValueType.Tables[0].NewRow();
            dr2[0] = "-1"; dr2[1] = "不选择";
            dsValueType.Tables[0].Rows.InsertAt(dr2, 0);
            cboValue.ValueMember = "Code";
            cboValue.DisplayMember = "Meaning";
            cboValue.DataSource = dsValueType.Tables[0];
            dsValueType.Dispose();

            cboState.ValueMember = "Code";
            cboState.DisplayMember = "Meaning";
            cboState.DataSource=dsState.Tables[0];
            cboState.SelectedValue = 1;
            dsState.Dispose();
        }

        private void gvItem_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle < 0) return;
            labID.Text = gvItems.GetRowCellValue(e.RowHandle,"ID").ToString();
            txtName.Text = gvItems.GetRowCellValue(e.RowHandle, "Name").ToString();
            txtAlias.Text = gvItems.GetRowCellValue(e.RowHandle, "Alias").ToString();
            cboValue.SelectedValue = gvItems.GetRowCellValue(e.RowHandle, "ValueType").ToString() == "" ? -1 : gvItems.GetRowCellValue(e.RowHandle, "ValueType");
            cboMachine.SelectedValue = gvItems.GetRowCellValue(e.RowHandle, "MachineID").ToString() == "" ? -1 : gvItems.GetRowCellValue(e.RowHandle, "MachineID");
            cboPoint.SelectedValue = gvItems.GetRowCellValue(e.RowHandle, "PointID").ToString() == "" ? -1 : gvItems.GetRowCellValue(e.RowHandle, "PointID");
            cboState.SelectedValue = gvItems.GetRowCellValue(e.RowHandle,"ValidState");
            txtRemarks.Text = gvItems.GetRowCellValue(e.RowHandle, "Comment").ToString();
            txtDefault.Text = gvItems.GetRowCellValue(e.RowHandle, "DefaultValue").ToString();
        }

        private void cboValue_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboValue.SelectedValue!=null && cboValue.SelectedValue.ToString() == "2")
            {
                txtDefault.Enabled = true;
            }
            else 
            {
                txtDefault.Enabled = false;
            }
        }

        private void clearValue()
        {
            txtName.Text = "";
            txtAlias.Text = "";
            txtRemarks.Text = "";
            txtDefault.Text = "";
        }
    }
}
