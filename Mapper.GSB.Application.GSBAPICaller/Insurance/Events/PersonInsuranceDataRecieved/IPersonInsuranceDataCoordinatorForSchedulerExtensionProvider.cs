using Mapper.GSB.Application.GSBAPICaller.Insurance.Services;

namespace Mapper.GSB.Application.GSBAPICaller.Insurance.Events.PersonInsuranceDataRecieved;

/// <summary>
/// دسترسی بع داده های هماهنگ کننده برای 
/// Scheduler
/// </summary>
public interface IPersonInsuranceDataCoordinatorForSchedulerExtensionProvider
{
    /// <summary>
    /// دریافت اطلاعات بر اساس اگر رکوردی وضعیتش ارسال نشده است به 
    /// GSB
    /// این حالت برای رکورد هایی است که زمان ایجاد شان کمتر از زمان مشخص شده در ورودی متد باشد
    /// </summary>
    /// <param name="createdDate"></param>
    /// <param name="recordsPerPage"></param>
    /// <param name="page"></param>
    /// <returns></returns>
    Task<List<GSBSchedulerDto>> FindAllInsurancesWhichIsNotSendingDataToGSBBeforeTheCreatedDateAndSortedByCreatedDate(DateTime createdDate,int recordsPerPage, int page = 1);
}
