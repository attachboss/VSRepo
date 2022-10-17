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
    public partial class CourseInfor : Form
    {
        public CourseInfor()
        {
            InitializeComponent();
        }
        #region 链接
        string conStr = "Data Source=LAPTOP-ARN2CV9O;Initial Catalog=CyberCampus;User ID=sa;Password=08001402";
        #endregion
        #region list
        List<string> 课程名 = new List<string>();
        List<string> 课程代码 = new List<string>();
        List<string> 任课教师 = new List<string>();
        List<string> 学分 = new List<string>();
        List<string> 成绩 = new List<string>();
        List<List<string>> lists = new List<List<string>>();
        #endregion



        /// <summary>
        /// 清空所有输入信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Clear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }


        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }


        /// <summary>
        /// 当窗体加载的时候查询Course表中的所有数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CourseInfor_Load(object sender, EventArgs e)
        {
            QueryAll();
            ListAdd();
            PrintTable();
        }


        /// <summary>
        /// 将list<><>中的数据赋给listView控件
        /// </summary>
        private void PrintTable()
        {
            for (int k = 0; k < 课程代码.Count; k++)
            {
                string[][] student = new string[课程代码.Count][];
                for (int i = 0; i < 课程代码.Count; i++)
                {
                    student[i] = new string[lists.Count];
                }
                for (int i = 0; i < lists.Count; i++)
                {
                    for (int j = 0; j < 课程代码.Count; j++)
                    {
                        student[j][i] = lists[i][j];
                    }
                }
                ListViewItem[] lvItem = new ListViewItem[课程代码.Count];
                lvItem[k] = new ListViewItem(student[k]);
                listView1.Items.Add(lvItem[k]);
            }
        }


        /// <summary>
        /// 将每个list中的元素加入到list<><>中去
        /// </summary>
        private void ListAdd()
        {
            lists.Add(课程名);
            lists.Add(课程代码);
            lists.Add(任课教师);
            lists.Add(学分);
            lists.Add(成绩);
        }


        /// <summary>
        /// 查询语句(所有内容)
        /// </summary>
        private void QueryAll()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string sql = "select * from Course";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    ClearAllList();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        课程名.Add(reader.GetString(reader.GetOrdinal("课程名")));
                        课程代码.Add(reader.GetString(reader.GetOrdinal("课程代码")));
                        任课教师.Add(reader.GetString(reader.GetOrdinal("任课教师")));
                        学分.Add(reader.GetInt32(reader.GetOrdinal("学分")).ToString());
                        成绩.Add(reader.GetDouble(reader.GetOrdinal("成绩")).ToString());
                    }
                }
            }

        }


        /// <summary>
        /// 运行时清空所有list集合中的数据
        /// </summary>
        private void ClearAllList()
        {
            课程名.Clear();
            课程代码.Clear();
            任课教师.Clear();
            学分.Clear();
            成绩.Clear();
        }


        /// <summary>
        /// update语句添加新记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Update_Click(object sender, EventArgs e)
        {
            int s = 0;
            double sd = 0;
            string Sno = this.textBox1.Text;
            if (textBox4.Text == "")
                sd = 0;
            else
            {
                try
                { sd = Convert.ToDouble(textBox4.Text); }
                catch
                {
                    MessageBox.Show("请正确输入学分", "错误");
                    return;
                }
            }
            if (textBox5.Text == "")
                s = 0;
            else
            {
                try
                { s = Convert.ToInt32(textBox5.Text); }
                catch
                {
                    MessageBox.Show("请正确输入成绩", "错误");
                    return;
                }
            }
            using (SqlConnection con = new SqlConnection(conStr))
            {
                int r = -1;
                con.Open();
                string sql = String.Format("update Course set " +
                    "课程名='{0}'," +
                    "课程代码='{1}'," +
                    "任课教师='{2}' ," +
                    "学分={3} ," +
                    "成绩={4} ," +
                    "where 学号=@Sno", textBox1.Text, textBox2.Text, textBox3.Text, sd,s);
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Sno", Sno);
                    try
                    { r = cmd.ExecuteNonQuery(); }
                    catch
                    { MessageBox.Show("修改失败！", "提示"); }
                    finally
                    {
                        if (r > 0)
                        {
                            MessageBox.Show("修改完成", "提示");
                        }
                        else if (r == 0)
                        {
                            MessageBox.Show("没有找到数据", "提示");
                        }
                    }
                }
            }
        }


        /// <summary>
        /// select条件查询(最多支持5个条件，不支持子查询)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Select_Click(object sender, EventArgs e)
        {
            double s = 0;
            int select_s = 0;
            int conditionNum = 0;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string sql = "select * from Course where ";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    #region 拼写查询语句
                    if (textBox1.Text != "")
                    {
                        sql += String.Format("课程名='{0}'", textBox1.Text);
                        conditionNum++;
                    }
                    if (textBox2.Text != "")
                    {
                        if (conditionNum != 0)
                        {
                            sql += " and ";
                        }
                        sql += String.Format("课程代码='{0}'", textBox2.Text);
                        conditionNum++;
                    }
                    if (textBox3.Text != "")
                    {
                        if (conditionNum != 0)
                        {
                            sql += " and ";
                        }
                        sql += String.Format("任课教师='{0}'", textBox3.Text);
                        conditionNum++;
                    }
                    if (textBox4.Text != "")
                    {
                        if (textBox4.Text == "")
                            select_s = 0;
                        else
                        {
                            try
                            {
                                select_s = Convert.ToInt32(textBox4.Text);
                                conditionNum++;
                            }
                            catch
                            {
                                MessageBox.Show("请正确输入", "错误");
                            }
                        }
                        if (conditionNum != 0)
                        {
                            sql += " and ";
                        }
                        sql += String.Format("成绩={0}", select_s);
                    }
                    if (textBox5.Text != "")
                    {
                        if (textBox5.Text == "")
                            s = 0;
                        else
                        {
                            try
                            {
                                s = Convert.ToDouble(textBox5.Text);
                                conditionNum++;
                            }
                            catch
                            {
                                MessageBox.Show("请正确输入", "错误");
                            }
                        }
                        if (conditionNum != 0)
                        {
                            sql += " and ";
                        }
                        sql += String.Format("成绩={0}", s);
                    }
                    #endregion
                    ClearAllList();
                    try
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = sql;
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            课程名.Add(reader.GetString(reader.GetOrdinal("课程名")));
                            课程代码.Add(reader.GetString(reader.GetOrdinal("课程代码")));
                            任课教师.Add(reader.GetString(reader.GetOrdinal("任课教师")));
                            学分.Add(reader.GetInt32(reader.GetOrdinal("学分")).ToString());
                            成绩.Add(reader.GetDouble(reader.GetOrdinal("成绩")).ToString());
                        }
                        ListAdd();
                        listView1.Items.Clear();
                        PrintTable();
                    }
                    catch
                    {
                        MessageBox.Show("查询发生错误！", "错误");
                    }
                }
            }
        }


        /// <summary>
        /// 按钮按下时查询(所有)数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_SelectAll_Click(object sender, EventArgs e)
        {
            QueryAll();
            ListAdd();
            listView1.Items.Clear();
            PrintTable();
        }


        /// <summary>
        /// 插入一条数据(必须有课程代码)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Insert_Click(object sender, EventArgs e)
        {
            double sd = 0;
            int s = 0;
            string Sno = this.textBox2.Text;
            if (Sno == "")
            {
                MessageBox.Show("要插入的记录必须有课程代码！", "提示");
            }

            if (textBox4.Text == "")
                s = 0;
            else
            {
                try
                { s = Convert.ToInt32(textBox4.Text); }
                catch
                {
                    MessageBox.Show("请正确输入成绩", "错误");
                    return;
                }
            }

            if (textBox5.Text == "")
                sd = 0;
            else
            {
                try
                { sd = Convert.ToDouble(textBox5.Text); }
                catch
                {
                    MessageBox.Show("请正确输入学分", "错误");
                    return;
                }
            }
            using (SqlConnection con = new SqlConnection(conStr))
            {
                int r = -1;
                con.Open();
                string sql = String.Format("insert into Course([课程名], [课程代码], [任课教师], [学分], [成绩]) values(" +
                    "'{0}'," +
                    "'{1}'," +
                    "'{2}'," +
                    "{3}," +
                    "{4}" +
                    ")", textBox1.Text, textBox2.Text, textBox3.Text,s,sd);
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    try
                    { r = cmd.ExecuteNonQuery(); }
                    catch
                    { MessageBox.Show("添加失败！", "错误"); }
                    finally
                    {
                        if (r > 0)
                        {
                            MessageBox.Show("添加完成", "提示");
                        }
                    }
                }
            }
        }


        /// <summary>
        /// 删除语句(sql语句拼写同select)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Delete_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                int conditionNum = -1;
                int r = -1;
                con.Open();
                string sql = String.Format("delete from Course where ");
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    int select_s = 0;
                    double s = 0;
                    #region 拼写查询语句
                    if (textBox1.Text != "")
                    {
                        sql += String.Format("课程名='{0}'", textBox1.Text);
                        conditionNum++;
                    }
                    if (textBox2.Text != "")
                    {
                        if (conditionNum != 0)
                        {
                            sql += " and ";
                        }
                        sql += String.Format("课程代码='{0}'", textBox2.Text);
                        conditionNum++;
                    }
                    if (textBox3.Text != "")
                    {
                        if (conditionNum != 0)
                        {
                            sql += " and ";
                        }
                        sql += String.Format("任课教师='{0}'", textBox3.Text);
                        conditionNum++;
                    }
                    if (textBox4.Text != "")
                    {
                        if (textBox4.Text == "")
                            select_s = 0;
                        else
                        {
                            try
                            {
                                select_s = Convert.ToInt32(textBox4.Text);
                                conditionNum++;
                            }
                            catch
                            {
                                MessageBox.Show("请正确输入", "错误");
                            }
                        }
                        if (conditionNum != 0)
                        {
                            sql += " and ";
                        }
                        sql += String.Format("学分={0}", select_s);
                    }
                    if (textBox5.Text != "")
                    {
                        if (textBox5.Text == "")
                            s = 0;
                        else
                        {
                            try
                            {
                                s = Convert.ToDouble(textBox5.Text);
                                conditionNum++;
                            }
                            catch
                            {
                                MessageBox.Show("请正确输入", "错误");
                            }
                        }
                        if (conditionNum != 0)
                        {
                            sql += " and ";
                        }
                        sql += String.Format("成绩={0}", s);
                    }
                    #endregion

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    try
                    { r = cmd.ExecuteNonQuery(); }
                    catch
                    { MessageBox.Show("删除失败！", "错误"); }
                    finally
                    {
                        if (r > 0)
                        {
                            MessageBox.Show("删除完成", "提示");
                        }
                    }
                }
            }
        }

    }
}
