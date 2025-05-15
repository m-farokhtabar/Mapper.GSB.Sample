using Services.Authorization.Cache;
using Services.Authorization.Settings;

namespace Mapper.GSB.Rest.API.StartupConfig.Settings;
/// <summary>
/// تنظیمات سطح دسترسی
/// </summary>
public class AuthSettings : IAuthSettings
{
    /// <summary>
    /// آدرس اینترنتی سرور 
    /// IDP
    /// </summary>
    public string Authority { get; set; } = string.Empty;
    /// <summary>
    /// در صورت وجود
    /// SSL
    /// بایستی 
    /// true
    /// باشد
    /// </summary>
    public bool RequireHttpsMetadata { get; set; }
    /// <summary>
    /// نام سرویس به همراه نوع سرویس
    /// </summary>
    public string Audience { get; set; } = string.Empty;
    /// <summary>
    /// نام سرویس
    /// </summary>
    public string ApiName { get; set; } = string.Empty;
    /// <summary>
    /// لیست تنظیمات کش
    /// دلیل استفاده از این خاصیت به دلیل عدم پذیرش مبدل سفارشی برای اینتر فیس در زمان تبدیل جی سان تنظیمات است
    /// </summary>        
    public List<CacheMasterKeySetting>? CacheKeysSettingList { get; set; }
    /// <summary>
    /// تبدیل لیست تنظیمات کش به نوع دیکشنری
    /// </summary>
    public Dictionary<string, ICacheMasterKeySetting>? CacheKeysSetting => CacheKeysSettingList?.ToDictionary(x => x.MasterKey, x => (ICacheMasterKeySetting)x);
}

