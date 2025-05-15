using openEHR.DDR.Query.Party.Details;
using openEHR.DDR.Query.PartyRelationship.Details;
using openEHR.DDR.Command.SeedWork.Serializer;
using Mapper.GSB.Rest.API.StartupConfig.Settings;
using MassTransit;

namespace Mapper.GSB.Rest.API.StartupConfig.Services;

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
    public static void ConfigureMassTransit(this IServiceCollection services, MassTransitSettings massTransitSettings)
    {        
        services.AddMassTransit(Config =>
        {
            Config.UsingRabbitMq((Context, Cfg) =>
            {
                //Cfg.ConfigureNewtonsoftJsonSerializer(settings =>
                //{
                //    settings.Converters.Add(new MessageConverter());
                //    return settings;
                //});                
                Cfg.Host(massTransitSettings.RabbitMQConnection);
            });
            //Config.AddRequestClient<PartyDetailsQuery>(timeout: RequestTimeout.After(s: massTransitSettings!.TimeOutForQuery));
            //Config.AddRequestClient<PartyRelationshipDetailsQuery>(timeout: RequestTimeout.After(s: massTransitSettings!.TimeOutForQuery));
        });        
    }
}
