using Mapper.GSB.Application.GSBAPICaller.Insurance.Services;

namespace Mapper.GSB.Host.GSBAPICaller.StartupConfig.Settings;

/// <summary>
/// <see cref="IGSBSchedulerServiceSetting"/>
/// </summary>
public class GSBSchedulerServiceSetting : IGSBSchedulerServiceSetting
{
    /// <summary>
    /// <see cref="IGSBSchedulerServiceSetting.WatingTimeForFetchingTheRecord"/>
    /// </summary>
    public int WatingTimeForFetchingTheRecord { get; init; }
    /// <summary>
    /// <see cref="IGSBSchedulerServiceSetting.DelayBetweenSendingRequest"/>
    /// </summary>
    public int DelayBetweenSendingRequest { get; init; }
    /// <summary>
    /// <see cref="IGSBSchedulerServiceSetting.DelayBetweenSendingBatchResponse"/>
    /// </summary>
    public int DelayBetweenSendingBatchResponse { get; init; }
    /// <summary>
    /// <see cref="IGSBSchedulerServiceSetting.DelayBetweenSendingBatchResponse"/>
    /// </summary>
    public int RecordsCountPerFetch { get; init; }
    /// <summary>
    /// زمان مورد به ازای هر بار اجرای کامل سرویس
    /// به دقیقه
    /// </summary>
    public int ServiceRunningPeriod { get; init; }
}
