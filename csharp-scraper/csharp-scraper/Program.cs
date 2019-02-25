using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using csharp_scraper.Controllers;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace csharp_scraper
{
    public class Program
    {
        public static void Main(string[] args)
        {
//            Service service = new Service();
//
//            var keys = new Credentials();
//            Auth.WebClient(keys.LoginUrl, keys.Username, keys.Password);
               Api.server();

//            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}