using Mapper.GSB.Application.SeedWorks;
using Mapper.GSB.Domain.Insurance;
using Mapper.GSB.Domain.InsuranceDataCoordinator;
using Mapper.GSB.Domain.SeedWork;
using MediatR;

namespace Mapper.GSB.Application.Insurance.Events.PersonInsuranceEvent
{
    /// <summary>
    /// عملیات های مورد نیاز پس از اعلان ایجاد موجودیت بیمه نامه فرد
    /// </summary>
    internal class PersonInsuranceCreatedEventHandler : INotificationHandler<MediatREventAdapter<PersonInsuranceCreatedEvent>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPersonInsuranceDataCoordinatorRepository personInsuranceDataCoordinatorRepository;

        /// <summary>
        /// دریافت سرویس های مورد نیاز جهت انجلم عملیات
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="personInsuranceDataCoordinatorRepository"></param>
        public PersonInsuranceCreatedEventHandler(IUnitOfWork unitOfWork, IPersonInsuranceDataCoordinatorRepository personInsuranceDataCoordinatorRepository)
        {
            this.unitOfWork = unitOfWork;
            this.personInsuranceDataCoordinatorRepository = personInsuranceDataCoordinatorRepository;
        }
        /// <summary>
        /// ثبت اطلاعات جدول هماهنگ کننده داده های بیمه نامه فرد
        /// </summary>
        /// <param name="notification"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task Handle(MediatREventAdapter<PersonInsuranceCreatedEvent> notification, CancellationToken cancellationToken)
        {
            string? accountId =  null;
            //TODO: ممکن چندین شناسه اکانت داشته باشیم بعدا برای این مورد باید فکری کرد                     
            if (notification.Event.PersonPolicy.Account?.Count > 0)
                accountId = notification.Event.PersonPolicy.Account[0].AccountID;

            PersonInsuranceDataCoordinator entity = new(notification.Event.AggregateRootId, notification.Event.MsgId.Version, notification.Event.CreateDate, notification.Event.MsgId.PatientUID, notification.Event.MsgId.CompositionUID,
                                                        notification.Event.MsgId.RegisterUID!, notification.Event.MsgId.MessageUID!, notification.Event.Person.PersonId,
                                                        notification.Event.PersonPolicy.PolicyUniqueCode, notification.Event.PersonPolicy.CompanyInsuredId, notification.Event.PersonPolicy.CompanyPolicyId, null, notification.Event.MsgId.LocalId, notification.Event.Id, 
                                                        notification.Event.PersonPolicy.Insurer, notification.Event.PersonPolicy.InsuranceExpirationDate, accountId, notification.Event.PersonPolicy.PolicyType);
            await personInsuranceDataCoordinatorRepository.AddAsync(entity).ConfigureAwait(false);
            await unitOfWork.CommitAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
