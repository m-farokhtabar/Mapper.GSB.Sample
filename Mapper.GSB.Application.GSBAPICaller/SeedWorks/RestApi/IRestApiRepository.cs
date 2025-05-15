using System.Text;

namespace Mapper.GSB.Application.GSBAPICaller.SeedWorks.RestApi
{
    /// <summary>
    /// سرویس فرخوانی درخواست از نوع
    /// REST
    /// </summary>
    public interface IRestApiRepository
    {
        /// <summary>
        /// سرویس فرخوانی سرویس 
        /// REST - POST
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="headers"></param>
        /// <param name="body"></param>
        /// <param name="contentType"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        Task<RestApiOutputDto> PostAsync(Uri requestUrl, Dictionary<string, string>? headers, string body, string contentType, Encoding? encoding = null);
    }
}