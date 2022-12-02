using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogServices
{
    public interface ILogProvider
    {
        void Log(string message);

        void LogErr(string message, Exception exception);
    }
}
