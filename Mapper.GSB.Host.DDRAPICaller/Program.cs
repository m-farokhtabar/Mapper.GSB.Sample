using Mapper.GSB.Host.DDRAPICaller;
using Mapper.GSB.Host.DDRAPICaller.StartupConfig.Settings;
using Mapper.GSB.Application.DDRAPICaller.Configuration.StratupConfig;
using Mapper.GSB.Infrastructure.Configuration.StartupConfig;
using Mapper.GSB.Host.DDRAPICaller.StartupConfig.Services;
using Mapper.GSB.Host.DDRAPICaller.StartupConfig.Applications;
using Serilog;
using Logging;
using Mapper.GSB.Application.DDRAPICaller.Insurance.Services.Scheduler;

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
            DDRMapperSetting mapperSetting = configuration.GetSection("DDRMapperSetting").Get<DDRMapperSetting>()!;
            CacheSettings cacheSettings = configuration.GetSection("CacheSettings").Get<CacheSettings>()!;
            OmCacheSettings mapperCacheSettings = configuration.GetSection("OmCacheSettings").Get<OmCacheSettings>()!;            
            OpenEHRTerminologySettings openEHRTerminologySettings = configuration.GetSection("OpenEHRTerminologySettings").Get<OpenEHRTerminologySettings>()!;
            DDRRepositorySettings dDRRepositorySettings = configuration.GetSection("DDRRepositorySettings").Get<DDRRepositorySettings>()!;

            services.AddMemoryCache();
            services.ConfigureSettings(cacheSettings, mapperSetting, openEHRTerminologySettings, dDRRepositorySettings);
            services.ApplicationGSBAPICallerConfiguration(x=>x.ApplicationDDRAPICallerConfiguration(configuration["ConnectionStrings:DbConnection"]!, mapperCacheSettings));
            services.InfrastructureConfiguration(configuration["ConnectionStrings:DbConnection"]!, x => x.DDRServicesConfiguration(configuration["ConnectionStrings:DbFilterConnection"]!,
                                                                                                                                   configuration["ConnectionStrings:DbPersonPolicyInfoConnection"]!));

            services.ConfigureMassTransit(massTransitSettings, x => x.ConfigureMassTransitDDRAPICallerConfiguration());
            services.AddHostedService<Worker>();
        }
        else
        {
            DDRSchedulerServiceSetting dDRSchedulerServiceSetting = configuration.GetSection("DDRSchedulerServiceSetting").Get<DDRSchedulerServiceSetting>()!;
            services.AddSingleton<IDDRSchedulerServiceSetting>(_ => dDRSchedulerServiceSetting);
            services.AddSingleton(_ => dDRSchedulerServiceSetting);
            
            services.ApplicationGSBAPICallerConfiguration(x => x.ApplicationMissedDDRAPICallerSchedulerConfiguration());
            services.InfrastructureConfiguration(configuration["ConnectionStrings:DbConnection"]!, x => x.DDRSchedulerServicesConfiguration());

            services.ConfigureMassTransit(massTransitSettings, x => x.ConfigureMissedDDRAPICallerSchedulerConfiguration());
            services.AddHostedService<Schedular>();
        }
        
    })
    .Build();
host.ConfigureCulture(currentUICulture);
host.Run();
