using Mapper.GSB.Domain.InsuranceDataCoordinator;
using Mapper.GSB.Share.Helper;

namespace Mapper.GSB.Application.Insurance.Queries.Status
{
    /// <summary>
    /// مبدل وضعیت درخواست
    /// </summary>
    internal static class StatusMapper
    {
        /// <summary>
        /// مبل مدل به داده های مورد نیاز وضعیت درخواست
        /// </summary>
        /// <param name="cordinators"></param>
        /// <returns></returns>
        public static List<PersonInsuranceStatusDetailsDto> MapToStatusDetails(List<PersonInsuranceDataCoordinator> cordinators)
        {
            return cordinators.Select(x => new PersonInsuranceStatusDetailsDto
            {
                RegisterUID = x.RegisterUID,
                CompositionUID = x.CompositionUID,
                PatientUID = x.PatientUID,
                DomainModel = x.DomainModelName,
                GSBIgin = x.GSBIgin,
                GSBRegisterID = x.GSBRegisterID,
                GSBResult = x.GSBResult,
                LocalId = x.LocalId,
                MessageUID = x.MessageUID,
                Shebad = x.Shebad,
                RegisterDateTime = x.RegisterDateTime,
                RecordVersion = x.Version,
                Operation = x.Operation,
                PersonIdentifier = x.PersonId,
                PolicyUniqueCode = x.PolicyUniqueCode,                
                Errors = x.Status == InsuranceDataStatus.Done ? null : x.Error,
                Status = MapToStatus(x.Status),
                StatusMessage = MapToStatus(x.Status).GetDisplayName()
            }).ToList();
        }
        /// <summary>
        /// مبدل وضعیت درخواست در مدل به وضعیت درخواست برای خروجی
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static StatusType MapToStatus(InsuranceDataStatus status)
        {
            return status switch
            {
                InsuranceDataStatus.Recieved => StatusType.InProcessing,
                InsuranceDataStatus.SentToGSBServiceIsUnSucceessful => StatusType.GSBFail,
                InsuranceDataStatus.SentToGSBServiceIsSucceessful => StatusType.InProcessing,
                InsuranceDataStatus.SavePersonInopenEHRRepositoryIsUnSucceessful => StatusType.DDRFail,
                InsuranceDataStatus.SavePersonInopenEHRRepositoryIsSucceessful => StatusType.InProcessing,
                InsuranceDataStatus.SaveInsurnaceDataInopenEHRRepositoryIsUnSucceessful => StatusType.DDRFail,
                InsuranceDataStatus.Done => StatusType.Success,
                _ => StatusType.InProcessing
            };
        }
    }
}
