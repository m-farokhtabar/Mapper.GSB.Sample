using MOHME.Lib.Helper.Validator;
using MOHME.Lib.Shared;

namespace Mapper.GSB.Application.Insurance.Commands.Save;

/// <summary>
/// اطلاعات مورد استفاده در تبادل داده با سرویس‌های پرونده الکترونیکی سلامت می‌باشد
/// </summary>
public class MessageIdentifierVODto
{

    /// <summary>
    /// ایجاد اطلاعات مورد استفاده در تبادل
    /// </summary>
    /// <param name="versionLifecycleStateField"></param>
    /// <param name="iS_QueriableField"></param>
    /// <param name="compositionSignatureField"></param>
    /// <param name="systemID"></param>
    /// <param name="healthCareFacilityIDField"></param>
    /// <param name="patientUIDField"></param>
    /// <param name="compositionUIDField"></param>
    /// <param name="committerField"></param>
    /// <param name="localId"></param>
    /// <param name="universityID"></param>
    /// <param name="deactivate"></param>
    /// <param name="withoutId"></param>
    /// <param name="version"></param>
    /// <param name="messageUID"></param>
    /// <param name="registerUID"></param>
    public MessageIdentifierVODto(DO_CODED_TEXT? versionLifecycleStateField, bool? iS_QueriableField, SignatureVO? compositionSignatureField, DO_IDENTIFIER? systemID, DO_IDENTIFIER? healthCareFacilityIDField,
                               string? patientUIDField, string? compositionUIDField, ProviderInfoVO? committerField, string? localId, DO_IDENTIFIER? universityID, bool? deactivate, bool? withoutId, int? version, string? registerUID, string? messageUID)
    {        
        this.versionLifecycleStateField = versionLifecycleStateField is not null && versionLifecycleStateField.areAllPropsNullOrEmpty() ? null : versionLifecycleStateField;
        this.iS_QueriableField = iS_QueriableField;
        this.compositionSignatureField = compositionSignatureField;         
        this.systemIDField = systemID is not null && systemID.areAllPropsNullOrEmpty() ? null : systemID;        
        this.healthCareFacilityIDField = healthCareFacilityIDField is not null && healthCareFacilityIDField.areAllPropsNullOrEmpty() ? null : healthCareFacilityIDField;
        this.patientUIDField = patientUIDField;
        this.compositionUIDField = compositionUIDField;
        this.committerField = committerField;
        _localId = localId;        
        this.universityID = universityID is not null && universityID.areAllPropsNullOrEmpty() ? null : universityID;
        _deactivate = deactivate;
        this.withoutId = withoutId;
    }
    /// <summary>
    /// برای مبدل جی سان
    /// </summary>
    /// <param name="registerUID"></param>
    /// <param name="messageUID"></param>
    /// <param name="versionLifecycleState"></param>
    /// <param name="version"></param>
    /// <param name="iS_Queriable"></param>
    /// <param name="compositionSignature"></param>
    /// <param name="systemID"></param>
    /// <param name="healthCareFacilityID"></param>
    /// <param name="universityID"></param>
    /// <param name="patientUID"></param>
    /// <param name="withoutId"></param>
    /// <param name="compositionUID"></param>
    /// <param name="committer"></param>
    /// <param name="localId"></param>
    /// <param name="deactivate"></param>    
    [System.Text.Json.Serialization.JsonConstructor]
    private MessageIdentifierVODto(string? registerUID, string? messageUID, DO_CODED_TEXT? versionLifecycleState, int version, bool? iS_Queriable, SignatureVO? compositionSignature, 
                                    DO_IDENTIFIER? systemID, DO_IDENTIFIER? healthCareFacilityID, DO_IDENTIFIER? universityID, string? patientUID, bool? withoutId, string? compositionUID, 
                                    ProviderInfoVO? committer, string? localId, bool? deactivate)
    {
        RegisterUID = registerUID;
        MessageUID = messageUID;
        VersionLifecycleState = versionLifecycleState is not null && versionLifecycleState.areAllPropsNullOrEmpty() ? null : versionLifecycleState;
        Version = version;
        IS_Queriable = iS_Queriable;       
        CompositionSignature = compositionSignature;         
        SystemID = systemID is not null && systemID.areAllPropsNullOrEmpty() ? null : systemID;
        HealthCareFacilityID = healthCareFacilityID is not null && healthCareFacilityID.areAllPropsNullOrEmpty() ? null : healthCareFacilityID;        
        UniversityID = universityID is not null && universityID.areAllPropsNullOrEmpty() ? null : universityID;
        PatientUID = patientUID;
        WithoutId = withoutId;
        CompositionUID = compositionUID;
        Committer = committer;
        LocalId = localId;
        Deactivate = deactivate;
    }

    private DO_CODED_TEXT? versionLifecycleStateField;

    private bool? iS_QueriableField;

    private SignatureVO? compositionSignatureField;

    private DO_IDENTIFIER? systemIDField;

    private DO_IDENTIFIER? healthCareFacilityIDField;

    private string? patientUIDField;

    private string? compositionUIDField;

    private ProviderInfoVO? committerField;
    private string? _localId;
    private DO_IDENTIFIER? universityID;

    private bool? _deactivate = false;
    //private int field;
    private bool? withoutId;
    /// <summary>
    /// شناسه منحصر به فرد ثبت اطلاعات بیمه شده در هاب بیمه مرکزی است که به ازای هر بیمه شده  در داده پیام  ارسالی به سیستم بازگردانده میشود. سیستمهای جامع بیمه گری شرکت ها باید این شناسه ثبت را در سیستم خود نگهداری کنند.
    /// </summary>
    public string? RegisterUID { get; private set; }
    /// <summary>
    /// شناسه یکتای داده پیام ارسالی به هاب بیمه مرکزی است که به ازای هر تراکنش شناسه یکتا به سیستم بازگردانده میشود. سیستمهای جامع بیمه گری شرکت ها باید این شناسه را در سیستم خود نگهداری کنند.
    /// </summary>
    public string? MessageUID { get; private set; }
    /// <summary>
    /// وضعیت ارسال پرونده. تا زمانی که نیاز به ویرایش پرونده باشد مقدار این ویژگی به صورت "incomplete" می باشد. 
    /// </summary>
    public DO_CODED_TEXT? VersionLifecycleState
    {
        get
        {
            return versionLifecycleStateField;
        }
        private set
        {
            versionLifecycleStateField = value;
        }
    }
    /// <summary>
    /// نسخه بیمه نامه و بیمه شونده
    /// </summary>
    public int Version { get; private set; }
    /// <summary>
    ///  آیا سوابق پیام ارسالی برای دیگران قابل مشاهده باشد یا خیر?
    /// </summary>    
    public bool? IS_Queriable
    {
        get
        {
            return iS_QueriableField;
        }
        private set
        {
            iS_QueriableField = value;
        }
    }

    /// <summary>
    /// اطلاعات امضای الکترونیکی داده پیام
    /// </summary>
    public SignatureVO? CompositionSignature
    {
        get
        {
            return compositionSignatureField;
        }
        private set
        {
            compositionSignatureField = value;
        }
    }

    /// <summary>
    /// شناسه یگانه سیستم نرم افزاری ارسال کننده داده
    /// </summary>
    public DO_IDENTIFIER? SystemID
    {
        get
        {
            return systemIDField;
        }
        private set
        {
            systemIDField = value;
        }
    }

    /// <summary>
    /// شناسه ‌یگانه ‌مرکز ارائه دهنده ‌خدمت ‌بهداشتی درمانی
    /// </summary>
    public DO_IDENTIFIER? HealthCareFacilityID
    {
        get
        {
            return healthCareFacilityIDField;
        }
        private set
        {
            healthCareFacilityIDField = value;
        }
    }
    /// <summary>
    /// شناسه ‌یگانه ‌دانشگاه ناظر رائه دهنده ‌خدمت ‌بهداشتی درمانی
    /// </summary>
    public DO_IDENTIFIER? UniversityID
    {
        get
        {
            return universityID;
        }
        private set
        {
            universityID = value;
        }
    }
    /// <summary>
    /// شناسه منحصر به فرد بیمار
    /// </summary>
    public string? PatientUID
    {
        get
        {
            return patientUIDField;
        }
        private set
        {
            patientUIDField = value;
        }
    }
    /// <summary>
    /// مجهول الهویه بودن بیمار
    /// </summary>    
    public bool? WithoutId
    {
        get
        {
            return withoutId;
        }
        private set
        {
            withoutId = value;
        }
    }

    /// <summary>
    /// شناسه منحصر به فرد مربوط به یک مراجعه
    /// </summary>
    public string? CompositionUID
    {
        get
        {
            return compositionUIDField;
        }
        private set
        {
            compositionUIDField = value;
        }
    }

    /// <summary>
    /// مشخصات فرد مسئول ثبت کننده اطلاعات 
    /// </summary>
    public ProviderInfoVO? Committer
    {
        get
        {
            return committerField;
        }
        private set
        {
            committerField = value;
        }
    }

    /// <summary>
    /// شناسه محلی ثبت شده در سامانه بهداشتی/درمانی
    /// </summary>
    public string? LocalId
    {
        get
        {
            return _localId;
        }
        set
        {
            _localId = value;
        }
    }


    /// <summary>
    /// اگر مقدار  CompositionUID  مشخص باشد و مقدار این فیلد true باشد به معنای غیر فعال کردن رکورد خواهد بود.
    /// </summary>
    public bool? Deactivate
    {
        get => _deactivate;
        private set => _deactivate = value;
    }

}