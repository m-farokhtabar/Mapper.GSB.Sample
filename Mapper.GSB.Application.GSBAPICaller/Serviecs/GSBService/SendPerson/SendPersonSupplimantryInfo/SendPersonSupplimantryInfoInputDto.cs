using MOHME.Lib.Shared;

namespace Mapper.GSB.Application.GSBAPICaller.Serviecs.GSBService.SendPerson.SendPersonSupplimantryInfo;

/// <summary>
/// ورودی ارسال اطلاعات تکمیلی
/// </summary>
public class SendPersonSupplimantryInfoInputDto
{
    /// <summary>
    /// نام کاربری که در نرم افزار موسسه درخواست کننده سرویس وارد شده است
    /// </summary>
    public string? AppUser { get; set; }
    /// <summary>
    /// آدرس IPموسسه استفاده کننده از سرویس
    /// </summary>
    public string? ClientIp { get; set; }
    /// <summary>
    /// کد و نام سازمان بیمه‌گر تکمیلی در ترمینولوژی thritaEHR.insurer مکسا می‌باشد
    /// </summary>
    public DO_CODED_TEXT? InsuranceID { get; set; }
    /// <summary>
    /// شناسه ملی فرد یا شناسه اتباع بیگانه یا پاسپورت
    /// </summary>
    public DO_IDENTIFIER? PersonID { get; set; }
    /// <summary>
    /// نام بیمه شده
    /// </summary>
    public string? FirstName { get; set; }
    /// <summary>
    /// نام خانوادگی بیمه شده
    /// </summary>
    public string? LastName { get; set; }
    /// <summary>
    /// نام پدر بیمه شده
    /// </summary>
    public string? FatherName { get; set; }
    /// <summary>
    /// نشان‌دهنده جنسیت افراد است. کدهای مربوط به آن در thritaEHR.gender مکسا است.
    /// </summary>
    public DO_CODED_TEXT? Gender { get; set; }
    /// <summary>
    /// تاریخ تولد بیمه شده
    /// </summary>
    public DO_DATE? BirthDate { get; set; }
    /// <summary>
    /// این ویژگی نشان‌دهنده وضعیت تأهل فرد است. مقادیر مختلف آن در thritaEHR.maritalStatus مکسا است. (در صورت نداشتن با کد نامشخص تکمیل گردد)
    /// </summary>
    public DO_CODED_TEXT? Marital { get; set; }
    /// <summary>
    /// شناسه ملی سرپرست
    /// </summary>
    public DO_CODED_TEXT? RelationType { get; set; }
    /// <summary>
    /// شماره بیمه - در این پارامتر شناسه منحصر به فرد تراکنش خروجی سرویس هاب MessageUID قرار گیرد.
    /// </summary>
    public string? InsuranceNumber { get; set; }
    /// <summary>
    /// کد و عنوان نوع بیمه تکمیلی/فول درمان
    /// </summary>
    public DO_CODED_TEXT? InsuranceType { get; set; }
    /// <summary>
    /// تاریخ شروع اعتبار بیمه
    /// </summary>
    public DO_DATE? StartDate { get; set; }
    /// <summary>
    /// تاریخ پایان اعتبار بیمه (در صورتی که بخواهید بیمه شده از طریق پایگاه برخط خدمتی دریافت ننماید می بایست تاریخ اعتبار را به یک تاریخ گذشته مثلا روز قبل بروز رسانی نمایید )
    /// </summary>
    public DO_DATE? ExpireDate { get; set; }
    /// <summary>
    /// کد یکتای بیمه نامه (کد یکتای یازده رقمی صادر شده توسط بیمه مرکزی) 
    /// </summary>
    public string? PolicyUnqiueCode { get; set; }
    /// <summary>
    /// شماره چاپی بیمه نامه (شماره ی چاپ شده روی بیمه نامه که در هر شرکت بیمه یکتا ست)
    /// </summary>
    public string? PolicyPrintNumber { get; set; }
    /// <summary>
    /// کد پستی
    /// </summary>
    public string? PostalCode { get; set; }
    /// <summary>
    /// توضیحات
    /// </summary>
    public string? RecommandationMessage { get; set; }
    /// <summary>
    /// کد رایانه بیمه نامه در شرکت بیمه تکمیلی است.
    /// </summary>
    public string? CompanyPolicyId { get; set; }
    /// <summary>
    /// کد رایانه بیمه شده در شرکت بیمه تکمیلی است.
    /// </summary>
    public string? CompanyInsuredId { get; set; }
    /// <summary>
    /// نوع بیمه شده ( =1اصلی، =2تبعی)
    /// </summary>
    public string? InsuredType { get; set; }
    /// <summary>
    /// کدملی/کد اتباع/شماره پاسپورت بیمه شده اصلی - اجباری (اگر بیمه شده تبعی باشد این فیلد اجباری است.
    /// </summary>
    public DO_IDENTIFIER? MainInsuredNationCode { get; set; }
    /// <summary>
    /// نام بیمه گذار بیمه نامه(اگر بیمه گذار حقوقی باشد این فیلد اجباری است.) 
    /// </summary>
    public string? InsurerName { get; set; }
    /// <summary>
    /// شناسه ملی بیمه گذار حقوقی /   کدملی بیمه گذار حقیقی
    /// </summary>
    public string? InsurerNatoinalCode { get; set; }
}
