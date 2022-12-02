using System;
using System.Collections.Generic;
using System.Text;

namespace 间接平差控制台
{
    class IndirectAdjustment
    {

        const int sideNum = 5;
        const int totalObservationNum = 11;
        const int necessaryObservationNum = 8;
        const int ρ = 206265;
        public static double w;
        static double[] observedValue =
            {
                325442,
                793855,
                1031756,
                817538,
                829690,
                1063158
            };
        static double[] distance =
            {
                908.018,
                533.226,
                623.836,
                545.382,
                609.897
            };
        static double[] observationMeanSquareError =
        {
                1.0,
                3.5,
                3.1,
                4.0,
                3.1,
                2.2,
                3.4,
                6.2,
                4.6,
                6.8,
                8.8,
            };

        /// <summary>
        /// 运行间接平差程序
        /// </summary>
        public static void Run()
        {
            double[] azimuth = new double[sideNum + 1];
            double[] locationX = new double[sideNum];
            double[] locationY = new double[sideNum];
            double[] a = new double[sideNum];
            double[] b = new double[sideNum];
            double[] L = new double[totalObservationNum];//观测值向量
            //赋计算初值
            azimuth[0] = 100 * 3600 + 20 * 60 + 30;//角度以秒的格式输入
            locationX[0] = 100.208;
            locationY[0] = 120.365;

            //计算各边方位角近似值
            IndirectAdjustment.GetAzimuth(azimuth);
            //将角度转化为弧度制
            IndirectAdjustment.ToRadians(observedValue);
            IndirectAdjustment.ToRadians(azimuth);
            //计算各点坐标近似值
            IndirectAdjustment.GetApproximationLocation(sideNum, azimuth, ref locationX, ref locationY);

            //求解系数阵B与权阵P
            IndirectAdjustment.GetRef(ref a, ref b, azimuth, locationX, locationY);
            double[][] B = IndirectAdjustment.GetMatrixB(a, b, azimuth);
            double[][] P = IndirectAdjustment.GetWeightMatrix();
            //解法方程
            double[][] N_bb = Matrix.MultMatrix(Matrix.MultMatrix(Matrix.TransposeMatrix(B), P), B);
            double[][] l = IndirectAdjustment.GetConstantTermMatrix(locationX, locationY, azimuth);
            Matrix.PrintMatrix(l, "");
            double[][] W = Matrix.MultMatrix(Matrix.MultMatrix(Matrix.TransposeMatrix(B), P), l);
            double[][] x = Matrix.MultMatrix(Matrix.InverseMatrix(N_bb), W);
            //求平差值
            double[][] V = IndirectAdjustment.ObservationCorrectionMatrix(B, x, l, P);
            IndirectAdjustment.GetAdjustmentValue(x, ref locationX, ref locationY);
            //求单位权中误差
            IndirectAdjustment.GetUnitMeanSquareError(P, V);
            //求观测值改正数
            MergeObservationVector(L);//将角度和距离数组合并为一个观测值向量
            IndirectAdjustment.ObservationAdjustmentMatrix(V, L);
            //输出平差结果
            Console.WriteLine("坐标平差结果为：");
            for (int i = 1; i < 5; i++)
            {
                Console.WriteLine("{0:F4}\t{1:F4}", locationX[i], locationY[i]);
            }

            //精度评定
            Matrix.PrintMatrix(GetVarianceCovarianceMatrix(N_bb), "坐标平差值及其方差协方差阵为：");
            Matrix.PrintMatrix(GetVarianceCovarianceMatrix(N_bb,B), "观测值的平差值及其方差协方差阵为：");
            IndirectAdjustment.CoordinatePointMeanSquareError(N_bb);
            SideLengthRelativeMeanSquareError(L);
            //计算误差椭圆三参数
            GetErrorEllipseParameter(N_bb);
        }

        /// <summary>
        /// 将角度和距离数组合并为一个观测值向量
        /// </summary>
        /// <param name="L">观测值向量</param>
        private static void MergeObservationVector(double[] L)
        {
            for (int i = 0; i < observedValue.Length + distance.Length; i++)
            {
                if (i < 6)
                {
                    L[i] = observedValue[i];
                }
                else
                {
                    L[i] = distance[i - 6];
                }
            }
        }


        /// <summary>
        /// 求单位中误差
        /// </summary>
        /// <param name="P"></param>
        /// <param name="V"></param>
        private static void GetUnitMeanSquareError(double[][] P, double[][] V)
        {
            w = Math.Sqrt(Math.Abs(Matrix.MultMatrix(Matrix.MultMatrix(Matrix.TransposeMatrix(V), P), V)[0][0] / totalObservationNum - necessaryObservationNum));
        }


        /// <summary>
        /// 计算各边近似方位角
        /// </summary>
        /// <param name="azimuth"></param>
        public static void GetAzimuth(double[] azimuth)
        {
            for (int i = 1; i <= sideNum; i++)//计算
            {
                azimuth[i] = azimuth[i - 1] + observedValue[i - 1] - 180 * 3600;
                if (azimuth[i] < 0)
                {
                    azimuth[i] += 360 * 3600;
                }
                else if (azimuth[i] > 360 * 3600)
                {
                    azimuth[i] -= 360 * 3600;
                }
            }
        }


        /// <summary>
        /// 将角度转化为弧度制
        /// </summary>
        /// <param name="array"></param>
        public static void ToRadians(double[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] /= IndirectAdjustment.ρ;
            }
        }


        /// <summary>
        /// 计算各点坐标近似值
        /// </summary>
        /// <param name="sideNum">多边形边数</param>
        /// <param name="azimuth">方位角数组</param>
        /// <param name="locationX">X坐标数组</param>
        /// <param name="locationY">Y坐标数组</param>
        public static void GetApproximationLocation(int sideNum, double[] azimuth, ref double[] locationX, ref double[] locationY)
        {
            for (int i = 1; i < sideNum; i++)
            {
                locationX[i] = locationX[i - 1] + distance[i - 1] * Math.Cos(azimuth[i]);
                locationY[i] = locationY[i - 1] + distance[i - 1] * Math.Sin(azimuth[i]);
            }
        }


        /// <summary>
        /// 得出系数阵B
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="azimuth">方位角数组</param>
        /// <returns>返回系数阵B</returns>
        public static double[][] GetMatrixB(double[] a, double[] b, double[] azimuth)
        {
            double[][] B = new double[totalObservationNum][];
            B[0] = new double[] { -a[0], -b[0], 0, 0, 0, 0, 0, 0 };
            B[1] = new double[] { a[0] + a[1], b[0] + b[1], -a[1], -b[1], 0, 0, 0, 0 };
            B[2] = new double[] { -a[1], -b[1], a[1] + a[2], b[1] + b[2], -a[2], -b[2], 0, 0 };
            B[3] = new double[] { 0, 0, -a[2], -b[2], a[2] + a[3], b[2] + b[3], -a[3], -b[3] };
            B[4] = new double[] { 0, 0, 0, 0, -a[3], -b[3], a[3] - a[4], b[3] - b[4] };
            B[5] = new double[] { -a[0], -b[0], 0, 0, 0, 0, a[4], b[4] };
            B[6] = new double[] { Math.Cos(azimuth[1]), Math.Sin(azimuth[1]), 0, 0, 0, 0, 0, 0 };
            B[7] = new double[] { -Math.Cos(azimuth[2]), -Math.Sin(azimuth[2]), Math.Cos(azimuth[2]), Math.Sin(azimuth[2]), 0, 0, 0, 0 };
            B[8] = new double[] { 0, 0, -Math.Cos(azimuth[3]), -Math.Sin(azimuth[3]), Math.Cos(azimuth[3]), Math.Sin(azimuth[3]), 0, 0 };
            B[9] = new double[] { 0, 0, 0, 0, -Math.Cos(azimuth[4]), -Math.Sin(azimuth[4]), Math.Cos(azimuth[4]), Math.Sin(azimuth[4]) };
            B[10] = new double[] { 0, 0, 0, 0, 0, 0, Math.Cos(azimuth[5]), Math.Sin(azimuth[5]) };
            return B;
        }


        /// <summary>
        /// 计算参数a、b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="azimuth">方位角数组</param>
        /// <param name="locationX">X坐标数组</param>
        /// <param name="locationY">Y坐标数组</param>
        public static void GetRef(ref double[] a, ref double[] b, double[] azimuth, double[] locationX, double[] locationY)
        {
            for (int i = 0; i < 4; i++)
            {
                a[i] = 0.001 * ρ * Math.Sin(azimuth[i + 1]) / Math.Sqrt(Math.Pow(locationX[i + 1] - locationX[i], 2) + Math.Pow(locationY[i + 1] - locationY[i], 2));
                b[i] = -0.001 * ρ * Math.Cos(azimuth[i + 1]) / Math.Sqrt(Math.Pow(locationX[i + 1] - locationX[i], 2) + Math.Pow(locationY[i + 1] - locationY[i], 2));

            }
            a[4] = 0.001 * ρ * Math.Sin(azimuth[5]) / Math.Sqrt(Math.Pow(locationX[4] - locationX[0], 2) + Math.Pow(locationY[4] - locationY[0], 2));
            b[4] = -0.001 * ρ * Math.Cos(azimuth[5]) / Math.Sqrt(Math.Pow(locationX[4] - locationX[0], 2) + Math.Pow(locationY[4] - locationY[0], 2));
        }


        /// <summary>
        /// 计算权阵
        /// </summary>
        /// <returns>返回权阵P</returns>
        public static double[][] GetWeightMatrix()
        {
            double[][] P = new double[totalObservationNum][];
            for (int i = 0; i < totalObservationNum; i++)
            {
                double[] temp = new double[totalObservationNum];
                for (int j = 0; j < totalObservationNum; j++)
                {
                    if (j == i)
                    {
                        temp[j] = 1 / Math.Pow(observationMeanSquareError[i], 2);
                    }
                    else if (j != i)
                    {
                        temp[j] = 0;
                    }
                }
                P[i] = temp;
            }
            return P;
        }


        /// <summary>
        /// 计算误差方程常数项矩阵
        /// </summary>
        /// <param name="locationX">X坐标数组</param>
        /// <param name="locationY">Y坐标数组</param>
        /// <param name="azimuth">方位角数组</param>
        /// <returns>返回常数项矩阵l</returns>
        public static double[][] GetConstantTermMatrix(double[] locationX, double[] locationY, double[] azimuth)
        {
            double[][] l = new double[totalObservationNum][];
            for (int i = 0; i < l.Length; i++)
            {
                l[i] = new double[1];
            }
            //前六行为角度
            l[0][0] = -Math.PI + observedValue[0] + azimuth[1] - Math.Atan((locationY[1] - locationY[0]) / (locationX[1] - locationX[0]));
            l[1][0] = -Math.PI + observedValue[1] - Math.Atan((locationY[2] - locationY[1]) / (locationX[2] - locationX[1])) + Math.Atan((locationY[1] - locationY[0]) / (locationX[1] - locationX[0])); ;
            l[2][0] = -2 * Math.PI + observedValue[2] - Math.Atan((locationY[3] - locationY[2]) / (locationX[3] - locationX[2])) + -Math.Atan((locationY[2] - locationY[1]) / (locationX[2] - locationX[1]));
            l[3][0] = -Math.PI + observedValue[3] - Math.Atan((locationY[4] - locationY[3]) / (locationX[4] - locationX[3])) + Math.Atan((locationY[3] - locationY[2]) / (locationX[3] - locationX[2]));
            l[4][0] = observedValue[4] + Math.Atan((locationY[4] - locationY[3]) / (locationX[4] - locationX[3])) - Math.Atan((locationY[4] - locationY[0]) / (locationX[4] - locationX[0])) - Math.PI;
            l[5][0] = observedValue[5] + Math.Atan((locationY[4] - locationY[0]) / (locationX[4] - locationX[0])) - Math.Atan((locationY[1] - locationY[0]) / (locationX[1] - locationX[0])) - 2 * Math.PI;
            //后四行为距离
            for (int i = 0; i < 6; i++)
            {
                l[i][0] /= 3600;
            }
            for (int i = 6; i < 10; i++)
            {
                l[i][0] = distance[i - 6] - Math.Sqrt(Math.Pow(locationX[i - 6] - locationX[i - 5], 2) + Math.Pow(locationY[i - 6] - locationY[i - 5], 2));
            }
            l[10][0] = distance[4] - Math.Sqrt(Math.Pow(locationX[4] - locationX[0], 2) + Math.Pow(locationY[4] - locationY[0], 2));
            return l;

        }


        /// <summary>
        /// 计算平差值
        /// </summary>
        /// <param name="x">坐标改正数矩阵</param>
        /// <param name="locationX">X坐标数组</param>
        /// <param name="locationY">Y坐标数组</param>
        public static void GetAdjustmentValue(double[][] x, ref double[] locationX, ref double[] locationY)
        {
            //foreach (double[] item in x)
            //{
            //    item = new double[1];
            //}
            for (int i = 0; i < 4; i++)
            {
                locationX[i + 1] += x[2 * i][0] * 0.001;
                locationY[i + 1] += x[2 * i + 1][0] * 0.001;
            }
        }


        /// <summary>
        /// 观测量改正数矩阵V
        /// </summary>
        /// <param name="B"></param>
        /// <param name="x"></param>
        /// <param name="l"></param>
        /// <param name="P"></param>
        /// <returns>返回观测量改正数矩阵V</returns>
        public static double[][] ObservationCorrectionMatrix(double[][] B, double[][] x, double[][] l, double[][] P)
        {
            double[][] V = new double[totalObservationNum][];
            double[][] Bx = new double[totalObservationNum][];
            for (int i = 0; i < Bx.Length; i++)
            {
                V[i] = new double[1];
            }
            Bx = Matrix.MultMatrix(B, x);
            for (int i = 0; i < totalObservationNum; i++)
            {
                V[i][0] = Bx[i][0] - l[i][0];
            }
            return V;
        }


        /// <summary>
        /// 求观测量平差值
        /// </summary>
        /// <param name="V">观测量改正数矩阵</param>
        /// <param name="L">观测量数组</param>
        /// <returns>返回观测量平差值矩阵L_Adjustment</returns>
        public static double[][] ObservationAdjustmentMatrix(double[][] V, double[] L)
        {
            double[][] L_Adjustment = new double[totalObservationNum][];
            for (int i = 0; i < V.Length; i++)
            {
                V[i] = new double[1];
                L_Adjustment[i] = new double[1];
            }
            for (int i = 0; i < V.Length; i++)
            {
                L_Adjustment[i][0] = V[i][0] + L[i];
            }
            return L_Adjustment;
        }


        /// <summary>
        /// 计算误差椭圆三参数
        /// </summary>
        /// <param name="N"></param>
        public static void GetErrorEllipseParameter(double[][] N)
        {
            double[] E = new double[sideNum - 1];
            double[] F = new double[sideNum - 1];
            double[] tn = new double[sideNum - 1];
            for (int i = 0; i < N.Length; i++)
            {
                for (int j = 0; j < N.Length; j++)
                {
                    N[i][j] *= w;
                }
            }
            for (int i = 0; i < sideNum - 1; i++)
            {
                E[i] = Math.Sqrt(Math.Abs(0.5 * (N[2 * i][2 * i] + N[2 * i + 1][2 * i + 1] + Math.Sqrt(Math.Abs(Math.Pow(N[2 * i][2 * i] - N[2 * i + 1][2 * i + 1], 2) + 4 * N[2 * i][2 * i + 1])))));
                F[i] = Math.Sqrt(Math.Abs(0.5 * (N[2 * i][2 * i] + N[2 * i + 1][2 * i + 1] - Math.Sqrt(Math.Abs(Math.Pow(N[2 * i][2 * i] - N[2 * i + 1][2 * i + 1], 2) + 4 * N[2 * i][2 * i + 1])))));
                tn[i] = 0.5 * Math.Atan(N[2 * i][2 * i + 1] / (N[2 * i][2 * i] - N[2 * i + 1][2 * i + 1]));
            }
        }


        /// <summary>
        /// 计算待定点坐标的点位中误差
        /// </summary>
        /// <param name="N_bb"></param>
        /// <returns>返回点位中误差</returns>
        public static void CoordinatePointMeanSquareError(double[][] N_bb)
        {
            double[] σ = new double[necessaryObservationNum];
            for (int i = 0; i < N_bb.Length; i++)
            {
                for (int j = 0; j < N_bb[0].Length; j++)
                {
                    if (i == j && i % 2 == 0)
                    {
                        σ[i] = w * Math.Sqrt(N_bb[i][j]);
                    }
                    else if (i == j && i % 2 == 1)
                    {
                        σ[i] = Math.Sqrt(Math.Pow(σ[i - 1], 2) + Math.Pow(w * Math.Sqrt(N_bb[i][j]), 2));
                    }
                }
            }
            Console.WriteLine("待定点坐标的点位中误差为：");
            for (int i = 0; i < σ.Length; i++)
            {
                if (i % 2 == 1)
                {
                    Console.WriteLine("{0:F4}", σ[i]);
                }
            }
        }


        /// <summary>
        /// 计算坐标平差值及其方差协方差阵
        /// </summary>
        /// <param name="N_bb"></param>
        /// <returns></returns>
        public static double[][] GetVarianceCovarianceMatrix(double[][] N_bb)
        {
            double[][] VC = Matrix.InverseMatrix(N_bb);
            for (int i = 0; i < VC.Length; i++)
            {
                for (int j = 0; j < VC[0].Length; j++)
                {
                    VC[i][j]*=Math.Pow(w, 2);
                }
            }
            return VC;
        }


        /// <summary>
        /// 重载求观测值的平差值的方差协方差阵
        /// </summary>
        /// <param name="N_bb"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static double[][] GetVarianceCovarianceMatrix(double[][] N_bb,double[][] B)
        {
            double[][] VC = Matrix.MultMatrix(Matrix.MultMatrix(B, Matrix.InverseMatrix(N_bb)), Matrix.TransposeMatrix(B));
            for (int i = 0; i < VC.Length; i++)
            {
                for (int j = 0; j < VC[0].Length; j++)
                {
                    VC[i][j] *= Math.Pow(w, 2);
                }
            }
            return VC;
        }


        /// <summary>
        /// 求边长相对中误差
        /// </summary>
        /// <param name="L">观测值平差值</param>
        /// <returns></returns>
        public static void SideLengthRelativeMeanSquareError(double[] L)
        {
            double[] Relative_σ = new double[sideNum];
            Console.WriteLine("边长相对中误差为：");
            for (int i = 0; i < L.Length; i++)
            {
                if (i > 5)
                {
                    Relative_σ[i - 6] = observationMeanSquareError[i] / L[i];
                    //对分母进行四舍五入运算
                    string s = (1/Relative_σ[i - 6]).ToString("0");
                    Relative_σ[i - 6] = Convert.ToInt32(s);
                    //在方法中直接输出（1/x的形式）
                    Console.WriteLine("1/{0}",Relative_σ[i - 6]);
                }
            }
        }
    }
}
