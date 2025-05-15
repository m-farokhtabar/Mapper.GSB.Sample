using Mapper.GSB.Rest.API.Helper.SwaggerExamples.Errors;
using Mapper.GSB.Rest.API.ViewModels.ErrorResult;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using System.Net.Mime;

namespace Mapper.GSB.Rest.API.Controllers
{
    /// <summary>
    /// کلاس مربوط جهت اعمال استانداردها مشترک مابین تمامی کنترلرها مورد استفاده قرار می گیرد
    /// </summary>
    [SwaggerResponseExample(StatusCodes.Status400BadRequest, typeof(ErrorViewModel400Example))]
    [SwaggerResponseExample(StatusCodes.Status401Unauthorized, typeof(ErrorViewModel401Example))]
    [SwaggerResponseExample(StatusCodes.Status403Forbidden, typeof(ErrorViewModel403Example))]
    [SwaggerResponseExample(StatusCodes.Status404NotFound, typeof(ErrorViewModel404Example))]
    [SwaggerResponseExample(StatusCodes.Status408RequestTimeout, typeof(ErrorViewModel408Example))]
    [SwaggerResponseExample(StatusCodes.Status500InternalServerError, typeof(ErrorViewModel500Example))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "درخواست نامعتبر", typeof(ErrorViewModel))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "عدم اعتبار درخواست کننده", typeof(ErrorViewModel))]
    [SwaggerResponse(StatusCodes.Status403Forbidden, "عدم مجوز درخواست کننده برای سرویس مربوطه", typeof(ErrorViewModel))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "اطلاعات مورد نظر یافت نشده است", typeof(ErrorViewModel))]
    [SwaggerResponse(StatusCodes.Status408RequestTimeout, "مهلت زمانی جهت دریافت پاسخ از سرویس دهنده به پایان رسیده است.", typeof(ErrorViewModel))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "خطای زمان اجرا", typeof(ErrorViewModel))]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Route("api/v{version:apiVersion}/[Controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
    }
}
