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
    public partial class frmPostTeamEmployeeAdd : Form
    {
        public frmPostTeamEmployeeAdd()
        {
            InitializeComponent();
        } 
        public object OrganizationID = null;   //该岗位所在的组织
        public object TeamID=null;             //巡检组ID
        private void bindGvEmployee()
        {
            if (OrganizationID == null)
            {
                return;
            }
            string sqlIDs = @"WITH lmenu(name,ID,Organization_ID) as(
   SELECT NAME,ID,Organization_ID FROM  organization WHERE ID="+OrganizationID 
   +"UNION ALL SELECT O.NAME,O.ID,O.organization_ID FROM organization O,lmenu l where O.organization_ID = l.ID)"
         +" SELECT *  from lmenu";
            string orgIDs = "";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(sqlIDs))
            {
                while (dr.Read())
                {
                    orgIDs += dr["ID"].ToString()+",";
                }
            }
            if (orgIDs.Trim() != "")
            {
                string sqlSelect = @"Select *,'False' as IsCheck,
 (Select Name From Organization where ID=Employee.Organization_ID) as OrganizationName,
 (Select Meaning From Codes where Code=Employee.Specialty and Purpose='Specialty') as SpecialtyMeaning,
 (Select Meaning From Codes where Code=Employee.ValidState and Purpose='ValidState') as ValidStateMeaning 
 From Employee where Organization_ID in(" + orgIDs.TrimEnd(',')+")";
                DataSet ds = SqlHelper.ExecuteDataset(sqlSelect);
                this.gridControl1.DataSource=ds.Tables[0];
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SendKeys.SendWait("{TAB}"); SendKeys.SendWait("+{TAB}");
            List<string> insertList = new List<string>();
            for (int i = 0; i < gvEmployee.RowCount; i++)
            {
                object isCheck = gvEmployee.GetRowCellValue(i, "IsCheck");
                if (isCheck != null && Convert.ToBoolean(isCheck) == true)
                {
                    insertList.Add("Insert Into Team_Employee(Team_ID,Employee_ID) Values("+TeamID+","+gvEmployee.GetRowCellValue(i,"ID")+")");
                    
                }
            }
            if (insertList.Count != 0)
            {
                SqlHelper.ExecuteSqls(insertList);
            }
        }

        private void frmPostTeamEmployeeAdd_Load(object sender, EventArgs e)
        {
            bindGvEmployee();
        }
    }
}
