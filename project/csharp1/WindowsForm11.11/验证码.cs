using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm11._11
{
    public partial class 验证码 : Form
    {
        public 验证码()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            string verificationCodeStr = null;
            for (int i = 0; i < 4; i++)
            {
                verificationCodeStr += r.Next(0, 9 + 1).ToString();
            }
            Bitmap bmp = new Bitmap(120, 30);
            Graphics pic = Graphics.FromImage(bmp);
            //将图片镶嵌到PictureBox中
            pictureBox1.Image = bmp;
            string[] font = { "黑体", "宋体", "仿宋", "楷书" };
            Color[] colos = { Color.Chocolate, Color.DarkBlue, Color.Purple, Color.DarkRed };
            for (int i = 0; i < 4; i++)
            {
                Point p = new Point(i * 15, 0);
                pic.DrawString(verificationCodeStr[i].ToString(), new Font(font[r.Next(0, 3 + 1)], 15, FontStyle.Bold), new SolidBrush(colos[r.Next(0, 3 + 1)]), p);
            }
            for (int i = 0; i < 20; i++)
            {
                Point p1 = new Point(r.Next(0, bmp.Width), r.Next(0, bmp.Height));
                Point p2 = new Point(r.Next(0, bmp.Width), r.Next(0, bmp.Height));
                pic.DrawLine(new Pen(Brushes.Green), p1, p2);
            }
            for (int i = 0; i < 100; i++)
            {
                Point p = new Point(r.Next(0, bmp.Width), r.Next(0, bmp.Height));
                bmp.SetPixel(p.X, p.Y, Color.Black);
            }
        }
    }
}
