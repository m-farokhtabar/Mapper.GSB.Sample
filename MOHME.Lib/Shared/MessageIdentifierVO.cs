using Services.ExceptionManager;
using Services.ExceptionManager.Resources;
using Mapper.GSB.Share.Resource;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using System.ComponentModel.Design;
using MOHME.Lib.Helper.Validator;
using System.Reflection;

namespace MOHME.Lib.Shared
{
    /// <summary>
    /// اطلاعات مورد استفاده در تبادل داده با سرویس‌های پرونده الکترونیکی سلامت می‌باشد
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.1")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://thrita.behdasht.gov.ir/VM/")]
    public partial class MessageIdentifierVO
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
        /// <param name="isInsert"></param>
        /// <exception cref="ManualException"></exception>
        public MessageIdentifierVO(DO_CODED_TEXT? versionLifecycleStateField, bool? iS_QueriableField, SignatureVO? compositionSignatureField, DO_IDENTIFIER? systemID, DO_IDENTIFIER? healthCareFacilityIDField, 
                                   string? patientUIDField, string? compositionUIDField, ProviderInfoVO? committerField, string? localId, DO_IDENTIFIER? universityID, bool? deactivate, bool? withoutId, int? version, string? registerUID, string? messageUID, bool isInsert)
        {
            Validate(versionLifecycleStateField, systemID, healthCareFacilityIDField, universityID, version, registerUID, messageUID, isInsert);

            this.MessageUID = messageUID;
            if (isInsert)
            {
                this.RegisterUID = Guid.NewGuid().ToString();
                this.Version = 1;
            }
            else
            {
                this.Version = version!.Value;
                this.RegisterUID = registerUID;
            }
            this.versionLifecycleStateField = versionLifecycleStateField;
            this.iS_QueriableField = iS_QueriableField;
            this.compositionSignatureField = compositionSignatureField;
            this.systemIDField = systemID;
            this.healthCareFacilityIDField = healthCareFacilityIDField;
            this.patientUIDField = patientUIDField;
            this.compositionUIDField = compositionUIDField;
            this.committerField = committerField;
            _localId = localId;
            this.universityID = universityID;
            _deactivate = deactivate;
            this.withoutId = withoutId;            
        }
        /// <summary>
        /// فقط برای جس سان
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
        private MessageIdentifierVO(string? registerUID, string? messageUID, DO_CODED_TEXT? versionLifecycleState, int version, bool? iS_Queriable, SignatureVO? compositionSignature, DO_IDENTIFIER? systemID, DO_IDENTIFIER? healthCareFacilityID, DO_IDENTIFIER? universityID, string? patientUID, bool? withoutId, string? compositionUID, ProviderInfoVO? committer, string? localId, bool? deactivate)
        {
            RegisterUID = registerUID;
            MessageUID = messageUID;
            VersionLifecycleState = versionLifecycleState;
            Version = version;
            IS_Queriable = iS_Queriable;
            CompositionSignature = compositionSignature;
            SystemID = systemID;
            HealthCareFacilityID = healthCareFacilityID;
            UniversityID = universityID;
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
        [XmlElement(IsNullable = true)]
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
        //[Required(ErrorMessageResourceName = "FieldRequiredError", ErrorMessageResourceType = typeof(SDKValidationMessages))]
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
        //[Required(ErrorMessageResourceName = "FieldRequiredError", ErrorMessageResourceType = typeof(SDKValidationMessages))]
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
        [JsonIgnore]
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
        /// <summary>
        /// اعتبار سنجی داده های ورودی
        /// </summary>
        /// <param name="versionLifecycleStateField"></param>
        /// <param name="systemID"></param>
        /// <param name="healthCareFacilityIDField"></param>
        /// <param name="universityID"></param>
        /// <param name="version"></param>
        /// <param name="registerUID"></param>
        /// <param name="messageUID"></param>
        /// <param name="isInsert"></param>
        /// <exception cref="ManualException"></exception>
        private void Validate(DO_CODED_TEXT? versionLifecycleStateField, DO_IDENTIFIER? systemID, DO_IDENTIFIER? healthCareFacilityIDField, DO_IDENTIFIER? universityID, int? version, string? registerUID, string? messageUID, bool isInsert)
        {
            if (systemID is null)
                throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.MessageIdentifierVO).Replace("{1}", Names.MessageIdentifierVO_SystemID), ExceptionType.InValid, typeof(MessageIdentifierVO).FullName + "." + nameof(MessageIdentifierVO.SystemID));
            else
                systemID.Validate(Names.MessageIdentifierVO, Names.MessageIdentifierVO_SystemID, typeof(PersonInfoVO).FullName + "." + nameof(MessageIdentifierVO.SystemID));
                
            //حتما باید از نوع GUID
            if (!Guid.TryParse(systemID.ID, out Guid sysId))
                throw new ManualException(ExceptionsMessages.Data_is_not_valid_Value_is_wrong.Replace("{0}", Names.MessageIdentifierVO).Replace("{1}", Names.MessageIdentifierVO_SystemID), ExceptionType.InValid, typeof(MessageIdentifierVO).FullName + "." + nameof(MessageIdentifierVO.SystemID));

            if (messageUID is null || !Guid.TryParse(messageUID, out Guid mID))
                throw new ManualException(ExceptionsMessages.Data_is_not_valid_Value_is_wrong.Replace("{0}", Names.MessageIdentifierVO).Replace("{1}", Names.MessageIdentifierVO_MessageUID), ExceptionType.InValid, typeof(MessageIdentifierVO).FullName + "." + nameof(MessageIdentifierVO.MessageUID));
            
            if (!isInsert)
            {
                if (registerUID is null || !Guid.TryParse(registerUID, out Guid rID))
                    throw new ManualException(ExceptionsMessages.Data_is_not_valid_Value_is_wrong.Replace("{0}", Names.MessageIdentifierVO).Replace("{1}", Names.MessageIdentifierVO_RegisterUID), ExceptionType.InValid, typeof(MessageIdentifierVO).FullName + "." + nameof(MessageIdentifierVO.RegisterUID));
                if (!version.HasValue)
                    throw new ManualException(ExceptionsMessages.Data_is_not_valid_Value_is_wrong.Replace("{0}", Names.MessageIdentifierVO).Replace("{1}", Names.MessageIdentifierVO_Version), ExceptionType.InValid, typeof(MessageIdentifierVO).FullName + "." + nameof(MessageIdentifierVO.Version));
            }

            if (versionLifecycleStateField is not null)
                versionLifecycleStateField.Validate(Names.MessageIdentifierVO, Names.MessageIdentifierVO_VersionLifecycleState, typeof(MessageIdentifierVO).FullName + "." + nameof(VersionLifecycleState));
            if (healthCareFacilityIDField is not null)
                healthCareFacilityIDField.Validate(Names.MessageIdentifierVO, Names.MessageIdentifierVO_HealthCareFacilityID, typeof(MessageIdentifierVO).FullName + "." + nameof(HealthCareFacilityID));
            if (universityID is not null)
                universityID.Validate(Names.MessageIdentifierVO, Names.MessageIdentifierVO_UniversityID, typeof(MessageIdentifierVO).FullName + "." + nameof(UniversityID));
        }

    }
}