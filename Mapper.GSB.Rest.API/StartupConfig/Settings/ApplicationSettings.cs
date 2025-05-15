using Mapper.GSB.Application.GSBAPICaller.SeedWorks;
using Mapper.GSB.Application.SeedWorks;

namespace Mapper.GSB.Rest.API;

/// <summary>
/// تنظیمات برنامه
/// </summary>
public class ApplicationSettings : IInsuranceCompaniesIds
{
    /// <summary>
    /// کدهای مربوط به شرکت های بیمه خصوصی
    /// </summary>
    public Dictionary<string, int>? InsuranceCompaniesIds { get; init; }
}