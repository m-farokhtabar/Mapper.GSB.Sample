using Services.ExceptionManager;
using Services.ExceptionManager.Resources;
using Mapper.GSB.Share.Resource;
using MOHME.Lib.Shared;

namespace MOHME.Lib.Helper.Validator
{
    /// <summary>
    /// بررسی صحت داده های کلاس تاریخ
    /// </summary>
    public static class DoDateValidator
    {
        /// <summary>
        /// بررسی صحت تمامی فیلدهای مورد نیاز تاریخ در 
        /// openEHR
        /// </summary>
        /// <param name="date"></param>
        /// <param name="classNameForMessage">نام فارسی کلاس خصوصیت</param>
        /// <param name="propertyNameMessage">نام فارسی خصوصیت</param>
        /// <param name="fullPropertyName">آدرس کامل کلاس و نام خصوصیت به همراه نام فضای نام</param>        
        public static void Validate(this DO_DATE date, string classNameForMessage, string propertyNameMessage, string fullPropertyName)
        {
            if (date.Year is null || date.Year < 1)
                throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", classNameForMessage).Replace("{1}", Names.Year + " " + propertyNameMessage), ExceptionType.InValid, fullPropertyName + "." + nameof(date.Year));
            if (date.Month is null || date.Month < 1 || date.Month > 12)
                throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", classNameForMessage).Replace("{1}", Names.Month + " " + propertyNameMessage), ExceptionType.InValid, fullPropertyName + "." + nameof(date.Month));
            if (date.Day is null || date.Day < 1 || date.Day > 31)
                throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", classNameForMessage).Replace("{1}", Names.Day + " " + propertyNameMessage), ExceptionType.InValid, fullPropertyName + "." + nameof(date.Day));
        }
        /// <summary>
        /// اگر فیلدهای مهم همه نال یا رشته خالی هستند
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool areAllPropsNullOrEmpty(this DO_DATE data)
        {
            return data is null || (!data.Year.HasValue && !data.Month.HasValue && !data.Day.HasValue);                                   
        }
    }
}
