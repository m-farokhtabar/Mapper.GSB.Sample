using Mapper.GSB.Application.GSBAPICaller.Insurance.Events.PersonInsuranceDataRecieved;
using Mapper.GSB.Application.GSBAPICaller.Insurance.Services;
using Mapper.GSB.Application.GSBAPICaller.Serviecs.GSBService;
using Mapper.GSB.Domain.InsuranceDataCoordinator;
using Microsoft.Extensions.DependencyInjection;

namespace Mapper.GSB.Application.GSBAPICaller.Configuration.StartupConfig
{
    /// <summary>
    /// انواع تنظیمات برنامه
    /// </summary>
    public class ApplicationGSBAPICallerConfigurations
    {
        private readonly IServiceCollection services;
        /// <summary>
        /// تنظیمات برنامه ها
        /// </summary>
        /// <param name="services"></param>
        public ApplicationGSBAPICallerConfigurations(IServiceCollection services)
        {
            this.services = services;
        }
        /// <summary>
        /// تنظیمات سرویس های مورد نیاز برنامه
        /// برای جالت صدا زدن سرویس 
        /// GSB
        /// </summary>
        public void ApplicationGSBAPICallerConfiguration()
        {
            //ConfigureMediatR(services);            
            services.AddScoped<IGSBDataSenderService, GSBDataSenderService>();
            /**
             * تنظیمات مروبط به
             * MediatR
             * این دستور را واقعا نیاز نداره 
             * ولی چون قرار با پروژه 
             * Mapper.GSB.Infrastructure
             * کار کنه مجبوریم همینجوری یه چیزی ثبت کنیم
             */
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<PersonInsuranceDataRecievedEventHandler>());
            services.AddScoped<IGSBStatusDomainService, GSBStatusDomainService>();
        }
        /// <summary>
        /// تنظیمات سرویس های مورد نیاز برنامه
        /// برای حالت زمانبند
        /// </summary>
        public void ApplicationMissedGSBAPICallerSchedulerConfiguration()
        {
            /**
             * تنظیمات مروبط به
             * MediatR
             * این دستور را واقعا نیاز نداره
             * ولی چون قرار با پروژه 
             * Mapper.GSB.Infrastructure
             * کار کنه مجبوریم همینجوری یه چیزی ثبت کنیم
             */
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<PersonInsuranceDataRecievedEventHandler>());
            services.AddScoped<IMissingSendingDataToGSBSchedulerService, MissingSendingDataToGSBSchedulerService>();
        }
    }
}
