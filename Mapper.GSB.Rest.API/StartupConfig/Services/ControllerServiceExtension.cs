using Mapper.GSB.Rest.API.ViewModels.ErrorResult;
using Microsoft.AspNetCore.Mvc;
using static Services.ExceptionManager.Resources.ExceptionsMessages;
using static Mapper.GSB.Share.Resource.Names;
using System.Text.Json;

namespace Mapper.GSB.Rest.API.StartupConfig.Services;
/// <summary>
/// تنظیمات مربوط به نحوه دریاقت و ارسال درخواست ها
/// </summary>
public static class ControllerServiceExtension
{
    /// <summary>
    /// تنظیمات مربوط به نحوه دریاقت و ارسال درخواست ها
    /// </summary>
    /// <param name="services"></param>
    public static IMvcBuilder ConfigureController(this IServiceCollection services)
    {
        return services.AddControllers(x => x.RespectBrowserAcceptHeader = true)
            .AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
                x.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;                
            })
            .ConfigureApiBehaviorOptions(y =>
            {
                y.InvalidModelStateResponseFactory = context => new BadRequestObjectResult(CustomBadRequest.ConstructErrorMessages(context));
                y.SuppressMapClientErrors = false;
            });
    }
}
/// <summary>
/// سفارشی کردن پیام های اعتبار سنجی
/// </summary>
public static class CustomBadRequest
{
    /// <summary>
    /// سفارشی کردن پیام های اعتبار سنجی
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public static ErrorViewModel ConstructErrorMessages(ActionContext context)
    {
        List<ErrorDetails> ErrorDetailsList = new();

        foreach (var KeyModelStatePair in context.ModelState)
        {
            var Key = KeyModelStatePair.Key;
            var Errors = KeyModelStatePair.Value.Errors;
            if (Errors?.Count > 0)
            {
                var ErrorMessages = new string[Errors.Count];
                for (var i = 0; i < Errors.Count; i++)
                    ErrorMessages[i] = string.IsNullOrEmpty(Errors[i].ErrorMessage) ? Data_is_not_valid_Value_is_wrong.Replace("{0}", Input).Replace("{1}", "") : MessageTranslator(Errors[i].ErrorMessage, Key);
                ErrorDetailsList.Add(new ErrorDetails(Key.ToLower(), ErrorMessages.ToList(), ErrorType.LogicalError));
            }
        }
        return new ErrorViewModel(ErrorDetailsList);
    }
    /// <summary>
    /// ترجمه پیام خطا به فارسی
    /// </summary>
    /// <param name="Message"></param>
    /// <param name="Key"></param>
    /// <returns></returns>
    public static string MessageTranslator(string Message, string Key)
    {
        if (string.Equals(Message, "A non-empty request body is required.", StringComparison.InvariantCultureIgnoreCase))
            return Data_of_request_is_mandatory;
        if (Message.EndsWith("field is required.", StringComparison.InvariantCultureIgnoreCase))
            return Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Request).Replace("{1}", Key);
        if (!string.IsNullOrWhiteSpace(Key) && Key.StartsWith("$"))
        {
            if (!Message.Contains("property name", StringComparison.InvariantCultureIgnoreCase))
                return Data_format_is_not_valid + " " + Data_is_not_valid_Value_is_wrong.Replace("{0}", Request).Replace("{1}", Key);
            else
                return Data_format_is_not_valid + " " + Data_is_not_valid_Value_is_wrong.Replace("{0}", PropertyName).Replace("{1}", Key);
        }
        if (!string.IsNullOrWhiteSpace(Key))
            return Data_is_not_valid_Value_is_wrong.Replace("{0}", Request).Replace("{1}", Key);
        else
            return Data_is_not_valid_Value_is_wrong.Replace("{0}", Request).Replace("{1}", Input);
    }
}