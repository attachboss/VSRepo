using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelativeOrientationElementSolution
{
    internal class Program
    {
        //单位为mm
        public static double f = 24 / 1e+3;
        public static int index = 0;

        static void Main(string[] args)
        {
            //单位为mm
            ImagePointCoordinate[] ipc_left = {
                new ImagePointCoordinate(1.983,  -6.091),
                new ImagePointCoordinate(0.924 , 7.098),
                new ImagePointCoordinate(1.068 ,4.538),
                new ImagePointCoordinate(1.208 ,6.858),
                new ImagePointCoordinate(-0.514,-10.050),
                new ImagePointCoordinate(1.293 ,-8.089),
            };
            ImagePointCoordinate[] ipc_right = {
                new ImagePointCoordinate(-3.202,-5.564),
                new ImagePointCoordinate(-2.830,7.694),
                new ImagePointCoordinate(-2.878,5.098),
                new ImagePointCoordinate(-2.578,7.429),
                new ImagePointCoordinate(-5.642,-9.152),
                new ImagePointCoordinate(-3.981,-7.441),
            };
            CorrectInternalOrientationElement(ipc_left);
            CorrectInternalOrientationElement(ipc_right);
            double by = 0, bz = 0;
            //初始化矩阵
            double[][] X1 = new double[3][], X2 = new double[3][], A = new double[ipc_left.Length][], l = new double[ipc_left.Length][], R2 = new double[3][], X = new double[5][], XX = new double[5][];
            for (int j = 0; j < R2.Length; j++)
            {
                R2[j] = new double[3];
                X1[j] = new double[1];
                X2[j] = new double[1];
            }
            for (int i = 0; i < A.Length; i++)
            {
                A[i] = new double[5];
                l[i] = new double[1];
            }
            for (int i = 0; i < 5; i++)
            {
                X[i] = new double[] { 0 };
            }

        loop:
            for (int i = 0; i < ipc_left.Length; i++)
            {
                X1[0][0] = ipc_left[i].x;
                X1[1][0] = ipc_left[i].y;
                X1[2][0] = -f;

                R2 = GetMatR(new double[] { X[2][0], X[3][0], X[4][0] }, R2);
                X2 = Matrix.MultMatrix(R2, new double[][] { new double[] { ipc_right[i].x }, new double[] { ipc_right[i].y }, new double[] { -f } });

                double bx = (ipc_left[i].x - ipc_right[i].x);
                by = bx * Math.Tan(X[0][0]);
                bz = bx * Math.Tan(X[1][0]) / Math.Cos(X[0][0]);
                double N1 = (bx * X2[2][0] - bz * X2[0][0]) / (X1[0][0] * X2[2][0] - X2[0][0] * X1[2][0]);
                double N2 = (bx * X1[2][0] - bz * X1[0][0]) / (X1[0][0] * X2[2][0] - X2[0][0] * X1[2][0]);
                double Q = N1 * X1[1][0] - N2 * X2[1][0] - by;

                l[i][0] = Q;
                A[i][0] = bx;
                A[i][1] = -X2[1][0] * bx / X2[2][0];
                A[i][2] = -X2[0][0] * X2[1][0] * N2 / X2[2][0];
                A[i][3] = -(X2[2][0] + Math.Pow(X2[1][0], 2) / X2[2][0]) * N2;
                A[i][4] = X2[0][0] * N2;
            }
            XX = Matrix.MultMatrix(Matrix.InverseMatrix(Matrix.MultMatrix(Matrix.TransposeMatrix(A), A)), Matrix.MultMatrix(Matrix.TransposeMatrix(A), l));
            for (int i = 0; i < 5; i++)
            {
                while (X[i][0] > 2 * Math.PI)
                {
                    X[i][0] -= 2 * Math.PI;
                }
                while (X[i][0] < 0)
                {
                    X[i][0] += 2 * Math.PI;
                }
            }
            if (Math.Abs(XX[0][0]) >= 3e-5 || Math.Abs(XX[1][0]) >= 3e-5 || Math.Abs(XX[2][0]) >= 3e-5 || Math.Abs(XX[3][0]) >= 3e-5 || Math.Abs(XX[4][0]) >= 3e-5)
            {
                X[0][0] += XX[0][0];
                X[1][0] += XX[1][0];
                X[2][0] += XX[2][0];
                X[3][0] += XX[3][0];
                X[4][0] += XX[4][0];
                index++;
                goto loop;
            }
            else
            {
                XX[0][0] += X[0][0];
                XX[1][0] += X[1][0];
                XX[2][0] += X[2][0];
                XX[3][0] += X[3][0];
                XX[4][0] += X[4][0];
                Matrix.PrintMatrix(XX);
            }

            Console.ReadKey();
        }


        /// <summary>
        /// 计算系数阵A与常数阵l
        /// </summary>
        /// <param name="ipc"></param>
        /// <param name="eoe"></param>
        /// <param name="R"></param>
        /// <param name="A"></param>
        /// <param name="l"></param>
        /// <param name="i"></param>
        /// <param name="flag"></param>
        private static void GetMatrix(ImagePointCoordinate[] ipc, double[] eoe, double[][] R, ref double[][] A, ref double[][] l, int i, bool flag)
        {
            int value = 0;
            if (!flag)
            {
                value = 2;
            }
            A[value][0] = f * R[0][0] + ipc[i].x * R[2][0];
            A[value][1] = f * R[0][1] + ipc[i].x * R[2][1];
            A[value][2] = f * R[0][2] + ipc[i].x * R[2][2];
            A[value + 1][0] = f * R[1][0] + ipc[i].y * R[2][0];
            A[value + 1][1] = f * R[1][1] + ipc[i].y * R[2][1];
            A[value + 1][2] = f * R[1][2] + ipc[i].y * R[2][2];

            l[value][0] = f * R[0][0] * eoe[0] + f * R[0][1] * eoe[1] + f * R[0][2] * eoe[2] + ipc[i].x * R[0][2] * eoe[0] + ipc[i].x * R[1][2] * eoe[1] + ipc[i].x * R[2][2] * eoe[2];
            l[value + 1][0] = f * R[1][0] * eoe[0] + f * R[1][1] * eoe[1] + f * R[1][2] * eoe[2] + ipc[i].y * R[0][2] * eoe[0] + ipc[i].y * R[1][2] * eoe[1] + ipc[i].y * R[2][2] * eoe[2];
        }


        /// <summary>
        /// 对框标坐标进行改正
        /// </summary>
        /// <param name="ipc"></param>
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <returns></returns>
        private static ImagePointCoordinate[] CorrectInternalOrientationElement(ImagePointCoordinate[] ipc)
        {
            for (int i = 0; i < ipc.Length; i++)
            {
                ipc[i].x /= 1e+3;
                ipc[i].y /= 1e+3;
            }
            return ipc;
        }


        /// <summary>
        /// 初始化旋转矩阵R
        /// </summary>
        /// <param name="eoe"></param>
        /// <param name="R"></param>
        /// <returns></returns>
        private static double[][] GetMatR(double[] eoe, double[][] R)
        {
            R[0][0] = Math.Cos(eoe[0]) * Math.Cos(eoe[2]) - Math.Sin(eoe[0]) * Math.Sin(eoe[1]) * Math.Sin(eoe[2]);
            R[0][1] = -Math.Cos(eoe[0]) * Math.Sin(eoe[2]) - Math.Sin(eoe[0]) * Math.Sin(eoe[1]) * Math.Sin(eoe[2]);
            R[0][2] = -Math.Sin(eoe[0]) * Math.Sin(eoe[1]);
            R[1][0] = Math.Cos(eoe[1]) * Math.Sin(eoe[2]);
            R[1][1] = Math.Cos(eoe[1]) * Math.Cos(eoe[2]);
            R[1][2] = -Math.Sin(eoe[0]);
            R[2][0] = Math.Sin(eoe[0]) * Math.Cos(eoe[2]) + Math.Cos(eoe[0]) * Math.Sin(eoe[1]) * Math.Cos(eoe[2]);
            R[2][1] = -Math.Sin(eoe[0]) * Math.Sin(eoe[2]) + Math.Cos(eoe[0]) * Math.Sin(eoe[1]) * Math.Cos(eoe[2]);
            R[2][2] = Math.Cos(eoe[0]) * Math.Cos(eoe[1]);
            return R;
        }
    }
}
