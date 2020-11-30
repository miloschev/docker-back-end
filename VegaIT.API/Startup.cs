using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using VegaIT.Core.ServiceInterfaces;
using VegaIT.Core.Services;
using VegaIT.Data;
using VegaIT.Data.Repositories;
using VegaIT.Data.RepositoryInterfaces;

namespace VegaIT.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<API.MapperInterfaces.IUserMapper, API.Mappers.UserMapper>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<Core.MapperInterfaces.IUserMapper, Core.Mappers.UserMapper>();

            services.AddDbContext<VegaMainDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:VegaMainDb"]));

            services.AddControllers();
            services.AddApplicationInsightsTelemetry(Configuration["APPINSIGHTS_INSTRUMENTATIONKEY"]);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, VegaMainDbContext mainData)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            mainData.Database.Migrate();

            mainData.EnsureSeedUserData();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
