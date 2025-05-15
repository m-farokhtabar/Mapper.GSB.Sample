using Asp.Versioning.ApiExplorer;
using Mapper.GSB.Rest.API.StartupConfig.Settings;
using Microsoft.Extensions.Options;

namespace Mapper.GSB.Rest.API.StartupConfig.Applications;

/// <summary>
/// تنظیمات میان افزار جهت نمایش مستندات و نحوه صدا زدن سرویس های برنامه
/// </summary>
public static class SwashBuckleSwaggerApplicationExtension
{
    /// <summary>
    /// تنظیمات میان افزار جهت نمایش مستندات و نحوه صدا زدن سرویس های برنامه
    /// </summary>
    /// <param name="app"></param>
    public static void UseSwashBuckleSwagger(this IApplicationBuilder app)
    {
        IApiVersionDescriptionProvider Provider;
        SwaggerSettings Settings;
        using (var SrvScope = app.ApplicationServices.CreateScope().ServiceProvider.GetService<IServiceScopeFactory>()!.CreateScope())
        {                
            Provider = SrvScope.ServiceProvider.GetRequiredService<IApiVersionDescriptionProvider>();
            Settings = SrvScope.ServiceProvider.GetRequiredService<IOptions<SwaggerSettings>>().Value;
        }
        app.UseSwagger();
        app.UseSwaggerUI(
            options =>
            {
                // build a swagger endpoint for each discovered API version
                foreach (var description in Provider.ApiVersionDescriptions)
                {
                    /*
                     * دقت شود فرمت
                     * GroupNameFormat
                     * باید با نسخه مورد نظر هم خوانی داشته باشد
                     */
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", Settings.EndPointName + description.ApiVersion.ToString());
                    options.InjectStylesheet("/Swagger-ui/Custom.css");
                    options.InjectJavascript("/Swagger-ui/Custom.js");
                    options.DocumentTitle = Settings.DocumentTitle;
                }
            });
    }

}
