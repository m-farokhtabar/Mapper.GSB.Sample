using Mapper.GSB.Rest.API.ViewModels.ErrorResult;
using Mapper.GSB.Share.Resource;
using Services.ExceptionManager.Resources;
using System.Net.Mime;

namespace Mapper.GSB.Rest.API.StartupConfig.Applications;
/// <summary>
/// سفارشی کرن انواع خطای های 
/// HTTP
/// </summary>
public static class StatusCodePagesApplicationExtension
{
    /// <summary>
    /// سفارشی کرن انواع خطای های 
    /// HTTP
    /// </summary>
    /// <param name="app"></param>
    public static void UseCustomizeStatusCodePages(this IApplicationBuilder app)
    {
        app.UseStatusCodePages(async context =>
        {            
            string Message;
            string Key;
            switch (context.HttpContext.Response.StatusCode)
            {
                case StatusCodes.Status401Unauthorized:
                    Message = ExceptionsMessages.User_is_not_authenticated;
                    Key = nameof(Names.Authentication).ToLower();
                    break;
                case StatusCodes.Status403Forbidden:
                    Message = ExceptionsMessages.User_is_not_authorized.Replace("{0}", Names.Information);
                    Key = nameof(Names.Authorization).ToLower();
                    break;
                case StatusCodes.Status404NotFound:
                    Message = ExceptionsMessages.Data_is_not_found.Replace("{0}", Names.Asked).Replace("{1}", "");
                    Key = nameof(Names.Request).ToLower();
                    break;
                //406 is returned by the server when it can't respond based on accepting the request headers (ie they have an Accept header which states they only want XML).
                case StatusCodes.Status406NotAcceptable:
                    Message = ExceptionsMessages.Data_format_is_not_supported_for_response.Replace("{0}", MediaTypeNames.Application.Json);
                    Key = nameof(Names.Request).ToLower();
                    break;
                case StatusCodes.Status408RequestTimeout:
                    Message = ExceptionsMessages.Request_is_timeout.Replace("{0}", Names.Server);
                    Key = nameof(Names.Request).ToLower();
                    break;
                case StatusCodes.Status415UnsupportedMediaType:
                    Message = ExceptionsMessages.Data_format_is_not_valid;
                    Key = nameof(Names.Request).ToLower();
                    break;
                default:
                    Message = ExceptionsMessages.Server_has_encountered_With_error.Replace("{0}", Names.Operation).Replace("{1}", Names.Server);
                    Key = context.HttpContext.Response.StatusCode.ToString().ToLower();
                    break;
            }
            context.HttpContext.Response.ContentType = $"{MediaTypeNames.Application.Json}; charset=utf-8";
            var Error = new ErrorViewModel(new ErrorDetails(Key, Message, ErrorType.RuntimeError));
            await context.HttpContext.Response.WriteAsync(Error.ToString());
        });
    }
}
