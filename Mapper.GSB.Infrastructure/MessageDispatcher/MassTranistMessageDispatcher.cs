using Mapper.GSB.Domain.SeedWorks;
using Services.ExceptionManager.Resources;
using MassTransit;
using Microsoft.Extensions.Logging;
using Mapper.GSB.Domain.InsuranceDataCoordinator;
using Mapper.GSB.Application.SeedWorks;

namespace Mapper.GSB.Infrastructure.MessageDispatcher
{
    /// <summary>
    /// ارسال پیام از طریق کتابخانه
    /// Masstranist
    /// به
    /// RabbitMQ
    /// </summary>
    internal class MassTranistMessageDispatcher : IMessageDispatcher, IExternalMessageDispatcher
    {
        private readonly IPublishEndpoint publishEndpoint;
        private readonly ILogger<MassTranistMessageDispatcher> logger;
        //IPublishEndpoint
        public MassTranistMessageDispatcher(IPublishEndpoint publishEndpoint, ILogger<MassTranistMessageDispatcher> logger)
        {
            this.publishEndpoint = publishEndpoint;
            this.logger = logger;
        }

        /// <summary>
        /// <see cref="IMessageDispatcher.Publish{T}(T)"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="event"></param>
        /// <returns></returns>
        public async Task Publish<T>(T @event) where T : Mapper.GSB.Domain.SeedWorks.Event
        {
            for (var i = 0; i < 3; i++)
            {
                try
                {                    
                    await Task.Run(() =>
                    {
                        int delayInMiliSecond = (i * (int)Math.Pow(10, i));
                        Thread.Sleep(i * delayInMiliSecond);
                        publishEndpoint.Publish<T>(@event).ConfigureAwait(false);
                    });
                    break;
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, ExceptionsMessages.Cannot_Sent_Event_to_RabbitMQ.Replace("{0}", @event.GetType().FullName + " - Id=" + @event.Id + " - Version = " + @event.Version + " - AggregateRootId = " + @event.AggregateRootId));
                }
            }
        }
    }
}
