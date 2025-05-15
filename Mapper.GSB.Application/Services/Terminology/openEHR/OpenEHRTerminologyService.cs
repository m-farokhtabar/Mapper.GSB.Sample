using Mapper.GSB.Application.SeedWork.Cache;
using Mapper.GSB.Application.Services.Terminology.openEHR.CacheKey;
using Mapper.GSB.Share.Resource;
using openEHR.Library.Base.BaseTypes.Identification;
using openEHR.Library.Rm.DataTypes.Text;
using Services.ExceptionManager;
using Services.ExceptionManager.Resources;
using System.Data;

namespace Mapper.GSB.Application.Services.Terminology.openEHR;

/// <summary>
/// <see cref="IOpenEHRTerminologyService"/>
/// </summary>
public class OpenEHRTerminologyService : IOpenEHRTerminologyService
{
    private readonly ITerminologyProvider Provider;
    private readonly ICacheStore CacheStore;
    private readonly IOpenEHRTerminologySetting settings;
    /// <summary>
    /// دریافت سرویس های مورد نیاز
    /// </summary>
    /// <param name="Provider"></param>
    /// <param name="CacheStore"></param>
    /// <param name="openEHRTerminologySetting"></param>
    public OpenEHRTerminologyService(ITerminologyProvider Provider, ICacheStore CacheStore, IOpenEHRTerminologySetting openEHRTerminologySetting)
    {
        this.Provider = Provider;
        this.CacheStore = CacheStore;
        this.settings = openEHRTerminologySetting;
    }
    /// <summary>
    /// <see cref="IOpenEHRTerminologyService.GetVersionLifecycleState"/>
    /// </summary>
    /// <returns></returns>
    public async Task<List<DvCodedText>> GetVersionLifecycleState()
    {
        VersionLifecycleStateCacheKey Key = new("");
        List<DvCodedText>? Result = CacheStore.Get(Key);
        if (Result is null)
        {
            string CodeSystemUrl = settings.OpenEHRTerminology_CodeSystemUrl;
            string CodeSystemVersion = settings.OpenEHRTerminology_CodeSystemVersion;
            List<TerminologyDto>? VersionLifecycleStates = (await Provider.Get(CodeSystemUrl, CodeSystemVersion).ConfigureAwait(false))?
                                                                         .Where(x => x.Valueset_URL == settings.OpenEHRTerminology_ValueSet_VersionLifecycleState_Url &&
                                                                         x.Valueset_Version == settings.OpenEHRTerminology_ValueSet_VersionLifecycleState_Version).ToList();
            if (VersionLifecycleStates?.Count > 0)
            {
                Result = new List<DvCodedText>();
                foreach (var VersionLifecycle in VersionLifecycleStates)
                {
                    if (VersionLifecycle.CodeDetails?.Count > 0)
                    {
                        foreach (var CodeDetails in VersionLifecycle.CodeDetails)
                        {
                            if (CodeDetails.Language == settings.OpenEHRTerminology_ValueSet_VersionLifecycleState_DefaultLanguage)
                            {
                                CodePhrase Lang = new(new TerminologyId(settings.LanguagesTerminology_Id), CodeDetails.Language, null);
                                CodePhrase Encoding = new(new TerminologyId(settings.CharacterSetsTerminology_Id), settings.OpenEHRTerminology_ValueSet_VersionLifecycleState_DefaultCharacterSet, null);
                                CodePhrase CreationCode = new(new TerminologyId(settings.OpenEHRTerminology_Id), VersionLifecycle.ConceptDefinition_Code, null);
                                Result.Add(new DvCodedText(CreationCode, CodeDetails.Display, null, null, null, Lang, Encoding));
                                break;
                            }
                        }
                    }
                }
            }
            if (Result?.Count > 0)
                CacheStore.Add(Result, Key);
            else
                throw new ManualException(ExceptionsMessages.Data_is_not_found.Replace("{0}", Names.LIFECYCLE_STATE), ExceptionType.NotFound, nameof(Names.LIFECYCLE_STATE));
        }
        return Result;
    }
    /// <summary>
    /// <see cref="IOpenEHRTerminologyService.GetAuditChangeType"/>
    /// </summary>
    /// <returns></returns>
    public async Task<List<DvCodedText>> GetAuditChangeType()
    {
        AuditChangeTypeCacheKey Key = new("");
        List<DvCodedText>? Result = CacheStore.Get(Key);
        if (Result is null)
        {
            string CodeSystemUrl = settings.OpenEHRTerminology_CodeSystemUrl;
            string CodeSystemVersion = settings.OpenEHRTerminology_CodeSystemVersion;
            List<TerminologyDto>? AuditChangeTypes = (await Provider.Get(CodeSystemUrl, CodeSystemVersion).ConfigureAwait(false))?.Where(x => x.Valueset_URL == settings.OpenEHRTerminology_ValueSet_AuditChangeType_Url &&
                                                                                                                      x.Valueset_Version == settings.OpenEHRTerminology_ValueSet_AuditChangeType_Version).ToList();
            if (AuditChangeTypes?.Count > 0)
            {
                Result = new List<DvCodedText>();
                foreach (var AuditChangeType in AuditChangeTypes)
                {
                    if (AuditChangeType.CodeDetails?.Count > 0)
                    {
                        foreach (var CodeDetails in AuditChangeType.CodeDetails)
                        {
                            if (CodeDetails.Language == settings.OpenEHRTerminology_ValueSet_VersionLifecycleState_DefaultLanguage)
                            {
                                CodePhrase Lang = new(new TerminologyId(settings.LanguagesTerminology_Id), CodeDetails.Language, null);
                                CodePhrase Encoding = new(new TerminologyId(settings.CharacterSetsTerminology_Id), settings.OpenEHRTerminology_ValueSet_VersionLifecycleState_DefaultCharacterSet, null);
                                CodePhrase CreationCode = new(new TerminologyId(settings.OpenEHRTerminology_Id), AuditChangeType.ConceptDefinition_Code, null);
                                Result.Add(new DvCodedText(CreationCode, CodeDetails.Display, null, null, null, Lang, Encoding));
                                break;
                            }
                        }
                    }
                }
            }
            if (Result?.Count > 0)
                CacheStore.Add(Result, Key);
            else
                throw new ManualException(ExceptionsMessages.Data_is_not_found.Replace("{0}", Names.AUDIT_CHANGE), ExceptionType.NotFound, nameof(Names.AUDIT_CHANGE));
        }
        return Result;
    }
    /// <summary>
    /// <see cref="IOpenEHRTerminologyService.GetAuditChangeCreationId"/>
    /// </summary>
    /// <returns></returns>
    public async Task<DvCodedText> GetAuditChangeCreationId()
    {
        var AuditChangeTypes = await GetAuditChangeType().ConfigureAwait(false);
        var Result = AuditChangeTypes?.Find(x => x.DefiningCode.CodeString == settings.OpenEHRTerminology_ValueSet_AuditChangeType_CreationId);
        if (Result is null)
            throw new ManualException(ExceptionsMessages.Data_is_not_found.Replace("{0}", Names.AUDIT_CHANGE), ExceptionType.NotFound, nameof(Names.AUDIT_CHANGE));
        return Result;
    }
    /// <summary>
    /// <see cref="IOpenEHRTerminologyService.GetAuditChangeModificationId"/>
    /// </summary>
    /// <returns></returns>
    public async Task<DvCodedText> GetAuditChangeModificationId()
    {
        var AuditChangeTypes = await GetAuditChangeType().ConfigureAwait(false);
        var Result = AuditChangeTypes?.Find(x => x.DefiningCode.CodeString == settings.OpenEHRTerminology_ValueSet_AuditChangeType_Modification);
        if (Result is null)
            throw new ManualException(ExceptionsMessages.Data_is_not_found.Replace("{0}", Names.AUDIT_CHANGE), ExceptionType.NotFound, nameof(Names.AUDIT_CHANGE));
        return Result;
    }
    /// <summary>
    /// <see cref="IOpenEHRTerminologyService.GetVersionLifecycleStateCompleteId"/>
    /// </summary>
    /// <returns></returns>
    public async Task<DvCodedText> GetVersionLifecycleStateCompleteId()
    {
        var VersionLifecycleStats = await GetVersionLifecycleState().ConfigureAwait(false);
        var Result = VersionLifecycleStats?.Find(x => x.DefiningCode.CodeString == settings.OpenEHRTerminology_ValueSet_VersionLifecycleState_CompleteId);
        if (Result is null)
            throw new ManualException(ExceptionsMessages.Data_is_not_found.Replace("{0}", Names.LIFECYCLE_STATE), ExceptionType.NotFound, nameof(Names.LIFECYCLE_STATE));
        return Result;
    }
    /// <summary>
    /// <see cref="IOpenEHRTerminologyService.GetVersionLifecycleStateInCompleteId"/>
    /// </summary>
    /// <returns></returns>
    public async Task<DvCodedText> GetVersionLifecycleStateInCompleteId()
    {
        var VersionLifecycleStats = await GetVersionLifecycleState().ConfigureAwait(false);
        var Result = VersionLifecycleStats?.Find(x => x.DefiningCode.CodeString == settings.OpenEHRTerminology_ValueSet_VersionLifecycleState_IncompleteId);
        if (Result is null)
            throw new ManualException(ExceptionsMessages.Data_is_not_found.Replace("{0}", Names.LIFECYCLE_STATE), ExceptionType.NotFound, nameof(Names.LIFECYCLE_STATE));
        return Result;
    }
}
