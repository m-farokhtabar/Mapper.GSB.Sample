using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;

namespace Mapper.GSB.Rest.API.ViewModels.ErrorResult;
/// <summary>
/// در صورت وجود خطا منطقی یا زمان اجرا در هنگام اجرای خطا جواب درخواست با فرمت این کلاس ارسال خواهد شد.
/// </summary>
public class ErrorViewModel
{
    /// <summary>
    /// سازنده جهت ایجاد ویومدل
    /// </summary>
    public ErrorViewModel()
    {

    }
    /// <summary>
    /// سازنده برای تصحیل ایجاد ویومدل برای حالتی که فقط یک خطا وجود دارد
    /// </summary>
    /// <param name="Error"></param>
    public ErrorViewModel(ErrorDetails Error)
    {
        Errors = new List<ErrorDetails>
        {
            Error
        };
    }
    /// <summary>
    /// سازنده برای تصحیل ایجاد ویومدل برای حالتی که فقط یک خطا وجود دارد
    /// </summary>
    /// <param name="Errors"></param>
    public ErrorViewModel(List<ErrorDetails> Errors)
    {
        this.Errors = Errors;
    }
    /// <summary>
    ///لیست خطاهایی که روی داده است
    /// </summary>
    public List<ErrorDetails>? Errors { get; set; }
    /// <summary>
    /// تبدیل کلاس به جس سان
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
    /// <summary>
    /// تبدیل کلاس به
    /// XML
    /// </summary>
    /// <returns></returns>
    public string ToXmlString()
    {
        XmlSerializerNamespaces xmlNamespaces = new();
        var settings = new XmlWriterSettings
        {
            Indent = true,
            OmitXmlDeclaration = true
        };
        XmlSerializer Serializer = new(GetType());

        using StringWriter XmlStringStream = new();
        using XmlWriter writer = XmlWriter.Create(XmlStringStream, settings);
        Serializer.Serialize(writer, this, xmlNamespaces);
        return XmlStringStream.ToString();
    }
}
