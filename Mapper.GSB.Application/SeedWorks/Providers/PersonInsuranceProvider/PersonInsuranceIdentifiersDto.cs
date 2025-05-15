using Mapper.GSB.Domain.InsuranceDataCoordinator;

namespace Mapper.GSB.Application.SeedWorks.Providers.PersonInsuranceProvider;

/// <summary>
/// شناسه های مورد نیاز سند بیمه و فرد
/// </summary>
public class PersonInsuranceIdentifiersDto
{   
    /// <summary>
    /// شناسه
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
     /// شناسه ملی فرد یا شناسه اتباع بیگانه یا پاسپورت  (مطابق با شناسه های حوزه سلامت)    
     /// </summary>
    public string PersonId { get; set; } = string.Empty;
    /// <summary>
    /// نوع شناسه انتخابی
    /// </summary>
    ///<remarks>type = nationalCode</remarks>
    public string? PersonIdType {get; set;}
    /// <summary>
    /// شناسه ثبت شده در 
    /// openEHR
    /// برای شخص مورد نظر
    /// </summary>
    public string? openEHRPartyId { get; set;}
    /// <summary>
    /// شناسه ثبت شده در 
    /// openEHR
    /// برای روکش سند مورد نظر
    /// </summary>
    public string? openEHRPartyRelationshipId { get; set; }
    /// <summary>
    /// وضعیت فعلی سند بیمه
    /// </summary>
    public InsuranceDataStatus Status { get; set; }
    /// <summary>
    /// شناسه ثبت شده برای سند بیمه در بیمه مرکزی
    /// </summary>
    public Guid RegisterUID { get; set; }

}
