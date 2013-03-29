namespace WorkStation
{
    partial class frmRfidNew
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
            this.components = new System.ComponentModel.Container();
            this.label7 = new System.Windows.Forms.Label();
            this.lblUse = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.tbName = new DevExpress.XtraEditors.TextEdit();
            this.cboPurpose = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.cboValidState = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.btnRead = new DevExpress.XtraEditors.SimpleButton();
            this.tbRfid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tbName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPurpose.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboValidState.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 34;
            this.label7.Text = "有效状态";
            // 
            // lblUse
            // 
            this.lblUse.AutoSize = true;
            this.lblUse.Location = new System.Drawing.Point(35, 131);
            this.lblUse.Name = "lblUse";
            this.lblUse.Size = new System.Drawing.Size(29, 12);
            this.lblUse.TabIndex = 26;
            this.lblUse.Text = "用途";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(35, 45);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(29, 12);
            this.lblName.TabIndex = 24;
            this.lblName.Text = "名称";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(103, 40);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(184, 21);
            this.tbName.TabIndex = 39;
            // 
            // cboPurpose
            // 
            this.cboPurpose.Location = new System.Drawing.Point(103, 122);
            this.cboPurpose.Name = "cboPurpose";
            this.cboPurpose.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPurpose.Size = new System.Drawing.Size(184, 21);
            this.cboPurpose.TabIndex = 40;
            // 
            // cboValidState
            // 
            this.cboValidState.Location = new System.Drawing.Point(103, 161);
            this.cboValidState.Name = "cboValidState";
            this.cboValidState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboValidState.Size = new System.Drawing.Size(184, 21);
            this.cboValidState.TabIndex = 41;
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(311, 82);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(75, 23);
            this.btnRead.TabIndex = 42;
            this.btnRead.Text = "读卡";
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // tbRfid
            // 
            this.tbRfid.Location = new System.Drawing.Point(103, 82);
            this.tbRfid.Name = "tbRfid";
            this.tbRfid.ReadOnly = true;
            this.tbRfid.Size = new System.Drawing.Size(184, 21);
            this.tbRfid.TabIndex = 44;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 45;
            this.label1.Text = "RFID";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(103, 220);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 46;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(212, 220);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 47;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmRfidNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 312);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbRfid);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.cboValidState);
            this.Controls.Add(this.cboPurpose);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblUse);
            this.Controls.Add(this.lblName);
            this.Name = "frmRfidNew";
            this.Text = "新建RFID";
            this.Load += new System.EventHandler(this.frmRfidNew_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPurpose.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboValidState.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblUse;
        private System.Windows.Forms.Label lblName;
        private DevExpress.XtraEditors.TextEdit tbName;
        private DevExpress.XtraEditors.ImageComboBoxEdit cboPurpose;
        private DevExpress.XtraEditors.ImageComboBoxEdit cboValidState;
        private DevExpress.XtraEditors.SimpleButton btnRead;
        private System.Windows.Forms.TextBox tbRfid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnClose;
    }
}