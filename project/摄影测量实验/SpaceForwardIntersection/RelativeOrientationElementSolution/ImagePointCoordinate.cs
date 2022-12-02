using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelativeOrientationElementSolution
{
    internal class ImagePointCoordinate
    {
        //像点在框标坐标系当中的的坐标，在使用时需要将其转化为像平面坐标系(减去内方位元素)
        //只有X、Y值
        private double _x;
        private double _y;

        public double x { get => _x; set => _x = value; }
        public double y { get => _y; set => _y = value; }
        public ImagePointCoordinate(double yValue, double xValue) 
        {
            x = xValue;
            y = yValue;
        }
    }
}
