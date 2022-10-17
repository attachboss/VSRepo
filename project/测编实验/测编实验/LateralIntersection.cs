using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 测编实验2
{
    internal class LateralIntersection : IntersectionCalculation
    {
        /// <summary>
        /// 侧方交会
        /// </summary>
        /// <param name="locationA"></param>
        /// <param name="locationB"></param>
        /// <param name="α"></param>
        /// <param name="β"></param>
        /// <returns></returns>
        public override double[] IntersectionCal(double[] locationA, double[] locationB, double α, double β)
        {
            double α_ab = GetAzimuth.CalculateAzimuth(locationA, locationB);
            double γ = Math.PI - α - β;
            double Sab = Math.Sqrt(Math.Pow((locationA[1] - locationB[1]), 2) + Math.Pow((locationA[0] - locationB[0]), 2));
            double Sap = Sab * Math.Sin(γ) / Math.Sin(β);
            double[] locationP = new double[2];
            locationP[0] = locationA[0] + Sap * Math.Cos(α_ab - α);
            locationP[1] = locationA[1] + Sab * Math.Sin(α_ab - α);
            return locationP;
        }
    }
}
