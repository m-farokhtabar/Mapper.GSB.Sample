using openEHR.Library.Base.BaseTypes.Identification;
using openEHR.Library.Base.FoundationTypes.Terminology;
using openEHR.Library.Rm.Demographic;
using openEHR.Library.Sm.Platform.Common;

namespace Mapper.GSB.Application.DDRAPICaller.Services.DDR;

/// <summary>
/// ارسال درخواست به ریپو
/// DDR
/// </summary>
public interface IDDRRepository
{
    /// <summary>
    /// دریافت اطلاعات پارتی
    /// </summary>
    /// <param name="VersionUid">شناسه پارتی</param>
    /// <returns></returns>
    Task<Party?> GetParty(string VersionUid);
    /// <summary>
    /// دریافت اطلاعات ارتباطات پارتی
    /// </summary>
    /// <param name="VersionUid"></param>
    /// <returns></returns>
    Task<PartyRelationship?> GetPartyRelationship(string VersionUid);
    /// <summary>
    /// ارسال درخواست ایجاد پارتی
    /// </summary>
    /// <param name="Party">اطلاعات پارتی</param>
    /// <param name="UpdateAudit">اطلاعات متا ثبت</param>
    /// <param name="VersionLifecycleState">وضعیت داده</param>
    /// <returns>شناسه</returns>
    Task<ObjectVersionId> CreateParty(global::openEHR.DDR.Command.Party.Base.Party Party, UpdateAudit UpdateAudit, TerminologyCode VersionLifecycleState);
    /// <summary>
    /// ارسال درخواست ویرایش پارتی
    /// </summary>
    /// <param name="Party">اطلاعات پارتی</param>
    /// <param name="PrecedingVersionUid">شناسه آخرین نسخه پارتی</param>
    /// <param name="UpdateAudit">اطلاعات متا ثبت</param>
    /// <param name="VersionLifecycleState">وضعیت داده</param>
    /// <returns></returns>
    Task<ObjectVersionId> UpdateParty(global::openEHR.DDR.Command.Party.Base.Party Party, ObjectVersionId PrecedingVersionUid, UpdateAudit UpdateAudit, TerminologyCode VersionLifecycleState);
    /// <summary>
    /// ارسال درخواست ایجاد پارتی ریلیشن شیپ
    /// </summary>
    /// <param name="Relationship">اطلاعات پارتی ریلیشن شیپ</param>
    /// <param name="UpdateAudit">اطلاعات متا ثبت</param>
    /// <param name="VersionLifecycleState">وضعیت داده</param>
    /// <returns>شناسه</returns>
    Task<ObjectVersionId> CreatePartyRelationship(PartyRelationship Relationship, UpdateAudit UpdateAudit, TerminologyCode VersionLifecycleState);
    /// <summary>
    /// ارسال درخواست ویرایش پارتی ریلیشن شیپ
    /// </summary>
    /// <param name="Relationship">اطلاعات پارتی ریلیشن شیپ</param>
    /// <param name="PrecedingVersionUid">شناسه آخرین نسخه  پارتی ریلیشن شیپ</param>
    /// <param name="UpdateAudit">اطلاعات متا ثبت</param>
    /// <param name="VersionLifecycleState">وضعیت داده</param>
    /// <returns></returns>
    Task<ObjectVersionId> UpdatePartyRelationship(PartyRelationship Relationship, ObjectVersionId PrecedingVersionUid, UpdateAudit UpdateAudit, TerminologyCode VersionLifecycleState);
}