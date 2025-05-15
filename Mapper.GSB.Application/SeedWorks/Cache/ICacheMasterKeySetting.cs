namespace Mapper.GSB.Application.SeedWork.Cache
{
    /// <summary>
    /// تنظیمات کش به ازای هر کلید اصلی
    /// </summary>
    public interface ICacheMasterKeySetting
    {
        /// <summary>
        /// نام اصلی کلید کش
        /// </summary>
        string MasterKey { get; }
        /// <summary>
        /// تعداد روز جهت پاک کردن کش
        /// در صورت درخواست کاربر به صورت اتوماتیک تعداد  روز تمدید می شود
        /// </summary>
        int ExpiredInDay { get; }
        /// <summary>
        /// تعداد روز جهت پاک کردن کش
        /// </summary>
        int AbsoluteExpiredInDay { get; }
        /// <summary>
        /// میزان اولیت کش زمانی که با کمبود رم مواجه هستیم
        /// 0 Low 1 Normal 2 High 3 NeverRemove
        /// </summary>
        int CachePriority { get; }
    }
}
