using Mapper.GSB.Application.Insurance.Commands.Save;
using Mapper.GSB.Rest.API.ViewModels.Response;
using MOHME.Lib.Shared;
using Swashbuckle.AspNetCore.Filters;

namespace Mapper.GSB.Rest.API.Helpers.SwaggerExamples
{
    /// <summary>
    /// نمونه خروجی ثبت و ویرایش اطلاعات
    /// </summary>
    public class ResponseViewModelExample : IExamplesProvider<ResponseViewModel<List<DataVO>>>
    {
        /// <summary>
        /// ایجاد نمونه خروجی ثبت و ویرایش اطلاعات
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ResponseViewModel<List<DataVO>> GetExamples()
        {
            List<DataVO> results = new()
            {
                new DataVO
                {
                    CompositionUID ="Node11.behdasht.gov.ir::00401e77-8b38-4157-b1a7-4540d995d3b2",
                    PatientUID = "Node11.behdasht.gov.ir::1ee992cd-7f5d-4deb-a638-08b8e26cf176",
                    DomainModel = "HltHub.SendPersonPolicyInfo",
                    ErrorCode = 0,
                    ErrorMessage = "",
                    IsError = false,
                    LocalId = "6F439694-B595-4723-8AB2-7550183084C5",
                    Operation = (int)Mapper.GSB.Domain.InsuranceDataCoordinator.Operation.Insert,
                    MessageUID =Guid.NewGuid().ToString(),
                    RegisterUID = Guid.NewGuid().ToString(),
                    RecordVersion = 1,
                    RegisterDateTime = new DO_DATE_TIME()
                    {
                        Year = 1401,
                        Month =7,
                        Day = 12,
                        Hour = 11,
                        Minute = 12,
                        Second = 13
                    },
                    PersonIdentifier = "2722575485",
                    PolicyUniqueCode = "30000000027",
                    Shebad = new DO_IDENTIFIER() { ID = "123456789", Type="HID", Assigner = "TAMIN", Issuer = "TAMIN"}
                }
            };
            return Tools.CreateResponse(200, results);
        }
    }
}
