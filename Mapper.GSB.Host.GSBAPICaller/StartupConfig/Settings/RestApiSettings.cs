using Mapper.GSB.Application.GSBAPICaller.SeedWorks.RestApi;
using System.Linq;

namespace Mapper.GSB.Host.GSBAPICaller.StartupConfig.Settings;

/// <summary>
/// <see cref="IRestApiSettings"/>
/// </summary>
public class RestApiSettings : IRestApiSettings
{
    /// <summary>
    /// <see cref="IRestApiSettings.BaseUrl"/>
    /// </summary>
    public string BaseUrl { get; init; } = string.Empty;
    /// <summary>
    /// <see cref="IRestApiSettings.Services"/>
    /// </summary>
    public List<ApiServiceDetails>? services { get; init; }
    /// <summary>
    /// <see cref="IRestApiSettings.Services"/>
    /// </summary>
    public List<IApiServiceDetails>? Services => services?.Cast<IApiServiceDetails>().ToList();
}
/// <summary>
/// <see cref="IApiServiceDetails"/>
/// </summary>
public class ApiServiceDetails : IApiServiceDetails
{
    /// <summary>
    /// <see cref="IApiServiceDetails.ServiceName"/>
    /// </summary>
    public string ServiceName { get; init; } = string.Empty;
    /// <summary>
    /// <see cref="IApiServiceDetails.Url"/>
    /// </summary>
    public string Url { get; init; } = string.Empty;
    /// <summary>
    /// <see cref="IApiServiceDetails.Url"/>
    /// </summary>
    public RestApiType RequestType { get; init; }
    /// <summary>
    /// <see cref="IApiServiceDetails.Headers"/>
    /// </summary>
    public Dictionary<string, string>? Headers { get; init; }
    /// <summary>
    /// <see cref="IApiServiceDetails.KeyValuePairs"/>
    /// </summary>
    public Dictionary<string, string>? KeyValuePairs { get; init; }
    /// <summary>
    /// <see cref="IApiServiceDetails.ContentType"/>
    /// </summary>
    public string ContentType { get; init; } = string.Empty;
    /// <summary>
    /// <see cref="IApiServiceDetails.IsUTF8"/>
    /// </summary>
    public bool IsUTF8 { get; init; }
}
