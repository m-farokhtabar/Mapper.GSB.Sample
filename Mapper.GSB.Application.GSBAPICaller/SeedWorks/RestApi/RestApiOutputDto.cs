using System.Net;

namespace Mapper.GSB.Application.GSBAPICaller.SeedWorks.RestApi;
/// <summary>
/// خروجی یک سرویس 
/// Rest
/// </summary>
public class RestApiOutputDto
{
    /// <summary>
    /// وضعیت نتیجه درخواست یک سرویس 
    /// Rest
    /// </summary>
    public HttpStatusCode Status { get; set; }
    /// <summary>
    /// خروجی یا نتیجه ارسالی از طرف سرور
    /// </summary>
    public string? Data { get; set; }
}
