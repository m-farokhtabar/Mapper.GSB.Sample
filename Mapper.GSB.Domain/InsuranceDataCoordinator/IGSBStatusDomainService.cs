using Mapper.GSB.Domain.Insurance;
using MOHME.Lib.Shared;

namespace Mapper.GSB.Domain.InsuranceDataCoordinator;

/// <summary>
/// ثبت وضعیت و پاسخ اطلاعات دریافتی از سرور
/// GSB
/// </summary>
public interface IGSBStatusDomainService
{
    /// <summary>
    /// ثبت اطلاعات پاسخ درخواست و وضعیت آن در مدل های هماهنگ کننده و سند بیمه
    /// </summary>
    /// <param name="coordinator"></param>
    /// <param name="personInsurance"></param>
    /// <param name="gSBDataVO"></param>
    /// <param name="jsonStringifyResult"></param>
    void SaveStatus(PersonInsuranceDataCoordinator coordinator, PersonInsurance personInsurance, GSBDataVO gSBDataVO, string jsonStringifyResult);
}