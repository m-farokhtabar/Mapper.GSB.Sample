namespace Mapper.GSB.Domain.SeedWorks
{
    /// <summary>
    /// کلاس پایه رویداد ها
    /// </summary>
    /// <remarks>
    /// به خاطر
    /// Masstransit
    /// حتما باید سازنده خالی داشته باشیم و از مدل تعریف خلاصه نمی توان استفاده کرد
    /// </remarks>
    public abstract record Event
    {
        /// <summary>
        /// به خاطر
        /// Masstransit
        /// </summary>
        protected Event() { }
        /// <summary>
        /// سازنده اصلی
        /// </summary>
        /// <param name="id"></param>
        /// <param name="aggregateRootId"></param>
        /// <param name="aggregateRootName"></param>
        /// <param name="version"></param>
        /// <param name="createDate"></param>
        protected Event(Guid id, Guid aggregateRootId, string aggregateRootName, int version, DateTime createDate)
        {
            Id = id;
            AggregateRootId = aggregateRootId;
            AggregateRootName = aggregateRootName;
            Version = version;
            CreateDate = createDate;
        }

        /// <summary>
        /// شناسه رویداد
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// شناسه موجودیت ریشه
        /// </summary>
        public Guid AggregateRootId { get; set; }
        /// <summary>
        /// نام موجودیت ریشه
        /// </summary>
        public string AggregateRootName { get; set; } = string.Empty;
        /// <summary>
        /// نسخه
        /// </summary>
        public int Version { get; set; }
        /// <summary>
        /// تاریخ ایجاد رویداد
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}
