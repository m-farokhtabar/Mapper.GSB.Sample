namespace Mapper.GSB.Rest.API.StartupConfig.Settings;

/// <summary>
/// پیاده سازی تمامی رابط های 
/// Cache
/// </summary>
public class CacheMasterKeySetting : global::Services.Authorization.Cache.ICacheMasterKeySetting, Mapper.GSB.Application.SeedWork.Cache.ICacheMasterKeySetting
{
    /// <summary>
    /// <see cref="Mapper.GSB.Application.SeedWork.Cache.ICacheMasterKeySetting.MasterKey"/>
    /// <see cref="global::Services.Authorization.Cache.ICacheMasterKeySetting.MasterKey"/>
    /// </summary>
    public string MasterKey { get; set; } = string.Empty;
    /// <summary>
    /// <see cref="Mapper.GSB.Application.SeedWork.Cache.ICacheMasterKeySetting.ExpiredInDay"/>
    /// <see cref="global::Services.Authorization.Cache.ICacheMasterKeySetting.ExpiredInDay"/>
    /// </summary>
    public int ExpiredInDay { get; set; }
    /// <summary>
    /// <see cref="Mapper.GSB.Application.SeedWork.Cache.ICacheMasterKeySetting.CachePriority"/>
    /// <see cref="global::Services.Authorization.Cache.ICacheMasterKeySetting.CachePriority"/>
    /// </summary>
    public int CachePriority { get; set; }
    /// <summary>
    /// <see cref="Mapper.GSB.Application.SeedWork.Cache.ICacheMasterKeySetting.AbsoluteExpiredInDay"/>
    /// <see cref="global::Services.Authorization.Cache.ICacheMasterKeySetting.AbsoluteExpiredInDay"/>
    /// </summary>
    public int AbsoluteExpiredInDay { get; set; }
}
