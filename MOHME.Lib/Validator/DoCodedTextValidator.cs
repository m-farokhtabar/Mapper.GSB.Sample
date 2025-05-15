using Services.ExceptionManager;
using Services.ExceptionManager.Resources;
using Mapper.GSB.Share.Resource;
using MOHME.Lib.Shared;

namespace MOHME.Lib.Helper.Validator
{
    /// <summary>
    /// بررسی صحت داده های کلاس کد
    /// </summary>
    public static class DoCodedTextValidator
    {
        /// <summary>
        /// بررسی صحت تمامی فیلدهای مورد نیاز کد در 
        /// openEHR
        /// </summary>
        /// <param name="code"></param>
        /// <param name="classNameForMessage">نام فارسی کلاس خصوصیت</param>
        /// <param name="propertyNameMessage">نام فارسی خصوصیت</param>
        /// <param name="fullPropertyName">آدرس کامل کلاس و نام خصوصیت به همراه نام فضای نام</param>        
        public static void Validate(this DO_CODED_TEXT code,string classNameForMessage, string propertyNameMessage, string fullPropertyName)
        {
            if (string.IsNullOrWhiteSpace(code.Value))
                throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", classNameForMessage).Replace("{1}", Names.DoCodedText_Value + " " + propertyNameMessage), ExceptionType.InValid, fullPropertyName+ "." + nameof(code.Value));
            if (string.IsNullOrWhiteSpace(code.Terminology_id))
                throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", classNameForMessage).Replace("{1}", Names.DoCodedText_Terminology + " " + propertyNameMessage), ExceptionType.InValid, fullPropertyName + "." + nameof(code.Terminology_id));
            if (string.IsNullOrWhiteSpace(code.Coded_string))
                throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", classNameForMessage).Replace("{1}", Names.DoCodedText_Code + " " + propertyNameMessage), ExceptionType.InValid, fullPropertyName + "." + nameof(code.Coded_string));

        }
        /// <summary>
        /// اگر فیلدهای مهم همه نال یا رشته خالی هستند
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool areAllPropsNullOrEmpty(this DO_CODED_TEXT data)
        {
            return data is null || (string.IsNullOrWhiteSpace(data.Value) && string.IsNullOrWhiteSpace(data.Terminology_id) && string.IsNullOrWhiteSpace(data.Coded_string));
        }
    }
}
