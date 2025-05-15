using Mapper.GSB.Domain.Insurance;
using Mapper.GSB.Domain.SeedWorks;

namespace Mapper.GSB.Application.SeedWorks;

/// <summary>
/// دریافت اطلاعات رویداد های ثبت شده برای بیمه نامه و فرد 
/// </summary>
public interface IEventProvider
{
    /// <summary>
    /// دریافت اطلاعات یک رویداد با استفاده از شناسه رویداد
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    Task<Event?> Get(Guid Id);
    /// <summary>
    /// لیست تمامی رویداد های یک موجودیت به صورت صف
    /// </summary>
    /// <param name="AggregateId"></param>
    /// <returns></returns>
    Task<Queue<Event>?> GetByAggregateId(Guid AggregateId);
}
