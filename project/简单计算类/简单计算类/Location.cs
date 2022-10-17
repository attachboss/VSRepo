using System;
using System.Collections.Generic;
using System.Text;

namespace 简单计算类
{
    class Location
    {
        private double x1;
        private double y1;
        private double x2;
        private double y2;

        public double X1 { get => x1; set => x1 = value; }
        public double Y1 { get => y1; set => y1 = value; }
        public double X2 { get => x2; set => x2 = value; }
        public double Y2 { get => y2; set => y2 = value; }

        public Location(double x1Value, double y1Value, double x2Value, double y2Value)
        {
            this.X1 = x1Value;
            this.Y1 = y1Value;
            this.X2 = x2Value;
            this.Y2 = y2Value;
        }

        /// <summary>
        /// 计算距离
        /// </summary>
        /// <param name="x1">x(A)</param>
        /// <param name="y1">y(A)</param>
        /// <param name="x2">x(B)</param>
        /// <param name="y2">y(B)</param>
        /// <returns>返回距离</returns>
        public double CalculateDistance()
        {
            double distance = Math.Sqrt((X1 - X2) * (X1 - X2) + (Y1 - Y2) * (Y1 - Y2));//根据坐标求两点间距离
            return distance;
        }

        /// <summary>
        /// 计算方位角
        /// </summary>
        /// <param name="x1">x(A)</param>
        /// <param name="y1">y(A)</param>
        /// <param name="x2">x(B)</param>
        /// <param name="y2">y(B)</param>
        /// <returns>返回方位角</returns>
        public double CalculateAzimuth()
        {
            double angle = Math.Atan((Y2 - Y1) / (X2 - X1));
            return angle;
        }
    }
}
