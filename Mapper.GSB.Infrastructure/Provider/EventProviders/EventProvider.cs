using Mapper.GSB.Application.SeedWorks;
using Mapper.GSB.Domain.SeedWorks;
using Mapper.GSB.Infrastructure.Data;
using Mapper.GSB.Infrastructure.EventStore;
using Microsoft.EntityFrameworkCore;

namespace Mapper.GSB.Infrastructure.Provider.EventProviders;
/// <summary>
/// <see cref="IEventProvider"/>
/// </summary>
internal class EventProvider : IEventProvider
{
    private readonly IDbSet dbSet;

    public EventProvider(IDbSet dbSet)
    {
        this.dbSet = dbSet;
    }
    /// <summary>
    /// <see cref="IEventProvider.Get(Guid)"/>
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<Event?> Get(Guid Id)
    {
        var model = await dbSet.Get<EventModel>()!.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id).ConfigureAwait(false);
        return model != null ? EventFactory.GetEvent(model.Name, model.Data) : null;
    }
    /// <summary>
    /// <see cref="IEventProvider.GetByAggregateId(Guid)"/>
    /// </summary>
    /// <param name="AggregateId"></param>
    /// <returns></returns>
    public async Task<Queue<Event>?> GetByAggregateId(Guid AggregateId)
    {
        Queue<Event>? qEvents = null;
        var events = await dbSet.Get<EventModel>()!.AsNoTracking().Where(x => x.AggregateId == AggregateId).ToListAsync().ConfigureAwait(false);
        if (events?.Count > 0)
        {
            qEvents = new Queue<Event>();
            foreach (var @event in events.OrderBy(x => x.Version))
            {
                if (@event is not null)
                {
                    var createdEvent = EventFactory.GetEvent(@event.Name, @event.Data);
                    if (createdEvent is not null)
                        qEvents.Enqueue(createdEvent);
                }
            }
        }
        return qEvents;
    }
}
