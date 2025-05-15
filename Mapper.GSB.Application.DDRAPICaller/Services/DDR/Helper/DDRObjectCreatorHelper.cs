using openEHR.Library.Base.FoundationTypes.Terminology;
using openEHR.Library.Sm.Platform.Common;
using openEHR.Library.Base.BaseTypes.Identification;
using openEHR.Library.Rm.Common.Archetyped;



namespace Mapper.GSB.Application.DDRAPICaller.Services.DDR.Helper;

using global::openEHR.Library.Rm.Demographic;
using Mapper.GSB.Application.DDRAPICaller.Services.DDR.Constants;
using Mapper.GSB.Application.Services.Terminology.openEHR;
using Mapper.GSB.Share.Resource;
using MOHME.Lib.Shared;

/// <summary>
/// متدهای مورد نیاز برای انجام عملیات
/// </summary>
internal static class DDRObjectCreatorHelper
{
    /// <summary>
    /// مشخص کردن نام کامل
    /// </summary>
    /// <param name="Name"></param>
    /// <param name="Family"></param>
    /// <param name="FullName"></param>
    /// <returns></returns>
    public static string? GetFullName(string? Name, string? Family, string? FullName)
    {
        if (!string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Family))
            return Name + " " + Family;
        else
            if (!string.IsNullOrWhiteSpace(FullName))
            return FullName;
        else
            return Name + Family;
    }

    /// <summary>
    /// ایجاد اطلاعات فردی
    /// </summary>
    /// <param name="Committer"></param>
    /// <param name="AuditChange"></param>
    /// <param name="FeederAudit"></param>
    /// <param name="Person"></param>
    /// <returns></returns>
    public static (global::openEHR.DDR.Command.Party.Base.Person NewPerson, UpdateAudit PersonUpdateAudit) CreatePerson(Committer Committer, TerminologyCode AuditChange, FeederAudit FeederAudit, Person Person)
    {
        UpdateAudit PersonUpdateAudit = ToUpdateAudit.Map(Committer, AuditChange, "", Names.DATA_INSURANCE_FORMAT);
        global::openEHR.DDR.Command.Party.Base.Person NewPerson = new(Person.Languages?.ToList(), Person.Identities?.ToList(), Person.Contacts?.ToList(), Person.Details, Person.Name, Person.ArchetypeNodeId, null, Person.ArchetypeDetails, FeederAudit, Person.Links?.ToList(), null);

        return (NewPerson, PersonUpdateAudit);
    }
    /// <summary>
    /// ایجاد اطلاعات نقش
    /// </summary>
    /// <param name="Committer"></param>
    /// <param name="AuditChange"></param>
    /// <param name="FeederAudit"></param>
    /// <param name="Role"></param>
    /// <param name="PartyId"></param>
    /// <returns></returns>
    public static (global::openEHR.DDR.Command.Party.Base.Role NewRole, UpdateAudit PersonUpdateAudit) CreateRole(Committer Committer, TerminologyCode AuditChange, FeederAudit FeederAudit, Role Role, string PartyId)
    {
        UpdateAudit PersonUpdateAudit = ToUpdateAudit.Map(Committer, AuditChange, "", Names.DATA_INSURANCE_FORMAT);
        PartyRef Performer = new(openEHRConstant.PARTY_REF_NAMESPACE, openEHRConstant.PARTY_REF_TYPE_PERSON, new HierObjectId(PartyId));
        global::openEHR.DDR.Command.Party.Base.Role NewRole = new(Performer, null, Role.Capabilities?.ToList(), Role.Identities?.ToList(), Role.Contacts?.ToList(), Role.Details, Role.Name, Role.ArchetypeNodeId, null, Role.ArchetypeDetails, FeederAudit, Role.Links?.ToList(), null);

        return (NewRole, PersonUpdateAudit);
    }
    /// <summary>
    /// ایجاد اطلاعات روکش سند
    /// </summary>
    /// <param name="Committer"></param>
    /// <param name="AuditChange"></param>
    /// <param name="FeederAudit"></param>
    /// <param name="SourceId"></param>
    /// <param name="TargetId"></param>
    /// <param name="Relationship"></param>
    /// <returns></returns>
    public static (PartyRelationship BillData, UpdateAudit RelationshipUpdateAudit) CreatePartyRelationship(Committer Committer, TerminologyCode AuditChange, FeederAudit FeederAudit, string SourceId, string TargetId, PartyRelationship Relationship)
    {
        PartyRef Source = new(openEHRConstant.PARTY_REF_NAMESPACE, openEHRConstant.PARTY_REF_TYPE_PERSON, new HierObjectId(SourceId));
        PartyRef Target = new(openEHRConstant.PARTY_REF_NAMESPACE, openEHRConstant.PARTY_REF_TYPE_ORGANISATION, new HierObjectId(TargetId));
        UpdateAudit RelationshipUpdateAudit = ToUpdateAudit.Map(Committer, AuditChange, "", Names.DATA_INSURANCE_FORMAT);
        PartyRelationship BillData = new(Source, Target, Relationship.TimeValidity, Relationship.Details, Relationship.Name, Relationship.ArchetypeNodeId, null, Relationship.ArchetypeDetails, FeederAudit, Relationship.Links?.ToList(), null, false);

        return (BillData, RelationshipUpdateAudit);
    }
    /// <summary>
    /// دریافت اطلاعات متا 
    /// برای ثبت
    /// Part, PartyRelationship
    /// </summary>
    /// <param name="OpenEHRTerminologyService">سرویس اطلاعات ترمینولوژی</param>
    /// <param name="Audit"></param>
    /// <param name="PersonInfo"></param>
    /// <param name="VersionLifecycleStateCode"></param>
    /// <param name="MapperSystemId"></param>
    /// <param name="MapperOrganiationId"></param>
    /// <param name="MapperOrganizationName"></param>
    /// <returns></returns>
    public static async Task<(TerminologyCode AuditChangeCreationId, TerminologyCode VersionLifecycleStateCompleteId, FeederAudit FeederAudit)> GetMetaDataCreate(IOpenEHRTerminologyService OpenEHRTerminologyService, DataAuditDetails Audit, SubjectInfo PersonInfo, string? VersionLifecycleStateCode, string MapperSystemId, string MapperOrganiationId, string MapperOrganizationName)
    {
        TerminologyCode AuditChangeCreationId = ToTerminologyCode.Map(await OpenEHRTerminologyService.GetAuditChangeCreationId().ConfigureAwait(false));
        TerminologyCode VersionLifecycleState = await GetVersionLifecycleState(OpenEHRTerminologyService, VersionLifecycleStateCode).ConfigureAwait(false);
        //TODO: شناسه فرد کامیت کننده در ریپو دموگرافی
        FeederAudit FeederAudit = ToFeederAudit.Map(Audit, PersonInfo, "", MapperSystemId, MapperOrganiationId, MapperOrganizationName);

        return (AuditChangeCreationId, VersionLifecycleState, FeederAudit);
    }
    /// <summary>
    /// دریافت اطلاعات متا 
    /// برای ویرایش
    /// Part, PartyRelationship
    /// </summary>
    /// <param name="OpenEHRTerminologyService">سرویس اطلاعات ترمینولوژی</param>
    /// <param name="Audit"></param>
    /// <param name="PersonInfo"></param>
    /// <param name="VersionLifecycleStateCode"></param>
    /// <param name="MapperSystemId"></param>
    /// <param name="MapperOrganiationId"></param>
    /// <param name="MapperOrganizationName"></param>
    /// <returns></returns>
    public static async Task<(TerminologyCode AuditChangeCreationId, TerminologyCode VersionLifecycleStateCompleteId, FeederAudit FeederAudit)> GetMetaDataUpdate(IOpenEHRTerminologyService OpenEHRTerminologyService, DataAuditDetails Audit, SubjectInfo PersonInfo, string? VersionLifecycleStateCode, string MapperSystemId, string MapperOrganiationId, string MapperOrganizationName)
    {
        //TODO: اعمال شود MsgID.VersionLifecycleState
        TerminologyCode AuditChangeCreationId = ToTerminologyCode.Map(await OpenEHRTerminologyService.GetAuditChangeModificationId().ConfigureAwait(false));
        TerminologyCode VersionLifecycleState = await GetVersionLifecycleState(OpenEHRTerminologyService, VersionLifecycleStateCode).ConfigureAwait(false);
        //TODO: شناسه فرد کامیتر در ریپو دموگرافی
        FeederAudit FeederAudit = ToFeederAudit.Map(Audit, PersonInfo, string.Empty, MapperSystemId, MapperOrganiationId, MapperOrganizationName);

        return (AuditChangeCreationId, VersionLifecycleState, FeederAudit);
    }
    /// <summary>
    /// دریافت وضعیت پرونده بر اساس داده های ورودی
    /// </summary>
    /// <param name="OpenEHRTerminologyService"></param>
    /// <param name="VersionLifecycleStateCode"></param>
    /// <returns></returns>
    private static async Task<TerminologyCode> GetVersionLifecycleState(IOpenEHRTerminologyService OpenEHRTerminologyService, string? VersionLifecycleStateCode)
    {
        //incomplete    
        if (VersionLifecycleStateCode == "1.1.1.2")
            return ToTerminologyCode.Map(await OpenEHRTerminologyService.GetVersionLifecycleStateInCompleteId().ConfigureAwait(false));
        //complete
        else if (VersionLifecycleStateCode == "1.1.1.1")
            return ToTerminologyCode.Map(await OpenEHRTerminologyService.GetVersionLifecycleStateCompleteId().ConfigureAwait(false));
        else
            //در صورتی که وضعیت داده مشخص نشده باشد آن را به عنوان داده کامل ذخیره می کنیم
            return ToTerminologyCode.Map(await OpenEHRTerminologyService.GetVersionLifecycleStateCompleteId().ConfigureAwait(false));
    }
}
/// <summary>
/// اطلاعات و مشخصات مربوط به بیمار و روکش جهت ثبت در قسمت متا
/// </summary>
public class SubjectInfo
{
    /// <summary>
    /// ایجاد اطلاعات متا
    /// </summary>
    /// <param name="id"></param>
    /// <param name="personMohmehId"></param>
    /// <param name="relationShipId"></param>
    /// <param name="fullName"></param>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    public SubjectInfo(string? id, string? personMohmehId, string? relationShipId, string? firstName, string? lastName, string? fullName)
    {
        Id = string.IsNullOrWhiteSpace(id) ? "123" : id;
        FirstName = firstName is null ? "" : firstName;
        LastName = lastName is null ? "" : lastName;
        FullName = fullName is null ? "" : fullName;
        PersonId = personMohmehId;
        RelationShipId = relationShipId;
    }

    /// <summary>
    /// کد ملی
    /// </summary>
    public string Id { get; set; }
    /// <summary>
    /// شناسه ایجاد شده برای کاربر
    /// </summary>
    public string? PersonId { get; set; }
    /// <summary>
    /// شناسه ایجاد شده برای روکش سند کاربر
    /// </summary>
    public string? RelationShipId { get; set; }
    /// <summary>
    /// نام
    /// </summary>
    public string FirstName { get; set; }
    /// <summary>
    /// نام خانوادگی
    /// </summary>
    public string LastName { get; set; }
    /// <summary>
    /// نام و نام خانوادگی
    /// </summary>
    public string FullName { get; set; }
    /// <summary>
    /// دریافت نام کامل
    /// </summary>
    /// <returns></returns>
    public string GetFullName()
    {
        if (string.IsNullOrWhiteSpace(FullName))
            return FirstName + " " + LastName;
        else
        {
            if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName))
                return FullName;
            else
                return FirstName + " " + LastName;
        }
    }
}
/// <summary>
/// اطلاعات مربوط به درخواست ارسالی
/// </summary>
public class DataAuditDetails
{

    /// <summary>
    /// ایجاد اطلاعات مورد نیاز پرونده
    /// </summary>
    /// <param name="systemId"></param>
    /// <param name="organizationId"></param>
    /// <param name="organizationName"></param>
    /// <param name="versionLifecycleState"></param>
    /// <param name="committer"></param>
    /// <param name="creationDate"></param>
    public DataAuditDetails(DO_IDENTIFIER systemId, DO_IDENTIFIER organizationId, string organizationName, DO_CODED_TEXT? versionLifecycleState, Committer committer, DO_DATE? creationDate)
    {
        SystemId = systemId;
        OrganizationId = organizationId;
        OrganizationName = organizationName;
        VersionLifecycleState = versionLifecycleState;
        Committer = committer;
        CreationDate = creationDate;
    }

    /// <summary>
    /// شماره شناسه یکتا سیستمی که اطلاعات را ثبت کرده است
    /// </summary>
    /// <remarks></remarks>
    public DO_IDENTIFIER SystemId { get; private set; }
    /// <summary>
    /// شناسه یکتا سازمانی که اطلاعات در آن ثبت شده است
    /// </summary>
    public DO_IDENTIFIER OrganizationId { get; private set; }
    /// <summary>
    /// نام سازمانی که اطلاعات در آن ثبت شده است
    /// </summary>
    public string OrganizationName { get; private set; }
    /// <summary>
    /// وضعیت پرونده ارسالی
    /// <list type="">
    /// <item>incomplete</item>
    /// <item>complete</item>
    /// </list>        
    /// </summary>
    public DO_CODED_TEXT? VersionLifecycleState { get; private set; }
    /// <summary>
    /// اطلاعات کاربر درخواست کننده عملیات
    /// </summary>
    public Committer Committer { get; private set; }
    /// <summary>
    /// تاریخ ایجاد یا ثبت اطلاعات در سیستم بیمه
    /// </summary>
    public DO_DATE? CreationDate { get; private set; }
}
/// <summary>
/// اطلاعات کاربر ثبت کننده درخواست
/// </summary>
public class Committer
{
    /// <summary>
    /// ایجاد اطلاعات کاربر ثبت کننده درخواست
    /// </summary>
    /// <param name="identifier"></param>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    /// <param name="fullName"></param>
    public Committer(DO_IDENTIFIER? identifier, string? firstName, string? lastName, string? fullName)
    {
        Identifier = identifier;
        FirstName = firstName is null ? "" : firstName;
        LastName = lastName is null ? "" : lastName;
        FullName = fullName is null ? "" : fullName;
    }
    /// <summary>
    /// شناسه ملی کاربر
    /// </summary>
    public DO_IDENTIFIER? Identifier { get; set; }
    /// <summary>
    /// نام
    /// </summary>
    public string FirstName { get; set; }
    /// <summary>
    /// نام خانوادگی
    /// </summary>
    public string LastName { get; set; }
    /// <summary>
    /// نام کامل
    /// </summary>
    public string FullName { get; set; }
    /// <summary>
    /// دریافت نام کامل
    /// </summary>
    /// <returns></returns>
    public string GetFullName()
    {
        if (string.IsNullOrWhiteSpace(FullName))
            return FirstName + " " + LastName;
        else
        {
            if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName))
                return FullName;
            else
                return FirstName + " " + LastName;
        }
    }
}
/// <summary>
/// متدهای اضافی مورد نیاز نوع
/// DO_DATE
/// </summary>
public static class DO_DATEExtension
{
    /// <summary>
    /// تبدیل به فرمت 
    /// openEHR
    /// </summary>
    /// <returns></returns>
    public static string ToopenEHRFormatDate(this DO_DATE Date)
    {
        if (Date.Year.HasValue)
        {
            if (!Date.Month.HasValue)
                return Date.Year.Value.ToString("0000");
            else
            {
                if (!Date.Day.HasValue)
                    return Date.Year.Value.ToString("0000") + "-" + Date.Month.Value.ToString("00");
                else
                    return Date.Year.Value.ToString("0000") + "-" + Date.Month.Value.ToString("00") + "-" + Date.Day.Value.ToString("00");

            }
        }
        else
            return "";
    }
}
