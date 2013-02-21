﻿using System;
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
    public partial class frmItem : Form//WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public frmItem()
        {
            InitializeComponent();
        }

        private void frmAddItem_Load(object sender, EventArgs e)
        {
            BindDgv();
        }

        /// <summary>
        /// 给Dgv控件绑定数据
        /// </summary>
        private void BindDgv()
        {
            string str_select = @"select 
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
            ds.Tables[0].Columns.Add(new DataColumn("isCheck", typeof(System.Boolean)));
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["isCheck"] = false;
            }
            gridControlItems.DataSource = ds.Tables[0];
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            string Del = "";
            string strsql = "Delete From CheckItem Where ID in(";
            for (int i = 0; i < gvItems.RowCount; i++)
            {
                object isCheck = gvItems.GetRowCellValue(i, "isCheck");
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
            ItemNew itemNew = new ItemNew();
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
            ItemNew itemEdit = new ItemNew();
            itemEdit.IsEdit = true;
            itemEdit.ItemID = gvItems.GetRowCellValue(rowindex, "ID").ToString();
            itemEdit.ShowDialog();
            BindDgv();
        }

        //删除巡检项
        private void barButtonItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //btnSearch.Focus();
            string Del = "";
            string strsql = "Delete From CheckPlan Where ID in(";
            for (int i = 0; i < gvItems.RowCount; i++)
            {
                object isCheck = gvItems.GetRowCellValue(i, "isCheck");
                if ((bool)isCheck == true)
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
            ItemNew itemNew = new ItemNew();
            itemNew.IsEdit = true;
            itemNew.ItemID = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "ID").ToString();
            itemNew.ShowDialog();
            BindDgv();
        }


    }
}
