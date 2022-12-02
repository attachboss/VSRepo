using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 测编GUI编程
{
    public partial class LateralIntersection : Form
    {
        public LateralIntersection()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_Ax.Text == "" || textBox_Ay.Text == "" || textBox_Bx.Text == "" || textBox_By.Text == "")
            {
                MessageBox.Show("请输入", "提示");
            }
            else
            {
                double[] locationA = new double[] { Convert.ToDouble(this.textBox_Ax.Text), Convert.ToDouble(this.textBox_Ay.Text) };
                double[] locationB = new double[] { Convert.ToDouble(this.textBox_Bx.Text), Convert.ToDouble(this.textBox_By.Text) };
                double α = Convert.ToDouble(this.textBox_Aangle.Text);
                double β = Convert.ToDouble(this.textBox_Pangle.Text);
                double[] P = IntersectionCal(locationA, locationB, α, β);
                textBox_Px.Text = P[0].ToString("F4");
                textBox_Py.Text = P[1].ToString("F4");
            }
        }

        /// <summary>
        /// 侧方交会
        /// </summary>
        /// <param name="locationA"></param>
        /// <param name="locationB"></param>
        /// <param name="α"></param>
        /// <param name="β"></param>
        /// <returns></returns>
        public double[] IntersectionCal(double[] locationA, double[] locationB, double α, double β)
        {
            double α_ab = Azumith_Distance.CalculateAzimuth(locationA, locationB);
            double γ = Math.PI - α - β;
            double Sab = Math.Sqrt(Math.Pow((locationA[1] - locationB[1]), 2) + Math.Pow((locationA[0] - locationB[0]), 2));
            double Sap = Sab * Math.Sin(γ) / Math.Sin(β);
            double[] locationP = new double[2];
            locationP[0] = locationA[0] + Sap * Math.Cos(α_ab - α);
            locationP[1] = locationA[1] + Sab * Math.Sin(α_ab - α);
            return locationP;
        }


        private string filename = null;
        private void 打开结果文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "文本文件|*.txt|所有文件|*.*";
            DialogResult result = ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                filename = ofd.FileName;
                Process.Start(@filename);
            }
        }

        private void 保存到文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "文本文件|*.txt|所有文件|*.*";
            sfd.RestoreDirectory = true;
            DialogResult result = sfd.ShowDialog();
            if (result == DialogResult.OK)
            {
                filename = sfd.FileName;
                using (FileStream fsWrite = new FileStream(@filename, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
                {
                    using (StreamWriter sw = new StreamWriter(fsWrite))
                    {
                        //向文件中添加三个点（两个已知点、一个计算得出的点）的坐标
                        try
                        {
                            sw.WriteLine(this.textBox_Ax.Text + " " + this.textBox_Ay.Text + "已知点");
                            sw.WriteLine(this.textBox_Bx.Text + " " + this.textBox_By.Text + "已知点");
                            sw.WriteLine(this.textBox_Px.Text + " " + this.textBox_Py.Text + "解算点");
                        }
                        catch
                        {
                            MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OKCancel);
                        }
                    }
                }
            }
        }


        string conStr = "Data Source=.;Initial Catalog=ServingApplicationDB;Integrated Security=True";
        private void 保存到数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double Px = 0;
            double Py = 0;
            try
            {
                Px = Convert.ToDouble(this.textBox_Px.Text);
                Py = Convert.ToDouble(this.textBox_Py.Text);
            }
            catch
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    string sql = String.Format("insert into PointPos([Pno], [Pname], [P_x], [P_y], [Puse], [Pattribute]) values('{0}','{1}',{2},{3},'{4}','{5}')", DateTime.Now.ToString(), " ", Px, Py, "后方交会计算", "解算");
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        int r = cmd.ExecuteNonQuery();
                        if (r == 1)
                        {
                            MessageBox.Show("数据保存成功！", "提示", MessageBoxButtons.OKCancel);
                        }
                        else
                        {
                            MessageBox.Show("保存失败", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        }
                    }
                }
            }

        }

        private void 绘制交会图像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double Px = 0, Py = 0, Ax = 0, Ay = 0, Bx = 0, By = 0;
            try
            {
                Px = Convert.ToDouble(this.textBox_Px.Text);
                Py = Convert.ToDouble(this.textBox_Py.Text);
                Ax = Convert.ToDouble(this.textBox_Ax.Text);
                Ay = Convert.ToDouble(this.textBox_Ay.Text);
                Bx = Convert.ToDouble(this.textBox_Bx.Text);
                By = Convert.ToDouble(this.textBox_By.Text);
                DrawMap map = new DrawMap(Color.Red);
                map.Show();
                map.Draw(Px, Py, Ax, Ay);
                map.Draw(Ax, Ay, Bx, By);
                map.Draw(Bx, By, Px, Py);
            }
            catch
            {
                MessageBox.Show("出现错误！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            }
        }
    }
}
