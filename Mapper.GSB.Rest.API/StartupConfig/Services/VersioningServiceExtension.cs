using Asp.Versioning;

namespace Mapper.GSB.Rest.API.StartupConfig.Services;

/// <summary>
/// تنظیمات نسخه های سرویس ها
/// </summary>
public static class VersioningServiceExtension
{
    /// <summary>
    /// تنظیم نسخه سرویس های
    /// API
    /// </summary>
    public static void ConfigureVersioning(this IServiceCollection Services)
    {
        Services.AddApiVersioning(c =>
        {
            c.DefaultApiVersion = new ApiVersion(1, 0);
            c.AssumeDefaultVersionWhenUnspecified = true;
            c.ReportApiVersions = true;                        
        }).AddApiExplorer(options =>
        {
            /*
             * دلیل استفاده از 
             * VVVV
             * یعنی اینکه نسخه می تواند به صورت
             * اصلی.فرعی باشد
             * اگر از سه
             * VVV
             * استفاده کنیم یعنی نسخه اصلی فقط
             */
            options.GroupNameFormat = "'v'VVVV";
            /*
             * زمانی که می خواهیم نسخه فعلی بر روی 
             * URL
             * ها اعمال شود با فعال کردن این گزینه و فرمت مناسب تمامی آدرس ها به طور اتوماتیک نسخه مورد را دریافت می کنند
             */
            options.SubstituteApiVersionInUrl = true;
            options.SubstitutionFormat = "VVVV";
        });
    }
}
