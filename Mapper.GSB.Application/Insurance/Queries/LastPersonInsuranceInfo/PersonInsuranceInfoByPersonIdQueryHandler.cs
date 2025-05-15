using Mapper.GSB.Application.Insurance.Queries.LastPersonInsuranceInfo;
using Mapper.GSB.Application.Insurance.Queries.Status.ByRegisterUID;
using Mapper.GSB.Application.SeedWorks.Providers.PersonInsuranceProvider;
using Mapper.GSB.Domain.InsuranceDataCoordinator;
using Mapper.GSB.Share.Helper;
using Mapper.GSB.Share.Resource;
using MediatR;
using Services.Authorization;
using Services.ExceptionManager;
using Services.ExceptionManager.Resources;

namespace Mapper.GSB.Application.Insurance.Queries.Status.ByDate
{
    /// <summary>
    /// دریافت خلاصه اطلاعات وضعیت بیمه نامه بر اساس شناسه فرد
    /// </summary>
    public class PersonInsuranceInfoByPersonIdQueryHandler : IRequestHandler<PersonInsuranceInfoByPersonIdQuery, List<PersonInsuranceInfoDto>>
    {
        private readonly IPersonInsuranceDataCoordinatorProvider personInsuranceDataCoordinatorProvider;
        private readonly IAuthorizationService authorizationService;

        /// <summary>
        /// دریافت سرویس مورد نیاز جهت بررسی وضعیت
        /// </summary>
        /// <param name="personInsuranceDataCoordinatorProvider"></param>
        /// <param name="authorizationService"></param>
        public PersonInsuranceInfoByPersonIdQueryHandler(IPersonInsuranceDataCoordinatorProvider personInsuranceDataCoordinatorProvider, IAuthorizationService authorizationService)
        {
            this.personInsuranceDataCoordinatorProvider = personInsuranceDataCoordinatorProvider;
            this.authorizationService = authorizationService;
        }
        /// <summary>
        /// بررسی وضعیت درخواست ثبت یا ویرایش اطلاعات بیمه شده و بیمه نام
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<PersonInsuranceInfoDto>> Handle(PersonInsuranceInfoByPersonIdQuery request, CancellationToken cancellationToken)
        {
            
            ValidateRequest(request);
            //دسترسی فقط برای بیمه مرکزی            
            if (!await authorizationService.HasUserPermissionToReadAllData())
                throw new ManualException(ExceptionsMessages.USER_IS_NOT_AUTHORIZED_TO_DO.Replace("{0}", Names.RELATED_ORGANIZATION_DATA).Replace("{1}", Names.FOR_READ), ExceptionType.Forbidden, nameof(Names.Authorization));

            List<PersonInsuranceDataCoordinator> cordinators;
            cordinators = await personInsuranceDataCoordinatorProvider.FindByPersonIdAndPersonTypeAsync(request.Id, request.Type);
            cordinators = cordinators.Where(x => x.PersonIdentifier?.Issuer?.Trim() == request.Issuer.Trim() && x.PersonIdentifier?.Assigner?.Trim() == request.Assigner.Trim()).ToList();
            if (cordinators?.Count > 0)
            {
                List<PersonInsuranceDataCoordinator> lastinsurances;
                //فقط آخرین سند از هر نمونه بیمه نامه
                if (request.JustLast)
                    lastinsurances = GetLast(cordinators);
                //تمامی بیمه نامه ها در تمامی نسخه ها
                else
                    lastinsurances = cordinators;

                List<PersonInsuranceInfoDto> results = new();
                foreach (var lastinsurance in lastinsurances)
                {
                    results.Add(new PersonInsuranceInfoDto()
                    {
                        AccountID = lastinsurance.AccountID,
                        InsuranceExpirationDate = lastinsurance.InsuranceExpirationDate,
                        Insurer  = lastinsurance.Insurer,
                        PolicyType = lastinsurance.PolicyType,
                        PolicyUniqueCode = lastinsurance.PolicyUniqueCode,
                        RegisterUID = lastinsurance.RegisterUID.ToString(),
                        Status = StatusMapper.MapToStatus(lastinsurance.Status),
                        StatusMessage = StatusMapper.MapToStatus(lastinsurance.Status).GetDisplayName(),
                        CompanyInsuredId = lastinsurance.CompanyInsuredId,
                        CompanyPolicyId  = lastinsurance.CompanyPolicyId,
                    });
                }
                return results;
            }
            else
                throw new ManualException(ExceptionsMessages.Data_is_not_found.Replace("{0}", Names.PersonInsurance).Replace("{1}", $"{request.Id},{request.Issuer},{request.Assigner},{request.Type}"), ExceptionType.NotFound, nameof(PersonInsuranceInfoByPersonIdQuery));
        }
        /// <summary>
        /// پیدا کردن آخرین رکورد هر بیمه نامه ای که با خطا روبرو شده است
        /// </summary>
        /// <param name="cordinators"></param>
        /// <returns></returns>
        private List<PersonInsuranceDataCoordinator> GetLast(List<PersonInsuranceDataCoordinator> cordinators)
        {
            List<PersonInsuranceDataCoordinator> results = new();

            var supplementaries = cordinators.Where(x => x.PolicyType?.Coded_string == "1")?.GroupBy(x => new { x.InsurerId, x.PolicyUniqueCode }).ToList();
            if (supplementaries?.Count > 0)
            {                
                foreach (var supplementary in supplementaries)
                {
                    var max = supplementary.MaxBy(x => x.Version);
                    if (max is not null)
                        results.Add(max);
                }
            }
            var fullInsurances = cordinators.Where(x => x.PolicyType?.Coded_string == "2")?.GroupBy(x => new { x.InsurerId, x.AccountID }).ToList();
            if (fullInsurances?.Count > 0)
            {
                foreach (var fullInsurance in fullInsurances)
                {
                    var max = fullInsurance.MaxBy(x => x.Version);
                    if (max is not null)
                        results.Add(max);
                }
            }

            return results;
        }
        /// <summary>
        /// بررسی صحت درخواست
        /// </summary>
        /// <param name="request"></param>
        /// <exception cref="ManualException"></exception>
        private static void ValidateRequest(PersonInsuranceInfoByPersonIdQuery request)
        {
            if (request is null)
                throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonInsuranceInfoByPersonIdQuery).Replace("{1}", Names.PersonInfoVO_PersonID), ExceptionType.InValid, nameof(PersonInsuranceInfoByPersonIdQuery));
            if (string.IsNullOrWhiteSpace(request.Id))
                throw new ManualException(ExceptionsMessages.Data_is_not_valid_Value_is_wrong.Replace("{0}", Names.PersonInsuranceInfoByPersonIdQuery).Replace("{1}", Names.Id), ExceptionType.InValid, nameof(PersonInsuranceInfoByPersonIdQuery));
            if (string.IsNullOrWhiteSpace(request.Issuer))
                throw new ManualException(ExceptionsMessages.Data_is_not_valid_Value_is_wrong.Replace("{0}", Names.PersonInsuranceInfoByPersonIdQuery).Replace("{1}", Names.Issuer), ExceptionType.InValid, nameof(PersonInsuranceInfoByPersonIdQuery));
            if (string.IsNullOrWhiteSpace(request.Assigner))
                throw new ManualException(ExceptionsMessages.Data_is_not_valid_Value_is_wrong.Replace("{0}", Names.PersonInsuranceInfoByPersonIdQuery).Replace("{1}", Names.Assigner), ExceptionType.InValid, nameof(PersonInsuranceInfoByPersonIdQuery));
            if (string.IsNullOrWhiteSpace(request.Type))
                throw new ManualException(ExceptionsMessages.Data_is_not_valid_Value_is_wrong.Replace("{0}", Names.PersonInsuranceInfoByPersonIdQuery).Replace("{1}", Names.IdType), ExceptionType.InValid, nameof(PersonInsuranceInfoByPersonIdQuery));
        }
    }
}
