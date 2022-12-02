using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 测编实验2
{
    internal class GetAzimuth
    {
        public static double CalculateAzimuth(double[] location1, double[] location2)
        {
            double angle = Math.Atan((location1[1] - location2[1]) / (location1[0] - location2[0]));
            if ((location1[0] - location2[0]) < 0)//直线AB的斜率为正
            {
                angle += Math.PI;
            }
            else if ((location1[0] - location2[0]) > 0)//直线AB的斜率为负
            {
                if ((location1[1] - location2[1]) < 0)
                    angle += 2 * Math.PI;
            }
            return angle;
        }
    }
}
