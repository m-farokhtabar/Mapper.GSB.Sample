using Mapper.GSB.Application.Configuration.StratupConfig;
using Mapper.GSB.Application.GSBAPICaller.Configuration.StartupConfig;
using Mapper.GSB.Application.GSBAPICaller.Insurance.Events.PersonInsuranceDataRecieved;
using Mapper.GSB.Application.GSBAPICaller.Serviecs.GSBService;
using Mapper.GSB.Application.SeedWorks.Providers.PersonInsuranceProvider;
using Mapper.GSB.Domain.InsuranceDataCoordinator;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace Mapper.GSB.Application.GSBAPICaller.Configuration.StratupConfig
{
    /// <summary>
    /// تنظیمات سرویس های برنامه جهت صدا زدن 
    /// GSB API
    /// </summary>
    public static class ApplicationGSBAPICallerServiceExtension
    {
        /// <summary>
        /// تنظیمات سرویس های مورد نیاز برنامه
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void ApplicationGSBAPICallerConfiguration(this IServiceCollection services, Action<ApplicationGSBAPICallerConfigurations> configuration)
        {
            var appCfg = new ApplicationGSBAPICallerConfigurations(services);
            configuration.Invoke(appCfg);
        }
    }
}
