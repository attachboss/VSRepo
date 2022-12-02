using ConfigServices;
using LogServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailServices
{
    public class MailService : IMailService
    {
        readonly ILogProvider logger;

        readonly IConfigService configer;

        public MailService(ILogProvider logger, IConfigService configer)
        {
            this.logger = logger;
            this.configer = configer;
        }

        public void Send(string title, string content, string to)
        {
            logger.Log("启动");
            string serverHost = configer.GetConfig("serverHost");
            Console.WriteLine(serverHost);
            Console.WriteLine(title);
            Console.WriteLine(content);
            Console.WriteLine(to);
            logger.Log("完成");
        }
    }
}
