using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 测编实验2
{
    internal abstract class IntersectionCalculation
    {
        public abstract double[] IntersectionCal(double[] locationA, double[] locationB, double α, double β);
    }
}
