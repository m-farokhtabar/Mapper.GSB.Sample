//using MOHME.Lib.Shared.SDKResources;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MOHME.Lib.Shared
{
    /// <summary>
    /// نتیجه ارسال داده پیام سپاس
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.1")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://thrita.behdasht.gov.ir/VM/")]
    public partial class ResultVO
    {

        private string messageUIDField;

        private string errorMessageField;

        private string compositionUIDField;

        private string patientUIDField;
        private SepasErrorCodes errorCodeField;
        private bool _isError;
        private int _statusCode;
        private object failedEntity;
        /// <summary>
        /// وضعیت فراخوانی سرویس
        /// </summary>
        public int StatusCode
        {
            get => _statusCode;
            set => _statusCode = value;
        }

        /// <summary>
        /// ایا فراخوانی سرویس با خطا مواجه شد؟
        /// </summary>
        public bool IsError
        {
            get => _isError;
            set
            {
                _isError = value;
                if (value == false)
                    StatusCode = 200;
                else
                {
                    StatusCode = 400;
                }
            }

        }

        /// <summary>
        /// شناسه یکتای داده‌پیام ارسالی به سپاس
        /// </summary>
        public string MessageUID
        {
            get
            {
                return messageUIDField;
            }
            set
            {
                messageUIDField = value;
            }
        }
        private string localId;
        /// <summary>
        /// شناسه محلی رکورد(شناسه یکتای رکورد موجود در سامانه های بهداشتی/ درمانی)
        /// </summary>
        //[Display(Name = "LocalId", ResourceType = typeof(SDKMessages))]
        //[Required(ErrorMessageResourceName = "FieldRequiredError", ErrorMessageResourceType = typeof(SDKValidationMessages))]//
        public virtual string LocalId
        {
            get => localId;
            set => localId = value;
        }
        private string _personIdentifier;
        private int? _recordVersion;


        /// <summary>
        /// شناسه فرد
        /// </summary>
        //[Display(Name = "PersonIdentifier", ResourceType = typeof(SDKMessages))]
        public virtual string PersonIdentifier
        {
            get { return this._personIdentifier; }
            set
            {
                this._personIdentifier = value;

            }
        }
        /// <summary>
        /// در صورتی که در ارسال داده ها اشکالی رخ داده باشد، این ویژگی با کد خطای رخ‌داده پُر میشود و جهت خطایابی در اختیار سیستم ارسال‌کننده قرار میگیرد.
        /// </summary>
        public SepasErrorCodes ErrorCode
        {
            get
            {
                return errorCodeField;
            }
            set
            {
                errorCodeField = value;
            }
        }
        /// <summary>
        /// در صورتی که در ارسال داده ها اشکالی رخ داده باشد، این ویژگی با پیغام خطای رخ‌داده پُر میشود و جهت خطایابی در اختیار سیستم ارسال‌کننده قرار میگیرد.
        /// </summary>
        public string ErrorMessage
        {
            get
            {
                return errorMessageField;
            }
            set
            {
                errorMessageField = value;
            }
        }
        /// <summary>
        /// آبجکتی که با خطا مواجه شده است
        /// </summary>
        //[Display(Name = "FailedEntity", ResourceType = typeof(SDKMessages))]
        public virtual object FailedEntity
        {
            get { return this.failedEntity; }
            set
            {
                this.failedEntity = value;

            }
        }
        /// <summary>
        /// شناسه منحصر به ‌فرد مربوط به اطلاعات پرونده بالینی تشکیل شده 
        /// </summary>
        public string CompositionUID
        {
            get
            {
                return compositionUIDField;
            }
            set
            {
                compositionUIDField = value;
            }
        }

        /// <summary>
        /// شناسه یکتای بیمار
        /// </summary>
        public string PatientUID
        {
            get
            {
                return patientUIDField;
            }
            set
            {
                patientUIDField = value;
            }
        }

        /// <summary>
        /// نسخه رکورد
        /// </summary>
        public int? RecordVersion
        {
            get => _recordVersion;
            set => _recordVersion = value;
        }

        /// <summary>
        /// عملیات
        /// </summary>
        public Operation Operation
        {
            get;
            set;
        } = Operation.Insert;
    }
}