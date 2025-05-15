using Mapper.GSB.Application.Insurance.Commands.Save;
using MOHME.Lib.Shared;

namespace Mapper.GSB.Rest.API.ViewModels.SendPersonPolicyInfo;
/// <summary>
/// اطلاعات بیمه شدگان جهت ثبت یا ویرایش
/// </summary>
public record PersonPolicyInfoViewModel
{
    /// <summary>
    /// اطلاعات مورد استفاده در تبادل داده با سرویس های پرونده الکترونیکی سلامت می باشد
    /// </summary>
    public MessageIdentifierVODto? MsgID { get; init; }
    /// <summary>
    /// اطلاعات مرتبط با اطالعات هویتی بیمه شده و اطالعات تماس آن میباشد
    /// </summary>
    public PersonInfoVODto? Person { get; init; }
    /// <summary>
    /// اطلاعات اصلی مربوط به اطالعات بیمه نامه بیمه شده می باشد
    /// </summary>
    public PersonPolicyVODto? PersonPolicy { get; init; }
    /// <summary>
    /// زمان ثبت/الحاقیه بیمه شده در شرکت بیمه تکمیلی -  زمان ارائه خدمت
    /// </summary>
    public DO_DATE_TIME? ServiceDateTime { get; init; }
}
