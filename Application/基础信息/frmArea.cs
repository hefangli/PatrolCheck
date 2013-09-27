
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
        }
        private void frmArea_Load(object sender, EventArgs e)
        {
            BindTlArea();
        }

        private void BindTlArea()
        {
            DataSet ds = SqlHelper.ExecuteDataset("Select *,(select meaning from codes where code=Area.ValidState and Purpose='ValidState') as ValidStateMeaning,(Select Name From organization Where ID=Area.Organization_ID) as OrganizatonName from Area");
            tlArea.DataSource = ds.Tables[0];
            tlArea.ExpandAll();
        }

        private void barButtonItemAreaDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tlArea.FocusedNode != null)
            {
                string del = "Delete From Area Where ID=" + tlArea.FocusedNode.GetDisplayText("ID");
                if (MessageBox.Show("您确定删除该信息吗？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    SqlHelper.ExecuteNonQuery(del);
                    BindTlArea();
                }
            }
        }

        private void barButtonItemNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmAreaNew areaNew = new frmAreaNew();
            areaNew.IsEdit = false;
            areaNew.ID = null;
            areaNew.Area_ID = tlArea.FocusedNode == null ? null : tlArea.FocusedNode.GetDisplayText("ID");
            areaNew.ShowDialog();
            BindTlArea();
        }

        private void barButtonItemEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tlArea.FocusedNode != null)
            {
                frmAreaNew areaNew = new frmAreaNew();
                areaNew.IsEdit = true;
                areaNew.ID = tlArea.FocusedNode == null ? null : tlArea.FocusedNode.GetDisplayText("ID");
                areaNew.Area_ID = null;
                areaNew.ShowDialog();
                BindTlArea();
            }
        }

    }
}
