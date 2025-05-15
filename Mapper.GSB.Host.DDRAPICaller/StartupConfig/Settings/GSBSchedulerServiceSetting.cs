using Mapper.GSB.Application.DDRAPICaller.Insurance.Services.Scheduler;

namespace Mapper.GSB.Host.DDRAPICaller.StartupConfig.Settings;

/// <summary>
/// <see cref="IDDRSchedulerServiceSetting"/>
/// </summary>
public class DDRSchedulerServiceSetting : IDDRSchedulerServiceSetting
{
    /// <summary>
    /// <see cref="IDDRSchedulerServiceSetting.WatingTimeForFetchingTheRecord"/>
    /// </summary>
    public int WatingTimeForFetchingTheRecord { get; init; }
    /// <summary>
    /// <see cref="IDDRSchedulerServiceSetting.DelayBetweenSendingRequest"/>
    /// </summary>
    public int DelayBetweenSendingRequest { get; init; }
    /// <summary>
    /// <see cref="IDDRSchedulerServiceSetting.DelayBetweenSendingBatchResponse"/>
    /// </summary>
    public int DelayBetweenSendingBatchResponse { get; init; }
    /// <summary>
    /// <see cref="IDDRSchedulerServiceSetting.DelayBetweenSendingBatchResponse"/>
    /// </summary>
    public int RecordsCountPerFetch { get; init; }
    /// <summary>
    /// زمان مورد به ازای هر بار اجرای کامل سرویس
    /// به دقیقه
    /// </summary>
    public int ServiceRunningPeriod { get; init; }
}
