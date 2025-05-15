using Mapper.GSB.Application.Filter;
using Mapper.GSB.Application.FilterStore;
using Mapper.GSB.Application.SeedWorks;
using Mapper.GSB.Domain.Insurance;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Mapper.GSB.Application.Insurance.Events.PersonInsuranceEvent;

/// <summary>
/// درج اطلاعات در جدول
/// GSB.BI
/// </summary>
internal class UpdateFilterWhenPersonInsuranceCreatedEventHandler : INotificationHandler<MediatREventAdapter<PersonInsuranceCreatedEvent>>
{
    private readonly ILogger<UpdateFilterWhenPersonInsuranceCreatedEventHandler> logger;
    private readonly IPersonAndPersonPolicyStore personAndPersonPolicyStore;
    private readonly IFilterStore filterStore;    

    /// <summary>
    /// ایجاد سرویس ثبت اطلاعات
    /// BI
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="filterStore"></param>
    /// <param name="personAndPersonPolicyStore"></param>
    public UpdateFilterWhenPersonInsuranceCreatedEventHandler(ILogger<UpdateFilterWhenPersonInsuranceCreatedEventHandler> logger, IPersonAndPersonPolicyStore personAndPersonPolicyStore, IFilterStore filterStore)
    {
        this.logger = logger;
        this.personAndPersonPolicyStore = personAndPersonPolicyStore;
        this.filterStore = filterStore;        
    }
    /// <summary>
    /// درج اطلاعات در مدل
    /// GSB.BI
    /// </summary>
    /// <param name="notification"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task Handle(MediatREventAdapter<PersonInsuranceCreatedEvent> notification, CancellationToken cancellationToken)
    {
        try
        {
            await filterStore.Insert(notification.Event);
            await personAndPersonPolicyStore.InsertPersonInfo(notification.Event);
            await personAndPersonPolicyStore.InsertPersonPolicy(notification.Event);
        }
        catch (Exception Ex)
        {
            logger.LogError(Ex, $"UpdateFilterWhenPersonInsuranceCreatedEventHandler - AggregateRootId = {notification.Event?.AggregateRootId} - AggregateRootName = {notification.Event?.AggregateRootName} - EventId =  {notification.Event?.Id}");
        }
    }
}
