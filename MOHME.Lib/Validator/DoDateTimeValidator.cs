using Services.ExceptionManager;
using Services.ExceptionManager.Resources;
using Mapper.GSB.Share.Resource;
using MOHME.Lib.Shared;

namespace MOHME.Lib.Helper.Validator
{
    /// <summary>
    /// بررسی صحت داده های کلاس تاریخ
    /// </summary>
    public static class DoDateTimeValidator
    {
        /// <summary>
        /// بررسی صحت تمامی فیلدهای مورد نیاز تاریخ در 
        /// openEHR
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="classNameForMessage">نام فارسی کلاس خصوصیت</param>
        /// <param name="propertyNameMessage">نام فارسی خصوصیت</param>
        /// <param name="fullPropertyName">آدرس کامل کلاس و نام خصوصیت به همراه نام فضای نام</param>        
        public static void Validate(this DO_DATE_TIME dateTime, string classNameForMessage, string propertyNameMessage, string fullPropertyName)
        {
            if (dateTime.Year is null || dateTime.Year < 1)
                throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", classNameForMessage).Replace("{1}", Names.Year + " " + propertyNameMessage), ExceptionType.InValid, fullPropertyName + "." + nameof(dateTime.Year));
            if (dateTime.Month is null || dateTime.Month < 1 || dateTime.Month > 12)
                throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", classNameForMessage).Replace("{1}", Names.Month + " " + propertyNameMessage), ExceptionType.InValid, fullPropertyName + "." + nameof(dateTime.Month));
            if (dateTime.Day is null || dateTime.Day < 1 || dateTime.Day > 31)
                throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", classNameForMessage).Replace("{1}", Names.Day + " " + propertyNameMessage), ExceptionType.InValid, fullPropertyName + "." + nameof(dateTime.Day));
            if (dateTime.Hour is null || dateTime.Hour < 0  || dateTime.Hour > 23)
                throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", classNameForMessage).Replace("{1}", Names.Hour + " " + propertyNameMessage), ExceptionType.InValid, fullPropertyName + "." + nameof(dateTime.Hour));
            if (dateTime.Minute is null || dateTime.Minute < 0 || dateTime.Minute > 59)
                throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", classNameForMessage).Replace("{1}", Names.Minute + " " + propertyNameMessage), ExceptionType.InValid, fullPropertyName + "." + nameof(dateTime.Minute));
            if (dateTime.Second is null || dateTime.Second < 0 || dateTime.Second > 59)
                throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", classNameForMessage).Replace("{1}", Names.Second + " " + propertyNameMessage), ExceptionType.InValid, fullPropertyName + "." + nameof(dateTime.Second));
        }
        /// <summary>
        /// اگر فیلدهای مهم همه نال یا رشته خالی هستند
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool areAllPropsNullOrEmpty(this DO_DATE_TIME data)
        {
            return data is null || (!data.Year.HasValue && !data.Month.HasValue && !data.Day.HasValue && !data.Hour.HasValue && !data.Minute.HasValue && !data.Second.HasValue);
        }
    }
}
