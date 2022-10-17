using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace distance
{
    class Program
    {
        static void Main(string[] args)
        {
            basecalculation r = new basecalculation();
            r.Acceptdetails();
            r.Display();
            Console.ReadLine();
        }
    }
    class basecalculation
    {
        private double x1;
        private double x2;
        private double y1;
        private double y2;
        private double A;
        public void Acceptdetails()
        {
            Console.WriteLine("请输入x1:");
            x1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("请输入y1:");
            y1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("请输入x2:");
            x2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("请输入y2:");
            y2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("请输入A:");
            A = Convert.ToDouble(Console.ReadLine());
        }
        public double getdistance()
        {
            return Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2));
        }
        public double Azimuth()
        {
            return Math.Atan((y2 - y1) / (x2 - x1));
        }
        public double Angle()//度分秒转弧度
        {
            double an = Math.Floor(A);
            double mi = Math.Floor((A - an) * 60);
            double s = ((A - an) * 60 - mi) * 60;
            double A0 = an + mi / 100 + s / 10000;
            return Math.PI / 180 * A0;
        }
        public void Display()
        {
            Console.WriteLine("两点间距离为;{0}", getdistance());
            Console.WriteLine("坐标方位角为:{0}", Azimuth());
            Console.WriteLine("转换后为:{0}", Angle());
        }
    }

}

