using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;

namespace WorkStation
{
    public partial class frmAreaOrganzationChose : Form
    {
        public frmAreaOrganzationChose()
        {
            InitializeComponent();
            bindTlOrganization();
        }
        TreeListNode node = null;
        public object OrganizationID = null;
        private void bindTlOrganization()
        {
            string sql = @"SELECT *, 
 (SELECT Meaning FROM dbo.Codes WHERE code=dbo.organization.OrgType AND Purpose='OrgType') AS OrgTypeMeaning 
FROM dbo.organization WHERE ValidState="+(Int32)CodesValidState.Exit;
            DataSet ds = SqlHelper.ExecuteDataset(sql);
            tlOrganization.DataSource = ds.Tables[0];
        }

        private void barButtonItemOrgChose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TreeListNode nodeSelect = null;
            foreach (TreeListNode no in tlOrganization.Nodes)
            {
                nodeSelect = TreeVistor(no);
            }
            if (nodeSelect != null)
            {
                OrganizationID = nodeSelect.GetDisplayText("ID");
                this.Close();
            }
            else
            {
                MessageBox.Show("请选择一项");
            }
        }
        private TreeListNode TreeVistor(TreeListNode no)
        {
            TreeListNode selNode = null;
            if (no.Checked)
            {
                selNode = no;
                return selNode;
            }
            foreach (TreeListNode n in no.Nodes)
            {
                selNode=TreeVistor(n);
                if (selNode != null)
                {
                    break;
                }
            }
            return selNode;
        }

        private void tlOrganization_BeforeCheckNode(object sender, DevExpress.XtraTreeList.CheckNodeEventArgs e)
        {
            if (node != null)
            {
                node.Checked = false;
            }
            node = e.Node;
        }
    }
}
