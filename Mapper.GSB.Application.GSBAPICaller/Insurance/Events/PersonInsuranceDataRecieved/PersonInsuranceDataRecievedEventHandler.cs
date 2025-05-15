using Mapper.GSB.Application.GSBAPICaller.SeedWorks;
using Mapper.GSB.Application.GSBAPICaller.Serviecs.GSBService;
using Mapper.GSB.Application.GSBAPICaller.Serviecs.GSBService.ResponseBody;
using Mapper.GSB.Application.GSBAPICaller.Serviecs.GSBService.SendPerson;
using Mapper.GSB.Application.GSBAPICaller.Serviecs.GSBService.SendPerson.SendPersonInfo;
using Mapper.GSB.Application.GSBAPICaller.Serviecs.GSBService.SendPerson.SendPersonSupplimantryInfo;
using Mapper.GSB.Application.GSBAPICaller.Serviecs.GSBService.Token;
using Mapper.GSB.Application.SeedWorks;
using Mapper.GSB.Application.SeedWorks.Providers.PersonInsuranceProvider;
using Mapper.GSB.Domain.Insurance;
using Mapper.GSB.Domain.InsuranceDataCoordinator;
using Mapper.GSB.Domain.SeedWork;
using Mapper.GSB.Share.Resource;
using MassTransit;
using Microsoft.Extensions.Logging;
using MOHME.Lib.Shared;
using Services.ExceptionManager;
using Services.ExceptionManager.Resources;
using System.Collections.Generic;
using static Mapper.GSB.Application.Insurance.Events.PersonInsuranceEvent.PersonInsuranceEventHandlerHelper;

namespace Mapper.GSB.Application.GSBAPICaller.Insurance.Events.PersonInsuranceDataRecieved
{
    /// <summary>
    /// دریافت رویداد ثبت اطلاعات بیمه نامه و فرد جهت ارسال اطلاعات به سرور
    /// سازمان بیمه سلامت
    /// </summary>
    public class PersonInsuranceDataRecievedEventHandler : IConsumer<PersonInsuranceDataRecievedEvent>
    {
        private readonly IEventProvider eventProvider;
        private readonly IUnitOfWork unitOfWork;
        private readonly IPersonInsuranceRepository personInsuranceRepository;
        private readonly IPersonInsuranceDataCoordinatorRepository personInsuranceDataCoordinatorRepository;
        private readonly IPersonInsuranceDataCoordinatorProvider personInsuranceDataCoordinatorProvider;
        private readonly IGSBDataSenderService gSBDataSenderService;
        private readonly IGSBSendDataSettings gSBSendDataSetting;
        private readonly IGSBStatusDomainService gSBStatusDomainService;
        private readonly ILogger<PersonInsuranceDataRecievedEventHandler> logger;
        private readonly IStatesMapping statesMapping;

        /// <summary>
        /// دریافت سرویس های مورد نیاز جهت ارسال  اطلاعات به سازمان بیمه
        /// </summary>
        /// <param name="eventProvider"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="personInsuranceDataCoordinatorRepository"></param>
        /// <param name="gSBDataSenderService"></param>
        /// <param name="gSBSendDataSetting"></param>
        /// <param name="gSBStatusDomainService"></param>
        /// <param name="logger"></param>
        /// <param name="personInsuranceDataCoordinatorProvider"></param>
        /// <param name="personInsuranceRepository"></param>
        /// <param name="statesMapping"></param>
        public PersonInsuranceDataRecievedEventHandler(IEventProvider eventProvider, IUnitOfWork unitOfWork,
                                                       IPersonInsuranceRepository personInsuranceRepository,
                                                       IPersonInsuranceDataCoordinatorRepository personInsuranceDataCoordinatorRepository,
                                                       IPersonInsuranceDataCoordinatorProvider personInsuranceDataCoordinatorProvider,
                                                       IGSBDataSenderService gSBDataSenderService, IGSBSendDataSettings gSBSendDataSetting, IGSBStatusDomainService gSBStatusDomainService,
                                                       ILogger<PersonInsuranceDataRecievedEventHandler> logger,
                                                       IStatesMapping statesMapping)
        {
            this.eventProvider = eventProvider;
            this.unitOfWork = unitOfWork;
            this.personInsuranceRepository = personInsuranceRepository;
            this.personInsuranceDataCoordinatorRepository = personInsuranceDataCoordinatorRepository;
            this.personInsuranceDataCoordinatorProvider = personInsuranceDataCoordinatorProvider;
            this.gSBDataSenderService = gSBDataSenderService;
            this.gSBSendDataSetting = gSBSendDataSetting;
            this.gSBStatusDomainService = gSBStatusDomainService;
            this.logger = logger;
            this.statesMapping = statesMapping;
        }
        /// <summary>
        /// ارسال اطلاعات به سرور بیمه سلامت
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task Consume(ConsumeContext<PersonInsuranceDataRecievedEvent> context)
        {
            PersonInsuranceDataCoordinator? coordinatorEntity = null;
            bool allowToWrite = true;
            bool jobDoneSuccessfully = false;
            string jsonDataSendToGSBSrever = "";
            try
            {                
                Task[] tasks = new Task[2];
                var @event = (PersonInsuranceCreatedEvent?)await eventProvider.Get(context.Message.PersonInsuranceCreatedEventId);
                if (@event is null)
                    throw new ManualException(ExceptionsMessages.There_is_no_event_with_this_Id.Replace("{0}", nameof(PersonInsuranceDataRecievedEvent)).Replace("{1}", context.Message.PersonInsuranceCreatedEventId.ToString()), ExceptionType.NotFound, nameof(PersonInsuranceDataRecievedEvent));

                coordinatorEntity = await personInsuranceDataCoordinatorRepository.FindByIdAsync(context.Message.AggregateRootId);
                if (coordinatorEntity is null)
                    throw new ManualException(ExceptionsMessages.Data_is_not_found.Replace("{0}", Names.PersonInsuranceDataCoordinator).Replace("{1}", context.Message.AggregateRootId.ToString()), ExceptionType.NotFound, nameof(PersonInsuranceDataRecievedEvent));
                //اگر قبلا ارسال به بیمه سلامت انجام شده نباید دوباره بررسی و انجام شود
                
                if (coordinatorEntity.Status == InsuranceDataStatus.Recieved || coordinatorEntity.Status == InsuranceDataStatus.SentToGSBServiceIsUnSucceessful)
                {
                    //await IsValidToSendThisInsuranceToGSBServer(coordinatorEntity);
                    var tokenResult = await gSBDataSenderService.GetToken().ConfigureAwait(false);
                    //tokenResult = new ResultBodyDto<TokenResultDto>();
                    //tokenResult.Data = new TokenResultDto();
                    //tokenResult.Data.TokenID = "212222";
                    var sendDataResult = await SendData(@event, tokenResult).ConfigureAwait(false);
                    jsonDataSendToGSBSrever = sendDataResult.JsonStringSendData;
                    PersonInsurance personInsuranceEntity = GetPersonInsurance(@event);

                    //Just for test
                    //sendDataResult.GSBDataVO = new SendPersonResultDto()
                    //{
                    //    Igin = new DO_IDENTIFIER()
                    //    {
                    //        Assigner = "1",
                    //        ID = "2",
                    //        Issuer = "3",
                    //        Type = "4"
                    //    },
                    //    RecommandMessage = "asss",
                    //    RegisterDate = new DO_DATE_TIME()
                    //    {
                    //        Year = 2003,
                    //        Month = 3,
                    //        Day = 1,
                    //    },
                    //    RegisterID = coordinatorEntity.RegisterUID.ToString()
                    //};

                    gSBStatusDomainService.SaveStatus(coordinatorEntity, personInsuranceEntity, MapToGSBDataVO(sendDataResult.GSBDataVO), sendDataResult.JsonStringifyData);
                    await personInsuranceRepository.UpdateAsync(personInsuranceEntity).ConfigureAwait(false);
                    jobDoneSuccessfully = true;

                }
                else
                    allowToWrite = false;
            }
            catch (ManualException ex)
            {                
                logger.LogError(ex, ex.Message + $"[JsonDataSendToGSBSrever]={jsonDataSendToGSBSrever}"+ $"[ex.JsonStringifyData]={ex.JsonStringifyData}", ex.Code, ex.Type, ex.JsonStringifyData, jsonDataSendToGSBSrever);
                coordinatorEntity?.SetStatusGSBServiceIsUnSucceessful(ex.JsonStringifyData, new ErrorMessage("GSB - " + ex.Code, ex.Message));
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message + $"[JsonDataSendToGSBSrever]={jsonDataSendToGSBSrever}", jsonDataSendToGSBSrever);
                coordinatorEntity?.SetStatusGSBServiceIsUnSucceessful(null, new ErrorMessage("GSB - " + nameof(PersonInsuranceDataRecievedEventHandler) + "-" + "General exception", ex.Message));
                throw;
            }
            finally
            {
                if (coordinatorEntity is not null && allowToWrite)
                {
                    await unitOfWork.CommitAsync().ConfigureAwait(false);
                    if (jobDoneSuccessfully && coordinatorEntity.Version > 1)
                        await personInsuranceDataCoordinatorRepository.UpdateLowerVersionForGsb(coordinatorEntity.Version, coordinatorEntity.RegisterUID);
                }
            }
        }
        /// <summary>
        /// اگر نسخه قبلی وجود داشته باشد که به طور موفق برای سرور بیمه سلامت ارسال نشده موجودیت فعلی نباید اجرا شود 
        /// </summary>
        /// <param name="coordinatorEntity"></param>
        /// <returns></returns>
        private async Task IsValidToSendThisInsuranceToGSBServer(PersonInsuranceDataCoordinator coordinatorEntity)
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
                            if (prevCoordinator.Status == InsuranceDataStatus.Recieved || prevCoordinator.Status == InsuranceDataStatus.SentToGSBServiceIsUnSucceessful)
                                throw new ManualException(ExceptionsMessages.Cannot_send_data_to_server_due_to_lack_of_sending_data_of_prev_version_of_data.Replace("{0}", Names.PersonInsurance).Replace("{1}", "GSB").Replace("{2}", $"{prevCoordinator.Version}").Replace("{3}", $"{prevCoordinator.Id}"), ExceptionType.Conflict, nameof(PersonInsuranceDataRecievedEvent));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// مبدل جهت ایجاد مدل پاسخ درخواست برای ذخیره در سند بیمه
        /// </summary>
        /// <param name="sendDataResult"></param>
        /// <returns></returns>
        private static GSBDataVO MapToGSBDataVO(SendPersonResultDto sendDataResult)
        {
            return new GSBDataVO(sendDataResult.Igin, sendDataResult.RegisterID, sendDataResult.RecommandMessage, sendDataResult.RegisterDate);
        }
        /// <summary>
        /// ارسال اطلاعات برای سرور
        /// GSB
        /// جهت ثبت اطلاعات بیمه تکمیلی یا فول
        /// </summary>
        /// <param name="event"></param>
        /// <param name="tokenResult"></param>
        /// <returns></returns>
        private async Task<(SendPersonResultDto GSBDataVO, string JsonStringifyData, string JsonStringSendData)> SendData(PersonInsuranceCreatedEvent @event, RootResultDto<TokenResultDto> tokenResult)
        {
            string jsonStringSendData = "";
            // برای بیمه نامه درمان تکمیلی از مقدار SendPersonSupplimantryInfo  ( کد 1)
            if (@event.PersonPolicy.PolicyType.Coded_string == "1")
            {
                SendPersonSupplimantryInfoInputDto supData = PersonInsuranceDataRecievedMapper.MapToSendPersonSupplimantryInfoInputDto(@event, gSBSendDataSetting);
                (var supResult, jsonStringSendData) = await gSBDataSenderService.SendPersonSupplimantryInfo(supData, tokenResult.Result!.Data!.Data!.TokenID).ConfigureAwait(false);
                return (supResult.Result!.Data!.Data!, supResult.JsonStringifyData, jsonStringSendData);
            }
            // بیمه نامه فول درمان از مقدار SendPersonInfo (کد 2)
            else
            {
                SendPersonInfoInputDto fullData = PersonInsuranceDataRecievedMapper.MapToSendPersonInfoInputDto(@event, gSBSendDataSetting, statesMapping);
                (var fullResult, jsonStringSendData) = await gSBDataSenderService.SendPersonInfo(fullData, tokenResult.Result!.Data!.Data!.TokenID).ConfigureAwait(false);
                return (fullResult.Result!.Data!.Data!, fullResult.JsonStringifyData, jsonStringSendData);
            }
        }
    }

}
