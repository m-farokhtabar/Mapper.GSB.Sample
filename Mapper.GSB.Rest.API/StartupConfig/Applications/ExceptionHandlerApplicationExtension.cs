using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using Microsoft.Data.SqlClient;
using Mapper.GSB.Rest.API.ViewModels.ErrorResult;
using static Services.ExceptionManager.Resources.ExceptionsMessages;
using static Mapper.GSB.Share.Resource.Names;
using System.Net.Mime;
using Services.ExceptionManager;
using Serilog;

namespace Mapper.GSB.Rest.API.StartupConfig.Applications;
/// <summary>
/// سفارشی و مدیریت کردن خطاهای حروجی
/// </summary>
public static class ExceptionHandlerApplicationExtension
{
    /// <summary>
    /// تبدیل تمام خطاهای ایجاد شده به فرمت استاندارد جهت ارسال به کاربر
    /// <para>
    /// فرمت استاندارد <see cref="ErrorViewModel"/>
    /// </para>
    /// </summary>
    /// <param name="app"></param>
    public static void UseCustomizeExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature is not null)
                {
                    int StatusCode = (int)HttpStatusCode.InternalServerError;
                    ErrorViewModel? Error = null;
                    string ExtraErrorInfo = "";

                    if (contextFeature.Error is ManualException ManEx)
                    {
                        ExtraErrorInfo = $"Code= {ManEx.Code}";
                        Error = new ErrorViewModel(new ErrorDetails(ManEx.Code, ManEx.Message, ManEx.Type == ExceptionType.InternalServerError ? ErrorType.RuntimeError : ErrorType.LogicalError));
                        StatusCode = (int)ManEx.Type;
                    }
                    else if (contextFeature.Error is global::openEHR.Helper.CustomException.openEHRException OpenEHREx)
                    {
                        ExtraErrorInfo = $"Code= {OpenEHREx.Code}";
                        Error = new ErrorViewModel(new ErrorDetails(OpenEHREx.Code, OpenEHREx.Message, OpenEHREx.Type == global::openEHR.Helper.CustomException.ExceptionType.InternalServerError ? ErrorType.RuntimeError : ErrorType.LogicalError));
                        StatusCode = (int)OpenEHREx.Type;
                    }
                    else
                    {
                        (Error, StatusCode) = IsSqlException(contextFeature.Error);
                        if (Error is null)
                        {
                            Error = new ErrorViewModel(new ErrorDetails(nameof(InternalServerError), Server_has_encountered_With_error.Replace("{0}", Operation).Replace("{1}", Server), ErrorType.RuntimeError));
                            StatusCode = (int)HttpStatusCode.InternalServerError;
                        }
                    }
                    context.Response.Clear();
                    context.Response.ContentType = $"{MediaTypeNames.Application.Json}; charset=utf-8";
                    context.Response.StatusCode = StatusCode;
                    await context.Response.WriteAsync(Error!.ToString());
                }
            });
        });
    }
    /// <summary>
    /// تشخصی اینکه خطا مربوط به پایگاه داده است
    /// </summary>
    /// <param name="Error"></param>
    /// <returns></returns>
    private static (ErrorViewModel? Error, int StatusCode) IsSqlException(Exception Error)
    {
        SqlException? SqlEx = Error as SqlException ?? Error.InnerException as SqlException;
        return SqlEx is not null
            ? SqlEx.Number switch
            {
                //Pause
                17142 or 2 => (new ErrorViewModel(new ErrorDetails(nameof(Database), Cannot_connect_to_resource.Replace("{0}", Database), ErrorType.RuntimeError)), (int)HttpStatusCode.InternalServerError),
                //Unique field is already exist
                2601 or 2627 => (new ErrorViewModel(new ErrorDetails(nameof(Database), Data_is_already_exist.Replace("{0}", Input), ErrorType.LogicalError)), (int)HttpStatusCode.Conflict),
                //There is not the primary key to use as a foreign key
                547 => (new ErrorViewModel(new ErrorDetails(nameof(Database), Data_is_not_found.Replace("{0}", Input).Replace("{1}", ""), ErrorType.LogicalError)), (int)HttpStatusCode.NotFound),
                _ => (new ErrorViewModel(new ErrorDetails(nameof(Database), Server_has_encountered_With_error.Replace("{0}", Operation).Replace("{1}", Data), ErrorType.RuntimeError)), (int)HttpStatusCode.InternalServerError),
            }
            : (null, 0);
    }
}
