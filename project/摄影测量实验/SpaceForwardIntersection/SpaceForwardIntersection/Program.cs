using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceForwardIntersection
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
            ipc_left = CorrectInternalOrientationElement(ipc_left, x0, y0);
            ipc_right = CorrectInternalOrientationElement(ipc_right, x0, y0);
            //像片的外方位元素，前三个为摄影中心坐标(单位为m)，后三个为航摄飞机姿态角度(单位为°)
            double[] eoe_left = { 14922.9778, 11532.4077, 3230.3383, -0.0566, -0.1215, -0.6456 };
            double[] eoe_right = { 16296.9601, 11524.2256, 3239.6070, 0.0429, -0.5148, -0.1538 };
            //角度转弧度
            for (int i = 3; i < 6; i++)
            {
                eoe_left[i] = CalculateAngle.ToRadian(eoe_left[i]);
                eoe_right[i] = CalculateAngle.ToRadian(eoe_right[i]);
            }

            //初始化矩阵
            double[][] x1 = new double[3][], x2 = new double[3][], X1 = new double[3][], X2 = new double[3][], R1 = new double[3][], R2 = new double[3][], X = new double[3][];
            for (int j = 0; j < x1.Length; j++)
            {
                x1[j] = new double[1];
                x2[j] = new double[1];
                X1[j] = new double[1];
                X2[j] = new double[1];
                R1[j] = new double[3];
                R2[j] = new double[3];
                X[j] = new double[1];
            }
            //循环点数次求解
            for (int i = 0; i < ipc_left.Length; i++)
            {
                R1 = GetMatR(eoe_left, R1);
                x1[0][0] = ipc_left[i].x;
                x1[1][0] = ipc_left[i].y;
                x1[2][0] = -f;
                X1 = Matrix.MultMatrix(R1, x1);

                R2 = GetMatR(eoe_right, R2);
                x2[0][0] = ipc_right[i].x;
                x2[1][0] = ipc_right[i].y;
                x2[2][0] = -f;
                X2 = Matrix.MultMatrix(R2, x2);

                double Bx = eoe_right[0] - eoe_left[0];
                double By = eoe_right[1] - eoe_left[1];
                double Bz = eoe_right[2] - eoe_left[2];

                double N1 = (Bx * X2[2][0] - Bz * X2[0][0]) / (X1[0][0] * X2[2][0] - X2[0][0] * X1[2][0]);
                double N2 = (Bx * X1[2][0] - Bz * X1[0][0]) / (X1[0][0] * X2[2][0] - X2[0][0] * X1[2][0]);

                X[0][0] = (eoe_left[0] + N1 * X1[0][0]);
                X[1][0] = ((eoe_left[1] + N1 * X1[1][0]) + (eoe_right[1] + N2 * X2[1][0])) / 2;
                X[2][0] = (eoe_left[2] + N1 * X1[2][0]);
                Matrix.PrintMatrix(X);


            }
            Console.ReadKey();
        }

        /// <summary>
        /// 初始化旋转矩阵R
        /// </summary>
        /// <param name="eoe"></param>
        /// <param name="R"></param>
        /// <returns></returns>
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
    }
}

