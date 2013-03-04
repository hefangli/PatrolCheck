using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WorkStation
{
    public partial class frmOrganization : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public frmOrganization()
        {
            InitializeComponent();
            BindTreeList();
        }

        private void frmOrganization_Load(object sender, EventArgs e)
        {

        }

        private void BindTreeList()
        {
            DataSet ds = SqlHelper.ExecuteDataset("Select *,(select meaning from codes where code=Organization.OrgType and Purpose='OrgType') as OrgTypeMeaning,(select meaning from codes where code=Organization.ValidState and Purpose='ValidState') as ValidStateMeaning from Organization");
            tlOrganization.DataSource = ds.Tables[0];
        }

        private void barButtonItemOrganizationNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmOrganizationNew orgNew = new frmOrganizationNew();
            orgNew.IsEdit = false;
            orgNew.Organzation_ID = tlOrganization.FocusedNode == null ? null : tlOrganization.FocusedNode.GetDisplayText("ID");
            orgNew.ShowDialog();
            BindTreeList();
        }

        private void barButtonItemEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tlOrganization.FocusedNode != null)
            {
                frmOrganizationNew orgEdit = new frmOrganizationNew();
                orgEdit.IsEdit = true;
                orgEdit.OrgID = tlOrganization.FocusedNode.GetDisplayText("ID");
                orgEdit.ShowDialog();
                BindTreeList();
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tlOrganization.FocusedNode != null)
            {
                string del = "delete from Organization where id=" + tlOrganization.FocusedNode.GetDisplayText("ID");
                SqlHelper.ExecuteNonQuery(del);
                BindTreeList();
            }
        }
    }
}
