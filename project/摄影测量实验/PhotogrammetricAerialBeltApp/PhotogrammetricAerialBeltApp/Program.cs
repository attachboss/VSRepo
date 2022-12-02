using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotogrammetricAerialBeltApp
{
    internal class Program
    {
        //本例使用m和s作为标准单位
        static void Main(string[] args)
        {
            //地区左下角、右上角坐标、飞机第一摄站坐标
            Point p1 = new Point(0, 0);
            Point p2 = new Point(12880, 7360);
            Point p = new Point(-368, 184);
            //航高
            double Height = 750;
            //相幅大小
            double phaseAmplitude = 0.23;
            //根据已知航空摄影比例尺为1:8000
            double m = 8000;
            //航向重叠度为60%，旁向重叠度为30%
            double courseOverlap = 0.6, lateralOverlap = 0.3;
            //计算相幅在实际中的长度
            double L = phaseAmplitude * m;
            //计算航向基线、旁向基线的长度
            double B1 = L * (1 - courseOverlap);
            double B2 = L * (1 - lateralOverlap);
            //计算相邻相片曝光拍摄时间的间隔
            double velocity = 200;//航摄飞机的速度，以km/h为单位
            double adjacentTime = B1 / velocity * 3.6;
            Console.WriteLine("相邻相片曝光拍摄时间的间隔为：{0}\n航向基线长为：{1}", adjacentTime, B1);
            //计算摄站中心坐标
            double absoluteAltitude = 0.15 * m + Height;
            int index = 0;
            Console.WriteLine("各个摄站中心的三维坐标为：");
            for (int i = 0; i < (int)((p2.X - p1.X + 368) / 1288); i++)
            {
                for (int j = 0; j < (int)((p2.Y - p1.Y - 184) / 736); j++)
                {
                    if (index % 4 == 0)
                        Console.WriteLine("\n");
                    Console.Write("    S{0}({1},{2},{3})", index, p.X, p.Y, absoluteAltitude);
                    p.Y += 736;
                    index++;
                }
                p.Y = 920;
                p.X += 1288;
            }
            Console.ReadKey();
        }
    }
}
