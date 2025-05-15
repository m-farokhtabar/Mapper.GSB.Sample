using System.ComponentModel.DataAnnotations;

namespace Mapper.GSB.Rest.API.ViewModels.ErrorResult;
/// <summary>
/// نوع خطا
/// </summary>
public enum ErrorType
{
    /// <summary>
    /// خطای منطقی به طور مثال  پیدا نکردن رکورد مورد نظر یا اشتباه وارد کردن داده ای
    /// مربوط به اعتبارسنجی داده ها
    /// </summary>
    [Display(Name = "خطای منطقی")]
    LogicalError = 0,
    /// <summary>
    /// خطای زمان اجرا می تواند به دلیل عدم دسترسی به پایگاه داده یا سیستم های دیگر به وجود آید و یا خطاهای غیر منتظره
    /// </summary>
    [Display(Name = "خطای زمان اجرا")]
    RuntimeError = 1,
}
