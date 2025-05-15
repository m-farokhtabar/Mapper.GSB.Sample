using MOHME.Lib.Shared;

namespace MOHME.Lib.OpenEHRBaseClasses
{
    /// <summary>
    /// 
    /// </summary>
    public class EHRMessageHeaderVO
    {
        private MessageIdentifierVO _msgId;
        private PersonInfoVO _person;
        private DateTime _serviceDateTime;
        private int _recordVersion;
        private int _recordStatus;
        private TimeSpan _lastOperationDate;
        /// <summary>
        /// مشخصات پیام ارسالی
        /// </summary>

        public virtual MessageIdentifierVO MsgID
        {
            get
            {
                return _msgId;
            }
            set
            {
                _msgId = value;
            }
        }
        /// <summary>
        /// کلاس شامل داده‌های هویتی بیمار و اطلاعات تماس وی 
        /// </summary>
        public virtual PersonInfoVO Person
        {
            get
            {
                return _person;
            }
            set
            {
                _person = value;
            }
        }


        /// <summary>
        /// تاریخ و زمان ثبت خدمت بهداشتی/درمانی
        /// </summary>
        public virtual DateTime ServiceDateTime
        {
            get => _serviceDateTime;
            set => _serviceDateTime = value;
        }
        /// <summary>
        /// نسخه داده
        /// </summary>
        public virtual int RecordVersion
        {
            get => _recordVersion;
            set => _recordVersion = value;
        }
        /// <summary>
        /// وضعیت داده
        /// </summary>
        public virtual int RecordStatus
        {
            get => _recordStatus;
            set => _recordStatus = value;
        }
        /// <summary>
        /// 
        /// </summary>
        public virtual TimeSpan LastOperationDate
        {
            get => _lastOperationDate;
            set => _lastOperationDate = value;
        }
    }
}
