using Mapper.GSB.Application.DDRAPICaller.Insurance.Events.PersonInsuranceEvent.PersonInsuranceDataSentToGSBServiceSucceessfully;
using Mapper.GSB.Host.DDRAPICaller.StartupConfig.Settings;
using MassTransit;
using openEHR.DDR.Command.Party.Create;
using openEHR.DDR.Command.Party.Update;
using openEHR.DDR.Command.PartyRelationship.Create;
using openEHR.DDR.Command.PartyRelationship.Update;
using openEHR.DDR.Command.SeedWork.Serializer;

namespace Mapper.GSB.Host.DDRAPICaller.StartupConfig.Services
{
    /// <summary>
    /// تنظیمات مربوط به استفاده از
    /// RabbitMQ / Masstransit
    /// </summary>
    internal static class MassTransitServiceExtension
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
    /// <summary>
    /// تظنیمات 
    /// MassTransit
    /// بر اساس نوع برنامه ای که می خواهد اجرا شود
    /// </summary>
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
        /// DDR
        /// </summary>
        public void ConfigureMassTransitDDRAPICallerConfiguration()
        {
            services.AddMassTransit(Config =>
            {
                Config.AddConsumers(typeof(PersonInsuranceDataSentToGSBServiceSucceessfullyEventHandler).Assembly);
                Config.SetKebabCaseEndpointNameFormatter();
                Config.UsingRabbitMq((context, cfg) =>
                {
                    cfg.UseNewtonsoftJsonSerializer();
                    cfg.UseNewtonsoftJsonDeserializer();
                    cfg.ConfigureNewtonsoftJsonSerializer(settings =>
                    {
                        settings.Converters.Add(new MessageConverter());
                        return settings;
                    });
                    cfg.Host(massTransitSettings.RabbitMQConnection);
                    cfg.Durable = massTransitSettings.Durable;
                    cfg.PurgeOnStartup = massTransitSettings.PurgeOnStartup;
                    cfg.ConfigureEndpoints(context);                    
                });
                Config.AddRequestClient<CreatePartyCommand>(timeout: RequestTimeout.After(s: massTransitSettings.TimeOutForCommand));
                Config.AddRequestClient<UpdatePartyCommand>(timeout: RequestTimeout.After(s: massTransitSettings.TimeOutForCommand));

                Config.AddRequestClient<CreatePartyRelationshipCommand>(timeout: RequestTimeout.After(s: massTransitSettings.TimeOutForCommand));
                Config.AddRequestClient<UpdatePartyRelationshipCommand>(timeout: RequestTimeout.After(s: massTransitSettings.TimeOutForCommand));
            });            
        }
        /// <summary>
        /// تنظیمات سرویس های مورد نیاز برنامه
        /// برای حالت زمانبند
        /// </summary>
        public void ConfigureMissedDDRAPICallerSchedulerConfiguration()
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
}
