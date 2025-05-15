using Mapper.GSB.Domain.InsuranceDataCoordinator;

namespace Mapper.GSB.Application.SeedWorks.Providers.PersonInsuranceProvider;

/// <summary>
/// شناسه مورد نیاز جهت بررسی درخواست ثبت
/// </summary>
public class PersonInsuranceSaveIdentifiersDto
{   
    /// <summary>
    /// شناسه
    /// </summary>
    public Guid Id { get; init; }
    /// <summary>
    /// نسخه
    /// </summary>
    public int Version { get; init; }
    /// <summary>
    /// شناسه ثبت شده برای سند بیمه در بیمه مرکزی
    /// </summary>
    public Guid RegisterUID { get; set; }
    /// <summary>
    /// شناسه ثبت شده برای سند بیمه در بیمه مرکزی
    /// </summary>
    public Guid MessageUID { get; set; }
}
