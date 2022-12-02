using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 学籍管理系统
{
    public partial class Mainform : Form
    {
        public Mainform()
        {
            InitializeComponent();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Login.islogin == false)
            {
                Login login = new Login();
                login.Show();
            }
            else
            {
                MessageBox.Show("您已登录！", "提示");
            }
        }


        public void AdministratorChanged(string userName)
        {
            this.toolStripStatusLabel3.Text = string.Format(userName);
        }

        private void 学生信息管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentInfor infor = new StudentInfor();
            infor.Show();
        }

        private void 课程信息管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CourseInfor infor = new CourseInfor();
            infor.Show();
        }

        private void 操作员管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdministratorManage administratorManage = new AdministratorManage();
            administratorManage.Show();
        }


        private void 帮助文档ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "文本文件|*.txt|图片文件|*.jpg|媒体文件|*.wmv|所有文件|*.*";
            openFileDialog.ShowDialog();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("欢迎使用学籍管理系统！");
        }
    }
}
