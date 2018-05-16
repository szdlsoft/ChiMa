using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace SixMan.ChiMa.Web.Startup
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("host.json", optional: true)
                .Build();


            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseConfiguration(config)
                .Build();
            //return new WebHostBuilder()
            //    .PreferHostingUrls(false)
            //    .CaptureStartupErrors(true)
            //    .UseKestrel(options => options.Listen(IPAddress.Any, 443, listenOptions =>
            //    {
            //        listenOptions.UseHttps(new X509Certificate2("cert.pfx", "sixman"));
            //        options.Limits.MaxConcurrentConnections = 100;
            //        options.Limits.MaxConcurrentUpgradedConnections = 100;
            //        options.Limits.MaxRequestBodySize = 10 * 1024;
            //    }))
            //    //.UseUrls("https://*:443")
            //    .UseStartup<Startup>()
            //    .UseConfiguration(config)
            //    .Build();
        }
    }
}
