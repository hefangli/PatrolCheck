namespace WorkStation
{
    partial class frmDefectNew
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDefectName = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.cboDefectlev = new System.Windows.Forms.ComboBox();
            this.cboDefecttype = new System.Windows.Forms.ComboBox();
            this.cbovalidstate = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(149, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "缺陷名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "缺陷等级：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(149, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "有效状态：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(149, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "缺陷类别：";
            // 
            // txtDefectName
            // 
            this.txtDefectName.Location = new System.Drawing.Point(250, 49);
            this.txtDefectName.Name = "txtDefectName";
            this.txtDefectName.Size = new System.Drawing.Size(210, 21);
            this.txtDefectName.TabIndex = 4;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(179, 262);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 107;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(375, 262);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 108;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cboDefectlev
            // 
            this.cboDefectlev.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDefectlev.FormattingEnabled = true;
            this.cboDefectlev.Items.AddRange(new object[] {
            "选择路线"});
            this.cboDefectlev.Location = new System.Drawing.Point(250, 101);
            this.cboDefectlev.Name = "cboDefectlev";
            this.cboDefectlev.Size = new System.Drawing.Size(210, 20);
            this.cboDefectlev.TabIndex = 114;
            // 
            // cboDefecttype
            // 
            this.cboDefecttype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDefecttype.FormattingEnabled = true;
            this.cboDefecttype.Items.AddRange(new object[] {
            "选择路线"});
            this.cboDefecttype.Location = new System.Drawing.Point(250, 147);
            this.cboDefecttype.Name = "cboDefecttype";
            this.cboDefecttype.Size = new System.Drawing.Size(210, 20);
            this.cboDefecttype.TabIndex = 115;
            // 
            // cbovalidstate
            // 
            this.cbovalidstate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbovalidstate.FormattingEnabled = true;
            this.cbovalidstate.Items.AddRange(new object[] {
            "选择路线"});
            this.cbovalidstate.Location = new System.Drawing.Point(250, 201);
            this.cbovalidstate.Name = "cbovalidstate";
            this.cbovalidstate.Size = new System.Drawing.Size(210, 20);
            this.cbovalidstate.TabIndex = 116;
            // 
            // frmDefectNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 404);
            this.Controls.Add(this.cbovalidstate);
            this.Controls.Add(this.cboDefecttype);
            this.Controls.Add(this.cboDefectlev);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtDefectName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmDefectNew";
            this.Text = "缺陷添加";
            this.Load += new System.EventHandler(this.frmDefectNew_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDefectName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cboDefectlev;
        private System.Windows.Forms.ComboBox cboDefecttype;
        private System.Windows.Forms.ComboBox cbovalidstate;
    }
}