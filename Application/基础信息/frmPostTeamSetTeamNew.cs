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
    public partial class frmPostTeamSetTeamNew : Form
    {
        public frmPostTeamSetTeamNew()
        {
            InitializeComponent();
        }

        public Boolean IsEdit = false;
        public object TeamID = null;
        public object PostID = null;

        private void frmPostTeamSetTeamNew_Load(object sender, EventArgs e)
        {
            BindComboBox();
            if (IsEdit)
            {
                using (SqlDataReader dr = SqlHelper.ExecuteReader("Select *,(Select Name From Post where id=Team.Post_ID) as PostName From Team Where ID=" + TeamID))
                {
                    while (dr.Read())
                    {
                        this.tbName.Text = dr["Name"].ToString();
                        this.tbPost.Text = dr["PostName"].ToString();
                        this.tbPost.Tag = dr["Post_ID"];
                        this.cboValidState.EditValue = dr["ValidState"];
                    }
                }
            }
            else
            {
                if (PostID != null)
                {
                    string postName = SqlHelper.ExecuteScalar("Select Name From Post where id="+PostID).ToString();
                    this.tbPost.Text = postName;
                    this.tbPost.Tag = PostID;
                }
                else
                {
                    this.Close();
                }
            }
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql = "Insert Into Team(Name,Post_ID,ValidState) Values(@name,@postid,@validstate)";
            if (IsEdit)
            {
                sql = "Update Team set Name=@name,ValidState=@validstate Where ID=@id";
            }
            SqlParameter[] pars = new SqlParameter[] { 
              new SqlParameter("@id",TeamID),
              new SqlParameter("@name",tbName.Text.Trim()),
              new SqlParameter("@postid",PostID),
              new SqlParameter("@validstate",cboValidState.EditValue)
            };
            int _ret = SqlHelper.ExecuteNonQuery(sql,pars);
            if (_ret != 1)
            {
                MessageBox.Show("保存失败");
            }
            else
            {
                MessageBox.Show("保存成功");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
