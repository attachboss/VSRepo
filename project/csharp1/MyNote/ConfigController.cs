using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote
{
    class ConfigController
    {

        private readonly IOptionsSnapshot<Config> config;

        public ConfigController(IOptionsSnapshot<Config> optionsSnapshot)
        {
            this.config = optionsSnapshot;
        }

        public void TestConfiguration()
        {
            Console.WriteLine(config.Value.Name);
        }
    }
}
