using Mapper.GSB.Application.SeedWorks.BI;
using Mapper.GSB.Application.SeedWorks;
using Mapper.GSB.Domain.Insurance;
using Microsoft.Extensions.Logging;
using MediatR;
using Mapper.GSB.Application.Filter;
using Mapper.GSB.Application.FilterStore;

namespace Mapper.GSB.Application.GSBAPICaller.Insurance.Events.PersonInsuranceDataRecieved;

public class UpdateGSBDataForFilterWhenPersonInsuranceGSBResultChangedEventHandler : INotificationHandler<MediatREventAdapter<PersonInsuranceGSBResultChangedEvent>>
{
    private readonly ILogger<UpdateGSBDataForBIModelWhenPersonInsuranceGSBResultChangedEventHandler> logger;
    public readonly IFilterStore filterStore;
    private readonly IPersonAndPersonPolicyStore personAndPersonPolicyStore;

    /// <summary>
    /// ایجاد سرویس ثبت اطلاعات
    /// BI
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="bIStore"></param>
    public UpdateGSBDataForFilterWhenPersonInsuranceGSBResultChangedEventHandler(ILogger<UpdateGSBDataForBIModelWhenPersonInsuranceGSBResultChangedEventHandler> logger, IFilterStore filterStore, IPersonAndPersonPolicyStore personAndPersonPolicyStore)
    {
        this.logger = logger;
        this.filterStore = filterStore;
        this.personAndPersonPolicyStore = personAndPersonPolicyStore;
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
            await filterStore.UpdateGSB(notification.Event.AggregateRootId, notification.Event.GSBDataVO?.RegisterID, notification.Event.GSBDataVO?.RegisterDate?.ToDateTime());
            await personAndPersonPolicyStore.UpdateGSBPersonInfo(notification.Event.AggregateRootId, notification.Event.GSBDataVO?.RegisterDate?.ToDateTime());
            await personAndPersonPolicyStore.UpdateGSBPersonPolicyFields(notification.Event.AggregateRootId, notification.Event.GSBDataVO?.Igin?.ID, notification.Event.GSBDataVO?.RegisterID, notification.Event.GSBDataVO?.RegisterDate?.ToDateTime(), notification.Event.JsonStringifyResult);
        }
        catch (Exception Ex)
        {
            logger.LogError(Ex, $"UpdateGSBDataForBIModelWhenPersonInsuranceGSBResultChangedEventHandler - AggregateRootId = {notification.Event?.AggregateRootId} - AggregateRootName = {notification.Event?.AggregateRootName} - EventId =  {notification.Event?.Id}");
        }
    }

}
