using Mapper.GSB.Application.Insurance.Queries.LastPersonInsuranceInfo;
using Mapper.GSB.Application.Insurance.Queries.Status;
using Mapper.GSB.Share.Resource;
using MOHME.Lib.Shared;
using Swashbuckle.AspNetCore.Filters;

namespace Mapper.GSB.Rest.API.Helpers.SwaggerExamples
{
    /// <summary>
    /// نمونه خروجی خلاصه اطلاعات بیمه
    /// </summary>
    public class PersonInsuranceInfoDtoListExample : IExamplesProvider<List<PersonInsuranceInfoDto>>
    {
        /// <summary>
        /// ایجاد نمونه خروجی خلاصه اطلاعات بیمه
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<PersonInsuranceInfoDto> GetExamples()
        {
            return new List<PersonInsuranceInfoDto>()
            {
            new PersonInsuranceInfoDto()
            {
                AccountID = "2900",
                InsuranceExpirationDate = new DO_DATE()
                {
                    Day = 1,
                    Month = 10,
                    Year = 1402
                },
                Insurer = new DO_CODED_TEXT()
                {
                    Value = "بیمه آسیا",
                    Coded_string = "10",
                    Terminology_id = "thritaEHR.insurer"
                },
                PolicyType = new DO_CODED_TEXT()
                {
                    Value = "SendPersonSupplimantryInfo",
                    Coded_string = "1",
                    Terminology_id = "hltHub.policyType"
                },
                RegisterUID = Guid.NewGuid().ToString(),
                PolicyUniqueCode = "30000000026",
                CompanyInsuredId = "12",
                CompanyPolicyId = "100",
                Status = StatusType.Success,
                StatusMessage = Messages.The_operation_has_done_sucessfully,
            },
            new PersonInsuranceInfoDto()
            {
                AccountID = "2900",
                InsuranceExpirationDate = new DO_DATE()
                {
                    Day = 1,
                    Month = 10,
                    Year = 1402
                },
                Insurer = new DO_CODED_TEXT()
                {
                    Value = "بیمه آسیا",
                    Coded_string = "10",
                    Terminology_id = "thritaEHR.insurer"
                },
                PolicyType = new DO_CODED_TEXT()
                {
                    Value = "SendPersonInfo",
                    Coded_string = "2",
                    Terminology_id = "hltHub.policyType"
                },
                RegisterUID = Guid.NewGuid().ToString(),
                PolicyUniqueCode = "30000000027",
                CompanyInsuredId = "13",
                CompanyPolicyId = "300",
                Status = StatusType.GSBFail,
                StatusMessage = Messages.An_error_occurred_while_performing_the_operation_during_the_data_transmission_to_the_GSB_server                
            }
            };
        }
    }
}
