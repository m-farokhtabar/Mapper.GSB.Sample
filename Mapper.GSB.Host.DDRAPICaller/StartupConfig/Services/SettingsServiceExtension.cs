using Mapper.GSB.Application.DDRAPICaller.Services.DDR;
using Mapper.GSB.Application.SeedWork.Cache;
using Mapper.GSB.Application.Services.Terminology.openEHR;
using Mapper.GSB.Host.DDRAPICaller.StartupConfig.Settings;
using Mapper.GSB.Infrastructure.DDR;
using Mapper.openEHR.ModelToOPT.SeedWork;

namespace Mapper.GSB.Host.DDRAPICaller.StartupConfig.Services;

/// <summary>
/// دریافت تنظیمات اولیه برنامه
/// </summary>
public static class SettingsServiceExtension
{
    /// <summary>
    /// دریافت اطلاعات تنظیمات برنامه
    /// </summary>
    /// <param name="services"></param>
    /// <param name="cacheSettings"></param>
    /// <param name="mapperSetting"></param>
    /// <param name="openEHRTerminologySettings"></param>
    /// <param name="dDRRepositorySettings"></param>
    public static void ConfigureSettings(this IServiceCollection services, CacheSettings cacheSettings, DDRMapperSetting mapperSetting, OpenEHRTerminologySettings openEHRTerminologySettings, DDRRepositorySettings dDRRepositorySettings)
    {
        services.AddSingleton<ICacheSetting>(_ => cacheSettings);
        services.AddSingleton<IDDRMapperSetting>(_ => mapperSetting);
        services.AddSingleton<IMapperSetting>(_ => mapperSetting);
        services.AddSingleton<IOpenEHRTerminologySetting>(_ => openEHRTerminologySettings);
        services.AddSingleton<IDDRRepositorySettings>(_ => dDRRepositorySettings);
    }
}