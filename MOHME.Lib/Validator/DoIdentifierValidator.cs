using Services.ExceptionManager;
using Services.ExceptionManager.Resources;
using MOHME.Lib.Shared;

namespace MOHME.Lib.Helper.Validator
{
    /// <summary>
    /// بررسی صحت داده های کلاس شناسه
    /// </summary>
    public static class DoIdentifierValidator
    {
        /// <summary>
        /// بررسی صحت تمامی فیلدهای مورد نیاز شناسه در 
        /// openEHR
        /// </summary>
        /// <param name="id"></param>
        /// <param name="classNameForMessage">نام فارسی کلاس خصوصیت</param>
        /// <param name="propertyNameMessage">نام فارسی خصوصیت</param>
        /// <param name="fullPropertyName">آدرس کامل کلاس و نام خصوصیت به همراه نام فضای نام</param>        
        public static void Validate(this DO_IDENTIFIER id,string classNameForMessage, string propertyNameMessage, string fullPropertyName)
        {
            if (string.IsNullOrWhiteSpace(id.ID))
                throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", classNameForMessage).Replace("{1}", propertyNameMessage), ExceptionType.InValid, fullPropertyName+ "." + nameof(id.ID));

        }
        /// <summary>
        /// اگر فیلدهای مهم همه نال یا رشته خالی هستند
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool areAllPropsNullOrEmpty(this DO_IDENTIFIER data)
        {
            return data is null || (string.IsNullOrWhiteSpace(data.ID) && string.IsNullOrWhiteSpace(data.Issuer) && string.IsNullOrWhiteSpace(data.Assigner) && string.IsNullOrWhiteSpace(data.Type));
        }
    }
}
