using Contracts;
using Entities.Models;
using ERPApi.Helpers;
using LoggerService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Services;
using Swashbuckle.AspNetCore.Swagger;
using System.Text;

namespace ERPApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        public static void ConfigureDBContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["sqlserverconnection:connectionString"];
            services.AddDbContext<ERPContext>(o => o.UseSqlServer(connectionString));
        }

        public static void ConfigureBusinessService(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMaintenanceService, MaintenanceService>();
            services.AddScoped<ISalesService, SalesService>();
            services.AddScoped<IPurchasingService, PurchasingService>();
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<IAccountingService, AccountingService>();
            services.AddScoped<IReportService, ReportService>();
        }

        public static void ConfigureModelValidation(this IServiceCollection services)
        {
            services.AddScoped<ModelValidationAttribute>();
        }

        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }

        public static void ConfigureSwaggerUI(this IApplicationBuilder app)
        {
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ERP API V1");
                c.RoutePrefix = string.Empty;
            });
        }

        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                };
            });
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "ERP API",
                    Version = "v1",
                    Description = "ERP API Documentation",
                    Contact = new Contact
                    {
                        Name = "Jamal Dayanghirang",
                        Email = "jamday14@hotmail.com",
                        Url = "https://www.facebook.com/jamal.dayanghirang"
                    },
                    License = new License { Name = "Altron Software Solutions Inc." }
                });
            });
        }
    }
}
