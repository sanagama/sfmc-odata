using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace SfmcOdataDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            // Add seed data for the demo
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<SfmcContext>();
                SfmcDemoInitializer initializer = new SfmcDemoInitializer(context);
                initializer.Initialize();
            }
            host.Run();            
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                    .UseStartup<Startup>()
                    .UseDefaultServiceProvider(options =>
                    {
                        options.ValidateScopes = false;
                    })
                    .Build();
        }
    }
}
