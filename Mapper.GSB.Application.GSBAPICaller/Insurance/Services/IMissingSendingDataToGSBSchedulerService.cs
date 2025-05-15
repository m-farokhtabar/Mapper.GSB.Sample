namespace Mapper.GSB.Application.GSBAPICaller.Insurance.Services
{
    /// <summary>
    /// در این سرویس بررسی می کنیم که داده هایی که با موفقیت جهت ثبت در 
    /// GSB 
    /// ارسال نشده است دوباره بررسی و ارسال شود
    /// </summary>
    public interface IMissingSendingDataToGSBSchedulerService
    {
        /// <summary>
        /// اجرای زمان بند
        /// </summary>
        /// <param name="stoppingToken"></param>
        /// <returns></returns>
        Task Start(CancellationToken stoppingToken);
    }
}