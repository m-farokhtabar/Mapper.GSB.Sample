using System.Globalization;

namespace Mapper.GSB.Host.DDRAPICaller.StartupConfig.Applications
{
    /// <summary>
    /// تعیین نوع زبان پیش فرض سیستم
    /// </summary>
    public static class CultureApplicationExtension
    {
        /// <summary>
        /// تنظیم زبان جهت نمایش زبان
        /// </summary>
        /// <param name="host"></param>
        /// <param name="CurrentCulture"></param>
        public static void ConfigureCulture(this IHost host, string CurrentCulture)
        {
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.CreateSpecificCulture(CurrentCulture);
        }
    }
}
