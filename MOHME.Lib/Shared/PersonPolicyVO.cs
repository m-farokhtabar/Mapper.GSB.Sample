using Services.ExceptionManager;
using Services.ExceptionManager.Resources;
using Mapper.GSB.Share.Resource;
using MOHME.Lib.Helper.Validator;
namespace MOHME.Lib.Shared;

/// <summary>
/// کلاس اصلی مربوط به اطلاعات بیمه نامه بیمه شده می باشد
/// </summary>
public class PersonPolicyVO
{
    /// <summary>
    /// ایجاد اطلاعات بیمه نامه
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
    /// <exception cref="ManualException"></exception>    
    public PersonPolicyVO(DO_CODED_TEXT insurer, DO_CODED_TEXT policyType, string policyUniqueCode, DO_DATE effectiveDate, DO_DATE insuranceExpirationDate, DO_CODED_TEXT? insuranceBox,
                          DO_CODED_TEXT relationType, string policyPrintNumber, string companyPolicyId, string companyInsuredId, int insuredType, DO_IDENTIFIER responsibleID,
                          DO_CODED_TEXT responsibleGender, string? responsibleFirstName, string? responsibleLastName, string insurerName, string insurerNationalCode, DO_DATE? policyIssueDate,
                          DO_CODED_TEXT? baseInsurer, DO_CODED_TEXT provinceBranch, DO_CODED_TEXT cityBranch, DO_CODED_TEXT branch, string? recommendationMessage, DO_CODED_TEXT? planId,
                          DO_CODED_TEXT? requestReason, bool isCoverageUnlimited, string? policyVerNo, string? policyVerUniqueCode, DO_CODED_TEXT? contractType, string? shebaNo,
                          DO_CODED_TEXT? bankAcc, string? accNo, DO_DATE? deathDate, DO_CODED_TEXT? workShop, string? feranshiz, IReadOnlyList<AccountVO>? account)
    {
        Validate(insurer, policyType, policyUniqueCode, effectiveDate, insuranceExpirationDate, insuranceBox, relationType, policyPrintNumber, companyPolicyId,
                 companyInsuredId, responsibleID, responsibleGender, insurerName, provinceBranch, cityBranch, account, insurerNationalCode,
                 policyIssueDate, baseInsurer, branch, planId, requestReason, contractType, bankAcc, deathDate, workShop);

        Insurer = insurer;
        PolicyType = policyType;
        PolicyUniqueCode = policyUniqueCode;
        EffectiveDate = effectiveDate;
        InsuranceExpirationDate = insuranceExpirationDate;
        InsuranceBox = insuranceBox;
        RelationType = relationType;
        PolicyPrintNumber = policyPrintNumber;
        CompanyPolicyId = companyPolicyId;
        CompanyInsuredId = companyInsuredId;
        InsuredType = insuredType;
        ResponsibleID = responsibleID;
        ResponsibleGender = responsibleGender;
        ResponsibleFirstName = responsibleFirstName;
        ResponsibleLastName = responsibleLastName;
        InsurerName = insurerName;
        this.insurerNationalCode = insurerNationalCode;
        PolicyIssueDate = policyIssueDate;
        BaseInsurer = baseInsurer;
        ProvinceBranch = provinceBranch;
        CityBranch = cityBranch;
        Branch = branch;
        RecommendationMessage = recommendationMessage;
        PlanId = planId;
        RequestReason = requestReason;
        IsCoverageUnlimited = isCoverageUnlimited;
        PolicyVerNo = policyVerNo;
        PolicyVerUniqueCode = policyVerUniqueCode;
        ContractType = contractType;
        ShebaNo = shebaNo;
        BankAcc = bankAcc;
        AccNo = accNo;
        DeathDate = deathDate;
        WorkShop = workShop;
        Feranshiz = feranshiz;
        this.account = account?.ToList();
    }
    /// <summary>
    /// کد شرکت بیمه تکمیلی/فول درمان در مکسا
    /// </summary>
    public DO_CODED_TEXT Insurer { get; private set; }
    /// <summary>
    /// نوع بیمه نامه فول درمان یا تکمیلی مرتبط با بیمه شده می باشد. این ویژگی مطابق با جدول hltHub.policyType تکمیل گردد.  برای بیمه نامه درمان تکمیلی از مقدار SendPersonSupplimantryInfo  ( کد 1)  و  برای بیمه نامه فول درمان از مقدار SendPersonInfo (کد 2) استفاده گردد.
    /// </summary>
    /// <remarks>
    /// برای بیمه نامه درمان تکمیلی از مقدار SendPersonSupplimantryInfo - کد 1
    ///  برای بیمه نامه فول درمان از مقدار SendPersonInfo - کد 2
    /// </remarks>
    public DO_CODED_TEXT PolicyType { get; private set; }
    /// <summary>
    /// کد یکتای بیمه نامه (کد یکتای یازده رقمی صادر شده توسط بیمه مرکزی) 
    /// </summary>
    public string PolicyUniqueCode { get; private set; }
    /// <summary>
    /// تاریخ شروع اعتبار بیمه شده -(الزاماً با شروع بیمه نامه بیمه گذار  StartDate یکی نمی باشد.)
    /// </summary>
    public DO_DATE EffectiveDate { get; private set; }
    /// <summary>
    /// تاریخ پایان اعتبار بیمه (در صورتی که بخواهید بیمه شده از طریق پایگاه برخط خدمتی دریافت ننماید می بایست تاریخ اعتبار را به یک تاریخ گذشته مثلا روز قبل بروز رسانی نمایید )
    /// </summary>
    public DO_DATE InsuranceExpirationDate { get; private set; }
    /// <summary>
    /// صندوق بيمه فرد را مشخص ميکند.چنانچه برخي از سازمانهاي بيمه گر، صندوق خاصي نداشته باشند، اين ويژگي مقدار تهي خواهد داشت
    /// </summary>
    public DO_CODED_TEXT? InsuranceBox { get; private set; }
    /// <summary>
    /// کد و عنوان نسبت بیمه شده با سرپرست  که مربوط به PersonPersonRelationType مکسا است
    /// </summary>
    public DO_CODED_TEXT RelationType { get; private set; }
    /// <summary>
    /// شماره چاپی بیمه نامه (شماره ی چاپ شده روی بیمه نامه که در هر شرکت بیمه یکتا ست)
    /// </summary>
    public string PolicyPrintNumber { get; private set; }
    /// <summary>
    /// کد رایانه بیمه نامه در شرکت بیمه تکمیلی/فول درمان است.
    /// </summary>
    public string CompanyPolicyId { get; private set; }
    /// <summary>
    /// کد رایانه بیمه شده در شرکت بیمه تکمیلی/فول درمان است.
    /// </summary>
    public string CompanyInsuredId { get; private set; }
    /// <summary>
    /// نوع بیمه شده ( =1اصلی، =2تبعی)
    /// </summary>
    public int InsuredType { get; private set; }
    /// <summary>
    /// کدملی/کد اتباع/شماره پاسپورت بیمه شده اصلی
    /// </summary>
    public DO_IDENTIFIER ResponsibleID { get; private set; }
    /// <summary>
    /// جنسیت بیمه شده اصلی
    /// </summary>
    public DO_CODED_TEXT ResponsibleGender { get; private set; }
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
    public string InsurerName { get; private set; }
    /// <summary>
    /// شناسه ملی بیمه گذار حقوقی /   کدملی بیمه گذار حقیقی
    /// </summary>
    public string insurerNationalCode { get; private set; }
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
    public DO_CODED_TEXT ProvinceBranch { get; private set; }
    /// <summary>
    /// کد و عنوان شهر محل صدور بیمه. کدهاي اين ويژگي بر اساس سيستم گذاري countryDivisionsميباشد.
    /// </summary>
    public DO_CODED_TEXT CityBranch { get; private set; }
    /// <summary>
    /// عنوان و کد شعبه محل صدور بیمه نامه در شرکت بیمه تکمیلی "value": "نام شعبه"  ،   "coded_string": "کد شعبه"  ،  ترمینولوژی "terminology_id": "SupplementaryInsurer"
    /// </summary>
    public DO_CODED_TEXT Branch { get; private set; }
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
    public bool IsCoverageUnlimited { get; private set; }
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

    private List<AccountVO>? account;
    /// <summary>
    /// مشخصات صندوق های مرتبط با بیمه شده (برای فول درمان الزامی است) آرایه ای
    /// </summary>
    public IReadOnlyList<AccountVO>? Account => account?.AsReadOnly();
   
    /// <summary>
    /// اعتبار سنجی داده ها
    /// </summary>
    /// <param name="insurer"></param>
    /// <param name="policyType"></param>
    /// <param name="policyUnqiueCode"></param>
    /// <param name="effectiveDate"></param>
    /// <param name="insuranceExpirationDate"></param>
    /// <param name="insuranceBox"></param>
    /// <param name="relationType"></param>
    /// <param name="policyPrintNumber"></param>
    /// <param name="companyPolicyId"></param>
    /// <param name="companyInsuredId"></param>
    /// <param name="responsibleID"></param>
    /// <param name="responsibleGender"></param>
    /// <param name="insurerName"></param>
    /// <param name="provinceBranch"></param>
    /// <param name="cityBranch"></param>    
    /// <param name="account"></param>
    /// <param name="insurerNationalCode"></param>
    /// <param name="baseInsurer"></param>
    /// <param name="policyIssueDate"></param>
    /// <param name="branch"></param>
    /// <param name="planId"></param>
    /// <param name="requestReason"></param>
    /// <param name="contractType"></param>
    /// <param name="bankAcc"></param>
    /// <param name="deathDate"></param>
    /// <param name="workShop"></param>
    /// <exception cref="ManualException"></exception>
    private static void Validate(DO_CODED_TEXT insurer, DO_CODED_TEXT policyType, string policyUnqiueCode, DO_DATE effectiveDate, DO_DATE insuranceExpirationDate, DO_CODED_TEXT? insuranceBox,
                                 DO_CODED_TEXT relationType, string policyPrintNumber, string companyPolicyId, string companyInsuredId, DO_IDENTIFIER responsibleID, DO_CODED_TEXT responsibleGender,
                                 string insurerName, DO_CODED_TEXT provinceBranch, DO_CODED_TEXT cityBranch, IReadOnlyList<AccountVO>? account, string insurerNationalCode,
                                 DO_DATE? policyIssueDate, DO_CODED_TEXT? baseInsurer, DO_CODED_TEXT branch, DO_CODED_TEXT? planId, DO_CODED_TEXT? requestReason, DO_CODED_TEXT? contractType,
                                 DO_CODED_TEXT? bankAcc, DO_DATE? deathDate, DO_CODED_TEXT? workShop)
    {        
        if (insurer is not null)
            insurer.Validate(Names.PersonPolicyVO, Names.PersonPolicyVO_Insurer, typeof(PersonPolicyVO).FullName + "." + nameof(Insurer));
        else
            throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonPolicyVO).Replace("{1}", Names.PersonPolicyVO_Insurer), ExceptionType.InValid, typeof(PersonPolicyVO).FullName + "." + nameof(Insurer));

        if (policyType is not null)
            policyType.Validate(Names.PersonPolicyVO, Names.PersonPolicyVO_PolicyType, typeof(PersonPolicyVO).FullName + "." + nameof(PolicyType));
        else
            throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonPolicyVO).Replace("{1}", Names.PersonPolicyVO_PolicyType), ExceptionType.InValid, typeof(PersonPolicyVO).FullName + "." + nameof(PolicyType));
        if (policyType.Coded_string!.Trim() != "1" && policyType.Coded_string!.Trim() != "2")
            throw new ManualException(ExceptionsMessages.Data_is_not_valid_Value_is_wrong.Replace("{0}", Names.PersonPolicyVO).Replace("{1}", Names.PersonPolicyVO_PolicyType), ExceptionType.InValid, typeof(PersonPolicyVO).FullName + "." + nameof(PolicyType));

        if (string.IsNullOrWhiteSpace(policyUnqiueCode))
            throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonPolicyVO).Replace("{1}", Names.PersonPolicyVO_PolicyUnqiueCode), ExceptionType.InValid, typeof(PersonPolicyVO).FullName + "." + nameof(PolicyUniqueCode));
        /***
         * تعداد 11 رقمی بودن  کد یکتای بیمه نامه 1 برای  برای بیمه نامه درمان تکمیلی چک گردد.  
         * برای فول درمان 2 تعداد 11 رقمی بودن مهم نیست
         */
        if (policyType.Coded_string.Trim() == "1" && policyUnqiueCode.Length != 11)
            throw new ManualException(ExceptionsMessages.Data_is_not_valid_Value_is_wrong.Replace("{0}", Names.PersonPolicyVO).Replace("{1}", Names.PersonPolicyVO_PolicyUnqiueCode), ExceptionType.InValid, typeof(PersonPolicyVO).FullName + "." + nameof(PolicyUniqueCode));

        /***
         * مشخصات صندوق های مرتبط با بیمه شده (برای فول درمان الزامی است کد 2) آرایه ای
         */
         if (policyType.Coded_string.Trim() == "2" && (account is null || account.Count == 0))
            throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonPolicyVO).Replace("{1}", Names.PersonPolicyVO_Account), ExceptionType.InValid, typeof(PersonPolicyVO).FullName + "." + nameof(Account));

        if (effectiveDate is not null)
            effectiveDate.Validate(Names.PersonPolicyVO, Names.PersonPolicyVO_EffectiveDate, typeof(PersonPolicyVO).FullName + "." + nameof(EffectiveDate));
        else
            throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonPolicyVO).Replace("{1}", Names.PersonPolicyVO_EffectiveDate), ExceptionType.InValid, typeof(PersonPolicyVO).FullName + "." + nameof(EffectiveDate));

        if (insuranceExpirationDate is not null)
            insuranceExpirationDate.Validate(Names.PersonPolicyVO, Names.PersonPolicyVO_InsuranceExpirationDate, typeof(PersonPolicyVO).FullName + "." + nameof(InsuranceExpirationDate));
        else
            throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonPolicyVO).Replace("{1}", Names.PersonPolicyVO_InsuranceExpirationDate), ExceptionType.InValid, typeof(PersonPolicyVO).FullName + "." + nameof(InsuranceExpirationDate));

        if (effectiveDate.ToDateTime()>insuranceExpirationDate.ToDateTime())
            throw new ManualException(ExceptionsMessages.Data_is_not_valid_Value_is_wrong.Replace("{0}", Names.PersonPolicyVO).Replace("{1}", Names.PersonPolicyVO_EffectiveDate + "-" +Names.PersonPolicyVO_InsuranceExpirationDate) + " - effectiveDate<=insuranceExpirationDate", ExceptionType.InValid, typeof(PersonPolicyVO).FullName + "." + nameof(InsuranceExpirationDate));

        if (insuranceBox is not null)
            insuranceBox.Validate(Names.PersonPolicyVO, Names.PersonPolicyVO_InsuranceBox, typeof(PersonPolicyVO).FullName + "." + nameof(InsuranceBox));

        if (relationType is not null)
            relationType.Validate(Names.PersonPolicyVO, Names.PersonPolicyVO_RelationType, typeof(PersonPolicyVO).FullName + "." + nameof(RelationType));
        else
            throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonPolicyVO).Replace("{1}", Names.PersonPolicyVO_RelationType), ExceptionType.InValid, typeof(PersonPolicyVO).FullName + "." + nameof(RelationType));

        if (string.IsNullOrWhiteSpace(policyPrintNumber))
            throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonPolicyVO).Replace("{1}", Names.PersonPolicyVO_PolicyPrintNumber), ExceptionType.InValid, typeof(PersonPolicyVO).FullName + "." + nameof(PolicyPrintNumber));
        if (string.IsNullOrWhiteSpace(companyPolicyId))
            throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonPolicyVO).Replace("{1}", Names.PersonPolicyVO_CompanyPolicyId), ExceptionType.InValid, typeof(PersonPolicyVO).FullName + "." + nameof(CompanyPolicyId));
        if (string.IsNullOrWhiteSpace(companyInsuredId))
            throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonPolicyVO).Replace("{1}", Names.PersonPolicyVO_CompanyInsuredId), ExceptionType.InValid, typeof(PersonPolicyVO).FullName + "." + nameof(CompanyInsuredId));

        if (responsibleID is not null)
            responsibleID.Validate(Names.PersonPolicyVO, Names.PersonPolicyVO_ResponsibleID, typeof(PersonPolicyVO).FullName + "." + nameof(ResponsibleID));
        else
            throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonPolicyVO).Replace("{1}", Names.PersonPolicyVO_ResponsibleID), ExceptionType.InValid, typeof(PersonPolicyVO).FullName + "." + nameof(ResponsibleID));

        if (responsibleGender is not null)
            responsibleGender.Validate(Names.PersonPolicyVO, Names.PersonPolicyVO_ResponsibleGender, typeof(PersonPolicyVO).FullName + "." + nameof(ResponsibleGender));
        else
            throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonPolicyVO).Replace("{1}", Names.PersonPolicyVO_ResponsibleGender), ExceptionType.InValid, typeof(PersonPolicyVO).FullName + "." + nameof(ResponsibleGender));

        if (string.IsNullOrWhiteSpace(insurerName))
            throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonPolicyVO).Replace("{1}", Names.PersonPolicyVO_InsurerName), ExceptionType.InValid, typeof(PersonPolicyVO).FullName + "." + nameof(InsurerName));

        if (string.IsNullOrWhiteSpace(insurerNationalCode))
            throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonPolicyVO).Replace("{1}", Names.PersonPolicyVO_InsurerNationalCode), ExceptionType.InValid, typeof(PersonPolicyVO).FullName + "." + nameof(insurerNationalCode));

        policyIssueDate?.Validate(Names.PersonPolicyVO, Names.PersonPolicyVO_PolicyIssueDate, typeof(PersonPolicyVO).FullName + "." + nameof(PolicyIssueDate));

        baseInsurer?.Validate(Names.PersonPolicyVO, Names.PersonPolicyVO_BaseInsurer, typeof(PersonPolicyVO).FullName + "." + nameof(BaseInsurer));

        if (provinceBranch is not null)
            provinceBranch.Validate(Names.PersonPolicyVO, Names.PersonPolicyVO_ProvinceBranch, typeof(PersonPolicyVO).FullName + "." + nameof(ProvinceBranch));
        else
            throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonPolicyVO).Replace("{1}", Names.PersonPolicyVO_ProvinceBranch), ExceptionType.InValid, typeof(PersonPolicyVO).FullName + "." + nameof(ProvinceBranch));

        if (cityBranch is not null)
            cityBranch.Validate(Names.PersonPolicyVO, Names.PersonPolicyVO_CityBranch, typeof(PersonPolicyVO).FullName + "." + nameof(CityBranch));
        else
            throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonPolicyVO).Replace("{1}", Names.PersonPolicyVO_CityBranch), ExceptionType.InValid, typeof(PersonPolicyVO).FullName + "." + nameof(CityBranch));

        if (branch is not null)
            branch.Validate(Names.PersonPolicyVO, Names.PersonPolicyVO_Branch, typeof(PersonPolicyVO).FullName + "." + nameof(Branch));
        else
            throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonPolicyVO).Replace("{1}", Names.PersonPolicyVO_Branch), ExceptionType.InValid, typeof(PersonPolicyVO).FullName + "." + nameof(Branch));


        planId?.Validate(Names.PersonPolicyVO, Names.PersonPolicyVO_PlanId, typeof(PersonPolicyVO).FullName + "." + nameof(PlanId));
        requestReason?.Validate(Names.PersonPolicyVO, Names.PersonPolicyVO_RequestReason, typeof(PersonPolicyVO).FullName + "." + nameof(RequestReason));
        contractType?.Validate(Names.PersonPolicyVO, Names.PersonPolicyVO_ContractType, typeof(PersonPolicyVO).FullName + "." + nameof(ContractType));
        bankAcc?.Validate(Names.PersonPolicyVO, Names.PersonPolicyVO_BankAcc, typeof(PersonPolicyVO).FullName + "." + nameof(BankAcc));
        deathDate?.Validate(Names.PersonPolicyVO, Names.PersonPolicyVO_DeathDate, typeof(PersonPolicyVO).FullName + "." + nameof(DeathDate));
        workShop?.Validate(Names.PersonPolicyVO, Names.PersonPolicyVO_WorkShop, typeof(PersonPolicyVO).FullName + "." + nameof(WorkShop));
    }

}
