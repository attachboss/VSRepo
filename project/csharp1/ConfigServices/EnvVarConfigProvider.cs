using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigServices
{
    public class EnvVarConfigProvider : IConfigService
    {
        public string GetConfig(string key)
        {
            return Environment.GetEnvironmentVariable(key);
        }
    }
}
