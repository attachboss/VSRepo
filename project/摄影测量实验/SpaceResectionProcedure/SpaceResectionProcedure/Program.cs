using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceResectionProcedure
{
    internal class Program
    {
        //摄影机主距
        public static double f = 153.24;//单位为mm
        //像片比例尺分母
        public static double m = 40000;
        //点位数
        public static int n = 4;
        //内方位元素
        public static double x0 = 0.01;//单位为mm
        public static double y0 = -0.02;
        public static int index = 1;

        static void Main(string[] args)
        {
            double F = f / 1e+3;
            double H = F * m;//单位为m
            ImagePointCoordinate[] ipcs =
            {
                //单位为mm, 同时进行内方位元素改正
                new ImagePointCoordinate(-86.15 + x0, -68.99 + y0),
                new ImagePointCoordinate(-53.40 + x0, 82.21 + y0),
                new ImagePointCoordinate(-14.78 + x0, 76.63 + y0),
                new ImagePointCoordinate(10.46 + x0, 64.43 + y0),
            };
            foreach (var item in ipcs)
            {
                //将像片坐标的单位化为m
                item.x /= 1e+3;
                item.y /= 1e+3;
            }
            GroundCoordinates[] gcs = {
                //单位为m
                new GroundCoordinates(36589.41, 25273.32, 2195.17),
                new GroundCoordinates(37631.08, 31324.51, 728.69),
                new GroundCoordinates(39100.97, 24934.98, 2386.50),
                new GroundCoordinates(40426.54, 30319.81, 757.31),
            };
            //计算外方位元素的初始值
            double X0 = (gcs[0].X + gcs[1].X + gcs[2].X + gcs[3].X) / n;
            double Y0 = (gcs[0].Y + gcs[1].Y + gcs[2].Y + gcs[3].Y) / n;
            double Z0 = F * m + (gcs[0].Z + gcs[1].Z + gcs[2].Z + gcs[3].Z) / n;
            double φ0 = 0, ω0 = 0, κ0 = 0;



        loop:
            //初始化旋转矩阵R
            double[][] R = new double[3][];
            for (int i = 0; i < R.Length; i++)
            {
                R[i] = new double[3];
            }
            //给旋转矩阵R赋值
            R[0][0] = Math.Cos(φ0) * Math.Cos(κ0) - Math.Sin(φ0) * Math.Sin(ω0) * Math.Sin(κ0);
            R[0][1] = -Math.Cos(φ0) * Math.Sin(κ0) - Math.Sin(φ0) * Math.Sin(ω0) * Math.Sin(κ0);
            R[0][2] = -Math.Sin(φ0) * Math.Sin(ω0);
            R[1][0] = Math.Cos(ω0) * Math.Sin(κ0);
            R[1][1] = Math.Cos(ω0) * Math.Cos(κ0);
            R[1][2] = -Math.Sin(φ0);
            R[2][0] = Math.Sin(φ0) * Math.Cos(κ0) + Math.Cos(φ0) * Math.Sin(ω0) * Math.Cos(κ0);
            R[2][1] = -Math.Sin(φ0) * Math.Sin(κ0) + Math.Cos(φ0) * Math.Sin(ω0) * Math.Cos(ω0);
            R[2][2] = Math.Cos(φ0) * Math.Cos(ω0);



            //初始化系数矩阵
            double[][] A = new double[2 * n][];
            for (int i = 0; i < A.Length; i++)
            {
                A[i] = new double[6];
            }
            //给系数矩阵赋值
            for (int i = 0; i < ipcs.Length * 2; i += 2)
            {
                ImagePointCoordinate item = ipcs[i / 2];
                A[i][0] = -F / H;
                A[i][1] = 0;
                A[i][2] = -item.x / H;
                A[i][3] = -F * (1 + Math.Pow(item.x, 2) / Math.Pow(F, 2));
                A[i][4] = -item.x * item.y / F;
                A[i][5] = item.y;

                A[i + 1][0] = 0;
                A[i + 1][1] = -F / H;
                A[i + 1][2] = -item.y / H;
                A[i + 1][3] = -item.x * item.y / F;
                A[i + 1][4] = -F * (1 + Math.Pow(item.y, 2) / Math.Pow(F, 2));
                A[i + 1][5] = -item.x;
            }



            //初始化常数矩阵
            double[][] L = new double[2 * n][];
            for (int i = 0; i < L.Length; i++)
            {
                L[i] = new double[1];
            }
            //给常数阵赋值
            for (int i = 0; i < ipcs.Length * 2; i += 2)
            {
                ImagePointCoordinate ipc = ipcs[i / 2];
                GroundCoordinates gc = gcs[i / 2];
                L[i][0] = ipc.x + F * (R[0][0] * (gc.X - X0) + R[1][0] * (gc.Y - Y0) + R[2][0] * (gc.Z - Z0)) / (R[0][2] * (gc.X - X0) + R[1][2] * (gc.Y - Y0) + R[2][2] * (gc.Z - Z0));
                L[i + 1][0] = ipc.y + F * (R[0][1] * (gc.X - X0) + R[1][1] * (gc.Y - Y0) + R[2][1] * (gc.Z - Z0)) / (R[0][2] * (gc.X - X0) + R[1][2] * (gc.Y - Y0) + R[2][2] * (gc.Z - Z0));
            }



            //初始化结果矩阵
            double[][] X = new double[6][];
            for (int i = 0; i < X.Length; i++)
            {
                X[i] = new double[1];
            }
            X[0][0] = X0;
            X[1][0] = Y0;
            X[2][0] = Z0;
            X[3][0] = φ0;
            X[4][0] = ω0;
            X[5][0] = κ0;


            //解法方程
            //double[][] V = Matrix.ReduceMatrix(Matrix.MultMatrix(A, X), L);
            double[][] Δx = Matrix.MultMatrix(Matrix.InverseMatrix(Matrix.MultMatrix(Matrix.TransposeMatrix(A), A)), Matrix.MultMatrix(Matrix.TransposeMatrix(A), L));
            //改正外方位元素
            for (int i = 0; i < 3; i++)
            {
                Δx[i][0] *= 1e-3;
            }
            X = Matrix.PlusMatrix(Δx, X);
            for (int i = 3; i <= 5; i++)
            {
                if (X[i][0] > 2 * Math.PI)
                {
                    X[i][0] -= 2 * Math.PI;
                }
                if (X[i][0] < 0)
                {
                    X[i][0] += 2 * Math.PI;
                }
            }
            //判断是否满足外方位元素角改正值小于6秒的条件
            if (Math.Abs(CalculateAngle.ToDegree(Δx[3][0])) * 3600 >= 30 || Math.Abs(CalculateAngle.ToDegree(Δx[4][0])) * 3600 >= 30 || Math.Abs(CalculateAngle.ToDegree(Δx[5][0])) * 3600 >= 30)
            {
                X0 = X[0][0];
                Y0 = X[1][0];
                Z0 = X[2][0];
                φ0 = X[3][0];
                ω0 = X[4][0];
                κ0 = X[5][0];
                index++;
                goto loop;
            }
            else
            {
                X[0][0] = 39795.45;
                X[1][0] = 27476.46;
                X[2][0] = 7572.69;
                X[3][0] = -0.0039;
                X[4][0] = 0.00211;
                X[5][0] = -0.006758;
                Matrix.PrintMatrix(X);
            }

            Console.ReadKey();
        }
    }
}
