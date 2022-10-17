using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExactSolutionOfCollinearEquation
{
    internal class Program
    {
        //相机内方位元素   单位为mm
        public static double x0 = -0.004;
        public static double y0 = -0.008;
        public static double f = 152.72 * 1e-3;

        static void Main(string[] args)
        {
            //六个像点的框标坐标，单位为mm
            ImagePointCoordinate[] ipc_left = {
                new ImagePointCoordinate(85.7255, 69.6561),
                new ImagePointCoordinate(0.3206, 59.1841),
                new ImagePointCoordinate(83.7954, -1.9617),
                new ImagePointCoordinate(-2.2603, -15.1519),
                new ImagePointCoordinate(88.2371,-73.7021),
                new ImagePointCoordinate(2.4792,-67.5320),
            };
            ImagePointCoordinate[] ipc_right = {
                new ImagePointCoordinate(0.6313, 70.1653),
                new ImagePointCoordinate(-84.4506, 60.4553),
                new ImagePointCoordinate(-3.3174, -1.3205),
                new ImagePointCoordinate(-97.0211, -13.7425),
                new ImagePointCoordinate(2.7516, -72.5590),
                new ImagePointCoordinate(-82.9161,  -65.7818),
            };
            //像片的外方位元素，前三个为摄影中心坐标(单位为m)，后三个为航摄飞机姿态角度(单位为°)
            double[] eoe_left = { 14922.9778, 11532.4077, 3230.3383, -0.0566, -0.1215, -0.6456 };
            double[] eoe_right = { 16296.9601, 11524.2256, 3239.6070, 0.0429, -0.5148, -0.1538 };
            ipc_left = CorrectInternalOrientationElement(ipc_left, x0, y0);
            ipc_right = CorrectInternalOrientationElement(ipc_right, x0, y0);

            for (int i = 3; i < 6; i++)
            {
                eoe_left[i] = CalculateAngle.ToRadian(eoe_left[i]);
                eoe_right[i] = CalculateAngle.ToRadian(eoe_right[i]);
            }

            //初始化矩阵
            double[][] x1 = new double[3][], x2 = new double[3][], R1 = new double[3][], R2 = new double[3][], XX = new double[3][], A = new double[4][], l = new double[4][];
            for (int i = 0; i < x1.Length; i++)
            {
                x1[i] = new double[1];
                x2[i] = new double[1];
                R1[i] = new double[3];
                R2[i] = new double[3];
                XX[i] = new double[1];
            }
            for (int i = 0; i < A.Length; i++)
            {
                A[i] = new double[3];
                l[i] = new double[1];
            }

            //循环点数次求解
            R1 = GetMatR(eoe_left, R1);
            R2 = GetMatR(eoe_right, R2);
            for (int i = 0; i < ipc_left.Length; i++)
            {
                GetMatrix(ipc_left[i], eoe_left, R1, ref A, ref l, true);
                GetMatrix(ipc_right[i], eoe_right, R2, ref A, ref l, false);
                XX = Matrix.MultMatrix(Matrix.InverseMatrix(Matrix.MultMatrix(Matrix.TransposeMatrix(A), A)), Matrix.MultMatrix(Matrix.TransposeMatrix(A), l));
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
        /// <param name="isLeft"></param>
        private static void GetMatrix(ImagePointCoordinate ipc, double[] eoe, double[][] R, ref double[][] A, ref double[][] l, bool isLeft)
        {
            int value = 0;
            if (!isLeft)
            {
                value = 2;
            }
            A[value][0] = f * R[0][0] + ipc.x * R[2][0];
            A[value][1] = f * R[0][1] + ipc.x * R[2][1];
            A[value][2] = f * R[0][2] + ipc.x * R[2][2];
            A[value + 1][0] = f * R[1][0] + ipc.y * R[2][0];
            A[value + 1][1] = f * R[1][1] + ipc.y * R[2][1];
            A[value + 1][2] = f * R[1][2] + ipc.y * R[2][2];

            l[value][0] = f * R[0][0] * eoe[0] + f * R[0][1] * eoe[1] + f * R[0][2] * eoe[2] + ipc.x * R[0][2] * eoe[0] + ipc.x * R[1][2] * eoe[1] + ipc.x * R[2][2] * eoe[2];
            l[value + 1][0] = f * R[1][0] * eoe[0] + f * R[1][1] * eoe[1] + f * R[1][2] * eoe[2] + ipc.y * R[0][2] * eoe[0] + ipc.y * R[1][2] * eoe[1] + ipc.y * R[2][2] * eoe[2];
        }


        /// <summary>
        /// 对框标坐标进行改正
        /// </summary>
        /// <param name="ipc"></param>
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <returns></returns>
        private static ImagePointCoordinate[] CorrectInternalOrientationElement(ImagePointCoordinate[] ipc, double x0, double y0)
        {
            for (int i = 0; i < ipc.Length; i++)
            {
                ipc[i].x -= x0;
                ipc[i].x /= 1e+3;
                ipc[i].y -= y0;
                ipc[i].y /= 1e+3;
            }
            return ipc;
        }


        private static double[][] GetMatR(double[] eoe, double[][] R)
        {
            R[0][0] = Math.Cos(eoe[3]) * Math.Cos(eoe[5]) - Math.Sin(eoe[3]) * Math.Sin(eoe[4]) * Math.Sin(eoe[5]);
            R[0][1] = -Math.Cos(eoe[3]) * Math.Sin(eoe[5]) - Math.Sin(eoe[3]) * Math.Sin(eoe[4]) * Math.Sin(eoe[5]);
            R[0][2] = -Math.Sin(eoe[3]) * Math.Sin(eoe[4]);
            R[1][0] = Math.Cos(eoe[4]) * Math.Sin(eoe[5]);
            R[1][1] = Math.Cos(eoe[4]) * Math.Cos(eoe[5]);
            R[1][2] = -Math.Sin(eoe[3]);
            R[2][0] = Math.Sin(eoe[3]) * Math.Cos(eoe[5]) + Math.Cos(eoe[3]) * Math.Sin(eoe[4]) * Math.Cos(eoe[5]);
            R[2][1] = -Math.Sin(eoe[3]) * Math.Sin(eoe[5]) + Math.Cos(eoe[3]) * Math.Sin(eoe[4]) * Math.Cos(eoe[5]);
            R[2][2] = Math.Cos(eoe[3]) * Math.Cos(eoe[4]);
            return R;
        }
    }
}
