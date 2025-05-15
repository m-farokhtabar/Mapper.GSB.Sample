namespace Mapper.GSB.Application.DDRAPICaller.Insurance.Services.Scheduler;

/// <summary>
/// اطلاعات مورد نیاز از جدول هماهنگ کننده برای سرویس زمان بند بررسی درخواست های ارسال نشده به 
/// DDR
/// </summary>
public class DDRSchedulerDto
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="personInsuranceCreatedEventId"></param>
    /// <param name="version"></param>
    /// <param name="createDate"></param>
    public DDRSchedulerDto(Guid id, int version, DateTime createDate)
    {
        Id = id;            
        Version = version;
        CreateDate = createDate;
    }
    /// <summary>
    /// شناسه هماهنگ کننده
    /// </summary>
    public Guid Id { get; private set; }
    /// <summary>
    /// نسخه داده
    /// در هماهنگ کننده
    /// همان نسخه واقعی
    /// </summary>
    public int Version { get; private set; }
    /// <summary>
    /// زمان ایجاد در هماهنگ کننده
    /// </summary>
    public DateTime CreateDate { get; private set; }
}
