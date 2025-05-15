using Mapper.openEHR.ModelToOPT.SeedWork;

namespace Mapper.GSB.Application.Services.Terminology.openEHR;

/// <summary>
/// تنظیمات مورد جهت دریافت اطلاعات ترمینولوژی های 
/// openEHR
/// بر اساس استاندارد
/// FHIR
/// </summary>
public interface IOpenEHRTerminologySetting : IMapperSetting
{
    #region AuditChangeType
    /// <summary>
    /// آدرس منحصربفرد کد
    /// </summary>
    string OpenEHRTerminology_ValueSet_AuditChangeType_Url { get; }
    /// <summary>
    /// تسخه
    /// </summary>
    string OpenEHRTerminology_ValueSet_AuditChangeType_Version { get; }
    /// <summary>
    /// زبان پیش فرض
    /// </summary>
    string OpenEHRTerminology_ValueSet_AuditChangeType_DefaultLanguage { get; }
    /// <summary>
    /// کدینگ پیش فرض زبان
    /// </summary>
    string OpenEHRTerminology_ValueSet_AuditChangeType_DefaultCharacterSet { get; }
    /// <summary>
    /// کد ایجاد داده ها
    /// </summary>
    string OpenEHRTerminology_ValueSet_AuditChangeType_CreationId { get; }
    /// <summary>
    /// کد ویرایش
    /// </summary>
    string OpenEHRTerminology_ValueSet_AuditChangeType_Modification { get; }
    /// <summary>
    /// کد حذف
    /// </summary>
    string OpenEHRTerminology_ValueSet_AuditChangeType_DeletedId { get; }
    #endregion

    #region VersionLifecycleState
    /// <summary>
    /// آدرس منحسربفرد کد
    /// </summary>
    string OpenEHRTerminology_ValueSet_VersionLifecycleState_Url { get; }
    /// <summary>
    /// نسخه
    /// </summary>
    string OpenEHRTerminology_ValueSet_VersionLifecycleState_Version { get; }
    /// <summary>
    /// زبان پیش فرض
    /// </summary>
    string OpenEHRTerminology_ValueSet_VersionLifecycleState_DefaultLanguage { get; }
    /// <summary>
    /// کدینگ پیش فرض زبان
    /// </summary>
    string OpenEHRTerminology_ValueSet_VersionLifecycleState_DefaultCharacterSet { get; }
    /// <summary>
    /// داده  به صورت کامل است و امکان اعتبار سنجی دارد
    /// </summary>
    string OpenEHRTerminology_ValueSet_VersionLifecycleState_CompleteId { get; }
    /// <summary>
    /// داده  به صورت ناقص است و امکان اعتبار سنجی ندارد
    /// </summary>
    string OpenEHRTerminology_ValueSet_VersionLifecycleState_IncompleteId { get; }
    /// <summary>
    /// داده حذف شده است
    /// </summary>
    string OpenEHRTerminology_ValueSet_VersionLifecycleState_DeletedId { get; }
    #endregion

    /// <summary>
    /// کد ترمینولوژی استاندارد
    /// openEHR
    /// </summary>
    string OpenEHRTerminology_Id { get; }
    /// <summary>
    /// مجموعه کد
    /// openEHR
    /// </summary>
    string OpenEHRTerminology_CodeSystemUrl { get; }
    /// <summary>
    /// زیر مجموعه کد
    /// openEHR
    /// </summary>
    string OpenEHRTerminology_CodeSystemVersion { get; }

}
