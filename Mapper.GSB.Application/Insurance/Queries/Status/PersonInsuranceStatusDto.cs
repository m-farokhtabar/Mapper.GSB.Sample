namespace Mapper.GSB.Application.Insurance.Queries.Status;
/// <summary>
/// نمایش وضعیت های درخواست ثبت یا ویرایش بیمه نامه و بیمه شونده
/// </summary>
public class PersonInsuranceStatusDto
{
    /// <summary>
    /// شناسه منحصر به فرد ثبت اطلاعات بیمه شده در هاب بیمه مرکزی است که به ازای هر بیمه شده  در داده پیام  ارسالی به سیستم بازگردانده میشود. سیستمهای جامع بیمه گری شرکت ها باید این شناسه ثبت را در سیستم خود نگهداری کنند.
    /// </summary>
    public Guid RegisterUID { get; init; }
    /// <summary>
    /// نتایج و وضعیت مربوط به شناسه منحصر بفرد اطلاعات بیمه شده در هاب مرکزی
    /// </summary>
    public List<PersonInsuranceStatusDetailsDto>? Results { get; init; }
}