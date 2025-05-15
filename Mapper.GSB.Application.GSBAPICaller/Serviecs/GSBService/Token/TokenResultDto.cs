using Mapper.GSB.Application.GSBAPICaller.Serviecs.GSBService.ResponseBody;

namespace Mapper.GSB.Application.GSBAPICaller.Serviecs.GSBService.Token;
/// <summary>
/// نتیجه درخواست توکن
/// </summary>
public class TokenResultDto : IBodyData
{
    /// <summary>
    /// شناسه توکن
    /// </summary>
    public string TokenID { get; set; } = string.Empty;
    /// <summary>
    /// تاریخ انقضا
    /// </summary>
    public DateTime Expire { get; set; }
}