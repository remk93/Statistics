using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Statistics.Core;
using Statistics.Core.AutoMapper;
using Statistics.Core.Behaviours;
using Statistics.Core.Exceptions;
using Statistics.DataStorage.DataContext;
using System;
using System.Reflection;

namespace Statistics.Admin.Extensions
{
    public static class ConfigureServicesExtensions
    {
        public static void SetAutoMapperService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfile));
        }

        public static void SetCorsService(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy
                (
                    builder => builder.AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .AllowAnyHeader()
                );
            });
        }

        public static void SetControllerService(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
                options.Filters.Add(new ExceptionFilter());
            })
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                options.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                options.SerializerSettings.Formatting = Formatting.Indented;
            });
        }

        public static void SetServicesDependencies(this IServiceCollection services)
        {
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            
            services.AddCoreDependencies();            
        }

        public static void SetDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextFactory<EntitiesContext>(
                    options => options.UseSqlServer(configuration.GetConnectionString("MSSQL"), x => { 
                        x.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery); 
                        x.MigrationsAssembly("Statistics.Migrations"); }),
                    ServiceLifetime.Transient);
        }
    }
}
