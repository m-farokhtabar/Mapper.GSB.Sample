using Mapper.GSB.Application.GSBAPICaller.Insurance.Events.PersonInsuranceDataRecieved;
using Mapper.GSB.Application.SeedWorks;
using Mapper.GSB.Domain.InsuranceDataCoordinator;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Mapper.GSB.Application.GSBAPICaller.Insurance.Services
{
    /// <summary>
    /// در این سرویس بررسی می کنیم که داده هایی که با موفقیت جهت ثبت در 
    /// GSB 
    /// ارسال نشده است دوباره بررسی و ارسال شود
    /// </summary>
    public class MissingSendingDataToGSBSchedulerService : IMissingSendingDataToGSBSchedulerService
    {
        private readonly IPersonInsuranceDataCoordinatorForSchedulerExtensionProvider provider;
        private readonly IGSBSchedulerServiceSetting gSBSchedulerServiceSetting;
        private readonly IExternalMessageDispatcher messageDispatcher;
        private readonly ILogger<MissingSendingDataToGSBSchedulerService> logger;

        public MissingSendingDataToGSBSchedulerService(IPersonInsuranceDataCoordinatorForSchedulerExtensionProvider provider,
                                                       IGSBSchedulerServiceSetting gSBSchedulerServiceSetting,
                                                       IExternalMessageDispatcher messageDispatcher,
                                                       ILogger<MissingSendingDataToGSBSchedulerService> logger)
        {
            this.provider = provider;
            this.gSBSchedulerServiceSetting = gSBSchedulerServiceSetting;
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
                var createdDate = DateTime.Now.AddMinutes(-gSBSchedulerServiceSetting.WatingTimeForFetchingTheRecord);
                List<GSBSchedulerDto> insurances;
                int page = 1;
                int prevVersion = 1;
                logger.LogInformation($"- Will try to review {gSBSchedulerServiceSetting.RecordsCountPerFetch} in each step.");
                do
                {
                    insurances = await provider.FindAllInsurancesWhichIsNotSendingDataToGSBBeforeTheCreatedDateAndSortedByCreatedDate(createdDate, gSBSchedulerServiceSetting.RecordsCountPerFetch, page).ConfigureAwait(false);
                    if (insurances?.Count > 0)
                    {
                        logger.LogInformation($"- Step [{page}]: There are exact or more than {insurances?.Count} which need to resend to GSB web server. Please be patient to process ....");                        
                        foreach (var insurance in insurances!.OrderByDescending(x => x.Version).ThenBy(x => x.CreateDate))
                        {
                            prevVersion = await DelayBetweenVersions(prevVersion, insurance.Version);
                            PersonInsuranceDataRecievedEvent @event = new(insurance.Id, insurance.PersonInsuranceCreatedEventId, insurance.Version, insurance.CreateDate);
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
            if (gSBSchedulerServiceSetting.DelayBetweenSendingRequest > 0)
                await Task.Delay(gSBSchedulerServiceSetting.DelayBetweenSendingRequest);
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
                if (gSBSchedulerServiceSetting.DelayBetweenSendingBatchResponse > 0)
                    await Task.Delay(gSBSchedulerServiceSetting.DelayBetweenSendingBatchResponse * 1000);
            return version;
        }

    }
}
