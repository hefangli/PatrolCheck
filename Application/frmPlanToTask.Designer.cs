﻿namespace WorkStation
{
    partial class frmPlanToTask
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
            this.btnDown = new System.Windows.Forms.Button();
            this.cboState = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labState = new System.Windows.Forms.Label();
            this.gridControlPlan = new DevExpress.XtraGrid.GridControl();
            this.gvPlan = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn32 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControlTask = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn33 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn34 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn30 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(224, 19);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(75, 23);
            this.btnDown.TabIndex = 0;
            this.btnDown.Text = "生成任务";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // cboState
            // 
            this.cboState.FormattingEnabled = true;
            this.cboState.Location = new System.Drawing.Point(78, 20);
            this.cboState.Name = "cboState";
            this.cboState.Size = new System.Drawing.Size(121, 20);
            this.cboState.TabIndex = 37;
            this.cboState.SelectedIndexChanged += new System.EventHandler(this.cboState_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 38;
            this.label1.Text = "显示";
            // 
            // labState
            // 
            this.labState.AutoSize = true;
            this.labState.Location = new System.Drawing.Point(406, 28);
            this.labState.Name = "labState";
            this.labState.Size = new System.Drawing.Size(53, 12);
            this.labState.TabIndex = 40;
            this.labState.Text = "所选状态";
            // 
            // gridControlPlan
            // 
            this.gridControlPlan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlPlan.Location = new System.Drawing.Point(12, 67);
            this.gridControlPlan.MainView = this.gvPlan;
            this.gridControlPlan.Name = "gridControlPlan";
            this.gridControlPlan.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridControlPlan.Size = new System.Drawing.Size(785, 291);
            this.gridControlPlan.TabIndex = 47;
            this.gridControlPlan.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPlan});
            // 
            // gvPlan
            // 
            this.gvPlan.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn20,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn32,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19});
            this.gvPlan.GridControl = this.gridControlPlan;
            this.gvPlan.Name = "gvPlan";
            this.gvPlan.OptionsView.ColumnAutoWidth = false;
            this.gvPlan.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gvPlan_RowClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "选择";
            this.gridColumn1.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumn1.FieldName = "isCheck";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 53;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "计划ID";
            this.gridColumn20.FieldName = "ID";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.OptionsColumn.AllowEdit = false;
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "计划名称";
            this.gridColumn2.FieldName = "Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 87;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "计划别名";
            this.gridColumn3.FieldName = "Alias";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 80;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "路线";
            this.gridColumn4.FieldName = "RouteName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 59;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "岗位";
            this.gridColumn5.FieldName = "PostName";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 67;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "执行人";
            this.gridColumn6.FieldName = "OperatorName";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            this.gridColumn6.Width = 58;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "第一次开始时间";
            this.gridColumn7.DisplayFormat.FormatString = "yyyy\'-\'MM\'-\'dd HH\':\'mm";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn7.FieldName = "StartTime";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 7;
            this.gridColumn7.Width = 105;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "第一次结束时间";
            this.gridColumn8.DisplayFormat.FormatString = "yyyy\'-\'MM\'-\'dd HH\':\'mm";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn8.FieldName = "EndTime";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 8;
            this.gridColumn8.Width = 110;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "持续时间";
            this.gridColumn9.FieldName = "Duration";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 9;
            this.gridColumn9.Width = 72;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "允许误差时间";
            this.gridColumn10.FieldName = "TimeDeviation";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 10;
            this.gridColumn10.Width = 104;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "周期";
            this.gridColumn11.FieldName = "Interval";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 11;
            this.gridColumn11.Width = 65;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "周期单位";
            this.gridColumn12.FieldName = "IntervalUnit";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 12;
            this.gridColumn12.Width = 74;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "计划生效时间";
            this.gridColumn13.DisplayFormat.FormatString = "yyyy\'-\'MM\'-\'dd HH\':\'mm";
            this.gridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn13.FieldName = "EffectiveTime";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 13;
            this.gridColumn13.Width = 98;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "计划失效时间";
            this.gridColumn14.DisplayFormat.FormatString = "yyyy\'-\'MM\'-\'dd HH\':\'mm";
            this.gridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn14.FieldName = "IneffectiveTime";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 14;
            this.gridColumn14.Width = 111;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "计划制定人";
            this.gridColumn15.FieldName = "Planner";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 15;
            this.gridColumn15.Width = 90;
            // 
            // gridColumn32
            // 
            this.gridColumn32.Caption = "计划状态";
            this.gridColumn32.FieldName = "PlanState";
            this.gridColumn32.Name = "gridColumn32";
            this.gridColumn32.OptionsColumn.AllowEdit = false;
            this.gridColumn32.Visible = true;
            this.gridColumn32.VisibleIndex = 16;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "RouteID";
            this.gridColumn16.FieldName = "RouteID";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.Width = 39;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "PostID";
            this.gridColumn17.FieldName = "PostID";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.Width = 20;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "OperatorID";
            this.gridColumn18.FieldName = "OperatorID";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.Width = 20;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "IntervalUnitID";
            this.gridColumn19.FieldName = "IntervalUnitID";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.OptionsColumn.AllowEdit = false;
            this.gridColumn19.Width = 85;
            // 
            // gridControlTask
            // 
            this.gridControlTask.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlTask.Location = new System.Drawing.Point(12, 364);
            this.gridControlTask.MainView = this.gridView1;
            this.gridControlTask.Name = "gridControlTask";
            this.gridControlTask.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit2});
            this.gridControlTask.Size = new System.Drawing.Size(785, 231);
            this.gridControlTask.TabIndex = 48;
            this.gridControlTask.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn21,
            this.gridColumn22,
            this.gridColumn24,
            this.gridColumn25,
            this.gridColumn26,
            this.gridColumn23,
            this.gridColumn27,
            this.gridColumn33,
            this.gridColumn28,
            this.gridColumn29,
            this.gridColumn34,
            this.gridColumn30,
            this.gridColumn31});
            this.gridView1.GridControl = this.gridControlTask;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "任务编号";
            this.gridColumn21.FieldName = "ID";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.OptionsColumn.AllowEdit = false;
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 0;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "任务名称";
            this.gridColumn22.FieldName = "TaskName";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.OptionsColumn.AllowEdit = false;
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 1;
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "开始时间";
            this.gridColumn24.DisplayFormat.FormatString = "yyyy\'-\'MM\'-\'dd HH\':\'mm";
            this.gridColumn24.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn24.FieldName = "StartTime";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.OptionsColumn.AllowEdit = false;
            this.gridColumn24.Visible = true;
            this.gridColumn24.VisibleIndex = 2;
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "持续时间";
            this.gridColumn25.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn25.FieldName = "Duration";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.OptionsColumn.AllowEdit = false;
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 3;
            // 
            // gridColumn26
            // 
            this.gridColumn26.Caption = "结束时间";
            this.gridColumn26.DisplayFormat.FormatString = "yyyy\'-\'MM\'-\'dd HH\':\'mm";
            this.gridColumn26.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn26.FieldName = "EndTime";
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.OptionsColumn.AllowEdit = false;
            this.gridColumn26.Visible = true;
            this.gridColumn26.VisibleIndex = 4;
            // 
            // gridColumn27
            // 
            this.gridColumn27.Caption = "岗位";
            this.gridColumn27.FieldName = "PostName";
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn27.OptionsColumn.AllowEdit = false;
            this.gridColumn27.Visible = true;
            this.gridColumn27.VisibleIndex = 6;
            // 
            // gridColumn33
            // 
            this.gridColumn33.Caption = "执行人";
            this.gridColumn33.FieldName = "Operator";
            this.gridColumn33.Name = "gridColumn33";
            this.gridColumn33.OptionsColumn.AllowEdit = false;
            this.gridColumn33.Visible = true;
            this.gridColumn33.VisibleIndex = 7;
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "路线名称";
            this.gridColumn23.FieldName = "RouteName";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.OptionsColumn.AllowEdit = false;
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 5;
            // 
            // gridColumn28
            // 
            this.gridColumn28.Caption = "周期";
            this.gridColumn28.FieldName = "Interval";
            this.gridColumn28.Name = "gridColumn28";
            this.gridColumn28.OptionsColumn.AllowEdit = false;
            this.gridColumn28.Visible = true;
            this.gridColumn28.VisibleIndex = 8;
            // 
            // gridColumn29
            // 
            this.gridColumn29.Caption = "周期单位";
            this.gridColumn29.FieldName = "IntervalUnit";
            this.gridColumn29.Name = "gridColumn29";
            this.gridColumn29.OptionsColumn.AllowEdit = false;
            this.gridColumn29.Visible = true;
            this.gridColumn29.VisibleIndex = 9;
            // 
            // gridColumn34
            // 
            this.gridColumn34.Caption = "任务状态";
            this.gridColumn34.FieldName = "TaskState";
            this.gridColumn34.Name = "gridColumn34";
            this.gridColumn34.OptionsColumn.AllowEdit = false;
            this.gridColumn34.Visible = true;
            this.gridColumn34.VisibleIndex = 10;
            // 
            // gridColumn30
            // 
            this.gridColumn30.Caption = "计划生效时间";
            this.gridColumn30.DisplayFormat.FormatString = "yyyy\'-\'MM\'-\'dd HH\':\'mm";
            this.gridColumn30.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn30.FieldName = "EffectiveTime";
            this.gridColumn30.Name = "gridColumn30";
            this.gridColumn30.OptionsColumn.AllowEdit = false;
            this.gridColumn30.Visible = true;
            this.gridColumn30.VisibleIndex = 11;
            // 
            // gridColumn31
            // 
            this.gridColumn31.Caption = "计划失效时间";
            this.gridColumn31.DisplayFormat.FormatString = "yyyy\'-\'MM\'-\'dd HH\':\'mm";
            this.gridColumn31.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn31.FieldName = "IneffectiveTime";
            this.gridColumn31.Name = "gridColumn31";
            this.gridColumn31.OptionsColumn.AllowEdit = false;
            this.gridColumn31.Visible = true;
            this.gridColumn31.VisibleIndex = 12;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cboState);
            this.groupBox1.Controls.Add(this.btnDown);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.labState);
            this.groupBox1.Location = new System.Drawing.Point(12, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(785, 54);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "任务生成";
            // 
            // frmPlanToTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 607);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gridControlTask);
            this.Controls.Add(this.gridControlPlan);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmPlanToTask";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "任务生成";
            this.Load += new System.EventHandler(this.frmAddPlanToTask_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.ComboBox cboState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labState;
        private DevExpress.XtraGrid.GridControl gridControlPlan;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPlan;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.GridControl gridControlTask;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn28;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn29;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn30;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn31;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn32;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn33;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn34;
    }
}