using Mapper.GSB.Application.GSBAPICaller.SeedWorks;
using Mapper.GSB.Application.GSBAPICaller.Serviecs.GSBService.SendPerson.SendPersonInfo;
using Mapper.GSB.Application.GSBAPICaller.Serviecs.GSBService.SendPerson.SendPersonSupplimantryInfo;
using Mapper.GSB.Domain.Insurance;
using MOHME.Lib.Shared;

namespace Mapper.GSB.Application.GSBAPICaller.Insurance.Events.PersonInsuranceDataRecieved;

/// <summary>
/// مبدل داده های رویداد به کلاس های 
/// SendPerson
/// </summary>
internal static class PersonInsuranceDataRecievedMapper
{
    /// <summary>
    /// مبدل رویداد به بیمه نامه درمان تکمیلی
    /// </summary>
    /// <param name="event"></param>
    /// <param name="gSBSendDataSetting"></param>
    /// <returns></returns>
    public static SendPersonSupplimantryInfoInputDto MapToSendPersonSupplimantryInfoInputDto(PersonInsuranceCreatedEvent @event, IGSBSendDataSettings gSBSendDataSetting)
    {
        return new()
        {
            AppUser = gSBSendDataSetting.AppUser,
            ClientIp = gSBSendDataSetting.ClientIP,
            BirthDate = @event.Person.BirthDate,
            CompanyInsuredId = @event.PersonPolicy.CompanyInsuredId,
            CompanyPolicyId = @event.PersonPolicy.CompanyPolicyId,
            ExpireDate = @event.PersonPolicy.InsuranceExpirationDate,
            FatherName = @event.Person.Father_FirstName,
            FirstName = @event.Person.FirstName,
            LastName = @event.Person.LastName,
            Gender = @event.Person.Gender,
            InsuranceNumber = @event.MsgId.MessageUID?.ToString(),
            InsuranceType = @event.PersonPolicy.Insurer,
            InsuredType = @event.PersonPolicy.InsuredType.ToString(),
            InsurerName = @event.PersonPolicy.InsurerName,
            InsurerNatoinalCode = @event.PersonPolicy.insurerNationalCode,
            MainInsuredNationCode = @event.PersonPolicy.ResponsibleID,
            Marital = @event.Person.MaritalStatus,
            RelationType = @event.PersonPolicy.RelationType,
            PersonID = @event.Person.PersonId,
            InsuranceID = @event.PersonPolicy.Insurer,
            PolicyPrintNumber = @event.PersonPolicy.PolicyPrintNumber,
            PolicyUnqiueCode = @event.PersonPolicy.PolicyUniqueCode,
            PostalCode = @event.Person.PostalCode,
            StartDate = @event.PersonPolicy.EffectiveDate,
            RecommandationMessage = @event.PersonPolicy.RecommendationMessage
        };
    }
    /// <summary>
    /// مبدل رویداد به 
    /// ورودی فول درمان
    /// </summary>
    /// <param name="event"></param>
    /// <param name="gSBSendDataSetting"></param>
    /// <param name="statesMapping"></param>
    /// <returns></returns>
    public static SendPersonInfoInputDto MapToSendPersonInfoInputDto(PersonInsuranceCreatedEvent @event, IGSBSendDataSettings gSBSendDataSetting, IStatesMapping statesMapping)
    {
        DO_CODED_TEXT? Province = null;
        if (@event.PersonPolicy.ProvinceBranch is not null && statesMapping.StatesMap is not null)
        {
            string? codedString = @event!.PersonPolicy.ProvinceBranch.Coded_string;
            if (statesMapping.StatesMap.TryGetValue(Convert.ToInt32(codedString), out int gSMStateCode))
                codedString = gSMStateCode.ToString();
            
            Province = new DO_CODED_TEXT()
            {
                Value = @event.PersonPolicy.ProvinceBranch.Value,
                Terminology_id = @event.PersonPolicy.ProvinceBranch.Terminology_id,
                Coded_string = codedString
            };
        }
        return new()
        {
            AppUser = gSBSendDataSetting.AppUser,
            ClientIp = gSBSendDataSetting.ClientIP,
            PersonID = @event.Person.PersonId,
            InsurerID = @event.PersonPolicy.Insurer,
            FatherName = @event.Person.Father_FirstName,
            FirstName = @event.Person.FirstName,
            LastName = @event.Person.LastName,
            Gender = @event.Person.Gender,
            BirthDate = @event.Person.BirthDate,
            Marital = @event.Person.MaritalStatus,
            RelationType = @event.PersonPolicy.RelationType,
            ResponsibleID = @event.PersonPolicy.ResponsibleID,
            ResponsibleGender = @event.PersonPolicy.ResponsibleGender,
            ResponsibleFirstName = @event.PersonPolicy.ResponsibleFirstName,
            ResponsibleLastName = @event.PersonPolicy.ResponsibleLastName,
            InsuranceNumber = new DO_IDENTIFIER()
            {
                ID = @event.PersonPolicy.PolicyUniqueCode,
                Issuer = "CENTINSUR",
                Assigner = "CENTINSUR",
                Type = "policyUniqueCode"
            },
            InsuranceNumber2 = new DO_IDENTIFIER()
            {
                ID = @event.PersonPolicy.CompanyInsuredId,
                Issuer = "SupplementaryInsurer",
                Assigner = "SupplementaryInsurer",
                Type = "companyInsuredId"
            },
            InsuranceType = @event.PersonPolicy.Insurer,
            ExpireDate = @event.PersonPolicy.InsuranceExpirationDate,
            Branch = @event.PersonPolicy.Branch,
            Province = @event.PersonPolicy.ProvinceBranch,
            ProvinceVB = @event.PersonPolicy.ProvinceBranch,
            City = @event.PersonPolicy.CityBranch,
            Mobile = @event.Person.MobileNumber,
            Address = @event.Person.FullAddress,
            PostalCode = @event.Person.PostalCode,
            RecommandationMessage = @event.PersonPolicy.RecommendationMessage,
            FirstNameEnc = "",
            LastNameEnc = "",
            PersonIDEnc = @event.MsgId.MessageUID,
            IdNumber = "",
            WorkShop = @event.PersonPolicy.WorkShop,
            Feranshiz = @event.PersonPolicy.Feranshiz,
            PictureB64 = @event.Person.PictureB64,
            Igin = null,
            Account = @event.PersonPolicy.Account?.Select(x => new AccountVoDto
            {
                PersonID = @event.Person.PersonId,
                AccountID = x.AccountID,
                AccountType = x.AccountType,
                CreateDate = x.CreateDate,
                InsuranceLength = x.InsuranceLength,
                InitiateDate = x.InitiateDate,
                WaitingLength = x.WaitingLength,
                ActiveFrom = x.ActiveFrom,
                ActiveTo = x.ActiveTo,
                AccountStatus = x.AccountStatus
            }).ToList(),
        };

    }
}
