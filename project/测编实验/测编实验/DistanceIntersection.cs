using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 测编实验2
{
    internal class DistanceIntersection : IntersectionCalculation
    {
        /// <summary>
        /// 距离交会
        /// </summary>
        /// <param name="locationA"></param>
        /// <param name="locationB"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public override double[] IntersectionCal(double[] locationA, double[] locationB, double a, double b)
        {
            double S_ab = Math.Sqrt(Math.Pow((locationA[1] - locationB[1]), 2) + Math.Pow((locationA[0] - locationB[0]), 2));
            double A = Math.Acos((S_ab * S_ab + a * a - b * b) / (2 * a * S_ab));
            double α_ab = GetAzimuth.CalculateAzimuth(locationA, locationB);
            double α_ap = α_ab - A;
            double[] locationP = new double[2];
            locationP[0] = locationA[0] + a * Math.Cos(α_ap);
            locationP[1] = locationA[1] + a * Math.Sin(α_ap);
            return locationP;
        }
    }
}
