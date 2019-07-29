﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.FileProviders.Physical;
using Microsoft.Extensions.Logging;

namespace Vibechat.FileServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public string OriginsPolicyName = "DefaultOriginsPolicy";

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<AdminSafeListMiddleware, AdminSafeListMiddleware>();
            services.AddCors(options =>
            {
                options.AddPolicy(OriginsPolicyName,
                builder =>
                {
                    builder.AllowAnyOrigin();
                });
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseHttpsRedirection();

            app.UseCors(OriginsPolicyName);

            app.UseStaticFiles(new StaticFileOptions() {
                FileProvider = new PhysicalFileProvider(Configuration["ContentPath"], ExclusionFilters.None),                
            });

            app.UseMiddleware<AdminSafeListMiddleware>();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}