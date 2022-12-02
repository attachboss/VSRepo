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

namespace 测编GUI编程
{
    public partial class MatrixCal : Form
    {
        public MatrixCal()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 计算并输出结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            double[][] resultMat;
            if (textBox_A.Text == "")
            {
                MessageBox.Show("请输入矩阵！", "提示");
            }
            else
            {
                double[][] A = GetMatrix(textBox_A.Lines.Length, textBox_A.Lines[0].Length, textBox_A.Lines);
                switch (comboBox1.Text)
                {
                    case "+":
                        if (textBox_B.Text == "")
                        {
                            MessageBox.Show("请输入第二个矩阵！", "提示");
                        }
                        else
                        {
                            double[][] B = GetMatrix(textBox_B.Lines.Length, textBox_B.Lines[0].Length, textBox_B.Lines);
                            resultMat = Matrix.PlusMatrix(A, B);
                            textBox_Result.Text = PrintMat(resultMat);
                        }
                        break;
                    case "-":
                        if (textBox_B.Text == "")
                        {
                            MessageBox.Show("请输入第二个矩阵！", "提示");
                        }
                        else
                        {
                            double[][] B = GetMatrix(textBox_B.Lines.Length, textBox_B.Lines[0].Length, textBox_B.Lines);
                            resultMat = Matrix.MinusMatrix(A, B);
                            textBox_Result.Text = PrintMat(resultMat);
                        }
                        break;
                    case "*":
                        if (textBox_B.Text == "")
                        {
                            MessageBox.Show("请输入第二个矩阵！", "提示");
                        }
                        else
                        {
                            double[][] B = GetMatrix(textBox_B.Lines.Length, textBox_B.Lines[0].Length, textBox_B.Lines);
                            resultMat = Matrix.MultMatrix(A, B);
                            textBox_Result.Text = PrintMat(resultMat);
                        }
                        break;
                    case "求逆":
                        resultMat = Matrix.InverseMatrix(A);
                        textBox_Result.Text = PrintMat(resultMat);

                        break;
                }
            }
        }


        /// <summary>
        /// 将textBox中的string[] 转化为double[][]矩阵
        /// </summary>
        /// <param name="r"></param>
        /// <param name="c"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        private double[][] GetMatrix(int r, int c, string[] str)
        {
            string[] S = new string[r];
            double[][] Mat = new double[r][];
            for (int i = 0; i < r; i++)
            {
                S = str[i].Split(' ');
                Mat[i] = new double[S.Length];
                for (int j = 0; j < S.Length; j++)
                {
                    Mat[i][j] = Convert.ToDouble(S[j]);
                }
            }

            return Mat;
        }


        /// <summary>
        /// 求方阵的行数（列数）n
        /// </summary>
        /// <param name="matStr"></param>
        /// <returns></returns>
        private static int GetMatRowNum(string matStr)
        {
            char[] tem = matStr.ToCharArray();
            int n = 0;
            foreach (var item in tem)
            {
                if (item == ' ')
                    n++;
            }
            return (int)Math.Floor(Math.Sqrt(Math.Abs(n)));
        }


        /// <summary>
        /// 将double[][] 类型的矩阵转化为string
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        private static string PrintMat(double[][] mat)
        {
            string matStr = "";
            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat[0].Length; j++)
                {
                    matStr += mat[i][j].ToString();
                    if (j < mat[0].Length - 1)
                    {
                        matStr += " ";
                    }
                    else if (j == mat[0].Length - 1)
                    {
                        matStr += "\r\n";
                    }
                }
            }
            return matStr;
        }


        /// <summary>
        /// 点击清空所有内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            textBox_A.Text = "";
            textBox_B.Text = "";
            textBox_Result.Text = "";
        }


        /// <summary>
        /// 当复选框值变为求逆时，隐藏第二个矩阵的textBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "+":
                    textBox_B.Visible = true;
                    break;
                case "-":
                    textBox_B.Visible = true;
                    break;
                case "*":
                    textBox_B.Visible = true;
                    break;
                case "求逆":
                    textBox_B.Visible = false;
                    break;
            }
        }

    }
}
