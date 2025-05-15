using Mapper.GSB.Application.Insurance.Commands.Save;
using Mapper.GSB.Rest.API.ViewModels.SendPersonPolicyInfo;
using MOHME.Lib.Shared;
using Swashbuckle.AspNetCore.Filters;

namespace Mapper.GSB.Rest.API.Helpers.SwaggerExamples
{
    /// <summary>
    /// نمونه ورودی برای ثبت و ویرایش اطلاعات بیمه شونده و بیمه نامه
    /// </summary>
    public class PersonPolicyInfoInputViewModelExample : IExamplesProvider<PersonPolicyInfoInputViewModel>
    {
        /// <summary>
        /// ساخت نمونه مورد نظر
        /// </summary>
        /// <returns></returns>
        public PersonPolicyInfoInputViewModel GetExamples()
        {
            return new PersonPolicyInfoInputViewModel()
            {
                Data = new List<PersonPolicyInfoViewModel>()
                {
                    new PersonPolicyInfoViewModel()
                    {
                        MsgID = CreateMessageIdentifierVOSample(),
                        Person = CreatePersonInfoVOSample(),
                        PersonPolicy = CreatePersonPolicyVOSample(),
                        ServiceDateTime = new DO_DATE_TIME() {
                            Year = 1402,
                            Month = 11,
                            Day = 3,
                            Hour = 11,
                            Minute = 12,
                            Second = 13,
                            ISOString = "1402/11/03"
                        }
                    }
                }
            };
        }
        /// <summary>
        /// ایجاد نمونه مورد تبادل بین سرویس ها
        /// </summary>
        /// <returns></returns>
        private MessageIdentifierVODto CreateMessageIdentifierVOSample()
        {
            var versionLifecycleState = new DO_CODED_TEXT()
            {
                Value = "incomplete",
                Coded_string = "1.1.1.2",
                Terminology_id = "thritaEHR"
            };
            var systemID = new DO_IDENTIFIER()
            {
                Issuer = "MOHME_IT",
                Assigner = "MOHME_IT",
                ID = "79bac5f5-1b2b-41a4-8f2b-584cb58272fc",
                Type = "System_ID"
            };
            var healthCareFacilityID = new DO_IDENTIFIER()
            {
                Issuer = "MAXA",
                Assigner = "MAXA",
                ID = "10",
                Type = "thritaEHR.insurer"
            };
            return new MessageIdentifierVODto(versionLifecycleState, false, null, systemID, healthCareFacilityID, "Node11.behdasht.gov.ir::1ee992cd-7f5d-4deb-a638-08b8e26cf176",
                                           "Node11.behdasht.gov.ir::00401e77-8b38-4157-b1a7-4540d995d3b2", null, "6F439694-B595-4723-8AB2-7550183084C5", null, false, false, null, null, null);
        }
        /// <summary>
        /// ایجاد نمونه برای بیمه شونده
        /// </summary>
        /// <returns></returns>
        private PersonInfoVODto CreatePersonInfoVOSample()
        {
            var personID = new DO_IDENTIFIER()
            {
                Issuer = "National_Org_Civil_Reg",
                Assigner = "National_Org_Civil_Reg",
                ID = "2722575485",
                Type = "National_Code"
            };
            var province = new DO_CODED_TEXT()
            {
                Value = "تهران",
                Coded_string = "24",
                Terminology_id = "countryDivisions"
            };
            var city = new DO_CODED_TEXT()
            {
                Value = "تهران",
                Coded_string = "019",
                Terminology_id = "countryDivisions"
            };
            var maritalStatus = new DO_CODED_TEXT()
            {
                Value = "متأهل",
                Coded_string = "2",
                Terminology_id = "thritaEHR.maritalStatus"
            };
            var nationality = new DO_CODED_TEXT()
            {
                Value = "IRAN, ISLAMIC REPUBLIC OF",
                Coded_string = "IR",
                Terminology_id = "ISO_3166-1"
            };
            var gender = new DO_CODED_TEXT()
            {
                Value = "مرد",
                Coded_string = "1",
                Terminology_id = "thritaEHR.gender"
            };
            var birthDate = new DO_DATE()
            {
                Year = 1362,
                Day = 8,
                Month = 10,
                ISOString = "1362/08/10"
            };
             
            return new PersonInfoVODto(personID, province, city, GetImageSample(), null, null, null, null, maritalStatus, nationality, birthDate, null, null,
                                    "محمد", "فرخ تبار", null, null, "مهدی فرخ تبار", "9377183778", gender, null, null, "خیابان نلسون ماندلا (آفریقا)، نبش خیابان مریم، برج بیمه",
                                    null, null, null, "02124551000", "09356530013", null, "مهدی", "فرخ تبار", "2722575485", null, null, null);
        }
        /// <summary>
        /// ایجاد نمونه اطلاعات بیمه نامه
        /// </summary>
        /// <returns></returns>
        private PersonPolicyVODto CreatePersonPolicyVOSample()
        {
            var insurer = new DO_CODED_TEXT()
            {
                Value = "بیمه آسیا",
                Coded_string = "10",
                Terminology_id = "thritaEHR.insurer"
            };
            var policyType = new DO_CODED_TEXT()
            {
                Value = "SendPersonInfo",
                Coded_string = "2",
                Terminology_id = "hltHub.policyType"
            };
            var effectiveDate = new DO_DATE()
            {
                Year = 1402,
                Day = 7,
                Month = 8,
                ISOString = "1402/07/25"
            };
            var insuranceExpirationDate = new DO_DATE()
            {
                Year = 1402,
                Day = 8,
                Month = 10,
                ISOString = "1402/08/10"
            };
            var insuranceBox = new DO_CODED_TEXT()
            {
                Value = "صندوق پایه",
                Coded_string = "99",
                Terminology_id = "thritaEHR.insuranceBox"
            };
            var relationType = new DO_CODED_TEXT()
            {
                Value = "سرپرست",
                Coded_string = "1",
                Terminology_id = "PersonPersonRelationType"
            };
            var responsibleID = new DO_IDENTIFIER()
            {
                Issuer = "National_Org_Civil_Reg",
                Assigner = "National_Org_Civil_Reg",
                ID = "2722575485",
                Type = "National_Code"
            };
            var responsibleGender = new DO_CODED_TEXT()
            {
                Value = "مرد",
                Coded_string = "1",
                Terminology_id = "thritaEHR.Gender"
            };
            var policyIssueDate = new DO_DATE()
            {
                Year = 1402,
                Day = 7,
                Month = 11,
                ISOString = "1402/07/11"
            };
            var baseInsurer = new DO_CODED_TEXT()
            {
                Value = "خدمات درماني",
                Coded_string = "2",
                Terminology_id = "thritaEHR.Insurer"
            };
            var provinceBranch = new DO_CODED_TEXT()
            {
                Value = "تهران",
                Coded_string = "24",
                Terminology_id = "countryDivisions"
            };
            var cityBranch = new DO_CODED_TEXT()
            {
                Value = "تهران",
                Coded_string = "019",
                Terminology_id = "countryDivisions"
            };
            var branch = new DO_CODED_TEXT()
            {
                Value = "شعبه جردن تهران",
                Coded_string = "1100",
                Terminology_id = "SupplementaryInsurer"
            };
            var planId = new DO_CODED_TEXT()
            {
                Value = "طرح 1",
                Coded_string = "17678",
                Terminology_id = "hltHub.SupplementaryInsurer"
            };
            var requestReason = new DO_CODED_TEXT()
            {
                Value = "اضافه يا حذف يا تغيير مشخصات بيمه شدگان",
                Coded_string = "2",
                Terminology_id = "hltHub.RequestReason"
            };
            var contractType = new DO_CODED_TEXT()
            {
                Value = "قراردادی",
                Coded_string = "3",
                Terminology_id = "hltHub.ContractType"
            };
            var bankAcc = new DO_CODED_TEXT()
            {
                Value = "بانک ملی ایران",
                Coded_string = "28",
                Terminology_id = "hltHub.BankAcc"
            };
            var workShop = new DO_CODED_TEXT()
            {
                Value = "شرکت آب و برق اهواز",
                Coded_string = "54628",
                Terminology_id = "SupplementaryInsurer"
            };
            return new PersonPolicyVODto(insurer, policyType, "30000000027", effectiveDate, insuranceExpirationDate, insuranceBox, relationType, "14020723027", "2000027", "4000027", 1,
                                      responsibleID, responsibleGender, "مهدی", "فرخ تبار", "تست از بیمه مرکزی سرویس", "40000000027", policyIssueDate, baseInsurer, provinceBranch, cityBranch,
                                      branch, "Test Service BimeMArkazi", planId, requestReason, false, "4", "30815940573", contractType, "IR500170000000101105893002", bankAcc, "0101105893002", null, workShop,
                                      "15%", CreateAccountVOSamples());
        }
        /// <summary>
        /// ایجاد نمونه مشخصات صندوق ها
        /// </summary>
        /// <returns></returns>
        public List<AccountVODto> CreateAccountVOSamples()
        {
            var accountType = new DO_CODED_TEXT()
            {
                Value = "صندوق پایه",
                Coded_string = "99",
                Terminology_id = "thritaEHR.insuranceBox"
            };
            var createDate = new DO_DATE()
            {
                Year = 1402,
                Day = 7,
                Month = 11,
                ISOString = "1402/07/11"
            };
            var initiateDate = new DO_DATE()
            {
                Year = 1402,
                Day = 7,
                Month = 12,
                ISOString = "1402/07/11"
            };
            var activeFrom = new DO_DATE()
            {
                Year = 1402,
                Day = 7,
                Month = 12,
                ISOString = "1402/07/11"
            };
            var activeTo = new DO_DATE()
            {
                Year = 1403,
                Day = 7,
                Month = 12,
                ISOString = "1402/07/11"
            };
            var accountStatus = new DO_CODED_TEXT()
            {
                Value = "A",
                Coded_string = "A",
                Terminology_id = "A"
            };
            return new List<AccountVODto>
            {
                new AccountVODto("2900",accountType,createDate,365,initiateDate,30,activeFrom,activeTo,accountStatus)
            };
        }
        /// <summary>
        /// ایجاد نممونه تولید تصویر
        /// </summary>
        /// <returns></returns>
        public string GetImageSample()
        {
            return "data:image/jpg;base64,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";
        }
    }
}
