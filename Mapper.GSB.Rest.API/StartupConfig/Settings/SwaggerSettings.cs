namespace Mapper.GSB.Rest.API.StartupConfig.Settings;
/// <summary>
/// تنظیمات مروبط به 
/// Swagger
/// </summary>
public class SwaggerSettings
{
    /// <summary>
    /// عنوان اصلی سرویس ها
    /// </summary>
    public string? Title { get; set; }
    /// <summary>
    /// توضیحات
    /// </summary>
    public string? Description { get; set; }
    /// <summary>
    /// کپی رایت
    /// </summary>
    public string? Copyright { get; set; }
    /// <summary>
    /// نخه منسوخ شده
    /// </summary>
    public string? IsDeprecated { get; set; }
    /// <summary>
    /// نام
    /// </summary>
    public string? Name { get; set; }
    /// <summary>
    /// ایمیل
    /// </summary>
    public string? Email { get; set; }
    /// <summary>
    /// آدرس وب
    /// </summary>
    public string? Url { get; set; }
    /// <summary>
    /// عنوان سند راهنما
    /// </summary>
    public string? DocumentTitle { get; set; }
    /// <summary>
    /// عنوان سند در کامبو باکس
    /// </summary>
    public string? EndPointName { get; set; }
}
