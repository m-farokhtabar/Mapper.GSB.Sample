namespace Mapper.GSB.Application.DDRAPICaller.Insurance.Services.Scheduler
{
    /// <summary>
    /// در این سرویس بررسی می کنیم که داده هایی که با موفقیت جهت ثبت در 
    /// DDR 
    /// ارسال نشده است دوباره بررسی و ارسال شود
    /// </summary>
    public interface IMissingSendingDataToDDRSchedulerService
    {
        /// <summary>
        /// اجرای زمان بند
        /// </summary>
        /// <param name="stoppingToken"></param>
        /// <returns></returns>
        Task Start(CancellationToken stoppingToken);
    }
}