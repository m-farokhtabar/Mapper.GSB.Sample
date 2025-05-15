using Mapper.GSB.Rest.API.ViewModels.ErrorResult;
using Mapper.GSB.Share.Resource;
using Services.ExceptionManager.Resources;
using Swashbuckle.AspNetCore.Filters;

namespace Mapper.GSB.Rest.API.Helper.SwaggerExamples.Errors;
/// <summary>
/// نمونه شی که درزمان ایجاد خطا برای کلاینت ارسال می شود
/// </summary>
public class ErrorViewModel400Example : IExamplesProvider<ErrorViewModel>
{
    /// <summary>
    /// ایجاد نمونه خطا
    /// </summary>
    /// <returns></returns>
    public ErrorViewModel GetExamples()
    {
        return new ErrorViewModel(new ErrorDetails(nameof(Names.Data).ToLower(), ExceptionsMessages.Data_is_not_valid_Value_is_wrong.Replace("{0}", Names.Data).Replace("{1}", Names.Data), ErrorType.LogicalError));
    }
}
