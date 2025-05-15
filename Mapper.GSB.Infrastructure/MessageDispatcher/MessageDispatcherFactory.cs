using Mapper.GSB.Domain.Insurance;
using Mapper.GSB.Domain.InsuranceDataCoordinator;
using Mapper.GSB.Domain.SeedWorks;
using MassTransit;
using Microsoft.Extensions.Logging;
namespace Mapper.GSB.Infrastructure.MessageDispatcher;

/// <summary>
/// این کلاس مشخص می کنند بر اساس رویداد باید از چه نوع پابلیشری باید استفاده کنیم
/// <list type="bullet">
/// <para>RabbitMQ</para>
/// <para>Internal</para>
/// </list>
/// </summary>
internal class MessageDispatcherFactory
{
    private readonly MediatR.IMediator mediator;
    private readonly IPublishEndpoint publishEndpoint;
    private readonly ILogger<MassTranistMessageDispatcher> massTransitLogger;
    /// <summary>
    /// سرویس های پیش نیاز مورد نظر جهت ایجاد سرویس های ارسال پیام
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="publishEndpoint"></param>
    /// <param name="massTransitLogger"></param>
    public MessageDispatcherFactory(MediatR.IMediator mediator, IPublishEndpoint publishEndpoint, ILogger<MassTranistMessageDispatcher> massTransitLogger)
    {
        this.mediator = mediator;
        this.publishEndpoint = publishEndpoint;
        this.massTransitLogger = massTransitLogger;
    }
    /// <summary>
    /// ایجاد ارسال کننده پیام بر اساس نوع انتخابی
    /// </summary>
    /// <param name="type"></param>
    public IMessageDispatcher GetDispatcher(MessageDispatcherType type)
    {
        return type switch
        {
            MessageDispatcherType.Internal => new MediatorMessageDispatcher(mediator),
            MessageDispatcherType.External => new MassTranistMessageDispatcher(publishEndpoint, massTransitLogger),
            _ => new MediatorMessageDispatcher(mediator),
        };
    }
}
