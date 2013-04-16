namespace WorkStation
{
    partial class frmRfid
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
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barNew = new DevExpress.XtraBars.BarButtonItem();
            this.barEdit = new DevExpress.XtraBars.BarButtonItem();
            this.barDel = new DevExpress.XtraBars.BarButtonItem();
            this.barSearch = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dpSearch = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cboUsed = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboValidState = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.cboPurpose = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.tbName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gvRfid = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dpSearch.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboUsed.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboValidState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPurpose.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRfid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockManager = this.dockManager1;
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barNew,
            this.barEdit,
            this.barDel,
            this.barSearch});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 4;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barNew),
            new DevExpress.XtraBars.LinkPersistInfo(this.barEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.barDel),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSearch)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barNew
            // 
            this.barNew.Caption = "新建";
            this.barNew.Id = 0;
            this.barNew.Name = "barNew";
            this.barNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barNew_ItemClick);
            // 
            // barEdit
            // 
            this.barEdit.Caption = "编辑";
            this.barEdit.Id = 1;
            this.barEdit.Name = "barEdit";
            this.barEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barEdit_ItemClick);
            // 
            // barDel
            // 
            this.barDel.Caption = "删除";
            this.barDel.Id = 2;
            this.barDel.Name = "barDel";
            this.barDel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barDel_ItemClick);
            // 
            // barSearch
            // 
            this.barSearch.Caption = "查找";
            this.barSearch.Id = 3;
            this.barSearch.Name = "barSearch";
            this.barSearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barSearch_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(858, 26);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 529);
            this.barDockControlBottom.Size = new System.Drawing.Size(858, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 26);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 503);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(858, 26);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 503);
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dpSearch});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // dpSearch
            // 
            this.dpSearch.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.dpSearch.Appearance.Options.UseBackColor = true;
            this.dpSearch.Controls.Add(this.dockPanel1_Container);
            this.dpSearch.Dock = DevExpress.XtraBars.Docking.DockingStyle.Top;
            this.dpSearch.ID = new System.Guid("5ee615cd-1c8c-40fd-94f1-efa7fba74d33");
            this.dpSearch.Location = new System.Drawing.Point(0, 26);
            this.dpSearch.Name = "dpSearch";
            this.dpSearch.OriginalSize = new System.Drawing.Size(200, 118);
            this.dpSearch.Size = new System.Drawing.Size(858, 118);
            this.dpSearch.Text = "查找";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.labelControl4);
            this.dockPanel1_Container.Controls.Add(this.labelControl3);
            this.dockPanel1_Container.Controls.Add(this.cboUsed);
            this.dockPanel1_Container.Controls.Add(this.labelControl2);
            this.dockPanel1_Container.Controls.Add(this.cboValidState);
            this.dockPanel1_Container.Controls.Add(this.cboPurpose);
            this.dockPanel1_Container.Controls.Add(this.btnSearch);
            this.dockPanel1_Container.Controls.Add(this.tbName);
            this.dockPanel1_Container.Controls.Add(this.labelControl1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(3, 25);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(852, 90);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(210, 52);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(52, 14);
            this.labelControl4.TabIndex = 14;
            this.labelControl4.Text = "是否在用:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(20, 48);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(28, 14);
            this.labelControl3.TabIndex = 12;
            this.labelControl3.Text = "状态:";
            // 
            // cboUsed
            // 
            this.cboUsed.Location = new System.Drawing.Point(268, 49);
            this.cboUsed.MenuManager = this.barManager1;
            this.cboUsed.Name = "cboUsed";
            this.cboUsed.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboUsed.Size = new System.Drawing.Size(125, 21);
            this.cboUsed.TabIndex = 13;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(222, 18);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(28, 14);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "用途:";
            // 
            // cboValidState
            // 
            this.cboValidState.Location = new System.Drawing.Point(63, 45);
            this.cboValidState.MenuManager = this.barManager1;
            this.cboValidState.Name = "cboValidState";
            this.cboValidState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboValidState.Size = new System.Drawing.Size(125, 21);
            this.cboValidState.TabIndex = 11;
            // 
            // cboPurpose
            // 
            this.cboPurpose.Location = new System.Drawing.Point(268, 15);
            this.cboPurpose.MenuManager = this.barManager1;
            this.cboPurpose.Name = "cboPurpose";
            this.cboPurpose.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPurpose.Size = new System.Drawing.Size(125, 21);
            this.cboPurpose.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(441, 52);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "查找";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(63, 15);
            this.tbName.MenuManager = this.barManager1;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(125, 21);
            this.tbName.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(21, 18);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "名称：";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Remove.Enabled = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridControl1.Location = new System.Drawing.Point(0, 144);
            this.gridControl1.MainView = this.gvRfid;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridControl1.Size = new System.Drawing.Size(858, 385);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvRfid});
            // 
            // gvRfid
            // 
            this.gvRfid.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.gvRfid.GridControl = this.gridControl1;
            this.gvRfid.Name = "gvRfid";
            this.gvRfid.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvRfid.DoubleClick += new System.EventHandler(this.gvRfid_DoubleClick);
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "选择";
            this.gridColumn7.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumn7.FieldName = "IsCheck";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.ValueChecked = "True";
            this.repositoryItemCheckEdit1.ValueUnchecked = "False";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "编号";
            this.gridColumn1.FieldName = "ID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "名称";
            this.gridColumn2.FieldName = "Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "RFID";
            this.gridColumn3.FieldName = "RFID";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "用途";
            this.gridColumn4.FieldName = "PurposeMeaning";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "是否在用";
            this.gridColumn5.FieldName = "UsedMeaning";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "状态";
            this.gridColumn6.FieldName = "ValidStateMeaning";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            // 
            // frmRfid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 529);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.dpSearch);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmRfid";
            this.Text = "RFID卡管理";
            this.Load += new System.EventHandler(this.frmRFid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dpSearch.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.dockPanel1_Container.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboUsed.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboValidState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPurpose.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRfid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barNew;
        private DevExpress.XtraBars.BarButtonItem barEdit;
        private DevExpress.XtraBars.BarButtonItem barDel;
        private DevExpress.XtraBars.BarButtonItem barSearch;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRfid;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraBars.Docking.DockPanel dpSearch;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ImageComboBoxEdit cboValidState;
        private DevExpress.XtraEditors.ImageComboBoxEdit cboPurpose;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.TextEdit tbName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ImageComboBoxEdit cboUsed;
    }
}