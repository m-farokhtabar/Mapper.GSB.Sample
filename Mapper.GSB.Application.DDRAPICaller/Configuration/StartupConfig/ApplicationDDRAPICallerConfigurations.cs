using Mapper.GSB.Application.Configuration.StratupConfig;
using Mapper.GSB.Application.DDRAPICaller.Insurance.Events.PersonInsuranceEvent.PersonInsuranceDataSentToGSBServiceSucceessfully;
using Mapper.GSB.Application.DDRAPICaller.Insurance.Services.Scheduler;
using Mapper.GSB.Application.DDRAPICaller.Services.DDR;
using Mapper.openEHR.Infrastructure.StratupConfig;
using Mapper.openEHR.SeedWork.Cache;
using Mapper.openEHR.StratupConfig;
using Microsoft.Extensions.DependencyInjection;

namespace Mapper.GSB.Application.DDRAPICaller.Configuration.StratupConfig
{
    /// <summary>
    /// انواع تنظیمات برنامه
    /// </summary>
    public class ApplicationDDRAPICallerConfigurations
    {
        private readonly IServiceCollection services;
        /// <summary>
        /// تنظیمات برنامه ها
        /// </summary>
        /// <param name="services"></param>
        public ApplicationDDRAPICallerConfigurations(IServiceCollection services)
        {
            this.services = services;
        }
        /// <summary>
        /// تنظیمات سرویس های مورد نیاز برنامه
        /// برای جالت صدا زدن سرویس 
        /// DDR
        /// </summary>
        /// <param name="dbConnectionString"></param>
        /// <param name="mapperCachesetting"></param>
        public void ApplicationDDRAPICallerConfiguration(string dbConnectionString, IOmCacheSetting mapperCachesetting)
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
            services.ApplicationConfiguration(x => x.OpenEHRTerminologyServiceConfiguration());
        }
        /// <summary>
        /// تنظیمات سرویس های مورد نیاز برنامه
        /// برای حالت زمانبند
        /// </summary>
        public void ApplicationMissedDDRAPICallerSchedulerConfiguration()
        {
            /**
             * تنظیمات مروبط به
             * MediatR
             * این دستور را واقعا نیاز نداره
             * ولی چون قرار با پروژه 
             * Mapper.GSB.Infrastructure
             * کار کنه مجبوریم همینجوری یه چیزی ثبت کنیم
             */
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<PersonInsuranceDataSentToGSBServiceSucceessfullyEventHandler>());
            services.AddScoped<IMissingSendingDataToDDRSchedulerService, MissingSendingDataToDDRSchedulerService>();
        }
    }
}
