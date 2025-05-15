using System.ComponentModel;

namespace MOHME.Lib.Shared
{

    /// <summary>
    /// عملیات
    /// </summary>
    public enum Operation
    {
        /// <summary>
        /// درج
        /// </summary>
        [Description("درج")]
        Insert = 1,
        /// <summary>
        /// بروزرسانی
        /// </summary>
        [Description("بروزرسانی")]
        Update = 2,

        /// <summary>
        /// غیر فعال سازی
        /// </summary>
        [Description("غیر فعال سازی")]
        Deactivation = 3,
    }
    /// <summary>
    /// 
    /// </summary>
    public enum RecordStatus : short
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("حذف شده")]
        Removed = -2,
        /// <summary>
        /// 
        /// </summary>
        [Description("در حال حذف")]
        Removing = -1,

        /// <summary>
        /// 
        /// </summary>
        [Description("غیرفعال")]
        Inactive = 0,

        /// <summary>
        /// 
        /// </summary>
        [Description("فعال")]
        Active = 1,

        //[Description("در حال ویرایش")]
        //Editing = 2,
        /// <summary>
        /// 
        /// </summary>
        [Description("ویرایش شده")]
        Edited = 3,

    }
    /// <summary>
    /// وابستگی سرویس به بیمار
    /// <remarks>
    /// 1 : Dependent
    /// 2 : Independent
    /// 3 : Conditional
    /// </remarks>
    /// </summary>
    /// <remarks>
    /// 1 : Dependent
    /// 2 : Independent
    /// 3 : Conditional
    /// </remarks>
    public enum PatientDependency : short
    {
        /// <summary>
        /// Dependent
        /// </summary>
        Dependent = 1,
        /// <summary>
        /// Independent
        /// </summary>
        Independent = 2,
        /// <summary>
        /// Conditional
        /// </summary>
        Conditional = 3

    }
}
