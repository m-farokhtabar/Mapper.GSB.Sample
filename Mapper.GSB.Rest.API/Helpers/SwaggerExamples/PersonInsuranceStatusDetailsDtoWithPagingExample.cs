using Mapper.GSB.Application.Insurance.Queries;
using Mapper.GSB.Application.Insurance.Queries.Status;
using Mapper.GSB.Share.Resource;
using MOHME.Lib.Shared;
using Services.ExceptionManager.Resources;
using Swashbuckle.AspNetCore.Filters;

namespace Mapper.GSB.Rest.API.Helpers.SwaggerExamples
{
    /// <summary>
    /// نمونه خروجی وضعیت های درخواست ثبت یا ویرایش بیمه نامه و بیمه شونده به همراه صفحه بندی
    /// </summary>
    public class PersonInsuranceStatusDetailsDtoWithPagingExample : IExamplesProvider<PagingDto<List<PersonInsuranceStatusDetailsDto>>>
    {
        /// <summary>
        /// ایجاد نمونه خروجی وضعیت های درخواست ثبت یا ویرایش بیمه نامه و بیمه شونده به همراه صفحه بندی
        /// </summary>
        /// <returns></returns>
        public PagingDto<List<PersonInsuranceStatusDetailsDto>> GetExamples()
        {
            var results = new List<PersonInsuranceStatusDetailsDto>
                {
                new PersonInsuranceStatusDetailsDto() {
                    RegisterUID = Guid.NewGuid(),
                    CompositionUID ="Node11.behdasht.gov.ir::00401e77-8b38-4157-b1a7-4540d995d3b2",
                    PatientUID = "Node11.behdasht.gov.ir::1ee992cd-7f5d-4deb-a638-08b8e26cf176",
                    DomainModel = "HltHub.SendPersonPolicyInfo",
                    GSBIgin = "2722575485",
                    GSBRegisterID = "2722575485",
                    GSBResult = "{\r\n\t\"result\": {\r\n\t\t\"data\": [\r\n\t\t\t{\r\n\t\t\t\t\"isError\": false,\r\n\t\t\t\t\"messageUID\": \"424bd2f3-45f8-4119-b6fb-b01d01124633\",\r\n\t\t\t\t\"registerDateTime\": {\r\n\t\t\t\t\t\"year\": 1402,\r\n\t\t\t\t\t\"month\": 7,\r\n\t\t\t\t\t\"day\": 23,\r\n\t\t\t\t\t\"hour\": 17,\r\n\t\t\t\t\t\"minute\": 31,\r\n\t\t\t\t\t\"second\": 37,\r\n\t\t\t\t\t\"isoString\": \"1402/07/23 17:31:37\"\r\n\t\t\t\t},\r\n\t\t\t\t\"personIdentifier\": \"4433227196\",\r\n\t\t\t\t\"policyUnqiueCode\": \"30000000027\",\r\n\t\t\t\t\"domainModel\": \"hltHub.SendPersonPolicyInfo\",\r\n\t\t\t\t\"compositionUID\": \"\",\r\n\t\t\t\t\"patientUID\": \"\",\r\n\t\t\t\t\"shebad\": \"\",\r\n\t\t\t\t\r\n\t\t\t\t\"recordVersion\": 1,\r\n\t\t\t\t\"operation\": 1,\r\n\t\t\t\t\"errorCode\": 0,\r\n\t\t\t\t\"errorMessage\": \"\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"statusCode\": 200,\r\n\t\t\"Message\": \"عملیات با موفقیت انجام شد\",\r\n\t\t\"isError\": false\r\n\t},\r\n\t\"status\": {\r\n\t\t\"statusCode\": 200,\r\n\t\t\"message\": \"OK\"\r\n\t}\r\n}",
                    LocalId = "6F439694-B595-4723-8AB2-7550183084C5",
                    MessageUID = Guid.NewGuid(),
                    Operation = Mapper.GSB.Domain.InsuranceDataCoordinator.Operation.Insert,
                    Shebad = new DO_IDENTIFIER() { ID = "123456789", Type="HID", Assigner = "TAMIN", Issuer = "TAMIN"},
                    Status = StatusType.Success,
                    Errors = null,
                    RecordVersion = 1,
                    StatusMessage = Messages.The_operation_has_done_sucessfully,
                    PersonIdentifier = "2722575485",
                    PolicyUniqueCode = "30000000027",
                    RegisterDateTime = new DO_DATE_TIME()
                    {
                        Year = 1401,
                        Month =7,
                        Day = 12,
                        Hour = 11,
                        Minute = 12,
                        Second = 13
                    }
                },
                new PersonInsuranceStatusDetailsDto() {
                    RegisterUID = Guid.NewGuid(),
                    CompositionUID = "Node11.behdasht.gov.ir::00401e77-8b38-4157-b1a7-4540d995d3b2",
                    PatientUID = "Node11.behdasht.gov.ir::1ee992cd-7f5d-4deb-a638-08b8e26cf176",
                    DomainModel = "HltHub.SendPersonPolicyInfo",
                    GSBIgin = null,
                    GSBRegisterID = null,
                    GSBResult = null,
                    LocalId = "6F439694-B595-4723-8AB2-7550183084C5",
                    MessageUID = Guid.NewGuid(),
                    Operation = Mapper.GSB.Domain.InsuranceDataCoordinator.Operation.Update,
                    Shebad = new DO_IDENTIFIER() { ID = "123456789", Type="HID", Assigner = "TAMIN", Issuer = "TAMIN"},
                    Status = StatusType.GSBFail,
                    Errors = new List<Domain.InsuranceDataCoordinator.ErrorMessage>()
                    {
                        new Domain.InsuranceDataCoordinator.ErrorMessage("server",ExceptionsMessages.An_error_occurred_while_processing_the_request_from_this_service.Replace("{0}","").Replace("{1}",""))
                    },
                    RecordVersion = 2,
                    StatusMessage = Messages.An_error_occurred_while_performing_the_operation_during_the_data_transmission_to_the_GSB_server,
                    PersonIdentifier = "3210001015",
                    PolicyUniqueCode = "30000000027",
                    RegisterDateTime = new DO_DATE_TIME()
                    {
                        Year = 1401,
                        Month =7,
                        Day = 14,
                        Hour = 11,
                        Minute = 12,
                        Second = 13
                    }
                }
                };
            return new PagingDto<List<PersonInsuranceStatusDetailsDto>>()
            {
                Result = results,
                PageNumber = 1,
                TotalPages = 1,
                TotalCountOfRecords = 2
            };
        }
    }
}
