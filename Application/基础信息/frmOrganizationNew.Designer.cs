namespace WorkStation
{
    partial class frmOrganizationNew
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
            this.cboValidState = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.tbName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cboOrgType = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btnChoseArea = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cboValidState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboOrgType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cboValidState
            // 
            this.cboValidState.Location = new System.Drawing.Point(116, 152);
            this.cboValidState.Name = "cboValidState";
            this.cboValidState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboValidState.Size = new System.Drawing.Size(151, 21);
            this.cboValidState.TabIndex = 12;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(195, 219);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(83, 219);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 10;
            this.btnNew.Text = "保存";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(116, 28);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(151, 21);
            this.tbName.TabIndex = 9;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(61, 159);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "状态：";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(37, 31);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "部门名称：";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(37, 70);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 14);
            this.labelControl3.TabIndex = 13;
            this.labelControl3.Text = "组织类别：";
            // 
            // cboOrgType
            // 
            this.cboOrgType.Location = new System.Drawing.Point(116, 67);
            this.cboOrgType.Name = "cboOrgType";
            this.cboOrgType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboOrgType.Size = new System.Drawing.Size(151, 21);
            this.cboOrgType.TabIndex = 14;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(37, 111);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(60, 14);
            this.labelControl4.TabIndex = 15;
            this.labelControl4.Text = "所管区域：";
            // 
            // btnChoseArea
            // 
            this.btnChoseArea.Location = new System.Drawing.Point(116, 107);
            this.btnChoseArea.Name = "btnChoseArea";
            this.btnChoseArea.Size = new System.Drawing.Size(75, 23);
            this.btnChoseArea.TabIndex = 16;
            this.btnChoseArea.Text = "选择";
            this.btnChoseArea.Click += new System.EventHandler(this.btnChoseArea_Click);
            // 
            // frmOrganizationNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 309);
            this.Controls.Add(this.btnChoseArea);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.cboOrgType);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.cboValidState);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "frmOrganizationNew";
            this.Text = "新建部门";
            this.Load += new System.EventHandler(this.frmOrganizationNew_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboValidState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboOrgType.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ImageComboBoxEdit cboValidState;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private DevExpress.XtraEditors.TextEdit tbName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ImageComboBoxEdit cboOrgType;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton btnChoseArea;

    }
}