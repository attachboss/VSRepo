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
    public partial class AngleCalculate : Form
    {
        public AngleCalculate()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 当复选框被选中时执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            double angle;
            double[] angleDMS;
            double radian;
            string str;
            if (textBox1.Text != "")
            {
                switch (comboBox1.Text)
                {
                    case "度分秒转度":
                        if (textBox1.Text.Contains("/"))
                        {
                            angleDMS = new double[3];
                            string[] s = textBox1.Text.Split('/');
                            for (int i = 0; i < s.Length; i++)
                            {
                                angleDMS[i] = Convert.ToDouble(s[i]);
                            }
                            textBox_result.Text = Calculate.AngleConversion(angleDMS).ToString("F4");
                        }
                        break;
                    case "度转度分秒":
                        angle = Convert.ToDouble(textBox1.Text);
                        str = "";
                        for (int i = 0; i < 3; i++)
                        {
                            str += Calculate.AngleConversion(angle)[i].ToString()+"' ";
                        }
                        textBox_result.Text = str;
                        break;
                    case "度转弧度":
                        angle = Convert.ToDouble(textBox1.Text);
                        textBox_result.Text = Calculate.ToRadian(angle).ToString("F4");
                        break;
                    case "弧度转度":
                        radian = Convert.ToDouble(textBox1.Text);
                        textBox_result.Text = Calculate.ToDegree(radian).ToString("F4");
                        break;
                    case "度分秒转弧度":
                        if (textBox1.Text.Contains("/"))
                        {
                            angleDMS = new double[3];
                            string[] s = textBox1.Text.Split('/');
                            for (int i = 0; i < s.Length; i++)
                            {
                                angleDMS[i] = Convert.ToDouble(s[i]);
                            }
                            textBox_result.Text = Calculate.ToRadian(angleDMS).ToString("F4");
                        }
                        break;
                    case "弧度转度分秒":
                        radian = Convert.ToDouble(textBox1.Text);
                        str = "";
                        for (int i = 0; i < 3; i++)
                        {
                            str += Calculate.ToDegreeDMS(radian)[i].ToString()+"' ";
                        }
                        textBox_result.Text = str;
                        break;
                }
            }

        }
    }
}
