using MOHME.Lib.Shared;
using MOHME.Lib.Helper.Validator;
namespace Mapper.GSB.Application.Insurance.Commands.Save;
/// <summary>
/// کلاس اصلی مربوط به اطلاعات بیمه نامه بیمه شده می باشد
/// </summary>
public class PersonPolicyVODto
{
    /// <summary>
    /// ایجاد شی
    /// </summary>
    /// <param name="insurer"></param>
    /// <param name="policyType"></param>
    /// <param name="policyUniqueCode"></param>
    /// <param name="effectiveDate"></param>
    /// <param name="insuranceExpirationDate"></param>
    /// <param name="insuranceBox"></param>
    /// <param name="relationType"></param>
    /// <param name="policyPrintNumber"></param>
    /// <param name="companyPolicyId"></param>
    /// <param name="companyInsuredId"></param>
    /// <param name="insuredType"></param>
    /// <param name="responsibleID"></param>
    /// <param name="responsibleGender"></param>
    /// <param name="responsibleFirstName"></param>
    /// <param name="responsibleLastName"></param>
    /// <param name="insurerName"></param>
    /// <param name="insurerNationalCode"></param>
    /// <param name="policyIssueDate"></param>
    /// <param name="baseInsurer"></param>
    /// <param name="provinceBranch"></param>
    /// <param name="cityBranch"></param>
    /// <param name="branch"></param>
    /// <param name="recommendationMessage"></param>
    /// <param name="planId"></param>
    /// <param name="requestReason"></param>
    /// <param name="isCoverageUnlimited"></param>
    /// <param name="policyVerNo"></param>
    /// <param name="policyVerUniqueCode"></param>
    /// <param name="contractType"></param>
    /// <param name="shebaNo"></param>
    /// <param name="bankAcc"></param>
    /// <param name="accNo"></param>
    /// <param name="deathDate"></param>
    /// <param name="workShop"></param>
    /// <param name="feranshiz"></param>
    /// <param name="account"></param>
    public PersonPolicyVODto(DO_CODED_TEXT? insurer, DO_CODED_TEXT? policyType, string? policyUniqueCode, DO_DATE? effectiveDate, DO_DATE? insuranceExpirationDate, DO_CODED_TEXT? insuranceBox,
                                   DO_CODED_TEXT? relationType, string? policyPrintNumber, string? companyPolicyId, string? companyInsuredId, int? insuredType, DO_IDENTIFIER? responsibleID,
                                   DO_CODED_TEXT? responsibleGender, string? responsibleFirstName, string? responsibleLastName, string? insurerName, string? insurerNationalCode, DO_DATE? policyIssueDate,
                                   DO_CODED_TEXT? baseInsurer, DO_CODED_TEXT? provinceBranch, DO_CODED_TEXT? cityBranch, DO_CODED_TEXT? branch, string? recommendationMessage, DO_CODED_TEXT? planId,
                                   DO_CODED_TEXT? requestReason, bool? isCoverageUnlimited, string? policyVerNo, string? policyVerUniqueCode, DO_CODED_TEXT? contractType, string? shebaNo,
                                   DO_CODED_TEXT? bankAcc, string? accNo, DO_DATE? deathDate, DO_CODED_TEXT? workShop, string? feranshiz, List<AccountVODto>? account)
    {        
        Insurer = insurer is not null && insurer.areAllPropsNullOrEmpty() ? null : insurer;
        PolicyType = policyType is not null && policyType.areAllPropsNullOrEmpty() ? null : policyType;
        PolicyUniqueCode = policyUniqueCode;        
        EffectiveDate = effectiveDate is not null && effectiveDate.areAllPropsNullOrEmpty() ? null : effectiveDate;
        InsuranceExpirationDate = insuranceExpirationDate is not null && insuranceExpirationDate.areAllPropsNullOrEmpty() ? null : insuranceExpirationDate;        
        InsuranceBox = insuranceBox is not null && insuranceBox.areAllPropsNullOrEmpty() ? null : insuranceBox;
        RelationType = relationType is not null && relationType.areAllPropsNullOrEmpty() ? null : relationType;
        PolicyPrintNumber = policyPrintNumber;
        CompanyPolicyId = companyPolicyId;
        CompanyInsuredId = companyInsuredId;
        InsuredType = insuredType;        
        ResponsibleID = responsibleID is not null && responsibleID.areAllPropsNullOrEmpty() ? null : responsibleID;        
        ResponsibleGender = responsibleGender is not null && responsibleGender.areAllPropsNullOrEmpty() ? null : responsibleGender;
        ResponsibleFirstName = responsibleFirstName;
        ResponsibleLastName = responsibleLastName;
        InsurerName = insurerName;
        this.insurerNationalCode = insurerNationalCode;        
        PolicyIssueDate = policyIssueDate is not null && policyIssueDate.areAllPropsNullOrEmpty() ? null : policyIssueDate;        
        BaseInsurer = baseInsurer is not null && baseInsurer.areAllPropsNullOrEmpty() ? null : baseInsurer;        
        ProvinceBranch = provinceBranch is not null && provinceBranch.areAllPropsNullOrEmpty() ? null : provinceBranch;        
        CityBranch = cityBranch is not null && cityBranch.areAllPropsNullOrEmpty() ? null : cityBranch;        
        Branch = branch is not null && branch.areAllPropsNullOrEmpty() ? null : branch;
        RecommendationMessage = recommendationMessage;        
        PlanId = planId is not null && planId.areAllPropsNullOrEmpty() ? null : planId;        
        RequestReason = requestReason is not null && requestReason.areAllPropsNullOrEmpty() ? null : requestReason;
        IsCoverageUnlimited = isCoverageUnlimited;
        PolicyVerNo = policyVerNo;
        PolicyVerUniqueCode = policyVerUniqueCode;        
        ContractType = contractType is not null && contractType.areAllPropsNullOrEmpty() ? null : contractType;
        ShebaNo = shebaNo;        
        BankAcc = bankAcc is not null && bankAcc.areAllPropsNullOrEmpty() ? null : bankAcc;
        AccNo = accNo;        
        DeathDate = deathDate is not null && deathDate.areAllPropsNullOrEmpty() ? null : deathDate;        
        WorkShop = workShop is not null && workShop.areAllPropsNullOrEmpty() ? null : workShop;
        Feranshiz = feranshiz;
        //برای بیمه نامه فول درمان با کد دو الزامی است
        if (policyType is not null && !string.IsNullOrEmpty(policyType.Coded_string) && policyType.Coded_string.Trim() == "2")
            Account = account;
        else
            Account = null;
    }

    /// <summary>
    /// کد شرکت بیمه تکمیلی/فول درمان در مکسا
    /// </summary>
    public DO_CODED_TEXT? Insurer { get; private set; }
    /// <summary>
    /// نوع بیمه نامه فول درمان یا تکمیلی مرتبط با بیمه شده می باشد. این ویژگی مطابق با جدول hltHub.policyType تکمیل گردد.  برای بیمه نامه درمان تکمیلی از مقدار SendPersonSupplimantryInfo  ( کد 1)  و  برای بیمه نامه فول درمان از مقدار SendPersonInfo (کد 2) استفاده گردد.
    /// </summary>
    public DO_CODED_TEXT? PolicyType { get; private set; }
    /// <summary>
    /// کد یکتای بیمه نامه (کد یکتای یازده رقمی صادر شده توسط بیمه مرکزی) 
    /// </summary>
    public string? PolicyUniqueCode { get; private set; }
    /// <summary>
    /// تاریخ شروع اعتبار بیمه شده -(الزاماً با شروع بیمه نامه بیمه گذار  StartDate یکی نمی باشد.)
    /// </summary>
    public DO_DATE? EffectiveDate { get; private set; }
    /// <summary>
    /// تاریخ پایان اعتبار بیمه (در صورتی که بخواهید بیمه شده از طریق پایگاه برخط خدمتی دریافت ننماید می بایست تاریخ اعتبار را به یک تاریخ گذشته مثلا روز قبل بروز رسانی نمایید )
    /// </summary>
    public DO_DATE? InsuranceExpirationDate { get; private set; }
    /// <summary>
    /// صندوق بيمه فرد را مشخص ميکند.چنانچه برخي از سازمانهاي بيمه گر، صندوق خاصي نداشته باشند، اين ويژگي مقدار تهي خواهد داشت
    /// </summary>
    public DO_CODED_TEXT? InsuranceBox { get; private set; }
    /// <summary>
    /// کد و عنوان نسبت بیمه شده با سرپرست  که مربوط به PersonPersonRelationType مکسا است
    /// </summary>
    public DO_CODED_TEXT? RelationType { get; private set; }
    /// <summary>
    /// شماره چاپی بیمه نامه (شماره ی چاپ شده روی بیمه نامه که در هر شرکت بیمه یکتا ست)
    /// </summary>
    public string? PolicyPrintNumber { get; private set; }
    /// <summary>
    /// کد رایانه بیمه نامه در شرکت بیمه تکمیلی/فول درمان است.
    /// </summary>
    public string? CompanyPolicyId { get; private set; }
    /// <summary>
    /// کد رایانه بیمه شده در شرکت بیمه تکمیلی/فول درمان است.
    /// </summary>
    public string? CompanyInsuredId { get; private set; }
    /// <summary>
    /// نوع بیمه شده ( =1اصلی، =2تبعی)
    /// </summary>
    public int? InsuredType { get; private set; }
    /// <summary>
    /// کدملی/کد اتباع/شماره پاسپورت بیمه شده اصلی
    /// </summary>
    public DO_IDENTIFIER? ResponsibleID { get; private set; }
    /// <summary>
    /// جنسیت بیمه شده اصلی
    /// </summary>
    public DO_CODED_TEXT? ResponsibleGender { get; private set; }
    /// <summary>
    /// نام بیمه شده اصلی
    /// </summary>
    public string? ResponsibleFirstName { get; private set; }
    /// <summary>
    /// نام خانوادگی بیمه شده اصلی
    /// </summary>
    public string? ResponsibleLastName { get; private set; }
    /// <summary>
    /// نام بیمه گذار بیمه نامه(اگر بیمه گذار حقوقی باشد این فیلد اجباری است.)
    /// </summary>
    public string? InsurerName { get; private set; }
    /// <summary>
    /// شناسه ملی بیمه گذار حقوقی /   کدملی بیمه گذار حقیقی
    /// </summary>
    public string? insurerNationalCode { get; private set; }
    /// <summary>
    /// تاریخ صدور بیمه نامه درمان
    /// </summary>
    public DO_DATE? PolicyIssueDate { get; private set; }
    /// <summary>
    /// کد و نام سازمان بیمه‌گر پایه برای بیمه شدگان تکمیلی  در ترمینولوژی thritaEHR.insurer مکسا می‌باشد
    /// </summary>
    public DO_CODED_TEXT? BaseInsurer { get; private set; }
    /// <summary>
    /// کد و عنوان استان محل صدور بیمه. کدهاي اين ويژگي بر اساس سيستم گذاري countryDivisionsميباشد.
    /// </summary>
    public DO_CODED_TEXT? ProvinceBranch { get; private set; }
    /// <summary>
    /// کد و عنوان شهر محل صدور بیمه. کدهاي اين ويژگي بر اساس سيستم گذاري countryDivisionsميباشد.
    /// </summary>
    public DO_CODED_TEXT? CityBranch { get; private set; }
    /// <summary>
    /// عنوان و کد شعبه محل صدور بیمه نامه در شرکت بیمه تکمیلی "value": "نام شعبه"  ،   "coded_string": "کد شعبه"  ،  ترمینولوژی "terminology_id": "SupplementaryInsurer"
    /// </summary>
    public DO_CODED_TEXT? Branch { get; private set; }
    /// <summary>
    /// توضیحات
    /// </summary>
    public string? RecommendationMessage { get; private set; }
    /// <summary>
    /// عنوان و کد رایانه طرح بیمه نامه در  شرکت بیمه تکمیلی/فول درمان است.
    /// </summary>
    /// <example>(مثال: طرح 1    کد 17678   ترمینولوژی SupplementaryInsurer)</example>
    public DO_CODED_TEXT? PlanId { get; private set; }
    /// <summary>
    /// مطابق با جدول سنهاب Sanhab-12-RequestReason لیست اولیه، حذف از قرارداد/بیمه نامه، انتقال
    /// </summary>
    public DO_CODED_TEXT? RequestReason { get; private set; }
    /// <summary>
    /// بله، پوشش نامحدود است (بدون سقف) True / خیر، پوشش محدود است False
    /// </summary>
    public bool? IsCoverageUnlimited { get; private set; }
    /// <summary>
    /// شماره الحاقیه بیمه نامه در شرکت (در صورت عدم وجود الحاقیه مقدار 0 می باشد)
    /// </summary>
    public string? PolicyVerNo { get; private set; }
    /// <summary>
    /// کدیکتا الحاقیه بیمه نامه در بیمه مرکزی  -- الحاقیه که در ابتدا جهت ورود بیمه شده و سپس بر روی پارامترهای وابسته به بیمه شده موثر است.
    /// </summary>
    public string? PolicyVerUniqueCode { get; private set; }
    /// <summary>
    /// نوع قرارداد بیمه شده اصلی (برای فول درمان الزامی است) مطابق با جدول Sanhab-08-ContractType
    /// </summary>
    public DO_CODED_TEXT? ContractType { get; private set; }
    /// <summary>
    /// شماره شبا
    /// </summary>
    public string? ShebaNo { get; private set; }
    /// <summary>
    /// نام بانک - مطابق با جدول Sanhab-07-BankAcc
    /// </summary>
    public DO_CODED_TEXT? BankAcc { get; private set; }
    /// <summary>
    /// شماره حساب
    /// </summary>
    public string? AccNo { get; private set; }
    /// <summary>
    /// تاریخ فوت
    /// </summary>
    public DO_DATE? DeathDate { get; private set; }
    /// <summary>
    /// کد و عنوان کارگاه یا اداره بیمه شده (برای فول درمان الزامی است)  --- ؟ insurerName
    /// </summary>
    public DO_CODED_TEXT? WorkShop { get; private set; }
    /// <summary>
    /// فرانشیز
    /// </summary>
    public string? Feranshiz { get; private set; }
    /// <summary>
    /// مشخصات صندوق های مرتبط با بیمه شده (برای فول درمان الزامی است) آرایه ای
    /// </summary>
    public List<AccountVODto>? Account { get; private set; }

}
