namespace Mapper.GSB.Application.Services.Terminology;
/// <summary>
/// دریافت اطلاعات ترمینولوزی های موجود
/// </summary>
public interface ITerminologyProvider
{
    /// <summary>
    /// دریافت تمامی کدهای و مجموعه یک مجموعه سیستمی
    /// </summary>
    /// <param name="CodeSystemUrl">آدرس مجموعه کد سیستم</param>
    /// <param name="CodeSystemVersion">نسخه</param>
    /// <returns></returns>
    Task<List<TerminologyDto>> Get(string CodeSystemUrl, string CodeSystemVersion);
}