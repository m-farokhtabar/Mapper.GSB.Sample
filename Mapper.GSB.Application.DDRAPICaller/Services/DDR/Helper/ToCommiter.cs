using Mapper.GSB.Application.DDRAPICaller.Services.DDR.Constants;
using openEHR.Library.Base.BaseTypes.Identification;
using openEHR.Library.Rm.Common.Generic;
using openEHR.Library.Rm.DataTypes.Basic;

namespace Mapper.GSB.Application.DDRAPICaller.Services.DDR.Helper;
/// <summary>
/// مبدل اطلاعات ثبت کننده داده ها
/// </summary>
public static class ToCommiter
{
    /// <summary>
    /// ایجاد شی 
    /// PartyIdentified
    /// برای فردی که اطلاعات سیستم را جهت ثبت ارسال کرد است
    /// </summary>
    /// <param name="Committer"></param>
    /// <param name="CommiterPartyId">شناسه فرد کامیتر که در ریپو دموگرافی قبلا ثبت شده است</param>
    /// <returns></returns>
    public static PartyIdentified Map(Committer Committer, string CommiterPartyId)
    {
        List<DvIdentifier>? Identifiers = null;
        if (Committer.Identifier is not null)
            Identifiers = new() { new DvIdentifier(Committer.Identifier.Issuer, Committer.Identifier.Assigner, Committer.Identifier.ID, Committer.Identifier.Type) };
        return new PartyIdentified(Committer.GetFullName(), Identifiers, CreatePartyRefOfCommiter(CommiterPartyId));
    }
    /// <summary>
    /// شناسه مربوط به ارسال کننده درخواست ثبت یا ویرایش در ریپو دموگرافی
    /// </summary>
    /// <param name="PersonId">شناسه شخص ثبت کننده</param>
    /// <returns></returns>
    public static PartyRef? CreatePartyRefOfCommiter(string PersonId)
    {
        if (string.IsNullOrWhiteSpace(PersonId))
            return null;
        else
            return new PartyRef(openEHRConstant.PARTY_REF_NAMESPACE, openEHRConstant.PARTY_REF_TYPE_PERSON, new HierObjectId(PersonId));
    }
}
