namespace Mapper.GSB.Application.GSBAPICaller.SeedWorks.RestApi
{
    /// <summary>
    /// اطلاعات مورد نیاز برای صدا زدن یک سرویس
    /// API
    /// </summary>
    public interface IApiServiceDetails
    {
        /// <summary>
        /// نام سرویس
        /// </summary>
        string ServiceName { get; }
        /// <summary>
        /// آدرس درخواست سرویس
        /// </summary>
        string Url { get; }
        /// <summary>
        /// نوع درخواست
        /// </summary>
        RestApiType RequestType { get; }
        /// <summary>
        /// هدر های مورد نیاز
        /// </summary>
        /// <remarks>
        /// لطفا هدر
        /// Content-type
        /// charset
        /// در این قسمت قرار نگیرد
        /// </remarks>
        Dictionary<string, string>? Headers { get; }
        /// <summary>
        /// پارامترهای مورد نیاز برای صدا زدن سرویس
        /// </summary>
        Dictionary<string,string>? KeyValuePairs { get; }
        /// <summary>
        /// نوع داده ای که قرار است ارسال شود
        /// </summary>
        /// <example>
        /// مثلا برای جی سان
        /// "application/json"
        /// </example>
        public string ContentType { get; }
        /// <summary>
        /// یونیکد
        /// charset
        /// </summary>
        public bool IsUTF8 { get; }
    }
}
