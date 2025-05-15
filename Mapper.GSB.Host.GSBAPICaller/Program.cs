using Logging;
using Mapper.GSB.Host.GSBAPICaller;
using Mapper.GSB.Host.GSBAPICaller.StartupConfig.Applications;
using Mapper.GSB.Host.GSBAPICaller.StartupConfig.Services;
using Mapper.GSB.Host.GSBAPICaller.StartupConfig.Settings;
using Mapper.GSB.Infrastructure.Configuration.StartupConfig;
using Serilog;
using Mapper.GSB.Application.GSBAPICaller.Configuration.StratupConfig;
using Mapper.GSB.Application.GSBAPICaller.Insurance.Services;

string currentUICulture = "fa-IR";
IHost host = Host.CreateDefaultBuilder(args)
.UseSerilog(LoggingConfiguration.SeriLogConfiguration)
.ConfigureServices((hostContext, services) =>
{
    IConfiguration configuration = hostContext.Configuration;

    MassTransitSettings massTransitSettings = configuration.GetSection("MassTransitSettings").Get<MassTransitSettings>()!;
    ApplicationSettings applicationSettings = configuration.GetSection("ApplicationSettings").Get<ApplicationSettings>()!;

    currentUICulture = applicationSettings.CurrentUICulture;


    if (applicationSettings.ServiceType == ServiceType.APICaller)
    {
        RestApiSettings restApiSettings = configuration.GetSection("RestApiSettings").Get<RestApiSettings>()!;
        GSBSendDataSettings gSBSendDataSettings = configuration.GetSection("GSBSendDataSettings").Get<GSBSendDataSettings>()!;
        CacheSettings cacheSettings = configuration.GetSection("CacheSettings").Get<CacheSettings>()!;
        services.ConfigureSettings(cacheSettings, restApiSettings, gSBSendDataSettings, applicationSettings);
        services.InfrastructureConfiguration(configuration["ConnectionStrings:DbConnection"]!, x => x.GSBServicesConfiguration(restApiSettings.BaseUrl, configuration["ConnectionStrings:DbBIConnection"]!, 
                                                                                                                                                        configuration["ConnectionStrings:DbFilterConnection"]!,
                                                                                                                                                        configuration["ConnectionStrings:DbPersonPolicyInfoConnection"]!));
        services.AddMemoryCache();
        services.AddHostedService<Worker>();
        services.ApplicationGSBAPICallerConfiguration(x => x.ApplicationGSBAPICallerConfiguration());
        services.ConfigureMassTransit(massTransitSettings, x => x.ConfigureMassTransitGSBAPICallerConfiguration());
    }
    else
    {
        GSBSchedulerServiceSetting gSBSchedulerServiceSetting = configuration.GetSection("GSBSchedulerServiceSetting").Get<GSBSchedulerServiceSetting>()!;        
        services.AddSingleton<IGSBSchedulerServiceSetting>(_ => gSBSchedulerServiceSetting);
        services.AddSingleton(_ => gSBSchedulerServiceSetting);

        services.ApplicationGSBAPICallerConfiguration(x => x.ApplicationMissedGSBAPICallerSchedulerConfiguration());
        services.InfrastructureConfiguration(configuration["ConnectionStrings:DbConnection"]!, x => x.GSBSchedulerServicesConfiguration());
                
        services.ConfigureMassTransit(massTransitSettings, x => x.ConfigureMissedGSBAPICallerSchedulerConfiguration());
        services.AddHostedService<Schedular>();
    }
})
.Build();
host.ConfigureCulture(currentUICulture);
host.Run();
