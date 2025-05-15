using System.ComponentModel.DataAnnotations;

namespace MOHME.Lib.Shared
{
    /// <summary>
    /// 
    /// </summary>
    public enum SepasErrorCodes
    {
        /// <summary>
        /// خطاهای اعتبار سنجی تاریخ‌ها در پرونده
        /// </summary>
        [Display(Name = "DataValidationError", Description = "Date validation failed")]
        DataValidationError = 1,
        /// <summary>
        /// خطاهای مرتبط به نگاشت بین اقلام اطلاعاتی کد شده موجود در سیستم با کدهای استاندارد سپاس
        /// </summary>
        [Display(Name = "MappingError", Description = "Please check correct coding at maxa.behdasht.gov.ir")]
        MappingError = 2,
        /// <summary>
        /// خطاهای مرتبط با ماژول مکان‌یاب نود‌های سپاس است که تشخیص می دهد پرونده هر فرد در کدام نود ذخیره شده است.
        /// </summary>
        [Display(Name = "LocatorError", Description = "Error inquiring Patient Master Index")]
        NationalLocatorError = 3,
        /// <summary>
        /// Master locator id allocation error
        /// </summary>
        [Display(Name = "StructureError", Description = "Data structure error")]
        StructureError = 4,
        /// <summary>
        /// ماژول مکان‌یاب مرکزی که Master Locator نامیده می‌شود که Routing پرونده‌ها روی نودها از طریق آن انجام می‌شود.
        /// </summary>
        [Display(Name = "NationalLocator", Description = "Error inquiring Patient Master Index")]
        LocatorError = 5,
        /// <summary>
        /// اقلام اطلاعاتی که اجباری هستند، اگر تکمیل نشوند در این دسته قرار می‌گیرند.
        /// </summary>
        [Display(Name = "MandatoryError", Description = "Field required error")]
        MandatoryError = 6,
        /// <summary>
        /// محتوای اشتباه روی هر کدام از این فیلدهای اطلاعاتی
        /// </summary>
        [Display(Name = "WrongData", Description = "Field content validation error")]
        WrongData = 7,
        /// <summary>
        /// خطاهایی که مربوط به اشکالات در نودهای سپاس می‌شود.
        /// </summary>
        [Display(Name = "DB", Description = "Sepas DB transaction error")]
        DB = 8,
        /// <summary>
        /// خطای محاسبات است که بیشتر در ارتباط با محاسبات صورت حساب کاربرد دارد
        /// </summary>
        [Display(Name = "Calculation", Description = "Data Calculation error")]
        Calculation = 9,

        /// <summary>
        /// در ارتباط با منطق عملکرد نرم‌افزار است که نرم‌افزار باید حداقل یک سری از موارد را چک کند و درست کار کند تا بتواند خروجی درست بگیرد.
        /// </summary>
        [Display(Name = "LogicError", Description = "Sepas DB transaction error")]
        LogicError = 10,

        /// <summary>
        /// SystemID(شناسه یکتای نرم افزار اطلاعات مرکز درمانی)هایی که بسته شوند به عبارتی اجازه ارسال اطلاعات از آنها سلب شود، اصطلاحاً Block می‌شوند
        /// </summary>
        [Display(Name = "SepasBlock", Description = "System id has been blocked!")]
        SepasBlock = 11,

        /// <summary>
        /// خطاهای مرتبط با برقراری ارتباط بین سیستم مربوط به ارسال اطلاعات، نود دانشگاهی، نود سپاس وزارت بهداشت و یا خطوط ارتباطی فی مابین می باشد.
        /// </summary>
        [Display(Name = "Network", Description = "System id has been blocked!")]
        Network = 12,
        /// <summary>
        /// خطاهایی که وابستگی مستقیم به ورژن مورد استفاده در نرم افزار مبدا یا مقصد دارد.
        /// </summary>
        [Display(Name = "System", Description = "System has been blocked!")]
        System = 13,
        /// <summary>
        /// خطاهایی که وابستگی مستقیم به ورژن مورد استفاده در نرم افزار مبدا یا مقصد دارد.
        /// </summary>
        [Display(Name = "Healthcare Facility validation error", Description = "Healthcare Facility id is not valid!")]
        HCFI = 14,
        /// <summary>
        /// خطاهای مرتبط با دیتای ورودی سرویس های سپاس
        /// </summary>
        [Display(Name = "InputDataError", Description = "Input Data Error")]
        InputDataError = 15,

        /// <summary>
        /// خطاهای مرتبط با فرمت دیتای ورودی سرویس های سپاس
        /// </summary>
        [Display(Name = "DataFormatError", Description = "Data Format Error")]
        DataFormatError = 16,

        /// <summary>
        /// خطاهای نامشخص
        /// </summary>
        [Display(Name = "UnknownError", Description = "Unknown Error")]
        UnknownError = 17,
    }
}
