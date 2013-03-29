namespace WorkStation
{
    partial class frmCheckPlanNew
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
            this.tbDuration = new DevExpress.XtraEditors.TextEdit();
            this.tbInterval = new DevExpress.XtraEditors.TextEdit();
            this.tbTimeDeviation = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCycle = new System.Windows.Forms.Label();
            this.lblPost = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblshixiao = new System.Windows.Forms.Label();
            this.lblshengxiao = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblRount = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.tbName = new DevExpress.XtraEditors.TextEdit();
            this.tbPost = new DevExpress.XtraEditors.TextEdit();
            this.dtStartTime = new DevExpress.XtraEditors.DateEdit();
            this.dtEndTime = new DevExpress.XtraEditors.DateEdit();
            this.dtpEffect = new DevExpress.XtraEditors.DateEdit();
            this.dtpIneffect = new DevExpress.XtraEditors.DateEdit();
            this.cboUnit = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.cboPlanType = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboValidState = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.cboCheckRoute = new DevExpress.XtraEditors.ImageComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDuration.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbInterval.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTimeDeviation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPost.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartTime.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEndTime.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEffect.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEffect.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpIneffect.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpIneffect.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlanType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboValidState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCheckRoute.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tbDuration
            // 
            this.tbDuration.Location = new System.Drawing.Point(139, 181);
            this.tbDuration.Name = "tbDuration";
            this.tbDuration.Properties.LookAndFeel.SkinName = "Blue";
            this.tbDuration.Properties.Mask.EditMask = "f0";
            this.tbDuration.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbDuration.Size = new System.Drawing.Size(52, 21);
            this.tbDuration.TabIndex = 96;
            this.tbDuration.EditValueChanged += new System.EventHandler(this.txtDuration_EditValueChanged);
            // 
            // tbInterval
            // 
            this.tbInterval.Location = new System.Drawing.Point(139, 331);
            this.tbInterval.Name = "tbInterval";
            this.tbInterval.Properties.Mask.EditMask = "f0";
            this.tbInterval.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbInterval.Size = new System.Drawing.Size(52, 21);
            this.tbInterval.TabIndex = 95;
            // 
            // tbTimeDeviation
            // 
            this.tbTimeDeviation.Location = new System.Drawing.Point(139, 235);
            this.tbTimeDeviation.Name = "tbTimeDeviation";
            this.tbTimeDeviation.Properties.LookAndFeel.SkinName = "Blue";
            this.tbTimeDeviation.Properties.Mask.EditMask = "f0";
            this.tbTimeDeviation.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbTimeDeviation.Size = new System.Drawing.Size(52, 21);
            this.tbTimeDeviation.TabIndex = 94;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(197, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 93;
            this.label5.Text = "分钟";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(49, 240);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 92;
            this.label6.Text = "允许误差时间";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(197, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 91;
            this.label4.Text = "分钟";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 90;
            this.label3.Text = "持续时间";
            // 
            // lblCycle
            // 
            this.lblCycle.AutoSize = true;
            this.lblCycle.Location = new System.Drawing.Point(73, 336);
            this.lblCycle.Name = "lblCycle";
            this.lblCycle.Size = new System.Drawing.Size(53, 12);
            this.lblCycle.TabIndex = 83;
            this.lblCycle.Text = "循环周期";
            // 
            // lblPost
            // 
            this.lblPost.AutoSize = true;
            this.lblPost.Location = new System.Drawing.Point(73, 118);
            this.lblPost.Name = "lblPost";
            this.lblPost.Size = new System.Drawing.Size(53, 12);
            this.lblPost.TabIndex = 81;
            this.lblPost.Text = "指派岗位";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 80;
            this.label1.Text = "第一次执行结束时间";
            // 
            // lblshixiao
            // 
            this.lblshixiao.AutoSize = true;
            this.lblshixiao.Location = new System.Drawing.Point(56, 302);
            this.lblshixiao.Name = "lblshixiao";
            this.lblshixiao.Size = new System.Drawing.Size(77, 12);
            this.lblshixiao.TabIndex = 72;
            this.lblshixiao.Text = "任务失效时间";
            // 
            // lblshengxiao
            // 
            this.lblshengxiao.AutoSize = true;
            this.lblshengxiao.Location = new System.Drawing.Point(56, 269);
            this.lblshengxiao.Name = "lblshengxiao";
            this.lblshengxiao.Size = new System.Drawing.Size(77, 12);
            this.lblshengxiao.TabIndex = 71;
            this.lblshengxiao.Text = "任务生效时间";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(20, 155);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(113, 12);
            this.lblTime.TabIndex = 70;
            this.lblTime.Text = "第一次执行开始时间";
            // 
            // lblRount
            // 
            this.lblRount.AutoSize = true;
            this.lblRount.Location = new System.Drawing.Point(73, 89);
            this.lblRount.Name = "lblRount";
            this.lblRount.Size = new System.Drawing.Size(53, 12);
            this.lblRount.TabIndex = 69;
            this.lblRount.Text = "巡检路线";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(73, 32);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(53, 12);
            this.lblName.TabIndex = 68;
            this.lblName.Text = "计划名称";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(139, 27);
            this.tbName.Name = "tbName";
            this.tbName.Properties.LookAndFeel.SkinName = "Blue";
            this.tbName.Size = new System.Drawing.Size(183, 21);
            this.tbName.TabIndex = 97;
            // 
            // tbPost
            // 
            this.tbPost.Location = new System.Drawing.Point(139, 115);
            this.tbPost.Name = "tbPost";
            this.tbPost.Properties.LookAndFeel.SkinName = "Blue";
            this.tbPost.Properties.ReadOnly = true;
            this.tbPost.Size = new System.Drawing.Size(183, 21);
            this.tbPost.TabIndex = 98;
            // 
            // dtStartTime
            // 
            this.dtStartTime.EditValue = null;
            this.dtStartTime.Location = new System.Drawing.Point(139, 152);
            this.dtStartTime.Name = "dtStartTime";
            this.dtStartTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtStartTime.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm";
            this.dtStartTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtStartTime.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm";
            this.dtStartTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtStartTime.Properties.Mask.EditMask = "";
            this.dtStartTime.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.dtStartTime.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.dtStartTime.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.dtStartTime.Properties.VistaEditTime = DevExpress.Utils.DefaultBoolean.True;
            this.dtStartTime.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtStartTime.Size = new System.Drawing.Size(183, 21);
            this.dtStartTime.TabIndex = 99;
            // 
            // dtEndTime
            // 
            this.dtEndTime.EditValue = null;
            this.dtEndTime.Location = new System.Drawing.Point(139, 209);
            this.dtEndTime.Name = "dtEndTime";
            this.dtEndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEndTime.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm";
            this.dtEndTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtEndTime.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm";
            this.dtEndTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtEndTime.Properties.Mask.EditMask = "";
            this.dtEndTime.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.dtEndTime.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.dtEndTime.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.dtEndTime.Properties.VistaEditTime = DevExpress.Utils.DefaultBoolean.True;
            this.dtEndTime.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtEndTime.Size = new System.Drawing.Size(183, 21);
            this.dtEndTime.TabIndex = 100;
            // 
            // dtpEffect
            // 
            this.dtpEffect.EditValue = null;
            this.dtpEffect.Location = new System.Drawing.Point(139, 266);
            this.dtpEffect.Name = "dtpEffect";
            this.dtpEffect.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpEffect.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm";
            this.dtpEffect.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpEffect.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm";
            this.dtpEffect.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpEffect.Properties.Mask.EditMask = "";
            this.dtpEffect.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.dtpEffect.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.dtpEffect.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.dtpEffect.Properties.VistaEditTime = DevExpress.Utils.DefaultBoolean.True;
            this.dtpEffect.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtpEffect.Size = new System.Drawing.Size(183, 21);
            this.dtpEffect.TabIndex = 101;
            // 
            // dtpIneffect
            // 
            this.dtpIneffect.EditValue = null;
            this.dtpIneffect.Location = new System.Drawing.Point(139, 299);
            this.dtpIneffect.Name = "dtpIneffect";
            this.dtpIneffect.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpIneffect.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm";
            this.dtpIneffect.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpIneffect.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm";
            this.dtpIneffect.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpIneffect.Properties.Mask.EditMask = "";
            this.dtpIneffect.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.dtpIneffect.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.dtpIneffect.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.dtpIneffect.Properties.VistaEditTime = DevExpress.Utils.DefaultBoolean.True;
            this.dtpIneffect.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtpIneffect.Size = new System.Drawing.Size(183, 21);
            this.dtpIneffect.TabIndex = 102;
            // 
            // cboUnit
            // 
            this.cboUnit.Location = new System.Drawing.Point(199, 331);
            this.cboUnit.Name = "cboUnit";
            this.cboUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboUnit.Size = new System.Drawing.Size(123, 21);
            this.cboUnit.TabIndex = 103;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(137, 413);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 105;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(236, 413);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 106;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cboPlanType
            // 
            this.cboPlanType.Location = new System.Drawing.Point(139, 57);
            this.cboPlanType.Name = "cboPlanType";
            this.cboPlanType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPlanType.Size = new System.Drawing.Size(183, 21);
            this.cboPlanType.TabIndex = 108;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 107;
            this.label2.Text = "计划类型";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(73, 363);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 110;
            this.label7.Text = "状态";
            // 
            // cboValidState
            // 
            this.cboValidState.Location = new System.Drawing.Point(139, 360);
            this.cboValidState.Name = "cboValidState";
            this.cboValidState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboValidState.Size = new System.Drawing.Size(183, 21);
            this.cboValidState.TabIndex = 111;
            // 
            // cboCheckRoute
            // 
            this.cboCheckRoute.Location = new System.Drawing.Point(139, 86);
            this.cboCheckRoute.Name = "cboCheckRoute";
            this.cboCheckRoute.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCheckRoute.Size = new System.Drawing.Size(183, 21);
            this.cboCheckRoute.TabIndex = 112;
            // 
            // frmCheckPlanNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 465);
            this.Controls.Add(this.cboCheckRoute);
            this.Controls.Add(this.cboValidState);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboPlanType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cboUnit);
            this.Controls.Add(this.dtpIneffect);
            this.Controls.Add(this.dtpEffect);
            this.Controls.Add(this.dtEndTime);
            this.Controls.Add(this.dtStartTime);
            this.Controls.Add(this.tbPost);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.tbDuration);
            this.Controls.Add(this.tbInterval);
            this.Controls.Add(this.tbTimeDeviation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCycle);
            this.Controls.Add(this.lblPost);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblshixiao);
            this.Controls.Add(this.lblshengxiao);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblRount);
            this.Controls.Add(this.lblName);
            this.Name = "frmCheckPlanNew";
            this.Text = "新建巡检计划";
            this.Load += new System.EventHandler(this.frmCheckPlanNew_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbDuration.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbInterval.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTimeDeviation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPost.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartTime.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEndTime.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEffect.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEffect.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpIneffect.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpIneffect.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlanType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboValidState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCheckRoute.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit tbDuration;
        private DevExpress.XtraEditors.TextEdit tbInterval;
        private DevExpress.XtraEditors.TextEdit tbTimeDeviation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCycle;
        private System.Windows.Forms.Label lblPost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblshixiao;
        private System.Windows.Forms.Label lblshengxiao;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblRount;
        private System.Windows.Forms.Label lblName;
        private DevExpress.XtraEditors.TextEdit tbName;
        private DevExpress.XtraEditors.TextEdit tbPost;
        private DevExpress.XtraEditors.DateEdit dtStartTime;
        private DevExpress.XtraEditors.DateEdit dtEndTime;
        private DevExpress.XtraEditors.DateEdit dtpEffect;
        private DevExpress.XtraEditors.DateEdit dtpIneffect;
        private DevExpress.XtraEditors.ImageComboBoxEdit cboUnit;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.ImageComboBoxEdit cboPlanType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.ImageComboBoxEdit cboValidState;
        private DevExpress.XtraEditors.ImageComboBoxEdit cboCheckRoute;
    }
}