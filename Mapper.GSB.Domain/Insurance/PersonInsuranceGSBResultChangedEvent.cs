using Mapper.GSB.Domain.SeedWorks;
using MOHME.Lib.Shared;

namespace Mapper.GSB.Domain.Insurance
{
    /// <summary>
    /// رویداد زمانی ایجاد می شود که که اطلاعات فرد و بیمه نامه ثبت شود
    /// </summary>
    /// <param name="AggregateRootId"></param>
    /// <param name="JsonStringifyResult"></param>
    /// <param name="Version"></param>
    /// <param name="GSBDataVO"></param>
    /// <param name="CreateDate"></param>
    /// <remarks>این رویداد نیاز به پابلیش کردن بر روی سف خاصی ندارد فقط یک رویداد برای مخزن ذخیره رویداد است</remarks>
    public sealed record PersonInsuranceGSBResultChangedEvent(Guid AggregateRootId, string JsonStringifyResult, GSBDataVO? GSBDataVO, int Version, DateTime CreateDate) : Event(Guid.NewGuid(), AggregateRootId, nameof(PersonInsurance), Version, CreateDate);
}
