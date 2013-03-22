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
            BindTreeList();
        }
        private void frmAddRoute_Load(object sender, EventArgs e)
        {
            this.dpSearch.Close();
        }

        //获取路线
        private void BindGvRoute()
        {
            if (tlArea.FocusedNode != null)
            {
                string sql = @"Select 'False' as isCheck,ID,Name,Alias,Comment,(select meaning from codes where code=checkroute.validstate and purpose='validstate') as ValidState,
                        (select meaning from codes where code=checkroute.Sequence and purpose='CheckSequence') as Sequence,
                        (select name from area where id=checkroute.area_id and validstate=1) as Site From checkroute where 1=1 ";
                sql += " and Area_ID=" + tlArea.FocusedNode.GetDisplayText("ID") + " order by ID";
                DataSet ds = SqlHelper.ExecuteDataset(sql);
                gridControl1.DataSource = ds == null ? null : ds.Tables[0];
            }
        }

        private void BindTreeList()
        {
            DataSet ds = SqlHelper.ExecuteDataset("Select *,(select meaning from codes where code=Area.ValidState and Purpose='ValidState') as ValidStateMeaning from Area where validstate=" + (Int32)CodesValidState.Exit);
            tlArea.DataSource = ds == null ? null : ds.Tables[0];
        }

        private void BindComboBox()
        {
            DataSet ds = SqlHelper.ExecuteDataset("Select Code,Meaning  From Codes where purpose='ValidState'");
            DataRow dr = ds.Tables[0].NewRow();
            dr["Code"] = -1;
            dr["Meaning"] = "不选择";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            this.cboValidState.DisplayMember = "Meaning";
            this.cboValidState.ValueMember = "Code";
            this.cboValidState.DataSource = ds.Tables[0];
            ds.Dispose();
            cboValidState.SelectedValue = -1;

            ds = SqlHelper.ExecuteDataset("Select Code,Meaning From Codes where purpose='CheckSequence'");
            dr=ds.Tables[0].NewRow();
            dr["Code"] = -1;
            dr["Meaning"] = "不选择";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            this.cboSequence.DisplayMember = "Meaning";
            this.cboSequence.ValueMember = "Code";
            this.cboSequence.DataSource=ds.Tables[0];
            ds.Dispose();
            cboSequence.SelectedValue = -1;
        }

        private void dgvRoute_DoubleClick(object sender, EventArgs e)
        {
            frmRouteNew fn = new frmRouteNew();
            fn.Left = this.Left + (this.Width - fn.Width) / 2;
            fn.Top = this.Top + (this.Height - fn.Height) / 2;
            fn.IsEdit = true;
            fn.RouteID = gvRoute.GetRowCellValue(gvRoute.FocusedRowHandle, "ID");
            fn.ShowDialog();
            BindGvRoute();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = @"Select 'False' as isCheck,ID,Name,Alias,Comment,(select meaning from codes where code=checkroute.validstate and purpose='validstate') as ValidState,
                        (select meaning from codes where code=checkroute.Sequence and purpose='CheckSequence') as Sequence,
                        (select name from area where id=checkroute.area_id and validstate=1) as Site From checkroute where 1=1 ";
            if (tbName != null)
            {
                sql += " and Name Like '%"+tbName.Text+"%'";
            }
            if (!chkAll.Checked)
            {
                if (tlArea.FocusedNode == null) { MessageBox.Show("请选择位置"); return; }
                string selectID = " with parent(ID,Area_ID,Name) as( select ID,Area_ID,Name From Area where id=" + tlArea.FocusedNode.GetDisplayText("ID") + " union all select c.ID,c.Area_ID,c.Name from area c  join  parent p  on c.area_id=p.id  ) select ID from parent";
                SqlDataReader dr = SqlHelper.ExecuteReader(selectID);
                string ids = "";
                while (dr.Read())
                {
                    ids += dr["ID"].ToString() + ",";
                }
                if (ids != "")
                {
                    ids = ids.TrimEnd(new char[] { ',' });
                    sql += " and Area_ID IN(" + ids + ")";
                }
            }
            if (cboSequence.SelectedValue.ToString()!="-1")
            {
                sql += " and Sequence="+cboSequence.SelectedValue;
            }
            if (cboValidState.SelectedValue.ToString() != "-1")
            {
                sql += " and ValidState="+cboValidState.SelectedValue;
            }
            DataSet ds = SqlHelper.ExecuteDataset(sql);
            gridControl1.DataSource = ds == null ? null : ds.Tables[0];
        }

        private void barButtonItem_New_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tlArea.FocusedNode == null) return;
            frmRouteNew fn = new frmRouteNew();
            fn.Left = this.Left + (this.Width - fn.Width) / 2;
            fn.Top = this.Top + (this.Height - fn.Height) / 2;
            fn.IsEdit = false;
            fn.AreaID = tlArea.FocusedNode.GetDisplayText("ID");
            fn.ShowDialog();
            BindGvRoute();
        }

        private void barButtonItem_update_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SendKeys.SendWait("{TAB}"); SendKeys.SendWait("+{TAB}"); //Tab ,Shit+Tab
            if (gvRoute.FocusedRowHandle >= 0)
            {
                frmRouteNew fn = new frmRouteNew();
                fn.Left = this.Left + (this.Width - fn.Width) / 2;
                fn.Top = this.Top + (this.Height - fn.Height) / 2;
                fn.IsEdit = true;
                fn.RouteID = gvRoute.GetRowCellValue(gvRoute.FocusedRowHandle,"ID");
                fn.ShowDialog();
                BindGvRoute();
            }
        }

        private void barButtonItem_delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SendKeys.SendWait("{TAB}"); SendKeys.SendWait("+{TAB}"); //Tab ,Shit+Tab
            string routeid = "";
            for (int i = 0; i < gvRoute.RowCount; i++)
            {
                object isChose = gvRoute.GetRowCellValue(i, "isCheck");
                if (Convert.ToBoolean(isChose) == true)
                {
                    routeid += gvRoute.GetRowCellValue(gvRoute.FocusedRowHandle, "ID") + ",";
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
            BindGvRoute();
        }

        private void dgvRoute_DoubleClick_1(object sender, EventArgs e)
        {
            if (gvRoute.FocusedRowHandle >= 0)
            {
                frmRouteNew fn = new frmRouteNew();
                fn.Left = this.Left + (this.Width - fn.Width) / 2;
                fn.Top = this.Top + (this.Height - fn.Height) / 2;
                fn.IsEdit = true;
                fn.RouteID = gvRoute.GetRowCellValue(gvRoute.FocusedRowHandle, "ID");
                fn.ShowDialog();
                BindGvRoute();
            }
        }

        private void tlArea_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            BindGvRoute();
        }

        private void barButtonItemSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BindComboBox();
            dpSearch.Show();
        }
    }
}
