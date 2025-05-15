using System.Collections.Immutable;

namespace Mapper.GSB.Domain.SeedWorks;

/// <summary>
/// مدل برای موجودیت های ریشه که از سیستم ثبت رویداد استفاده می کنند
/// </summary>
public abstract class EventSourcedAggregateRoot : AggregateRoot
{
    /// <summary>
    /// ایجاد موجودیت ریشه
    /// </summary>
    /// <param name="createDateTime"></param>
    protected EventSourcedAggregateRoot(DateTime? createDateTime) : base(createDateTime, Guid.NewGuid(), 0)
    {
    }
    /// <summary>
    /// ایجاد موجودیت با استفاده از رویداد ها
    /// </summary>
    /// <param name="historyEvents"></param>
    protected EventSourcedAggregateRoot(Queue<Event> historyEvents) : base(null, Guid.Empty, 0)
    {
        foreach (var @event in historyEvents)
        {
            Apply(@event);
            Version++;
        }
    }
    /// <summary>
    /// اضافه نمودن و اعمال رویداد مورد نظر به موجودیت و افزایش نسخه
    /// </summary>
    /// <param name="event"></param>
    protected override void AddEvent(Event @event)
    {
        Apply(@event);
        Version++;
        base.AddEvent(@event);
    }
    /// <summary>
    /// اعمال رویداد بر روی داده مورد نظر
    /// </summary>
    /// <param name="event"></param>
    private protected abstract void Apply(Event @event);
}
