using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace Mapper.GSB.Rest.API.StartupConfig.Applications
{
    /// <summary>
    /// تنظیمات زبان
    /// </summary>
    public static class LocalizationApplicationExtension
    {
        /// <summary>
        /// تنظیم زبان برای نمایش پیام ها
        /// </summary>
        /// <param name="app"></param>
        public static void UseCustomizeLocalization(this WebApplication app)
        {
            var FaCu = CultureInfo.CreateSpecificCulture("fa-IR");
            app.UseRequestLocalization(new RequestLocalizationOptions()
            {
                DefaultRequestCulture = new RequestCulture(FaCu),
                SupportedUICultures = new List<CultureInfo>
                {
                    FaCu
                }
            });
        }
    }
}
