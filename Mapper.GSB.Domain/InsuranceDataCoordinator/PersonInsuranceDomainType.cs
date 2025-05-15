using System.ComponentModel.DataAnnotations;

namespace Mapper.GSB.Domain.InsuranceDataCoordinator;

/// <summary>
/// اواع دامنه های مورد تایید
/// </summary>
public enum PersonInsuranceDomainType
{
    /// <summary>
    /// برای بیمه نامه درمان تکمیلی و فول
    /// </summary>    
    [Display(Name = "HltHub.SendPersonPolicyInfo")]
    HltHub_SendPersonPolicyInfo,
}
