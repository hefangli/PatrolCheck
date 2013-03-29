namespace WorkStation
{
    partial class frmReportSearchByPlan
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
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.barPDF = new DevExpress.XtraBars.BarButtonItem();
            this.barExcel = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.tlCheckPlan = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn5 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn6 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn7 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn8 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.dpSearch = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.tbCheckItem = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.tbCheckPoint = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.tbCheckPlan = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.chkAll = new DevExpress.XtraEditors.CheckEdit();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtEndTime = new DevExpress.XtraEditors.DateEdit();
            this.dtStartTime = new DevExpress.XtraEditors.DateEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gvItemChecking = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlCheckPlan)).BeginInit();
            this.dpSearch.SuspendLayout();
            this.dockPanel2_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbCheckItem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCheckPoint.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCheckPlan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEndTime.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartTime.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItemChecking)).BeginInit();
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
            this.barButtonItem1,
            this.barSubItem1,
            this.barPDF,
            this.barExcel});
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
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem1)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "查询";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "导出";
            this.barSubItem1.Id = 1;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barPDF),
            new DevExpress.XtraBars.LinkPersistInfo(this.barExcel)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // barPDF
            // 
            this.barPDF.Caption = "导出PDF";
            this.barPDF.Id = 2;
            this.barPDF.Name = "barPDF";
            this.barPDF.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barPDF_ItemClick);
            // 
            // barExcel
            // 
            this.barExcel.Caption = "导出Excel";
            this.barExcel.Id = 3;
            this.barExcel.Name = "barExcel";
            this.barExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barExcel_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(898, 26);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 528);
            this.barDockControlBottom.Size = new System.Drawing.Size(898, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 26);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 502);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(898, 26);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 502);
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1,
            this.dpSearch});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // dockPanel1
            // 
            this.dockPanel1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.dockPanel1.Appearance.Options.UseBackColor = true;
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.ID = new System.Guid("e3dcdf2e-40bc-4444-8b28-60b937faa18e");
            this.dockPanel1.Location = new System.Drawing.Point(0, 26);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Options.ShowCloseButton = false;
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel1.Size = new System.Drawing.Size(200, 502);
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.tlCheckPlan);
            this.dockPanel1_Container.Location = new System.Drawing.Point(3, 25);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(194, 474);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // tlCheckPlan
            // 
            this.tlCheckPlan.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2,
            this.treeListColumn3,
            this.treeListColumn5,
            this.treeListColumn6,
            this.treeListColumn7,
            this.treeListColumn8});
            this.tlCheckPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlCheckPlan.Location = new System.Drawing.Point(0, 0);
            this.tlCheckPlan.Name = "tlCheckPlan";
            this.tlCheckPlan.OptionsBehavior.Editable = false;
            this.tlCheckPlan.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.tlCheckPlan.Size = new System.Drawing.Size(194, 474);
            this.tlCheckPlan.TabIndex = 0;
            this.tlCheckPlan.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.tlCheckPlan_FocusedNodeChanged);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "ID";
            this.treeListColumn1.FieldName = "ID";
            this.treeListColumn1.Name = "treeListColumn1";
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "ParentID";
            this.treeListColumn2.FieldName = "ParentID";
            this.treeListColumn2.Name = "treeListColumn2";
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.Caption = "名称";
            this.treeListColumn3.FieldName = "Name";
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.OptionsColumn.AllowEdit = false;
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 0;
            // 
            // treeListColumn5
            // 
            this.treeListColumn5.Caption = "TID";
            this.treeListColumn5.FieldName = "TID";
            this.treeListColumn5.Name = "treeListColumn5";
            // 
            // treeListColumn6
            // 
            this.treeListColumn6.Caption = "IsOrgization";
            this.treeListColumn6.FieldName = "IsOrgization";
            this.treeListColumn6.Name = "treeListColumn6";
            // 
            // treeListColumn7
            // 
            this.treeListColumn7.Caption = "IsPost";
            this.treeListColumn7.FieldName = "IsPost";
            this.treeListColumn7.Name = "treeListColumn7";
            // 
            // treeListColumn8
            // 
            this.treeListColumn8.Caption = "IsCheckPlan";
            this.treeListColumn8.FieldName = "IsCheckPlan";
            this.treeListColumn8.Name = "treeListColumn8";
            // 
            // dpSearch
            // 
            this.dpSearch.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.dpSearch.Appearance.Options.UseBackColor = true;
            this.dpSearch.Controls.Add(this.dockPanel2_Container);
            this.dpSearch.Dock = DevExpress.XtraBars.Docking.DockingStyle.Top;
            this.dpSearch.ID = new System.Guid("ae347b60-d75c-4eef-b872-672dcc951233");
            this.dpSearch.Location = new System.Drawing.Point(200, 26);
            this.dpSearch.Name = "dpSearch";
            this.dpSearch.OriginalSize = new System.Drawing.Size(200, 108);
            this.dpSearch.Size = new System.Drawing.Size(698, 108);
            this.dpSearch.Text = "查询";
            this.dpSearch.Click += new System.EventHandler(this.dpSearch_Click);
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Controls.Add(this.tbCheckItem);
            this.dockPanel2_Container.Controls.Add(this.labelControl6);
            this.dockPanel2_Container.Controls.Add(this.tbCheckPoint);
            this.dockPanel2_Container.Controls.Add(this.labelControl4);
            this.dockPanel2_Container.Controls.Add(this.tbCheckPlan);
            this.dockPanel2_Container.Controls.Add(this.labelControl5);
            this.dockPanel2_Container.Controls.Add(this.chkAll);
            this.dockPanel2_Container.Controls.Add(this.btnSearch);
            this.dockPanel2_Container.Controls.Add(this.labelControl2);
            this.dockPanel2_Container.Controls.Add(this.labelControl1);
            this.dockPanel2_Container.Controls.Add(this.dtEndTime);
            this.dockPanel2_Container.Controls.Add(this.dtStartTime);
            this.dockPanel2_Container.Location = new System.Drawing.Point(3, 25);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(692, 80);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // tbCheckItem
            // 
            this.tbCheckItem.Location = new System.Drawing.Point(452, 21);
            this.tbCheckItem.MenuManager = this.barManager1;
            this.tbCheckItem.Name = "tbCheckItem";
            this.tbCheckItem.Size = new System.Drawing.Size(132, 21);
            this.tbCheckItem.TabIndex = 21;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(398, 24);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(36, 14);
            this.labelControl6.TabIndex = 17;
            this.labelControl6.Text = "巡检项";
            // 
            // tbCheckPoint
            // 
            this.tbCheckPoint.Location = new System.Drawing.Point(257, 21);
            this.tbCheckPoint.MenuManager = this.barManager1;
            this.tbCheckPoint.Name = "tbCheckPoint";
            this.tbCheckPoint.Size = new System.Drawing.Size(132, 21);
            this.tbCheckPoint.TabIndex = 20;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(215, 24);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(36, 14);
            this.labelControl4.TabIndex = 16;
            this.labelControl4.Text = "巡检点";
            // 
            // tbCheckPlan
            // 
            this.tbCheckPlan.Location = new System.Drawing.Point(61, 20);
            this.tbCheckPlan.MenuManager = this.barManager1;
            this.tbCheckPlan.Name = "tbCheckPlan";
            this.tbCheckPlan.Size = new System.Drawing.Size(132, 21);
            this.tbCheckPlan.TabIndex = 19;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(31, 20);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(24, 14);
            this.labelControl5.TabIndex = 15;
            this.labelControl5.Text = "计划";
            // 
            // chkAll
            // 
            this.chkAll.Location = new System.Drawing.Point(590, 22);
            this.chkAll.MenuManager = this.barManager1;
            this.chkAll.Name = "chkAll";
            this.chkAll.Properties.Caption = "全部计划";
            this.chkAll.Size = new System.Drawing.Size(72, 19);
            this.chkAll.TabIndex = 18;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(452, 48);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 16;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(202, 49);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 15;
            this.labelControl2.Text = "结束时间";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(7, 51);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 14;
            this.labelControl1.Text = "开始时间";
            // 
            // dtEndTime
            // 
            this.dtEndTime.EditValue = null;
            this.dtEndTime.Location = new System.Drawing.Point(256, 48);
            this.dtEndTime.MenuManager = this.barManager1;
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
            this.dtEndTime.Size = new System.Drawing.Size(132, 21);
            this.dtEndTime.TabIndex = 13;
            // 
            // dtStartTime
            // 
            this.dtStartTime.EditValue = null;
            this.dtStartTime.Location = new System.Drawing.Point(61, 47);
            this.dtStartTime.MenuManager = this.barManager1;
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
            this.dtStartTime.Size = new System.Drawing.Size(132, 21);
            this.dtStartTime.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(200, 134);
            this.gridControl1.MainView = this.gvItemChecking;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(698, 394);
            this.gridControl1.TabIndex = 6;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvItemChecking});
            // 
            // gvItemChecking
            // 
            this.gvItemChecking.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn10,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn6,
            this.gridColumn9,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn7,
            this.gridColumn8});
            this.gvItemChecking.GridControl = this.gridControl1;
            this.gvItemChecking.Name = "gvItemChecking";
            this.gvItemChecking.OptionsBehavior.Editable = false;
            this.gvItemChecking.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvItemChecking.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvItemChecking_RowStyle);
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceCell.Font = new System.Drawing.Font("宋体", 9F);
            this.gridColumn10.AppearanceCell.Options.UseFont = true;
            this.gridColumn10.AppearanceHeader.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn10.AppearanceHeader.Options.UseFont = true;
            this.gridColumn10.Caption = "计划";
            this.gridColumn10.FieldName = "CheckPlanName";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 0;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("宋体", 9F);
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("宋体", 9F);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.Caption = "路线";
            this.gridColumn1.FieldName = "CheckRouteName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("宋体", 9F);
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("宋体", 9F);
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.Caption = "巡检点";
            this.gridColumn2.FieldName = "PhysicalCheckPointName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Font = new System.Drawing.Font("宋体", 9F);
            this.gridColumn3.AppearanceCell.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("宋体", 9F);
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.Caption = "巡检项";
            this.gridColumn3.FieldName = "CheckItemName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Font = new System.Drawing.Font("宋体", 9F);
            this.gridColumn6.AppearanceCell.Options.UseFont = true;
            this.gridColumn6.AppearanceHeader.Font = new System.Drawing.Font("宋体", 9F);
            this.gridColumn6.AppearanceHeader.Options.UseFont = true;
            this.gridColumn6.Caption = "是否正常";
            this.gridColumn6.FieldName = "BoolValue";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.Font = new System.Drawing.Font("宋体", 9F);
            this.gridColumn9.AppearanceCell.Options.UseFont = true;
            this.gridColumn9.AppearanceHeader.Font = new System.Drawing.Font("宋体", 9F);
            this.gridColumn9.AppearanceHeader.Options.UseFont = true;
            this.gridColumn9.Caption = "数值";
            this.gridColumn9.FieldName = "NumericalValue";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 5;
            // 
            // gridColumn11
            // 
            this.gridColumn11.AppearanceCell.Font = new System.Drawing.Font("宋体", 9F);
            this.gridColumn11.AppearanceCell.Options.UseFont = true;
            this.gridColumn11.AppearanceHeader.Font = new System.Drawing.Font("宋体", 9F);
            this.gridColumn11.AppearanceHeader.Options.UseFont = true;
            this.gridColumn11.Caption = "文本记录";
            this.gridColumn11.FieldName = "TextValue";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 6;
            // 
            // gridColumn12
            // 
            this.gridColumn12.AppearanceCell.Font = new System.Drawing.Font("宋体", 9F);
            this.gridColumn12.AppearanceCell.Options.UseFont = true;
            this.gridColumn12.AppearanceHeader.Font = new System.Drawing.Font("宋体", 9F);
            this.gridColumn12.AppearanceHeader.Options.UseFont = true;
            this.gridColumn12.Caption = "图片记录";
            this.gridColumn12.FieldName = "PictureFile";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 7;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Font = new System.Drawing.Font("宋体", 9F);
            this.gridColumn4.AppearanceCell.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("宋体", 9F);
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.Caption = "开始时间";
            this.gridColumn4.DisplayFormat.FormatString = "yyyy\'-\'MM\'-\'dd HH\':\'mm";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn4.FieldName = "PStartTime";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 8;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Font = new System.Drawing.Font("宋体", 9F);
            this.gridColumn5.AppearanceCell.Options.UseFont = true;
            this.gridColumn5.AppearanceHeader.Font = new System.Drawing.Font("宋体", 9F);
            this.gridColumn5.AppearanceHeader.Options.UseFont = true;
            this.gridColumn5.Caption = "结束时间";
            this.gridColumn5.DisplayFormat.FormatString = "yyyy\'-\'MM\'-\'dd HH\':\'mm";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn5.FieldName = "PEndTime";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 9;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Font = new System.Drawing.Font("宋体", 9F);
            this.gridColumn7.AppearanceCell.Options.UseFont = true;
            this.gridColumn7.AppearanceHeader.Font = new System.Drawing.Font("宋体", 9F);
            this.gridColumn7.AppearanceHeader.Options.UseFont = true;
            this.gridColumn7.Caption = "班组";
            this.gridColumn7.FieldName = "OrganizationName";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 10;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.Font = new System.Drawing.Font("宋体", 9F);
            this.gridColumn8.AppearanceCell.Options.UseFont = true;
            this.gridColumn8.AppearanceHeader.Font = new System.Drawing.Font("宋体", 9F);
            this.gridColumn8.AppearanceHeader.Options.UseFont = true;
            this.gridColumn8.Caption = "巡检人";
            this.gridColumn8.FieldName = "EmployeeName";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 11;
            // 
            // frmReportSearchByPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 528);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.dpSearch);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmReportSearchByPlan";
            this.Text = "按计划查询";
            this.Load += new System.EventHandler(this.frmReportSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlCheckPlan)).EndInit();
            this.dpSearch.ResumeLayout(false);
            this.dockPanel2_Container.ResumeLayout(false);
            this.dockPanel2_Container.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbCheckItem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCheckPoint.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCheckPlan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEndTime.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartTime.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItemChecking)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dpSearch;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraTreeList.TreeList tlCheckPlan;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gvItemChecking;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraEditors.DateEdit dtStartTime;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dtEndTime;
        private DevExpress.XtraEditors.CheckEdit chkAll;
        private DevExpress.XtraEditors.TextEdit tbCheckPlan;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit tbCheckItem;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit tbCheckPoint;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn5;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn6;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn7;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn8;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem barPDF;
        private DevExpress.XtraBars.BarButtonItem barExcel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}