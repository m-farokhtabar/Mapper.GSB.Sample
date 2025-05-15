using MOHME.Lib.Shared;

namespace Mapper.GSB.Application.Insurance.Commands.Save;

/// <summary>
/// مبدل دستورات ارسالی به دامنه سیستم
/// </summary>
internal class MapToDomain
{
    /// <summary>
    /// مبدل به مدل اطلاعات بیمه
    /// </summary>
    /// <param name="personPolicy"></param>
    /// <returns></returns>
    public static PersonPolicyVO MapToPersonPolicy(PersonPolicyVODto personPolicy)
    {
        return new PersonPolicyVO(personPolicy.Insurer!, personPolicy.PolicyType!, personPolicy.PolicyUniqueCode!, personPolicy.EffectiveDate!, personPolicy.InsuranceExpirationDate!, personPolicy.InsuranceBox,
                            personPolicy.RelationType!, personPolicy.PolicyPrintNumber!, personPolicy.CompanyPolicyId!, personPolicy.CompanyInsuredId!, personPolicy.InsuredType!.Value,
                            personPolicy.ResponsibleID!, personPolicy.ResponsibleGender!, personPolicy.ResponsibleFirstName!, personPolicy.ResponsibleLastName, personPolicy.InsurerName!,
                            personPolicy.insurerNationalCode!, personPolicy.PolicyIssueDate, personPolicy.BaseInsurer, personPolicy.ProvinceBranch!, personPolicy.CityBranch!, personPolicy.Branch!,
                            personPolicy.RecommendationMessage, personPolicy.PlanId, personPolicy.RequestReason, personPolicy.IsCoverageUnlimited!.Value, personPolicy.PolicyVerNo, personPolicy.PolicyVerUniqueCode,
                            personPolicy.ContractType, personPolicy.ShebaNo, personPolicy.BankAcc, personPolicy.AccNo, personPolicy.DeathDate, personPolicy.WorkShop, personPolicy.Feranshiz, MapToAccount(personPolicy.Account));
    }
    /// <summary>
    /// مبدل اکانت
    /// </summary>
    /// <param name="accounts"></param>
    /// <returns></returns>
    private static List<AccountVO>? MapToAccount(List<AccountVODto>? accounts)
    {
        List<AccountVO>? result = null;
        if (accounts?.Count>0)
        {
            result = new List<AccountVO>();
            foreach (var account in accounts)
                result.Add(new AccountVO(account.AccountID!, account.AccountType!, account.CreateDate, account.InsuranceLength, account.InitiateDate, account.WaitingLength, account.ActiveFrom!, account.ActiveTo!, account.AccountStatus!));
        }
        
        return result;
    }

    /// <summary>
    /// مبدل به مدل اطلاعات بیمه شونده
    /// </summary>
    /// <returns></returns>
    public static PersonInfoVO MapToPerson(PersonInfoVODto person)
    {
        return new PersonInfoVO(person.PersonId!, person.Province, person.City, person.PictureB64, person.OtherContacts, person.OtherIdentifier, person.BirthPlaceArea, person.Religion, person.MaritalStatus,
            person.Nationality, person.BirthDate!, person.BirthTime, person.BirthdateAccuracy, person.Father_FirstName, person.Father_LastName, person.Mother_FirstName,
            person.Mother_LastName, person.FullName, person.PostalCode!, person.Gender!, person.Job, person.JobDescribtion, person.FullAddress, person.LivingPlaceArea,
            person.IDCardNumber, person.IDIssueArea, person.HomeTel, person.MobileNumber, person.EducationLevel, person.FirstName!, person.LastName!, person.NationalCode, person.Languages, person.DeathDetail, person.BirthDetail);
    }
    /// <summary>
    /// مبدل به مدل اطلاعات تبادلی
    /// </summary>
    /// <param name="msgId"></param>
    /// <param name="isInsert"></param>
    /// <param name="registerUID"></param>
    /// <param name="messageUID"></param>
    /// <param name="version"></param>
    /// <returns></returns>
    public static MessageIdentifierVO MapToMessageIdentifier(MessageIdentifierVODto msgId, bool isInsert, string? registerUID, string? messageUID, int? version)
    {
        return new(msgId.VersionLifecycleState, msgId.IS_Queriable, msgId.CompositionSignature, msgId.SystemID, msgId.HealthCareFacilityID,
                                                       msgId.PatientUID, msgId.CompositionUID, msgId.Committer, msgId.LocalId, msgId.UniversityID, msgId.Deactivate, msgId.WithoutId,
                                                       version, registerUID?.ToString(), messageUID?.ToString(), isInsert);
    }
}
