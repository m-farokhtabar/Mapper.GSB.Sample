using Mapper.GSB.Infrastructure.EventStore;
using MassTransit.Futures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mapper.GSB.Infrastructure.Data.Config
{
    /// <summary>
    /// تنظیمات جدول مربوط به مدل مورد نظر
    /// </summary>
    internal class EventModelConfig : IEntityTypeConfiguration<EventModel>
    {
        /// <summary>
        /// تنظیمات جدول
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<EventModel> builder)
        {
            builder.ToTable("Event");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.AggregateId).IsRequired();
            builder.Property(x => x.AggregateName).HasMaxLength(60).IsRequired();
            builder.Property(x => x.Version).IsRequired();
            builder.Property(x => x.CorrelationId).IsRequired();
            builder.Property(x => x.Data).IsRequired();
            builder.Property(x => x.CreatedDate).IsRequired();

            builder.HasIndex(x => x.AggregateId);
        }
    }
}
