namespace Mapper.GSB.Rest.API.ViewModels.Response;
/// <summary>
/// وضعیت پاسخ
/// </summary>
public class StatusVO
{
    /// <summary>
    /// کد وضعیت
    /// </summary>
    public int? StatusCode { get; set; }
    /// <summary>
    /// پیام مربوطه
    /// </summary>
    public string? Message { get; set; }
}