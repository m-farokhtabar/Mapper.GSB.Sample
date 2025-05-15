using Mapper.GSB.Domain.Insurance;
using openEHR.Library.Base.BaseTypes.Identification;

namespace Mapper.GSB.Application.DDRAPICaller.Services.DDR;

/// <summary>
/// ثبت اطلاعات در سرویس 
/// DDR
/// </summary>
public interface IDDRService
{
    /// <summary>
    /// ایجاد اطلاعات نسخه و اطلاعات تکمیلی سند
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="SourceId"></param>
    /// <param name="PrevopenEHRPartyRelationshipId"></param>
    /// <returns></returns>
    Task<ObjectVersionId> SaveCompositon(PersonInsurance entity, string SourceId, ObjectVersionId? PrevopenEHRPartyRelationshipId);
    /// <summary>
    /// ایجاد بیمار
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="PrevopenEHRPartyId"></param>
    /// <returns></returns>
    Task<ObjectVersionId> SavePatient(PersonInsurance entity, ObjectVersionId? PrevopenEHRPartyId);
}