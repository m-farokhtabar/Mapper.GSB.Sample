using Mapper.GSB.Application.SeedWorks;
using Mapper.GSB.Domain.SeedWorks;
using MediatR;

namespace Mapper.GSB.Infrastructure.MessageDispatcher;

/// <summary>
/// ارسال ییام از طریق 
/// Mediator
/// </summary>
public class MediatorMessageDispatcher : IMessageDispatcher
{
    private readonly IMediator dispatcher;
    /// <summary>
    /// سرویس های مورد نیاز
    /// </summary>
    /// <param name="dispatcher"></param>
    public MediatorMessageDispatcher(IMediator dispatcher)
    {
        this.dispatcher = dispatcher;
    }

    /// <summary>
    /// <see cref="IMessageDispatcher.Publish{T}(T)"/>
    /// </summary>
    /// <param name="event"></param>
    /// <returns></returns>
    public async Task Publish<T>(T @event) where T : Event
    {
        await dispatcher.Publish(new MediatREventAdapter<T> (@event));
    }
}
