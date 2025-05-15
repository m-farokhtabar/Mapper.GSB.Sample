using Mapper.GSB.Application.GSBAPICaller.Serviecs.GSBService.ResponseBody;
using Mapper.GSB.Application.GSBAPICaller.Serviecs.GSBService.SendPerson;
using Mapper.GSB.Application.GSBAPICaller.Serviecs.GSBService.SendPerson.SendPersonInfo;
using Mapper.GSB.Application.GSBAPICaller.Serviecs.GSBService.SendPerson.SendPersonSupplimantryInfo;
using Mapper.GSB.Application.GSBAPICaller.Serviecs.GSBService.Token;
using Services.ExceptionManager;

namespace Mapper.GSB.Application.GSBAPICaller.Serviecs.GSBService
{
    /// <summary>
    /// سرویس ارسال داده به سامانه بیمه سلامت
    /// </summary>
    public interface IGSBDataSenderService
    {
        /// <summary>
        /// دریافت توکن مورد نیاز سیستم
        /// </summary>
        /// <returns>توکن</returns>
        /// <exception cref="ManualException"></exception>
        Task<RootResultDto<TokenResultDto>> GetToken();
        /// <summary>
        /// درخواست ثبت اطلاعات فول درمان
        /// </summary>
        /// <param name="data"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="ManualException"></exception>
        Task<(RootResultDto<SendPersonResultDto>, string)> SendPersonInfo(SendPersonInfoInputDto data, string token);
        /// <summary>
        /// درخواست ثبت اطلاعات فول درمان
        /// </summary>
        /// <param name="data"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="ManualException"></exception>
        Task<(RootResultDto<SendPersonResultDto>, string)> SendPersonSupplimantryInfo(SendPersonSupplimantryInfoInputDto data, string token);
    }
}