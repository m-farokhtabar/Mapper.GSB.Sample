using Mapper.GSB.Domain.InsuranceDataCoordinator;
using Mapper.GSB.Share.Resource;
using MOHME.Lib.Shared;
using System.ComponentModel.DataAnnotations;

namespace Mapper.GSB.Application.Insurance.Queries.Status;
/// <summary>
/// نمایش وضعیت درخواست ثبت یا ویرایش بیمه نامه و بیمه شونده
/// </summary>
public class PersonInsuranceStatusDetailsDto
{
    /// <summary>
    /// شناسه منحصر به فرد ثبت اطلاعات بیمه شده در هاب بیمه مرکزی است که به ازای هر بیمه شده  در داده پیام  ارسالی به سیستم بازگردانده میشود. سیستمهای جامع بیمه گری شرکت ها باید این شناسه ثبت را در سیستم خود نگهداری کنند.
    /// </summary>
    public Guid RegisterUID { get; init; }
    /// <summary>
    /// وضعیت درخواست
    /// </summary>
    public StatusType Status { get; init; }
    /// <summary>
    /// توضیحات وضعیت درخواست
    /// </summary>
    public string? StatusMessage { get; init; }
    /// <summary>
    /// شناسه منحصر به فرد بیمار در سپاس
    /// </summary>
    public string? PatientUID { get; init; }
    /// <summary>
    /// شناسه منحصر به فرد محتوای ارسالی 
    /// </summary>
    public string? CompositionUID { get; init; }
    /// <summary>
    /// نشان دهنده مفهوم یا مدلی سرویس فراخوانی شده است.
    /// </summary>
    public string? DomainModel { get; init; }
    /// <summary>
    /// خطای سیستم
    /// </summary>
    public List<ErrorMessage>? Errors { get; init; }
    /// <summary>
    /// GSB
    /// شناسه منحصر بفرد بیمه شده در بانک تجمیع بیمه سلامت
    /// </summary>
    public string? GSBIgin { get; init; }
    /// <summary>
    /// GSB
    /// شناسه تولید شده در فرآیند ثبت اطلاعات بیمه شده
    /// </summary>
    public string? GSBRegisterID { get; init; }
    /// <summary>
    /// نتیجه جواب GSB
    /// </summary>
    public string? GSBResult { get; init; }
    /// <summary>
    /// شناسه محلی رکورد در سامانه مورد نظر شرکت بیمه یا مرکز درمانی- این شناسه در صورت وجود در کلاس پیام ورودی سرویس، عینا در خروجی ارسال می گردد.
    /// </summary>
    public string? LocalId { get; init; }
    /// <summary>
    /// شناسه یکتای داده پیام ارسالی به هاب بیمه مرکزی است که به ازای هر تراکنش شناسه یکتا به سیستم بازگردانده میشود. سیستمهای جامع بیمه گری شرکت ها باید این شناسه را در سیستم خود نگهداری کنند.
    /// </summary>
    public Guid MessageUID { get; init; }
    /// <summary>
    /// نوع عملیات انجام شده جهت ثبت این داده
    /// </summary>
    public Mapper.GSB.Domain.InsuranceDataCoordinator.Operation Operation { get; init; }
    /// <summary>
    /// کد ملی بیمه شده یا شناسه اتباع بیگانه یا پاسپورت
    /// </summary>
    public string? PersonIdentifier { get; init; }
    /// <summary>
    /// کد یکتای بیمه نامه (کد یکتای یازده رقمی صادر شده توسط بیمه مرکزی) 
    /// </summary>
    public string? PolicyUniqueCode { get; init; }
    /// <summary>
    /// نسخه رکورد (تعداد نسخ ثبت شده قبلی برای این بیمه شده در پایگاه داده هاب بیمه مرکزی ارسال گردد)
    /// </summary>
    public int RecordVersion { get; init; }
    /// <summary>
    /// تاریخ و ساعت ثبت اطلاعات در هاب بیمه مرکزی
    /// </summary>
    public DO_DATE_TIME? RegisterDateTime { get; init; }
    /// <summary>
    /// شناسه منحصر بفرد صادر شده توسط سازمان بیمه گر در فرآیند استعلام الکترونیکی میباشد که می تواند شناسه ارجاع بیماران ارجاع شده از سطح 1و یا استعلام اطلاعات بیمه ای و نسخه بیمار باشد.
    /// </summary>
    public DO_IDENTIFIER? Shebad { get; init; }
}
