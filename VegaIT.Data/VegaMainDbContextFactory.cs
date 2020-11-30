using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace VegaIT.Data
{
    public class VegaMainDbContextFactory : IDesignTimeDbContextFactory<VegaMainDbContext>
    {
        public VegaMainDbContext CreateDbContext(string[] args)
        {
            //var env = hostingContext.HostingEnvironment;
            var appDirectory = Path.Combine(Directory.GetCurrentDirectory(), "..", "VegaIT.API");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                //.AddJsonFile("appsettings.json")
                .AddJsonFile(Path.Combine(appDirectory, "appsettings.json"), optional: true)
                //.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                //.AddJsonFile(Path.Combine(appDirectory, "appsettings.Develppment.json"), optional: true)
                .Build();

            var builder = new DbContextOptionsBuilder<VegaMainDbContext>();
            var connectionString = configuration.GetConnectionString("VegaMainDb");
            builder.UseSqlServer(connectionString);

            return new VegaMainDbContext(builder.Options);
        }
    }
}
