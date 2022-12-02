using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogServices
{
    public class ConsoleLogProvider : ILogProvider
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }

        public void LogErr(string message, Exception exception)
        {
            Console.WriteLine(message);
        }
    }
}
