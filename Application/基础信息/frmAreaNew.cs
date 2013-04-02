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
    public partial class frmAreaNew : Form
    {
        public frmAreaNew()
        {
            InitializeComponent();
        }
        public bool IsEdit = false;   
        public object Area_ID = null;  //父ID
        public object ID = null;
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAreaNew_Load(object sender, EventArgs e)
        {
            BindComoboBox();
            if (IsEdit)
            {

                using (SqlDataReader dr = SqlHelper.ExecuteReader("Select *,(Select A.Name From Area A Where A.ID=Area.Area_ID) as ParentName,(Select Name From Organization Where ID=Area.organization_ID) as OrgName From Area Where ID=" + ID))
                {
                    while (dr.Read())
                    {
                        this.tbName.Text = dr["Name"].ToString();
                        this.tbParentAreaName.Text = dr["ParentName"].ToString();
                        this.tbOrganization.Text = dr["OrgName"].ToString();
                        this.tbOrganization.Tag = dr["organization_ID"];
                        this.cboValidState.EditValue = dr["ValidState"];
                    }
                }
            }
            else
            {
                this.Text = "编辑地点";
                string arename = SqlHelper.ExecuteScalar("Select Name From Area Where ID=" + Area_ID).ToString();
                this.tbParentAreaName.Text = arename;
                this.tbOrganization.Text = "";
                this.tbOrganization.Tag = null;
            }
        }

        private void BindComoboBox()
        {
            using (SqlDataReader dr = SqlHelper.ExecuteReader("Select Code,Meaning from Codes Where Purpose='ValidState'"))
            {
                while (dr.Read())
                {
                    cboValidState.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr["Meaning"].ToString(), dr["Code"], -1));
                }
                cboValidState.EditValue = 1;
            }
        }

        private void btnOrgChose_Click(object sender, EventArgs e)
        {
            frmAreaOrganzationChose orgChose = new frmAreaOrganzationChose();
            orgChose.ShowDialog();
            this.tbOrganization.Text=orgChose.OrganizationName==null?this.tbOrganization.Text:orgChose.OrganizationName.ToString();
            this.tbOrganization.Tag = orgChose.OrganizationID == null ? this.tbOrganization.Tag : orgChose.OrganizationID;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (tbName.Text == "") return;
            string sql = "";
            if (!IsEdit)
            {
                sql = "Insert Into Area(Name,Area_ID,Organization_ID,ValidState) Values(@name,@area_id,@organizationid,@validstate)";
            }
            else
            {
                sql = "Update Area Set Name=@name,ValidState=@validstate,Organization_ID=@organizationid Where ID=@id";
            }
            SqlParameter[] pars = new SqlParameter[] { 
                  new SqlParameter("@name",tbName.Text.Trim()),
                  new SqlParameter("@area_id",Area_ID),
                  new SqlParameter("@organizationid",tbOrganization.Tag),
                  new SqlParameter("@validstate",cboValidState.EditValue),
                   new SqlParameter("@id",ID)
            };
            if (SqlHelper.ExecuteNonQuery(sql, pars) == 1)
            {
                MessageBox.Show("保存成功");
            }
        }
    }
}
