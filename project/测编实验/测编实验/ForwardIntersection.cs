using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 测编实验2
{
    internal class ForwardIntersection: IntersectionCalculation
    {
        /// <summary>
        /// 前方交会
        /// </summary>
        /// <param name="locationA"></param>
        /// <param name="locationB"></param>
        /// <param name="α"></param>
        /// <param name="β"></param>
        /// <returns></returns>
        public override double[] IntersectionCal(double[] locationA, double[] locationB,double α,double β)
        {
            double[] locationP = new double[2];
            locationP[0] = (locationA[0] / Math.Tan(β) + locationB[0] / Math.Tan(α) + (locationB[1] - locationA[1])) / (1 / Math.Tan(α) + 1 / Math.Tan(β));
            locationP[1] = (locationA[1] / Math.Tan(β) + locationB[1] / Math.Tan(α) - (locationB[0] - locationA[0])) / (1 / Math.Tan(α) + 1 / Math.Tan(β));
            return locationP;
        }
    }
}
