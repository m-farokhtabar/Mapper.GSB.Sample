namespace Mapper.GSB.Application.GSBAPICaller.Serviecs.GSBService.ResponseBody;

/// <summary>
/// 
/// </summary>
public class DataResultDto<T> where T : IBodyData
{
    /// <summary>
    /// 
    /// </summary>
    public ResultBodyDto<T>? Data { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public Status? Status { get; set; }
}
