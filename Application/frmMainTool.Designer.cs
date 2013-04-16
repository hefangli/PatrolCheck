namespace WorkStation
{
    partial class frmMainTool
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("计划管理");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("按计划查询");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("按地点查询");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("按班组和人员查询");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("数据明细查询", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("缺陷查询");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("按计划汇总");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("按地点汇总");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("按班组和人员汇总");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("巡检工作汇总", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("漏检点查询");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("执行情况查询");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("计划执行查询", new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("数据趋势查询");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("巡检路线管理");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("巡检点管理");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("巡检项管理");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("缺陷管理");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("组织结构设置");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("人员设置");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("地点设置");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("岗位设置");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("卡片管理");
            this.xPanderPanelList1 = new BSE.Windows.Forms.XPanderPanelList();
            this.xPanderPanel1 = new BSE.Windows.Forms.XPanderPanel();
            this.tvPlan = new System.Windows.Forms.TreeView();
            this.xPanderPanel2 = new BSE.Windows.Forms.XPanderPanel();
            this.tvSearch = new System.Windows.Forms.TreeView();
            this.xPanderPanel3 = new BSE.Windows.Forms.XPanderPanel();
            this.tvXunjian = new System.Windows.Forms.TreeView();
            this.xPanderPanel4 = new BSE.Windows.Forms.XPanderPanel();
            this.tvJiChu = new System.Windows.Forms.TreeView();
            this.xPanderPanel5 = new BSE.Windows.Forms.XPanderPanel();
            this.tvCard = new System.Windows.Forms.TreeView();
            this.xPanderPanelList1.SuspendLayout();
            this.xPanderPanel1.SuspendLayout();
            this.xPanderPanel2.SuspendLayout();
            this.xPanderPanel3.SuspendLayout();
            this.xPanderPanel4.SuspendLayout();
            this.xPanderPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // xPanderPanelList1
            // 
            this.xPanderPanelList1.CaptionStyle = BSE.Windows.Forms.CaptionStyle.Normal;
            this.xPanderPanelList1.ColorScheme = BSE.Windows.Forms.ColorScheme.Custom;
            this.xPanderPanelList1.Controls.Add(this.xPanderPanel1);
            this.xPanderPanelList1.Controls.Add(this.xPanderPanel2);
            this.xPanderPanelList1.Controls.Add(this.xPanderPanel3);
            this.xPanderPanelList1.Controls.Add(this.xPanderPanel4);
            this.xPanderPanelList1.Controls.Add(this.xPanderPanel5);
            this.xPanderPanelList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanderPanelList1.GradientBackground = System.Drawing.Color.Empty;
            this.xPanderPanelList1.Location = new System.Drawing.Point(0, 0);
            this.xPanderPanelList1.Name = "xPanderPanelList1";
            this.xPanderPanelList1.PanelColors = null;
            this.xPanderPanelList1.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007;
            this.xPanderPanelList1.Size = new System.Drawing.Size(219, 490);
            this.xPanderPanelList1.TabIndex = 0;
            this.xPanderPanelList1.Text = "xPanderPanelList1";
            // 
            // xPanderPanel1
            // 
            this.xPanderPanel1.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Bold);
            this.xPanderPanel1.ColorScheme = BSE.Windows.Forms.ColorScheme.Custom;
            this.xPanderPanel1.Controls.Add(this.tvPlan);
            this.xPanderPanel1.CustomColors.BackColor = System.Drawing.SystemColors.Control;
            this.xPanderPanel1.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(65)))), ((int)(((byte)(118)))));
            this.xPanderPanel1.CustomColors.CaptionCheckedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(154)))));
            this.xPanderPanel1.CustomColors.CaptionCheckedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(166)))), ((int)(((byte)(76)))));
            this.xPanderPanel1.CustomColors.CaptionCheckedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(116)))));
            this.xPanderPanel1.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel1.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel1.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.xPanderPanel1.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(164)))), ((int)(((byte)(224)))));
            this.xPanderPanel1.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.xPanderPanel1.CustomColors.CaptionPressedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(128)))), ((int)(((byte)(62)))));
            this.xPanderPanel1.CustomColors.CaptionPressedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(154)))));
            this.xPanderPanel1.CustomColors.CaptionPressedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(177)))), ((int)(((byte)(109)))));
            this.xPanderPanel1.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(222)))));
            this.xPanderPanel1.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(203)))), ((int)(((byte)(136)))));
            this.xPanderPanel1.CustomColors.CaptionSelectedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(225)))), ((int)(((byte)(172)))));
            this.xPanderPanel1.CustomColors.CaptionSelectedText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel1.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel1.CustomColors.FlatCaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.xPanderPanel1.CustomColors.FlatCaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.xPanderPanel1.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xPanderPanel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel1.Image = null;
            this.xPanderPanel1.Name = "xPanderPanel1";
            this.xPanderPanel1.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007;
            this.xPanderPanel1.Size = new System.Drawing.Size(219, 25);
            this.xPanderPanel1.TabIndex = 0;
            this.xPanderPanel1.Text = "巡检管理";
            this.xPanderPanel1.ToolTipTextCloseIcon = null;
            this.xPanderPanel1.ToolTipTextExpandIconPanelCollapsed = null;
            this.xPanderPanel1.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // tvPlan
            // 
            this.tvPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvPlan.Font = new System.Drawing.Font("宋体", 10F);
            this.tvPlan.Location = new System.Drawing.Point(1, 25);
            this.tvPlan.Name = "tvPlan";
            treeNode1.Name = "frmCheckPlan";
            treeNode1.Text = "计划管理";
            this.tvPlan.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.tvPlan.Size = new System.Drawing.Size(217, 0);
            this.tvPlan.TabIndex = 0;
            this.tvPlan.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // xPanderPanel2
            // 
            this.xPanderPanel2.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Bold);
            this.xPanderPanel2.ColorScheme = BSE.Windows.Forms.ColorScheme.Custom;
            this.xPanderPanel2.Controls.Add(this.tvSearch);
            this.xPanderPanel2.CustomColors.BackColor = System.Drawing.SystemColors.Control;
            this.xPanderPanel2.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(65)))), ((int)(((byte)(118)))));
            this.xPanderPanel2.CustomColors.CaptionCheckedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(154)))));
            this.xPanderPanel2.CustomColors.CaptionCheckedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(166)))), ((int)(((byte)(76)))));
            this.xPanderPanel2.CustomColors.CaptionCheckedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(116)))));
            this.xPanderPanel2.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel2.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel2.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.xPanderPanel2.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(164)))), ((int)(((byte)(224)))));
            this.xPanderPanel2.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.xPanderPanel2.CustomColors.CaptionPressedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(128)))), ((int)(((byte)(62)))));
            this.xPanderPanel2.CustomColors.CaptionPressedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(154)))));
            this.xPanderPanel2.CustomColors.CaptionPressedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(177)))), ((int)(((byte)(109)))));
            this.xPanderPanel2.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(222)))));
            this.xPanderPanel2.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(203)))), ((int)(((byte)(136)))));
            this.xPanderPanel2.CustomColors.CaptionSelectedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(225)))), ((int)(((byte)(172)))));
            this.xPanderPanel2.CustomColors.CaptionSelectedText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel2.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel2.CustomColors.FlatCaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.xPanderPanel2.CustomColors.FlatCaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.xPanderPanel2.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xPanderPanel2.Expand = true;
            this.xPanderPanel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel2.Image = null;
            this.xPanderPanel2.Name = "xPanderPanel2";
            this.xPanderPanel2.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007;
            this.xPanderPanel2.Size = new System.Drawing.Size(219, 390);
            this.xPanderPanel2.TabIndex = 1;
            this.xPanderPanel2.Text = "统计报表";
            this.xPanderPanel2.ToolTipTextCloseIcon = null;
            this.xPanderPanel2.ToolTipTextExpandIconPanelCollapsed = null;
            this.xPanderPanel2.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // tvSearch
            // 
            this.tvSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvSearch.Location = new System.Drawing.Point(1, 25);
            this.tvSearch.Name = "tvSearch";
            treeNode2.Name = "frmReportSearchByPlan";
            treeNode2.Text = "按计划查询";
            treeNode3.Name = "frmReportSearchByPoint";
            treeNode3.Text = "按地点查询";
            treeNode4.Name = "frmReportSearchByEmployee";
            treeNode4.Text = "按班组和人员查询";
            treeNode5.Name = "节点1";
            treeNode5.Text = "数据明细查询";
            treeNode6.Name = "frmReportDefectSearch";
            treeNode6.Text = "缺陷查询";
            treeNode7.Name = "frmReportSummaryByPlan";
            treeNode7.Text = "按计划汇总";
            treeNode8.Name = "frmReportSummaryByPoint";
            treeNode8.Text = "按地点汇总";
            treeNode9.Name = "frmReportSummaryByEmployee";
            treeNode9.Text = "按班组和人员汇总";
            treeNode10.Name = "节点3";
            treeNode10.Text = "巡检工作汇总";
            treeNode11.Name = "frmReportPointsMissed";
            treeNode11.Text = "漏检点查询";
            treeNode12.Name = "frmReportRunSituation";
            treeNode12.Text = "执行情况查询";
            treeNode13.Name = "节点4";
            treeNode13.Text = "计划执行查询";
            treeNode14.Name = "frmReportDataTrend";
            treeNode14.Text = "数据趋势查询";
            this.tvSearch.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode10,
            treeNode13,
            treeNode14});
            this.tvSearch.Size = new System.Drawing.Size(217, 365);
            this.tvSearch.TabIndex = 0;
            this.tvSearch.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // xPanderPanel3
            // 
            this.xPanderPanel3.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Bold);
            this.xPanderPanel3.ColorScheme = BSE.Windows.Forms.ColorScheme.Custom;
            this.xPanderPanel3.Controls.Add(this.tvXunjian);
            this.xPanderPanel3.CustomColors.BackColor = System.Drawing.SystemColors.Control;
            this.xPanderPanel3.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(65)))), ((int)(((byte)(118)))));
            this.xPanderPanel3.CustomColors.CaptionCheckedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(154)))));
            this.xPanderPanel3.CustomColors.CaptionCheckedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(166)))), ((int)(((byte)(76)))));
            this.xPanderPanel3.CustomColors.CaptionCheckedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(116)))));
            this.xPanderPanel3.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel3.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel3.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.xPanderPanel3.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(164)))), ((int)(((byte)(224)))));
            this.xPanderPanel3.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.xPanderPanel3.CustomColors.CaptionPressedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(128)))), ((int)(((byte)(62)))));
            this.xPanderPanel3.CustomColors.CaptionPressedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(154)))));
            this.xPanderPanel3.CustomColors.CaptionPressedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(177)))), ((int)(((byte)(109)))));
            this.xPanderPanel3.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(222)))));
            this.xPanderPanel3.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(203)))), ((int)(((byte)(136)))));
            this.xPanderPanel3.CustomColors.CaptionSelectedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(225)))), ((int)(((byte)(172)))));
            this.xPanderPanel3.CustomColors.CaptionSelectedText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel3.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel3.CustomColors.FlatCaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.xPanderPanel3.CustomColors.FlatCaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.xPanderPanel3.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xPanderPanel3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel3.Image = null;
            this.xPanderPanel3.Name = "xPanderPanel3";
            this.xPanderPanel3.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007;
            this.xPanderPanel3.Size = new System.Drawing.Size(219, 25);
            this.xPanderPanel3.TabIndex = 2;
            this.xPanderPanel3.Text = "巡检信息";
            this.xPanderPanel3.ToolTipTextCloseIcon = null;
            this.xPanderPanel3.ToolTipTextExpandIconPanelCollapsed = null;
            this.xPanderPanel3.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // tvXunjian
            // 
            this.tvXunjian.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvXunjian.Location = new System.Drawing.Point(1, 25);
            this.tvXunjian.Name = "tvXunjian";
            treeNode15.Name = "frmRoute";
            treeNode15.Text = "巡检路线管理";
            treeNode16.Name = "frmPoint";
            treeNode16.Text = "巡检点管理";
            treeNode17.Name = "frmItem";
            treeNode17.Text = "巡检项管理";
            treeNode18.Name = "frmDefectType";
            treeNode18.Text = "缺陷管理";
            this.tvXunjian.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18});
            this.tvXunjian.Size = new System.Drawing.Size(217, 0);
            this.tvXunjian.TabIndex = 1;
            this.tvXunjian.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // xPanderPanel4
            // 
            this.xPanderPanel4.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Bold);
            this.xPanderPanel4.ColorScheme = BSE.Windows.Forms.ColorScheme.Custom;
            this.xPanderPanel4.Controls.Add(this.tvJiChu);
            this.xPanderPanel4.CustomColors.BackColor = System.Drawing.SystemColors.Control;
            this.xPanderPanel4.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(65)))), ((int)(((byte)(118)))));
            this.xPanderPanel4.CustomColors.CaptionCheckedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(154)))));
            this.xPanderPanel4.CustomColors.CaptionCheckedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(166)))), ((int)(((byte)(76)))));
            this.xPanderPanel4.CustomColors.CaptionCheckedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(116)))));
            this.xPanderPanel4.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel4.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel4.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.xPanderPanel4.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(164)))), ((int)(((byte)(224)))));
            this.xPanderPanel4.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.xPanderPanel4.CustomColors.CaptionPressedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(128)))), ((int)(((byte)(62)))));
            this.xPanderPanel4.CustomColors.CaptionPressedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(154)))));
            this.xPanderPanel4.CustomColors.CaptionPressedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(177)))), ((int)(((byte)(109)))));
            this.xPanderPanel4.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(222)))));
            this.xPanderPanel4.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(203)))), ((int)(((byte)(136)))));
            this.xPanderPanel4.CustomColors.CaptionSelectedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(225)))), ((int)(((byte)(172)))));
            this.xPanderPanel4.CustomColors.CaptionSelectedText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel4.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel4.CustomColors.FlatCaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.xPanderPanel4.CustomColors.FlatCaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.xPanderPanel4.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xPanderPanel4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel4.Image = null;
            this.xPanderPanel4.Name = "xPanderPanel4";
            this.xPanderPanel4.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007;
            this.xPanderPanel4.Size = new System.Drawing.Size(219, 25);
            this.xPanderPanel4.TabIndex = 3;
            this.xPanderPanel4.Text = "基础管理";
            this.xPanderPanel4.ToolTipTextCloseIcon = null;
            this.xPanderPanel4.ToolTipTextExpandIconPanelCollapsed = null;
            this.xPanderPanel4.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // tvJiChu
            // 
            this.tvJiChu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvJiChu.Location = new System.Drawing.Point(1, 25);
            this.tvJiChu.Name = "tvJiChu";
            treeNode19.Name = "frmOrganization";
            treeNode19.Text = "组织结构设置";
            treeNode20.Name = "frmEmployee";
            treeNode20.Text = "人员设置";
            treeNode21.Name = "frmArea";
            treeNode21.Text = "地点设置";
            treeNode22.Name = "frmPost";
            treeNode22.Text = "岗位设置";
            this.tvJiChu.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode19,
            treeNode20,
            treeNode21,
            treeNode22});
            this.tvJiChu.Size = new System.Drawing.Size(217, 0);
            this.tvJiChu.TabIndex = 2;
            this.tvJiChu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // xPanderPanel5
            // 
            this.xPanderPanel5.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Bold);
            this.xPanderPanel5.ColorScheme = BSE.Windows.Forms.ColorScheme.Custom;
            this.xPanderPanel5.Controls.Add(this.tvCard);
            this.xPanderPanel5.CustomColors.BackColor = System.Drawing.SystemColors.Control;
            this.xPanderPanel5.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(65)))), ((int)(((byte)(118)))));
            this.xPanderPanel5.CustomColors.CaptionCheckedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(154)))));
            this.xPanderPanel5.CustomColors.CaptionCheckedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(166)))), ((int)(((byte)(76)))));
            this.xPanderPanel5.CustomColors.CaptionCheckedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(116)))));
            this.xPanderPanel5.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel5.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel5.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.xPanderPanel5.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(164)))), ((int)(((byte)(224)))));
            this.xPanderPanel5.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.xPanderPanel5.CustomColors.CaptionPressedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(128)))), ((int)(((byte)(62)))));
            this.xPanderPanel5.CustomColors.CaptionPressedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(154)))));
            this.xPanderPanel5.CustomColors.CaptionPressedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(177)))), ((int)(((byte)(109)))));
            this.xPanderPanel5.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(222)))));
            this.xPanderPanel5.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(203)))), ((int)(((byte)(136)))));
            this.xPanderPanel5.CustomColors.CaptionSelectedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(225)))), ((int)(((byte)(172)))));
            this.xPanderPanel5.CustomColors.CaptionSelectedText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel5.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel5.CustomColors.FlatCaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.xPanderPanel5.CustomColors.FlatCaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.xPanderPanel5.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xPanderPanel5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel5.Image = null;
            this.xPanderPanel5.Name = "xPanderPanel5";
            this.xPanderPanel5.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007;
            this.xPanderPanel5.Size = new System.Drawing.Size(219, 25);
            this.xPanderPanel5.TabIndex = 4;
            this.xPanderPanel5.Text = "卡片管理";
            this.xPanderPanel5.ToolTipTextCloseIcon = null;
            this.xPanderPanel5.ToolTipTextExpandIconPanelCollapsed = null;
            this.xPanderPanel5.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // tvCard
            // 
            this.tvCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvCard.Location = new System.Drawing.Point(1, 25);
            this.tvCard.Name = "tvCard";
            treeNode23.Name = "frmRfid";
            treeNode23.Text = "卡片管理";
            this.tvCard.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode23});
            this.tvCard.Size = new System.Drawing.Size(217, 0);
            this.tvCard.TabIndex = 3;
            this.tvCard.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // frmMainTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 490);
            this.Controls.Add(this.xPanderPanelList1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HideOnClose = true;
            this.Name = "frmMainTool";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft;
            this.Text = "工具窗口";
            this.Load += new System.EventHandler(this.frmMainTool_Load);
            this.xPanderPanelList1.ResumeLayout(false);
            this.xPanderPanel1.ResumeLayout(false);
            this.xPanderPanel2.ResumeLayout(false);
            this.xPanderPanel3.ResumeLayout(false);
            this.xPanderPanel4.ResumeLayout(false);
            this.xPanderPanel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private BSE.Windows.Forms.XPanderPanelList xPanderPanelList1;
        private BSE.Windows.Forms.XPanderPanel xPanderPanel1;
        private BSE.Windows.Forms.XPanderPanel xPanderPanel2;
        private BSE.Windows.Forms.XPanderPanel xPanderPanel3;
        private BSE.Windows.Forms.XPanderPanel xPanderPanel4;
        private System.Windows.Forms.TreeView tvPlan;
        private System.Windows.Forms.TreeView tvSearch;
        private System.Windows.Forms.TreeView tvXunjian;
        private BSE.Windows.Forms.XPanderPanel xPanderPanel5;
        private System.Windows.Forms.TreeView tvJiChu;
        private System.Windows.Forms.TreeView tvCard;


    }
}