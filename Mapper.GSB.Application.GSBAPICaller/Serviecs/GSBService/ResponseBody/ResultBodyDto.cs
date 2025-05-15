using System.Text.Json.Serialization;

namespace Mapper.GSB.Application.GSBAPICaller.Serviecs.GSBService.ResponseBody
{
    /// <summary>
    /// تمامی پاسخ های سرویس 
    /// GSB 
    /// از این پاسخ استفاده می کنند
    /// </summary>
    public class ResultBodyDto<T> where T : IBodyData
    {
        /// <summary>
        /// نتیجه اصلی
        /// </summary>
        public T? Data { get; set; }
        /// <summary>
        /// در صورتی که اعتبارسننجی به درستی انجام شده باشد و کاربر معتبر باشد
        /// true
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// زمان انتظار ؟؟؟
        /// </summary>
        public int WaitTime { get; set; }
        /// <summary>
        /// وضعیت نتیجه درخواست ????
        /// </summary>
        public int StatusCode { get; set; }
        /// <summary>
        /// پیام ارسالی از سمت سرویس دهنده
        /// </summary>
        public List<string>? Message { get; set; } = null;
    }
}
