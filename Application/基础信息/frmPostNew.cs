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
    public partial class frmPostNew : Form
    {
        public frmPostNew()
        {
            InitializeComponent();
        }
        private bool isEdit = false;
        private object postID = null;
        private bool isShiftsSet = false;
        private object org_id = null;

        //组织机构的id
        public object Org_id
        {
            get { return org_id; }
            set { org_id = value; }
        }
        /// <summary>
        /// 是否添加了班次
        /// </summary>
        public bool IsShiftsSet
        {
            get { return isShiftsSet; }
            set { isShiftsSet = value; }
        }
        /// <summary>
        /// True为编辑
        /// </summary>
        public bool IsEdit
        {
            get { return isEdit; }
            set { isEdit = value; }
        }        
        /// <summary>
        /// 岗位ID
        /// </summary>
        public object PostID
        {
            get { return postID; }
            set { postID = value; }
        }

        private void frmPostNew_Load(object sender, EventArgs e)
        {
            //BindTreeList();
            BindComboBox();
            if (IsEdit)
            {
                using (SqlDataReader dr = SqlHelper.ExecuteReader("Select *,(select name from organization where id=post.organization_id) as OrgName  from Post Where ID="+PostID))
                {
                    while (dr.Read())
                    {
                        this.tbPostName.Text = dr["Name"].ToString();
                        this.tlOrganization.Text = dr["OrgName"].ToString();
                       //this.tlOrganization.Tag = dr["Organization_ID"];
                        this.tlOrganization.Tag = Org_id;
                        this.cboValidState.EditValue = (Int32)dr["ValidState"];
                        if (dr["Organization_ID"] != null)
                        {
                            TreeListNode selNode = null;
                            foreach (TreeListNode node in tlOrganization.Nodes)
                            {
                                selNode=treeVisitor(node,"ID");
                            }
                            if (selNode != null)
                            {
                                tlOrganization.SetFocusedNode(selNode);
                            }
                        }
                    }
                }
            }
        }

        private TreeListNode treeVisitor(TreeListNode node, string orgID)
        {
            TreeListNode findNode=null;
            if (node.GetDisplayText("ID") == orgID)
            {
                return node;
            }
            foreach (TreeListNode no in node.Nodes)
            {
                findNode = treeVisitor(no, orgID);
            }
            return node;
        }

      

        private void BindComboBox()
        {
            using (SqlDataReader dr = SqlHelper.ExecuteReader("Select Code,Meaning from Codes Where Purpose='ValidState'"))
            {
                while (dr.Read())
                {
                    cboValidState.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr["Meaning"].ToString(), dr["Code"], -1));
                }
                cboValidState.EditValue = 1;                
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbPostName.Text == ""&&tbOrganization.Text!="") return;
            string sql = "Insert Into Post(Name,ValidState,Organization_ID) Values(@name,@validstate,@orgid)";
            if (isEdit || IsShiftsSet)
            {
                sql = "Update Post set Name=@name,Organization_ID=@orgid,ValidState=@validstate where id=@id";
            }
            SqlParameter[] pars = new SqlParameter[] { 
              new SqlParameter("@id",postID),
              new SqlParameter("@name",tbPostName.Text),
              new SqlParameter("@validstate",cboValidState.EditValue),
              //new SqlParameter("@orgid",tbOrganization.Tag)
              new SqlParameter("@orgid",Org_id)
            };
            if (SqlHelper.ExecuteNonQuery(sql,pars) == 1)
            {
                MessageBox.Show("保存成功");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlOrganization_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            this.tbOrganization.Text = tlOrganization.FocusedNode.GetDisplayText("Name");
            this.tbOrganization.Tag = tlOrganization.FocusedNode.GetDisplayText("ID");
        }

        private void btnShiftsSet_Click(object sender, EventArgs e)
        {
            if (IsEdit == false&&tlOrganization.FocusedNode!=null)
            {
                string insert = "Insert Into Post (Organization_ID) values(" + tbOrganization.Tag + ");Select @@identity";
                PostID = SqlHelper.ExecuteScalar(insert);
                if (PostID == null)
                {
                    IsShiftsSet = false;
                    MessageBox.Show("失败，请稍后再试！");
                    return;
                }
                IsShiftsSet = true;
            }
            frmPostShiftsSet shiftsSet = new frmPostShiftsSet();
            shiftsSet.ShowDialog();
        }

        private void btnGroupSet_Click(object sender, EventArgs e)
        {
            MessageBox.Show("班组存哪");
        }
       
    }
}
