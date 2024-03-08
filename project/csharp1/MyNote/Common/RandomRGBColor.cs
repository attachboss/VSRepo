using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp1.Common
{
    public class RandomRGBColor
    {
        static List<Color> RandomComparableColor(int h)
        {
            //最大化区分随机颜色
            List<double[]> colorHSL = new List<double[]>();
            List<Color> colorRGBs = new List<Color>();
            int step = (int)(360.0 / h);
            Random rand = new Random();
            while (h < 360)
            {
                double s = 0.9 + rand.NextDouble() * 0.1;
                double l = 0.5 + rand.NextDouble() * 0.1;
                colorHSL.Add(new double[] { h, s, l });
                h += step;
            }
            for (int ii = 0; ii < colorHSL.Count; ii++)
            {
                //rgb转换
                double H = colorHSL[ii][0];
                double S = colorHSL[ii][1];
                double L = colorHSL[ii][2];
                double R, G, B;
                double v1, v2;
                if (S == 0)
                {
                    R = L * 255.0;
                    G = L * 255.0;
                    B = L * 255.0;
                    colorRGBs.Add(Color.FromArgb((int)Math.Round(R), (int)Math.Round(G), (int)Math.Round(B)));
                }
                else
                {
                    if (L < 0.5) v2 = L * (1 + S);
                    else v2 = L + S - S * L;

                    v1 = 2.0 * L - v2;
                    H /= 360;

                    R = 255.0 * Hue2RGB(v1, v2, H + 1.0 / 3.0);
                    G = 255.0 * Hue2RGB(v1, v2, H);
                    B = 255.0 * Hue2RGB(v1, v2, H - 1.0 / 3.0);
                    colorRGBs.Add(Color.FromArgb((int)Math.Round(R), (int)Math.Round(G), (int)Math.Round(B)));
                }

            }

            return colorRGBs;
        }

        static double Hue2RGB(double v1, double v2, double vH)
        {
            if (vH < 0) vH += 1;
            if (vH > 1) vH -= 1;
            if (6.0 * vH < 1) return v1 + (v2 - v1) * 6.0 * vH;
            if (2.0 * vH < 1) return v2;
            if (3.0 * vH < 2) return v1 + (v2 - v1) * (2.0 / 3.0 - vH) * 6.0;
            return v1;
        }


    }
}
