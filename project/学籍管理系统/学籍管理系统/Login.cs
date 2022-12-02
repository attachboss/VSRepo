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

namespace 学籍管理系统
{
    public partial class Login : Form
    {
        public static bool islogin = false;
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
            Login login = new Login();
            #region 链接
            string connectionStr = "Data Source=LAPTOP-ARN2CV9O;Initial Catalog=CyberCampus;User ID=sa;Password=08001402";
            #endregion
            using (SqlConnection SqlCon = new SqlConnection(connectionStr))
            {
                SqlCon.Open();
                //string sql = "select * from Spassword where Sno='" + this.textBoxImportAdmin.Text + "' and Spassword='" + this.textBoxImportPsw.Text + "'";
                string sql = string.Format("select * from Spassword where Sno='{0}' and Spassword = '{1}'", textBoxImportAdmin.Text, textBoxImportPsw.Text);
                SqlCommand cmd = new SqlCommand(sql, SqlCon);
                cmd.CommandType = CommandType.Text;
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    MessageBox.Show("登录成功");
                    islogin = true;
                    Mainform mainform = new Mainform();
                    mainform.AdministratorChanged(textBoxImportAdmin.Text);
                    this.Hide();
                    mainform.Show();
                }
                else if (this.textBoxImportAdmin.Text == "" || this.textBoxImportPsw.Text == "")
                {
                    MessageBox.Show("用户名或密码不能为空！", "提示");
                }
                else
                {
                    MessageBox.Show("用户名或密码不正确！");
                }
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
