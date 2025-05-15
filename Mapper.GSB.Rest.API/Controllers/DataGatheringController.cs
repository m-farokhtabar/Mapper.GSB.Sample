using Mapper.GSB.Rest.API.ViewModels.SendPersonPolicyInfo;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mapper.GSB.Application.Insurance.Commands.Save;
using Mapper.GSB.Application.Insurance.Queries.Status;
using Microsoft.AspNetCore.Authorization;
using Asp.Versioning;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Filters;
using Mapper.GSB.Rest.API.Helpers.SwaggerExamples;
using Mapper.GSB.Rest.API.Helpers;
using Services.ExceptionManager;
using Services.ExceptionManager.Resources;
using Mapper.GSB.Share.Resource;
using Mapper.GSB.Rest.API.ViewModels.Response;
using Mapper.GSB.Application.Insurance.Queries.Status.ByRegisterUID;
using Mapper.GSB.Application.Insurance.Queries;
using Mapper.GSB.Application.Insurance.Queries.LastPersonInsuranceInfo;
namespace Mapper.GSB.Rest.API.Controllers
{
    /// <summary>
    /// مدیریت اطلاعات بیمه نامه و بیمه شونده - فول درمان و تکمیلی
    /// </summary>
    [ApiVersion("1.0")]
    [Authorize]
    public class DataGatheringController : BaseController
    {
        private readonly IMediator mediator;
        private readonly ILogger<DataGatheringController> logger;

        /// <summary>
        /// جهت دریافت سرویس های مورد نیاز کنترلر
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="logger"></param>
        public DataGatheringController(IMediator mediator, ILogger<DataGatheringController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }
        /// <summary>
        /// سرویس ارسال و ثبت و ویرایش اطلاعات بیمه شده و بیمه نامه
        /// </summary>
        /// <param name="personPolicyInfoList">اطلاعات بیمه شونده و بیمه نامه</param>
        /// <returns>اطلاعات وضعیت درخواست ثبت یا ویرایش</returns>
        [HttpPost("SendPersonPolicyInfo")]
        [SwaggerRequestExample(typeof(PersonPolicyInfoInputViewModel), typeof(PersonPolicyInfoInputViewModelExample))]
        [SwaggerResponse(StatusCodes.Status200OK, "شناسه منحصر به فرد ثبت اطلاعات بیمه شده در هاب بیمه مرکزی و نسخه ثبت شده", typeof(ResponseViewModel<List<DataVO>>))]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(ResponseViewModelExample))]
        public async Task<IActionResult> CreatePersonPolicyInfo(PersonPolicyInfoInputViewModel personPolicyInfoList)
        {
            List<DataVO> results = new();
            if (personPolicyInfoList?.Data?.Count > 0)
            {
                Guid messageUID = Guid.NewGuid();
                foreach (var personPolicyInfo in personPolicyInfoList.Data)
                {
                    if (personPolicyInfo is not null)
                    {
                        var result = await mediator.Send(new SavePersonInsuranceCommand(personPolicyInfo.MsgID, personPolicyInfo.Person, personPolicyInfo.PersonPolicy, personPolicyInfo.ServiceDateTime, messageUID));
                        results.Add(result);
                    }
                }
                return Ok(Tools.CreateResponse(200, results));
            }
            else
                throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.Input).Replace("{1}", $"{Names.Information} {Names.PersonInfoVO}, {Names.PersonPolicyVO}"), ExceptionType.InValid, nameof(CreatePersonPolicyInfo));
        }
        /// <summary>
        /// دریافت وضعیت داده درخواست های ثبت یا ویرایش
        /// </summary>
        /// <param name="regsiterUID">شناسه منحصر به فرد ثبت اطلاعات بیمه شده در هاب بیمه مرکزی</param>
        /// <returns>اطلاعات وضعیت درخواست ثبت یا ویرایش</returns>
        [HttpGet("PersonPolicyInfo/Status/{regsiterUID:Guid}")]
        [SwaggerResponse(StatusCodes.Status200OK, "نمایش وضعیت های درخواست ثبت یا ویرایش بیمه نامه و بیمه شونده", typeof(PersonInsuranceStatusDto))]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(PersonInsuranceStatusDtoExample))]
        public async Task<IActionResult> GetStatus([Required(ErrorMessage = "لطفا شناسه منحصر به فرد ثبت اطلاعات بیمه شده در هاب بیمه مرکزی را وارد نمایید.")] Guid regsiterUID)
        {
            var result = await mediator.Send(new PersonInsuranceStatusByRegisterUIDQuery(regsiterUID));
            return Ok(result);
        }
        /// <summary>
        /// دریافت وضعیت درخواست های که با خطا روبرو شده است در تاریخ مورد نظر
        /// به صورت صفحه بندی
        /// </summary>
        /// <param name="year">سال</param>
        /// <param name="month">ماه</param>
        /// <param name="day">روز</param>
        /// <param name="pageNumber">شماره صفحه</param>
        /// <returns>اطلاعات وضعیت درخواست ثبت یا ویرایش</returns>        
        [HttpGet("PersonPolicyInfo/Status/Last/Error/{year:int}/{month:int}/{day:int}/{pageNumber:int?}")]
        [SwaggerResponse(StatusCodes.Status200OK, "نمایش وضعیت های درخواست ثبت یا ویرایش بیمه نامه و بیمه شونده", typeof(PagingDto<List<PersonInsuranceStatusDetailsDto>>))]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(PersonInsuranceStatusDetailsDtoWithPagingExample))]
        public async Task<IActionResult> GetFailedStatusByDate([Required(ErrorMessage = "لطفا سال را وارد نمایید.")] int year, [Required(ErrorMessage = "لطفا ماه را وارد نمایید.")] int month, [Required(ErrorMessage = "لطفا روز را وارد نمایید.")] int day, int? pageNumber = 0)
        {
            if (pageNumber == null)
                pageNumber = 0;
            var result = await mediator.Send(new PersonInsuranceStatusByDateQuery(year, month, day, pageNumber.Value));
            return Ok(result);
        }
        /// <summary>
        /// دریافت اطلاعات آخرین نسخه بیمه نامه ثبت شده از طریق شناسه فردی بیمه شده
        /// بیمه مرکزی
        /// </summary>
        /// <param name="id">شناسه</param>
        /// <param name="issuer">صادر کننده شناسه</param>
        /// <param name="assigner">سازکان اختصاص دهنده</param>
        /// <param name="type">نوع شناسه</param>
        /// <returns>خلاصه اطلاعات آخرین نسخه بیمه نامه ثبت شده</returns>        
        [HttpGet("PersonPolicyInfo/Summary/Last/{id}/{issuer}/{assigner}/{type}")]
        [SwaggerResponse(StatusCodes.Status200OK, "خلاصه اطلاعات آخرین نسخه بیمه نامه ثبت شده", typeof(List<PersonInsuranceInfoDto>))]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(PersonInsuranceInfoDtoListExample))]
        public async Task<IActionResult> GetLastPersonPolicyInfo([Required(ErrorMessage = "لطفا شناسه را وارد نمایید.")] string id, [Required(ErrorMessage = "لطفا صادر کننده را وارد نمایید.")] string issuer, [Required(ErrorMessage = "لطفا سازمان اختصاص دهنده را وارد نمایید.")] string assigner, [Required(ErrorMessage = "لطفا نوع شناسه را وارد نمایید.")] string type)
        {
            var result = await mediator.Send(new PersonInsuranceInfoByPersonIdQuery(id, issuer, assigner, type));
            return Ok(result);
        }
        /// <summary>
        /// دریافت اطلاعات تمامی نسخه های بیمه نامه ثبت شده از طریق شناسه فردی بیمه شده
        /// بیمه مرکزی
        /// </summary>
        /// <param name="id">شناسه</param>
        /// <param name="issuer">صادر کننده شناسه</param>
        /// <param name="assigner">سازکان اختصاص دهنده</param>
        /// <param name="type">نوع شناسه</param>
        /// <returns>خلاصه اطلاعات نسخه بیمه نامه ثبت شده</returns>        
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("PersonPolicyInfo/Summary/{id}/{issuer}/{assigner}/{type}")]
        [SwaggerResponse(StatusCodes.Status200OK, "خلاصه اطلاعات نسخه بیمه نامه ثبت شده", typeof(List<PersonInsuranceInfoDto>))]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(PersonInsuranceInfoDtoListExample))]
        public async Task<IActionResult> GetPersonPolicyInfo([Required(ErrorMessage = "لطفا شناسه را وارد نمایید.")] string id, [Required(ErrorMessage = "لطفا صادر کننده را وارد نمایید.")] string issuer, [Required(ErrorMessage = "لطفا سازمان اختصاص دهنده را وارد نمایید.")] string assigner, [Required(ErrorMessage = "لطفا نوع شناسه را وارد نمایید.")] string type)
        {
            var result = await mediator.Send(new PersonInsuranceInfoByPersonIdQuery(id, issuer, assigner, type, false));
            return Ok(result);
        }
    }
}
