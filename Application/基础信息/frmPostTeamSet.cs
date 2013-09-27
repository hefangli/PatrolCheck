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
using DevExpress.XtraBars.Docking;

namespace WorkStation
{
    public partial class frmPostTeamSet : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public frmPostTeamSet()
        {
            InitializeComponent();
            using (SqlDataReader dr = SqlHelper.ExecuteReader("Select * From Codes where purpose='ValidState'"))
            {
                while (dr.Read())
                {
                    repositoryItemImageComboBox1.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr["Meaning"].ToString(), dr["Code"], 0));
                }
            }
            BindComboBox();
            bindTlPost();
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

        private void bindTlPost()
        {
            string sql = @"DECLARE @maxid INT 
SELECT @maxid=MAX(ID) FROM dbo.Post
SELECT ID,ID AS PostID,NULL AS TeamID,Name,Organization_ID,ValidState,
  (Select Name From Organization where id=Post.Organization_ID) as OrganizationName 
FROM dbo.Post WHERE ValidState=1
UNION ALL
SELECT ID+@maxid,Post_ID,ID,Name,Null,ValidState,null FROM dbo.Teasm";
            DataSet ds = SqlHelper.ExecuteDataset(sql);
            this.tlPost.DataSource=ds.Tables[0];
        }

        private void bindGvEmployee()
        {
            string sql = @"SELECT 'False' as IsCheck,te.Team_ID,te.Employee_ID,e.Name as EmployeeName,
 (SELECT NAME FROM dbo.Team WHERE ID=te.Team_ID) AS TeamName,
 (Select Name FROM Post Where id=t.Post_ID) as PostName,
(SELECT Meaning FROM dbo.Codes WHERE code=e.Specialty AND Purpose='Specialty') AS SpecialtyMeaning,
(SELECT Meaning FROM dbo.Codes WHERE code=e.ValidState AND Purpose='ValidState') AS  ValidStateMeaning
FROM Team_Employee te LEFT JOIN dbo.Employee e ON te.Employee_ID=e.ID LEFT JOIN Team t On te.Team_ID=t.ID Where 1=1 ";
            string[] ids = new string[2] {"", ""};
            if (!chkAll.Checked&&tlPost.FocusedNode!=null)
            {
                ids = treeVisitor(tlPost.FocusedNode);
            }
            if (ids[0].Trim() != "")
            {
                sql += " and te.Team_ID in ("+ids[0].TrimEnd(',')+")";
            }
            if (ids[1].Trim() != "")
            {
                sql += " and t.Post_ID in(" + ids[1].TrimEnd(',') + ")";
            }
            if (tbName.Text.Trim() != "")
            {
                sql += " and e.Name Like'%"+tbName.Text.Trim()+"%'";
            }
            if (Convert.ToInt32(cboValidState.EditValue) != (Int32)CodesValidState.ChoseAll)
            {
                sql += " and e.ValidState="+cboValidState.EditValue;
            }
            DataSet ds = SqlHelper.ExecuteDataset(sql);
            this.gridControl1.DataSource=ds.Tables[0];
        }

        private string[] treeVisitor(TreeListNode areaNode)
        {
            string[] strs = new string[2] {"","" };
            if (areaNode.GetDisplayText("TeamID") != "")
            {
                strs[0] += areaNode.GetDisplayText("TeamID") + ",";  
            }
            if (areaNode.GetDisplayText("PostID") != "")
            {
                strs[1] += areaNode.GetDisplayText("PostID") + ",";
            }
            foreach (TreeListNode n in areaNode.Nodes)
            {
                string[] _ret= treeVisitor(n);
                strs[0]+=_ret[0];
                strs[1] += _ret[1];
            }
            return strs;
        }

        private void dpSearch_Click(object sender, EventArgs e)
        {
            if (dpSearch.Visibility == DockVisibility.Hidden)
            {
                dpSearch.Show();
            }
            else
            {
                dpSearch.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bindGvEmployee();
        }

        private void tlPost_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            bindGvEmployee();
        }

        //添加组
        private void barButtonItemTeamNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tlPost.FocusedNode != null)
            {
                frmPostTeamSetTeamNew postNew = new frmPostTeamSetTeamNew();
                postNew.IsEdit = false;
                if (tlPost.FocusedNode.GetDisplayText("TeamID") == "")
                {
                    postNew.PostID = tlPost.FocusedNode.GetDisplayText("PostID");
                }
                else if (tlPost.FocusedNode.GetDisplayText("TeamID")!="")
                {
                    if (tlPost.FocusedNode.ParentNode == null)
                    {
                        return;
                    }
                    postNew.PostID = tlPost.FocusedNode.ParentNode.GetDisplayText("PostID");
                }
                postNew.ShowDialog();
                bindTlPost();
            }
        }

        //编辑组
        private void barButtonItemTeamEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tlPost.FocusedNode != null && tlPost.FocusedNode.GetDisplayText("TeamID")!="")
            {
                frmPostTeamSetTeamNew postNew = new frmPostTeamSetTeamNew();
                postNew.IsEdit = true;
                postNew.TeamID = tlPost.FocusedNode.GetDisplayText("TeamID");
                postNew.ShowDialog();
                bindTlPost();
            }
        }

        private void tlPost_DoubleClick(object sender, EventArgs e)
        {
            if (tlPost.FocusedNode != null && tlPost.FocusedNode.GetDisplayText("TeamID") != "")
            {
                frmPostTeamSetTeamNew postNew = new frmPostTeamSetTeamNew();
                postNew.IsEdit = true;
                postNew.TeamID = tlPost.FocusedNode.GetDisplayText("TeamID");
                postNew.ShowDialog();
                bindTlPost();
            }
        }
        //添加人员
        private void barButtonItemEmployeeAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tlPost.FocusedNode != null && tlPost.FocusedNode.GetDisplayText("TeamID") != "")
            {
                frmPostTeamEmployeeAdd emAdd = new frmPostTeamEmployeeAdd();
                emAdd.TeamID = tlPost.FocusedNode.GetDisplayText("TeamID");
                emAdd.OrganizationID = tlPost.FocusedNode.ParentNode.GetDisplayText("Organization_ID");
                emAdd.ShowDialog();
                bindGvEmployee();
            }
        }

        private void barButtonItemTeamDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tlPost.FocusedNode != null && tlPost.FocusedNode.GetDisplayText("TeamID") != "")
            {
                List<string> listStr = new List<string>();
                listStr.Add("Delete From Team Where ID="+tlPost.FocusedNode.GetDisplayText("TeamID"));
                if (MessageBox.Show("您确定删除该信息吗？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    SqlHelper.ExecuteSqls(listStr);
                    bindTlPost();
                }
            }
        }

        private void barButtonItemEmployeeDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SendKeys.SendWait("{TAB}"); SendKeys.SendWait("+{TAB}");
            List<string> listStrs = new List<string>();
            for (int i = 0; i < gvEmployee.RowCount; i++)
            {
                object isCheck = gvEmployee.GetRowCellValue(i, "IsCheck");
                if (isCheck != null && Convert.ToBoolean(isCheck) == true)
                {
                    listStrs.Add("Delete From Team_Employee Where Team_ID="+gvEmployee.GetRowCellValue(i,"Team_ID")+" and Employee_ID="+gvEmployee.GetRowCellValue(i,"Employee_ID"));
                }
            }
            if (listStrs.Count != 0)
            {
                if (MessageBox.Show("您确定删除该信息吗？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    SqlHelper.ExecuteSqls(listStrs);
                    bindGvEmployee();
                }
            }
        }

        private void frmPostTeamSet_Load(object sender, EventArgs e)
        {

        }
    }
}
