﻿namespace WorkStation
{
    partial class frmPoint
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblAlias = new System.Windows.Forms.Label();
            this.lblRelated = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtAlias = new System.Windows.Forms.TextBox();
            this.txtRelation = new System.Windows.Forms.TextBox();
            this.btnChose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.labID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboSite = new System.Windows.Forms.ComboBox();
            this.gridControlPoint = new DevExpress.XtraGrid.GridControl();
            this.gvPoint = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRead = new System.Windows.Forms.Button();
            this.cboState = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(14, 23);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(53, 12);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "巡检名称";
            // 
            // lblAlias
            // 
            this.lblAlias.AutoSize = true;
            this.lblAlias.Location = new System.Drawing.Point(389, 23);
            this.lblAlias.Name = "lblAlias";
            this.lblAlias.Size = new System.Drawing.Size(29, 12);
            this.lblAlias.TabIndex = 1;
            this.lblAlias.Text = "别名";
            // 
            // lblRelated
            // 
            this.lblRelated.AutoSize = true;
            this.lblRelated.Location = new System.Drawing.Point(2, 59);
            this.lblRelated.Name = "lblRelated";
            this.lblRelated.Size = new System.Drawing.Size(65, 12);
            this.lblRelated.TabIndex = 2;
            this.lblRelated.Text = "关联标签卡";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(73, 20);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(301, 21);
            this.txtName.TabIndex = 3;
            // 
            // txtAlias
            // 
            this.txtAlias.Location = new System.Drawing.Point(424, 20);
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.Size = new System.Drawing.Size(229, 21);
            this.txtAlias.TabIndex = 4;
            // 
            // txtRelation
            // 
            this.txtRelation.Location = new System.Drawing.Point(73, 53);
            this.txtRelation.Name = "txtRelation";
            this.txtRelation.ReadOnly = true;
            this.txtRelation.Size = new System.Drawing.Size(205, 21);
            this.txtRelation.TabIndex = 5;
            this.txtRelation.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtRelation_MouseDoubleClick);
            // 
            // btnChose
            // 
            this.btnChose.Location = new System.Drawing.Point(284, 54);
            this.btnChose.Name = "btnChose";
            this.btnChose.Size = new System.Drawing.Size(44, 23);
            this.btnChose.TabIndex = 6;
            this.btnChose.Text = "选择";
            this.btnChose.UseVisualStyleBackColor = true;
            this.btnChose.Click += new System.EventHandler(this.btnChose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(391, 88);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(495, 86);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "修改";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(593, 86);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 9;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // labID
            // 
            this.labID.AutoSize = true;
            this.labID.Location = new System.Drawing.Point(659, 59);
            this.labID.Name = "labID";
            this.labID.Size = new System.Drawing.Size(41, 12);
            this.labID.TabIndex = 12;
            this.labID.Text = "巡检ID";
            this.labID.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(389, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "厂区";
            // 
            // cboSite
            // 
            this.cboSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSite.FormattingEnabled = true;
            this.cboSite.Location = new System.Drawing.Point(424, 56);
            this.cboSite.Name = "cboSite";
            this.cboSite.Size = new System.Drawing.Size(229, 20);
            this.cboSite.TabIndex = 14;
            // 
            // gridControlPoint
            // 
            this.gridControlPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlPoint.Location = new System.Drawing.Point(12, 135);
            this.gridControlPoint.MainView = this.gvPoint;
            this.gridControlPoint.Name = "gridControlPoint";
            this.gridControlPoint.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridControlPoint.Size = new System.Drawing.Size(727, 403);
            this.gridControlPoint.TabIndex = 15;
            this.gridControlPoint.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPoint});
            // 
            // gvPoint
            // 
            this.gvPoint.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn8,
            this.gridColumn5,
            this.gridColumn9,
            this.gridColumn7,
            this.gridColumn10});
            this.gvPoint.GridControl = this.gridControlPoint;
            this.gvPoint.Name = "gvPoint";
            this.gvPoint.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gvPoint_RowClick);
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "选择";
            this.gridColumn6.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumn6.FieldName = "isCheck";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "巡检点名称";
            this.gridColumn1.FieldName = "Name";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "别名";
            this.gridColumn2.FieldName = "Alias";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "RFID";
            this.gridColumn3.FieldName = "RName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "所属厂区";
            this.gridColumn4.FieldName = "SiteName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "状态";
            this.gridColumn8.FieldName = "ValidStateMeaning";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "SiteID";
            this.gridColumn5.FieldName = "SiteID";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "gridColumn9";
            this.gridColumn9.FieldName = "ValidState";
            this.gridColumn9.Name = "gridColumn9";
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "gridColumn7";
            this.gridColumn7.FieldName = "RID";
            this.gridColumn7.Name = "gridColumn7";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnRead);
            this.groupBox1.Controls.Add(this.cboState);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.cboSite);
            this.groupBox1.Controls.Add(this.lblAlias);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblRelated);
            this.groupBox1.Controls.Add(this.labID);
            this.groupBox1.Controls.Add(this.txtAlias);
            this.groupBox1.Controls.Add(this.btnDel);
            this.groupBox1.Controls.Add(this.txtRelation);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.btnChose);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(727, 117);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "功能";
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(334, 54);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(40, 23);
            this.btnRead.TabIndex = 17;
            this.btnRead.Text = "读取";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // cboState
            // 
            this.cboState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboState.FormattingEnabled = true;
            this.cboState.Location = new System.Drawing.Point(73, 86);
            this.cboState.Name = "cboState";
            this.cboState.Size = new System.Drawing.Size(205, 20);
            this.cboState.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "状态";
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "gridColumn10";
            this.gridColumn10.FieldName = "ID";
            this.gridColumn10.Name = "gridColumn10";
            // 
            // frmPoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(751, 550);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gridControlPoint);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.Name = "frmPoint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "新建巡检点";
            this.Load += new System.EventHandler(this.frmAddPoint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblAlias;
        private System.Windows.Forms.Label lblRelated;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtAlias;
        private System.Windows.Forms.TextBox txtRelation;
        private System.Windows.Forms.Button btnChose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Label labID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboSite;
        private DevExpress.XtraGrid.GridControl gridControlPoint;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPoint;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.ComboBox cboState;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
    }
}