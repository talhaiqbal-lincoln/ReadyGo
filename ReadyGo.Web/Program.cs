using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ReadyGo.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureLogging((context, loggingBuilder) =>
            {
                loggingBuilder.AddFilter("System", LogLevel.Information);
                loggingBuilder.AddFilter("Microsoft", LogLevel.Information);
                var path = context.HostingEnvironment.ContentRootPath;
                loggingBuilder.AddLog4Net($"{path}/log4net.config");//Profile
            }).ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
