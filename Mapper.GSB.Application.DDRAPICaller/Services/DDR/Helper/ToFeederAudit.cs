using Mapper.GSB.Application.DDRAPICaller.Services.DDR.Constants;
using openEHR.Library.Base.BaseTypes.Identification;
using openEHR.Library.Rm.Common.Archetyped;
using openEHR.Library.Rm.Common.Generic;
using openEHR.Library.Rm.DataTypes.Basic;
using openEHR.Library.Rm.DataTypes.Encapsulated;
using openEHR.Library.Rm.DataTypes.Quantity.DateTime;


namespace Mapper.GSB.Application.DDRAPICaller.Services.DDR.Helper;

/// <summary>
/// ایجاد کلاس
/// Feeder
/// از طریق اطلاعات سپاس
/// </summary>
public static class ToFeederAudit
{
    /// <summary>
    /// ایجاد اطلاعات مربوط به ایچاد کننده و ارسال کنند داده ها
    /// </summary>
    /// <param name="Audit"></param>
    /// <param name="Person"></param>
    /// <param name="CommiterPartyId">شناسه فرد کامیتر که در ریپو دموگرافی قبلا ثبت شده است</param>
    /// <param name="MapperSystemId"></param>
    /// <param name="MapperOrganizationName"></param>
    /// <param name="MapperOrganiationId"></param>
    /// <returns></returns>
    public static FeederAudit Map(DataAuditDetails Audit, SubjectInfo Person, string CommiterPartyId, string MapperSystemId, string MapperOrganiationId, string MapperOrganizationName)
    {
        //TODO: شناسه اطلاعات در سیستم مرجع
        List<DvIdentifier>? OriginatingSystemItemIds = null;
        //TODO: شناسه اطلاعات در سیستم میانجی
        List<DvIdentifier>? FeederSystemItemIds = null;
        //TODO: داده های اصلی یا آدرس آن که از روی آن داده های ارسالی ساخته شده است
        DvMultimedia? OriginalContent = null;

        return new FeederAudit(OriginatingSystemItemIds, FeederSystemItemIds, OriginalContent, CreateOriginatingSystemAudit(Audit, Person, CommiterPartyId), CreateFeederSystemAudit(Audit, Person, MapperSystemId, MapperOrganiationId, MapperOrganizationName));
    }
    /// <summary>
    /// اطلاعات مربوط به سیستم تولید کننده داده
    /// </summary>
    /// <param name="Audit"></param>
    /// <param name="Person"></param>
    /// <param name="CommiterPartyId">شناسه فرد کامیتر که در ریپو دموگرافی قبلا ثبت شده است</param>
    /// <returns></returns>
    private static FeederAuditDetails CreateOriginatingSystemAudit(DataAuditDetails Audit, SubjectInfo Person, string CommiterPartyId)
    {
        //محل سسیتم اصلی مثلا نام شرکت بیمه
        PartyIdentified Location = new(Audit.OrganizationName, null, new PartyRef(openEHRConstant.PARTY_REF_NAMESPACE, openEHRConstant.PARTY_REF_TYPE_ORGANISATION, new HierObjectId(Audit.OrganizationId.ID)));
        //خود بیمه شده شخصی که مرتبط است با بیمه شده مورد نظر => کد ملی شماره پاسپورت شماره اتباع خارجی
        PartyProxy Subject = ToSubject.Map(Person);
        PartyIdentified Provider = ToCommiter.Map(Audit.Committer, CommiterPartyId);
        DvDateTime? Time = null;
        if (Audit.CreationDate is not null)
            Time = new DvDateTime(Audit.CreationDate.ToopenEHRFormatDate() + "T12:00");
        //TODO: در صورت وجود نسخه ارسال شود
        const string VersionId = "final";
        return new FeederAuditDetails(Audit.SystemId.ID, Location, Subject, Provider, Time, VersionId, null);
    }
    /// <summary>
    /// اطلاعات مربوط به سیستم مپر
    /// همین سیستم خواهد بود
    /// </summary>
    /// <param name="Audit"></param>
    /// <param name="Person"></param>
    /// <param name="MapperSystemId"></param>
    /// <param name="MapperOrganizationId"></param>
    /// <param name="MapperOrganizationName"></param>
    /// <returns></returns>
    private static FeederAuditDetails CreateFeederSystemAudit(DataAuditDetails Audit, SubjectInfo Person, string MapperSystemId, string MapperOrganizationId, string MapperOrganizationName)
    {
        //TODO:اطلاعات محل سیستم مپر که کجا قرار دارد
        PartyIdentified Location = new(MapperOrganizationName, null, new PartyRef(openEHRConstant.PARTY_REF_NAMESPACE, openEHRConstant.PARTY_REF_TYPE_ORGANISATION, new HierObjectId(MapperOrganizationId)));
        //خود بیمه شده شخصی که مرتبط است با بیمه شده مورد نظر => کد ملی شماره پاسپورت شماره اتباع خارجی
        PartyProxy Subject = ToSubject.Map(Person);
        //چون به صورت سیستمی توسط مپر ارسال می شود نیازی به این فیلد نمی باشد
        PartyIdentified? Provider = null;
        DvDateTime Time = new();
        const string VersionId = "final";
        return new FeederAuditDetails(MapperSystemId, Location, Subject, Provider, Time, VersionId, null);
    }
}
