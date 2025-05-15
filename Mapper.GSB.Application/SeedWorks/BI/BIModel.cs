namespace Mapper.GSB.Application.SeedWorks.BI;

/// <summary>
/// کلاس مدل
/// GSB.BI
/// </summary>
public class BIModel
{
    /// <summary>
    /// ایجاد مدل 
    /// BI
    /// </summary>
    /// <param name="dataCoordinatorId"></param>
    /// <param name="receiveDate"></param>
    /// <param name="registerUID"></param>
    /// <param name="messageUID"></param>
    /// <param name="insurerCoded_string"></param>
    /// <param name="policyUnqiueCode"></param>
    /// <param name="policyType"></param>
    /// <param name="provinceBranchCoded_string"></param>
    /// <param name="insuredType"></param>
    /// <param name="relationTypeValue"></param>
    /// <param name="relationTypeCoded_string"></param>
    /// <param name="responsibleGenderValue"></param>
    /// <param name="responsibleGenderCoded_string"></param>
    /// <param name="insuranceExpirationDate"></param>
    /// <param name="insurerNationalCode"></param>
    /// <param name="isCoverageUnlimited"></param>
    /// <param name="personIdType"></param>
    /// <param name="birthDate"></param>
    /// <param name="maritalStatusCoded_string"></param>
    /// <param name="nationalityValue"></param>
    /// <param name="personId"></param>
    /// <param name="gSBDataVORegisterID"></param>
    /// <param name="registerDate"></param>
    public BIModel(Guid dataCoordinatorId, DateTime receiveDate, Guid registerUID, Guid messageUID, int insurerCoded_string,
             string policyUnqiueCode, string policyType, string provinceBranchCoded_string, int insuredType,
             string relationTypeValue, string relationTypeCoded_string,
             string responsibleGenderValue, string responsibleGenderCoded_string, DateTime insuranceExpirationDate, string insurerNationalCode,
             byte isCoverageUnlimited, string personIdType, DateTime birthDate,
             string maritalStatusCoded_string, string? nationalityValue, string personId,
             string? gSBDataVORegisterID, DateTime? registerDate)
    {
        DataCoordinatorId = dataCoordinatorId;
        ReceiveDate = receiveDate;
        RegisterUID = registerUID;
        MessageUID = messageUID;
        InsurerCoded_string = insurerCoded_string;
        PolicyUnqiueCode = policyUnqiueCode;
        PolicyType = policyType;
        ProvinceBranchCoded_string = provinceBranchCoded_string;
        InsuredType = insuredType;
        RelationTypeValue = relationTypeValue;
        RelationTypeCoded_string = relationTypeCoded_string;
        ResponsibleGenderValue = responsibleGenderValue;
        ResponsibleGenderCoded_string = responsibleGenderCoded_string;
        InsuranceExpirationDate = insuranceExpirationDate;
        InsurerType = insurerNationalCode.Length != 10 ? (byte)0 : (byte)1;
        IsCoverageUnlimited = isCoverageUnlimited;
        PersonIdType = personIdType;
        BirthDate = birthDate;
        MaritalStatusCoded_string = maritalStatusCoded_string;
        NationalityValue = nationalityValue;
        NationalCode = personId;
        RegisterIDStatus = gSBDataVORegisterID is null ? (byte)0 : (byte)1;
        RegisterDate = registerDate;
    }
    /// <summary>
    /// شناسه اصلی مربوط به مدل
    /// PersonInsuranceDataCoordinator
    /// </summary>
    public Guid DataCoordinatorId { get; private set; }
    /// <summary>
    /// تاریخ دریافت GSBBI را برمی‌گرداند یا تنظیم می‌کند.
    /// </summary>
    public DateTime ReceiveDate { get; private set; }

    /// <summary>
    /// شناسه ثبت GSBBI را برمی‌گرداند یا تنظیم می‌کند.
    /// </summary>
    public Guid RegisterUID { get; private set; }

    /// <summary>
    /// شناسه پیام GSBBI را برمی‌گرداند یا تنظیم می‌کند.
    /// </summary>
    public Guid MessageUID { get; private set; }

    /// <summary>
    /// رشته کد شرکت بیمه‌گر GSBBI را برمی‌گرداند یا تنظیم می‌کند.
    /// </summary>
    public int InsurerCoded_string { get; private set; }

    /// <summary>
    /// کد یکتا بیمه‌گر GSBBI را برمی‌گرداند یا تنظیم می‌کند.
    /// </summary>
    public string PolicyUnqiueCode { get; private set; }

    /// <summary>
    /// نوع بیمه GSBBI را برمی‌گرداند یا تنظیم می‌کند.
    /// </summary>
    public string PolicyType { get; private set; }

    /// <summary>
    /// رشته کد شعبه استانی GSBBI را برمی‌گرداند یا تنظیم می‌کند.
    /// </summary>
    public string ProvinceBranchCoded_string { get; private set; }

    /// <summary>
    /// نوع بیمه شده GSBBI را برمی‌گرداند یا تنظیم می‌کند.
    /// </summary>
    public int InsuredType { get; private set; }

    /// <summary>
    /// مقدار نوع ارتباط GSBBI را برمی‌گرداند یا تنظیم می‌کند.
    /// </summary>
    public string RelationTypeValue { get; private set; }

    /// <summary>
    /// رشته کد شرکت بیمه‌گر GSBBI را برمی‌گرداند یا تنظیم می‌کند.
    /// </summary>
    public string RelationTypeCoded_string { get; private set; }

    /// <summary>
    /// مقدار جنسیت مسئول GSBBI را برمی‌گرداند یا تنظیم می‌کند.
    /// </summary>
    public string ResponsibleGenderValue { get; private set; }

    /// <summary>
    /// رشته جنسیت مسئول GSBBI را برمی‌گرداند یا تنظیم می‌کند.
    /// </summary>
    public string ResponsibleGenderCoded_string { get; private set; }
    /// <summary>
    /// تاریخ انقضای بیمه GSBBI را برمی‌گرداند یا تنظیم می‌کند.
    /// </summary>
    public DateTime InsuranceExpirationDate { get; private set; }

    /// <summary>
    /// نوع بیمه‌گر GSBBI را برمی‌گرداند یا تنظیم می‌کند.
    /// </summary>
    public byte InsurerType { get; private set; }

    /// <summary>
    /// پرچم نشان دهنده پوشش نامحدود بودن GSBBI را برمی‌گرداند یا تنظیم می‌کند.
    /// </summary>
    public byte IsCoverageUnlimited { get; private set; }

    /// <summary>
    /// نوع شناسه شخص GSBBI را برمی‌گرداند یا تنظیم می‌کند.
    /// </summary>
    public string PersonIdType { get; private set; }

    /// <summary>
    /// تاریخ تولد GSBBI را برمی‌گرداند یا تنظیم می‌کند.
    /// </summary>
    public DateTime BirthDate { get; private set; }

    /// <summary>
    /// رشته کد وضعیت تاهل GSBBI را برمی‌گرداند یا تنظیم می‌کند.
    /// </summary>
    public string MaritalStatusCoded_string { get; private set; }

    /// <summary>
    /// مقدار ملیت GSBBI را برمی‌گرداند یا تنظیم می‌کند.
    /// </summary>
    public string? NationalityValue { get; private set; }

    /// <summary>
    /// کد ملی GSBBI را برمی‌گرداند یا تنظیم می‌کند.
    /// </summary>
    public string NationalCode { get; private set; }

    /// <summary>
    /// وضعیت ثبت GSBBI را برمی‌گرداند یا تنظیم می‌کند.
    /// </summary>
    public byte RegisterIDStatus { get; private set; }

    /// <summary>
    /// تاریخ ثبت GSBBI را برمی‌گرداند یا تنظیم می‌کند.
    /// </summary>
    public DateTime? RegisterDate { get; private set; }
}
