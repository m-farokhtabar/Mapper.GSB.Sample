namespace Mapper.GSB.Application.SeedWork.Cache
{
    /// <summary>
    /// ایجاد نام کش
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    public abstract class CacheKey<TItem>
    {
        /// <summary>
        /// کلید کش
        /// تنظیمات کش بر اساس این کلید است
        /// <seealso cref="ICacheMasterKeySetting"/>
        /// </summary>
        public virtual string MasterKey { get; protected private set; } = string.Empty;
        /// <summary>
        /// زیر کلید کش
        /// </summary>
        public string? SubKey { get; set; }
        /// <summary>
        /// کلید جهت کش
        /// </summary>
        /// <returns></returns>
        public string GetCacheKey() => !string.IsNullOrWhiteSpace(SubKey) ? MasterKey + "." + SubKey : MasterKey;
    }
}