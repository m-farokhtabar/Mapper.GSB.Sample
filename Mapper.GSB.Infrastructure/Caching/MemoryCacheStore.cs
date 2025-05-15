using Mapper.GSB.Application.SeedWork.Cache;
using Microsoft.Extensions.Caching.Memory;
namespace Mapper.GSB.Infrastructure.Caching
{
    /// <summary>
    /// <see cref="ICacheStore"/>
    /// </summary>
    public class MemoryCacheStore : ICacheStore
    {
        private readonly IMemoryCache MemoryCache;
        private readonly Dictionary<string, ICacheMasterKeySetting>? ExpirationConfiguration;
        /// <summary>
        /// ایجاد کش
        /// </summary>
        /// <param name="MemoryCache"></param>
        /// <param name="CacheSetting"></param>
        public MemoryCacheStore(IMemoryCache MemoryCache, ICacheSetting CacheSetting)
        {
            this.MemoryCache = MemoryCache;
            ExpirationConfiguration = CacheSetting.CacheKeysSetting;
        }
        /// <summary>
        /// <see cref="ICacheStore.Add{TItem}(TItem, CacheKey{TItem})"/>
        /// </summary>
        /// <typeparam name="TItem"></typeparam>
        /// <param name="Item"></param>
        /// <param name="Key"></param>        
        public void Add<TItem>(TItem Item, CacheKey<TItem> Key)
        {
            /*
             *  absolute expiration
             * در اینجا به این معنا است که یک زمان قطعی را برای منقضی شدن کش‌ها مشخص میکند؛ 
             * به عبارتی میگوییم کش با کلید فلان، در تاریخ و ساعت فلان حذف شود
             *  اما در
             *  sliding expiration
             *  یک بازه زمانی برای منقضی شدن کش‌ها مشخص میکنیم؛ یعنی میگوییم بعد از گذشت فلان دقیقه از ایجاد کش، آن را حذف کن و اگر در طی این مدت مجددا خوانده شد، طول مدت زمان آن تمدید خواهد شد
             */
            var Setting = ExpirationConfiguration?[Key.MasterKey];
            if (Setting is not null)
            {
                MemoryCacheEntryOptions Options = new()
                {
                    Priority = (CacheItemPriority)Setting.CachePriority,
                    SlidingExpiration = TimeSpan.FromDays(Setting.ExpiredInDay),
                    AbsoluteExpiration = Setting.AbsoluteExpiredInDay > 0 ? DateTime.Now.AddDays(Setting.AbsoluteExpiredInDay) : null
                };
                this.MemoryCache.Set(Key.GetCacheKey(), Item, Options);
            }
            else
                this.MemoryCache.Set(Key.GetCacheKey(), Item);
            
        }
        /// <summary>
        /// <see cref="ICacheStore.GetOrCreateWithoutSlidingExpAndWithHourExpAsync{TItem}(CacheKey{TItem}, Func{Task{TItem}})"/>
        /// </summary>
        /// <typeparam name="TItem"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<TItem?> GetOrCreateWithoutSlidingExpAndWithHourExpAsync<TItem>(CacheKey<TItem> key, Func<Task<TItem>> factory) where TItem : class
        {
            return await MemoryCache.GetOrCreateAsync(key.GetCacheKey(), async entry =>
            {
                var Setting = ExpirationConfiguration?[key.MasterKey];
                if (Setting is not null)
                {
                    entry.Priority = (CacheItemPriority)Setting.CachePriority;
                    entry.SlidingExpiration = null;
                    entry.AbsoluteExpiration = Setting.AbsoluteExpiredInDay > 0 ? DateTime.Now.AddHours(Setting.AbsoluteExpiredInDay) : null;
                }
                return await factory();
            });
        }
        /// <summary>
        /// <see cref="ICacheStore.Get{TItem}(CacheKey{TItem})"/>
        /// </summary>
        /// <typeparam name="TItem"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public TItem? Get<TItem>(CacheKey<TItem> key) where TItem : class => MemoryCache.TryGetValue(key.GetCacheKey(), out TItem? value) ? value : null;
        /// <summary>
        /// <see cref="ICacheStore.Remove{TItem}(CacheKey{TItem})"/>
        /// </summary>
        /// <typeparam name="TItem"></typeparam>
        /// <param name="key"></param>
        public void Remove<TItem>(CacheKey<TItem> key) => MemoryCache.Remove(key.GetCacheKey());
    }
}