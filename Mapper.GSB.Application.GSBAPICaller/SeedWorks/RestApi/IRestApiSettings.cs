namespace Mapper.GSB.Application.GSBAPICaller.SeedWorks.RestApi
{
    /// <summary>
    /// تنظیمات مورد نیاز جهت صدا زدن سرویس های سرور
    /// </summary>
    public interface IRestApiSettings
    {
        /// <summary>
        /// آدرس پایه درخواست
        /// </summary>
        string BaseUrl { get; }
        /// <summary>
        /// اطلاعات سرویس ها
        /// </summary>
        List<IApiServiceDetails>? Services { get; }
    }
}
