using openEHR.Library.Rm.DataTypes.Text;

namespace Mapper.GSB.Application.Services.Terminology.openEHR
{
    /// <summary>
    /// سرویس دریافت ترمینولوژی های مورد نیاز
    /// </summary>
    public interface IOpenEHRTerminologyService
    {
        /// <summary>
        /// دریافت تمامی کدهای ترمینولوژی چرخه داده ها در
        /// openEHR
        /// </summary>
        /// <returns></returns>
        Task<List<DvCodedText>> GetVersionLifecycleState();
        /// <summary>
        /// دریافت تمامی کدهای ترمینولوژی عملیات های اعمال شده بر روی داده ها در
        /// openEHR
        /// </summary>
        /// <returns></returns>
        Task<List<DvCodedText>> GetAuditChangeType();
        /// <summary>
        /// دریافت کد تغییرات، ایجاد داده
        /// </summary>
        /// <returns></returns>
        Task<DvCodedText> GetAuditChangeCreationId();
        /// <summary>
        /// دریافت کد تغییرات، ویرایش داده
        /// </summary>
        /// <returns></returns>
        Task<DvCodedText> GetAuditChangeModificationId();
        /// <summary>
        /// دریافت کد وضعیت داده، کامل بودن داده
        /// </summary>
        /// <returns></returns>
        Task<DvCodedText> GetVersionLifecycleStateCompleteId();
        /// <summary>
        /// دریافت کد وضعیت داده، ناقص بودن داده
        /// </summary>
        /// <returns></returns>
        Task<DvCodedText> GetVersionLifecycleStateInCompleteId();
    }
}
