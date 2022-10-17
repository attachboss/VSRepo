using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Shapes;
using System.Drawing.Drawing2D;

namespace WindowsForm11._11
{
    public partial class GDI : Form
    {
        public GDI()
        {
            InitializeComponent();
        }

        private void GDI_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //创建GDI对象
            Graphics pic = this.CreateGraphics();
            //创建画笔对象
            Pen pen = new Pen(Brushes.Goldenrod);
            //创建两点坐标
            Point p1 = new Point(30, 50);
            Point p2 = new Point(100, 120);
            pic.DrawLine(pen, p1, p2);
        }

        private void GDI_Paint(object sender, PaintEventArgs e)
        {
            //button1_Click(sender,e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics pic = this.CreateGraphics();
            Pen p = new Pen(Brushes.Black);
            System.Drawing.Rectangle borderRectangle = new System.Drawing.Rectangle(new Point(100,100), new Size(120, 60));
            pic.DrawEllipse(p, borderRectangle);
            pic.TranslateTransform(160, 130);
            pic.RotateTransform(45.1f);
            pic.TranslateTransform(-160, -130);
            pic.DrawEllipse(p, borderRectangle);
            pic.Dispose();
        }
    }
}
