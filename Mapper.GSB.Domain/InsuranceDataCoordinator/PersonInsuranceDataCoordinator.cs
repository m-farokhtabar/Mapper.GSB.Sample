using Mapper.GSB.Domain.Helper;
using Mapper.GSB.Domain.SeedWorks;
using Services.ExceptionManager;
using Services.ExceptionManager.Resources;
using Mapper.GSB.Share.Resource;
using MOHME.Lib.Helper.Validator;
using MOHME.Lib.Shared;
using System.Text.Json;
using Mapper.GSB.Share.Helper;

namespace Mapper.GSB.Domain.InsuranceDataCoordinator;

/// <summary>
/// هماهنگ کننده جهت دریافت و ارسال داده های بیمه به سرویس های مورد نظر
/// خلاصه اطلاعات بیمه جهت دسترسی سریع
/// </summary>
public sealed class PersonInsuranceDataCoordinator : AggregateRoot
{
    /// <summary>
    /// فقط جهت
    /// entityframework
    /// </summary>
    private PersonInsuranceDataCoordinator()
    {
    }
    /// <summary>
    /// ایجاد
    /// خلاصه اطلاعات بیمه جهت دسترسی سریع
    /// </summary>
    /// <param name="id">
    /// شناسه اطلاعات بیمه نامه تکمیلی یا بیمه نامه فول به همراه اطلاعات فرد
    /// PersonInsuranceId
    /// </param>
    /// <param name="version"></param>
    /// <param name="createDate"></param>
    /// <param name="patientUID"></param>
    /// <param name="compositionUID"></param>
    /// <param name="registerUID"></param>
    /// <param name="messageUID"></param>
    /// <param name="personId"></param>
    /// <param name="policyUniqueCode"></param>
    /// <param name="companyInsuredId"></param>
    /// <param name="companyPolicyId"></param>
    /// <param name="shebad"></param>
    /// <param name="localId"></param>
    /// <param name="personInsuranceCreatedEventId"></param>
    /// <param name="accountID"></param>
    /// <param name="insuranceExpirationDate"></param>
    /// <param name="insurer"></param>
    /// <param name="policyType"></param>
    public PersonInsuranceDataCoordinator(Guid id, int version, DateTime createDate, string? patientUID, string? compositionUID, string registerUID, string messageUID,
                                          DO_IDENTIFIER personId, string policyUniqueCode, string companyInsuredId, string companyPolicyId, DO_IDENTIFIER? shebad, string? localId, Guid personInsuranceCreatedEventId,
                                          DO_CODED_TEXT insurer, DO_DATE insuranceExpirationDate, string? accountID, DO_CODED_TEXT policyType) : base(createDate, id, version)
    {
        if (personId is not null)
            personId.Validate(Names.PersonInsuranceDataCoordinator, Names.PersonInfoVO_PersonID, typeof(PersonInsuranceDataCoordinator).FullName + "." + nameof(PersonId));
        else
            throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonInsuranceDataCoordinator).Replace("{1}", Names.PersonInfoVO_PersonID), ExceptionType.InValid, typeof(PersonInsuranceDataCoordinator).FullName + "." + nameof(PersonId));

        if (string.IsNullOrWhiteSpace(policyUniqueCode))
            throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonInsuranceDataCoordinator).Replace("{1}", Names.PersonPolicyVO_PolicyUnqiueCode), ExceptionType.InValid, typeof(PersonInsuranceDataCoordinator).FullName + "." + nameof(PolicyUniqueCode));

        if (string.IsNullOrWhiteSpace(companyInsuredId))
            throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonInsuranceDataCoordinator).Replace("{1}", Names.PersonPolicyVO_CompanyInsuredId), ExceptionType.InValid, typeof(PersonInsuranceDataCoordinator).FullName + "." + nameof(CompanyInsuredId));

        if (string.IsNullOrWhiteSpace(companyPolicyId))
            throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonInsuranceDataCoordinator).Replace("{1}", Names.PersonPolicyVO_CompanyPolicyId), ExceptionType.InValid, typeof(PersonInsuranceDataCoordinator).FullName + "." + nameof(CompanyPolicyId));

        RegisterUID = new Guid(registerUID);
        MessageUID = new Guid(messageUID);
        
        PersonId = personId.ID!.Trim();
        PersonIdType = !string.IsNullOrWhiteSpace(personId.Type) ? personId.Type.Trim() : "";
        personIdentifier = JsonSerializer.Serialize(personId);

        PolicyUniqueCode = policyUniqueCode.Trim();
        CompanyInsuredId = companyInsuredId.Trim();
        CompanyPolicyId = companyPolicyId.Trim();
        DomainModel = PersonInsuranceDomainType.HltHub_SendPersonPolicyInfo;
        PatientUID = patientUID;
        CompositionUID = compositionUID;
        if (shebad is not null)
        {
            shebad.Validate(Names.PersonInsuranceDataCoordinator, Names.PersonInsuranceDataCoordinator_Shebad, typeof(PersonInsuranceDataCoordinator).FullName + "." + nameof(Shebad));
            ShebadId = shebad.ID;
            this.shebad = JsonSerializer.Serialize(shebad);
        }
        Status = InsuranceDataStatus.Recieved;
        GSBResult = null;
        GSBAttemptsFailCount = 0;
        LocalId = localId;
        Operation = Version == 1 ? Operation.Insert : Operation.Update;
        PersonInsuranceVersion = 1;
        PersonInsuranceCreatedEventId = personInsuranceCreatedEventId;

        AccountID = accountID;
        this.insurer = JsonSerializer.Serialize(insurer);
        this.InsurerId = Convert.ToInt32(insurer.Coded_string);

        this.policyType = JsonSerializer.Serialize(policyType);
        this.insuranceExpirationDate = insuranceExpirationDate.ToDateTime()!.Value;

        AddEvent(new PersonInsuranceDataRecievedEvent(Id, personInsuranceCreatedEventId, version, createDate));
    }
    /// <summary>
    /// شناسه منحصر به فرد ثبت اطلاعات بیمه شده در هاب بیمه مرکزی است که به ازای هر بیمه شده  در داده پیام  ارسالی به سیستم بازگردانده میشود. سیستمهای جامع بیمه گری شرکت ها باید این شناسه ثبت را در سیستم خود نگهداری کنند.
    /// </summary>
    public Guid RegisterUID { get; private set; }
    /// <summary>
    /// شناسه یکتای داده پیام ارسالی به هاب بیمه مرکزی است که به ازای هر تراکنش شناسه یکتا به سیستم بازگردانده میشود. سیستمهای جامع بیمه گری شرکت ها باید این شناسه را در سیستم خود نگهداری کنند.
    /// </summary>
    public Guid MessageUID { get; private set; }
    /// <summary>
    /// شناسه ثبت شده در 
    /// openEHR
    /// برای شخص مورد نظر
    /// </summary>
    public string? openEHRPartyId { get; private set; }
    /// <summary>
    /// شناسه ثبت شده در 
    /// openEHR
    /// برای روکش سند مورد نظر
    /// </summary>
    public string? openEHRPartyRelationshipId { get; set; }
    /// <summary>
    /// تاریخ و ساعت ثبت اطلاعات در هاب بیمه مرکزی
    /// </summary>
    public DO_DATE_TIME RegisterDateTime => CreatedDate.GetPersianDoDateTime();
    /// <summary>
    /// شناسه ملی فرد یا شناسه اتباع بیگانه یا پاسپورت  (مطابق با شناسه های حوزه سلامت)    
    /// DO_IDENTIFIER => ID
    /// </summary>
    public string PersonId { get; private set; }
    /// <summary>
    /// نوع شناسه انتخابی
    /// DO_IDENTIFIER => TYPE
    /// </summary>
    ///<remarks>type = nationalCode</remarks>
    public string PersonIdType { get; private set; }
    /// <summary>
    /// شناسه ملی فرد یا شناسه اتباع بیگانه یا پاسپورت  (مطابق با شناسه های حوزه سلامت)    
    /// </summary>
    public string personIdentifier { get; private set; }
    /// <summary>
    /// شناسه ملی فرد یا شناسه اتباع بیگانه یا پاسپورت  (مطابق با شناسه های حوزه سلامت)    
    /// DO_IDENTIFIER
    /// </summary>
    public DO_IDENTIFIER? PersonIdentifier => string.IsNullOrWhiteSpace(personIdentifier) ? null : JsonSerializer.Deserialize<DO_IDENTIFIER>(personIdentifier);
    /// <summary>
    /// کد یکتای بیمه نامه (کد یکتای یازده رقمی صادر شده توسط بیمه مرکزی) 
    /// </summary>
    public string PolicyUniqueCode { get; private set; }
    /// <summary>
    /// کد رایانه بیمه شده در شرکت بیمه تکمیلی/فول درمان است.
    /// </summary>
    public string CompanyInsuredId { get; private set; }
    /// <summary>
    /// کد رایانه بیمه نامه در شرکت بیمه تکمیلی/فول درمان است.
    /// </summary>
    public string CompanyPolicyId { get; private set; }
    
    /// <summary>
    /// کد شرکت بیمه تکمیلی/فول درمان در مکسا
    /// </summary>
    public int InsurerId { get; private set; }
    /// <summary>
    /// کد شرکت بیمه تکمیلی/فول درمان در مکسا
    /// DO_CODED_TEXT
    /// </summary>
    /// <remarks>به صورت جی سان نگهداری می شود</remarks>
    public string insurer { get; private set; }
    /// <summary>
    /// کد شرکت بیمه تکمیلی/فول درمان در مکسا
    /// </summary>
    /// <remarks>به صورت جی سان نگهداری می شود</remarks>
    public DO_CODED_TEXT? Insurer => string.IsNullOrWhiteSpace(insurer) ? null : JsonSerializer.Deserialize<DO_CODED_TEXT>(insurer);
    /// <summary>
    /// تاریخ پایان اعتبار بیمه (در صورتی که بخواهید بیمه شده از طریق پایگاه برخط خدمتی دریافت ننماید می بایست تاریخ اعتبار را به یک تاریخ گذشته مثلا روز قبل بروز رسانی نمایید )
    /// </summary>
    public DateTime insuranceExpirationDate { get; private set; }
    /// <summary>
    /// تاریخ پایان اعتبار بیمه (در صورتی که بخواهید بیمه شده از طریق پایگاه برخط خدمتی دریافت ننماید می بایست تاریخ اعتبار را به یک تاریخ گذشته مثلا روز قبل بروز رسانی نمایید )
    /// </summary>
    public DO_DATE InsuranceExpirationDate => insuranceExpirationDate.GetPersianDoDate();
    /// <summary>
    /// شماره سریال مرتبط با صندوق یا خدمت ثبت شده برای این بیمه شده در نرم افزار بیمه گری
    /// </summary>
    public string? AccountID { get; private set; }
    /// <summary>
    /// نوع بیمه نامه فول درمان یا تکمیلی مرتبط با بیمه شده می باشد. این ویژگی مطابق با جدول hltHub.policyType تکمیل گردد.  برای بیمه نامه درمان تکمیلی از مقدار SendPersonSupplimantryInfo  ( کد 1)  و  برای بیمه نامه فول درمان از مقدار SendPersonInfo (کد 2) استفاده گردد.
    /// </summary>
    /// <remarks>به صورت جی سان نگهداری می شود</remarks>
    public string policyType { get; private set; }
    /// <summary>
    /// نوع بیمه نامه فول درمان یا تکمیلی مرتبط با بیمه شده می باشد. این ویژگی مطابق با جدول hltHub.policyType تکمیل گردد.  برای بیمه نامه درمان تکمیلی از مقدار SendPersonSupplimantryInfo  ( کد 1)  و  برای بیمه نامه فول درمان از مقدار SendPersonInfo (کد 2) استفاده گردد.
    /// </summary>
    public DO_CODED_TEXT? PolicyType => string.IsNullOrWhiteSpace(policyType) ? null : JsonSerializer.Deserialize<DO_CODED_TEXT>(policyType);
    /// <summary>
    /// نشان دهنده مفهوم یا مدلی سرویس فراخوانی شده است. hltHub.SendPersonPolicyInfo
    /// </summary>
    public PersonInsuranceDomainType DomainModel { get; private set; }
    /// <summary>
    /// نام دامنه
    /// </summary>
    public string? DomainModelName => DomainModel.GetDisplayName();
    /// <summary>
    /// شناسه بیمار ثبت شده از جانب سپاس
    /// </summary>
    public string? PatientUID { get; private set; }
    /// <summary>
    /// شناسه منحصربفرد مربوط به یک مراجعه(پرونده بیمار یا همان روکش سند) را مشخص می کند
    /// </summary>
    public string? CompositionUID { get; private set; }
    /// <summary>
    /// شماره برگه بیمه یا همان شماره شباد
    /// DO_IDENTIFIER => ID
    /// </summary>
    /// <remarks>به صورت جی سان نگهداری می شود</remarks>
    public string? ShebadId { get; private set; }
    /// <summary>
    /// شناسه منحصر بفرد صادر شده توسط سازمان بیمه گر در فرآیند استعلام الکترونیکی میباشد که می تواند شناسه ارجاع بیماران ارجاع شده از سطح 1و یا استعلام اطلاعات بیمه ای و نسخه بیمار باشد.
    /// DO_IDENTIFIER
    /// </summary>
    /// <remarks>به صورت جی سان نگهداری می شود</remarks>
    private string? shebad;
    /// <summary>
    /// شناسه منحصر بفرد صادر شده توسط سازمان بیمه گر در فرآیند استعلام الکترونیکی میباشد که می تواند شناسه ارجاع بیماران ارجاع شده از سطح 1و یا استعلام اطلاعات بیمه ای و نسخه بیمار باشد.
    /// </summary>
    public DO_IDENTIFIER? Shebad => string.IsNullOrWhiteSpace(shebad) ? null : JsonSerializer.Deserialize<DO_IDENTIFIER>(shebad);
    /// <summary>
    /// نتیجه جواب GSB
    /// </summary>
    public string? GSBResult { get; private set; }
    /// <summary>
    /// تعداد تلاش های ارسال درخواست به سرور
    /// GSB
    /// که منجر به خطا شده است
    /// </summary>
    public int GSBAttemptsFailCount { get; private set; } = 0;
    /// <summary>
    /// شناسه محلی رکورد در سامانه مورد نظر شرکت بیمه یا مرکز درمانی- این شناسه در صورت وجود در کلاس پیام ورودی سرویس، عینا در خروجی ارسال می گردد.
    /// </summary>
    public string? LocalId { get; private set; }
    /// <summary>
    /// وضعیت فعلی سند بیمه
    /// </summary>
    public InsuranceDataStatus Status { get; private set; }
    /// <summary>
    /// نوع عملیات انجام شده جهت ثبت این داده
    /// </summary>
    public Operation Operation { get; private set; }
    /// <summary>
    /// خطای به وجود آمده 
    /// به صورت جی سان
    /// </summary>
    private string? error;
    /// <summary>
    /// خطای به وجود آمده 
    /// </summary>
    public List<ErrorMessage>? Error => string.IsNullOrWhiteSpace(error) ? null : JsonSerializer.Deserialize<List<ErrorMessage>>(error, new JsonSerializerOptions() { Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping});
    /// <summary>
    /// ثبت خطاها
    /// </summary>
    /// <remarks>دقت شود در صورت وجود خطا به خطاهای قبلی اضافه می شود </remarks>
    /// <param name="errors"></param>
    public void AddErrors(List<ErrorMessage> errors)
    {
        JsonSerializerOptions jso = new()
        {
            //برای این استفاده شده که کارکترهای یونیکد را به صورت کد نگهدرای نکند بلکه به همان صورت کارکترهای فارسی تبدیل کند
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
        List<ErrorMessage>? PrevError = !string.IsNullOrWhiteSpace(error) ? JsonSerializer.Deserialize<List<ErrorMessage>>(error, jso) : null;
        if (errors?.Count > 0)
        {
            if (PrevError?.Count > 0)
                errors.AddRange(PrevError);
            error = JsonSerializer.Serialize(errors, jso);
        }
        else
            error = null;
        ModifiedDate = DateTime.Now;
    }
    /// <summary>
    /// ثبت خطا
    /// </summary>
    /// <remarks>دقت شود در صورت وجود خطا به خطاهای قبلی اضافه می شود </remarks>
    /// <param name="error"></param>
    public void AddError(ErrorMessage error) => AddErrors(new List<ErrorMessage> { error });
    /// <summary>
    /// شناسه رویدادی  که باعث ایجاد این موجودیت مورد نظر شده است
    /// در اصل شناسه رویدادی که داد های دریافتی از سرور بیمه های تکمیلی در آن قرار دارد اینجا نگه داری می شود
    /// این رویداد یعنی نسخه یک
    /// PersonInsuranceVersion
    /// </summary>
    public Guid PersonInsuranceCreatedEventId { get; private set; }
    /// <summary>
    /// آخرین نسخه تغییرات داد های دریافتی از سرور بیمه های تکمیلی و بیمه نامه فول برای این سند
    /// این فیلد استفاده داخلی دارد و می گوید همین رکورد چند بار ویرایش شده است و ربطی به فیلد
    /// Version
    /// ندارد
    /// در فیلد 
    /// Version
    /// منظورمان این است که چند درخواست ثبت اطلاعات بیمه شده و بیمه نامه امده است که به ازای هر بار نسخه می خورد
    /// همان معادل
    /// MsgID.Version
    /// است
    /// </summary>
    public int PersonInsuranceVersion { get; private set; }
    /// <summary>
    /// تنظیم نسخه جدید ثبت شده برای همین داده
    /// </summary>
    /// <param name="personInsuranceVersion"></param>
    public void SetPersonInsuranceVersion(int personInsuranceVersion)
    {
        if (personInsuranceVersion <= PersonInsuranceVersion)
            throw new ManualException(ExceptionsMessages.Data_is_not_valid_Value_is_wrong.Replace("{0}", Names.PersonInsuranceDataCoordinator).Replace("{1}", Names.PersonInsuranceDataCoordinator_PersonInsuranceVersion), 
                                      ExceptionType.InValid, typeof(PersonInsuranceDataCoordinator).FullName + "." + nameof(PersonInsuranceVersion));
        PersonInsuranceVersion = personInsuranceVersion;
        ModifiedDate = DateTime.Now;
    }
    /// <summary>
    /// GSB
    /// شناسه منحصر بفرد بیمه شده در بانک تجمیع بیمه سلامت
    /// </summary>
    /// <remarks>جهت دسترسی سریع اضافه شده است</remarks>
    public string? GSBIgin { get; private set; }
    /// <summary>
    /// GSB
    /// شناسه تولید شده در فرآیند ثبت اطلاعات بیمه شده
    /// </summary>
    /// <remarks>جهت دسترسی سریع اضافه شده است</remarks>
    public string? GSBRegisterID { get; private set; }
    /// <summary>
    /// تنظیم وضعیتی که درخواست جهت دریافت اطلاعات از وب سرویس ناموفق بوده است
    /// </summary>
    /// <param name="gSBResult"></param>
    /// <param name="error"></param>    
    public void SetStatusGSBServiceIsUnSucceessful(string? gSBResult, ErrorMessage? error)
    {
        Status = InsuranceDataStatus.SentToGSBServiceIsUnSucceessful;
        GSBResult = gSBResult;
        GSBAttemptsFailCount++;
        if (error is not null)
            AddError(error);
        ModifiedDate = DateTime.Now;        
    }
    /// <summary>
    /// تنظیم وضعیتی که درخواست جهت دریافت اطلاعات از وب سرویس موفق بوده است
    /// </summary>
    /// <param name="gSBResult"></param>
    /// <param name="igin"></param>
    /// <param name="registerID"></param>
    public void SetStatusGSBServiceIsSucceessful(string? gSBResult, string? igin, string? registerID)
    {
        if (Status == InsuranceDataStatus.SentToGSBServiceIsSucceessful)
            throw new ManualException(ExceptionsMessages.The_data_is_not_valid_the_field_with_the_value_has_already_been_registered_in_the_system_It_is_not_possible_to_re_register_it_with_this_value.
                                      Replace("{0}", Names.PersonInsuranceDataCoordinator).
                                      Replace("{1}", Names.PersonInsuranceDataCoordinator_Status).
                                      Replace("{2}", InsuranceDataStatus.SentToGSBServiceIsSucceessful.ToString()), 
                                      ExceptionType.Conflict, typeof(PersonInsuranceDataCoordinator).FullName + "." + nameof(Status));

        Status = InsuranceDataStatus.SentToGSBServiceIsSucceessful;
        GSBResult = gSBResult;
        GSBIgin = igin;
        GSBRegisterID = registerID;
        ModifiedDate = DateTime.Now;
        AddEvent(new PersonInsuranceDataSentToGSBServiceSucceessfullyEvent(Id, Version, ModifiedDate));
    }
    /// <summary>
    /// اطلاعات بیمه شونده در ریپو ذخیره شده است
    /// ثبت
    /// شناسه ثبت شده در 
    /// openEHR
    /// برای شخص مورد نظر
    /// </summary>
    /// <param name="openEHRPartyId"></param>
    public void SetStatusSavePersonInopenEHRRepositoryIsSucceessful(string openEHRPartyId)
    {
        Status = InsuranceDataStatus.SavePersonInopenEHRRepositoryIsSucceessful;
        this.openEHRPartyId = openEHRPartyId;
        ModifiedDate = DateTime.Now;
        
    }
    /// <summary>
    /// اطلاعات بیمه شونده در ریپو ذخیره نشده است و با خطا روبرو شده است
    /// </summary>
    /// <param name="error"></param>
    public void SetStatusSavePersonInopenEHRRepositoryIsUnSucceessful(ErrorMessage? error)
    {
        Status = InsuranceDataStatus.SavePersonInopenEHRRepositoryIsUnSucceessful;               
        if (error is not null)
            AddError(error);
        ModifiedDate = DateTime.Now;
    }
    /// <summary>
    /// اطلاعات بیمه نامه در ریپو ذخیره شده است
    /// </summary>
    public void SetStatusDone(string openEHRPartyRelationshipId)
    {
        this.openEHRPartyRelationshipId = openEHRPartyRelationshipId;
        Status = InsuranceDataStatus.Done;
        ModifiedDate = DateTime.Now;
    }
    /// <summary>
    /// اطلاعات بیمه نامه در ریپو ذخیره نشده است و با خطا روبرو شده است
    /// </summary>
    /// <param name="error"></param>
    public void SetStatusSaveInsurnaceDataInopenEHRRepositoryIsUnSucceessful(ErrorMessage? error)
    {
        Status = InsuranceDataStatus.SaveInsurnaceDataInopenEHRRepositoryIsUnSucceessful;        
        if (error is not null)
            AddError(error);
        ModifiedDate = DateTime.Now;
    }
}
/// <summary>
/// شناسه خطا
/// </summary>
public class ErrorMessage
{
    /// <summary>
    /// ایجاد پیام خطا
    /// </summary>
    /// <param name="errorCode"></param>
    /// <param name="message"></param>
    public ErrorMessage(string? errorCode, string message)
    {
        ErrorCode = errorCode?.ToLower();
        Message = message;
        CreatedDate = DateTime.Now;
    }
    /// <summary>
    /// کد خطا
    /// </summary>
    public string? ErrorCode { get; set; }
    /// <summary>
    /// پیام خطا
    /// </summary>
    public string Message { get; set; }
    /// <summary>
    /// زمان رخ دادن خطا
    /// </summary>
    public DateTime CreatedDate { get; private set; }
}