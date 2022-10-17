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
    public partial class MIDI窗体 : Form
    {
        public MIDI窗体()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 在父
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 显示子窗体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            form1.MdiParent = this;
            Form2 form2 = new Form2();
            form2.Show();
            form2.MdiParent = this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 横向排列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void 纵向排列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }
    }
}
