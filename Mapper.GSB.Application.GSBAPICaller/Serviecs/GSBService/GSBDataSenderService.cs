using Mapper.GSB.Application.GSBAPICaller.SeedWorks.RestApi;
using Mapper.GSB.Application.GSBAPICaller.Serviecs.GSBService.CacheKey;
using Mapper.GSB.Application.GSBAPICaller.Serviecs.GSBService.ResponseBody;
using Mapper.GSB.Application.GSBAPICaller.Serviecs.GSBService.SendPerson;
using Mapper.GSB.Application.GSBAPICaller.Serviecs.GSBService.SendPerson.SendPersonInfo;
using Mapper.GSB.Application.GSBAPICaller.Serviecs.GSBService.SendPerson.SendPersonSupplimantryInfo;
using Mapper.GSB.Application.GSBAPICaller.Serviecs.GSBService.Token;
using Mapper.GSB.Application.SeedWork.Cache;
using Mapper.GSB.Share.Resource;
using Microsoft.Extensions.Logging;
using Services.ExceptionManager;
using Services.ExceptionManager.Resources;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Mapper.GSB.Application.GSBAPICaller.Serviecs.GSBService
{
    /// <summary>
    /// سرویس ارسال داده به سامانه بیمه سلامت
    /// </summary>
    public class GSBDataSenderService : IGSBDataSenderService
    {
        private readonly IRestApiSettings restApiSettings;
        private readonly IRestApiRepository restApiRepository;
        private readonly ICacheStore cacheStore;
        private readonly ILogger<GSBDataSenderService> logger;
        private readonly JsonSerializerOptions serializeOptions;
        /// <summary>
        /// آماده سازی سرویس جهت صدا زدن سرویس وب خارجی
        /// </summary>
        /// <param name="restApiSettings"></param>
        /// <param name="restApiRepository"></param>
        public GSBDataSenderService(IRestApiSettings restApiSettings, IRestApiRepository restApiRepository, ICacheStore cacheStore, ILogger<GSBDataSenderService> logger)
        {
            this.restApiSettings = restApiSettings;
            this.restApiRepository = restApiRepository;
            this.cacheStore = cacheStore;
            this.logger = logger;
            serializeOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull };
        }
        /// <summary>
        /// درخواست ثبت اطلاعات فول درمان
        /// </summary>
        /// <param name="data"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="ManualException"></exception>
        public async Task<(RootResultDto<SendPersonResultDto>, string)> SendPersonSupplimantryInfo(SendPersonSupplimantryInfoInputDto data, string token)
        {
            var settingDetails = GetSettingDetails("SendPersonSupplimantryInfo", Names.ApiServiceSetting_SendPersonSupplimantryInfo, typeof(GSBDataSenderService).FullName + "." + nameof(SendPersonSupplimantryInfo) + "()");
            Dictionary<string, string> headers = new();
            if (settingDetails.Headers?.Count > 0)
                foreach (var header in settingDetails.Headers)
                    headers.Add(header.Key, header.Value);
            headers.Add("X_Authorization", $"Bearer {token}");

            //"SendPersonSupplimantryInfo"
            string jsonData = JsonSerializer.Serialize(data, serializeOptions);
            var result = await restApiRepository.PostAsync(new Uri(settingDetails.Url, UriKind.Relative), headers,
                                                           jsonData, settingDetails.ContentType, settingDetails.IsUTF8 ? Encoding.UTF8 : null);
            return (MapToObject<SendPersonResultDto>(result, Names.SendPersonSupplimantryInfo, typeof(GSBDataSenderService).FullName + "." + nameof(SendPersonSupplimantryInfo) + "()", jsonData), jsonData);
        }
        /// <summary>
        /// درخواست ثبت اطلاعات فول درمان
        /// </summary>
        /// <param name="data"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="ManualException"></exception>
        public async Task<(RootResultDto<SendPersonResultDto>, string)> SendPersonInfo(SendPersonInfoInputDto data, string token)
        {
            //logger.LogError("Input[SendPersonInfoInputDto]: " + JsonSerializer.Serialize(data));
            var settingDetails = GetSettingDetails("SendPersonInfo", Names.ApiServiceSetting_SendPersonInfo, typeof(GSBDataSenderService).FullName + "." + nameof(SendPersonInfo) + "()");
            Dictionary<string, string> headers = new();
            if (settingDetails.Headers?.Count > 0)
                foreach (var header in settingDetails.Headers)
                    headers.Add(header.Key, header.Value);
            headers.Add("X_Authorization", $"Bearer {token}");
            //"SendPersonInfo"
            string jsonData = JsonSerializer.Serialize(data, serializeOptions);
            var result = await restApiRepository.PostAsync(new Uri(settingDetails.Url, UriKind.Relative), headers,
                                                           jsonData, settingDetails.ContentType, settingDetails.IsUTF8 ? Encoding.UTF8 : null);
            //logger.LogError("Output[RestApiOutputDto]: " + JsonSerializer.Serialize<RestApiOutputDto>(result));
            return (MapToObject<SendPersonResultDto>(result, Names.SendPersonInfo, typeof(GSBDataSenderService).FullName + "." + nameof(SendPersonInfo) + "()", jsonData), jsonData);
        }
        /// <summary>
        /// دریافت توکن مورد نیاز سیستم
        /// </summary>
        /// <returns>توکن</returns>
        /// <exception cref="ManualException"></exception>
        public async Task<RootResultDto<TokenResultDto>> GetToken()
        {
            TokenCacheKey cacheKey = new("");
            var result = await cacheStore.GetOrCreateWithoutSlidingExpAndWithHourExpAsync(cacheKey, async () =>
            {
                var settingDetails = GetSettingDetails("GetToken", Names.ApiServiceSetting_GetToken, typeof(GSBDataSenderService).FullName + "." + nameof(GetToken) + "()");
                var result = await restApiRepository.PostAsync(new Uri(settingDetails.Url, UriKind.Relative), settingDetails.Headers, JsonSerializer.Serialize(new
                {
                    username = settingDetails.KeyValuePairs?["username"],
                    password = settingDetails.KeyValuePairs?["password"]
                }, serializeOptions), settingDetails.ContentType, settingDetails.IsUTF8 ? Encoding.UTF8 : null);
                var data = MapToObject<TokenResultDto>(result, Names.GetToken, typeof(GSBDataSenderService).FullName + "." + nameof(GetToken) + "()","");
                if (string.IsNullOrEmpty(data.Result?.Data?.Data?.TokenID))
                    throw new ManualException(ExceptionsMessages.Server_request_is_successfully_done_however_the_response_is_null.Replace("{0}", Names.GetToken + " - (TokenId is null!)"), ExceptionType.InternalServerError,
                                              typeof(GSBDataSenderService).FullName + "." + nameof(GetToken) + "()", result.Data);
                return data;
            });
            return result!;

            //var settingDetails = GetSettingDetails("GetToken", Names.ApiServiceSetting_GetToken, typeof(GSBDataSenderService).FullName + "." + nameof(GetToken) + "()");            
            //var result = await restApiRepository.PostAsync(new Uri(settingDetails.Url, UriKind.Relative), settingDetails.Headers, JsonSerializer.Serialize(new
            //{
            //    UserName = settingDetails.KeyValuePairs?["userName"],
            //    Password = settingDetails.KeyValuePairs?["password"]
            //}, serializeOptions), settingDetails.ContentType, settingDetails.IsUTF8 ? Encoding.UTF8 : null);
            //var data = MapToObject<TokenResultDto>(result, Names.GetToken, typeof(GSBDataSenderService).FullName + "." + nameof(GetToken) + "()");
            //if (string.IsNullOrEmpty(data.Data?.TokenID))
            //    throw new ManualException(ExceptionsMessages.Server_request_is_successfully_done_however_the_response_is_null.Replace("{0}", Names.GetToken + " - (TokenId is null!)"), ExceptionType.InternalServerError,
            //                              typeof(GSBDataSenderService).FullName + "." + nameof(GetToken) + "()", result.Data);
            //return data;
        }
        /// <summary>
        /// دریافت نتیجه وتبدیل آن به شی مورد نظر
        /// </summary>
        /// <typeparam name="T">نوع کلاس نتیجه در صورت موفق بودن</typeparam>
        /// <param name="result"></param>
        /// <param name="ServiceName">نام فارسی سرویس</param>
        /// <param name="ServiceFullName">نام کامل به همراه فضای نام نام کلاس و نام متد</param>
        /// <returns></returns>
        /// <exception cref="ManualException"></exception>
        private RootResultDto<T> MapToObject<T>(RestApiOutputDto result, string ServiceName, string ServiceFullName,string jsonDataSendToGSb) where T : IBodyData
        {
            //نتیجه موفققیت آمیز بوده
            if (result.Status == HttpStatusCode.OK)
            {
                if (!string.IsNullOrWhiteSpace(result.Data))
                {
                    var resultData = JsonSerializer.Deserialize<RootResultDto<T>>(result.Data, serializeOptions) ?? throw new ManualException(ExceptionsMessages.Server_request_is_successfully_done_however_the_response_is_null.Replace("{0}", ServiceName), ExceptionType.InternalServerError, ServiceFullName, result.Data + " -- jsonDataSendToGSb=[" + jsonDataSendToGSb+"]");
                    if (resultData?.Result?.Data?.IsSuccess == true || resultData?.Result?.Data?.StatusCode == 0)
                    {
                        resultData.JsonStringifyData = result.Data;
                        return resultData;
                    }
                    else
                        throw new ManualException(ExceptionsMessages.Server_request_is_successfully_done_however_the_response_shows_internal_error.Replace("{0}", ServiceName).Replace("{1}", $"StatusCoderoot={resultData?.Status?.Message},StatusCodeMiddle={resultData?.Result?.Status?.Message},StatusCodeInner={resultData?.Result?.Data?.StatusCode}"), ExceptionType.InternalServerError, ServiceFullName, result.Data + " -- jsonDataSendToGSb=[" + jsonDataSendToGSb + "]");
                }
                else
                    throw new ManualException(ExceptionsMessages.Server_request_is_successfully_done_however_the_response_is_null.Replace("{0}", ServiceName), ExceptionType.InternalServerError, ServiceFullName, " -- jsonDataSendToGSb=[" + jsonDataSendToGSb + "]");
            }
            //نتیجه غیر از حالت موفقیت آمیز بوده است
            else
            {
                if (!string.IsNullOrWhiteSpace(result.Data))
                    throw new ManualException(ExceptionsMessages.An_error_occurred_while_processing_the_request_from_the_web_service.Replace("{0}", $"{result.Status}[{(int)result.Status}]").Replace("{1}", ServiceName), ExceptionType.InternalServerError, ServiceFullName, result.Data + " -- jsonDataSendToGSb=[" + jsonDataSendToGSb + "]");
                else
                    throw new ManualException(ExceptionsMessages.Server_request_is_not_successful_however_the_response_is_null.Replace("{0}", ServiceName).Replace("{1}", $"{result.Status}[{(int)result.Status}]"), ExceptionType.InternalServerError, ServiceFullName, " -- jsonDataSendToGSb=[" + jsonDataSendToGSb + "]");
            }
        }
        /// <summary>
        /// دریافت تنظیمات مورد نیاز سرویس
        /// </summary>
        /// <param name="settingKey">کلید جهت بدست اوردن تنظیمات سرویس مورد نظر</param>
        /// <param name="ApiServiceSettingName">نام فارسی تنظیمات سرویس مورد نظر</param>
        /// <param name="ServiceFullName">نام کامل به همراه فضای نام نام کلاس و نام متد</param>
        /// <returns></returns>
        /// <exception cref="ManualException"></exception>
        private IApiServiceDetails GetSettingDetails(string settingKey, string ApiServiceSettingName, string ServiceFullName)
        {
            var settingDetails = restApiSettings.Services?.Where(x => x.ServiceName.Equals(settingKey)).FirstOrDefault();
            if (settingDetails is null)
                throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.ApiServiceSetting).Replace("{1}", ApiServiceSettingName), ExceptionType.InValid, ServiceFullName);
            return settingDetails;
        }
    }
}
