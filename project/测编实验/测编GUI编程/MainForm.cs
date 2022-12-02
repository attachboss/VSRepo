using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 测编GUI编程
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        #region 登录

        private void 登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
        } 
        #endregion
        #region 窗体
        private void 横向排列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void 纵向排列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void 关闭所有子窗体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in MdiChildren)
            {
                item.Close();
            }
        }
        #endregion
        #region 系统
        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = @"D:\File\专业课\C\测编";
            openFile.Filter = "txt files(*.txt)|*.txt|All files(*.*)|*.*";
            openFile.FilterIndex = 0;
            openFile.RestoreDirectory = true;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("打开文件", openFile.FileName);
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        #endregion
        #region 功能
        #region 交会计算
        private void 前方交会ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ForwardIntersection forwardIntersection = new ForwardIntersection();
            forwardIntersection.MdiParent = this;
            forwardIntersection.Show();
        }

        private void 距离交会ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DistanceIntersection distanceIntersection = new DistanceIntersection();
            distanceIntersection.MdiParent = this;
            distanceIntersection.Show();
        }

        private void 侧方交会ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LateralIntersection lateralIntersection = new LateralIntersection();
            lateralIntersection.MdiParent = this;
            lateralIntersection.Show();
        }

        #endregion

        private void 计算坐标方位角及距离ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Azumith_Distance azumith_Distance = new Azumith_Distance();
            azumith_Distance.Show();
            azumith_Distance.MdiParent = this;
        }

        private void 角度转换计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AngleCalculate angleCalculate = new AngleCalculate();
            angleCalculate.MdiParent = this;
            angleCalculate.Show();
        }

        private void 矩阵运算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MatrixCal matrixCal = new MatrixCal();
            matrixCal.MdiParent = this;
            matrixCal.Show();
        }
        #endregion

    }
}
