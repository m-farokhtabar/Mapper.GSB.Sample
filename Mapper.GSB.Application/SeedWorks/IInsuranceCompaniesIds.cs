namespace Mapper.GSB.Application.SeedWorks;

/// <summary>
/// لیست شناسه های بیمه های خصوصوی مورد تایید جهت ثبت اطلاعات
/// </summary>
public interface IInsuranceCompaniesIds
{
    /// <summary>
    /// کدهای مربوط به شرکت های بیمه خصوصی
    /// </summary>
    public Dictionary<string, int>? InsuranceCompaniesIds { get; init; }
}
