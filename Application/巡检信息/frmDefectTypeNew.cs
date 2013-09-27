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
    public partial class frmDefectTypeNew : Form
    {
        public frmDefectTypeNew()
        {
            InitializeComponent();
        }
        public object ParentDefectTypeID = null;
        public object DefectTypeID = null;
        public object ValidState = null;
        public bool IsEdit = false;

        private void DefectTypeDefectNew_Load(object sender, EventArgs e)
        {
            BindCbo();
            this.Text = IsEdit == false ? "添加缺陷类型" : "修改缺陷类型";
            if(IsEdit==true)
            {
                string sqlDefect = "select name,ValidState from defecttype where id=" + ParentDefectTypeID;
                SqlDataReader dr = SqlHelper.ExecuteReader(sqlDefect);
                while (dr.Read())
                {
                    this.txtName.Text=dr["name"].ToString();
                    this.cboValidState.EditValue = dr["ValidState"];
                }
            }
        }

        private void BindCbo()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader("Select Code,Meaning from Codes Where Purpose='ValidState'");
            while (dr.Read())
            {
                cboValidState.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr["Meaning"].ToString(),dr["Code"],-1));
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            string insert = null;
            if (IsEdit == false)
            {
                if (ParentDefectTypeID != null)
                {
                    //待定。。。。。
//                    insert = @"Insert into DefectType(DefectType_ID,Name,ValidState) 
//                        Values(" + ParentDefectTypeID + ",'" + this.txtName.Text.Trim() + "'," + cboValidState.EditValue + ")";
                    insert = @"Insert into DefectType(DefectType_ID,Name,ValidState) 
                        Values(" + DefectTypeID + ",'" + this.txtName.Text.Trim() + "'," + cboValidState.EditValue + ")";
                    MessageBox.Show("保存成功！");
                }
                else
                {
                    insert = @"Insert into DefectType(Name,ValidState) 
                        Values('" + this.txtName.Text.Trim() + "'," + cboValidState.EditValue + ")";
                    MessageBox.Show("保存成功！");
                }
            }
            else
            {
                //待定.....................
                //insert = "Update DefectType Set Name='"+this.txtName.Text.Trim()+"',ValidState="+cboValidState.SelectedItem+" where ID="+DefectTypeID;
                insert = "Update DefectType Set Name='" + this.txtName.Text.Trim() + "',ValidState=" + cboValidState.EditValue + " where ID=" + ParentDefectTypeID;
                MessageBox.Show("修改成功！");
            }

            if (SqlHelper.ExecuteNonQuery(insert).ToString() != "1")
            {
                MessageBox.Show("保存失败，请稍后再试！");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboValidState_SelectedIndexChanged(object sender, EventArgs e)
        {
           //MessageBox.Show(cboValidState.EditValue+";"+cboValidState.SelectedText+";"+cboValidState.SelectedItem);   
        }
    }
}
