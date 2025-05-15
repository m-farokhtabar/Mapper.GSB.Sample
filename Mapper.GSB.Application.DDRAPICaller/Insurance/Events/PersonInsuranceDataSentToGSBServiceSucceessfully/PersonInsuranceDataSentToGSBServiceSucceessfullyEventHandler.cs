using Mapper.GSB.Application.DDRAPICaller.Services.DDR;
using Mapper.GSB.Application.Filter;
using Mapper.GSB.Application.FilterStore;
using Mapper.GSB.Application.SeedWorks;
using Mapper.GSB.Application.SeedWorks.Providers.PersonInsuranceProvider;
using Mapper.GSB.Domain.Insurance;
using Mapper.GSB.Domain.InsuranceDataCoordinator;
using Mapper.GSB.Domain.SeedWork;
using Mapper.GSB.Domain.SeedWorks;
using Mapper.GSB.Share.Resource;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using openEHR.Library.Base.BaseTypes.Identification;
using Services.ExceptionManager;
using Services.ExceptionManager.Resources;
using static Mapper.GSB.Application.Insurance.Events.PersonInsuranceEvent.PersonInsuranceEventHandlerHelper;

namespace Mapper.GSB.Application.DDRAPICaller.Insurance.Events.PersonInsuranceEvent.PersonInsuranceDataSentToGSBServiceSucceessfully
{
    /// <summary>
    /// دریافت رویداد ثبت سرویس در
    /// GSB
    /// و اعمال عملیات جدید که ثبت آن در
    /// DDR
    /// </summary>
    public class PersonInsuranceDataSentToGSBServiceSucceessfullyEventHandler : IConsumer<PersonInsuranceDataSentToGSBServiceSucceessfullyEvent>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPersonInsuranceDataCoordinatorRepository personInsuranceDataCoordinatorRepository;
        private readonly IPersonInsuranceDataCoordinatorProvider personInsuranceDataCoordinatorProvider;
        private readonly IEventProvider eventProvider;
        private readonly IDDRService dDRService;
        private readonly ILogger<PersonInsuranceDataSentToGSBServiceSucceessfullyEventHandler> logger;
        private readonly IFilterStore filterStore;
        private readonly IPersonAndPersonPolicyStore personAndPersonPolicyStore;

        /// <summary>
        /// دریافت رویداد ثبت سرویس در
        /// GSB
        /// و اعمال عملیات جدید که ثبت آن در
        /// DDR
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="personInsuranceDataCoordinatorRepository"></param>
        /// <param name="personInsuranceDataCoordinatorProvider"></param>
        /// <param name="eventProvider"></param>
        /// <param name="dDRService"></param>
        /// <param name="logger"></param>
        public PersonInsuranceDataSentToGSBServiceSucceessfullyEventHandler(IUnitOfWork unitOfWork,
                                                                            IPersonInsuranceDataCoordinatorRepository personInsuranceDataCoordinatorRepository,
                                                                            IPersonInsuranceDataCoordinatorProvider personInsuranceDataCoordinatorProvider,
                                                                            IEventProvider eventProvider,
                                                                            IDDRService dDRService,
                                                                            ILogger<PersonInsuranceDataSentToGSBServiceSucceessfullyEventHandler> logger,
                                                                            IFilterStore filterStore,
                                                                            IPersonAndPersonPolicyStore personAndPersonPolicyStore)
        {
            this.unitOfWork = unitOfWork;
            this.personInsuranceDataCoordinatorRepository = personInsuranceDataCoordinatorRepository;
            this.personInsuranceDataCoordinatorProvider = personInsuranceDataCoordinatorProvider;
            this.eventProvider = eventProvider;
            this.dDRService = dDRService;
            this.logger = logger;
            this.filterStore = filterStore;
            this.personAndPersonPolicyStore = personAndPersonPolicyStore;
        }
        /// <summary>
        /// ارسال اطلاعات جهت ثبت در سرویس
        /// DDR
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task Consume(ConsumeContext<PersonInsuranceDataSentToGSBServiceSucceessfullyEvent> context)
        {
            PersonInsuranceDataCoordinator? coordinatorEntity = null;
            ObjectVersionId? partyRelationshipVersionId;
            ObjectVersionId? partyVersionId;
            PersonInsurance personInsuranceEntity;
            bool allowToWrite = true;
            try
            {
                coordinatorEntity = await personInsuranceDataCoordinatorRepository.FindByIdAsync(context.Message.AggregateRootId);
                coordinatorEntity = coordinatorEntity ?? throw new ManualException(ExceptionsMessages.Data_is_not_found.Replace("{0}", Names.PersonInsuranceDataCoordinator).Replace("{1}", context.Message.AggregateRootId.ToString()), ExceptionType.NotFound, nameof(PersonInsuranceDataSentToGSBServiceSucceessfullyEvent));
                //اگر قبلا ثبت شده در ریپو نباید دوباره بررسی و انجام شود
                if (coordinatorEntity.Status == InsuranceDataStatus.SentToGSBServiceIsSucceessful ||
                    coordinatorEntity.Status == InsuranceDataStatus.SavePersonInopenEHRRepositoryIsUnSucceessful ||
                    coordinatorEntity.Status == InsuranceDataStatus.SavePersonInopenEHRRepositoryIsSucceessful ||
                    coordinatorEntity.Status == InsuranceDataStatus.SaveInsurnaceDataInopenEHRRepositoryIsUnSucceessful)
                {
                    await IsValidToSendThisInsuranceToDDRServer(coordinatorEntity);
                    (Queue<Domain.SeedWorks.Event> events, partyVersionId, partyRelationshipVersionId) = await GetData(context.Message, coordinatorEntity).ConfigureAwait(false);
                    
                    personInsuranceEntity = GetPersonInsurance(events);

                    ObjectVersionId newPartyId;
                    //در صورتی که شخصی برای این رکورد قبلا ثبت شده نباید دوباره درخواست ثبت داده شود
                    if (string.IsNullOrWhiteSpace(coordinatorEntity.openEHRPartyId))
                        newPartyId = await SavePersonData(coordinatorEntity, partyVersionId, personInsuranceEntity).ConfigureAwait(false);
                    else
                        newPartyId = new ObjectVersionId(coordinatorEntity.openEHRPartyId);
                    await SaveInsuranceData(coordinatorEntity, newPartyId, partyRelationshipVersionId, personInsuranceEntity).ConfigureAwait(false);
                }
                else
                    allowToWrite = false;
            }
            catch (ManualException ex)
            {
                logger.LogError(ex, ex.Message, ex.Code, ex.Type, ex.JsonStringifyData);
                coordinatorEntity?.SetStatusSavePersonInopenEHRRepositoryIsUnSucceessful(new ErrorMessage(ex.Code, ex.Message));
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                coordinatorEntity?.SetStatusSavePersonInopenEHRRepositoryIsUnSucceessful(new ErrorMessage(nameof(PersonInsuranceDataSentToGSBServiceSucceessfullyEvent) + "-" + "General exception", ex.Message));
                throw;
            }
            finally
            {
                if (allowToWrite)
                    await unitOfWork.CommitAsync().ConfigureAwait(false);
            }
        }
        /// <summary>
        /// ثبت اطلاعات بیمه شونده در
        /// DDR
        /// </summary>
        /// <param name="coordinatorEntity"></param>
        /// <param name="partyId"></param>
        /// <param name="personInsuranceEntity"></param>
        /// <returns></returns>
        private async Task<ObjectVersionId> SavePersonData(PersonInsuranceDataCoordinator coordinatorEntity, ObjectVersionId? partyId, PersonInsurance personInsuranceEntity)
        {
            ObjectVersionId newPartyId;
            try
            {
                newPartyId = await dDRService.SavePatient(personInsuranceEntity, partyId).ConfigureAwait(false);
                coordinatorEntity.SetStatusSavePersonInopenEHRRepositoryIsSucceessful(newPartyId.Value);
                try
                {
                    await filterStore.UpdateopenEHRPartyId(coordinatorEntity.Id, newPartyId.Value);
                    await personAndPersonPolicyStore.UpdateopenEHRPartyIdPersonInfo(coordinatorEntity.Id, newPartyId.Value);
                }
                catch(Exception Ex)
                {
                    logger.LogError(Ex, $"filterStore.UpdateopenEHRPartyId or personAndPersonPolicyStore.UpdateopenEHRPartyIdPersonInfo - AggregateRootId = {coordinatorEntity.Id}");
                }
            }
            catch (ManualException ex)
            {
                logger.LogError(ex, ex.Message + $" - AggregateId[{coordinatorEntity.Id}]", ex.Code, ex.Type, ex.JsonStringifyData);
                coordinatorEntity.SetStatusSaveInsurnaceDataInopenEHRRepositoryIsUnSucceessful(new ErrorMessage(ex.Code, ex.Message));
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message + $" - AggregateId[{coordinatorEntity.Id}]");
                coordinatorEntity.SetStatusSaveInsurnaceDataInopenEHRRepositoryIsUnSucceessful(new ErrorMessage(nameof(PersonInsuranceDataSentToGSBServiceSucceessfullyEvent) + "-" + "General exception", ex.Message));
                throw;
            }
            finally
            {
                await unitOfWork.CommitAsync().ConfigureAwait(false);
            }
            return newPartyId;
        }
        /// <summary>
        /// ثبت اطلاعات بیمه در
        /// DDR
        /// </summary>
        /// <param name="coordinatorEntity"></param>
        /// <param name="newPartyId"></param>
        /// <param name="partyRelationshipVersionId"></param>
        /// <param name="personInsuranceEntity"></param>
        /// <returns></returns>
        private async Task SaveInsuranceData(PersonInsuranceDataCoordinator coordinatorEntity, ObjectVersionId newPartyId, ObjectVersionId? partyRelationshipVersionId, PersonInsurance personInsuranceEntity)
        {
            try
            {
                ObjectVersionId newPartyRelationshipId = await dDRService.SaveCompositon(personInsuranceEntity, newPartyId.Root().Value, partyRelationshipVersionId).ConfigureAwait(false);
                coordinatorEntity.SetStatusDone(newPartyRelationshipId.Value);
                try
                {
                    await filterStore.UpdateopenEHRDocId(coordinatorEntity.Id, newPartyRelationshipId.Value);
                    await personAndPersonPolicyStore.UpdateopenEHRDocIdPersonInfo(coordinatorEntity.Id, newPartyRelationshipId.Value);
                }
                catch (Exception Ex)
                {
                    logger.LogError(Ex, $"filterStore.UpdateopenEHRDocId or personAndPersonPolicyStore.UpdateopenEHRDocIdPersonInfo - AggregateRootId = {coordinatorEntity.Id}");
                }
            }
            catch (ManualException ex)
            {
                logger.LogError(ex, ex.Message + $" - AggregateId[{coordinatorEntity.Id}]", ex.Code, ex.Type, ex.JsonStringifyData);
                coordinatorEntity.SetStatusSaveInsurnaceDataInopenEHRRepositoryIsUnSucceessful(new ErrorMessage(ex.Code, ex.Message));
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message + $" - AggregateId[{coordinatorEntity.Id}]");
                coordinatorEntity.SetStatusSaveInsurnaceDataInopenEHRRepositoryIsUnSucceessful(new ErrorMessage(nameof(PersonInsuranceDataSentToGSBServiceSucceessfullyEvent) + "-" + "General exception", ex.Message));
                throw;
            }
            finally
            {
                await unitOfWork.CommitAsync().ConfigureAwait(false);
            }
        }
        /// <summary>
        /// دریافت اطلاعات رویدادها و داده های 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        /// <exception cref="ManualException"></exception>
        private async Task<(Queue<Domain.SeedWorks.Event> events, ObjectVersionId? partyVersionId, ObjectVersionId? partyRelationshipVersionId)> GetData(PersonInsuranceDataSentToGSBServiceSucceessfullyEvent message, PersonInsuranceDataCoordinator coordinatorEntity)
        {
            Queue<Domain.SeedWorks.Event> events = await eventProvider.GetByAggregateId(message.AggregateRootId) ?? throw new ManualException(ExceptionsMessages.There_is_no_event_with_this_Id.Replace("{0}", nameof(PersonInsuranceDataSentToGSBServiceSucceessfullyEventHandler)).Replace("{1}", coordinatorEntity.PersonInsuranceCreatedEventId.ToString()), ExceptionType.NotFound, nameof(PersonInsuranceDataSentToGSBServiceSucceessfullyEventHandler));
            List<PersonInsuranceIdentifiersDto> identifiersByPersonId = await personInsuranceDataCoordinatorProvider.FindIdentifiersByPersonIdAsync(coordinatorEntity.PersonId);
            List<PersonInsuranceIdentifiersDto> identifiersByRegisterUID = await personInsuranceDataCoordinatorProvider.FindIdentifiersAtLeastHasSavePersonInopenEHRSuccessfulStatusByRegisterUIDAsync(coordinatorEntity.RegisterUID);

            (ObjectVersionId? partyVersionId, ObjectVersionId? partyRelationshipVersionId) = GetLastopenEHRIds(coordinatorEntity, identifiersByPersonId, identifiersByRegisterUID);
            return (events, partyVersionId, partyRelationshipVersionId);
        }
        /// <summary>
        /// دریافت اطلاعات 
        /// </summary>
        /// <param name="coordinatorEntity"></param>
        /// <param name="identifiersByPersonId"></param>
        /// <param name="identifiersByRegisterUID"></param>
        /// <returns></returns>
        private (ObjectVersionId? partyVersionId, ObjectVersionId? partyRelationshipVersionId) GetLastopenEHRIds(PersonInsuranceDataCoordinator coordinatorEntity, List<PersonInsuranceIdentifiersDto> identifiersByPersonId, List<PersonInsuranceIdentifiersDto> identifiersByRegisterUID)
        {
            List<PersonInsuranceIdentifiersDto> Allidentifiers = new();
            if (identifiersByPersonId?.Count > 0)
                Allidentifiers.AddRange(identifiersByPersonId);
            if (identifiersByRegisterUID?.Count > 0)
                Allidentifiers.AddRange(identifiersByRegisterUID);
            Allidentifiers = Allidentifiers.DistinctBy(x => x.Id).ToList();

            ObjectVersionId? partyVersionId = Allidentifiers.Where(x => x.Id != coordinatorEntity.Id && x.PersonIdType == coordinatorEntity.PersonIdType && !string.IsNullOrWhiteSpace(x.openEHRPartyId)).Select(x =>
            {
                try
                {
                    return new ObjectVersionId(x.openEHRPartyId);
                }
                catch
                {
                    return null;
                }
            }).Where(x => !string.IsNullOrWhiteSpace(x?.VersionTreeId()?.TrunkVersion())).ToList().MaxBy(x => x!.VersionTreeId().TrunkVersion());
            //اگر شناسه رجیستر یکسان باشد یعنی سند یکسان است
            ObjectVersionId? partyRelationshipVersionId = Allidentifiers.Where(x => x.Id != coordinatorEntity.Id && x.RegisterUID == coordinatorEntity.RegisterUID && x.Status == InsuranceDataStatus.Done && !string.IsNullOrWhiteSpace(x.openEHRPartyRelationshipId)).Select(x =>
            {
                try
                {
                    return new ObjectVersionId(x.openEHRPartyRelationshipId);
                }
                catch
                {
                    return null;
                }
            }).Where(x => !string.IsNullOrWhiteSpace(x?.VersionTreeId()?.TrunkVersion())).MaxBy(x => x!.VersionTreeId().TrunkVersion());

            return (partyVersionId, partyRelationshipVersionId);
        }

        /// <summary>
        /// اگر نسخه قبلی وجود داشته باشد که به طور موفق برای سرور ریپو ارسال نشده باشد موجودیت فعلی نباید اجرا شود 
        /// </summary>
        /// <param name="coordinatorEntity"></param>
        /// <returns></returns>
        private async Task IsValidToSendThisInsuranceToDDRServer(PersonInsuranceDataCoordinator coordinatorEntity)
        {
            if (coordinatorEntity.Version > 1)
            {
                var prevCoordinatorsEntity = await personInsuranceDataCoordinatorProvider.FindByRegisterUIDAsync(coordinatorEntity.RegisterUID);
                if (prevCoordinatorsEntity?.Count > 1)
                {
                    var prevCoordinatorsEntitiesWithoutCurrent = prevCoordinatorsEntity.Where(x => x.Version < coordinatorEntity.Version)?.ToList();
                    if (prevCoordinatorsEntitiesWithoutCurrent?.Count > 0)
                    {
                        foreach (var prevCoordinator in prevCoordinatorsEntitiesWithoutCurrent)
                        {
                            if (prevCoordinator.Status != InsuranceDataStatus.Done)
                                throw new ManualException(ExceptionsMessages.Cannot_send_data_to_server_due_to_lack_of_sending_data_of_prev_version_of_data.Replace("{0}", Names.PersonInsurance).Replace("{1}", "DDR").Replace("{2}", $"{prevCoordinator.Version}").Replace("{3}", $"{prevCoordinator.Id}"), ExceptionType.Conflict, nameof(PersonInsuranceDataSentToGSBServiceSucceessfullyEvent));
                        }
                    }
                }
            }
        }

    }
}
