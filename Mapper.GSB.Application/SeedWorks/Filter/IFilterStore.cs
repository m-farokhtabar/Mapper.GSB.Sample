using Mapper.GSB.Domain.Insurance;

namespace Mapper.GSB.Application.Filter
{
    public interface IFilterStore
    {
        Task Insert(PersonInsuranceCreatedEvent entity);
        Task UpdateGSB(Guid snapshotId, string? GSBRegisterID, DateTime? RegisterDate);
        Task UpdateopenEHRPartyId(Guid snapshotId, string openEHRPartyId);
        Task UpdateopenEHRDocId(Guid snapshotId, string openEHRDocId);
    }
}