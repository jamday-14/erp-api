﻿using AutoMapper;
using ERPApi.Extensions;
using ERPApi.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace ERPApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            //loggerFactory.ConfigureNLog(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            NLog.LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }


        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureCors();

            services.ConfigureIISIntegration();

            services.ConfigureLoggerService();

            services.ConfigureDBContext(Configuration);

            services.ConfigureBusinessService();

            services.ConfigureModelValidation();

            services.ConfigureAuthentication(Configuration);

            services.AddAutoMapper(cfg => new MapperConfiguration(mc => { mc.AddProfile(new MapperProfile()); }));

            services.ConfigureSwagger();

            services.AddMvc(options => options.Filters.Add(typeof(AuthorizationAttribute)))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.ConfigureCustomExceptionMiddleware();

            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.ConfigureSwaggerUI();

            app.UseMvc();
        }
    }
}
