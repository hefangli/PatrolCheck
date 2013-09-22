namespace WorkStation
{
    partial class frmAreaNew
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOrgChose = new DevExpress.XtraEditors.SimpleButton();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.tbParentAreaName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.tbName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboValidState = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.tbOrganization = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btnAreaClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnOrgClear = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tbParentAreaName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboValidState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbOrganization.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOrgChose
            // 
            this.btnOrgChose.Location = new System.Drawing.Point(347, 66);
            this.btnOrgChose.Name = "btnOrgChose";
            this.btnOrgChose.Size = new System.Drawing.Size(63, 23);
            this.btnOrgChose.TabIndex = 29;
            this.btnOrgChose.Text = "所属组织";
            this.btnOrgChose.Click += new System.EventHandler(this.btnOrgChose_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(111, 210);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 28;
            this.btnNew.Text = "保存";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(61, 154);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(28, 14);
            this.labelControl3.TabIndex = 27;
            this.labelControl3.Text = "状态:";
            // 
            // tbParentAreaName
            // 
            this.tbParentAreaName.Location = new System.Drawing.Point(140, 101);
            this.tbParentAreaName.Name = "tbParentAreaName";
            this.tbParentAreaName.Properties.ReadOnly = true;
            this.tbParentAreaName.Size = new System.Drawing.Size(151, 21);
            this.tbParentAreaName.TabIndex = 26;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(50, 104);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 14);
            this.labelControl2.TabIndex = 25;
            this.labelControl2.Text = "上级地点：";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(140, 34);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(151, 21);
            this.tbName.TabIndex = 24;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(50, 37);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 23;
            this.labelControl1.Text = "地点名称：";
            // 
            // cboValidState
            // 
            this.cboValidState.Location = new System.Drawing.Point(140, 151);
            this.cboValidState.Name = "cboValidState";
            this.cboValidState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboValidState.Size = new System.Drawing.Size(151, 21);
            this.cboValidState.TabIndex = 22;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(255, 210);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 30;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tbOrganization
            // 
            this.tbOrganization.Location = new System.Drawing.Point(140, 68);
            this.tbOrganization.Name = "tbOrganization";
            this.tbOrganization.Properties.ReadOnly = true;
            this.tbOrganization.Size = new System.Drawing.Size(151, 21);
            this.tbOrganization.TabIndex = 31;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(50, 71);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(60, 14);
            this.labelControl4.TabIndex = 32;
            this.labelControl4.Text = "所属组织：";
            // 
            // btnAreaClear
            // 
            this.btnAreaClear.Location = new System.Drawing.Point(297, 99);
            this.btnAreaClear.Name = "btnAreaClear";
            this.btnAreaClear.Size = new System.Drawing.Size(44, 23);
            this.btnAreaClear.TabIndex = 33;
            this.btnAreaClear.Text = "清除";
            this.btnAreaClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnOrgClear
            // 
            this.btnOrgClear.Location = new System.Drawing.Point(297, 66);
            this.btnOrgClear.Name = "btnOrgClear";
            this.btnOrgClear.Size = new System.Drawing.Size(44, 23);
            this.btnOrgClear.TabIndex = 34;
            this.btnOrgClear.Text = "清除";
            this.btnOrgClear.Click += new System.EventHandler(this.btnOrgClear_Click);
            // 
            // frmAreaNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 315);
            this.Controls.Add(this.btnOrgClear);
            this.Controls.Add(this.btnAreaClear);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.tbOrganization);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOrgChose);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.tbParentAreaName);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.cboValidState);
            this.Name = "frmAreaNew";
            this.Text = "编辑地点";
            this.Load += new System.EventHandler(this.frmAreaNew_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbParentAreaName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboValidState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbOrganization.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnOrgChose;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit tbParentAreaName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit tbName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ImageComboBoxEdit cboValidState;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.TextEdit tbOrganization;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton btnAreaClear;
        private DevExpress.XtraEditors.SimpleButton btnOrgClear;
    }
}