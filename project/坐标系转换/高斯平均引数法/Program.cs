using System;
using System.Collections.Generic;

namespace 高斯平均引数法
{
    class Program
    {
        const int a = 6378245;
        const int ρ = 206265;
        public static double e1 = Math.Sqrt(0.00669342162297);
        public static double e2 = Math.Sqrt(0.00673852541468);
        public static double ε1 = 0.0001;
        public static double ε2 = 0.001;
        static void Main(string[] args)
        {
            double Bm, Lm, Am = 0, Wm, Nm, Mm, tm, ηm, B2, L2, A21 = 0;

            Console.WriteLine("请选择：\n1、高斯平均引数正算解算\n2、高斯平均引数反算解算");
            string option = Console.ReadLine();
            switch (option)
            {
                #region 正算
                case "1":
                    Console.WriteLine("请输入大地经度L1，大地纬度B1，大地方位角A12(转化为秒的格式输入)和大地线长度S：");
                    double L1 = Convert.ToDouble(Console.ReadLine());
                    double B1 = Convert.ToDouble(Console.ReadLine());
                    double A12 = Convert.ToDouble(Console.ReadLine());
                    double S = Convert.ToDouble(Console.ReadLine());

                    double W1 = Math.Sqrt(1 - Math.Pow(e1 * Math.Sin(B1 / ρ), 2));
                    double N1 = Program.a / W1;
                    double M1 = Program.a * (1 - Math.Pow(e1, 2)) / Math.Pow(W1, 3);
                    double t1 = Math.Tan(B1 / ρ);
                    double η1 = Math.Sqrt(Math.Pow(e2 * Math.Cos(B1 / ρ), 2));

                    double ΔB0 = ρ * S * Math.Cos(A12 / ρ) / M1;
                    double ΔL0 = ρ * S * Math.Sin(A12 / ρ) / N1 / Math.Cos(B1 / ρ);
                    double ΔA0 = ρ * S * Math.Sin(A12 / ρ) * Math.Tan(B1 / ρ) / N1;
                    double ΔB1 = 0, ΔL1 = 0, ΔA1 = 0, ΔBn = 0, ΔLn = 0, ΔAn = 0;

                    while ((Math.Abs(ΔBn - ΔB1) < ε1) && Math.Abs(ΔLn - ΔL1) < ε1 && Math.Abs(ΔAn - ΔA1) < ε2)
                    {
                        ΔBn = ΔB1;
                        ΔLn = ΔL1;
                        ΔAn = ΔA1;
                        Bm = B1 + 0.5 * ΔB0;
                        Lm = B1 + 0.5 * ΔL0;
                        Am = B1 + 0.5 * ΔA0;

                        Wm = Math.Sqrt(1 - Math.Pow(e1 * Math.Sin(Bm / ρ), 2));
                        Nm = Program.a / Wm;
                        Mm = Program.a * (1 - Math.Pow(e1, 2)) / Math.Pow(Wm, 3);
                        tm = Math.Tan(Bm / ρ);
                        ηm = Math.Sqrt(Math.Pow(e2 * Math.Cos(Bm / ρ), 2));

                        ΔB1 = ρ / Mm * S * Math.Cos(Am / ρ) * (1 + Math.Pow(S, 2) / 24 / Math.Pow(Nm, 2) * (Math.Pow(Math.Sin(Am / ρ), 2) * (2 + 3 * Math.Pow(tm, 2) + 2 * Math.Pow(tm * ηm, 2)) + 3 * Math.Pow(ηm * Math.Cos(Am / ρ), 2) * (-1 + Math.Pow(tm, 2) - Math.Pow(ηm, 2) - Math.Pow(2 * tm * ηm, 2))));
                        ΔL1 = ρ / Nm / Math.Cos(Bm / ρ) * S * Math.Sin(Am / ρ) * (1 + S * S / 24 / Nm / Nm * (Math.Pow(Math.Sin(Am / ρ) * tm, 2) - Math.Pow(Math.Cos(Am / ρ), 2) * (1 + Math.Pow(ηm, 2) - 9 * Math.Pow(tm * ηm, 2) + Math.Pow(ηm, 4))));
                        ΔA1 = ρ / Nm * S * Math.Sin(Am / ρ) * tm * (1 + S * S / 24 / Nm / Nm * (Math.Pow(Math.Cos(Am / ρ), 2) * (2 + 7 * Math.Pow(ηm, 2) + 9 * Math.Pow(tm * ηm, 2) + 5 * Math.Pow(ηm, 4)) + Math.Pow(Math.Sin(Am / ρ), 2) * (2 + Math.Pow(tm, 2) + 2 * Math.Pow(ηm, 2))));
                    }
                    //计算B2,L2,A21
                    B2 = B1 + ΔB1;
                    L2 = L1 + ΔL1;
                    if (A12 < 180 * 3600)
                    {
                        A21 = A12 + ΔA1 + 180 * 3600;
                    }
                    else if (A12 > 180 * 3600)
                    {
                        A21 = A12 + ΔA1 - 180 * 3600;
                    }
                    Console.WriteLine("计算得出:\nL2:{0}\nB2:{1}\nA21:{2}", L2, B2, A21);

                    break;
                #endregion
                #region 反算
                case "2":
                    Console.WriteLine("请输入两点大地坐标经差、纬差、Bm");
                    double ΔL = (468612.2676 - 471399.8316553754) / ρ;
                    double ΔB = (148235.6874 - 150626.14256905808) / ρ;
                    Bm = 149823.22153035927;

                    Wm = Math.Sqrt(1 - Math.Pow(e1 * Math.Sin(Bm / ρ), 2));
                    Nm = Program.a / Wm;
                    double Vm = Wm * Math.Sqrt(1 + e2 * e2);
                    tm = Math.Tan(Bm / ρ);
                    ηm = Math.Sqrt(Math.Pow(e2 * Math.Cos(Bm / ρ), 2));

                    double r01 = Nm * Math.Cos(Bm / ρ);
                    double r21 = r01 / 24 / Vm / Vm * (1 + Math.Pow(ηm, 2) - 9 * Math.Pow(tm * ηm, 2) + Math.Pow(ηm, 4));
                    double r03 = -Nm / 24 * Math.Pow(Math.Cos(Bm / ρ), 3) * Math.Pow(tm, 2);
                    double s10 = Nm / Math.Pow(Vm, 2);
                    double s12 = -1 * s10 / 24 * Math.Pow(Math.Cos(Bm / ρ), 2) * (2 + 3 * tm * tm + 2 * ηm * ηm);
                    double s30 = Nm / 8 * Math.Pow(Vm, 6) * (ηm * ηm - Math.Pow(tm * ηm, 2) + Math.Pow(ηm, 4));
                    double t01 = tm * Math.Cos(Bm / ρ);
                    double t21 = t01 * t01 / 24 / Math.Pow(Vm, 4) * (2 + 7 * ηm * ηm + 9 * Math.Pow(tm * ηm, 2) + 5 * Math.Pow(ηm, 4));
                    double t03 = t01 / 24 * Math.Pow(Math.Cos(Bm / ρ), 2) * (2 + Math.Pow(tm, 2) + 2 * Math.Pow(ηm, 2));

                    double S_sinAm = r01 * ΔL + r21 * ΔB * ΔB * ΔL + t03 * Math.Pow(ΔL, 3);
                    double S_cosAm = s10 * ΔB + s12 * ΔB * ΔL * ΔL + t03 * Math.Pow(ΔB, 3);
                    double ΔA = t01 * ΔL + t21 * ΔL * ΔB * ΔB + t03 * Math.Pow(ΔL, 3);

                    double S12 = Math.Sqrt(Math.Abs(Math.Pow(S_sinAm, 2) + Math.Pow(S_cosAm, 2)));
                    double T = 0;
                    if (Math.Abs(ΔB) >= Math.Abs(ΔL))
                    {
                        T = Math.Atan(Math.Abs(S_sinAm / S_cosAm));
                    }
                    else if (Math.Abs(ΔB) <= Math.Abs(ΔL))
                    {
                        double c = Math.Abs(S_cosAm / S_sinAm);
                        T = Math.PI / 4 + Math.Atan(Math.Abs((1 - c) / (1 + c)));
                    }

                    if (ΔB > 0 && ΔL >= 0)
                        Am = T;
                    else if (ΔB < 0 && ΔL >= 0)
                        Am = Math.PI - T;
                    else if (ΔB <= 0 && ΔL < 0)
                        Am = Math.PI + T;
                    else if (ΔB > 0 && ΔL < 0)
                        Am = 2 * Math.PI - T;
                    else if (ΔB == 0 && ΔL > 0)
                        Am = Math.PI / 2;

                    A12 = Am - ΔA / 2;
                    if (A12 >= Math.PI)
                        A21 = Am + ΔA / 2 - Math.PI;
                    else if (A12 < Math.PI)
                        A21 = Am + ΔA / 2 + Math.PI;

                    Console.WriteLine("计算得出:\nS12:{0}\nA12:{1}\nA21:{2}", S12, A12 * 180 / Math.PI, A21 * 180 / Math.PI);
                    break; 
                    #endregion
            }
            Console.ReadKey();
        }

    }
}
//正算数据：
//学号尾号数据
//L1: 468612.2676
//B1: 148235.6874
//A12:6583
//S:  98000

//B2:41.840595158071686
//L2:130.94439768204873
//A21:182.3428947855761

//L2: 471399.8316553754-468612.2676
//B2: 150626.14256905808-148235.6874
//Bm: 149823.22153035927

//324000
//126000
//360000
//15000000