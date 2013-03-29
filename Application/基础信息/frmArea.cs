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
    public partial class frmArea : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public frmArea()
        {
            InitializeComponent();
            BindComoboBox();
            BindTlArea();
        }
        bool isEdit = false;
        object id = null;
        object organizationid = null;  //所在组织ID
        private void frmArea_Load(object sender, EventArgs e)
        {

        }

        private void BindTlArea()
        {
            DataSet ds = SqlHelper.ExecuteDataset("Select *,(select meaning from codes where code=Area.ValidState and Purpose='ValidState') as ValidStateMeaning,(Select Name From organization Where ID=Area.Organization_ID) as OrganizatonName   from Area");
            tlArea.DataSource = ds.Tables[0];
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


        private void btnNew_Click(object sender, EventArgs e)
        {
            if (tbName.Text == "") return;
            string sql="";
            if (!isEdit)
            {
                sql = "Insert Into Area(Name,Area_ID,Organization_ID,ValidState) Values(@name,@area_id,@organizationid,@validstate)";
            }
            else
            {
                sql = "Update Area Set Name=@name,ValidState=@validstate,Organization_ID=@organizationid Where ID=@id";
            }
            SqlParameter[] pars = new SqlParameter[] { 
                  new SqlParameter("@name",tbName.Text.Trim()),
                  new SqlParameter("@area_id",tbParentAreaName.Tag),
                  new SqlParameter("@organizationid",organizationid),
                  new SqlParameter("@validstate",cboValidState.EditValue),
                   new SqlParameter("@id",id)
            };
            if (SqlHelper.ExecuteNonQuery(sql, pars) == 1)
            {
                MessageBox.Show("保存成功");
            }
            BindTlArea();
        }

        private void barButtonItemAreaDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tlArea.FocusedNode != null)
            {
                string del = "Delete From Area Where ID=" + tlArea.FocusedNode.GetDisplayText("ID");
                SqlHelper.ExecuteNonQuery(del);
                BindTlArea();
            }
        }

        private void barButtonItemNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tlArea.FocusedNode != null)
            {
                this.tbName.Text = "";
                this.tbParentAreaName.Text = tlArea.FocusedNode.GetDisplayText("Name");
                this.tbParentAreaName.Tag = tlArea.FocusedNode.GetDisplayText("ID");
                id = null;
            }
            isEdit = false;
        }

        private void barButtonItemEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tlArea.FocusedNode != null)
            {
                this.tbName.Text = tlArea.FocusedNode.GetDisplayText("Name");
                if (tlArea.FocusedNode.ParentNode != null)
                {
                    this.tbParentAreaName.Text = tlArea.FocusedNode.ParentNode.GetDisplayText("Name");
                    this.tbParentAreaName.Tag = tlArea.FocusedNode.ParentNode.GetDisplayText("ID");
                }
                else
                {
                    this.tbParentAreaName.Text = null;
                    this.tbParentAreaName.Tag = null;
                }
                this.cboValidState.EditValue = Int32.Parse(tlArea.FocusedNode.GetDisplayText("ValidState"));
                id = tlArea.FocusedNode.GetDisplayText("ID");
            }
            isEdit = true;
        }

        private void btnOrgChose_Click(object sender, EventArgs e)
        {
            frmAreaOrganzationChose orgChose = new frmAreaOrganzationChose();
            orgChose.ShowDialog();
            this.organizationid = orgChose.OrganizationID;
        }
    }
}
