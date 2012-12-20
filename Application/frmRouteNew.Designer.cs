namespace WorkStation
{
    partial class frmRouteNew
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
            this.cboSiteArea = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbRouteName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbRouteAlias = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnTrue = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cboInOrder = new System.Windows.Forms.ComboBox();
            this.tvLogicalPoint = new System.Windows.Forms.TreeView();
            this.label5 = new System.Windows.Forms.Label();
            this.tvPhysicalPoint = new System.Windows.Forms.TreeView();
            this.btnAddTemplate = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnShowAdd = new System.Windows.Forms.Button();
            this.cboState = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboSiteArea
            // 
            this.cboSiteArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSiteArea.FormattingEnabled = true;
            this.cboSiteArea.Location = new System.Drawing.Point(72, 94);
            this.cboSiteArea.Name = "cboSiteArea";
            this.cboSiteArea.Size = new System.Drawing.Size(183, 20);
            this.cboSiteArea.TabIndex = 0;
            this.cboSiteArea.SelectedIndexChanged += new System.EventHandler(this.cboSiteArea_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "所在厂区";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "路线名称";
            // 
            // tbRouteName
            // 
            this.tbRouteName.Location = new System.Drawing.Point(72, 25);
            this.tbRouteName.Name = "tbRouteName";
            this.tbRouteName.Size = new System.Drawing.Size(183, 21);
            this.tbRouteName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "路线别名";
            // 
            // tbRouteAlias
            // 
            this.tbRouteAlias.Location = new System.Drawing.Point(72, 61);
            this.tbRouteAlias.Name = "tbRouteAlias";
            this.tbRouteAlias.Size = new System.Drawing.Size(183, 21);
            this.tbRouteAlias.TabIndex = 5;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(720, 394);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnTrue
            // 
            this.btnTrue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTrue.Location = new System.Drawing.Point(622, 394);
            this.btnTrue.Name = "btnTrue";
            this.btnTrue.Size = new System.Drawing.Size(75, 23);
            this.btnTrue.TabIndex = 7;
            this.btnTrue.Text = "添加";
            this.btnTrue.UseVisualStyleBackColor = true;
            this.btnTrue.Click += new System.EventHandler(this.btnTrue_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "顺序巡检";
            // 
            // cboInOrder
            // 
            this.cboInOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInOrder.FormattingEnabled = true;
            this.cboInOrder.Location = new System.Drawing.Point(72, 131);
            this.cboInOrder.Name = "cboInOrder";
            this.cboInOrder.Size = new System.Drawing.Size(183, 20);
            this.cboInOrder.TabIndex = 9;
            // 
            // tvLogicalPoint
            // 
            this.tvLogicalPoint.Location = new System.Drawing.Point(12, 25);
            this.tvLogicalPoint.Name = "tvLogicalPoint";
            this.tvLogicalPoint.Size = new System.Drawing.Size(169, 298);
            this.tvLogicalPoint.TabIndex = 10;
            this.tvLogicalPoint.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvLogicalPoint_BeforeSelect);
            this.tvLogicalPoint.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvLogicalPoint_NodeMouseDoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "备注";
            // 
            // tvPhysicalPoint
            // 
            this.tvPhysicalPoint.Location = new System.Drawing.Point(6, 6);
            this.tvPhysicalPoint.Name = "tvPhysicalPoint";
            this.tvPhysicalPoint.Size = new System.Drawing.Size(165, 271);
            this.tvPhysicalPoint.TabIndex = 14;
            this.tvPhysicalPoint.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvPhysicalPoint_BeforeSelect);
            this.tvPhysicalPoint.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvPhysicalPoint_NodeMouseDoubleClick);
            // 
            // btnAddTemplate
            // 
            this.btnAddTemplate.Location = new System.Drawing.Point(186, 89);
            this.btnAddTemplate.Name = "btnAddTemplate";
            this.btnAddTemplate.Size = new System.Drawing.Size(76, 23);
            this.btnAddTemplate.TabIndex = 22;
            this.btnAddTemplate.Text = "添加模板";
            this.btnAddTemplate.UseVisualStyleBackColor = true;
            this.btnAddTemplate.Click += new System.EventHandler(this.btnAddTemplate_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Location = new System.Drawing.Point(186, 214);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(75, 23);
            this.btnMoveDown.TabIndex = 21;
            this.btnMoveDown.Text = "下移";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Location = new System.Drawing.Point(186, 178);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(75, 23);
            this.btnMoveUp.TabIndex = 20;
            this.btnMoveUp.Text = "上移";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(186, 147);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 19;
            this.btnDel.Text = ">";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(186, 118);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 18;
            this.btnAdd.Text = "<";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tbComment
            // 
            this.tbComment.Location = new System.Drawing.Point(72, 197);
            this.tbComment.Multiline = true;
            this.tbComment.Name = "tbComment";
            this.tbComment.Size = new System.Drawing.Size(183, 91);
            this.tbComment.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnShowAdd);
            this.groupBox1.Controls.Add(this.cboState);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbComment);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboInOrder);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbRouteAlias);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbRouteName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboSiteArea);
            this.groupBox1.Location = new System.Drawing.Point(12, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 345);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "添加/修改路线信息";
            // 
            // btnShowAdd
            // 
            this.btnShowAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowAdd.Location = new System.Drawing.Point(180, 310);
            this.btnShowAdd.Name = "btnShowAdd";
            this.btnShowAdd.Size = new System.Drawing.Size(75, 23);
            this.btnShowAdd.TabIndex = 27;
            this.btnShowAdd.Text = "设置巡检点";
            this.btnShowAdd.UseVisualStyleBackColor = true;
            this.btnShowAdd.Click += new System.EventHandler(this.btnShowAdd_Click);
            // 
            // cboState
            // 
            this.cboState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboState.FormattingEnabled = true;
            this.cboState.Location = new System.Drawing.Point(72, 163);
            this.cboState.Name = "cboState";
            this.cboState.Size = new System.Drawing.Size(183, 20);
            this.cboState.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 25;
            this.label6.Text = "状态";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tabControl1);
            this.groupBox2.Controls.Add(this.btnAddTemplate);
            this.groupBox2.Controls.Add(this.btnMoveDown);
            this.groupBox2.Controls.Add(this.btnMoveUp);
            this.groupBox2.Controls.Add(this.btnDel);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.tvLogicalPoint);
            this.groupBox2.Location = new System.Drawing.Point(319, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(478, 345);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "添加巡检点";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(278, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(188, 308);
            this.tabControl1.TabIndex = 23;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tvPhysicalPoint);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(180, 283);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "巡检点";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.treeView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(180, 283);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "模版";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(6, 6);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(165, 271);
            this.treeView1.TabIndex = 15;
            // 
            // frmRouteNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(821, 429);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnTrue);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmRouteNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "路线详细信息";
            this.Load += new System.EventHandler(this.frmAddRoutName_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ComboBox cboSiteArea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox tbRouteName;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox tbRouteAlias;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnTrue;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cboInOrder;
        private System.Windows.Forms.TreeView tvLogicalPoint;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TreeView tvPhysicalPoint;
        private System.Windows.Forms.Button btnAddTemplate;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        public System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnShowAdd;
        public System.Windows.Forms.ComboBox cboState;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TreeView treeView1;
    }
}