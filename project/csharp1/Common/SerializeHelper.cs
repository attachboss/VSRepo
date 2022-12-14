using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;


namespace Common
{
    public class SerializeHelper
    {
        public SerializeHelper()
        { }

        #region XML序列化
        /// <summary>
        /// 文件化XML序列化
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="filename">文件路径</param>
        public static void Save(object obj, string filename)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(fs, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (fs != null) fs.Close();
            }
        }

        /// <summary>
        /// 文件化XML反序列化
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <param name="filename">文件路径</param>
        public static object Load(Type type, string filename)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                XmlSerializer serializer = new XmlSerializer(type);
                return serializer.Deserialize(fs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (fs != null) fs.Close();
            }
        }

        /// <summary>
        /// 文本化XML序列化
        /// </summary>
        /// <param name="item">对象</param>
        public static string ToXml<T>(T item)
        {
            XmlSerializer serializer = new XmlSerializer(item.GetType());
            StringBuilder sb = new StringBuilder();
            using (XmlWriter writer = XmlWriter.Create(sb))
            {
                serializer.Serialize(writer, item);
                return sb.ToString();
            }
        }

        /// <summary>
        /// 文本化XML反序列化
        /// </summary>
        /// <param name="str">字符串序列</param>
        public static T FromXml<T>(string str)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (XmlReader reader = new XmlTextReader(new StringReader(str)))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
        #endregion

        #region Json序列化
        /// <summary>
        /// JsonSerializer序列化
        /// </summary>
        /// <param name="item">对象</param>
        public static string ToJson<T>(T item)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(item.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, item);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }

        /// <summary>
        /// JsonSerializer反序列化
        /// </summary>
        /// <param name="str">字符串序列</param>
        public static T FromJson<T>(string str) where T : class
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(str)))
            {
                return serializer.ReadObject(ms) as T;
            }
        }

        /// <summary>
        /// NewTonSoft序列化Json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string ToJsonNT<T>(T t)
        {
            return JsonConvert.SerializeObject(t);
        }

        /// <summary>
        /// NewTonSoft反序列化Json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T FromJsonNT<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
        #endregion

        #region SoapFormatter序列化
        /// <summary>
        /// SoapFormatter序列化
        /// </summary>
        /// <param name="item">对象</param>
        //public  static string ToSoap<T>(T item)
        //{
        //    SoapFormatter formatter = new SoapFormatter();
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        formatter.Serialize(ms, item);
        //        ms.Position = 0;
        //        XmlDocument xmlDoc = new XmlDocument();
        //        xmlDoc.Load(ms);
        //        return xmlDoc.InnerXml;
        //    }
        //}

        /// <summary>
        /// SoapFormatter反序列化
        /// </summary>
        /// <param name="str">字符串序列</param>
        //public  static T FromSoap<T>(string str)
        //{
        //    XmlDocument xmlDoc = new XmlDocument();
        //    xmlDoc.LoadXml(str);
        //    SoapFormatter formatter = new SoapFormatter();
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        xmlDoc.Save(ms);
        //        ms.Position = 0;
        //        return (T)formatter.Deserialize(ms);
        //    }
        //}
        #endregion

        #region BinaryFormatter序列化
        /// <summary>
        /// BinaryFormatter序列化
        /// </summary>
        /// <param name="item">对象</param>
        public static string ToBinary<T>(T item)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                formatter.Serialize(ms, item);
                ms.Position = 0;
                byte[] bytes = ms.ToArray();
                StringBuilder sb = new StringBuilder();
                foreach (byte bt in bytes)
                {
                    sb.Append(string.Format("{0:X2}", bt));
                }
                return sb.ToString();
            }
        }

        /// <summary>
        /// BinaryFormatter反序列化
        /// </summary>
        /// <param name="str">字符串序列</param>
        public static T FromBinary<T>(string str)
        {
            int intLen = str.Length / 2;
            byte[] bytes = new byte[intLen];
            for (int i = 0; i < intLen; i++)
            {
                int ibyte = Convert.ToInt32(str.Substring(i * 2, 2), 16);
                bytes[i] = (byte)ibyte;
            }
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                return (T)formatter.Deserialize(ms);
            }
        }
        #endregion
    }
}