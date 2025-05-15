using Mapper.GSB.Domain.SeedWorks;

namespace Mapper.GSB.Domain.InsuranceDataCoordinator;

/// <summary>
/// رویداد
/// داده های بیمه تکمیلی با موفقیت برای سرور
/// GSB
/// ارسال گردید
/// </summary>
public sealed record PersonInsuranceDataSentToGSBServiceSucceessfullyEvent : Event
{
    /// <summary>
    /// به خاطر
    /// Masstransit
    /// </summary>
    public PersonInsuranceDataSentToGSBServiceSucceessfullyEvent()
    {

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="aggregateRootId"></param>
    /// <param name="version"></param>
    /// <param name="createDate"></param>
    public PersonInsuranceDataSentToGSBServiceSucceessfullyEvent(Guid aggregateRootId, int version, DateTime createDate) : base(Guid.NewGuid(), aggregateRootId, nameof(PersonInsuranceDataCoordinator), version, createDate)
    {
    }
}
//public sealed record PersonInsuranceDataSentToGSBServiceSucceessfullyEvent(Guid AggregateRootId, int Version, DateTime CreateDate) : Event(Guid.NewGuid(), AggregateRootId, nameof(PersonInsuranceDataCoordinator), Version, CreateDate);
