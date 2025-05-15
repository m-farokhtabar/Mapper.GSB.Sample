using Mapper.GSB.Application.SeedWorks;
using Mapper.GSB.Domain.InsuranceDataCoordinator;
using Microsoft.Extensions.Logging;

namespace Mapper.GSB.Application.DDRAPICaller.Insurance.Services.Scheduler
{
    /// <summary>
    /// در این سرویس بررسی می کنیم که داده هایی که با موفقیت جهت ثبت در 
    /// DDR 
    /// ارسال نشده است دوباره بررسی و ارسال شود
    /// </summary>
    public class MissingSendingDataToDDRSchedulerService : IMissingSendingDataToDDRSchedulerService
    {
        private readonly IPersonInsuranceDataCoordinatorForDDRSchedulerExtensionProvider provider;
        private readonly IDDRSchedulerServiceSetting schedulerServiceSetting;
        private readonly IExternalMessageDispatcher messageDispatcher;
        private readonly ILogger<MissingSendingDataToDDRSchedulerService> logger;

        public MissingSendingDataToDDRSchedulerService(IPersonInsuranceDataCoordinatorForDDRSchedulerExtensionProvider provider,
                                                       IDDRSchedulerServiceSetting schedulerServiceSetting,
                                                       IExternalMessageDispatcher messageDispatcher,
                                                       ILogger<MissingSendingDataToDDRSchedulerService> logger)
        {
            this.provider = provider;
            this.schedulerServiceSetting = schedulerServiceSetting;
            this.messageDispatcher = messageDispatcher;
            this.logger = logger;
        }
        /// <summary>
        /// <see cref="IMissingSendingDataToGSBSchedulerService.Start"/>
        /// </summary>
        /// <returns></returns>
        public async Task Start(CancellationToken stoppingToken)
        {
            try
            {
                var createdDate = DateTime.Now.AddMinutes(-schedulerServiceSetting.WatingTimeForFetchingTheRecord);
                List<DDRSchedulerDto> insurances;
                int page = 1;
                int prevVersion = 1;
                logger.LogInformation($"- Will try to review {schedulerServiceSetting.RecordsCountPerFetch} in each step.");
                do
                {
                    insurances = await provider.FindAllInsurancesWhichIsNotSendingDataToDDRBeforeTheCreatedDateAndSortedByCreatedDate(createdDate, schedulerServiceSetting.RecordsCountPerFetch, page).ConfigureAwait(false);
                    if (insurances?.Count > 0)
                    {
                        logger.LogInformation($"- Step [{page}]: There are exact or more than {insurances?.Count} which need to resend to DDR server. Please be patient to process ....");
                        foreach (var insurance in insurances!.OrderBy(x => x.Version).ThenBy(x => x.CreateDate))
                        {
                            prevVersion = await DelayBetweenVersions(prevVersion, insurance.Version);
                            PersonInsuranceDataSentToGSBServiceSucceessfullyEvent @event = new(insurance.Id, insurance.Version, insurance.CreateDate);
                            await messageDispatcher.Publish(@event);
                            await DelayBetweenEachRequest();
                        }
                    }
                    page++;
                } while (insurances?.Count != 0 && !stoppingToken.IsCancellationRequested);
                logger.LogInformation($"- All records were reviewed and sent :)");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
            }
        }
        /// <summary>
        /// تاخیر میان هر درخواست برای راحتی کار سرور
        /// </summary>
        /// <returns></returns>
        private async Task DelayBetweenEachRequest()
        {
            if (schedulerServiceSetting.DelayBetweenSendingRequest > 0)
                await Task.Delay(schedulerServiceSetting.DelayBetweenSendingRequest);
        }

        /// <summary>
        /// تاخیر میان نسخه ها 
        /// </summary>
        /// <remarks>این تاخیر کمک می کند که مطمین شویم اگر بر حسب اتفاق دو نسخه از یک سند پشت سر هم یا بافاصله کوتاه آمدند فرصت کافی برای ثبت اولین نسخه وجود داشته باشد تا نسخه دوم رد نشود</remarks>
        /// <param name="prevVersion"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        private async Task<int> DelayBetweenVersions(int prevVersion, int version)
        {
            if (version != prevVersion)
                if (schedulerServiceSetting.DelayBetweenSendingBatchResponse > 0)
                    await Task.Delay(schedulerServiceSetting.DelayBetweenSendingBatchResponse * 1000);
            return version;
        }

    }
}
