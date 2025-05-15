
namespace Mapper.GSB.Rest.API.ViewModels.ErrorResult;
/// <summary>
/// جزییات خطا
/// </summary>
public class ErrorDetails
{
    /// <summary>
    /// ایجاد کد خطا
    /// </summary>
    private ErrorDetails()
    {

    }
    /// <summary>
    /// ایجاد کد خطا
    /// برای حالت تک پیام
    /// </summary>
    /// <param name="Code"></param>
    /// <param name="Message"></param>
    /// <param name="Type"></param>
    public ErrorDetails(string? Code, string Message, ErrorType Type)
    {
        this.Code = Code?.ToLower();
        this.Messages = new List<string>() { Message };
        this.Type = Type;
    }
    /// <summary>
    /// ایجاد کد خطا
    /// برای حالت جند پیام
    /// </summary>
    /// <param name="Code"></param>
    /// <param name="Messages"></param>
    /// <param name="Type"></param>
    public ErrorDetails(string? Code, List<string> Messages, ErrorType Type)
    {
        this.Code = Code?.ToLower();
        this.Messages = Messages;
        this.Type = Type;
    }

    /// <summary>
    /// کد خطا
    /// </summary>
    public string? Code { get; set; }
    /// <summary>
    /// پیام خطا
    /// </summary>
    public List<string>? Messages { get; set; }
    /// <summary>
    /// نوع خطا 
    /// منطقی
    /// یا زمان اجرا
    /// </summary>
    public ErrorType Type { get; set; }
}
