using MediatR;
using Mapper.GSB.Domain.Insurance;
using Mapper.GSB.Domain.SeedWork;
using Services.ExceptionManager.Resources;
using Services.ExceptionManager;
using Mapper.GSB.Application.SeedWorks.Providers.PersonInsuranceProvider;
using Mapper.GSB.Share.Resource;
using MOHME.Lib.Shared;
using Mapper.GSB.Application.SeedWorks;
using System.Net;
using Services.Authorization;
using Microsoft.Extensions.Logging;

namespace Mapper.GSB.Application.Insurance.Commands.Save
{
    /// <summary>
    /// ثبت اطلاعات فردی و بیمه نامه
    /// </summary>
    internal class SavePersonInsuranceCommandHandler : IRequestHandler<SavePersonInsuranceCommand, DataVO>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPersonInsuranceRepository personInsuranceRepository;
        private readonly IPersonInsuranceDataCoordinatorProvider personInsuranceDataCoordinatorProvider;
        private readonly IInsuranceCompaniesIds insuranceCompaniesIds;
        private readonly IAuthorizationService authorizationService;
        private readonly ILogger<SavePersonInsuranceCommandHandler> logger;

        /// <summary>
        /// دریافت سرویس های مورد نیاز جهت انجلم عملیات
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="personInsuranceRepository"></param>
        /// <param name="personInsuranceDataCoordinatorProvider"></param>
        /// <param name="insuranceCompaniesIds"></param>
        /// <param name="authorizationService"></param>
        /// <param name="logger"></param>
        public SavePersonInsuranceCommandHandler(IUnitOfWork unitOfWork, IPersonInsuranceRepository personInsuranceRepository,
                                                 IPersonInsuranceDataCoordinatorProvider personInsuranceDataCoordinatorProvider,
                                                 IInsuranceCompaniesIds insuranceCompaniesIds, IAuthorizationService authorizationService, ILogger<SavePersonInsuranceCommandHandler> logger)
        {
            this.unitOfWork = unitOfWork;
            this.personInsuranceRepository = personInsuranceRepository;
            this.personInsuranceDataCoordinatorProvider = personInsuranceDataCoordinatorProvider;
            this.insuranceCompaniesIds = insuranceCompaniesIds;
            this.authorizationService = authorizationService;
            this.logger = logger;
        }
        /// <summary>
        /// عملیات ثبت اطلاعات فردی و بیمه نامه
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<DataVO> Handle(SavePersonInsuranceCommand request, CancellationToken cancellationToken)
        {
            //TODO: بررسی اینکه وقتی دو تا کد ملی یکسان پشت سر هم میاد باید چه کار انجام داد
            DataVO result;
            List<PersonInsuranceSaveIdentifiersDto>? cordinators = null;
            //کاربری شرکت بیمه ارسال کننده در توکن الزاما با مقدار id مکسا شرکت بیمه برابر باشد. Authentication
            await AuthorizedWriteData(request);

            ValidateDate(request);

            PersonPolicyVO newPersonPolicy = MapToDomain.MapToPersonPolicy(request.PersonPolicy!);
            PersonInfoVO newPerson = MapToDomain.MapToPerson(request.Person!);


            PersonInsurance entity;
            int operation;
            cordinators = await GetCordinators(request);

            //به روز رسانی
            if (cordinators?.Count > 0)
            {
                var lastCordinator = cordinators.MaxBy(x => x.Version);

                var msgId = request.MsgId!;
                operation = (int)Mapper.GSB.Domain.InsuranceDataCoordinator.Operation.Update;
                MessageIdentifierVO newMsgId = MapToDomain.MapToMessageIdentifier(request.MsgId!, false, lastCordinator!.RegisterUID.ToString(), request.MessageUID.ToString(), lastCordinator!.Version + 1);
                entity = new(newMsgId, newPerson, newPersonPolicy, request.ServiceDateTime, false);
            }
            //درج
            else
            {
                MessageIdentifierVO newMsgId = MapToDomain.MapToMessageIdentifier(request.MsgId!, true, null, request.MessageUID.ToString(), request.MsgId!.Version);
                operation = (int)Mapper.GSB.Domain.InsuranceDataCoordinator.Operation.Insert;
                entity = new(newMsgId, newPerson, newPersonPolicy, request.ServiceDateTime, true);
            }
            await personInsuranceRepository.AddAsync(entity).ConfigureAwait(false);
            await unitOfWork.CommitAsync(cancellationToken).ConfigureAwait(false);

            result = DataVO.MaptoDataVo(entity, operation);
            return result;
        }
        /// <summary>
        /// بررسی سطح دسترسی به داده
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="ManualException"></exception>
        private async Task AuthorizedWriteData(SavePersonInsuranceCommand request)
        {
            if (!Int32.TryParse(request.PersonPolicy?.Insurer?.Coded_string, out int InsurerId))
                throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonPolicyVO).Replace("{1}", Names.PersonPolicyVO_Insurer), ExceptionType.InValid, nameof(SavePersonInsuranceCommand.PersonPolicy) + "." + nameof(SavePersonInsuranceCommand.PersonPolicy.Insurer) + "." + nameof(SavePersonInsuranceCommand.PersonPolicy.Insurer.Coded_string));

            //یعنی اگه ریشه یا سازمان بیمه مرکزی نبود
            if (!await authorizationService.HasUserPermissionToWriteAllData())
            {
                int UserOrganizationId = authorizationService.GetOrganizationId();
                if (UserOrganizationId != InsurerId)
                    throw new ManualException(ExceptionsMessages.USER_IS_NOT_AUTHORIZED_TO_DO.Replace("{0}", Names.RELATED_ORGANIZATION_DATA).Replace("{1}", Names.FOR_WRITE), ExceptionType.Forbidden, nameof(Names.Authorization));
                await authorizationService.HasUserPermissionToWriteDataOfThisOrganization(InsurerId);
            }
        }


        /// <summary>
        /// دریافت اطلاعات بیمه نامه و بیمه شده اگر قبلا در سیستم ثبت شده باشند
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="ManualException"></exception>
        private async Task<List<PersonInsuranceSaveIdentifiersDto>> GetCordinators(SavePersonInsuranceCommand request)
        {
            List<PersonInsuranceSaveIdentifiersDto> cordinators;
            Int32.TryParse(request.PersonPolicy?.Insurer?.Coded_string, out int insurerId);
            //برای بیمه نامه درمان تکمیلی کد یک
            if (request.PersonPolicy!.PolicyType!.Coded_string == "1")
                cordinators = await personInsuranceDataCoordinatorProvider.FindByPersonIdAndInsurerIdAndPolicyUniqueCodeAsync(request.Person!.PersonId!.ID!.Trim(), insurerId, request.PersonPolicy!.PolicyUniqueCode!.Trim());
            //برای بیمه نامه فول درمان کد دو
            else if (request.PersonPolicy!.PolicyType!.Coded_string == "2")
                cordinators = await personInsuranceDataCoordinatorProvider.FindByPersonIdAndInsurerIdAndAccountIdAsync(request.Person!.PersonId!.ID!.Trim(), insurerId, request.PersonPolicy!.Account![0].AccountID!.Trim());
            else
                throw new ManualException(ExceptionsMessages.Data_is_not_valid_Value_is_wrong.Replace("{0}", Names.PersonPolicyVO).Replace("{1}", Names.PersonPolicyVO_PolicyType), ExceptionType.InValid, nameof(SavePersonInsuranceCommand));
            return cordinators;
        }

        /// <summary>
        /// بررسی صحت داده هایی که قرار است در شرط وجود یا عدم وجود بیمه نامه استفاده شود
        /// </summary>
        private void ValidateDate(SavePersonInsuranceCommand request)
        {
            if (request is null)
                throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonInfoVO + "، " + Names.PersonPolicyVO).Replace("{1}", Names.PersonInfoVO + "، " + Names.PersonPolicyVO), ExceptionType.InValid, nameof(SavePersonInsuranceCommand));
            if (request.PersonPolicy is null)
                throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonPolicyVO).Replace("{1}", Names.PersonPolicyVO), ExceptionType.InValid, nameof(SavePersonInsuranceCommand.PersonPolicy));

            if (request.MsgId is null)
                throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.MessageIdentifierVO).Replace("{1}", Names.MessageIdentifierVO), ExceptionType.InValid, nameof(SavePersonInsuranceCommand.MsgId));
            if (string.IsNullOrWhiteSpace(request.PersonPolicy?.PolicyUniqueCode))
                throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonPolicyVO).Replace("{1}", Names.PersonPolicyVO_PolicyUnqiueCode), ExceptionType.InValid, nameof(SavePersonInsuranceCommand.PersonPolicy) + "." + nameof(SavePersonInsuranceCommand.PersonPolicy.PolicyUniqueCode));
            if (string.IsNullOrWhiteSpace(request.Person?.PersonId?.ID))
                throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonInfoVO).Replace("{1}", Names.PersonInfoVO_PersonID), ExceptionType.InValid, nameof(SavePersonInsuranceCommand.Person) + "." + nameof(SavePersonInsuranceCommand.Person.PersonId));
            if (!Int32.TryParse(request.PersonPolicy?.Insurer?.Coded_string, out int insurerId))
                throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonPolicyVO).Replace("{1}", Names.PersonPolicyVO_Insurer), ExceptionType.InValid, nameof(SavePersonInsuranceCommand.PersonPolicy) + "." + nameof(SavePersonInsuranceCommand.PersonPolicy.Insurer));
            if (string.IsNullOrWhiteSpace(request.PersonPolicy?.PolicyType?.Coded_string))
                throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonPolicyVO).Replace("{1}", Names.PersonPolicyVO_PolicyType), ExceptionType.InValid, nameof(SavePersonInsuranceCommand.PersonPolicy) + "." + nameof(SavePersonInsuranceCommand.PersonPolicy.PolicyType));

            //در حالت فول درمان بایستی حتما کد صندوق را داشته باشیم
            if (request.PersonPolicy!.PolicyType!.Coded_string == "2")
            {
                if (request.PersonPolicy?.Account is null || request.PersonPolicy.Account.Count == 0)
                    throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonPolicyVO).Replace("{1}", Names.PersonPolicyVO_Account), ExceptionType.InValid, nameof(SavePersonInsuranceCommand.PersonPolicy) + "." + nameof(SavePersonInsuranceCommand.PersonPolicy.Account));
                if (string.IsNullOrWhiteSpace(request.PersonPolicy?.Account[0].AccountID))
                    throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.AccountVO).Replace("{1}", Names.AccountVO_AccountID), ExceptionType.InValid, nameof(SavePersonInsuranceCommand.PersonPolicy) + "." + nameof(SavePersonInsuranceCommand.PersonPolicy.Account) + ".AccountId");
            }
            if (request.MsgId!.SystemID is null || !insuranceCompaniesIds.InsuranceCompaniesIds!.ContainsKey(request.MsgId!.SystemID.ID!.ToLower()))
                throw new ManualException(ExceptionsMessages.Data_is_not_valid_Value_is_wrong.Replace("{0}", Names.PersonInfoVO + "، " + Names.PersonPolicyVO).Replace("{1}", Names.MessageIdentifierVO_SystemID), ExceptionType.InValid, nameof(SavePersonInsuranceCommand.MsgId) + "." + nameof(SavePersonInsuranceCommand.MsgId.SystemID));
            if (request.PersonPolicy.InsuredType is null)
                throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonPolicyVO).Replace("{1}", Names.PersonPolicyVO_InsuredType), ExceptionType.InValid, nameof(SavePersonInsuranceCommand.PersonPolicy) + "." + nameof(SavePersonInsuranceCommand.PersonPolicy.InsuredType));

            if (request.PersonPolicy.IsCoverageUnlimited is null)
                throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonPolicyVO).Replace("{1}", Names.PersonPolicyVO_IsCoverageUnlimited), ExceptionType.InValid, nameof(SavePersonInsuranceCommand.PersonPolicy) + "." + nameof(SavePersonInsuranceCommand.PersonPolicy.IsCoverageUnlimited));
        }
    }
}
