using Mapper.GSB.Rest.API.ViewModels.ErrorResult;
using Mapper.GSB.Share.Resource;
using Swashbuckle.AspNetCore.Filters;
using Services.ExceptionManager.Resources;

namespace Mapper.GSB.Rest.API.Helper.SwaggerExamples.Errors;
/// <summary>
/// نمونه شی که درزمان ایجاد خطا برای کلاینت ارسال می شود
/// </summary>
public class ErrorViewModel408Example : IExamplesProvider<ErrorViewModel>
{
    /// <summary>
    /// ایجاد نمونه خطا
    /// </summary>
    /// <returns></returns>
    public ErrorViewModel GetExamples()
    {        
        return new ErrorViewModel(new ErrorDetails(nameof(Names.Server).ToLower(), ExceptionsMessages.Request_is_timeout.Replace("{0}", Names.Server), ErrorType.RuntimeError));
    }
}
