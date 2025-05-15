namespace Mapper.GSB.Application.DDRAPICaller.Insurance.Services.Scheduler;

/// <summary>
/// دسترسی بع داده های هماهنگ کننده برای 
/// Scheduler
/// </summary>
public interface IPersonInsuranceDataCoordinatorForDDRSchedulerExtensionProvider
{
    /// <summary>
    /// دریافت اطلاعات بر اساس اگر رکوردی وضعیتش ارسال نشده است به 
    /// DDR
    /// این حالت برای رکورد هایی است که زمان ایجاد شان کمتر از زمان مشخص شده در ورودی متد باشد
    /// </summary>
    /// <param name="createdDate"></param>
    /// <param name="recordsPerPage"></param>
    /// <param name="page"></param>
    /// <returns></returns>
    Task<List<DDRSchedulerDto>> FindAllInsurancesWhichIsNotSendingDataToDDRBeforeTheCreatedDateAndSortedByCreatedDate(DateTime createdDate, int recordsPerPage, int page = 1);
}
