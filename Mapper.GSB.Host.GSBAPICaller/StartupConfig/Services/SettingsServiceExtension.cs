using Mapper.GSB.Application.GSBAPICaller.Insurance.Events.PersonInsuranceDataRecieved;
using Mapper.GSB.Application.GSBAPICaller.SeedWorks;
using Mapper.GSB.Application.GSBAPICaller.SeedWorks.RestApi;
using Mapper.GSB.Application.SeedWork.Cache;
using Mapper.GSB.Host.GSBAPICaller.StartupConfig.Settings;

namespace Mapper.GSB.Host.GSBAPICaller.StartupConfig.Services;

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
    /// <param name="restApiSettings"></param>
    /// <param name="gSBSendDataSettings"></param>
    /// <param name="applicationSettings"></param>
    public static void ConfigureSettings(this IServiceCollection services, CacheSettings cacheSettings, RestApiSettings restApiSettings, GSBSendDataSettings gSBSendDataSettings, ApplicationSettings applicationSettings)
    {
        services.AddSingleton<ICacheSetting>(_ => cacheSettings);
        services.AddSingleton<IRestApiSettings>(_ => restApiSettings);
        services.AddSingleton<IGSBSendDataSettings>(_ => gSBSendDataSettings);
        services.AddSingleton<IRestApiSettings>(_ => restApiSettings);
        services.AddSingleton<IStatesMapping>(_ => applicationSettings);
    }
}
