using Mapper.GSB.Domain.Insurance;
using Mapper.GSB.Domain.SeedWorks;
using Mapper.GSB.Infrastructure.Data;
using Mapper.GSB.Infrastructure.MessageDispatcher;
using System.Collections.Immutable;
using System.Text.Json;

namespace Mapper.GSB.Infrastructure.EventStore
{
    /// <summary>
    /// <see cref="IEventStore"/>
    /// </summary>
    internal class EventStore : IEventStore
    {
        private readonly IDbSet dbSet;
        private readonly MessageDispatcherFactory messageDispatcherFactory;

        public EventStore(IDbSet dbSet, MessageDispatcherFactory messageDispatcherFactory)
        {
            this.dbSet = dbSet;
            this.messageDispatcherFactory = messageDispatcherFactory;
        }
        /// <summary>
        /// <see cref="Save(Queue{Event})"/>
        /// </summary>
        /// <param name="domainEvents"></param>
        /// <exception cref="NotImplementedException"></exception>
        public async Task SaveAsync(ImmutableQueue<Event> domainEvents)
        {            
            Random rnd = new();
            int correlationId = rnd.Next(1, Int32.MaxValue);
            while (!domainEvents.IsEmpty)
            {                
                var domainEvent = domainEvents.Peek();
                if (domainEvent is not null)
                {
                    EventModel? eventModel = null;
                    switch (domainEvent)
                    {
                        case PersonInsuranceCreatedEvent prsInsCrtEv:
                            string dataCrt = JsonSerializer.Serialize(prsInsCrtEv);
                            eventModel = new(prsInsCrtEv.Id, nameof(PersonInsuranceCreatedEvent), prsInsCrtEv.AggregateRootId, prsInsCrtEv.AggregateRootName, prsInsCrtEv.Version, correlationId, dataCrt, domainEvent.CreateDate);
                            break;
                        case PersonInsuranceGSBResultChangedEvent prsInsGSBRstChEv:
                            string dataGSB = JsonSerializer.Serialize(prsInsGSBRstChEv);
                            eventModel = new(prsInsGSBRstChEv.Id, nameof(PersonInsuranceGSBResultChangedEvent), prsInsGSBRstChEv.AggregateRootId, prsInsGSBRstChEv.AggregateRootName, prsInsGSBRstChEv.Version, correlationId, dataGSB, domainEvent.CreateDate);
                            break;
                    }
                    if (eventModel is not null)
                        await dbSet.Get<EventModel>()!.AddAsync(eventModel).ConfigureAwait(false);
                    
                    if (domainEvent is PersonInsuranceCreatedEvent pEvent)
                        await messageDispatcherFactory.GetDispatcher(MessageDispatcherType.Internal).Publish(pEvent);
                    
                    if (domainEvent is PersonInsuranceGSBResultChangedEvent gEvent)
                        await messageDispatcherFactory.GetDispatcher(MessageDispatcherType.Internal).Publish(gEvent);
                }
                domainEvents = domainEvents.Dequeue();
            }
        }
        
    }
}
