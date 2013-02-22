using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Nodes;
using System.IO;

namespace WorkStation
{
    public partial class frmTest : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public frmTest()
        {
            InitializeComponent();
        }
        private void CreateColumns()
        {
            string[] captions = { "FullName", "Name", "Type", "Size", "Attribute", "Check" };
            for (int i = 0; i < 6; i++)
            {
                treeList1.Columns.Add();
                treeList1.Columns[i].Caption = captions[i];
                // VisibleIndex为-1表示隐藏
                treeList1.Columns[i].VisibleIndex = (i == 0) ? -1 : i;
                treeList1.Columns[i].OptionsColumn.AllowEdit = false;
                if (i == 5)
                {
                    //给第五列添加一个选择框，本列可编辑               

                    //所使用的“repository 项”必须被添加到 TreeList 的内部或外部存储库中

                    //treeList1.Columns[i].ColumnEdit = repositoryItemCheckEdit1;
                    treeList1.Columns[i].OptionsColumn.AllowEdit = true;
                }
            }
        }

        private void InitDrives()
        {
            treeList1.BeginUnboundLoad();
            TreeListNode node;
            try
            {
                string[] root = Directory.GetLogicalDrives();


                foreach (string s in root)
                {
                    node = treeList1.AppendNode(new object[] { s, s, "Logical Driver", null, null, false }, null);
                    node.HasChildren = true;
                    node.Tag = true;
                }
            }
            catch { }
            treeList1.EndUnboundLoad();
        }

        private void InitFolders(string path, TreeListNode pNode, bool check)
        {
            treeList1.BeginUnboundLoad();
            TreeListNode node;
            DirectoryInfo di;
            try
            {
                string[] root = Directory.GetDirectories(path);
                foreach (string s in root)
                {
                    try
                    {
                        di = new DirectoryInfo(s);
                        node = treeList1.AppendNode(new object[] { s, di.Name, "Folder", null, di.Attributes, check }, pNode);
                        node.HasChildren = true;
                        if (node.HasChildren)
                            node.Tag = true;
                    }
                    catch { }
                }
            }
            catch { }
            InitFiles(path, pNode, check);
            treeList1.EndUnboundLoad();
        }


        private void InitFiles(string path, TreeListNode pNode, bool check)
        {
            TreeListNode node;
            FileInfo fi;
            try
            {
                string[] root = Directory.GetFiles(path);
                foreach (string s in root)
                {
                    fi = new FileInfo(s);
                    node = treeList1.AppendNode(new object[] { s, fi.Name, "File", fi.Length, fi.Attributes, check }, pNode);
                    node.HasChildren = false;
                }
            }
            catch { }
        }

        private void treeList1_BeforeExpand(object sender, DevExpress.XtraTreeList.BeforeExpandEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                Cursor currentCursor = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;
                InitFolders(e.Node.GetDisplayText("FullName"), e.Node, (bool)e.Node.GetValue("Check"));
                e.Node.Tag = null;
                Cursor.Current = currentCursor;
            }
        }

        private void frmTest_Load(object sender, EventArgs e)
        {
            CreateColumns();
            InitDrives();
        }


    }
}
