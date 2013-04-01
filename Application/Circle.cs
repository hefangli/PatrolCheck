using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication1
{
    public class Circle: Control
    {
        Color back = Color.Empty;

        public Circle()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true); 
            this.BackColor = Color.Transparent;
            back = Color.Green;
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            back = Color.Blue;
            this.Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            back = this.ForeColor;
            this.Invalidate();
        }

        int height = 10;
        //public int Height1
        //{
        //    get { return height; }
        //    set
        //    {
        //        if( height != value)
        //        {
        //            height = value;
        //            this.Invalidate();
        //        }
        //    }
        //}
        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;
            g.DrawEllipse(new Pen(back), 1, 1, height, height);
            Brush b = new SolidBrush(back);
            g.FillEllipse(b, new Rectangle(1, 1, height, height));
        }
    }
}
