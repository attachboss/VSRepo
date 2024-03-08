using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp1
{
    class ConfigController
    {

        private readonly IOptionsMonitor<Config> config;

        public ConfigController(IOptionsMonitor<Config> options)
        {
            this.config = options;
        }

        public void TestConfiguration()
        {
            Console.WriteLine(config.CurrentValue.Name);
        }
    }
}
