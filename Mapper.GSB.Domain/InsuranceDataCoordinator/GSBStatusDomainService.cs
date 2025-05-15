using Mapper.GSB.Domain.Insurance;
using MOHME.Lib.Shared;

namespace Mapper.GSB.Domain.InsuranceDataCoordinator;

/// <summary>
/// ثبت وضعیت و پاسخ اطلاعات دریافتی از سرور
/// GSB
/// </summary>
public class GSBStatusDomainService : IGSBStatusDomainService
{
    /// <summary>
    /// ثبت اطلاعات پاسخ درخواست و وضعیت آن در مدل های هماهنگ کننده و سند بیمه
    /// </summary>
    /// <param name="coordinator"></param>
    /// <param name="personInsurance"></param>
    /// <param name="gSBDataVO"></param>
    /// <param name="jsonStringifyResult"></param>
    public void SaveStatus(PersonInsuranceDataCoordinator coordinator, PersonInsurance personInsurance, GSBDataVO gSBDataVO, string jsonStringifyResult)
    {
        //ثبت نتیجه درخواست ثبت اطلاعات به سرور بیمه سلامت در مدل هماهنگ کننده
        coordinator.SetStatusGSBServiceIsSucceessful(jsonStringifyResult, gSBDataVO.Igin?.ID, gSBDataVO.RegisterID);
        personInsurance.SetGSBDataVO(jsonStringifyResult, new GSBDataVO(gSBDataVO.Igin, gSBDataVO.RegisterID, gSBDataVO.RecommandMessage, gSBDataVO.RegisterDate));
        //ٍثبت نسخه جدید نمونه ویرایش در مدل هماهنگ کننده
        coordinator.SetPersonInsuranceVersion(personInsurance.Version);
    }
}
