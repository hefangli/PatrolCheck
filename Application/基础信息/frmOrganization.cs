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
//            string sql = @" DECLARE @MaxID INT
// SELECT @MaxID=MAX(ID) FROM dbo.organization
// SELECT ID,ID AS OrgID,NULL AS TeamID,organization_ID,Name,
//       (SELECT Meaning FROM dbo.Codes WHERE Code=OrgType AND Purpose='OrgType') AS OrgTypeMeaning,
//       (SELECT Meaning FROM dbo.Codes WHERE Code=ValidState AND Purpose='ValidState') AS ValidStateMeaning 
//       FROM dbo.organization WHERE ValidState=1
// UNION ALL
// SELECT @MaxID+ID,NULL,ID,organization_ID,Name,NULL,
//       (SELECT Meaning FROM dbo.Codes WHERE Code=ValidState AND Purpose='ValidState') AS ValidStateMeaning 
//       FROM dbo.Team WHERE ValidState=1";
            //DataSet ds = SqlHelper.ExecuteDataset(sql);
            tlOrganization.DataSource = ds.Tables[0];
            tlOrganization.ExpandAll();
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

        private void barButtonItemNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmOrganizationNew orgNew = new frmOrganizationNew();
            orgNew.IsEdit = false;
            orgNew.Organzation_ID = tlOrganization.FocusedNode == null ? null : tlOrganization.FocusedNode.GetDisplayText("ID");
            orgNew.ShowDialog();
            BindTreeList();
        }

        private void tlOrganization_BeforeCheckNode(object sender, DevExpress.XtraTreeList.CheckNodeEventArgs e)
        {
           // MessageBox.Show("123");
        }
    }
}
