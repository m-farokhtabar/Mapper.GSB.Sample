using Mapper.GSB.Domain.InsuranceDataCoordinator;
using MOHME.Lib.Shared;
using Mapper.GSB.Share.Helper;
using Mapper.GSB.Domain.Insurance;

namespace Mapper.GSB.Application.Insurance.Commands.Save;
/// <summary>
/// پاسخ
/// </summary>
public class DataVO
{
    /// <summary>
    /// ایا فراخوانی سرویس با خطا مواجه شد؟
    /// </summary>
    public bool? IsError { get; set; }
    /// <summary>
    /// شناسه یکتای داده پیام ارسالی به هاب بیمه مرکزی است که به ازای هر تراکنش شناسه یکتا به سیستم بازگردانده میشود. سیستمهای جامع بیمه گری شرکت ها باید این شناسه را در سیستم خود نگهداری کنند.
    /// </summary>
    public string? MessageUID { get; init; }
    /// <summary>
    /// تاریخ و ساعت ثبت اطلاعات در هاب بیمه مرکزی
    /// </summary>
    public DO_DATE_TIME? RegisterDateTime { get; set; }
    /// <summary>
    /// شناسه منحصر به فرد ثبت اطلاعات بیمه شده در هاب بیمه مرکزی است که به ازای هر بیمه شده  در داده پیام  ارسالی به سیستم بازگردانده میشود. سیستمهای جامع بیمه گری شرکت ها باید این شناسه ثبت را در سیستم خود نگهداری کنند.
    /// </summary>
    public string? RegisterUID { get; set; }
    /// <summary>
    /// کد ملی بیمه شده یا شناسه اتباع بیگانه یا پاسپورت
    /// </summary>
    public string? PersonIdentifier { get; set; }
    /// <summary>
    /// کد یکتای بیمه نامه (کد یکتای یازده رقمی صادر شده توسط بیمه مرکزی) 
    /// </summary>
    public string? PolicyUniqueCode { get; set; }
    /// <summary>
    /// نشان دهنده مفهوم یا مدلی سرویس فراخوانی شده است.
    /// </summary>
    public string? DomainModel { get; set; }
    /// <summary>
    /// شناسه منحصر به فرد محتوای ارسالی 
    /// </summary>
    public string? CompositionUID { get; set; }
    /// <summary>
    /// شناسه منحصر به فرد بیمار در سپاس
    /// </summary>
    public string? PatientUID { get; set; }
    /// <summary>
    /// شناسه منحصر بفرد صادر شده توسط سازمان بیمه گر در فرآیند استعلام الکترونیکی میباشد که می تواند شناسه ارجاع بیماران ارجاع شده از سطح 1و یا استعلام اطلاعات بیمه ای و نسخه بیمار باشد.
    /// </summary>
    public DO_IDENTIFIER? Shebad { get; set; }
    /// <summary>
    /// شناسه محلی رکورد در سامانه مورد نظر شرکت بیمه یا مرکز درمانی- این شناسه در صورت وجود در کلاس پیام ورودی سرویس، عینا در خروجی ارسال می گردد.
    /// </summary>
    public string? LocalId { get; set; }
    /// <summary>
    /// نسخه رکورد (تعداد نسخ ثبت شده قبلی برای این بیمه شده در پایگاه داده هاب بیمه مرکزی ارسال گردد)
    /// </summary>
    public int? RecordVersion { get; set; }
    /// <summary>
    /// عملیات انجام شده بر روی رکورد: 
    /// 1 درج
    /// 2 به روز رسانی
    /// </summary>
    public int? Operation { get; set; }
    /// <summary>
    /// در صورتی که در ارسال داده ها اشکالی رخ داده باشد، این ویژگی با کد خطای رخداده پُر میشود و جهت خطایابی در اختیار سیستم ارسال کننده قرار میگیرد
    /// </summary>
    public int? ErrorCode { get; set; }
    /// <summary>
    /// متن خطا در صورت وجود
    /// </summary>
    public string? ErrorMessage { get; set; }
    /// <summary>
    /// ایجاد شی نتیجه ثبت و یا ویرایش
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="operation"></param>
    /// <param name="isError"></param>
    /// <param name="errorMessage"></param>
    /// <param name="errorCode"></param>
    /// <returns></returns>
    public static DataVO MaptoDataVo(PersonInsurance entity, int operation, bool isError = false, string errorMessage = "", int errorCode = 0)
    {
        return new DataVO()
        {
            CompositionUID = entity.MsgId!.CompositionUID,
            DomainModel = PersonInsuranceDomainType.HltHub_SendPersonPolicyInfo.GetDisplayName(),
            LocalId = entity.MsgId!.LocalId,
            IsError = isError,
            ErrorMessage = errorMessage,
            ErrorCode = errorCode,
            MessageUID = entity.MsgId!.MessageUID,
            RegisterUID = entity.MsgId!.RegisterUID,
            PatientUID = entity.MsgId!.PatientUID,
            Operation = operation,
            RecordVersion = entity.MsgId!.Version,
            PolicyUniqueCode = entity.PersonPolicy!.PolicyUniqueCode,
            RegisterDateTime = entity.RegisterDateTime,
            PersonIdentifier = entity.Person!.PersonId.ID,
            Shebad = null
        };
    }
    /// <summary>
    /// ایجاد شی نتیجه ثبت و یا ویرایش
    /// </summary>
    /// <param name="request"></param>
    /// <param name="operation"></param>
    /// <param name="isError"></param>
    /// <param name="errorMessage"></param>
    /// <param name="errorCode"></param>
    /// <returns></returns>
    public static DataVO MaptoDataVo(SavePersonInsuranceCommand request, int operation, bool isError = false, string errorMessage = "", int errorCode = 0)
    {
        return new DataVO()
        {
            CompositionUID = request.MsgId!.CompositionUID,
            DomainModel = PersonInsuranceDomainType.HltHub_SendPersonPolicyInfo.GetDisplayName(),
            LocalId = request.MsgId!.LocalId,
            IsError = isError,
            ErrorMessage = errorMessage,
            ErrorCode = errorCode,
            MessageUID = request.MsgId!.MessageUID,
            RegisterUID = request.MsgId!.RegisterUID,
            PatientUID = request.MsgId!.PatientUID,
            Operation = operation,
            RecordVersion = request.MsgId!.Version,
            PolicyUniqueCode = request.PersonPolicy!.PolicyUniqueCode,
            RegisterDateTime = null,
            PersonIdentifier = request.Person!.PersonId!.ID!,
            Shebad = null
        };
    }

}