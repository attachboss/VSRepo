using log4net;
using log4net.Config;

namespace csharp1.Common
{
    public class Logger
    {
        ILog logger = null;

        static Logger()
        {
            XmlConfigurator.Configure(new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.cfg.xml")));
            ILog log = LogManager.GetLogger(typeof(Logger));
            log.Info("初始化Log4net模块");
        }

        public Logger(Type type)
        {
            logger = LogManager.GetLogger(type);
        }

        public void Error(string msg, Exception ex)
        {
            Console.WriteLine(msg);
            logger.Error(msg, ex);
        }
        public void Warn(string msg, Exception ex)
        {
            Console.WriteLine(msg);
            logger.Warn(msg, ex);
        }
        public void Info(string msg, Exception ex)
        {
            Console.WriteLine(msg);
            logger.Info(msg, ex);
        }

        public void Debug(string msg, Exception ex)
        {
            Console.WriteLine(msg);
            logger.Debug(msg, ex);
        }


    }
}
