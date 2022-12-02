using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 学籍管理系统
{
    public partial class AdministratorManage : Form
    {
        #region 连接
        static string conStr = "Data Source=.;Initial Catalog=CyberCampus;User Id=sa;Password=08001402;";
        #endregion
        public AdministratorManage()
        {
            InitializeComponent();
        }
        private void AdministratorManage_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
        }


        private void 注册新用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = true;

        }

        private void 注销用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
        }


        /// <summary>
        /// 调用数据库过程(一致)
        /// </summary>
        /// <param name="sql"></param>
        private static void SqlMethod(string sql)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    try
                    {
                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("成功!", "提示");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }


        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_PwdChange_Click(object sender, EventArgs e)
        {
            string oldPwd = textBox1.Text;
            string newPwd = textBox2.Text;
            string comFirmPwd = textBox3.Text;
            if (oldPwd.Equals(newPwd))
            {
                MessageBox.Show("要修改的密码不能和之前的相同", "提示");
            }
            else if (comFirmPwd!= newPwd)
            {
                MessageBox.Show("两次输入的密码不一样!","错误");
            }
            else
            {
                string sql = String.Format("update Spassword set Spassword={0} where Sno={1}", newPwd, oldPwd);
                SqlMethod(sql);
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
        }

        private void button_NewUser_Click(object sender, EventArgs e)
        {
            string newUser = textBox4.Text;
            string pwd1 = textBox5.Text;
            string pwd2 = textBox6.Text;
            if (pwd1 != pwd2)
            {
                MessageBox.Show("两次输入的密码不一样!", "错误");
            }
            else
            {
                string sql = String.Format("insert into Spassword([Sno], [Spassword])  values('{0}','{1}')",newUser,pwd1);
                SqlMethod(sql);
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
            }
        }
    }
}
