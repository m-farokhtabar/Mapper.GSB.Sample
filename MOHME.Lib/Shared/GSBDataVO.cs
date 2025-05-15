using System.Globalization;

namespace MOHME.Lib.Shared
{
    /// <summary>
    /// پاسخ GSB
    /// در صورتی که عملیات به درستی انجام شده باشد
    /// </summary>
    public class GSBDataVO
    {
       /// <summary>
       /// ایجاد شی نتایج بیمه سلامت
       /// </summary>
       /// <param name="igin"></param>
       /// <param name="registerID"></param>
       /// <param name="recommandMessage"></param>
       /// <param name="registerDate"></param>
        public GSBDataVO(DO_IDENTIFIER? igin, string? registerID, string? recommandMessage, DO_DATE_TIME? registerDate)
        {
            //این قسمت فقط نوشته شده جهت تصحیح داده ها
            if (igin is not null && string.IsNullOrWhiteSpace(igin.ID))
                igin.ID = "_";            
            if (registerDate is not null)
            {
                PersianCalendar Pc = new();
                var CurrentDate = DateTime.Now;
                registerDate.Year ??= Pc.GetYear(CurrentDate);
                registerDate.Month ??= Pc.GetMonth(CurrentDate);
                registerDate.Day ??= Pc.GetDayOfMonth(CurrentDate);
                registerDate.Hour ??= Pc.GetHour(CurrentDate);
                registerDate.Minute ??= Pc.GetMinute(CurrentDate);
                registerDate.Second ??= Pc.GetSecond(CurrentDate);
                if (registerDate.Hour == 24)
                    registerDate.Hour = 0;
            }
            Igin = igin;
            RegisterID = registerID;
            RecommandMessage = recommandMessage;
            RegisterDate = registerDate;
            
        }

        /// <summary>
        /// شناسه منحصر بفرد بیمه شده در بانک تجمیع بیمه سلامت
        /// GSB پاسخ
        /// </summary>
        /// <remarks>با توجه به غیر قابل پیش بینی بودن پاسخ سرور مربوطه من پارامتر را اختیاری گرفتم</remarks>
        public DO_IDENTIFIER? Igin { get; private set; }
        /// <summary>
        /// شناسه تولید شده در فرآیند ثبت اطلاعات بیمه شده
        /// GSB پاسخ
        /// </summary>
        public string? RegisterID { get; private set; }
        /// <summary>
        /// توضیحات تکمیلی
        /// GSB پاسخ
        /// </summary>
        /// <remarks>با توجه به غیر قابل پیش بینی بودن پاسخ سرور مربوطه من پارامتر را اختیاری گرفتم</remarks>
        public string? RecommandMessage { get; private set; }
        /// <summary>
        /// تاریخ و ساعت ثبت
        /// GSB پاسخ
        /// </summary>
        /// <remarks>با توجه به غیر قابل پیش بینی بودن پاسخ سرور مربوطه من پارامتر را اختیاری گرفتم</remarks>
        public DO_DATE_TIME? RegisterDate { get; private set; }
    }
}
