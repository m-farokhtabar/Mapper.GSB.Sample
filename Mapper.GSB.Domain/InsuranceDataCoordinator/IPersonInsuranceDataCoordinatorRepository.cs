namespace Mapper.GSB.Domain.InsuranceDataCoordinator
{
    /// <summary>
    /// ریپو جهت ذخیره و بازیابی اطلاعات هماهنگ کننده
    /// </summary>
    public interface IPersonInsuranceDataCoordinatorRepository
    {
        /// <summary>
        /// ثبت اطلاعات هماهنگ کننده فرد و بیمه نامه
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task AddAsync(PersonInsuranceDataCoordinator entity);
        ///// <summary>
        ///// دریافت اطلاعات رکورد هماهنگ کننده بر اساس
        ///// شناسه منحصر به فرد ثبت اطلاعات بیمه شده در هاب بیمه مرکزی
        ///// </summary>
        ///// <param name="RegisterUID"></param>
        ///// <returns></returns>
        //Task<List<PersonInsuranceDataCoordinator>> FindByRegisterUIDAsync(Guid RegisterUID);
        /// <summary>
        /// دریافت اطلاعات رکورد هماهنگ کننده با شناسه اصلی مدل
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<PersonInsuranceDataCoordinator?> FindByIdAsync(Guid Id);
        /// <summary>
        /// به روز کردن نسخه های پایین تر زمانی که نسخه بالاتری به روز می شود
        /// </summary>
        /// <param name="version"></param>
        /// <param name="RegsiterUID"></param>
        /// <returns></returns>
        Task UpdateLowerVersionForGsb(int version, Guid RegsiterUID);
    }
}
