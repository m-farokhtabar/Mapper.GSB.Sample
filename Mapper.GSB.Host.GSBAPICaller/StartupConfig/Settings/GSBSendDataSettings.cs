using Mapper.GSB.Application.GSBAPICaller.Insurance.Events.PersonInsuranceDataRecieved;

namespace Mapper.GSB.Host.GSBAPICaller.StartupConfig.Settings
{
    /// <summary>
    /// <see cref="IGSBSendDataSettings"/>
    /// </summary>
    public class GSBSendDataSettings : IGSBSendDataSettings
    {
        /// <summary>
        /// <see cref="IGSBSendDataSettings.AppUser"/>
        /// </summary>
        public string AppUser { get; init; } = string.Empty;
        /// <summary>
        /// <see cref="IGSBSendDataSettings.ClientIP"/>
        /// </summary>
        public string ClientIP { get; init; } = string.Empty;
    }
}
