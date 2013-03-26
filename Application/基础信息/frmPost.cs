using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraTreeList.Nodes;

namespace WorkStation
{
    public partial class frmPost : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public frmPost()
        {
            InitializeComponent();
            using (SqlDataReader dr = SqlHelper.ExecuteReader("select * from codes where purpose='ValidState'"))
            {
                while (dr.Read())
                {
                    repositoryItemImageComboBox1.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr["Meaning"].ToString(), dr["Code"], 0));
                }
            }
            using (SqlDataReader dr = SqlHelper.ExecuteReader("select * from codes where purpose='Specialty'"))
            {
                while (dr.Read())
                {
                    repositoryItemImageComboBox2.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr["Meaning"].ToString(), dr["Code"], 0));
                }
            }
            BindComboBox();
            BindTreeList();
        }

        bool isEdit = true;   //是否启用编辑

        private void frmPost_Load(object sender, EventArgs e)
        {            
            this.dpSearch.Close();  
        }

        private void BindTreeList()
        {
            string sql = @"SELECT *,(SELECT Meaning FROM dbo.Codes WHERE Code=dbo.organization.OrgType AND Purpose='Orgtype') AS OrgTypeMeaning 
FROM dbo.organization  WHERE ValidState="+(Int32)CodesValidState.Exit;
            DataSet ds = SqlHelper.ExecuteDataset(sql);
            tlOrganization.DataSource = ds.Tables[0];
        }

        private void BindGvPost()
        {
            string sqlPost = @"Select *,'False' as IsCheck,
                      (select name from organization where id=post.organization_id) as OrgName From Post where 1=1 ";
            string ids = "";
            if (!chkAll.Checked)
            {
                if (tlOrganization.FocusedNode != null)
                {
                    ids += treeVisitor(tlOrganization.FocusedNode);
                }
            }
            if (ids.Trim() != "")
            {
                sqlPost += " and Organization_ID In("+ids.TrimEnd(',')+")";
            }
            if (tbName.Text != "")
            {
                sqlPost += " and Name like'%" + tbName.Text.Trim() + "%'";
            }
            if (Convert.ToInt32(cboValidState.EditValue) != (int)CodesValidState.ChoseAll)
            {
                sqlPost += " and validstate=" + cboValidState.EditValue;
            }
            DataSet ds = SqlHelper.ExecuteDataset(sqlPost);
            gridControl1.DataSource = ds.Tables[0];
        }

        private string treeVisitor(TreeListNode areaNode)
        {
            string orgIDs = "";
            orgIDs += areaNode.GetDisplayText("ID") + ",";
            foreach (TreeListNode n in areaNode.Nodes)
            {
                orgIDs += treeVisitor(n);
            }
            return orgIDs;
        }

        private void BindComboBox()
        {
            using (SqlDataReader dr = SqlHelper.ExecuteReader("Select Code,Meaning from Codes Where Purpose='ValidState'"))
            {
                cboValidState.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem("全选", -1, -1));
                while (dr.Read())
                {
                    cboValidState.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr["Meaning"].ToString(), dr["Code"], -1));
                }
                cboValidState.EditValue = (Int32)CodesValidState.Exit;
            }
        }

        private void barButtonItemNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tlOrganization.FocusedNode != null)
            {
                string sqlInsert = "Insert Into Post(Organization_ID,Name,ValidState) values(" + tlOrganization.FocusedNode.GetDisplayText("ID") + ",'新建岗位',1)";
                SqlHelper.ExecuteNonQuery(sqlInsert);
                BindGvPost();
            }
        }
       
        private void barButtonItemEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (isEdit)
            {
                barButtonItemEdit.Caption = "取消修改";
                isEdit = false;
                this.gridColumnName.OptionsColumn.AllowEdit = true;
                this.gridColumnValidState.OptionsColumn.AllowEdit = true;
                this.gridColumnSpecialty.OptionsColumn.AllowEdit = true;
            }
            else
            {
                barButtonItemEdit.Caption = "修改";
                isEdit = true;
                this.gridColumnName.OptionsColumn.AllowEdit = false;
                this.gridColumnValidState.OptionsColumn.AllowEdit = false;
                this.gridColumnSpecialty.OptionsColumn.AllowEdit = false;
            }
        }

        private void barButtonItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SendKeys.SendWait("{TAB}"); SendKeys.SendWait("+{TAB}"); //Tab ,Shit+Tab
            string Del = "";
            string strsql = "Delete From Post Where ID in(";
            for (int i = 0; i < gvPost.RowCount; i++)
            {
                object isCheck = gvPost.GetRowCellValue(i, "IsCheck");
                if (isCheck != null && Convert.ToBoolean(isCheck) == true)
                {
                    Del += gvPost.GetRowCellValue(i, "ID") + ",";
                }
            }
            if (Del != "")
            {
                Del = Del.Substring(0, Del.Length - 1);
                strsql += Del + ")";
                SqlHelper.ExecuteNonQuery(strsql);
                BindGvPost();
            }
            else
            {
                MessageBox.Show("请选择要删除的项。");
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindGvPost();
        }

        private void gvPost_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName != "IsCheck")
            {
                int rowIndex = gvPost.FocusedRowHandle;
                string sql = "Update Post Set Name=@name,ValidState=@validstate,Specialty=@specialty where id=" + gvPost.GetRowCellValue(rowIndex, "ID");
                SqlParameter[] pars = new SqlParameter[] {
                new SqlParameter("@name",gvPost.GetRowCellValue(rowIndex,"Name")),
                new SqlParameter("@validstate",gvPost.GetRowCellValue(rowIndex,"ValidState")),
                new SqlParameter("@specialty",gvPost.GetRowCellValue(rowIndex,"Specialty"))
            };
                if (SqlHelper.ExecuteNonQuery(sql, pars) != 1)
                {
                    MessageBox.Show("修改失败，请稍后再试");
                }
                BindGvPost();
            }
        }

        private void tlOrganization_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            BindGvPost();
        }


    }
}
