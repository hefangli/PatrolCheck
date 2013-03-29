using System;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace System.Windows.Forms
{
    public class CPoint: UserControl
    {
        public bool DataChanged = false;
        private Point mouseDownPoint = new Point();
        public WindowsFormsApplication1.Circle circle1;
        private bool isSelected = false;
        public CPoint()
        {
            InitializeComponent();
           
            //this.circle1.Location = new Point() { Y = ClientRectangle.Top + (this.Width - this.circle1.Width) / 2 };
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.MouseDown += new MouseEventHandler(Control_MouseDown);
            this.MouseUp += new MouseEventHandler(Control_MouseUp);
            this.MouseMove += new MouseEventHandler(Control_MouseMove);
          
        }

        void Control_MouseMove(object sender, MouseEventArgs e)
        {
            Control btn = sender as Control;
            if (isSelected)
            {
                btn.Left = btn.Left + (Cursor.Position.X - mouseDownPoint.X);
                btn.Top = btn.Top + (Cursor.Position.Y - mouseDownPoint.Y);
                mouseDownPoint.X = Cursor.Position.X;
                mouseDownPoint.Y = Cursor.Position.Y;
            }             

        }
      
        void Control_MouseUp(object sender, MouseEventArgs e)
        {
            isSelected = false;
            this.Invalidate();      
           
        }

        void Control_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDownPoint.X = Cursor.Position.X;
                mouseDownPoint.Y = Cursor.Position.Y;
                isSelected = true;
            }           
        }
       
        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;
            if (isSelected)
                this.BackColor = Color.Silver;
            else
                this.BackColor = Color.Transparent;
            int buttonHeight = (int)g.MeasureString(this.Text, this.Font).Height;          
            //g.DrawEllipse(new Pen(this.ForeColor), 1, 1, buttonHeight, buttonHeight);
            //Brush b=  new SolidBrush(Color.Green);
            //g.FillEllipse(b, new Rectangle(1, 1, buttonHeight, buttonHeight));
            //this.circle1.Height1 = buttonHeight;          
            g.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), ClientRectangle.Left + buttonHeight + 5, ClientRectangle.Top + 3);      
        }

        private void InitializeComponent()
        {
            this.circle1 = new WindowsFormsApplication1.Circle();
            this.SuspendLayout();
            // 
            // circle1
            // 
            this.circle1.BackColor = System.Drawing.Color.Transparent;
            this.circle1.ForeColor = System.Drawing.Color.SeaGreen;
            this.circle1.Location = new System.Drawing.Point(10, 9);
            this.circle1.Name = "circle1";
            this.circle1.Size = new System.Drawing.Size(11, 11);
            this.circle1.TabIndex = 0;
            // 
            // CPoint
            // 
            this.Controls.Add(this.circle1);
            this.Name = "CPoint";
            this.Size = new System.Drawing.Size(100, 34);
            this.ResumeLayout(false);

        }

      

        
    }
}
