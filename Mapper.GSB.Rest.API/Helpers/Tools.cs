using Mapper.GSB.Rest.API.ViewModels.Response;
using Services.ExceptionManager;

namespace Mapper.GSB.Rest.API.Helpers
{
    /// <summary>
    /// ابزارهای مورد نیاز در
    /// API
    /// </summary>
    public static class Tools    
    {
        /// <summary>
        /// ایجاد آدرس جهت دریافت منایع یا همان دادها
        /// </summary>
        /// <param name="Request"></param>
        /// <param name="ControllerName"></param>
        /// <param name="ResourceId"></param>
        /// <returns></returns>
        public static string CreateResourceLocation(this HttpRequest Request, string ControllerName, string ResourceId)
        {

            return Request.Scheme + "://" + Request.Host.Value + "/api/v" + Request.RouteValues.GetValueOrDefault("Version") + "/" + ControllerName + "/" + ResourceId;
        }
        /// <summary>
        /// ایجاد شی پاسح
        /// </summary>
        /// <param name="status"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResponseViewModel<T> CreateResponse<T>(int? status, T? data = default)
        {            
            var result = new ResultVO<T>()
            {
                Data = data,
                IsError = status != 200,
                StatusCode = status
            };
            return new ResponseViewModel<T>
            {
                Result = result,
                Status = new StatusVO()
                {
                    Message = "ok",
                    StatusCode = 200
                }
            };
        }

    }
}
