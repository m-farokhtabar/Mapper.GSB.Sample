using Services.ExceptionManager;
using Services.ExceptionManager.Resources;
using Mapper.GSB.Share.Resource;
using MOHME.Lib.Shared;

namespace MOHME.Lib.Helper.Validator
{
    /// <summary>
    /// بررسی صحت داده های کلاس تاریخ
    /// </summary>
    public static class DoTimeValidator
    {
        /// <summary>
        /// اگر فیلدهای مهم همه نال یا رشته خالی هستند
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool areAllPropsNullOrEmpty(this DO_TIME data)
        {
            return data is null || (!data.Hour.HasValue && !data.Minute.HasValue && !data.Second.HasValue);                   
        }
    }
}
