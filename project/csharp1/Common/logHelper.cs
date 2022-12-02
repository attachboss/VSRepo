using System.IO;

namespace Common
{
    public class LogHelper
    {
        public static string logPath = AppDomain.CurrentDomain.BaseDirectory + "logs";

        /// <summary>
        /// 将异常打印到LOG文件
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="message">自定义异常信息</param>
        public static void WriteLog(Exception ex, params string[] message)
        {
            try
            {
                if (!Directory.Exists(logPath))
                {
                    Directory.CreateDirectory(logPath);
                }
                string logAddress = logPath + "\\" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-fff") + ".log";
                using (FileStream fs = new FileStream(logAddress, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine("记录时间：" + DateTime.Now.ToString());
                    sw.WriteLine("特定内容：" + message);
                    if (ex != null)
                    {
                        sw.WriteLine("异常信息：" + ex.Message);
                        sw.WriteLine("异常来源：" + ex.Source);
                        sw.WriteLine("调用堆栈：\n" + ex.StackTrace);
                        sw.WriteLine("触发方法：" + ex.TargetSite);
                    }
                    sw.WriteLine();
                    sw.Close();
                    sw.Dispose();
                }
            }
            catch (Exception)
            {

            }
}

/// <summary>
/// 记录系统日志
/// </summary>
/// <param name="fileName"></param>
/// <param name="errorMsg"></param>
public static void RecordLog(string fileName, string errorMsg)
{
    try
    {
        string errorPath = logPath + "ErrorMsg";
        if (!Directory.Exists(errorPath))
        {
            Directory.CreateDirectory(errorPath);
        }
        string path = errorPath + fileName + ".txt";
        if (!File.Exists(path))
        {
            FileInfo myfile = new FileInfo(path);
            FileStream fs = myfile.Create();
            fs.Close();
        }
        StreamWriter sw = File.AppendText(path);
        sw.WriteLine(errorMsg);
        sw.Flush();
        sw.Close();
    }
    catch (Exception)
    {
    }
}
    }
}