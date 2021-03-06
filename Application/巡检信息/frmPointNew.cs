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
    public partial class frmPointNew : Form
    {
        public frmPointNew()
        {
            InitializeComponent();
        }

        public bool IsEdit = false;                //True为编辑 False为新建
        bool isItemSet = false;                    //是否添加了巡检项 
        public object AreaID = null;               //位置ID-新建使用
        public object CheckPointID = null;         //巡检点ID-编辑使用,新建时添加巡检项时使用
        bool isFirstOpenCardReader = true;         //是否第一次打开读卡器 
        private object oldRfid = null;          //老的RFID

        private void frmCheckPointNew_Load(object sender, EventArgs e)
        {
            this.Text = IsEdit == true ? "编辑巡检点" : "新建巡检点";
            if (IsEdit)
            {
                using (SqlDataReader dr = SqlHelper.ExecuteReader("Select *,(select name from rfid where id=PhysicalCheckPoint.Rfid_id) as RfidName from PhysicalCheckPoint where id=" + CheckPointID))
                {
                    while (dr.Read())
                    {
                        this.txtName.Text = Convert.IsDBNull(dr["Name"]) ? null : dr["Name"].ToString();
                        this.txtRelation.Text = dr["RfidName"].ToString();
                        this.txtRelation.Tag = dr["Rfid_id"];
                        oldRfid = dr["Rfid_id"];
                        this.cboState.SelectedValue = dr["ValidState"];
                        this.txtComment.Text = dr["Comment"].ToString();
                    }
                }
            }
            else
            {
                this.txtRelation.Tag = "";
            }
            BindCombox();
        }

        private void BindCombox()
        {
            DataSet ds = SqlHelper.ExecuteDataset("select code,meaning from codes where purpose='validstate'");
            cboState.DisplayMember = "Meaning";
            cboState.ValueMember = "Code";
            this.cboState.DataSource = ds.Tables[0];
            this.cboState.SelectedValue = 1;
            ds.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == string.Empty)
            {
                MessageBox.Show("请确保没有空值！");
                return;
            }
            //if ((int)SqlHelper.ExecuteScalar("Select Count(1) From PhysicalCheckPoint Where [Name]='" + this.txtName.Text.Trim() + "'") > 0)
            //{
            //    MessageBox.Show("已存在巡检点名称.");
            //    this.txtName.Focus();
            //    return;
            //}
            string str_insert = "";
            if (IsEdit || isItemSet)
            {
                str_insert = @"Update PhysicalCheckPoint Set Name=@name,rfid_id=@rfid_id,validstate=@validstate,comment=@comment Where ID=@id;";
            }
            else
            {
                str_insert = @"Insert into PhysicalCheckPoint (Name,Area_ID,Rfid_id,ValidState,Comment) values(@name,@area_id,@rfid_id,@validstate,@comment);";
            }

            SqlParameter[] pars = new SqlParameter[] { 
                    new SqlParameter("@id",SqlDbType.BigInt),
                    new SqlParameter("@name",SqlDbType.NVarChar),  
                    new SqlParameter("@validstate",SqlDbType.Int),
                    new SqlParameter("@comment",SqlDbType.Text),
                    new SqlParameter("@area_id",SqlDbType.BigInt),
                    new SqlParameter("@rfid_id",SqlDbType.BigInt),
                    new SqlParameter("@oldRfid_id",SqlDbType.BigInt)
            };
            pars[0].Value = CheckPointID;
            pars[1].Value = this.txtName.Text.Trim();
            pars[2].Value = this.cboState.SelectedValue;
            pars[3].Value = this.txtComment.Text;
            pars[4].Value = this.AreaID;

            if (txtRelation.Tag != null && txtRelation.Tag.ToString() != "")
            {
                pars[5].Value = this.txtRelation.Tag;
                str_insert += " Update Rfid Set Used=1 Where ID=@rfid_id;";
            }
            if (IsEdit && oldRfid != null)
            {
                if (txtRelation.Tag.ToString().Trim() != oldRfid.ToString().Trim())
                {
                    pars[6].Value = oldRfid;
                    str_insert += "Update RFid Set Used=0 Where ID=@oldRfid_id;";
                }
            }
            int obj_ret = SqlHelper.ExecuteNonQuery(str_insert, pars);
            if (obj_ret > 0)
            {
                MessageBox.Show("保存成功");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChose_Click(object sender, EventArgs e)
        {
            frmPointChoseRfid f = new frmPointChoseRfid();
            f.SelIndex = 2;
            f.ShowDialog();
            this.txtRelation.Text = f.RFID_Name == null ? this.txtRelation.Text : f.RFID_Name.ToString();
            this.txtRelation.Tag = f.RFID_ID == null ? this.txtRelation.Tag : f.RFID_ID;
            this.btnSave.Enabled = true;
            this.txtRelation.ReadOnly = false;
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            if (isFirstOpenCardReader == true)
            {
                if (YW605Helper.YW605_Init() > 0)
                {
                    YW605Helper.Timer_Start(timer1);
                    isFirstOpenCardReader = false;
                }
            }
            int _ret = YW605Helper.YW605_WriteToTextBox(this.txtRelation);
            if (_ret < 0)
            {
                MessageBox.Show("读卡失败.错误代码:" + _ret);
            }
        }

        private void btnItemNew_Click(object sender, EventArgs e)
        {
            if (IsEdit == false)
            {
                string insert = "Insert Into PhysicalCheckPoint (Area_ID) values(" + AreaID + ");Select @@identity";
                CheckPointID = SqlHelper.ExecuteScalar(insert);
                if (CheckPointID == null)
                {
                    isItemSet = false;
                    MessageBox.Show("失败，请稍后再试！");
                    return;
                }
                isItemSet = true;
            }
            frmPointNewItemNew itemNew = new frmPointNewItemNew();
            itemNew.CheckPointID = this.CheckPointID;
            itemNew.ShowDialog();
        }

        private void frmCheckPointNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            YW605Helper.Timer_Stop(timer1);
        }

        private void btnClearRfid_Click(object sender, EventArgs e)
        {
            this.txtRelation.Text = "";
            this.txtRelation.Tag = "";
        }
    }
}
