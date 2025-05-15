namespace Mapper.GSB.Rest.API.ViewModels.SendPersonPolicyInfo;
/// <summary>
/// ورودی سرویس اطلاعات بیمه شدگان جهت انجام عملیات ثبت یا ویرایش
/// </summary>
public record PersonPolicyInfoInputViewModel
{
    /// <summary>
    /// داده های بیمه شده و بیمه نامه
    /// </summary>
    public List<PersonPolicyInfoViewModel>? Data { get; init; }
}
