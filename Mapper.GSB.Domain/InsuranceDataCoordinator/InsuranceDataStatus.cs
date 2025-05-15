namespace Mapper.GSB.Domain.InsuranceDataCoordinator;

/// <summary>
/// وضعیت فعلی داده های بیمه که در کدام مرحله است
/// </summary>
public enum InsuranceDataStatus
{
    /// <summary>
    /// به معنی دریافت داده ها از بیمه های تکمیلی است
    /// ثبت اطلاعات به صورت رویداد و همچنین ثبت اطلاعات هماهنگ کننده
    /// </summary>
    Recieved,
    /// <summary>
    /// ارسال اطلاعات به سازمان بیمه سلامت با موفقیت انجام نشده است
    /// </summary>
    SentToGSBServiceIsUnSucceessful,
    /// <summary>
    /// ارسال اطلاعات به سازمان بیمه سلامت با موفقیت انجام شده است
    /// </summary>
    SentToGSBServiceIsSucceessful,
    /// <summary>
    /// درج اطلاعات شخص در ریپو 
    /// openEHR
    /// موفقیت آمیز نبوده است
    /// </summary>
    SavePersonInopenEHRRepositoryIsUnSucceessful,
    /// <summary>
    /// درج اطلاعات شخص در ریپو 
    /// openEHR
    /// موفقیت آمیز بوده است
    /// </summary>
    SavePersonInopenEHRRepositoryIsSucceessful,
    /// <summary>
    /// درج اطلاعات بیمه و متا دیتا ها و تمامی اطالات مرتبط در ریپو 
    /// openEHR
    /// موفقیت آمیز نبوده است
    /// </summary>
    SaveInsurnaceDataInopenEHRRepositoryIsUnSucceessful,
    /// <summary>
    /// درج اطلاعات به طور کامل انجام شده است
    /// یعنی درج اطلاعات بیمه نیز به طور کامل انجام شده است
    /// </summary>
    Done
}
