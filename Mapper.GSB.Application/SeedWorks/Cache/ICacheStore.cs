using Mapper.openEHR.SeedWork.Cache;

namespace Mapper.GSB.Application.SeedWork.Cache
{
    /// <summary>
    /// مدیریت و نگهداری اطلاعات کش
    /// </summary>
    public interface ICacheStore
    {
        /// <summary>
        /// اضاه نمودن اطلاعات به کش
        /// </summary>
        /// <typeparam name="TItem"></typeparam>
        /// <param name="Item">محتویات کش</param>
        /// <param name="Key">کلید کش</param>
        void Add<TItem>(TItem Item, CacheKey<TItem> Key);
        /// <summary>
        /// دریافت اطلاعات از کش
        /// </summary>
        /// <typeparam name="TItem"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        TItem? Get<TItem>(CacheKey<TItem> key) where TItem : class;
        /// <summary>
        /// حدف اطلاعات از کش
        /// </summary>
        /// <typeparam name="TItem"></typeparam>
        /// <param name="key"></param>
        void Remove<TItem>(CacheKey<TItem> key);
        /// <summary>
        /// دریاقت یا درج اطلاعات در کش
        /// دراین حالت از تاریخ انقضا اسلایدی پشتیبان نمی شود
        /// همچنین تاریخ انقضا به صورت ساعت است می باشد
        /// </summary>
        /// <typeparam name="TItem"></typeparam>
        /// <param name="key"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        Task<TItem?> GetOrCreateWithoutSlidingExpAndWithHourExpAsync<TItem>(CacheKey<TItem> key, Func<Task<TItem>> factory) where TItem : class;
    }
}