using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigServices
{
    public class ConfigService : IConfigService
    {
        public string Path { get; set; }

        public string GetConfig(string key)
        {
            return File.ReadAllText(Path);
        }
    }
}
