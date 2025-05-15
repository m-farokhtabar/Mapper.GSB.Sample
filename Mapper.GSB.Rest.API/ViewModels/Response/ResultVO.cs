namespace Mapper.GSB.Rest.API.ViewModels.Response;
/// <summary>
/// داده ها یا همان پاسخ مورد نظر
/// </summary>
/// <typeparam name="T"></typeparam>
public class ResultVO<T>
{
    /// <summary>
    /// داده
    /// </summary>
    public T? Data { get; set; }
    /// <summary>
    /// وضعیت خطا
    /// </summary>
    public bool IsError { get; set; }
    /// <summary>
    /// وضعیت
    /// </summary>
    public int? StatusCode { get; set; }
    /// <summary>
    /// شرح وضعیت پاسخ
    /// </summary>
    public string? Message
    {
        get
        {
            switch(StatusCode)
            {
                case 200:
                    return "عملیات با موفقیت انجام شده است.";                    
                case 201:
                    return "اطلاعات مورد نظر با موفقیت ثبت شده است.";
                case 400:
                    return "درخواست نامعتبر";
                case 401:
                    return "عدم اعتبار درخواست کننده";
                case 403:
                    return "عدم مجوز درخواست کننده برای سرویس مربوطه";
                case 404:
                    return "اطالعات مورد نظر یافت نشده است.";
                case 408:
                    return "مهلت زمانی جهت دریافت پاسخ از سرویس دهنده به پایان رسیده است.";
                case 409:
                    return "داده های دریافتی با داده های فعلی در تعارض میباشد.";
                case 500:
                    return "در زمان اجرای عملیات، سرور با خطا روبرو شده است.";
                default:
                    return "در زمان اجرای عملیات، سرور با خطا روبرو شده است.";
            }
        }
    }
}