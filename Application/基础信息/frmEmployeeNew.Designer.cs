namespace WorkStation
{
    partial class frmEmployeeNew
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbName = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.cboValidState = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.lblRelated = new System.Windows.Forms.Label();
            this.txtRelation = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnChose = new DevExpress.XtraEditors.SimpleButton();
            this.btnRead = new DevExpress.XtraEditors.SimpleButton();
            this.cboCraft = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.btnClearRfid = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tbName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboValidState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCraft.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "人员名称";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(102, 24);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(154, 21);
            this.tbName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "工种";
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(75, 200);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 11;
            this.btnNew.Text = "保存";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // cboValidState
            // 
            this.cboValidState.Location = new System.Drawing.Point(102, 143);
            this.cboValidState.Name = "cboValidState";
            this.cboValidState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboValidState.Size = new System.Drawing.Size(154, 21);
            this.cboValidState.TabIndex = 14;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(56, 146);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 13;
            this.labelControl2.Text = "状态：";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(202, 200);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblRelated
            // 
            this.lblRelated.AutoSize = true;
            this.lblRelated.Location = new System.Drawing.Point(30, 105);
            this.lblRelated.Name = "lblRelated";
            this.lblRelated.Size = new System.Drawing.Size(65, 12);
            this.lblRelated.TabIndex = 18;
            this.lblRelated.Text = "关联标签卡";
            // 
            // txtRelation
            // 
            this.txtRelation.Location = new System.Drawing.Point(102, 102);
            this.txtRelation.Name = "txtRelation";
            this.txtRelation.ReadOnly = true;
            this.txtRelation.Size = new System.Drawing.Size(154, 21);
            this.txtRelation.TabIndex = 19;
            // 
            // btnChose
            // 
            this.btnChose.Location = new System.Drawing.Point(324, 102);
            this.btnChose.Name = "btnChose";
            this.btnChose.Size = new System.Drawing.Size(47, 23);
            this.btnChose.TabIndex = 22;
            this.btnChose.Text = "选择";
            this.btnChose.Click += new System.EventHandler(this.btnChose_Click);
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(377, 102);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(47, 23);
            this.btnRead.TabIndex = 23;
            this.btnRead.Text = "读取";
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // cboCraft
            // 
            this.cboCraft.Location = new System.Drawing.Point(102, 64);
            this.cboCraft.Name = "cboCraft";
            this.cboCraft.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCraft.Size = new System.Drawing.Size(154, 21);
            this.cboCraft.TabIndex = 24;
            // 
            // btnClearRfid
            // 
            this.btnClearRfid.Location = new System.Drawing.Point(271, 102);
            this.btnClearRfid.Name = "btnClearRfid";
            this.btnClearRfid.Size = new System.Drawing.Size(47, 23);
            this.btnClearRfid.TabIndex = 25;
            this.btnClearRfid.Text = "清除";
            this.btnClearRfid.Click += new System.EventHandler(this.btnClearRfid_Click);
            // 
            // frmEmployeeNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 318);
            this.Controls.Add(this.btnClearRfid);
            this.Controls.Add(this.cboCraft);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.btnChose);
            this.Controls.Add(this.lblRelated);
            this.Controls.Add(this.txtRelation);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cboValidState);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label1);
            this.Name = "frmEmployeeNew";
            this.Text = "添加人员";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEmployeeNew_FormClosing);
            this.Load += new System.EventHandler(this.frmEmployeeNew_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboValidState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCraft.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit tbName;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private DevExpress.XtraEditors.ImageComboBoxEdit cboValidState;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private System.Windows.Forms.Label lblRelated;
        private System.Windows.Forms.TextBox txtRelation;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.SimpleButton btnChose;
        private DevExpress.XtraEditors.SimpleButton btnRead;
        private DevExpress.XtraEditors.ImageComboBoxEdit cboCraft;
        private DevExpress.XtraEditors.SimpleButton btnClearRfid;
    }
}