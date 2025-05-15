using Mapper.GSB.Domain.SeedWorks;

namespace Mapper.GSB.Domain.InsuranceDataCoordinator;

/// <summary>
/// داده های بیمه تکمیلی دریافت و وضعیت آن در جدول هماهنگ کننده به عنوان دریافت شده ثبت شده است
/// </summary>
/// <remarks>
/// به خاطر
/// Masstransit
/// حتما باید سازنده خالی عمومی داشته باشیم و از مدل تعریف خلاصه نمی توان استفاده کرد
/// </remarks>
public sealed record PersonInsuranceDataRecievedEvent : Event
{
    /// <summary>
    /// به خاطر
    /// Masstransit
    /// </summary>
    public PersonInsuranceDataRecievedEvent()
    {
        
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="aggregateRootId"></param>
    /// <param name="personInsuranceCreatedEventId"></param>
    /// <param name="version"></param>
    /// <param name="createDate"></param>
    public PersonInsuranceDataRecievedEvent(Guid aggregateRootId, Guid personInsuranceCreatedEventId, int version, DateTime createDate) : base(Guid.NewGuid(), aggregateRootId, nameof(PersonInsuranceDataCoordinator), version, createDate)
    {
        PersonInsuranceCreatedEventId = personInsuranceCreatedEventId;
    }

    /// <summary>
    /// شناسه رویداد مورد نظر جهت دریاقت اطلاعات و داده های مورد نظر
    /// </summary>
    public Guid PersonInsuranceCreatedEventId { get; set; }
}    
