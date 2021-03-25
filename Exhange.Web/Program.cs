using System;
using System.IO;
using Autofac.Extensions.DependencyInjection;
using Exchange.Data.Contexts;
using Exchange.Data.DbInitializers;
using Exchange.Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Exchange.Web
{
    public class Program
    {
        private static string RunDbInitializer = "RunDbInitializer";
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            CreateDbIfNotExists(host);
            host.Run();
        }

        private static void CreateDbIfNotExists(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            
            var runDbInitializer = services.GetService<IConfiguration>().GetValue<bool>(RunDbInitializer);
            if (!runDbInitializer) return;
            
            try
            {

                var context = services.GetRequiredService<ApplicationDbContext>();
                var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                
                DbInitializer.Initialize(context, userManager).Wait();
                UpdateRunDbInitializerSettings();
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred running Database initializer the DB.");
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        private static void UpdateRunDbInitializerSettings()
        {
            const string appsettings = "appsettings.json";
            var json = File.ReadAllText(appsettings);
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            jsonObj[RunDbInitializer] = false;
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(appsettings, output);
        }
    }
}
