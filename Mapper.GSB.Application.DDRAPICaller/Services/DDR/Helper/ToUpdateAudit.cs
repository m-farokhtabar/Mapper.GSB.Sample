using openEHR.Library.Base.FoundationTypes.Terminology;
using openEHR.Library.Sm.Platform.Common;

namespace Mapper.GSB.Application.DDRAPICaller.Services.DDR.Helper;

/// <summary>
/// ایجاد
/// UpdateAudit
/// مبدل کلاس
/// MessageIdentifierVO
/// به کلاس های دیگر
/// </summary>
public static class ToUpdateAudit
{
    /// <summary>
    /// ایجاداطلاعات متا مربوط به عملیات بر روی داده ها
    /// </summary>
    /// <param name="Committer"></param>
    /// <param name="AuditChangeCreationId"></param>
    /// <param name="CommiterId">شناسه پارتی ثبت کننده داده</param>
    /// <param name="Description"></param>
    /// <returns></returns>
    public static UpdateAudit Map(Committer Committer, TerminologyCode AuditChangeCreationId, string CommiterId, string Description) => new(AuditChangeCreationId, Description, ToCommiter.Map(Committer, CommiterId));
}
