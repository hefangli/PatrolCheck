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
    public partial class frmDefectNew : Form
    {
        public frmDefectNew()
        {
            InitializeComponent();
        }
        public bool IsEdit = false;
        public object ParentDefectTypeID = null;
        public object DefectTypeID = null;
        public object ValidState = null;
        private void frmDefectNew_Load(object sender, EventArgs e)
        {
            DefectTypeBind();
            DefectLevelBind();
            BindViladState();            
            if(IsEdit==true)
            {
                string sqlDefect = "select Name,DefectType_ID,DefectLevel,ValidState from defect where DefectType_ID=" + ParentDefectTypeID;
                SqlDataReader dr = SqlHelper.ExecuteReader(sqlDefect);
                while(dr.Read())
                {
                    this.txtDefectName.Text=dr["name"].ToString();
                    this.cboDefectlev.SelectedValue = dr["DefectLevel"];
                    this.cboDefecttype.SelectedValue = dr["DefectType_ID"];
                    this.cbovalidstate.SelectedValue = dr["ValidState"];
                }
            }

        }
        //绑定缺陷类别：
        private void DefectTypeBind()
        {
            string sqlDefectTypeName = "select DefectType.DefectType_ID,DefectType.Name from Defect,DefectType where Defect.DefectType_ID =DefectType.DefectType_ID";
            //string sqlDefectTypeName = "select DefectType.DefectType_ID,DefectType.Name from DefectType ";
            DataSet ds = SqlHelper.ExecuteDataset(sqlDefectTypeName);
            DataRow dr = ds.Tables[0].NewRow();
            dr[0] = -1;
            dr[1] = "未选择";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            this.cboDefecttype.DataSource = ds.Tables[0];
            this.cboDefecttype.ValueMember = "DefectType_ID";
            this.cboDefecttype.DisplayMember = "Name";           

        }
        //绑定缺陷等级：
        private void DefectLevelBind()
        {
            string sqlDefectTypeLevel = "select code,Meaning from Codes where Purpose='defectlevel'";
            DataSet ds = SqlHelper.ExecuteDataset(sqlDefectTypeLevel);
            DataRow dr = ds.Tables[0].NewRow();
            dr[0] = -1;
            dr[1] = "未选择";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            this.cboDefectlev.DataSource=ds.Tables[0];
            this.cboDefectlev.ValueMember = "code";
            this.cboDefectlev.DisplayMember = "Meaning";            
        }
        //绑定缺陷状态：
        private void BindViladState()
        {
            string sqlValidState = "select code,Meaning from Codes where Purpose='ValidState'";
            DataSet ds = SqlHelper.ExecuteDataset(sqlValidState);
            DataRow dr = ds.Tables[0].NewRow();
            dr[0] = -1;
            dr[1] = "未选择";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            this.cbovalidstate.DataSource=ds.Tables[0];
            this.cbovalidstate.ValueMember = "code";
            this.cbovalidstate.DisplayMember = "Meaning";          
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string sqlInsertDefect;
            if (IsEdit == false)
            {
                sqlInsertDefect = "insert into defect(name,DefectLevel,DefectType_ID,ValidState) values('" + this.txtDefectName.Text + "'," + this.cboDefectlev.SelectedValue + "," + this.cboDefecttype.SelectedValue + "," + this.cbovalidstate.SelectedValue + ")";               
            }
            else
            {
                sqlInsertDefect = "update defect set name='" + this.txtDefectName.Text + "',DefectType_ID=" + this.cboDefecttype.SelectedValue + ",DefectLevel=" + this.cboDefectlev.SelectedValue + ",ValidState=" + this.cbovalidstate.SelectedValue + "where DefectType_ID=" + ParentDefectTypeID;             
                
            }
            if (SqlHelper.ExecuteNonQuery(sqlInsertDefect) > 0)
            {
                MessageBox.Show("保存成功！");
            }
             
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }




    }
}
