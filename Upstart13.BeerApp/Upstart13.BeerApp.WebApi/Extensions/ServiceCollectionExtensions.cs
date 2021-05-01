using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Polly;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Reflection;
using Upstart13.BeerApp.Dal;
using Upstart13.BeerApp.Domain;
using Upstart13.BeerApp.Entities;
using Upstart13.BeerApp.Infrastructure.HttpClients;
using Upstart13.BeerApp.Infrastructure.Swagger;

namespace Upstart13.BeerApp.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAndConfigureLocalization(this IServiceCollection services)
        {
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            var supportedCultures = new List<CultureInfo> { new("en") };
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("en");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            return services;
        }

        public static IServiceCollection AddAndConfigureApiVersioning(this IServiceCollection services)
        {
            services.Configure<RouteOptions>(options => { options.LowercaseUrls = true; });

            services.AddApiVersioning(options =>
            {
                // reporting api versions will return the headers "api-supported-versions" and "api-deprecated-versions"
                options.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
                // note: the specified format code will format the version as "'v'major[.minor][-status]"
                options.GroupNameFormat = "'v'VVV";

                // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                // can also be used to control the format of the API version in route templates
                options.SubstituteApiVersionInUrl = true;
            });

            return services;
        }

        public static IServiceCollection AddAndConfigureSwagger(this IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(options =>
            {
                // add a custom operation filter which sets default values
                options.OperationFilter<SwaggerDefaultValues>();
                options.OperationFilter<SwaggerLanguageHeader>();

                // JWT Bearer Authorization
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header,
                },
                new List<string>()
            }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });

            return services;
        }

        public static IServiceCollection AddAndConfigurePunkApiHttpClient(this IServiceCollection services, IConfiguration configuration)
        {
            var punkApiSettings = new PunkApiSettings();
            configuration.GetSection("WeatherSettings").Bind(punkApiSettings);
            services.AddSingleton(punkApiSettings);

            var timeoutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(10);

            services.AddHttpClient<IPunkApiHttpClient, PunkApiHttpClient>()
                .AddTransientHttpErrorPolicy(policy => policy.WaitAndRetryAsync(3, _ => TimeSpan.FromSeconds(2)))
                .AddTransientHttpErrorPolicy(policy => policy.CircuitBreakerAsync(6, TimeSpan.FromSeconds(5)))
                .AddPolicyHandler(request =>
                {
                    if (request.Method == HttpMethod.Get)
                        return timeoutPolicy;

                    return Policy.NoOpAsync<HttpResponseMessage>();
                });

            return services;
        }

        public static IServiceCollection AddDalServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBeerDal, BeerDal>();
            services.AddScoped<IFoodPairingDal, FoodPairingDal>();
            services.AddScoped<IIngredientDal, IngredientDal>();
            services.AddScoped<IMethodDal, MethodDal>();
            services.AddScoped<IVolumeDal, VolumeDal>();

            services.AddScoped<IBeerService, BeerService>();
            services.AddDbContext<Upstart13beerappContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Upstart13beerappContext"));
            });

            services.AddAutoMapper(typeof(Mapping.AutomapperProfile));
            services.AddCors();

            return services;
        }
    }
}