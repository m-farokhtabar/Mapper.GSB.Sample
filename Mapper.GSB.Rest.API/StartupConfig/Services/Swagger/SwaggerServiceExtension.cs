using Mapper.GSB.Rest.API.Helpers.SwaggerExamples;
using Mapper.GSB.Rest.API.StartupConfig.Settings;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace Mapper.GSB.Rest.API.StartupConfig.Services.Swagger;

/// <summary>
/// سرویس نمایش مستندات
/// API
/// </summary>
public static class SwaggerServiceExtension
{
    /// <summary>
    /// تنظیمات سرویس نمایش مستندات سرویس وب
    /// </summary>
    /// <param name="services"></param>
    /// <param name="Configuration"></param>
    public static void ConfigureSwashBuckleSwagger(this IServiceCollection services, IConfiguration Configuration)
    {
        services.Configure<SwaggerSettings>(Configuration.GetSection("SwaggerSettings"));
        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        services.AddSwaggerGen(options =>
        {
            options.OperationFilter<SwaggerDefaultValues>();

            var XmlAPI = Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
            var XmlApplication = Path.Combine(AppContext.BaseDirectory, "Mapper.GSB.Application.xml");
            var XmlDomain = Path.Combine(AppContext.BaseDirectory, "Mapper.GSB.Domain.xml");
            var XmlMOHME = Path.Combine(AppContext.BaseDirectory, "MOHME.Lib.xml");
            options.IncludeXmlComments(XmlAPI, includeControllerXmlComments: true);
            options.IncludeXmlComments(XmlApplication);
            options.IncludeXmlComments(XmlDomain);
            options.IncludeXmlComments(XmlMOHME);
            /*
             * جهت استفاده از 
             * Annotations
             * چه انواع داخلی خود کلاس چه انواع مانند
             * Swashbuckle.AspNetCore.Annotations
             */
            options.EnableAnnotations();
            options.ExampleFilters();
            options.OperationFilter<AddResponseHeadersFilter>(); // [SwaggerResponseHeader]
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "هدر مجوز" +  " JWT " + "با استفاده از نوع" + " 'Bearer' " + " مثال زیر نحوه استفاده از توکن را مشخص می نماید." + "\r\n\r\n" + "Example: \"Bearer 1safsfsdfdfd\""                
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement {
            {
                new OpenApiSecurityScheme {
                    Reference = new OpenApiReference {
                        Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                    }
                },
                new string[] {}
            }
            });
        });
        services.AddSwaggerExamplesFromAssemblyOf<PersonPolicyInfoInputViewModelExample>();
    }
}
