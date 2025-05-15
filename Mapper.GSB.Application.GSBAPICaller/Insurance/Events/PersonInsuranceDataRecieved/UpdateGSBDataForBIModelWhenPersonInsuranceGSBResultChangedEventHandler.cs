using Mapper.GSB.Application.SeedWorks.BI;
using Mapper.GSB.Application.SeedWorks;
using Mapper.GSB.Domain.Insurance;
using Microsoft.Extensions.Logging;
using MediatR;

namespace Mapper.GSB.Application.GSBAPICaller.Insurance.Events.PersonInsuranceDataRecieved;

public class UpdateGSBDataForBIModelWhenPersonInsuranceGSBResultChangedEventHandler : INotificationHandler<MediatREventAdapter<PersonInsuranceGSBResultChangedEvent>>
{
    private readonly ILogger<UpdateGSBDataForBIModelWhenPersonInsuranceGSBResultChangedEventHandler> logger;
    private readonly IBIStore bIStore;

    /// <summary>
    /// ایجاد سرویس ثبت اطلاعات
    /// BI
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="bIStore"></param>
    public UpdateGSBDataForBIModelWhenPersonInsuranceGSBResultChangedEventHandler(ILogger<UpdateGSBDataForBIModelWhenPersonInsuranceGSBResultChangedEventHandler> logger, IBIStore bIStore)
    {
        this.logger = logger;
        this.bIStore = bIStore;
    }
    /// <summary>
    /// درج اطلاعات در مدل
    /// GSB.BI
    /// </summary>
    /// <param name="notification"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task Handle(MediatREventAdapter<PersonInsuranceGSBResultChangedEvent> notification, CancellationToken cancellationToken)
    {
        try
        {
            await bIStore.UpdateGSB(notification.Event.AggregateRootId, notification.Event.GSBDataVO?.RegisterDate?.ToDateTime());
        }
        catch (Exception Ex)
        {
            logger.LogError(Ex, $"UpdateGSBDataForBIModelWhenPersonInsuranceGSBResultChangedEventHandler - AggregateRootId = {notification.Event?.AggregateRootId} - AggregateRootName = {notification.Event?.AggregateRootName} - EventId =  {notification.Event?.Id}");
        }
    }

}
