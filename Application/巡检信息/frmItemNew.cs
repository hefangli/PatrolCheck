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
    public partial class frmItemNew : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public frmItemNew()
        {
            InitializeComponent();
        }

        private DataSet dsMachine, dsValueType, dsPoint, dsState;   //绑定Combox
        public bool IsEdit = false;                                 //True为新建界面 False为编辑界面  
        public string ItemID = null;                                //巡检项的ID(编辑使用)
        private object defectID=null;                               //缺陷ID

        private void ItemNew_Load(object sender, EventArgs e)
        {
            this.Text = IsEdit == false?"新建巡检项": "编辑巡检项";
            bkwItemNew.RunWorkerAsync();
            if (IsEdit == true)
            {
                if (ItemID != null)
                {
                    SqlDataReader dr = SqlHelper.ExecuteReader("Select *,(select name from defect where id=defect_id) as DefectName From CheckItem Where ID="+ItemID);
                    if (dr.Read())
                    {
                        this.txtName.Text = dr["Name"].ToString();
                        this.txtAlias.Text = dr["Alias"].ToString();
                        this.txtDefault.Text = dr["DefaultValue"].ToString();
                        this.txtRemarks.Text = dr["Comment"].ToString();
                        this.cboMachine.SelectedValue = dr["Machine_ID"];
                        this.cboPoint.SelectedValue = dr["PhysicalCheckPoint_ID"];
                        this.cboValue.SelectedValue=dr["ValueType"];
                        this.cboState.SelectedValue=dr["ValidState"];
                        this.txtDefectName.Text = dr["DefectName"].ToString();
                        this.chkDefect.Checked = Convert.ToBoolean(dr["isDefect"]);
                        defectID = dr["Defect_ID"];
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtRemarks.Text == "")
            {
                MessageBox.Show("请确保没有空值");
                return;
            }
            //if (SqlHelper.ExecuteScalar("Select count(1) From CheckItem Where  Name='" + this.txtName.Text.Trim() + "'").ToString() != "0")
            //{
            //    MessageBox.Show("请确保名称的唯一性");
            //    return;
            //}
            if (txtDefault.Enabled == true)
            {
                try
                {
                    Convert.ToDouble(txtDefault.Text);
                }
                catch
                {
                    txtDefault.Text = null;
                    MessageBox.Show("请输入默认值");
                    return;
                }
            }
            string sqlInsert;
            if (IsEdit)
            {
                sqlInsert = @"Update CheckItem Set Name=@name,alias=@alias,Machine_ID=@machineid,ValueType=@valuetype,
                                 PhysicalCheckPoint_ID=@pointid,Comment=@comment,validstate=@validstate,defaultvalue=@defaultvalue,isDefect=@isdefect,Defect_ID=@defectid Where ID=" + ItemID;;
            }
            else
            {
                sqlInsert = @"Insert into CheckItem([Name],Alias,Machine_ID,ValueType,PhysicalCheckPoint_ID,Comment,validstate,defaultvalue,isdefect,defect_id) 
                                 Values(@name,@alias,@machineid,@valuetype,@pointid,@comment,@validstate,@defaultvalue,@isdefect,@defectid)";
            }
            SqlParameter[] pars = new SqlParameter[]{
                new SqlParameter("@name",SqlDbType.NVarChar),
                new SqlParameter("@alias",SqlDbType.NVarChar),
                new SqlParameter("@machineid",SqlDbType.Int),
                new SqlParameter("@valuetype",SqlDbType.Int),
                new SqlParameter("@pointid",SqlDbType.Int),              
                new SqlParameter("@comment",SqlDbType.NText),
                new SqlParameter("@validstate",SqlDbType.Int),
                new SqlParameter("@defaultvalue",SqlDbType.Int),
                new SqlParameter("@isdefect",SqlDbType.Int),
                new SqlParameter("@defectid",SqlDbType.Int)
            };
            pars[0].Value = this.txtName.Text.ToString().Trim();
            pars[1].Value = this.txtAlias.Text.ToString().Trim();
            pars[2].Value = ((cboMachine.SelectedValue == null || cboMachine.SelectedValue.ToString() == "-1") ? null : cboMachine.SelectedValue);
            pars[3].Value = ((cboValue.SelectedValue == null || cboValue.SelectedValue.ToString() == "-1") ? null : cboValue.SelectedValue);
            pars[4].Value = ((cboPoint.SelectedValue == null || cboPoint.SelectedValue.ToString() == "-1") ? null : cboPoint.SelectedValue);
            pars[5].Value = this.txtRemarks.Text;
            pars[6].Value = cboState.SelectedValue == null ? null : cboState.SelectedValue;
            pars[7].Value = (txtDefault.Text == null || txtDefault.Text == "") ? null : txtDefault.Text;
            pars[8].Value = chkDefect.Checked == true ? 1 : 0;
            pars[9].Value = defectID;

            int _ret = SqlHelper.ExecuteNonQuery(sqlInsert, pars);
            if (_ret == 1)
            {
                MessageBox.Show("保存成功");
                ClearValue();
            }
            else
            {
                MessageBox.Show("保存失败，请稍后再试！");
            }
        }

        private void bkwItemNew_DoWork(object sender, DoWorkEventArgs e)
        {
            dsMachine = SqlHelper.ExecuteDataset("select ID,Name From Machine where validstate=1");
            dsValueType = SqlHelper.ExecuteDataset("Select Code,Meaning From Codes where Purpose='ValueType'");
            dsPoint = SqlHelper.ExecuteDataset("select ID,Name From PhysicalCheckPoint where validstate=1");
            dsState = SqlHelper.ExecuteDataset("Select Code,Meaning From Codes where Purpose='ValidState'");
        }
 
        private void bkwItemNew_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DataRow dr = dsMachine.Tables[0].NewRow();
            dr[0] = "-1"; dr[1] = "不选择";
            dsMachine.Tables[0].Rows.InsertAt(dr, 0);
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
            cboState.DataSource = dsState.Tables[0];
            cboState.SelectedValue = 1;
            dsState.Dispose();
        }
      
        private void ClearValue()
        {
            txtName.Text = "";
            txtAlias.Text = "";
            txtRemarks.Text = "";
            txtDefault.Text = "";
        }

        private void btnDefectSet_Click(object sender, EventArgs e)
        {
            frmItemDefectSet defectset = new frmItemDefectSet();
            defectset.ShowDialog();
            defectID = defectset.DefectID == null ? defectID : defectset.DefectID;
            this.txtDefectName.Text = defectset.DefectName == null ? this.txtDefectName.Text : defectset.DefectName.ToString();
        }

        private void btnDefectClear_Click(object sender, EventArgs e)
        {
            this.txtDefectName.Text = null;
            this.defectID = null;
        }
    }
}
