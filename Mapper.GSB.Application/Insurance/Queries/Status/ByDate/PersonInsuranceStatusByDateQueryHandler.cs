using Mapper.GSB.Application.SeedWorks.Providers.PersonInsuranceProvider;
using Mapper.GSB.Domain.InsuranceDataCoordinator;
using Mapper.GSB.Share.Resource;
using MediatR;
using Services.Authorization;
using Services.ExceptionManager;
using Services.ExceptionManager.Resources;
using System.Globalization;

namespace Mapper.GSB.Application.Insurance.Queries.Status.ByDate
{
    /// <summary>
    /// بررسی وضعیت درخواست ثبت یا ویرایش اطلاعات بیمه شده و بیمه نام
    /// از طریق تاریخ
    /// </summary>
    public class PersonInsuranceStatusByDateQueryHandler : IRequestHandler<PersonInsuranceStatusByDateQuery, PagingDto<List<PersonInsuranceStatusDetailsDto>>>
    {
        private readonly IPersonInsuranceDataCoordinatorProvider personInsuranceDataCoordinatorProvider;
        private readonly IAuthorizationService authorizationService;

        /// <summary>
        /// دریافت سرویس مورد نیاز جهت بررسی وضعیت
        /// </summary>
        /// <param name="personInsuranceDataCoordinatorProvider"></param>
        /// <param name="authorizationService"></param>
        public PersonInsuranceStatusByDateQueryHandler(IPersonInsuranceDataCoordinatorProvider personInsuranceDataCoordinatorProvider, IAuthorizationService authorizationService)
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
        public async Task<PagingDto<List<PersonInsuranceStatusDetailsDto>>> Handle(PersonInsuranceStatusByDateQuery request, CancellationToken cancellationToken)
        {
            
            ValidateRequest(request);
            PersianCalendar pc = new();
            DateTime createdDate = pc.ToDateTime(request.Year, request.Month, request.Day, 23, 59, 59, 999);
            List<PersonInsuranceDataCoordinator> cordinators;

            //سطح دسترسی            
            int? InsurerId = null;
            //اگر بیمه مرکزی نبود باید فقط اطلاعات همان شرکت بیمه را نمایش دهد
            if (!await authorizationService.HasUserPermissionToReadAllData())
                InsurerId = authorizationService.GetOrganizationId();

            if (request.JustErrorStatus)
                cordinators = await personInsuranceDataCoordinatorProvider.FindInsurancesWhichEncountersErrorByCreatedDateAsync(createdDate, InsurerId);
            else
                cordinators = await personInsuranceDataCoordinatorProvider.FindByCreatedDateAsync(createdDate, InsurerId);
            
            if (cordinators?.Count > 0)
            {
                List<PersonInsuranceDataCoordinator> insurancerequestsWithError = GetLastError(cordinators).OrderByDescending(x => x.Version).ToList();
                PagingDto<List<PersonInsuranceStatusDetailsDto>> result = new()
                {
                    TotalCountOfRecords = insurancerequestsWithError.Count,
                    TotalPages = (int)Math.Ceiling((((double)insurancerequestsWithError.Count) / ((double)1000))),
                    Result = StatusMapper.MapToStatusDetails(insurancerequestsWithError.Skip(request.pageNumber * 1000).Take(1000).ToList()),
                    PageNumber = request.pageNumber
                };
                return result;
            }
            else
                throw new ManualException(ExceptionsMessages.Data_is_not_found.Replace("{0}", Names.PersonInsurance).Replace("{1}", $"{request.Year}/{request.Month}/{request.Day}"), ExceptionType.NotFound, nameof(PersonInsuranceStatusByDateQuery));
        }
        /// <summary>
        /// پیدا کردن آخرین رکورد هر بیمه نامه ای که با خطا روبرو شده است
        /// </summary>
        /// <param name="cordinators"></param>
        /// <returns></returns>
        private List<PersonInsuranceDataCoordinator> GetLastError(List<PersonInsuranceDataCoordinator> cordinators)
        {            
            List<PersonInsuranceDataCoordinator> results = new();

            var supplementaries = cordinators.Where(x => x.PolicyType?.Coded_string == "1")?.GroupBy(x => new { x.InsurerId, x.PersonId, x.PersonIdType, x.PolicyUniqueCode }).ToList();
            if (supplementaries?.Count > 0)
            {
                foreach (var supplementary in supplementaries)
                {
                    var max = supplementary.MaxBy(x => x.Version);
                    if (max is not null)
                        results.Add(max);
                }
            }
            var fullInsurances = cordinators.Where(x => x.PolicyType?.Coded_string == "2")?.GroupBy(x => new { x.InsurerId, x.PersonId, x.PersonIdType, x.AccountID }).ToList();
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
        private static void ValidateRequest(PersonInsuranceStatusByDateQuery request)
        {
            if (request is null)
                throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonInsuranceStatusByDateQuery).Replace("{1}", Names.RegisterDateInDataHub), ExceptionType.InValid, nameof(PersonInsuranceStatusByDateQuery));
            if (request.Year == 0)
                throw new ManualException(ExceptionsMessages.Data_is_not_valid_Value_is_wrong.Replace("{0}", Names.PersonInsuranceStatusByDateQuery).Replace("{1}", Names.Year), ExceptionType.InValid, nameof(PersonInsuranceStatusByDateQuery));
            if (request.Month < 1 || request.Month > 12)
                throw new ManualException(ExceptionsMessages.Data_is_not_valid_Value_is_wrong.Replace("{0}", Names.PersonInsuranceStatusByDateQuery).Replace("{1}", Names.Month), ExceptionType.InValid, nameof(PersonInsuranceStatusByDateQuery));
            if (request.Day < 1 || request.Day > 31)
                throw new ManualException(ExceptionsMessages.Data_is_not_valid_Value_is_wrong.Replace("{0}", Names.PersonInsuranceStatusByDateQuery).Replace("{1}", Names.Day), ExceptionType.InValid, nameof(PersonInsuranceStatusByDateQuery));
        }       
    }
}
