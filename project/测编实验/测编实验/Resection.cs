using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 测编实验2
{
    internal class Resection : IntersectionCalculation
    {
        double[] locationC;
        double γ;

        public double[] LocationC { get => locationC; set => locationC = value; }
        public double Γ { get => γ; set => γ = value; }

        public Resection(double[] locationCValue, double γValue)
        {
            this.Γ = γValue;
            this.locationC = locationCValue;
        }
        /// <summary>
        /// 后方交会
        /// </summary>
        /// <param name="locationA"></param>
        /// <param name="locationB"></param>
        /// <param name="locationC"></param>
        /// <param name="α"></param>
        /// <param name="β"></param>
        /// <param name="γ"></param>
        /// <returns></returns>
        public override double[] IntersectionCal(double[] locationA, double[] locationB, double α, double β)
        {
            double A = Math.Abs(GetAzimuth.CalculateAzimuth(LocationC, locationA) - GetAzimuth.CalculateAzimuth(locationB, locationA));
            double B = Math.Abs(GetAzimuth.CalculateAzimuth(locationA, locationB) - GetAzimuth.CalculateAzimuth(LocationC, locationB));
            double C = Math.Abs(GetAzimuth.CalculateAzimuth(locationB, LocationC) - GetAzimuth.CalculateAzimuth(locationA, LocationC));
            double Pa = 1 / (1 / Math.Tan(A) - 1 / Math.Tan(α));
            double Pb = 1 / (1 / Math.Tan(B) - 1 / Math.Tan(β));
            double Pc = 1 / (1 / Math.Tan(C) - 1 / Math.Tan(Γ));
            double[] locationP = new double[2];
            locationP[0] = (Pa * locationA[0] + Pb * locationB[0] + Pc * LocationC[0]) / (Pa + Pb + Pc);
            locationP[1] = (Pa * locationA[1] + Pb * locationB[1] + Pc * LocationC[1]) / (Pa + Pb + Pc);
            return locationP;
        }
    }
}
