using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote
{
    public static class VerificationCode
    {
        /// <summary>
        /// 生成四位字母数字混合验证码
        /// </summary>
        /// <returns></returns>
        public static string CreateVerificationCodeString()
        {
            string strData = "";
            string codeStr = null;
            string chars = "abcdefghijklmnopqrstuvwxyz";
            Random r = new(DateTime.Now.Millisecond);
            int verificationLength = 4;
            for (int i = 0; i < verificationLength; i++)
            {
                strData += r.Next(0, 10);
                strData += chars[r.Next(chars.Length)];
            }
            for (int i = 0; i < verificationLength; i++)
            {
                codeStr += strData[r.Next(strData.Length)];
            }
            return codeStr;
        }

        /// <summary>
        /// 绘制验证码
        /// </summary>
        /// <param name="verificationCodeStr"></param>
        /// <exception cref="Exception"></exception>
        public static Byte[] DrawVerticationCode(string verificationCodeStr)
        {
            if (verificationCodeStr == null)
            {
                throw new Exception("绘制验证码为空！");
            }
            Random r = new Random();
            Bitmap bmp = new Bitmap(120, 30);
            Graphics pic = Graphics.FromImage(bmp);
            string[] fonts = { "黑体", "宋体", "仿宋", "楷书" };
            Color[] colors = { Color.Chocolate, Color.DarkBlue, Color.Purple, Color.DarkRed };
            for (int i = 0; i < verificationCodeStr.Length; i++)
            {
                Point p = new Point(i * 15, 0);
                pic.DrawString(verificationCodeStr[i].ToString(), new Font(fonts[r.Next(0, fonts.Length)], 15, FontStyle.Bold), new SolidBrush(colors[r.Next(0, colors.Length)]), p);
            }
            //生成混淆点、线
            for (int i = 0; i < 20; i++)
            {
                Point p1 = new Point(r.Next(0, bmp.Width), r.Next(0, bmp.Height));
                Point p2 = new Point(r.Next(0, bmp.Width), r.Next(0, bmp.Height));
                pic.DrawLine(new Pen(Brushes.Green), p1, p2);
            }
            for (int i = 0; i < 100; i++)
            {
                Point p = new Point(r.Next(0, bmp.Width), r.Next(0, bmp.Height));
                bmp.SetPixel(p.X, p.Y, Color.Black);
            }
            //将图片保存到缓冲区中
            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, ImageFormat.Png);
            bmp.Dispose();
            pic.Dispose();
            //二进制流转图片
            //File(byte[], @"image/png")
            return ms.ToArray();
        }

    }
}
