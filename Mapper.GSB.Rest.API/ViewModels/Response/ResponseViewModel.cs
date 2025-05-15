namespace Mapper.GSB.Rest.API.ViewModels.Response;
/// <summary>
/// فرمت خروجی برای 
/// POST, PUT
/// </summary>
/// <typeparam name="T">مدل خروجی</typeparam>
public class ResponseViewModel<T>
{
    /// <summary>
    /// پاسخ نهایی
    /// </summary>
    public ResultVO<T>? Result { get; set; }
    /// <summary>
    /// وضعیت پاسخ
    /// </summary>
    public StatusVO? Status { get; set; }
}
