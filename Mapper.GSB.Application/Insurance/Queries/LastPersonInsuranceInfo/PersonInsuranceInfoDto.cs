using Mapper.GSB.Application.Insurance.Queries.Status;
using MOHME.Lib.Shared;

namespace Mapper.GSB.Application.Insurance.Queries.LastPersonInsuranceInfo
{
    /// <summary>
    /// خلاصه اطلاعات بیمه نامه
    /// </summary>
    public class PersonInsuranceInfoDto
    {
        /// <summary>
        /// وضعیت درخواست
        /// </summary>
        public StatusType Status { get; init; }
        /// <summary>
        /// توضیحات وضعیت درخواست
        /// </summary>
        public string? StatusMessage { get; init; }
        /// <summary>
        /// شناسه منحصر به فرد ثبت اطلاعات بیمه شده در هاب بیمه مرکزی است که به ازای هر بیمه شده  در داده پیام  ارسالی به سیستم بازگردانده میشود. سیستمهای جامع بیمه گری شرکت ها باید این شناسه ثبت را در سیستم خود نگهداری کنند.
        /// </summary>
        public string? RegisterUID { get; init; }
        /// <summary>
        /// کد شرکت بیمه تکمیلی/فول درمان در مکسا
        /// </summary>
        /// <remarks>به صورت جی سان نگهداری می شود</remarks>
        public DO_CODED_TEXT? Insurer { get; init; }
        /// <summary>
        /// کد یکتای بیمه نامه (کد یکتای یازده رقمی صادر شده توسط بیمه مرکزی) 
        /// </summary>
        public string? PolicyUniqueCode { get; init; }
        /// <summary>
        /// تاریخ پایان اعتبار بیمه (در صورتی که بخواهید بیمه شده از طریق پایگاه برخط خدمتی دریافت ننماید می بایست تاریخ اعتبار را به یک تاریخ گذشته مثلا روز قبل بروز رسانی نمایید )
        /// </summary>
        public DO_DATE? InsuranceExpirationDate { get; init; }
        /// <summary>
        /// نوع بیمه نامه فول درمان یا تکمیلی مرتبط با بیمه شده می باشد. این ویژگی مطابق با جدول hltHub.policyType تکمیل گردد.  برای بیمه نامه درمان تکمیلی از مقدار SendPersonSupplimantryInfo  ( کد 1)  و  برای بیمه نامه فول درمان از مقدار SendPersonInfo (کد 2) استفاده گردد.
        /// </summary>
        public DO_CODED_TEXT? PolicyType { get; init; }
        /// <summary>
        /// شماره سریال مرتبط با صندوق یا خدمت ثبت شده برای این بیمه شده در نرم افزار بیمه گری
        /// </summary>
        public string? AccountID { get; init; }
        /// <summary>
        /// کد رایانه بیمه شده در شرکت بیمه تکمیلی/فول درمان است
        /// </summary>
        public string? CompanyInsuredId { get; init; }
        /// <summary>
        /// کد رایانه بیمه نامه در شرکت بیمه تکمیلی/فول درمان است.
        /// </summary>
        public string? CompanyPolicyId { get; init; }  
    }
}
