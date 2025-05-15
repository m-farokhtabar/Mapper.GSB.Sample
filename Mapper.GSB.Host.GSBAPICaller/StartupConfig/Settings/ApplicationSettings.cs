using Mapper.GSB.Application.GSBAPICaller.SeedWorks;

namespace Mapper.GSB.Host.GSBAPICaller.StartupConfig.Settings;

/// <summary>
/// تنظیمات برنامه
/// </summary>
public class ApplicationSettings : IStatesMapping
{
    /// <summary>
    /// تنظیمات زبان برای نمایش پیام ها
    /// </summary>
    public string CurrentUICulture { get; init; } = string.Empty;
    /// <summary>
    /// کد نگاشت استان ها
    /// </summary>
    public Dictionary<int, int>? StatesMap { get; init; }
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