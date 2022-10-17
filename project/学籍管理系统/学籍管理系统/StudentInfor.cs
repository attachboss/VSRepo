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
    public partial class StudentInfor : Form
    {
        #region 链接
        string conStr = "Data Source=LAPTOP-ARN2CV9O;Initial Catalog=CyberCampus;User ID=sa;Password=08001402";
        #endregion
        #region list
        List<string> 学号 = new List<string>();
        List<string> 姓名 = new List<string>();
        List<string> 性别 = new List<string>();
        List<string> 出生日期 = new List<string>();
        List<string> 班级 = new List<string>();
        List<string> QQ号 = new List<string>();
        List<string> 职务 = new List<string>();
        List<string> 四级成绩 = new List<string>();
        List<string> 籍贯 = new List<string>();
        List<List<string>> lists = new List<List<string>>();
        #endregion

        public StudentInfor()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 清空所有输入信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
        }


        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }


        /// <summary>
        /// 当窗体加载的时候查询Student表中的所有数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportInfor_Load(object sender, EventArgs e)
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
            for (int k = 0; k < 学号.Count; k++)
            {
                string[][] student = new string[学号.Count][];
                for (int i = 0; i < 学号.Count; i++)
                {
                    student[i] = new string[lists.Count];
                }
                for (int i = 0; i < lists.Count; i++)
                {
                    for (int j = 0; j < 学号.Count; j++)
                    {
                        student[j][i] = lists[i][j];
                    }
                }
                ListViewItem[] lvItem = new ListViewItem[学号.Count];
                lvItem[k] = new ListViewItem(student[k]);
                listView1.Items.Add(lvItem[k]);
            }
        }


        /// <summary>
        /// 将每个list中的元素加入到list<><>中去
        /// </summary>
        private void ListAdd()
        {
            lists.Add(学号);
            lists.Add(姓名);
            lists.Add(性别);
            lists.Add(出生日期);
            lists.Add(班级);
            lists.Add(QQ号);
            lists.Add(职务);
            lists.Add(四级成绩);
            lists.Add(籍贯);
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
                string sql = "select * from Student";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    ClearAllList();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        学号.Add(reader.GetString(reader.GetOrdinal("学号")));
                        姓名.Add(reader.GetString(reader.GetOrdinal("姓名")));
                        性别.Add(reader.GetString(reader.GetOrdinal("性别")));
                        出生日期.Add(reader.GetDateTime(reader.GetOrdinal("出生日期")).ToString());
                        班级.Add(reader.GetString(reader.GetOrdinal("班级")));
                        QQ号.Add(reader.GetString(reader.GetOrdinal("QQ")));
                        if (reader["职务"] != DBNull.Value)
                        {
                            职务.Add(reader.GetString(reader.GetOrdinal("职务")));
                        }
                        else
                        {
                            职务.Add("");
                        }
                        四级成绩.Add(reader.GetInt32((reader.GetOrdinal("成绩"))).ToString());
                        籍贯.Add(reader.GetString(reader.GetOrdinal("籍贯")));
                    }
                }
            }

        }


        /// <summary>
        /// 运行时清空所有list集合中的数据
        /// </summary>
        private void ClearAllList()
        {
            学号.Clear();
            姓名.Clear();
            性别.Clear();
            出生日期.Clear();
            班级.Clear();
            QQ号.Clear();
            职务.Clear();
            四级成绩.Clear();
            籍贯.Clear();
            lists.Clear();
        }


        /// <summary>
        /// update语句添加新记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            int s = 0;
            string Sno = this.textBox1.Text;
            if (textBox8.Text == "")
                s = 0;
            else
            {
                try
                { s = Convert.ToInt32(textBox8.Text); }
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
                string sql = String.Format("update Student set " +
                    "学号='{0}'," +
                    "姓名='{1}'," +
                    "性别='{2}' ," +
                    "出生日期='{3}' ," +
                    "班级='{4}' ," +
                    "QQ='{5}'," +
                    "职务='{6}' ," +
                    "成绩={7}," +
                    "籍贯='{8}'" +
                    "where 学号=@Sno", textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, s, textBox9.Text);
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
        /// select条件查询(最多支持9个条件，不支持子查询)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            int select_s = 0;
            int conditionNum = 0;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string sql = "select * from Student where ";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    #region 拼写查询语句
                    if (textBox1.Text != "")
                    {
                        sql += String.Format("学号='{0}'", textBox1.Text);
                        conditionNum++;
                    }
                    if (textBox2.Text != "")
                    {
                        if (conditionNum != 0)
                        {
                            sql += " and ";
                        }
                        sql += String.Format("姓名='{0}'", textBox2.Text);
                        conditionNum++;
                    }
                    if (textBox3.Text != "")
                    {
                        if (conditionNum != 0)
                        {
                            sql += " and ";
                        }
                        sql += String.Format("性别='{0}'", textBox3.Text);
                        conditionNum++;
                    }
                    if (textBox4.Text != "")
                    {
                        if (conditionNum != 0)
                        {
                            sql += " and ";
                        }
                        sql += String.Format("班级='{0}'", textBox4.Text);
                        conditionNum++;
                    }
                    if (textBox5.Text != "")
                    {
                        if (conditionNum != 0)
                        {
                            sql += " and ";
                        }
                        sql += String.Format("出生日期='{0}'", textBox5.Text);
                        conditionNum++;
                    }
                    if (textBox6.Text != "")
                    {
                        if (conditionNum != 0)
                        {
                            sql += " and ";
                        }
                        sql += String.Format("QQ='{0}'", textBox6.Text);
                        conditionNum++;
                    }
                    if (textBox7.Text != "")
                    {
                        if (conditionNum != 0)
                        {
                            sql += " and ";
                        }
                        sql += String.Format("职务='{0}'", textBox7.Text);
                        conditionNum++;
                    }
                    if (textBox8.Text != "")
                    {
                        if (textBox8.Text == "")
                            select_s = 0;
                        else
                        {
                            try
                            {
                                select_s = Convert.ToInt32(textBox8.Text);
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
                    if (textBox9.Text != "")
                    {
                        if (conditionNum != 0)
                        {
                            sql += " and ";
                        }
                        sql += String.Format("籍贯='{0}'", textBox9.Text);
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
                            学号.Add(reader.GetString(reader.GetOrdinal("学号")));
                            姓名.Add(reader.GetString(reader.GetOrdinal("姓名")));
                            性别.Add(reader.GetString(reader.GetOrdinal("性别")));
                            出生日期.Add(reader.GetDateTime(reader.GetOrdinal("出生日期")).ToString());
                            班级.Add(reader.GetString(reader.GetOrdinal("班级")));
                            QQ号.Add(reader.GetString(reader.GetOrdinal("QQ")));
                            if (reader["职务"] != DBNull.Value)
                            {
                                职务.Add(reader.GetString(reader.GetOrdinal("职务")));
                            }
                            else
                            {
                                职务.Add("");
                            }
                            四级成绩.Add(reader.GetInt32((reader.GetOrdinal("成绩"))).ToString());
                            籍贯.Add(reader.GetString(reader.GetOrdinal("籍贯")));
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
        private void button1_Click_1(object sender, EventArgs e)
        {
            QueryAll();
            ListAdd();
            listView1.Items.Clear();
            PrintTable();
        }


        /// <summary>
        /// 插入一条数据(必须有学号)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Insert_Click(object sender, EventArgs e)
        {
            int s = 0;
            string Sno = this.textBox1.Text;
            if (Sno == "")
            {
                MessageBox.Show("要插入的记录必须有学号！", "提示");
            }
            if (textBox8.Text == "")
                s = 0;
            else
            {
                try
                { s = Convert.ToInt32(textBox8.Text); }
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
                string sql = String.Format("insert into Student([学号], [姓名], [性别], [出生日期], [班级], [QQ], [职务], [成绩], [籍贯]) values(" +
                    "'{0}'," +
                    "'{1}'," +
                    "'{2}'," +
                    "'{3}'," +
                    "'{4}'," +
                    "'{5}'," +
                    "'{6}'," +
                    "{7}," +
                    "'{8}'" +
                    ")", textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, s, textBox9.Text);
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

        private void button_Delete_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                int conditionNum = -1;
                int r = -1;
                con.Open();
                string sql = String.Format("delete from Student where ");
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    int select_s = 0;
                    #region 拼写查询语句
                    if (textBox1.Text != "")
                    {
                        sql += String.Format("学号='{0}'", textBox1.Text);
                        conditionNum++;
                    }
                    if (textBox2.Text != "")
                    {
                        if (conditionNum != 0)
                        {
                            sql += " and ";
                        }
                        sql += String.Format("姓名='{0}'", textBox2.Text);
                        conditionNum++;
                    }
                    if (textBox3.Text != "")
                    {
                        if (conditionNum != 0)
                        {
                            sql += " and ";
                        }
                        sql += String.Format("性别='{0}'", textBox3.Text);
                        conditionNum++;
                    }
                    if (textBox4.Text != "")
                    {
                        if (conditionNum != 0)
                        {
                            sql += " and ";
                        }
                        sql += String.Format("班级='{0}'", textBox4.Text);
                        conditionNum++;
                    }
                    if (textBox5.Text != "")
                    {
                        if (conditionNum != 0)
                        {
                            sql += " and ";
                        }
                        sql += String.Format("出生日期='{0}'", textBox5.Text);
                        conditionNum++;
                    }
                    if (textBox6.Text != "")
                    {
                        if (conditionNum != 0)
                        {
                            sql += " and ";
                        }
                        sql += String.Format("QQ='{0}'", textBox6.Text);
                        conditionNum++;
                    }
                    if (textBox7.Text != "")
                    {
                        if (conditionNum != 0)
                        {
                            sql += " and ";
                        }
                        sql += String.Format("职务='{0}'", textBox7.Text);
                        conditionNum++;
                    }
                    if (textBox8.Text != "")
                    {
                        if (textBox8.Text == "")
                            select_s = 0;
                        else
                        {
                            try
                            {
                                select_s = Convert.ToInt32(textBox8.Text);
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
                    if (textBox9.Text != "")
                    {
                        if (conditionNum != 0)
                        {
                            sql += " and ";
                        }
                        sql += String.Format("籍贯='{0}'", textBox9.Text);
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
