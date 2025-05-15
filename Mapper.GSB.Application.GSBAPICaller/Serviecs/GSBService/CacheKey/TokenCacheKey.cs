using Mapper.GSB.Application.GSBAPICaller.Serviecs.GSBService.ResponseBody;
using Mapper.GSB.Application.GSBAPICaller.Serviecs.GSBService.Token;
using Mapper.GSB.Application.SeedWork.Cache;

namespace Mapper.GSB.Application.GSBAPICaller.Serviecs.GSBService.CacheKey;

/// <summary>
/// کلید جهت دریافت و ارسال اطلاعات به کش
/// </summary>
public class TokenCacheKey : CacheKey<RootResultDto<TokenResultDto>>
{
    /// <summary>
    /// ایجاد کلید بدون نیاز به زیر کلید
    /// </summary>
    public TokenCacheKey()
    {

    }
    /// <summary>
    /// ایجاد کلید با توجه به زیر کلید مورد نظر
    /// </summary>
    /// <param name="SubKey"></param>
    public TokenCacheKey(string SubKey)
    {
        this.SubKey = SubKey;
    }
    /// <summary>
    /// نام قسمت اصلی کلید
    /// </summary>
    public override string MasterKey => "Token";
}