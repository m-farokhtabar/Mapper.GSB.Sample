using Mapper.GSB.Domain.InsuranceDataCoordinator;

namespace Mapper.GSB.Application.SeedWorks.Providers.PersonInsuranceProvider;

/// <summary>
/// دریافت اطلاعات هماهنگ کننده
/// </summary>
public interface IPersonInsuranceDataCoordinatorProvider
{
    /// <summary>
    /// دریافت اطلاعات شناسه های ثبت شده در رکورد هماهنگ کننده بر اساس
    /// شناسه فرد
    /// </summary>
    /// <param name="personId"></param>
    /// <returns>شناسه های ثبت شده در رکورد هماهنگ کننده</returns>
    Task<List<PersonInsuranceIdentifiersDto>> FindIdentifiersByPersonIdAsync(string personId);
    /// <summary>
    /// دریافت اطلاعات شناسه های منحصر به فرد بیمه شده و بیمه نامه در هاب بیمه مرکزی
    /// رکوردهایی را در خروجی نمایش می دهد که حداقل وضعیت ثبت موفق اطلاعات بیمه شونده را در مخزن داده داشته باشد
    /// </summary>
    /// <param name="registerUID"></param>
    /// <returns>شناسه های ثبت شده در رکورد هماهنگ کننده</returns>
    Task<List<PersonInsuranceIdentifiersDto>> FindIdentifiersAtLeastHasSavePersonInopenEHRSuccessfulStatusByRegisterUIDAsync(Guid registerUID);
    /// <summary>
    /// دریافت اطلاعات بر اساس شناسه فرد شناسه شرکت بیمه و شناسه بیمه نامه
    /// </summary>
    /// <param name="personId"></param>
    /// <param name="insurerId"></param>
    /// <param name="policyUniqueCode"></param>    
    /// <returns></returns>
    Task<List<PersonInsuranceSaveIdentifiersDto>> FindByPersonIdAndInsurerIdAndPolicyUniqueCodeAsync(string personId, int insurerId, string policyUniqueCode);
    /// <summary>
    /// دریافت اطلاعات بر اساس شناسه فرد شناسه شرکت بیمه و شناسه بیمه نامه
    /// </summary>
    /// <param name="personId"></param>
    /// <param name="insurerId"></param>
    /// <param name="accountID"></param>
    /// <returns></returns>
    Task<List<PersonInsuranceSaveIdentifiersDto>> FindByPersonIdAndInsurerIdAndAccountIdAsync(string personId, int insurerId, string accountID);
    /// <summary>
    /// دریافت اطلاعات بر اساس شناسه منحصر به فرد ثبت اطلاعات بیمه شده در هاب بیمه مرکزی
    /// </summary>
    /// <param name="registerUID"></param>
    /// <returns></returns>
    Task<List<PersonInsuranceDataCoordinator>> FindByRegisterUIDAsync(Guid registerUID);
    /// <summary>
    /// دریافت اطلاعات بیمه نامه ها با توجه به تاریخ وارد شده
    /// </summary>
    /// <param name="date"></param>
    /// <param name="InsurerId"></param>
    /// <returns></returns>
    Task<List<PersonInsuranceDataCoordinator>> FindByCreatedDateAsync(DateTime date, int? InsurerId);
    /// <summary>
    /// دریافت اطلاعات بیمه نامه هایی که با توجه به تاریخ وارد شده
    /// </summary>
    /// <param name="date"></param>
    /// <param name="InsurerId"></param>
    /// <returns></returns>
    Task<List<PersonInsuranceDataCoordinator>> FindInsurancesWhichEncountersErrorByCreatedDateAsync(DateTime date, int? InsurerId);
    /// <summary>
    /// دریافت اطلاعات بر اساس شناسه منحصر به فرد بیمه و نوع شناسه بیمه شده
    /// </summary>
    /// <param name="PersonId"></param>
    /// <param name="PersonType"></param>
    /// <returns></returns>
    Task<List<PersonInsuranceDataCoordinator>> FindByPersonIdAndPersonTypeAsync(string PersonId, string PersonType);
}
