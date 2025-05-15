using Mapper.GSB.Rest.API.ViewModels.ErrorResult;
using Mapper.GSB.Share.Resource;
using Swashbuckle.AspNetCore.Filters;
using Services.ExceptionManager.Resources;

namespace Mapper.GSB.Rest.API.Helper.SwaggerExamples.Errors;
/// <summary>
/// نمونه شی که درزمان ایجاد خطا برای کلاینت ارسال می شود
/// </summary>
public class ErrorViewModel409Example : IExamplesProvider<ErrorViewModel>
{
    /// <summary>
    /// ایجاد نمونه خطا
    /// </summary>
    /// <returns></returns>
    public ErrorViewModel GetExamples()
    {        
        return new ErrorViewModel(new ErrorDetails(nameof(Names.Data).ToLower(), ExceptionsMessages.Data_is_already_exist.Replace("{0}", ""), ErrorType.LogicalError));
    }
}
