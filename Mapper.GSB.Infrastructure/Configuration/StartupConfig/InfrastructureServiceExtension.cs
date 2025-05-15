using Mapper.GSB.Domain.SeedWork;
using Mapper.GSB.Infrastructure.Data;
using Mapper.GSB.Infrastructure.Domain;
using Mapper.GSB.Infrastructure.MessageDispatcher;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Mapper.GSB.Infrastructure.Configuration.StartupConfig
{
    /// <summary>
    /// تنظیمات مربوط به منابع خارجی مورد نیاز سیستم مانند پایگاه داده ها
    /// </summary>
    public static class InfrastructureServiceExtension
    {
        /// <summary>
        /// تنظیمات سرویس های مرتبط با پایگاه داده و سیستم صف
        /// </summary>
        /// <param name="services"></param>
        /// <param name="dbConnection"></param>
        /// <param name="configuration"></param>
        public static void InfrastructureConfiguration(this IServiceCollection services, string dbConnection, Action<InfrastructureConfigurations> configuration)
        {
            ConfigureCommonServices(services, dbConnection);
            var infraCfg = new InfrastructureConfigurations(services, dbConnection);
            configuration.Invoke(infraCfg);
        }
        /// <summary>
        /// تنظیمات سرویس پایگاه داده
        /// Mapper
        /// </summary>
        /// <param name="services"></param>
        /// <param name="dbConnection"></param>
        private static void ConfigureCommonServices(IServiceCollection services, string dbConnection)
        {
            var migrationAssembly = typeof(InfrastructureServiceExtension).GetTypeInfo().Assembly.GetName().Name;
            services.AddDbContext<GSBDbContext>(Opts => Opts.UseSqlServer(dbConnection, sql => sql.MigrationsAssembly(migrationAssembly)));            
            services.AddScoped<IDbSet>(x => x.GetRequiredService<GSBDbContext>());
        }
    }
}
