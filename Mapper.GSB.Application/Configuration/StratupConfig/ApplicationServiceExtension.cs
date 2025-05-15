using Mapper.GSB.Application.Insurance.Commands.Save;
using Mapper.GSB.Application.SeedWorks;
using Mapper.GSB.Domain.Insurance;
using Mapper.GSB.Domain.SeedWorks;
using MassTransit;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Mapper.GSB.Application.Configuration.StratupConfig
{
    /// <summary>
    /// تنظیمات سرویس های برنامه
    /// </summary>
    public static class ApplicationServiceExtension
    {
        /// <summary>
        /// تنظیمات سرویس های مورد نیاز برنامه
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void ApplicationConfiguration(this IServiceCollection services,Action<ApplicationConfigurations> configuration)
        {
            var appCfg = new ApplicationConfigurations(services);
            configuration.Invoke(appCfg);
        }
    }
}
