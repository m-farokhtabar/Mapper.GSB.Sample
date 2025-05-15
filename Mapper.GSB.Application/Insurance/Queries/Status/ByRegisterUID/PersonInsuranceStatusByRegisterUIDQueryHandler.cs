using Mapper.GSB.Application.SeedWorks.Providers.PersonInsuranceProvider;
using Mapper.GSB.Share.Resource;
using MediatR;
using Services.Authorization;
using Services.ExceptionManager;
using Services.ExceptionManager.Resources;

namespace Mapper.GSB.Application.Insurance.Queries.Status.ByRegisterUID
{
    /// <summary>
    /// بررسی وضعیت درخواست ثبت یا ویرایش اطلاعات بیمه شده و بیمه نام
    /// </summary>
    public class PersonInsuranceStatusByRegisterUIDQueryHandler : IRequestHandler<PersonInsuranceStatusByRegisterUIDQuery, PersonInsuranceStatusDto>
    {
        private readonly IPersonInsuranceDataCoordinatorProvider personInsuranceDataCoordinatorProvider;
        private readonly IAuthorizationService authorizationService;

        /// <summary>
        /// دریافت سرویس مورد نیاز جهت بررسی وضعیت
        /// </summary>
        /// <param name="personInsuranceDataCoordinatorProvider"></param>
        /// <param name="authorizationService"></param>
        public PersonInsuranceStatusByRegisterUIDQueryHandler(IPersonInsuranceDataCoordinatorProvider personInsuranceDataCoordinatorProvider, IAuthorizationService authorizationService)
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
        public async Task<PersonInsuranceStatusDto> Handle(PersonInsuranceStatusByRegisterUIDQuery request, CancellationToken cancellationToken)
        {            
            if (request is null)
                throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonInsuranceStatusByRegisterUIDQuery).Replace("{1}", Names.MessageIdentifierVO_RegisterUID), ExceptionType.InValid, nameof(PersonInsuranceInfoByPersonIdQuery));

            var cordinators = await personInsuranceDataCoordinatorProvider.FindByRegisterUIDAsync(request.RegisterUID);
            
            if (cordinators?.Count > 0)
            {
                //سطح دسترسی            
                int? InsurerId = null;
                //اگر بیمه مرکزی نبود باید فقط اطلاعات همان شرکت بیمه را نمایش دهد
                if (!await authorizationService.HasUserPermissionToReadAllData())
                    InsurerId = authorizationService.GetOrganizationId();
                if (InsurerId is not null)
                    cordinators = cordinators.Where(x => x.InsurerId == InsurerId).ToList();
                
                //این قسمت باید چک شود که اگر با شرط بیمه هم خوانی دارد جواب نمایش داده شود
                if (cordinators?.Count > 0)
                {
                    return new PersonInsuranceStatusDto()
                    {
                        RegisterUID = request.RegisterUID,
                        Results = StatusMapper.MapToStatusDetails(cordinators.OrderByDescending(x => x.Version).ToList())
                    };
                }
                else
                    throw new ManualException(ExceptionsMessages.USER_IS_NOT_AUTHORIZED_TO_DO.Replace("{0}", Names.RELATED_ORGANIZATION_DATA).Replace("{1}", Names.FOR_READ), ExceptionType.Forbidden, nameof(Names.Authorization));
            }
            else
                throw new ManualException(ExceptionsMessages.Data_is_not_found.Replace("{0}", Names.PersonInsurance).Replace("{1}", request.RegisterUID.ToString()), ExceptionType.NotFound, nameof(PersonInsuranceStatusByRegisterUIDQuery));
        }
    }
}
