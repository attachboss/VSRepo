using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsForm11._11
{
    public partial class 图片浏览器 : Form
    {
        public 图片浏览器()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 窗体加载时先显示一张图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 图片浏览器_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users\14345\Pictures\Download\0a5dd82eb6b61ef2764b87c04cce32fe.jpg");

        }
        string[] path = Directory.GetFiles(@"C:\Users\14345\Pictures\Download","*.jpg");
        int i = 0;

        /// <summary>
        /// 点击时更换到下一张图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            i++;
            if (i == path.Length)
            {
                i = 0;
            }
            pictureBox1.Image = Image.FromFile(path[i]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            i--;
            if (i < 0)
            {
                i = path.Length - 1;
            }
            pictureBox1.Image = Image.FromFile(path[i]);

        }
    }
}
