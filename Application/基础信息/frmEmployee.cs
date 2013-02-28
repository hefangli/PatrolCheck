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
    public partial class frmEmployee : Form
    {
        public frmEmployee()
        {
            InitializeComponent();
            BindTreeList();
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {

        }

        private void BindTreeList()
        {
            DataSet ds = SqlHelper.ExecuteDataset(@"Select *,(select meaning from codes where code=Organization.OrgType and Purpose='OrgType') as OrgTypeMeaning,
                             (select meaning from codes where code=Organization.ValidState and Purpose='ValidState') as ValidStateMeaning
                              from Organization Where ValidState=1");
            tlOrganization.DataSource = ds.Tables[0];
        }

        private void BindGvEmployee()
        {
            if (tlOrganization.FocusedNode == null) return;
            string sql = @"select 'False' as IsCheck,ID,Name,(select name from Craft where ID=employee.Craft_ID) as CraftName,
                        (Select Name from Organization where id=Employee.Organization_ID) as OrganizationName,
                        (select Name From Rfid where id=Employee.Rfid_id) as RfidName,
                        (Select Meaning from Codes where code=Employee.validstate and  purpose='ValidState') as ValidStateMeaning
                         from employee Where Organization_ID=" + tlOrganization.FocusedNode.GetDisplayText("ID");
            DataSet ds = SqlHelper.ExecuteDataset(sql);
            this.gridControl1.DataSource = ds == null ? null : ds.Tables[0];
        }

        private void BindComboBox()
        {
            using (SqlDataReader dr = SqlHelper.ExecuteReader("Select Code,Meaning from Codes Where Purpose='ValidState'"))
            {
                cboValidState.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem("全部", -1, -1));
                while (dr.Read())
                {
                    cboValidState.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr["Meaning"].ToString(), dr["Code"], -1));
                }
                cboValidState.EditValue = -1;
            }

            using (SqlDataReader dr = SqlHelper.ExecuteReader("select * from craft where validstate=1"))
            {
                while (dr.Read())
                {
                    cboCraft.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr["Meaning"].ToString(), dr["Code"], -1));
                }
                cboCraft.SelectedIndex = 0;
            }
        }

        private void barButtonItemEmployeeNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tlOrganization.FocusedNode != null)
            {
                frmEmployeeNew emNew = new frmEmployeeNew();
                emNew.IsEdit = false;
                emNew.OrgID = tlOrganization.FocusedNode.GetDisplayText("ID");
                emNew.ShowDialog();
                BindGvEmployee();
            }
        }

        private void barButtonItemEmployeeEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tlOrganization.FocusedNode != null && gvEmployee.FocusedRowHandle >= 0)
            {
                frmEmployeeNew emNew = new frmEmployeeNew();
                emNew.EmployeeID = gvEmployee.GetRowCellValue(gvEmployee.FocusedRowHandle, "ID");
                emNew.IsEdit = true;
                emNew.OrgID = tlOrganization.FocusedNode.GetDisplayText("ID");
                emNew.ShowDialog();
                BindGvEmployee();
            }
        }

        private void barButtonItemEmployeeDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SendKeys.SendWait("{TAB}"); SendKeys.SendWait("+{TAB}"); //Tab ,Shit+Tab
            string Del = "";
            string strsql = "Delete From Employee Where ID in(";
            for (int i = 0; i < gvEmployee.RowCount; i++)
            {
                object isCheck = gvEmployee.GetRowCellValue(i, "IsCheck");
                if (isCheck != null && Convert.ToBoolean(isCheck) == true)
                {
                    Del += gvEmployee.GetRowCellValue(i, "ID") + ",";
                }
            }
            if (Del != "")
            {
                Del = Del.Substring(0, Del.Length - 1);
                strsql += Del + ")";
                SqlHelper.ExecuteNonQuery(strsql);
                BindGvEmployee();
            }
            else
            {
                MessageBox.Show("请选择要删除的项。");
            }
        }

        private void tlOrganization_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            BindGvEmployee();
        }

        private void barButtonItemSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.dpSearch.Show();
            BindComboBox();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = @"select 'False' as IsCheck,ID,Name,(select name from Craft where ID=employee.Craft_ID) as CraftName,
                        (Select Name from Organization where id=Employee.Organization_ID) as OrganizationName,
                        (select Name From Rfid where id=Employee.Rfid_id) as RfidName,
                        (Select Meaning from Codes where Code=employee.ValidState and purpose='ValidState') as ValidStateMeaning
                         from employee  where 1=1 ";
            if (tbName.Text != "")
            {
                sql += " and Name like '%"+tbName.Text.Trim()+"%' ";
            }
            if (cboCraft.EditValue != null)
            {
                sql += " and Craft_ID="+cboCraft.EditValue;
            }
            if (cboValidState.EditValue.ToString() != "-1")
            {
                sql += " and ValidState=" + cboValidState.EditValue;
            }
            if (tbRFID.Text != "")
            {
                sql += " and Rfid_ID in (Select ID From Rfid where name like '%" + tbRFID.Name + "%')";
            }
            if (!chkAll.Checked)
            {
                if (tlOrganization.FocusedNode == null) { MessageBox.Show("请选择位置"); return; }
                string selectID = " with parent(ID,Organization_ID,Name) as( select ID,Organization_ID,Name From Organization where id=" + tlOrganization.FocusedNode.GetDisplayText("ID") + " union all select o.ID,o.Organization_ID,o.Name from Organization o  join  parent p  on o.organization_id=p.id  ) select ID from parent";
                SqlDataReader dr = SqlHelper.ExecuteReader(selectID);
                string ids = "";
                while (dr.Read())
                {
                    ids += dr["ID"].ToString() + ",";
                }
                if (ids != "")
                {
                    ids = ids.TrimEnd(new char[] { ',' });
                    sql += " and Organization_ID IN(" + ids + ")";
                }
            }
            DataSet ds = SqlHelper.ExecuteDataset(sql);
            gridControl1.DataSource = ds == null ? null : ds.Tables[0];
        }

        private void gvEmployee_DoubleClick(object sender, EventArgs e)
        {
            if (tlOrganization.FocusedNode != null && gvEmployee.FocusedRowHandle>=0)
            {
                frmEmployeeNew emNew = new frmEmployeeNew();
                emNew.EmployeeID = gvEmployee.GetRowCellValue(gvEmployee.FocusedRowHandle,"ID");
                emNew.IsEdit = true;
                emNew.OrgID = tlOrganization.FocusedNode.GetDisplayText("ID");
                emNew.ShowDialog();
                BindGvEmployee();
            }
        }
    }
}
