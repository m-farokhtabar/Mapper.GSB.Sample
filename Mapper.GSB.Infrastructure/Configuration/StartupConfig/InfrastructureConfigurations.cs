using Mapper.GSB.Application.DDRAPICaller.Insurance.Services.Scheduler;
using Mapper.GSB.Application.DDRAPICaller.Services.DDR;
using Mapper.GSB.Application.GSBAPICaller.Insurance.Events.PersonInsuranceDataRecieved;
using Mapper.GSB.Application.GSBAPICaller.SeedWorks.RestApi;
using Mapper.GSB.Application.SeedWork.Cache;
using Mapper.GSB.Application.SeedWorks;
using Mapper.GSB.Application.SeedWorks.BI;
using Mapper.GSB.Application.SeedWorks.Providers.PersonInsuranceProvider;
using Mapper.GSB.Application.Services.Terminology;
using Mapper.GSB.Domain.Insurance;
using Mapper.GSB.Domain.InsuranceDataCoordinator;
using Mapper.GSB.Domain.SeedWork;
using Mapper.GSB.Infrastructure.Caching;
using Mapper.GSB.Infrastructure.Data.Read;
using Mapper.GSB.Infrastructure.DDR;
using Mapper.GSB.Infrastructure.Domain;
using Mapper.GSB.Infrastructure.EventStore;
using Mapper.GSB.Infrastructure.MessageDispatcher;
using Mapper.GSB.Infrastructure.Provider;
using Mapper.GSB.Infrastructure.Provider.EventProviders;
using Mapper.GSB.Infrastructure.Provider.Terminology;
using Mapper.GSB.Infrastructure.RestApi;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Mapper.GSB.Infrastructure.Configuration.StartupConfig;

using Mapper.GSB.Application.Filter;
using Mapper.GSB.Application.FilterStore;
using Mapper.GSB.Infrastructure.BIStore;
using Mapper.GSB.Infrastructure.FilterStore;
using System.Data.Common;

/// <summary>
/// انواع تنظیمات اتصال به منابع خارجی
/// </summary>
public class InfrastructureConfigurations
{
    
    private readonly IServiceCollection services;
    private readonly string dbConnection;

    /// <summary>
    ///انواع تنظیمات اتصال به منابع خارجی
    /// </summary>
    /// <param name="services"></param>
    public InfrastructureConfigurations(IServiceCollection services, string dbConnection)
    {
        this.services = services;
        this.dbConnection = dbConnection;
    }
    /// <summary>
    /// تنظیمات برای حالت پیش فرض
    /// </summary>
    public void DefaultConfiguration(string dbBIConnection, string dbFilterConnection, string dbPersonPolicyInfoConnection)
    {
        services.AddScoped<IPersonInsuranceRepository, PersonInsuranceRepository>();
        services.AddScoped<IEventStore, Mapper.GSB.Infrastructure.EventStore.EventStore>();
        services.AddScoped<IPersonInsuranceDataCoordinatorRepository, PersonInsuranceDataCoordinatorRepository>();
        services.AddScoped<IPersonInsuranceDataCoordinatorProvider, PersonInsuranceDataCoordinatorProvider>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<MessageDispatcherFactory>();
        
        services.AddScoped<IBIStore, BIStore>();
        services.AddSingleton<IBIDbConnection>(_ => new BIDbConnection(dbBIConnection));

        services.AddScoped<IFilterStore, FilterStore>();
        services.AddScoped<IPersonAndPersonPolicyStore, PersonAndPersonPolicyStore>();        
        services.AddSingleton<IFilterDbConnection>(_ => new FilterDbConnection(dbFilterConnection));
        services.AddSingleton<IPersonPolicyInfoDbConnection>(_ => new PersonPolicyInfoDbConnection(dbPersonPolicyInfoConnection));
    }
    /// <summary>
    /// تنظیمات سرویس های برنامه
    /// GSB
    /// </summary>
    /// <param name="baseUrl"></param>
    /// <param name="dbBIConnection"></param>
    public void GSBServicesConfiguration(string baseUrl, string dbBIConnection, string dbFilterConnection, string dbPersonPolicyInfoConnection)
    {
        services.AddScoped<IEventProvider, EventProvider>();
        services.AddScoped<IPersonInsuranceDataCoordinatorRepository, PersonInsuranceDataCoordinatorRepository>();
        services.AddScoped<IPersonInsuranceDataCoordinatorProvider, PersonInsuranceDataCoordinatorProvider>();
        services.AddScoped<IEventStore, Mapper.GSB.Infrastructure.EventStore.EventStore>();
        services.AddScoped<IPersonInsuranceRepository, PersonInsuranceRepository>();

        services.AddScoped<IRestApiRepository>(x => new RestApiRepository(baseUrl, x.GetRequiredService<ILogger<RestApiRepository>>()));

        services.AddSingleton<ICacheStore, MemoryCacheStore>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<MessageDispatcherFactory>();

        services.AddScoped<IBIStore, BIStore>();
        services.AddSingleton<IBIDbConnection>(_ => new BIDbConnection(dbBIConnection));

        services.AddScoped<IFilterStore, FilterStore>();
        services.AddScoped<IPersonAndPersonPolicyStore, PersonAndPersonPolicyStore>();
        services.AddSingleton<IFilterDbConnection>(_ => new FilterDbConnection(dbFilterConnection));
        services.AddSingleton<IPersonPolicyInfoDbConnection>(_ => new PersonPolicyInfoDbConnection(dbPersonPolicyInfoConnection));
    }
    /// <summary>
    /// تنظیمات سرویس های برنامه
    /// SCheduler GSB
    /// </summary>
    /// <param name="baseUrl"></param>
    public void GSBSchedulerServicesConfiguration()
    {        
        services.AddScoped<IPersonInsuranceDataCoordinatorForSchedulerExtensionProvider, PersonInsuranceDataCoordinatorProvider>();
        services.AddScoped<IExternalMessageDispatcher, MassTranistMessageDispatcher>();
    }
    /// <summary>
    /// تنظیمات سرویس های مرتبط با سیستم 
    /// DDR
    /// و
    /// Mapper
    /// </summary>
    /// <param name="dbConnectionString"></param>
    /// <param name="mapperCachesetting"></param>
    public void DDRServicesConfiguration(string dbFilterConnection, string dbPersonPolicyInfoConnection)
    {
        services.AddScoped<IPersonInsuranceDataCoordinatorRepository, PersonInsuranceDataCoordinatorRepository>();
        services.AddScoped<IPersonInsuranceDataCoordinatorProvider, PersonInsuranceDataCoordinatorProvider>();
        services.AddScoped<IEventProvider, EventProvider>();
        services.AddScoped<ITerminologyProvider, TerminologyProvider>();
        services.AddScoped<IDDRRepository, DDRRepository>();

        services.AddSingleton<ICacheStore, MemoryCacheStore>();
        services.AddSingleton<IReadDbConnection>(_ => new ReadDbConnection(dbConnection));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<MessageDispatcherFactory>();

        services.AddScoped<IFilterStore, FilterStore>();
        services.AddScoped<IPersonAndPersonPolicyStore, PersonAndPersonPolicyStore>();
        services.AddSingleton<IFilterDbConnection>(_ => new FilterDbConnection(dbFilterConnection));
        services.AddSingleton<IPersonPolicyInfoDbConnection>(_ => new PersonPolicyInfoDbConnection(dbPersonPolicyInfoConnection));
    }
    /// <summary>
    /// تنظیمات سرویس های برنامه
    /// SCheduler DDR
    /// </summary>
    /// <param name="baseUrl"></param>
    public void DDRSchedulerServicesConfiguration()
    {
        services.AddScoped<IPersonInsuranceDataCoordinatorForDDRSchedulerExtensionProvider, PersonInsuranceDataCoordinatorProvider>();
        services.AddScoped<IExternalMessageDispatcher, MassTranistMessageDispatcher>();
    }

}
