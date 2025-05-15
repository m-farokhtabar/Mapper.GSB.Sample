using Mapper.GSB.Application.GSBAPICaller.Insurance.Events.PersonInsuranceDataRecieved;
using Mapper.GSB.Host.GSBAPICaller.StartupConfig.Settings;
using MassTransit;

namespace Mapper.GSB.Host.GSBAPICaller.StartupConfig.Services;

/// <summary>
/// تنظیمات مربوط به استفاده از
/// RabbitMQ / Masstransit
/// </summary>
public static class MassTransitServiceExtension
{
    /// <summary>
    /// تنظیمات مربوط به استفاده از
    /// RabbitMQ / Masstransit\
    /// </summary>
    /// <param name="services"></param>
    /// <param name="massTransitSettings"></param>
    public static void ConfigureMassTransit(this IServiceCollection services, MassTransitSettings massTransitSettings, Action<MassTransitConfiguration> configuration)
    {
        var cfg = new MassTransitConfiguration(services, massTransitSettings);        
        configuration(cfg);
    }
}

public class MassTransitConfiguration
{
    private readonly IServiceCollection services;
    private readonly MassTransitSettings massTransitSettings;

    /// <summary>
    /// تنظیمات مربوط به استفاده از
    /// RabbitMQ / Masstransit\
    /// </summary>
    /// <param name="services"></param>
    /// <param name="massTransitSettings"></param>
    public MassTransitConfiguration(IServiceCollection services, MassTransitSettings massTransitSettings)
    {
        this.services = services;
        this.massTransitSettings = massTransitSettings;
    }
    /// <summary>
    /// تنظیمات سرویس های مورد نیاز برنامه
    /// برای جالت صدا زدن سرویس 
    /// GSB
    /// </summary>
    public void ConfigureMassTransitGSBAPICallerConfiguration()
    {
        services.AddMassTransit(Config =>
        {
                Config.AddConsumers(typeof(PersonInsuranceDataRecievedEventHandler).Assembly);
                Config.SetKebabCaseEndpointNameFormatter();
                Config.UsingRabbitMq((context, cfg) =>
                {
                    cfg.UseConcurrencyLimit(32);
                    cfg.PrefetchCount = 32;
                    cfg.ConfigureEndpoints(context);
                    cfg.Host(massTransitSettings.RabbitMQConnection);
                    cfg.Durable = massTransitSettings.Durable;
                    cfg.PurgeOnStartup = massTransitSettings.PurgeOnStartup;
                });
        });

    }
    /// <summary>
    /// تنظیمات سرویس های مورد نیاز برنامه
    /// برای حالت زمانبند
    /// </summary>
    public void ConfigureMissedGSBAPICallerSchedulerConfiguration()
    {
        services.AddMassTransit(Config =>
        {
                Config.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(massTransitSettings.RabbitMQConnection);
                });
        });

    }
}
