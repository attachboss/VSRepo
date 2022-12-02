using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Common
{
    public partial class Md5Helper
    {
        /// <summary>
        /// 字符串md5加密
        /// 使用UTF8编码
        /// </summary>
        /// <param name="pwdStr">要加密的字符串</param>
        /// <returns>返回密码</returns>
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
    }
}
