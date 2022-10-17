using System;

namespace 坐标系转换
{
    class Program
    {
        const int a = 6378245;
        public static double e = Math.Sqrt(0.006693421622966);
        static void Main(string[] args)
        {
            double epsilon = 0.00001;
            int i=0;
            Console.WriteLine("请选择：\n1、空间直角坐标系转换为大地坐标系\n2、大地坐标系转换为空间直角坐标系");
            string option = Console.ReadLine();
            switch (option)
            {
                #region option1
                case "1":
                    Console.WriteLine("请输入空间坐标(X，Y，Z)");
                    double x = Convert.ToDouble(Console.ReadLine());
                    double y = Convert.ToDouble(Console.ReadLine());
                    double z = Convert.ToDouble(Console.ReadLine());
                    double l = Math.Atan(y / x);//通过x,y得出L的值
                    double b0 = Math.Atan(z / Math.Sqrt(x * x + y * y));//B0初值
                    double b1 = 0;
                    while (Math.Abs(b1 - b0) >= epsilon)
                    {
                        b1 = b0;
                        b0 = Math.Atan((1 / (Math.Sqrt(x * x + y * y))) * (z + a * e * e * Math.Tan(b0) / Math.Sqrt(1 + Math.Tan(b0) * Math.Tan(b0) - e * e * Math.Tan(b0) * Math.Tan(b0))));
                        i++;
                    }
                    double W = Math.Sqrt(1 - e * e * Math.Sin(b0) * Math.Sin(b0));//通过迭代出的B值求第一辅助函数
                    double N = a / W;
                    double h = Math.Sqrt(x * x + y * y) / Math.Cos(b0) - N;//求大地高H
                    l *= 180 / Math.PI;//将角度转化为弧度制
                    b0 *= 180 / Math.PI;
                    if (l < 0)//规定大地经度（向东量度）的范围
                    {
                        l += 180;
                    }
                    else if (l > 180)
                    {
                        l -= 180;
                    }
                    if (b0 < 0)//规定大地纬度的范围为（0，90）
                    {
                        b0 += 90;
                    }
                    else if (b0 > 90)
                    {
                        b0 -= 90;
                    }

                    Console.WriteLine("转换后为：\nL:{0:0.000000}", l);
                    Console.WriteLine("转换后为：\nB:{0:0.000000}", b0);
                    Console.WriteLine("\nH:{0:0}", h);
                    Console.WriteLine("迭代了{0}次",i);
                    break;
                #endregion
                #region option2
                case "2":
                    double L, B;
                    Console.Write("请输入大地坐标(用逗号隔开度分秒)：\nL=");
                    string str = Console.ReadLine();
                    L = Convert.ToDouble(str);

                    Console.Write("\nB=");
                    str = Console.ReadLine();
                    B = Convert.ToDouble(str);

                    Console.Write("\nH=");
                    str = Console.ReadLine();
                    double H = Convert.ToDouble(str);
                    W = Math.Sqrt(1 - e * e * Math.Sin(B / 180 * Math.PI) * Math.Sin(B / 180 * Math.PI));
                    N = a / W;

                    double X = (N + H) * Math.Cos(B / 180 * Math.PI) * Math.Cos(L / 180 * Math.PI);
                    double Y = (N + H) * Math.Cos(B / 180 * Math.PI) * Math.Sin(L / 180 * Math.PI);
                    double Z = (N * (1 - e * e) + H) * Math.Sin(B / 180 * Math.PI);
                    Console.WriteLine("转换结果为：\nX:{0:0.000}\nY:{1:0.000}\nZ:{2:0.000}", X, Y, Z);
                    break;
                    #endregion
            }
            Console.ReadKey();
        }
    }
}