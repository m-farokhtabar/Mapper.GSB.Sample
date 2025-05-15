using Mapper.GSB.Application.Services.Terminology.openEHR;

namespace Mapper.GSB.Host.DDRAPICaller.StartupConfig.Settings
{
    /// <summary>
    /// <see cref="IOpenEHRTerminologySetting"/>
    /// </summary>
    public class OpenEHRTerminologySettings : IOpenEHRTerminologySetting
    {
        /// <summary>
        /// <see cref="IOpenEHRTerminologySetting.OpenEHRTerminology_ValueSet_AuditChangeType_Url"/>
        /// </summary>
        public string OpenEHRTerminology_ValueSet_AuditChangeType_Url { get; init; } = string.Empty;

        /// <summary>
        /// <see cref="IOpenEHRTerminologySetting.OpenEHRTerminology_ValueSet_AuditChangeType_Version"/>
        /// </summary>
        public string OpenEHRTerminology_ValueSet_AuditChangeType_Version { get; init; } = string.Empty;

        /// <summary>
        /// <see cref="IOpenEHRTerminologySetting.OpenEHRTerminology_ValueSet_AuditChangeType_DefaultLanguage"/>
        /// </summary>
        public string OpenEHRTerminology_ValueSet_AuditChangeType_DefaultLanguage { get; init; } = string.Empty;

        /// <summary>
        /// <see cref="IOpenEHRTerminologySetting.OpenEHRTerminology_ValueSet_AuditChangeType_DefaultCharacterSet"/>
        /// </summary>
        public string OpenEHRTerminology_ValueSet_AuditChangeType_DefaultCharacterSet { get; init; } = string.Empty;

        /// <summary>
        /// <see cref="IOpenEHRTerminologySetting.OpenEHRTerminology_ValueSet_AuditChangeType_CreationId"/>
        /// </summary>
        public string OpenEHRTerminology_ValueSet_AuditChangeType_CreationId { get; init; } = string.Empty;

        /// <summary>
        /// <see cref="IOpenEHRTerminologySetting.OpenEHRTerminology_ValueSet_AuditChangeType_Modification"/>
        /// </summary>
        public string OpenEHRTerminology_ValueSet_AuditChangeType_Modification { get; init; } = string.Empty;

        /// <summary>
        /// <see cref="IOpenEHRTerminologySetting.OpenEHRTerminology_ValueSet_AuditChangeType_DeletedId"/>
        /// </summary>
        public string OpenEHRTerminology_ValueSet_AuditChangeType_DeletedId { get; init; } = string.Empty;

        /// <summary>
        /// <see cref="IOpenEHRTerminologySetting.OpenEHRTerminology_ValueSet_VersionLifecycleState_Url"/>
        /// </summary>
        public string OpenEHRTerminology_ValueSet_VersionLifecycleState_Url { get; init; } = string.Empty;

        /// <summary>
        /// <see cref="IOpenEHRTerminologySetting.OpenEHRTerminology_ValueSet_VersionLifecycleState_Version"/>
        /// </summary>
        public string OpenEHRTerminology_ValueSet_VersionLifecycleState_Version { get; init; } = string.Empty;

        /// <summary>
        /// <see cref="IOpenEHRTerminologySetting.OpenEHRTerminology_ValueSet_VersionLifecycleState_DefaultLanguage"/>
        /// </summary>
        public string OpenEHRTerminology_ValueSet_VersionLifecycleState_DefaultLanguage { get; init; } = string.Empty;

        /// <summary>
        /// <see cref="IOpenEHRTerminologySetting.OpenEHRTerminology_ValueSet_VersionLifecycleState_DefaultCharacterSet"/>
        /// </summary>
        public string OpenEHRTerminology_ValueSet_VersionLifecycleState_DefaultCharacterSet { get; init; } = string.Empty;

        /// <summary>
        /// <see cref="IOpenEHRTerminologySetting.OpenEHRTerminology_ValueSet_VersionLifecycleState_CompleteId"/>
        /// </summary>
        public string OpenEHRTerminology_ValueSet_VersionLifecycleState_CompleteId { get; init; } = string.Empty;

        /// <summary>
        /// <see cref="IOpenEHRTerminologySetting.OpenEHRTerminology_ValueSet_VersionLifecycleState_IncompleteId"/>
        /// </summary>
        public string OpenEHRTerminology_ValueSet_VersionLifecycleState_IncompleteId { get; init; } = string.Empty;

        /// <summary>
        /// <see cref="IOpenEHRTerminologySetting.OpenEHRTerminology_ValueSet_VersionLifecycleState_DeletedId"/>
        /// </summary>
        public string OpenEHRTerminology_ValueSet_VersionLifecycleState_DeletedId { get; init; } = string.Empty;

        /// <summary>
        /// <see cref="IOpenEHRTerminologySetting.OpenEHRTerminology_Id"/>
        /// </summary>
        public string OpenEHRTerminology_Id { get; init; } = string.Empty;

        /// <summary>
        /// <see cref="IOpenEHRTerminologySetting.OpenEHRTerminology_CodeSystemUrl"/>
        /// </summary>
        public string OpenEHRTerminology_CodeSystemUrl { get; init; } = string.Empty;

        /// <summary>
        /// <see cref="IOpenEHRTerminologySetting.OpenEHRTerminology_CodeSystemVersion"/>
        /// </summary>
        public string OpenEHRTerminology_CodeSystemVersion { get; init; } = string.Empty;

        /// <summary>
        /// <see cref="IOpenEHRTerminologySetting.CharacterSetsTerminology_Id"/>
        /// </summary>
        public string CharacterSetsTerminology_Id { get; init; } = string.Empty;

        /// <summary>
        /// <see cref="IOpenEHRTerminologySetting.DefaultCharacterSet"/>
        /// </summary>
        public string DefaultCharacterSet { get; init; } = string.Empty;

        /// <summary>
        /// <see cref="IOpenEHRTerminologySetting.LanguagesTerminology_Id"/>
        /// </summary>
        public string LanguagesTerminology_Id { get; init; } = string.Empty;
        /// <summary>
        /// <see cref="IOpenEHRTerminologySetting.DataFaLanguage"/>
        /// </summary>
        public string DataFaLanguage { get; init; } = string.Empty;
        /// <summary>
        /// <see cref="IOpenEHRTerminologySetting.DataEnLanguage"/>
        /// </summary>
        public string DataEnLanguage { get; init; } = string.Empty;
    }
}
