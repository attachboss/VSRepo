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
    public partial class 浏览器控件 : Form
    {
        public 浏览器控件()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = this.textBox1.Text;
            Uri uri = new Uri("http://"+text);
            this.webBrowser1.Url = uri;
        }
    }
}
