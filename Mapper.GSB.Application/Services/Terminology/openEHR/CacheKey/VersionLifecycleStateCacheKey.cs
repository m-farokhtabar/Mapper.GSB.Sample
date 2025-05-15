using Mapper.GSB.Application.SeedWork.Cache;
using openEHR.Library.Rm.DataTypes.Text;

namespace Mapper.GSB.Application.Services.Terminology.openEHR.CacheKey;

/// <summary>
/// کلید جهت دریافت و ارسال اطلاعات به کش
/// </summary>
public class VersionLifecycleStateCacheKey : CacheKey<List<DvCodedText>>
{
    /// <summary>
    /// ایجاد کلید بدون نیاز به زیر کلید
    /// </summary>
    public VersionLifecycleStateCacheKey()
    {

    }
    /// <summary>
    /// ایجاد کلید با توجه به زیر کلید مورد نظر
    /// </summary>
    /// <param name="SubKey"></param>
    public VersionLifecycleStateCacheKey(string SubKey)
    {
        this.SubKey = SubKey;
    }
    /// <summary>
    /// نام قسمت اصلی کلید
    /// </summary>
    public override string MasterKey => "VersionLifecycleState";
}
