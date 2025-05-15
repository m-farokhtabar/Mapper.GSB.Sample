namespace Mapper.GSB.Infrastructure.EventStore;

/// <summary>
/// مدل جهت نگهداری داده های رویداد
/// </summary>
public class EventModel
{
    /// <summary>
    /// ایجاد مدل رویداد جهت ثبت
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="aggregateId"></param>
    /// <param name="aggregateName"></param>
    /// <param name="version"></param>
    /// <param name="correlationId"></param>
    /// <param name="data"></param>
    /// <param name="createdDate"></param>
    public EventModel(Guid id, string name, Guid aggregateId, string aggregateName, int version, int correlationId, string data, DateTime createdDate)
    {
        Id = id;
        Name = name;
        AggregateId = aggregateId;
        AggregateName = aggregateName;
        Version = version;
        CorrelationId = correlationId;
        Data = data;
        CreatedDate = createdDate;
    }
    /// <summary>
    /// شناسه رویداد
    /// </summary>
    public Guid Id { get; private set; }
    /// <summary>
    /// نام رویداد
    /// </summary>
    public string Name { get; private set; }
    /// <summary>
    /// شناسه موجودیت ریشه
    /// </summary>
    public Guid AggregateId { get; private set; }
    /// <summary>
    /// نام موجویت
    /// </summary>
    public string AggregateName { get; private set; }
    /// <summary>
    /// نسخه موجودیت
    /// </summary>
    public int Version { get; private set; }
    /// <summary>
    /// شناسه هماهنگی
    /// </summary>
    public int CorrelationId { get; private set; }
    /// <summary>
    /// داده های رویداد
    /// </summary>
    public string Data { get; private set; }
    /// <summary>
    /// تاریخ ایجاد
    /// </summary>
    public DateTime CreatedDate { get; private set; }
}
