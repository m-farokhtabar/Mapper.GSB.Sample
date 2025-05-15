using System.Collections.Immutable;

namespace Mapper.GSB.Domain.SeedWorks;

/// <summary>
/// مدل برای موجودیت های ریشه
/// </summary>
public abstract class AggregateRoot : Entity
{
    /// <summary>
    /// فقط جهت
    /// entityframework
    /// </summary>
    private protected AggregateRoot()
    {

    }
    /// <summary>
    /// ایجاد موجودیت ریشه
    /// </summary>
    /// <param name="createDate">تاریخ ایجاد</param>
    /// <param name="id"></param>
    /// <param name="version"></param>
    protected AggregateRoot(DateTime? createDate, Guid id, int version) : base(createDate)
    {
        Id = id;
        Version = version;
    }
    /// <summary>
    /// شناسه موجودیت
    /// </summary>
    public Guid Id { get; protected set; }
    /// <summary>
    /// شماره نسخه
    /// </summary>
    public int Version { get; protected set; }
    /// <summary>
    /// لیست رویداد های ایجاد شده مربوط به موجودیت ریشه
    /// </summary>
    private readonly Queue<Event> events = new();
    /// <summary>
    /// لیست رویداد های ایجاد شده مربوط به موجودیت ریشه
    /// </summary>
    public ImmutableQueue<Event> Events => ImmutableQueue.Create(events.ToArray());
    /// <summary>
    /// اضافه نمودن رویداد مورد نظر به موجودیت
    /// </summary>
    /// <param name="event"></param>
    protected virtual void AddEvent(Event @event) => events.Enqueue(@event);
    /// <summary>
    /// پاک کردن رویداد ها
    /// </summary>
    public void ClearEvents() => events.Clear();
}
