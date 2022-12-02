using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceResectionProcedure
{
    internal class GroundCoordinates
    {
        private double x;
        private double y;
        private double z;

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        public double Z { get => z; set => z = value; }

        public GroundCoordinates(double xValue, double yValue, double zValue) 
        {
            X = xValue;
            Y = yValue;
            Z = zValue;
        }
    }
}
