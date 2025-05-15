namespace Mapper.GSB.Application.SeedWork.Cache
{
    /// <summary>
    /// تنظیمات مورد کش به کلیدها
    /// </summary>
    public interface ICacheSetting
    {
        /// <summary>
        /// تنظیمات کش به ازای هر کلید اصلی
        /// </summary>
        public Dictionary<string, ICacheMasterKeySetting>? CacheKeysSetting { get; }

    }
}
