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
    public partial class TextBox : Form
    {
        public TextBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 当文本框中的数值改变的时候把值赋给label1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Text = textBox1.Text;
        }
    }
}
