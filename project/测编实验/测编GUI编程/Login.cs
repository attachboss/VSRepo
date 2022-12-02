using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 测编GUI编程
{
    public partial class Login : Form
    {

        private bool islogin;
        internal bool Islogin { get => islogin; set => islogin = value; }

        public Login()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 登录界面窗体，当用户通过主窗体调用时加载1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.textBoxImportAdmin.Text == "1" && this.textBoxImportPsw.Text == "1")
            {
                MessageBox.Show("登录成功!", "提示");
                Islogin = true;
                CheckLogin();
                this.Hide();
            }
            else if (this.textBoxImportAdmin.Text == "" || this.textBoxImportPsw.Text == "")
            {
                MessageBox.Show("用户名或密码不能为空！", "提示");
            }
            else
            {
                MessageBox.Show("用户名或密码不正确！", "提示");
            }
        }

        public void CheckLogin()
        {
            if(Islogin == true)
            {
                MainForm mainForm = new MainForm();
                mainForm.Show();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
