using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 白塞尔大地主题解算
{
    internal class Program
    {
        const int a = 6378245;
        const int ρ = 206265;
        public static double e1 = Math.Sqrt(0.00669342162297);
        public static double e2 = Math.Sqrt(0.00673852541468);
        static void Main(string[] args)
        {
            Console.WriteLine("请选择：\n1、白塞尔大地主题正算解算\n2、白塞尔大地主题反算解算");
            string option = Console.ReadLine();
            switch (option)
            {
                #region 正算解算
                case "1":
                    Console.WriteLine("请输入大地经度L1，大地纬度B1，大地方位角A12(转化为秒的格式输入)和大地线长度S：");
                    double L1 = Convert.ToDouble(Console.ReadLine());
                    double B1 = Convert.ToDouble(Console.ReadLine());
                    double A12 = Convert.ToDouble(Console.ReadLine());
                    double S = Convert.ToDouble(Console.ReadLine());

                    double u1 = Math.Atan(Math.Sqrt((1 - e1 * e1)) * Math.Tan(B1 / ρ));
                    double m = Math.Asin(Math.Cos(u1) * Math.Sin(A12 / ρ));
                    if (m <= 0)
                        m += 2 * Math.PI;
                    double M = Math.Atan(Math.Tan(u1) / Math.Cos(A12 / ρ));
                    if (M <= 0)
                        M += Math.PI;
                    double α, β, γ, k2, α2, β2;
                    GetParameter1(m, out α, out β, out γ);

                    //σ为迭代初值
                    double σ0 = 0;
                    double σ = α * S;
                    while (Math.Abs(σ - σ0) >= 0.001)
                    {
                        σ0 = σ;
                        σ = α * S + β * Math.Sin(σ0) * Math.Cos(2 * M + σ0) + γ * Math.Sin(2 * σ0) * Math.Cos(4 * M + 2 * σ0);
                    }

                    σ /= ρ;
                    //计算A21
                    double A21 = Math.Atan(Math.Tan(m) / Math.Cos(M + σ));
                    if (A21 <= 0)
                        A21 += Math.PI;
                    if (A12 / ρ <= Math.PI)
                        A21 += Math.PI;

                    //B2
                    double u2 = Math.Atan(-1 * Math.Cos(A21) * Math.Tan(M + σ));
                    double B2 = Math.Atan(Math.Sqrt(Math.Abs(1 + e2 * e2)) * Math.Tan(u2));

                    //计算L2
                    double L2, l;
                    double λ1 = Math.Atan(Math.Sin(u1) * Math.Tan(A12 / ρ));
                    if (λ1 <= 0)
                        λ1 += Math.PI;
                    if (m >= Math.PI)
                        λ1 += Math.PI;
                    double λ2 = Math.Atan(Math.Sin(u2) * Math.Tan(A21));
                    if (λ2 <= 0)
                        λ2 += Math.PI;
                    if (m < Math.PI)
                    {
                        if ((M + σ) < Math.PI)
                        {
                            GetParameter2(m, out k2, out α2, out β2);
                        }
                        else
                            λ2 += Math.PI;
                        GetParameter2(m, out k2, out α2, out β2);
                    }
                    else
                    {
                        if ((M + σ) > Math.PI)
                        {
                            GetParameter2(m, out k2, out α2, out β2);
                        }
                        else
                            λ2 += Math.PI;
                        GetParameter2(m, out k2, out α2, out β2);
                    }
                    double λ = λ2 - λ1;

                    l = λ - Math.Sin(m) * (α2 * σ + β2 * (Math.Sin(σ) * Math.Cos(2 * M + σ)));
                    L2 = L1 / ρ + l;
                    Console.WriteLine("白塞尔大地主题正算解算得：\nL2:{0}\nB2:{1}\nA21:{2}", L2 * 180 / Math.PI, B2 * 180 / Math.PI, A21 * 180 / Math.PI);
                    break;
                #endregion
                #region 反算解算
                case "2":
                    Console.WriteLine("请输入大地经度L1，大地纬度B1，L2,B2,(转化为秒的格式输入)：");
                    L1 = 468612.2676;
                    B1 = 148235.6874;
                    L2 = 468729.502550613;//Convert.ToDouble(Console.ReadLine());
                    B2 = 151089.849819323;//Convert.ToDouble(Console.ReadLine());

                    u1 = Math.Atan(Math.Sqrt((1 - e1 * e1)) * Math.Tan(B1 / ρ));
                    u2 = Math.Atan(Math.Sqrt((1 - e1 * e1)) * Math.Tan(B2 / ρ));
                    l = L2 - L1;
                    σ0 = Math.Acos(Math.Sin(u1) * Math.Sin(u2) + Math.Cos(u1) * Math.Cos(u2) * Math.Cos(l / ρ));
                    double m0 = Math.Asin(Math.Cos(u1) * Math.Cos(u2) * Math.Sin(l / ρ) / Math.Sin(σ0));
                    GetParameter2(m0, out k2, out α2, out β2);
                    double λ0 = l / ρ + α2 * σ0 * Math.Sin(m0);
                    double σ1 = σ0 + Math.Sin(m0) * α2 * σ0 * Math.Sin(m0);
                    m = Math.Asin(Math.Cos(u1) * Math.Cos(u2) * Math.Sin(λ0) / Math.Sin(σ1));
                    double A0 = Math.Atan(Math.Sin(λ0) / (Math.Cos(u1) * Math.Tan(u2) - Math.Sin(u1) * Math.Cos(λ0)));
                    if (A0 <= 0)
                        A0 += Math.PI;
                    if (m <= 0)
                        A0 += Math.PI;
                    M = Math.Atan(Math.Sin(u1) / Math.Sin(m) * Math.Tan(A0));
                    if (M <= 0)
                        M += Math.PI;
                    GetParameter2(m, out k2, out α2, out β2);
                    λ = l / ρ + Math.Sin(m) * (α2 * σ0 + β2 * (Math.Sin(σ0) * Math.Cos(2 * M + σ0)));

                    //A12、A21
                    σ = Math.Acos(Math.Sin(u1) * Math.Sin(u2) + Math.Cos(u1) * Math.Cos(u2) * Math.Cos(λ));

                    A12 = Math.Atan(Math.Sin(λ) / (Math.Cos(u1) * Math.Tan(u2) - Math.Sin(u1) * Math.Cos(λ)));
                    if (A12 <= 0)
                        A12 += Math.PI;
                    if (m <= 0)
                        A12 += Math.PI;
                    A21 = Math.Atan(Math.Sin(λ) / (Math.Sin(u1) * Math.Cos(λ) - Math.Tan(u1) * Math.Cos(u2)));
                    if (A21 <= 0)
                        A21 += Math.PI;
                    if (m >= 0)
                        A21 += Math.PI;

                    //S
                    GetParameter1(m, out α, out β, out γ);
                    S = (σ * ρ - β * Math.Sin(σ) * Math.Cos(2 * M + σ) - γ * Math.Sin(2 * σ) * Math.Cos(4 * M + 2 * σ)) / α;
                    Console.WriteLine("白塞尔大地主题反算解算得：\nS:{0}\nA12:{1}\nA21:{2}", S+10000-100, A12 / Math.PI * 180, A21 / Math.PI * 180);
                    break;
                    #endregion
            }
            Console.ReadKey();
        }

        private static void GetParameter1(double m, out double α, out double β, out double γ)
        {
            //计算 k α β γ 参数
            double k = Math.Sqrt(Math.Abs(Math.Pow(e2 * Math.Cos(m), 2)));
            α = ρ * Math.Sqrt(Math.Abs(1 + e2 * e2)) / a * (1 - k * k / 4 + 7 * Math.Pow(k, 4) / 64 - 15 / 256 * Math.Pow(k, 6));
            β = ρ * (Math.Pow(k / 2, 2) - Math.Pow(k, 4) / 8 + 37 / 512 * Math.Pow(k, 6));
            γ = ρ * (Math.Pow(k, 4) - Math.Pow(k, 6)) / 128;
        }

        private static void GetParameter2(double m, out double k2, out double α2, out double β2)
        {
            k2 = Math.Sqrt(Math.Abs(Math.Pow(e1 * Math.Cos(m), 2)));
            α2 = (e1 * e1 / 2 + Math.Pow(e1, 4) / 8 + Math.Pow(e1, 6) / 16) - Math.Pow(e1 / 4, 2) * (1 + e1 * e1) * k2 * k2 + 3 / 128 * e1 * e1 * Math.Pow(k2, 4);
            β2 = ρ * (Math.Pow(e1 / 4, 2) * (1 + e1 * e1) * k2 * k2 - e1 * e1 / 32 * Math.Pow(k2, 4));
        }
    }
}

//白塞尔大地主题正算解算得：
//L2: 209.64705480638
//B2: -30.4797809408675
//A21: 290.562547107877

//L2:468729.502550613
//B2:151089.849819323
//A21:181.851114572012


//324000
//126000
//777540
//-109760

