using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using WeifenLuo.WinFormsUI.Docking;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace WorkStation
{
    public partial class frmRoute : DockContent
    {
        public frmRoute()
        {
            InitializeComponent();
        }
        public bool isInParent = false;
        List<TreeNode> listPhy = new List<TreeNode>();
        List<TreeNode> listLogical = new List<TreeNode>();
        private void frmAddRoute_Load(object sender, EventArgs e)
        {
            isInParent = true;
            Cbo_Init();
            gvRouteInit();      
        }   

        private void 新建路线ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRouteNew rn = new frmRouteNew();
            rn.Left=this.Left+(this.Width-rn.Width)/2;
            rn.Top=this.Top+(this.Height-rn.Height)/2;
            rn.ShowDialog();
            gvRouteInit();
        }

        DataSet ds = null;
        //获取路线
        private void gvRouteInit()
        {
            string sql = @"Select ID,Name,Alias,Comment,(select meaning from codes where code=checkroute.validstate and purpose='validstate') as ValidState,
                        (select meaning from codes where code=checkroute.Sequence and purpose='CheckSequence') as Sequence,
                        (select name from site where id=checkroute.site_id and validstate=1) as Site From checkroute where 1=1 ";
            if (cboSiteArea.SelectedValue != null && cboSiteArea.SelectedValue.ToString() != "-1")
            {
                sql += " and Site_ID=" + cboSiteArea.SelectedValue;
            }
            else if (cboSiteArea.SelectedValue.ToString() == "-1")
            {
                sql += " and Site_ID in (select id from site where validstate=1)";
            }
            if (cboInOrder.SelectedValue != null && cboInOrder.SelectedValue.ToString() != "-1")
            {
                sql += " and sequence=" + cboInOrder.SelectedValue;
            }
            if (cboState.SelectedValue != null && cboState.SelectedValue.ToString() != "-1")
            {
                sql += " and validstate=" + cboState.SelectedValue;
            }
            ds = SqlHelper.ExecuteDataset(sql);
            if (ds == null) return;
            ds.Tables[0].Columns.Add(new DataColumn("isCheck", typeof(System.Boolean)));
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["isCheck"] = false;
            }
            gridControl1.DataSource = ds.Tables[0]; 
        }
      
        private void Cbo_Init()
        {
            DataSet ds = SqlHelper.ExecuteDataset("Select ID,Name From Site where validstate=1");
            DataRow dr = ds.Tables[0].NewRow();
            dr[0] = -1; dr[1] = "全部";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            cboSiteArea.DisplayMember = "Name";
            cboSiteArea.ValueMember = "ID";
            cboSiteArea.DataSource=ds.Tables[0];
            ds.Dispose();

            ds = SqlHelper.ExecuteDataset("Select Code,Meaning  From Codes where purpose='CheckSequence'");
            dr = ds.Tables[0].NewRow();
            dr[0] = -1; dr[1] = "全部";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            cboInOrder.DisplayMember = "Meaning";
            cboInOrder.ValueMember = "Code";
            cboInOrder.DataSource = ds.Tables[0];
            ds.Dispose();

            ds = SqlHelper.ExecuteDataset("Select Code,Meaning  From Codes where purpose='ValidState'");
            dr = ds.Tables[0].NewRow();
            dr[0] = -1; dr[1] = "全部";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            cboState.DisplayMember = "Meaning";
            cboState.ValueMember = "Code";
            cboState.DataSource = ds.Tables[0];
            ds.Dispose();
            cboState.SelectedValue = 1;
        }

        private void dgvRoute_DoubleClick(object sender, EventArgs e)
        {
            frmRouteNew fn = new frmRouteNew();
            fn.Left = this.Left + (this.Width - fn.Width) / 2;
            fn.Top = this.Top + (this.Height - fn.Height) / 2;
            fn.isEdit = true;
            fn.routeID=dgvRoute.GetRowCellValue(dgvRoute.FocusedRowHandle,"ID");
            fn.ShowDialog();
            gvRouteInit();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            gvRouteInit();
        }

        private void barButtonItem_New_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmRouteNew fn = new frmRouteNew();
            fn.ShowDialog();
            gvRouteInit();
        }

        private void barButtonItem_update_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnSearch.Focus();
            frmRouteNew fn = new frmRouteNew();
            fn.Left = this.Left + (this.Width - fn.Width) / 2;
            fn.Top = this.Top + (this.Height - fn.Height) / 2;
            fn.isEdit = true;
            object id = "";
            int id_count = 0;
            for (int i = 0; i < dgvRoute.RowCount; i++)
            {
                object isChose = dgvRoute.GetRowCellValue(i, "isCheck");
                if ((bool)isChose == true)
                {
                    id = dgvRoute.GetRowCellValue(i, "ID");
                    id_count++;
                }
            }
            if (id_count == 1)
            {
                fn.routeID = id;
                fn.ShowDialog();
                gvRouteInit();
            }
            else
            {
                MessageBox.Show("请选择一项要编辑的项");
                return;
            }
        }

        private void barButtonItem_delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnSearch.Focus();
            string routeid = "";
            for (int i = 0; i < dgvRoute.RowCount; i++)
            {
                object isChose = dgvRoute.GetRowCellValue(i, "isCheck");
                if ((bool)isChose == true)
                {
                    routeid += dgvRoute.GetRowCellValue(dgvRoute.FocusedRowHandle, "ID") + ",";
                }
            }
            if (routeid.Length > 1)
            {
                routeid = routeid.Substring(0, routeid.Length - 1);
                string[] strsDel = new string[3];
                strsDel[0] = "Delete From LogicalPoint_Item Where LogicPoint_ID in (Select ID From LogicalCheckPoint Where Route_ID in (" + routeid + "))";
                strsDel[1] = "Delete From LogicalCheckPoint Where Route_ID in (" + routeid + ")";
                strsDel[2] = "Delete From CheckRoute Where ID in(" + routeid + ")";
                try
                {
                    SqlHelper.ExecuteSqls(strsDel);
                }
                catch
                {
                    MessageBox.Show("删除失败。请稍后再试");
                }
            }
            else
            {
                MessageBox.Show("请选择要删除的项");
                return;
            }
            gvRouteInit();
        }

        private void dgvRoute_DoubleClick_1(object sender, EventArgs e)
        {
            if (dgvRoute.FocusedRowHandle >= 0)
            {
                frmRouteNew fn = new frmRouteNew();
                fn.Left = this.Left + (this.Width - fn.Width) / 2;
                fn.Top = this.Top + (this.Height - fn.Height) / 2;
                fn.isEdit = true;
                fn.routeID = dgvRoute.GetRowCellValue(dgvRoute.FocusedRowHandle, "ID");
                fn.ShowDialog();
                gvRouteInit();
            }
        }
    }
}
