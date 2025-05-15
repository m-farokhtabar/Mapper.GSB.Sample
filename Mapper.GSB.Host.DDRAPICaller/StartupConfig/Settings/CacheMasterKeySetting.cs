using Mapper.GSB.Application.SeedWork.Cache;
using Mapper.openEHR.SeedWork.Cache;

namespace Mapper.GSB.Host.DDRAPICaller.StartupConfig.Settings
{
    /// <summary>
    /// <see cref="ICacheMasterKeySetting"/>
    /// </summary>
    public class CacheMasterKeySetting : ICacheMasterKeySetting, IOmCacheMasterKeySetting
    {
        /// <summary>
        /// <see cref="ICacheMasterKeySetting.MasterKey"/>
        /// </summary>
        public string MasterKey { get; set; } = string.Empty;
        /// <summary>
        /// <see cref="ICacheMasterKeySetting.ExpiredInDay"/>
        /// </summary>
        public int ExpiredInDay { get; set; }
        /// <summary>
        /// <see cref="ICacheMasterKeySetting.CachePriority"/>
        /// </summary>
        public int CachePriority { get; set; }
        /// <summary>
        /// <see cref="ICacheMasterKeySetting.AbsoluteExpiredInDay"/>
        /// </summary>
        public int AbsoluteExpiredInDay { get; set; }
    }
}
