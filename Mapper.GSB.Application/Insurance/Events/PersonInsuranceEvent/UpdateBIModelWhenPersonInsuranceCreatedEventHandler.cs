using Mapper.GSB.Application.SeedWorks;
using Mapper.GSB.Application.SeedWorks.BI;
using Mapper.GSB.Domain.Insurance;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Mapper.GSB.Application.Insurance.Events.PersonInsuranceEvent;

/// <summary>
/// درج اطلاعات در جدول
/// GSB.BI
/// </summary>
internal class UpdateBIModelWhenPersonInsuranceCreatedEventHandler : INotificationHandler<MediatREventAdapter<PersonInsuranceCreatedEvent>>
{
    private readonly ILogger<UpdateBIModelWhenPersonInsuranceCreatedEventHandler> logger;
    private readonly IBIStore bIStore;

    /// <summary>
    /// ایجاد سرویس ثبت اطلاعات
    /// BI
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="bIStore"></param>
    public UpdateBIModelWhenPersonInsuranceCreatedEventHandler(ILogger<UpdateBIModelWhenPersonInsuranceCreatedEventHandler> logger, IBIStore bIStore)
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
    public async Task Handle(MediatREventAdapter<PersonInsuranceCreatedEvent> notification, CancellationToken cancellationToken)
    {
        try
        {
            BIModel model = new(notification.Event.AggregateRootId, notification.Event.CreateDate, new Guid(notification.Event.MsgId.RegisterUID!),
                new Guid(notification.Event.MsgId.MessageUID!), Convert.ToInt32(notification.Event.PersonPolicy.Insurer.Coded_string!),
                notification.Event.PersonPolicy.PolicyUniqueCode, notification.Event.PersonPolicy.PolicyType!.Coded_string!,
                notification.Event.PersonPolicy.ProvinceBranch.Coded_string!, notification.Event.PersonPolicy.InsuredType, notification.Event.PersonPolicy.RelationType!.Value!,
                notification.Event.PersonPolicy.RelationType.Coded_string!, notification.Event.PersonPolicy.ResponsibleGender.Value!,
                notification.Event.PersonPolicy.ResponsibleGender.Coded_string!, notification.Event.PersonPolicy.InsuranceExpirationDate!.ToDateTime()!.Value,
                notification.Event.PersonPolicy.insurerNationalCode, notification.Event.PersonPolicy.IsCoverageUnlimited ? (byte)1 : (byte)0,
                notification.Event.Person.PersonId.Type!,
                notification.Event.Person.BirthDate.ToDateTime()!.Value, notification.Event.Person.MaritalStatus!.Coded_string!, notification.Event.Person.Nationality?.Value,
                notification.Event.Person.PersonId.ID!, null, null);
            if (notification.Event.MsgId.Version == 1)
                await bIStore.Insert(model).ConfigureAwait(false);
            else
                await bIStore.Update(model).ConfigureAwait(false);
        }
        catch (Exception Ex)
        {
            logger.LogError(Ex, $"UpdateBIModelWhenPersonInsuranceCreatedEventHandler - AggregateRootId = {notification.Event?.AggregateRootId} - AggregateRootName = {notification.Event?.AggregateRootName} - EventId =  {notification.Event?.Id}");
        }
    }
}
