namespace Mapper.GSB.Host.DDRAPICaller.StartupConfig.Settings
{
    /// <summary>
    /// تنظیمات برنامه
    /// </summary>
    public class ApplicationSettings
    {
        /// <summary>
        /// تنظیمات زبان برای نمایش پیام ها
        /// </summary>
        public string CurrentUICulture { get; init; } = string.Empty;
        /// <summary>
        /// نوع راه اندازی
        /// </summary>
        public ServiceType ServiceType { get; init; }
    }
    /// <summary>
    /// نوع سرویس
    /// </summary>
    public enum ServiceType
    {
        APICaller,
        MissedAPICallerScheduler
    }
}
