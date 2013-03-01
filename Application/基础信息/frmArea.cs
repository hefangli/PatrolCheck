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
    public partial class frmArea : Form
    {
        public frmArea()
        {
            InitializeComponent();
        }

        private void frmArea_Load(object sender, EventArgs e)
        {
            BindComoboBox();
            BindTlArea();
        }

        private void BindTlArea()
        {
            DataSet ds = SqlHelper.ExecuteDataset("Select *,(select meaning from codes where code=Area.ValidState and Purpose='ValidState') as ValidStateMeaning from Area");
            tlArea.DataSource = ds.Tables[0];
        }

        private void BindComoboBox()
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


        private void btnNew_Click(object sender, EventArgs e)
        {
            if (tbName.Text == "") return;
            string sql = "Insert Into Area(Name,Area_ID,ValidState) Values(@name,@area_id,@validstate)";
            SqlParameter[] pars = new SqlParameter[] { 
                  new SqlParameter("@name",tbName.Text.Trim()),
                  new SqlParameter("@area_id",tbParentAreaName.Tag),
                  new SqlParameter("@validstate",cboValidState.EditValue)
            };
            if (SqlHelper.ExecuteNonQuery(sql, pars) == 1)
            {
                MessageBox.Show("保存成功");
            }
            BindTlArea();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (tbName.Text == "") return;
            string sql = "Update Area Set Name=@name,ValidState=@validstate Where ID=@id";
            SqlParameter[] pars = new SqlParameter[] { 
                  new SqlParameter("@name",tbName.Text.Trim()),
                  new SqlParameter("@area_id",tbParentAreaName.Tag),
                  new SqlParameter("@validstate",cboValidState.EditValue),
                  new SqlParameter("@id",tlArea.FocusedNode.GetDisplayText("ID"))
            };
            if (SqlHelper.ExecuteNonQuery(sql, pars) == 1)
            {
                MessageBox.Show("修改成功");
            }
            BindTlArea();
        }

        private void tlArea_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            this.tbName.Text = e.Node.GetDisplayText("Name");
            if (e.Node.ParentNode != null)
            {
                this.tbParentAreaName.Text = e.Node.GetDisplayText("Name");
                this.tbParentAreaName.Tag = e.Node.GetDisplayText("ID");
            }
            else
            {
                this.tbParentAreaName.Text = "";
                this.tbParentAreaName.Tag = null;
            }
            this.cboValidState.EditValue = Int32.Parse(e.Node.GetDisplayText("ValidState"));
        }

        private void barButtonItemAreaDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tlArea.FocusedNode != null)
            {
                string del = "Delete From Area Where ID=" + tlArea.FocusedNode.GetDisplayText("ID");
                SqlHelper.ExecuteNonQuery(del);
                BindTlArea();
            }
        }
    }
}
