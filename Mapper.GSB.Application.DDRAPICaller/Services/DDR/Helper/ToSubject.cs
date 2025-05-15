using openEHR.Library.Rm.Common.Generic;
using openEHR.Library.Rm.DataTypes.Basic;

namespace Mapper.GSB.Application.DDRAPICaller.Services.DDR.Helper;

/// <summary>
/// ایجاد شناسه مربوط به بیمار
/// </summary>
public static class ToSubject
{
    /// <summary>
    /// ایجاد شناسه
    /// </summary>
    /// <param name="Person">اطلاعات شخص</param>
    /// <returns></returns>
    public static PartyIdentified Map(SubjectInfo Person)
    {
        //TODO: برای اتباع خارجی تکلیف مشخص نیست
        List<DvIdentifier> Identifiers = new List<DvIdentifier>();
        if (!string.IsNullOrWhiteSpace(Person.PersonId))
            Identifiers.Add(new DvIdentifier("MOHME_IT", "MOHME_IT", Person.PersonId, "PatientUID"));
        if (!string.IsNullOrWhiteSpace(Person.RelationShipId))
            Identifiers.Add(new DvIdentifier("MOHME_IT", "MOHME_IT", Person.RelationShipId, "CompositionUID"));
        Identifiers.Add(new DvIdentifier("National_Org_Civil_Reg", "National_Org_Civil_Reg", Person.Id, "National_Code"));
        return new PartyIdentified(Person.GetFullName(), Identifiers, null);
    }
}
