using Mapper.GSB.Infrastructure.DDR;

namespace Mapper.GSB.Host.DDRAPICaller.StartupConfig.Settings;

/// <summary>
/// <see cref="IDDRRepositorySettings"/>
/// </summary>
public class DDRRepositorySettings : IDDRRepositorySettings
{
    /// <summary>
    /// <see cref="IDDRRepositorySettings.PreferMinimal"/>
    /// </summary>
    public string PreferMinimal { get; init; } = string.Empty;
    /// <summary>
    /// <see cref="IDDRRepositorySettings.PreferRepresentation"/>
    /// </summary>
    public string PreferRepresentation { get; init; } = string.Empty;
}
