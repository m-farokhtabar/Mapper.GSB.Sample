using Mapper.GSB.Application.DDRAPICaller.Insurance.Events.PersonInsuranceEvent.PersonInsuranceDataSentToGSBServiceSucceessfully;
using Mapper.GSB.Application.DDRAPICaller.Services.DDR;
using Mapper.openEHR.Infrastructure.StratupConfig;
using Mapper.openEHR.SeedWork.Cache;
using Mapper.openEHR.StratupConfig;
using Microsoft.Extensions.DependencyInjection;
using Mapper.GSB.Application.Configuration.StratupConfig;

namespace Mapper.GSB.Application.DDRAPICaller.Configuration.StratupConfig;

/// <summary>
/// تنظیمات سرویس های برنامه جهت صدا زدن 
/// GSB API
/// </summary>
public static class ApplicationDDRAPICallerServiceExtension
{
    /// <summary>
    /// تنظیمات سرویس های مورد نیاز برنامه
    /// </summary>
    /// <param name="services"></param>
    /// <param name="dbConnectionString"></param>
    /// <param name="mapperCachesetting"></param>
    /// <param name="configuration"></param>
    public static void ApplicationGSBAPICallerConfiguration(this IServiceCollection services, Action<ApplicationDDRAPICallerConfigurations> configuration)
    {
        var appCfg = new ApplicationDDRAPICallerConfigurations(services);
        configuration.Invoke(appCfg);
    }

    /// <summary>
    /// تنظیمات سرویس های مورد نیاز برنامه
    /// </summary>
    /// <param name="services"></param>
    public static void ApplicationDDRAPICallerConfiguration(this IServiceCollection services, string dbConnectionString, IOmCacheSetting mapperCachesetting)
    {        
        services.AddScoped<IDDRService, DDRService>();
        /**
         * تنظیمات مروبط به
         * MediatR
         * این دستور را واقعا نیاز نداره 
         * ولی چون قرار با پروژه 
         * Mapper.GSB.Infrastructure
         * کار کنه مجبوریم همینجوری یه چیزی ثبت کنیم
         */
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<PersonInsuranceDataSentToGSBServiceSucceessfullyEventHandler>());
        services.ConfigOpenEHRMapper();
        services.ConfigOpenEHRMapperInfrastructure(dbConnectionString, mapperCachesetting);
        services.ApplicationConfiguration(x=>x.OpenEHRTerminologyServiceConfiguration());
    }
}
