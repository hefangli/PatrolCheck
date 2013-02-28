using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WorkStation
{
    public partial class frmOrganizationNewAreaChose : Form
    {
        public frmOrganizationNewAreaChose()
        {
            InitializeComponent();
            BindTreeList();
        }


        private void BindTreeList()
        {
            DataSet ds = SqlHelper.ExecuteDataset("Select *,(select meaning from codes where code=Area.ValidState and Purpose='ValidState') as ValidStateMeaning from Area where validstate=" + (Int32)CodesValidState.Exit);
            tlArea.DataSource = ds.Tables[0];
        }

        private void barButtonItemChose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }
    }
}
