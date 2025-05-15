using Mapper.GSB.Domain.SeedWorks;
using MOHME.Lib.Shared;

namespace Mapper.GSB.Domain.Insurance
{
    /// <summary>
    /// رویداد زمانی ایجاد می شود که که اطلاعات فرد و بیمه نامه ثبت شود
    /// </summary>
    /// <param name="AggregateRootId"></param>
    /// <param name="MsgId"></param>
    /// <param name="Person"></param>
    /// <param name="PersonPolicy"></param>
    /// <param name="ServiceDateTime"></param>
    /// <param name="Version"></param>
    /// <param name="CreateDate"></param>
    public sealed record PersonInsuranceCreatedEvent(Guid AggregateRootId, MessageIdentifierVO MsgId, PersonInfoVO Person, PersonPolicyVO PersonPolicy, DO_DATE_TIME ServiceDateTime, int Version, DateTime CreateDate) : Event(Guid.NewGuid(), AggregateRootId, nameof(PersonInsurance), Version, CreateDate);
}
