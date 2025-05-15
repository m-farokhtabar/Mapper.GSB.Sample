using Mapper.GSB.Application.SeedWork.Cache;
using Mapper.openEHR.SeedWork.Cache;

namespace Mapper.GSB.Host.DDRAPICaller.StartupConfig.Settings
{
    /// <summary>
    /// تنظیمات برنامه
    /// mapper
    /// </summary>
    public class OmCacheSettings : IOmCacheSetting
    {
        /// <summary>
        /// لیست تنظیمات کش
        /// دلیل استفاده از این خاصیت به دلیل عدم پذیرش مبدل سفارشی برای اینتر فیس در زمان تبدیل جی سان تنظیمات است
        /// </summary>        
        public List<CacheMasterKeySetting>? CacheKeysSettingList { get; set; }
        /// <summary>
        /// تبدیل لیست تنظیمات کش به نوع دیکشنری
        /// </summary>
        public Dictionary<string, IOmCacheMasterKeySetting>? CacheKeysSetting => CacheKeysSettingList?.ToDictionary(x => x.MasterKey, x => (IOmCacheMasterKeySetting)x);
    }
}
