using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceResectionProcedure
{
    internal class ImagePointCoordinate
    {
        private double _x;
        private double _y;

        public double x { get => _x; set => _x = value; }
        public double y { get => _y; set => _y = value; }
        public ImagePointCoordinate(double xValue, double yValue) 
        {
            x = xValue;
            y = yValue;
        }
    }
}
