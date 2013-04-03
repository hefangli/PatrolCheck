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
    public partial class frmItem : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public frmItem()
        {
            InitializeComponent();
        }

        private void frmAddItem_Load(object sender, EventArgs e)
        {  
            BindComobox();
            BindDgv();
        }

        private void BindComobox()
        {
            using (SqlDataReader dr = SqlHelper.ExecuteReader("Select * From Codes where purpose='ValidState'"))
            {
                cboValidState.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem("全部",-1,-1));
                while (dr.Read())
                {
                    cboValidState.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr["Meaning"].ToString(), dr["Code"], -1));
                }
            }
        }
        /// <summary>
        /// 给Dgv控件绑定数据
        /// </summary>
        private void BindDgv()
        {
            string str_select = @"select 'False' as IsCheck,
                        c.ID,
                        c.Name,
                        c.Alias,
                        c.DefaultValue,
                        (select meaning from codes where code= c.ValidState and purpose='ValidState') as ValidStateMeaning,
                        c.ValidState,
                        (select meaning from codes where code=c.valuetype and purpose='valuetype') as ValueTypeMeaning,
                        c.ValueType,
                        c.Machine_ID,
                        m.name as MachineName,
                        c.PhysicalCheckPoint_ID,
                        p.name as PointName,
                        c.Comment,
                        (case c.isDefect when 1 then '是' when 0 then '否' else '未设定' end) as IsDefect,
                        (select name from defect where id=c.Defect_ID) as DefectName,
                        c.Defect_ID 
                        from checkitem c  left join Machine m on c.machine_id=m.id
                                          left join PhysicalCheckPoint p  on c.PhysicalCheckPoint_ID=p.id";
            DataSet ds = SqlHelper.ExecuteDataset(str_select);
            if (ds == null) return;
            gridControlItems.DataSource = ds.Tables[0];
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            string Del = "";
            string strsql = "Delete From CheckItem Where ID in(";
            for (int i = 0; i < gvItems.RowCount; i++)
            {
                object isCheck = gvItems.GetRowCellValue(i, "IsCheck");
                if (isCheck != null && (bool)isCheck == true)
                {
                    Del += gvItems.GetRowCellValue(i, "ID") + ",";
                }
            }
            if (Del != "")
            {
                Del = Del.Substring(0, Del.Length - 1);
                strsql += Del + ")";
                SqlHelper.ExecuteNonQuery(strsql);
                BindDgv();
            }
            else
            {
                MessageBox.Show("请选择要删除的项");
            }
        }

        //新建巡检项
        private void barButtonItemNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmItemNew itemNew = new frmItemNew();
            itemNew.IsEdit = false;
            itemNew.ShowDialog();
            BindDgv();
        }

        //修改巡检项
        private void barButtonItemUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int rowindex = gvItems.FocusedRowHandle;
            if (rowindex < 0)
            {
                MessageBox.Show("请选择一个要编辑的计划");
                return;
            }
            frmItemNew itemEdit = new frmItemNew();
            itemEdit.IsEdit = true;
            itemEdit.ItemID = gvItems.GetRowCellValue(rowindex, "ID").ToString();
            itemEdit.ShowDialog();
            BindDgv();
        }

        //删除巡检项
        private void barButtonItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SendKeys.SendWait("{TAB}"); SendKeys.SendWait("+{TAB}"); //Tab ,Shit+Tab
            string Del = "";
            string strsql = "Delete From CheckItem Where ID in(";
            for (int i = 0; i < gvItems.RowCount; i++)
            {
                object isCheck = gvItems.GetRowCellValue(i, "IsCheck");
                if (Convert.ToBoolean(isCheck) == true)
                {
                    Del += gvItems.GetRowCellValue(i, "ID") + ",";
                }
            }
            if (Del != "")
            {
                Del = Del.Substring(0, Del.Length - 1);
                strsql += Del + ")";
                SqlHelper.ExecuteNonQuery(strsql);
                BindDgv();
            }
            else
            {
                MessageBox.Show("请选择要删除的项。");
            }
        }

        private void gvItems_DoubleClick(object sender, EventArgs e)
        {
            frmItemNew itemNew = new frmItemNew();
            itemNew.IsEdit = true;
            itemNew.ItemID = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "ID").ToString();
            itemNew.ShowDialog();
            BindDgv();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindDgv();
        }

        private void barButtonItemSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dpSearch.Visibility == DevExpress.XtraBars.Docking.DockVisibility.Hidden)
            {
                dpSearch.Show();
            }
            else
            {
                dpSearch.Close();
            }
        }

    }
}
