using Mapper.GSB.Application.GSBAPICaller.Insurance.Services;
using Mapper.GSB.Host.GSBAPICaller.StartupConfig.Settings;

namespace Mapper.GSB.Host.GSBAPICaller;
/// <summary>
/// کلاس جهت تنظیم و اجرای سرویس زمان بند بررسی داده های سند نشده به
/// GSB
/// و ارسال مجدد آنها
/// </summary>
public class Schedular : BackgroundService
{
    public readonly PeriodicTimer timer;
    private readonly GSBSchedulerServiceSetting serviceSetting;
    private readonly IServiceProvider services;    
    private readonly ILogger<Schedular> logger;

    /// <summary>
    /// تنظیمات اولیه سرویس
    /// </summary>
    /// <param name="serviceSetting"></param>
    public Schedular(GSBSchedulerServiceSetting serviceSetting, IServiceProvider services, ILogger<Schedular> logger)
    {
        this.serviceSetting = serviceSetting;
        this.services = services;
        this.logger = logger;
        timer = new PeriodicTimer(TimeSpan.FromMinutes(serviceSetting.ServiceRunningPeriod));
    }
    /// <summary>
    /// اجرای زمانبند
    /// </summary>
    /// <param name="stoppingToken"></param>
    /// <returns></returns>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation($"GSB schedular is Started. The service will run every {serviceSetting.ServiceRunningPeriod} minutes.");
        do
        {
            logger.LogInformation($"This period is Started from {DateTime.Now} -");
            using var scope = services.CreateScope();
            var schedulerService = scope.ServiceProvider.GetRequiredService<IMissingSendingDataToGSBSchedulerService>();
            await schedulerService.Start(stoppingToken);
            logger.LogInformation($"The period is ended in {DateTime.Now} -");
        } while (await timer.WaitForNextTickAsync(stoppingToken) && !stoppingToken.IsCancellationRequested);
    }
}
