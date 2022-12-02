using LogServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConsoleLogExtension
    {
        public static void AddConsoleLog(this IServiceCollection services)
        {
            services.AddScoped<ILogProvider, ConsoleLogProvider>();
        }
    }
}
