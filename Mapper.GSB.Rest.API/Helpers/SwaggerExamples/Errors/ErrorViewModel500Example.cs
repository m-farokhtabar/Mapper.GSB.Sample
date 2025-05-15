using Mapper.GSB.Rest.API.ViewModels.ErrorResult;
using Mapper.GSB.Share.Resource;
using Swashbuckle.AspNetCore.Filters;
using Services.ExceptionManager.Resources;

namespace Mapper.GSB.Rest.API.Helper.SwaggerExamples.Errors;
/// <summary>
/// نمونه شی که درزمان ایجاد خطا برای کلاینت ارسال می شود
/// </summary>
public class ErrorViewModel500Example : IExamplesProvider<ErrorViewModel>
{
    /// <summary>
    /// ایجاد نمونه خطا
    /// </summary>
    /// <returns></returns>
    public ErrorViewModel GetExamples()
    {
        return new ErrorViewModel(new ErrorDetails(nameof(Names.InternalServerError).ToLower(), ExceptionsMessages.Server_has_encountered_With_error.Replace("{0}", Names.Operation).Replace("{1}", Names.Server), ErrorType.RuntimeError));
    }
}
