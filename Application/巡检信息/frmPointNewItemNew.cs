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
    public partial class frmPointNewItemNew : Form
    {
        public frmPointNewItemNew()
        {
            InitializeComponent();
        }
        object defectID = null;            //缺陷ID
        public object CheckPointID = null;   //巡检点的ID
        object checkItemID = null;         //巡检项ID-修改时使用

        private void frmCheckPointNewItemNew_Load(object sender, EventArgs e)
        {
            BindDgv();
            BindComoBox();
        }

        private void BindDgv()
        {
            if (CheckPointID == null) return;
            string str_select = @"select 
                        'False' as isCheck,
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
                        (case c.IsDefect when 1 then '1' when 0 then '0' else '-1' end) as IsDefect,
                        (select name from defect where id=c.Defect_ID) as DefectName,
                        c.Defect_ID 
                        from checkitem c  left join Machine m on c.machine_id=m.id
                                          left join PhysicalCheckPoint p  on c.PhysicalCheckPoint_ID=p.id";
            str_select += " where C.PhysicalCheckPoint_ID=" + CheckPointID;
            DataSet ds = SqlHelper.ExecuteDataset(str_select);
            gridControlItems.DataSource = ds==null?null:ds.Tables[0];
        }

        private void BindComoBox()
        {
            DataSet dsValueType = SqlHelper.ExecuteDataset("Select Code,Meaning From Codes where Purpose='ValueType'");
            DataSet dsState = SqlHelper.ExecuteDataset("Select Code,Meaning From Codes where Purpose='ValidState'");

            //DataRow dr2 = dsValueType.Tables[0].NewRow();
            //dr2[0] = "-1"; dr2[1] = "不选择";
            //dsValueType.Tables[0].Rows.InsertAt(dr2, 0);

            cboValue.ValueMember = "Code";
            cboValue.DisplayMember = "Meaning";
            cboValue.DataSource = dsValueType.Tables[0];
            dsValueType.Dispose();

            cboState.ValueMember = "Code";
            cboState.DisplayMember = "Meaning";
            cboState.DataSource = dsState.Tables[0];
            cboState.SelectedValue = 1;
            dsState.Dispose();
        }

        private void gvItems_Click(object sender, EventArgs e)
        {

        }

        private void btnDefectClear_Click(object sender, EventArgs e)
        {
            this.txtDefectName.Text = null;
            this.defectID = null;
        }

        private void btnDefectSet_Click(object sender, EventArgs e)
        {
            frmItemDefectSet defectset = new frmItemDefectSet();
            defectset.ShowDialog();
            defectID = defectset.DefectID == null ? defectID : defectset.DefectID;
            this.txtDefectName.Text = defectset.DefectName == null ? this.txtDefectName.Text : defectset.DefectName.ToString();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ItemSave(false);
            BindDgv();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ItemSave(true);
            BindDgv();
        }

        private void barButtonItemDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.btnNew.Focus();
            string Del = "";
            string strsql = "Delete From CheckItem Where ID in(";
            for (int i = 0; i < gvItems.RowCount; i++)
            {
                object isCheck = gvItems.GetRowCellValue(i, "isCheck");
                if (Convert.ToBoolean(isCheck) == true)
                {
                    Del += gvItems.GetRowCellValue(i, "ID") + ",";
                }
            }
            if (Del != "")
            {
                if (MessageBox.Show("您确定删除该信息吗？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    Del = Del.Substring(0, Del.Length - 1);
                    strsql += Del + ")";
                    SqlHelper.ExecuteNonQuery(strsql);
                    BindDgv();
                }
            }
            else
            {
                MessageBox.Show("请选择要删除的项。");
            }
        }

        private void ItemSave(bool isEdit)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("请确保没有空值");
                return;
            }
            if (txtDefault.Enabled == true)
            {
                try
                {
                    Convert.ToDouble(txtDefault.Text);
                }
                catch
                {
                    txtDefault.Text = null;
                    MessageBox.Show("请输入默认值");
                    return;
                }
            }
            string sqlInsert;
            if (isEdit)
            {
                if (checkItemID == null) { MessageBox.Show("无法修改"); return; }
                sqlInsert = @"Update CheckItem Set Name=@name,Machine_ID=@machineid,ValueType=@valuetype,                                 PhysicalCheckPoint_ID=@pointid,Comment=@comment,validstate=@validstate,defaultvalue=@defaultvalue,isDefect=@isdefect,Defect_ID=@defectid Where ID=" + checkItemID; ;
            }
            else
            {
                sqlInsert = @"Insert into CheckItem([Name],Machine_ID,ValueType,PhysicalCheckPoint_ID,Comment,validstate,defaultvalue,isdefect,defect_id) 
                                 Values(@name,@machineid,@valuetype,@pointid,@comment,@validstate,@defaultvalue,@isdefect,@defectid)";
            }
            SqlParameter[] pars = new SqlParameter[]{
                new SqlParameter("@name",SqlDbType.NVarChar),
                new SqlParameter("@machineid",SqlDbType.Int),
                new SqlParameter("@valuetype",SqlDbType.Int),
                new SqlParameter("@pointid",SqlDbType.Int),              
                new SqlParameter("@comment",SqlDbType.NText),
                new SqlParameter("@validstate",SqlDbType.Int),
                new SqlParameter("@defaultvalue",SqlDbType.Int),
                new SqlParameter("@isdefect",SqlDbType.Int),
                new SqlParameter("@defectid",SqlDbType.Int)
            };
            pars[0].Value = this.txtName.Text.ToString().Trim();
            pars[1].Value = null;
            pars[2].Value = ((cboValue.SelectedValue == null || cboValue.SelectedValue.ToString() == "-1") ? null : cboValue.SelectedValue);
            pars[3].Value = CheckPointID;
            pars[4].Value = this.txtRemarks.Text;
            pars[5].Value = cboState.SelectedValue == null ? null : cboState.SelectedValue;
            pars[6].Value = (txtDefault.Text == null || txtDefault.Text == "") ? null : txtDefault.Text;
            pars[7].Value = chkDefect.Checked == true ? 1 : 0;
            pars[8].Value = defectID;

            int _ret = SqlHelper.ExecuteNonQuery(sqlInsert, pars);
            if (_ret == 1)
            {
                MessageBox.Show("保存成功");
                ClearValue();
            }
            else
            {
                MessageBox.Show("保存失败，请稍后再试！");
            }
        }

        private void ClearValue()
        {
            txtName.Text = "";
            txtRemarks.Text = "";
            txtDefault.Text = "";
        }

        private void gvItems_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle < 0) return;
            this.txtName.Text = gvItems.GetRowCellValue(e.RowHandle, "Name").ToString();
            this.txtDefault.Text = gvItems.GetRowCellValue(e.RowHandle, "DefaultValue").ToString();
            this.txtDefectName.Text = gvItems.GetRowCellValue(e.RowHandle, "DefectName").ToString();
            this.txtRemarks.Text = gvItems.GetRowCellValue(e.RowHandle, "Comment").ToString();
            this.chkDefect.Checked =  gvItems.GetRowCellValue(e.RowHandle, "IsDefect").ToString()=="1"?true:false;
            this.cboValue.SelectedValue = gvItems.GetRowCellValue(e.RowHandle, "ValueType");
            this.cboState.SelectedValue = gvItems.GetRowCellValue(e.RowHandle, "ValidState");
            this.checkItemID = gvItems.GetRowCellValue(e.RowHandle, "ID");
        }

        private void cboValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboValue.SelectedValue != null)
            {
                this.txtDefault.Enabled = cboValue.SelectedValue.ToString() == "2" ? true : false;
            }
        }

    }
}
