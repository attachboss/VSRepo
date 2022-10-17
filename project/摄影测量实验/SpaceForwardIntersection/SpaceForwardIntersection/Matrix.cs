using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceForwardIntersection
{
    internal static class Matrix
    {
        /// <summary>
        /// 求矩阵的逆矩阵
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static double[][] InverseMatrix(double[][] matrix)
        {
            //matrix必须为非空
            if (matrix == null || matrix.Length == 0)
            {
                return new double[][] { };
            }
            //matrix 必须为方阵
            int len = matrix.Length;
            for (int counter = 0; counter < matrix.Length; counter++)
            {
                if (matrix[counter].Length != len)
                {
                    throw new Exception("matrix 必须为方阵");
                }
            }
            //计算矩阵行列式的值
            double dDeterminant = Determinant(matrix);
            if (Math.Abs(dDeterminant) <= 1E-100)
            {
                throw new Exception("矩阵不可逆");
            }
            //制作一个伴随矩阵大小的矩阵
            double[][] result = AdjointMatrix(matrix);
            //矩阵的每项除以矩阵行列式的值，即为所求
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix.Length; j++)
                {
                    result[i][j] = result[i][j] / dDeterminant;
                }
            }
            return result;
        }


        /// <summary>
        /// 求矩阵的转置
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns>返回matrix_T</returns>
        public static double[][] TransposeMatrix(double[][] matrix)
        {
            double[][] result = new double[matrix[0].Length][];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new double[matrix.Length];
            }
            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < result[0].Length; j++)
                {
                    result[i][j] = matrix[j][i];
                }
            }
            return result;
        }


        /// <summary>
        /// 递归计算行列式的值
        /// </summary>
        /// <param name="matrix">矩阵</param>
        /// <returns></returns>
        public static double Determinant(double[][] matrix)
        {
            //二阶及以下行列式直接计算
            if (matrix.Length == 0) return 0;
            else if (matrix.Length == 1) return matrix[0][0];
            else if (matrix.Length == 2)
            {
                return matrix[0][0] * matrix[1][1] - matrix[0][1] * matrix[1][0];
            }
            //对第一行使用“加边法”递归计算行列式的值
            double dSum = 0, dSign = 1;
            for (int i = 0; i < matrix.Length; i++)
            {
                double[][] matrixTemp = new double[matrix.Length - 1][];
                for (int count = 0; count < matrix.Length - 1; count++)
                {
                    matrixTemp[count] = new double[matrix.Length - 1];
                }
                for (int j = 0; j < matrixTemp.Length; j++)
                {
                    for (int k = 0; k < matrixTemp.Length; k++)
                    {
                        matrixTemp[j][k] = matrix[j + 1][k >= i ? k + 1 : k];
                    }
                }
                dSum += (matrix[0][i] * dSign * Determinant(matrixTemp));
                dSign = dSign * -1;
            }
            return dSum;
        }


        /// <summary>
        /// 计算方阵的伴随矩阵
        /// </summary>
        /// <param name="matrix">方阵</param>
        /// <returns></returns>
        public static double[][] AdjointMatrix(double[][] matrix)
        {
            //制作一个伴随矩阵大小的矩阵
            double[][] result = new double[matrix.Length][];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new double[matrix[i].Length];
            }
            //生成伴随矩阵
            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < result.Length; j++)
                {
                    //存储代数余子式的矩阵（行、列数都比原矩阵少1）
                    double[][] temp = new double[result.Length - 1][];
                    for (int k = 0; k < result.Length - 1; k++)
                    {
                        temp[k] = new double[result[k].Length - 1];
                    }
                    //生成代数余子式
                    for (int x = 0; x < temp.Length; x++)
                    {
                        for (int y = 0; y < temp.Length; y++)
                        {
                            temp[x][y] = matrix[x < i ? x : x + 1][y < j ? y : y + 1];
                        }
                    }
                    //Console.WriteLine("代数余子式:");
                    //PrintMatrix(temp);
                    result[j][i] = ((i + j) % 2 == 0 ? 1 : -1) * Determinant(temp);
                }
            }
            //Console.WriteLine("伴随矩阵：");
            //PrintMatrix(result);
            return result;
        }


        /// <summary>
        /// 打印矩阵
        /// </summary>
        /// <param name="matrix">待打印矩阵</param>
        public static void PrintMatrix(double[][] matrix, string title = "")
        {
            //1.标题值为空则不显示标题
            if (!String.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine(title);
            }
            //2.打印矩阵
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        Console.Write("{0}  ", 0);
                    }
                    else
                        Console.Write("{0:F4}  ", matrix[i][j]);
                    //注意不能写为：Console.Write(matrix[i][j] + '\t');
                }
                Console.WriteLine();
            }
            //3.空行
            Console.WriteLine();
        }


        /// <summary>
        /// 矩阵相乘
        /// </summary>
        /// <param name="matrixA">矩阵A</param>
        /// <param name="matrixB">矩阵B</param>
        /// <returns></returns>
        public static double[][] MultMatrix(double[][] matrixA, double[][] matrixB)
        {
            double[][] matrixC = new double[matrixA.Length][];
            if (matrixA[0].Length == matrixB.Length)
            {
                for (int i = 0; i < matrixA.Length; i++)//第一个矩阵的行数
                {
                    double[] sum = new double[matrixB[0].Length];
                    for (int j = 0; j < matrixB[0].Length; j++)//第二个矩阵的列数
                    {

                        for (int k = 0; k < matrixB.Length; k++)//第二个矩阵的行数
                        {
                            sum[j] += matrixA[i][k] * matrixB[k][j];
                        }
                    }
                    matrixC[i] = sum;
                }
                return matrixC;
            }
            else
            {
                Console.WriteLine("第一个矩阵的列数必须等于第二个矩阵的行数！");
                return null;
            }

        }


        /// <summary>
        /// 矩阵相加
        /// </summary>
        /// <param name="matrixA"></param>
        /// <param name="matrixB"></param>
        /// <returns></returns>
        public static double[][] PlusMatrix(double[][] matrixA, double[][] matrixB)
        {
            double[][] matrixC = new double[matrixA.Length][];
            for (int i = 0; i < matrixC.Length; i++)
            {
                matrixC[i] = new double[matrixA[0].Length];
            }
            if (matrixA.Length == matrixB.Length && matrixA[0].Length == matrixB[0].Length)
            {
                for (int i = 0; i < matrixA.Length; i++)
                {
                    for (int j = 0; j < matrixA[0].Length; j++)
                    {
                        matrixC[i][j] = matrixA[i][j] + matrixB[i][j];
                    }
                }
                return matrixC;
            }
            else
            {
                Console.WriteLine("相加的两个矩阵行数和列数必须相等");
                return null;
            }
        }


        /// <summary>
        /// 矩阵相减
        /// </summary>
        /// <param name="matrixA"></param>
        /// <param name="matrixB"></param>
        /// <returns></returns>
        public static double[][] ReduceMatrix(double[][] matrixA, double[][] matrixB)
        {
            double[][] matrixC = new double[matrixA.Length][];
            for (int i = 0; i < matrixC.Length; i++)
            {
                matrixC[i] = new double[matrixA[0].Length];
            }
            if (matrixA.Length == matrixB.Length && matrixA[0].Length == matrixB[0].Length)
            {
                for (int i = 0; i < matrixA.Length; i++)
                {
                    for (int j = 0; j < matrixA[0].Length; j++)
                    {
                        matrixC[i][j] = matrixA[i][j] - matrixB[i][j];
                    }
                }
                return matrixC;
            }
            else
            {
                Console.WriteLine("相减的两个矩阵行数和列数必须相等");
                return null;
            }
        }

    }
}
