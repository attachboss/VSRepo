using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 测编实验2
{
    internal class Test
    {
        static void Main(string[] args)
        {
            //double γ = Calculate.ToRadian(130, 42, 10);
            //Resection resection = new Resection(new double[] { 22714.984, 7575.591 }, γ);
            //for (int i = 0; i < 2; i++)
            //{
            //    Console.WriteLine(resection.IntersectionCal(new double[] { 19802.485, 8785.893 }, new double[] { 20752.058, 5995.401 }, Calculate.ToRadian(106, 18, 44), Calculate.ToRadian(122, 59, 6))[i]);
            //}


            LateralIntersection LateralIntersection = new LateralIntersection();
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine(LateralIntersection.IntersectionCal(new double[] {0,0 }, new double[] { 0,100 }, Calculate.ToRadian(75.425), Calculate.ToRadian(73.52752))[i]);
            }


            Console.ReadKey();
        }
    }
}
