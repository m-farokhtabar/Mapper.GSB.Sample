using MOHME.Lib.Shared;

namespace Mapper.GSB.Application.GSBAPICaller.Serviecs.GSBService.SendPerson.SendPersonInfo
{
    /// <summary>
    /// ورودی سرویس ارسال فول درمان
    /// </summary>
    public class SendPersonInfoInputDto
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
        public DO_CODED_TEXT? InsurerID { get; set; }
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
        /// جنسیت سرپرست
        /// </summary>
        public DO_IDENTIFIER? ResponsibleID { get; set; }
        /// <summary>
        /// نام بیمه شده اصلی
        /// </summary>
        public DO_CODED_TEXT? ResponsibleGender { get; set; }
        /// <summary>
        /// نام خانوادگی بیمه شده اصلی
        /// </summary>
        public string? ResponsibleFirstName { get; set; }
        /// <summary>
        /// شماره بیمه --- id کد یکتای بیمه نامه  (کد یکتای یازده رقمی صادر شده توسط بیمه مرکزی) برای استفاده از این ویژگی Issuer و Assigner این شناسه را با مقدار CENTINSUR و Type آن را با عبارت policyUniqueCode تکمیل نمائید.
        /// </summary>
        public string? ResponsibleLastName { get; set; }
        /// <summary>
        /// شماره بیمه انحصاری بیمه شده -- id کد رایانه بیمه شده در شرکت بیمه تکمیلی. برای استفاده از این ویژگی Issuer و Assigner این شناسه را با مقدار SupplementaryInsurer و Type آن را با عبارت companyInsuredId تکمیل نمائید.
        /// </summary>
        public DO_IDENTIFIER? InsuranceNumber { get; set; }
        /// <summary>
        /// کد و عنوان نوع بیمه تکمیلی/فول درمان
        /// </summary>
        public DO_IDENTIFIER? InsuranceNumber2 { get; set; }
        /// <summary>
        /// کد و عنوان نوع بیمه تکمیلی/فول درمان
        /// </summary>
        public DO_CODED_TEXT? InsuranceType { get; set; }
        /// <summary>
        /// تاریخ پایان اعتبار بیمه (در صورتی که بخواهید بیمه شده از طریق پایگاه برخط خدمتی دریافت ننماید می بایست تاریخ اعتبار را به یک تاریخ گذشته مثلا روز قبل بروز رسانی نمایید )
        /// </summary>
        public DO_DATE? ExpireDate { get; set; }
        /// <summary>
        /// کد و عنوان شعبه محل صدور بیمه
        /// </summary>
        public DO_CODED_TEXT? Branch { get; set; }
        /// <summary>
        /// کد و عنوان استان محل صدور بیمه
        /// </summary>
        public DO_CODED_TEXT? Province { get; set; }
        /// <summary>
        /// کد و عنوان استان محل صدور بیمه
        /// </summary>
        public DO_CODED_TEXT? ProvinceVB { get; set; }
        /// <summary>
        /// کد و عنوان شهر محل صدور بیمه
        /// </summary>
        public DO_CODED_TEXT? City { get; set; }
        /// <summary>
        /// شماره تلفن همراه بیمه شده
        /// </summary>
        public string? Mobile { get; set; }
        /// <summary>
        /// آدرس بیمه شده
        /// </summary>
        public string? Address { get; set; }
        /// <summary>
        /// کد پستی
        /// </summary>
        public string? PostalCode { get; set; }
        /// <summary>
        /// تصویر بیمه شده
        /// </summary>
        public string? PictureB64 { get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string? RecommandationMessage { get; set; }
        /// <summary>
        /// نام بیمه شده به انگلیسی
        /// </summary>
        public string? FirstNameEnc { get; set; }
        /// <summary>
        /// نام خانوادگی بیمه شده به انگلیسی
        /// </summary>
        public string? LastNameEnc { get; set; }
        /// <summary>
        /// شماره انگلیسی شخص -- در این پارامتر شناسه منحصر به فرد تراکنش خروجی سرویس هاب MessageUID قرار گیرد.
        /// </summary>
        public string? PersonIDEnc { get; set; }
        /// <summary>
        /// شماره idNumber  
        /// </summary>
        public string? IdNumber { get; set; }
        /// <summary>
        /// کد و عنوان کارگاه یا اداره بیمه شده
        /// </summary>
        public DO_CODED_TEXT? WorkShop { get; set; }
        /// <summary>
        /// فرانشیز
        /// </summary>
        public string? Feranshiz { get; set; }
        /// <summary>
        /// شناسه متمرکز بیمه سلامت – در صورتی که قبلا دریافت کرده اید
        /// </summary>
        public DO_IDENTIFIER? Igin { get; set; }
        /// <summary>
        /// مشخصات صندوق های مرتبط با بیمه شده به صورت آرایه ای
        /// </summary>
        public List<AccountVoDto>? Account { get; set; }

    }
    /// <summary>
    /// مشخصات صندوق های مرتبط با بیمه شده
    /// </summary>
    public class AccountVoDto
    {
        /// <summary>
        /// شناسه ملی فرد یا شناسه اتباع بیگانه یا پاسپورت
        /// </summary>
        public DO_IDENTIFIER? PersonID { get; set; }
        /// <summary>
        /// شماره سریال مرتبط با صندوق یا خدمت ثبت شده برای این بیمه شده در نرم افزار بیمه گری
        /// </summary>
        public string? AccountID { get; set; }
        /// <summary>
        /// کد نوع صندوق – خدمت ، از  ترمینولوژی thritaEHR.insuranceBox استفاده گردد و برای بیمه فول درمان اجباری است.
        /// </summary>
        public DO_CODED_TEXT? AccountType { get; set; }
        /// <summary>
        /// تاریخ ایجاد-چاپ – تمدید
        /// </summary>
        public DO_DATE? CreateDate { get; set; }
        /// <summary>
        /// سابقه بیمه در این نوع صندوق یا خدمت -روز
        /// </summary>
        public int? InsuranceLength { get; set; }
        /// <summary>
        /// تاریخ اولین ثبت نام برای این نوع خدمت
        /// </summary>
        public DO_DATE? InitiateDate { get; set; }
        /// <summary>
        /// حداقل مدت انتظار از تاریخ شروع جهت ارایه خدمت - روز
        /// </summary>
        public int? WaitingLength { get; set; }
        /// <summary>
        /// تاریخ شروع اعتبار
        /// </summary>
        public DO_DATE? ActiveFrom { get; set; }
        /// <summary>
        /// تاریخ پایان اعتبار
        /// </summary>
        public DO_DATE? ActiveTo { get; set; }
        /// <summary>
        /// وضعیت اعتباری صندوق یا خدمت -معتبر -غیر معتبر 
        /// </summary>
        public DO_CODED_TEXT? AccountStatus { get; set; }
    }
}
