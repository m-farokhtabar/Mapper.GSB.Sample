using Asp.Versioning.ApiExplorer;
using Mapper.GSB.Rest.API.StartupConfig.Settings;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Mapper.GSB.Rest.API.StartupConfig.Services.Swagger;

/// <summary>
/// سفارشی سازی نمایش اطلاعات سرویس ها
/// </summary>
public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider Provider;
    private readonly SwaggerSettings SwaggerSetting;
    /// <summary>
    /// دریافت اطلاعات سند ساز سرویس جهت سفارشی سازی
    /// </summary>
    /// <param name="provider"></param>
    /// <param name="swaggerSetting"></param>
    public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider, IOptions<SwaggerSettings> swaggerSetting)
    {
        Provider = provider;
        SwaggerSetting = swaggerSetting.Value;
    }
    /// <summary>
    /// ایجاد سند معرفی سرویس ها به ازای هر نسخه
    /// </summary>
    /// <param name="options"></param>
    public void Configure(SwaggerGenOptions options)
    {
        // در این قسمت می توانید در صورت لزوم نسخه خاصی یا نسخه های منسوخ شده را نمایش ندهید
        foreach (var description in Provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
        }
    }
    /// <summary>
    /// ایجاد اطلاعات مورد نیاز نسخه جهت نمایش در ابتدای صفحه ای که سرویس ها در اختیار کاربر قرار می گیرد
    /// </summary>
    /// <param name="Description"></param>
    /// <returns></returns>
    private OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription Description)
    {
        var info = new OpenApiInfo()
        {
            Title = SwaggerSetting.Title,
            Version = Description.ApiVersion.ToString(),
            Description = SwaggerSetting.Description,
            License = new OpenApiLicense()
            {
                Name = SwaggerSetting.Copyright,
                Url = null
            },
            TermsOfService = null,
            Contact = new OpenApiContact
            {
                Name = SwaggerSetting.Name,
                Email = SwaggerSetting.Email,
                Url = !string.IsNullOrWhiteSpace(SwaggerSetting.Url) ? new Uri(SwaggerSetting.Url) : null
            }
        };
        if (Description.IsDeprecated)
            info.Description += SwaggerSetting.IsDeprecated;

        return info;
    }
}
