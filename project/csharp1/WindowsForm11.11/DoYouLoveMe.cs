using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm11._11
{
    public partial class DoYouLoveMe : Form
    {
        public DoYouLoveMe()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("gun");
            this.Close();
        }

        /// <summary>
        /// 当光标进入控件可见部分时，给按钮一个新的位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_MouseEnter(object sender, EventArgs e)
        {
            //给按钮一个新坐标，活动的最大宽度为窗体宽度减去按钮宽度
            int x = this.ClientSize.Width- dont_love.Width;
            int y = this.ClientSize.Height - dont_love.Height;
            Random r = new Random();
            dont_love.Location = new Point(r.Next(0,x+1),r.Next(0,y+1));

        }
    }
}
