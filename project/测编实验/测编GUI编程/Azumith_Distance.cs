using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace 测编GUI编程
{
    public partial class Azumith_Distance : Form
    {
        public Azumith_Distance()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 计算坐标方位角
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAzumith_Click(object sender, EventArgs e)
        {
            if (textBox_Ax.Text == "" || textBox_Ay.Text == "" || textBox_Bx.Text == "" || textBox_By.Text == "")
            {
                MessageBox.Show("请输入", "提示");
            }
            double[] locationA = new double[] { Convert.ToDouble(this.textBox_Ax.Text), Convert.ToDouble(this.textBox_Ay.Text) };
            double[] locationB = new double[] { Convert.ToDouble(this.textBox_Bx.Text), Convert.ToDouble(this.textBox_By.Text) };
            textBoxAzumith.Text = CalculateAzimuth(locationA, locationB).ToString("F4");
        }

        /// <summary>
        /// 计算距离
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDistance_Click(object sender, EventArgs e)
        {
            if (textBox_Ax.Text == "" || textBox_Ay.Text == "" || textBox_Bx.Text == "" || textBox_By.Text == "")
            {
                MessageBox.Show("请输入", "提示");
            }
            double[] locationA = new double[] { Convert.ToDouble(this.textBox_Ax.Text), Convert.ToDouble(this.textBox_Ay.Text) };
            double[] locationB = new double[] { Convert.ToDouble(this.textBox_Bx.Text), Convert.ToDouble(this.textBox_By.Text) };
            this.textBoxDistance.Text = CalculateDistance(locationA, locationB).ToString("F4");
        }

        /// <summary>
        /// 根据两点坐标计算坐标方位角
        /// </summary>
        /// <param name="location1"></param>
        /// <param name="location2"></param>
        /// <returns></returns>
        public static double CalculateAzimuth(double[] location1, double[] location2)
        {
            double angle = Math.Atan((location1[1] - location2[1]) / (location1[0] - location2[0]));
            if ((location1[0] - location2[0]) < 0)//直线AB的斜率为正
            {
                angle += Math.PI;
            }
            else if ((location1[0] - location2[0]) > 0)//直线AB的斜率为负
            {
                if ((location1[1] - location2[1]) < 0)
                    angle += 2 * Math.PI;
            }
            return angle;
        }

        /// <summary>
        /// 根据两点坐标计算距离
        /// </summary>
        /// <param name="location1"></param>
        /// <param name="location2"></param>
        /// <returns></returns>
        public static double CalculateDistance(double[] location1, double[] location2)
        {
            double distance = Math.Sqrt(Math.Pow(location1[1] - location2[1], 2) + Math.Pow(location1[0] - location2[0], 2));
            return distance;
        }

        /// <summary>
        /// 坐标正算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 坐标正算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //使正算按钮可见
            button_forwardCal.Visible = true;
            this.buttonAzumith.Visible = false;
            this.buttonDistance.Visible = false;
            //当按下正算按钮时，改变控件文本来提示用户输入
            groupBox_A.Text = "输入A坐标";
            groupBox_B.Text = "B坐标";
            label1.Text = "输入坐标方位角";
            label2.Text = "输入两点距离";
        }

        /// <summary>
        /// 坐标反算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 坐标反算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //使计算方位角、距离按钮可见
            this.button_forwardCal.Visible = false;
            this.buttonAzumith.Visible = true;
            this.buttonDistance.Visible = true;
            //当按下正算按钮时，改变控件文本来提示用户输入
            groupBox_A.Text = "输入A坐标";
            groupBox_B.Text = "输入B坐标";
            label1.Text = "坐标方位角";
            label2.Text = "两点距离";
        }

        /// <summary>
        /// 当窗体加载时隐藏所有按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Azumith_Distance_Load(object sender, EventArgs e)
        {
            //隐藏所有按钮
            this.button_forwardCal.Visible = false;
            this.buttonAzumith.Visible = false;
            this.buttonDistance.Visible = false;
        }

        private void button_forwardCal_Click(object sender, EventArgs e)
        {
            if (textBox_Ax.Text == "" || textBox_Ay.Text == "" || textBoxDistance.Text == "" || textBoxAzumith.Text == "")
            {
                MessageBox.Show("请输入", "提示");
            }
            else
            {
                double[] locationB = ForwardCalculate(new double[] { Convert.ToDouble(textBox_Ax.Text), Convert.ToDouble(textBox_Ay.Text) }, Convert.ToDouble(textBoxDistance.Text), Convert.ToDouble(textBoxAzumith.Text));
                textBox_Bx.Text = locationB[0].ToString();
                textBox_By.Text = locationB[1].ToString();
            }
        }

        /// <summary>
        /// 正算B点坐标
        /// </summary>
        /// <param name="locationA">已知A点坐标</param>
        /// <param name="S">两点距离</param>
        /// <param name="α">坐标方位角</param>
        /// <returns></returns>
        public static double[] ForwardCalculate(double[] locationA, double S, double α)
        {
            double[] locationB = new double[2];
            locationB[0] = locationA[0] + S * Math.Cos(α);
            locationB[1] = locationA[1] + S * Math.Sin(α);
            return locationB;
        }
    }
}
