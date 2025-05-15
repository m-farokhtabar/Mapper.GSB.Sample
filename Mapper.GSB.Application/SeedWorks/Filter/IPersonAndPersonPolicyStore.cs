using Mapper.GSB.Domain.Insurance;

namespace Mapper.GSB.Application.FilterStore
{
    public interface IPersonAndPersonPolicyStore
    {
        Task InsertPersonInfo(PersonInsuranceCreatedEvent entity);
        Task InsertPersonPolicy(PersonInsuranceCreatedEvent entity);
        Task UpdateGSBPersonInfo(Guid snapshotId, DateTime? RegisterDate);
        Task UpdateopenEHRPartyIdPersonInfo(Guid snapshotId, string openEHRPartyId);
        Task UpdateopenEHRDocIdPersonInfo(Guid snapshotId, string openEHRDocId);
        Task UpdateGSBPersonPolicyFields(Guid snapshotId, string? GSBIgin, string? GSBRegisterID, DateTime? RegisterDate, string? errorMessage);
    }
}