using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
namespace WorkStation
{
    public partial class frmImage : Form
    {
        public bool DataChanged = false;
        public bool isRouteInOrder = false;
        public frmImage()
        {
            InitializeComponent();

        }
        /// <summary>
        /// 获得巡检路线上的巡检点
        /// </summary>         
        Graphics g;
        private Point pointStart, pointDestion, pointOffset;       
        private void Form1_Load(object sender, EventArgs e)
        {
            bind();
        }
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void bind()
        {
            string selectRoute = "select * from CheckRoute";
            DataSet ds = SqlHelper.ExecuteDataset(selectRoute);
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";
            this.comboBox1.SelectedIndex = -1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
        }
        /// <summary>
        /// 巡检路线选择
        /// </summary>
        IList<CPoint> checkPoints = null;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.checkPoints != null)
            {
                bool flag = false;
                foreach (CPoint p in this.checkPoints)
                {
                    if (p.DataChanged)
                    {
                        flag = true;
                        break;
                    }
                }

                if (flag)
                {
                    DialogResult result = MessageBox.Show("保存坐标位置", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        SaveRoutePoint();
                    }
                    else
                    {
                       //return;
                    }
                }
            }

            List<Control> list = new List<Control>();
            foreach (Control c in this.pictureBox1.Controls)
                if (c is CPoint)
                    list.Add(c);

            foreach (Control c in list)
                this.pictureBox1.Controls.Remove(c); 

            //获取数据库存放的图片
            //byte[] imageBytes; 
            //string GetPicture = "select BackgroundImage from CheckRoute where ID=" + this.comboBox1.SelectedValue.ToString();
            //SqlDataReader sdr = SqlHelper.ExecuteReader(GetPicture);
            //if(sdr.Read())
            //{
            //    imageBytes=(byte[])sdr["BackgroundImage"];
            //    MemoryStream stream = new MemoryStream(imageBytes);
            //    Bitmap bmap = new Bitmap(stream);
            //    stream.Close();
            //    //将位图显示在界面的PictureBox控件中   
            //    this.pictureBox1.Image = bmap;

            //}
            //待续.......................................
            this.pictureBox1.Image = this.BackgroundImage;

            pointStart = Point.Empty;
            pointDestion = Point.Empty;
            pointOffset = Point.Empty;
            
            string GetPoints = "select LogicalCheckPoint.ID,LogicalCheckPoint.Name,PointX,PointY ,CheckRoute.Sequence from LogicalCheckPoint,CheckRoute where CheckRoute.ID=LogicalCheckPoint.Route_ID and CheckRoute.ID=" + this.comboBox1.SelectedValue.ToString();

                //判断巡检点是否有顺序
                string SelectPoint = "select Sequence from CheckRoute where ID=" + this.comboBox1.SelectedValue.ToString();
                int i = (int)SqlHelper.ExecuteScalar(SelectPoint);
                isRouteInOrder = i == 1 ? true : false;
           
                DataSet ds = SqlHelper.ExecuteDataset(GetPoints);
                DataTable dt = ds.Tables[0];
                checkPoints = new List<CPoint>();
                foreach (DataRow dr in dt.Rows)
                {
                    string s = dr["PointX"].ToString();
                    int x = string.IsNullOrEmpty(s) ? 0 : int.Parse(s);
                    s = dr["PointY"].ToString();
                    int y = string.IsNullOrEmpty(s) ? 0 : int.Parse(s);
                    string id = dr["ID"].ToString();
                    s = dr["Name"].ToString();
                    CPoint btn = new CPoint()
                    {
                        Location = new Point(x, y),
                        Text = s,
                        Size = new Size(80, 20),
                        BackColor = Color.Transparent,
                        Name = id
                    };
                    btn.MouseDown += new MouseEventHandler(btn_MouseDown);
                    btn.MouseUp += new MouseEventHandler(btn_MouseUp);
                    btn.MouseMove += new MouseEventHandler(btn_MouseMove);
                    pictureBox1.Controls.Add(btn);
                    checkPoints.Add(btn);
                }
                DrawRoute();           
            

        }          
        /// <summary>
        /// 鼠标之间的移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btn_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                CPoint p = sender as CPoint;
                p.DataChanged = true;
                string x, y;
                x = p.Location.X.ToString();
                y = p.Location.Y.ToString();
                button1.Text = x;
                button2.Text = y;
            }

        }

        void btn_MouseUp(object sender, MouseEventArgs e)
        {
            DrawRoute();
        }

        void btn_MouseDown(object sender, MouseEventArgs e)
        {
            Point p = new Point() { X = Cursor.Position.X, Y = Cursor.Position.Y };
            p = this.PointToClient(p);
            if (e.Button == MouseButtons.Left)
                if (pointStart == Point.Empty)
                    pointStart = p;
                else
                    pointDestion = p;         

        }       

        private void button3_Click(object sender, EventArgs e)
        {
            SaveRoutePoint();
        }
        /// <summary>
        /// 点与点之间画直线
        /// </summary>
        private void DrawRoute()
        {
            if (!isRouteInOrder) return;

            if (checkPoints.Count <= 1) return;
            Pen pen = new Pen(new SolidBrush(Color.Red));
            Image tmp = new Bitmap(this.BackgroundImage.Clone() as Image);
            g = Graphics.FromImage(tmp);
            Point[] points = new Point[checkPoints.Count];

            for (int i = 0; i < this.checkPoints.Count; i++)
            {
                Point p  = checkPoints[i].Location;
                points[i] = new Point() { X = p.X + 13, Y = p.Y + 14 };
            }        
            
            pen.Width = 1;
            //增加线帽
           //pen.CustomEndCap = new System.Drawing.Drawing2D.AdjustableArrowCap(4, 6);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.DrawLines(pen, points);
            this.pictureBox1.Image = tmp;
        }
        /// <summary>
        /// 判断完后，保存巡检点
        /// </summary>
        private void SaveRoutePoint()
        {
            foreach (CPoint p in this.checkPoints)
            {
                if (p.DataChanged)
                {
                    SavePoint(p);
                }
            }
        }
        /// <summary>
        /// 保存巡检点
        /// </summary>
        /// <param name="p"></param>
        private void SavePoint(CPoint p)
        {
            string sql = "update LogicalCheckPoint set PointX=@PointX,PointY=@PointY where ID={0}";
            sql = string.Format(sql, p.Name);
            SqlParameter[] par = new SqlParameter[] { new SqlParameter("@PointX",SqlDbType.NVarChar),
                                                      new SqlParameter("@PointY",SqlDbType.NVarChar)};

            par[0].Value = p.Location.X.ToString();
            par[1].Value = p.Location.Y.ToString();
            int a = SqlHelper.ExecuteNonQuery(sql, par);
            if (a <= 0)
                MessageBox.Show("保存失败");            
        }
    }
}
