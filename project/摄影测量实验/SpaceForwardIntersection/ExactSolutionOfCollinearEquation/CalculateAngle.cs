using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExactSolutionOfCollinearEquation
{
    public static class CalculateAngle
    {
        /// <summary>
        /// 度分秒转度
        /// </summary>
        /// <param name="degree"></param>
        /// <param name="min"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static double AngleConversion(double degree, double min, double second)
        {
            double angle = degree * 3600 + min * 60 + second;
            return angle / 3600;
        }

        /// <summary>
        /// 度转度分秒
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static double[] AngleConversion(double degree)
        {
            double[] angle = new double[3];
            angle[1] = (int)((degree - (int)degree) * 60);
            angle[2] = Math.Truncate((((degree - (int)degree) * 60) - (int)((degree - (int)degree) * 60)) * 60);
            angle[0] = (int)degree;
            return angle;
        }

        /// <summary>
        /// 角度转换为弧度制
        /// </summary>
        /// <param name="degree"></param>
        /// <returns></returns>
        public static double ToRadian(double degree)
        {
            double radian = degree * Math.PI / 180;
            return radian;
        }

        /// <summary>
        /// 度分秒转换为弧度制
        /// </summary>
        /// <param name="degree"></param>
        /// <param name="min"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static double ToRadian(double degree, double min, double second)
        {
            second = second + min * 60 + degree * 3600;
            double radian = second / 3600 * Math.PI / 180;
            return radian;
        }

        /// <summary>
        /// 弧度转度分秒
        /// </summary>
        /// <param name="degree"></param>
        /// <returns></returns>
        public static double[] ToDegreeDMS(double radian)
        {
            radian /= Math.PI / 180;
            double[] angle = new double[3];
            angle[1] = (int)((radian - (int)radian) * 60);
            angle[2] = Math.Floor((((radian - (int)radian) * 60) - (int)((radian - (int)radian) * 60)) * 60);
            angle[0] = (int)radian;
            return angle;
        }

        /// <summary>
        /// 弧度制转换为角度
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        public static double ToDegree(double radian)
        {
            double degree = radian / Math.PI * 180;
            return degree;
        }


    }
}
