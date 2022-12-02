using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace Common
{
    public partial class Md5Helper
    {
        /// <summary>
        /// 字符串加密
        /// 使用UTF8编码
        /// </summary>
        /// <param name="pwdStr"></param>
        /// <returns></returns>
        public static string EncryptString(string pwdStr)
        {
            MD5 md5 = MD5.Create();
            //使用UTF8编码
            byte[] vs = Encoding.UTF8.GetBytes(pwdStr);
            vs = md5.ComputeHash(vs);
            StringBuilder sb = new StringBuilder();
            //将字节数组转换成16进制的字符串，占两位
            foreach (byte b in vs)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }


        /// <summary>
        /// 获取文件MD5摘要
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string AbstractFile(string fileName)
        {
            using(FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                return AbstractFile(fs);
            }
        }

        /// <summary>
        /// 对流式加密
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static string AbstractFile(Stream stream)
        { 
            MD5 md5 = MD5.Create();
            byte[] bt = md5.ComputeHash(stream);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bt.Length; i++)
            {
                sb.Append(bt[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
