using Azure;
using Mapper.GSB.Application.DDRAPICaller.Insurance.Services.Scheduler;
using Mapper.GSB.Application.GSBAPICaller.Insurance.Events.PersonInsuranceDataRecieved;
using Mapper.GSB.Application.GSBAPICaller.Insurance.Services;
using Mapper.GSB.Application.SeedWorks.Providers.PersonInsuranceProvider;
using Mapper.GSB.Domain.InsuranceDataCoordinator;
using Mapper.GSB.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Mapper.GSB.Infrastructure.Provider;

/// <summary>
/// <see cref="IPersonInsuranceDataCoordinatorProvider"/>
/// </summary>
internal class PersonInsuranceDataCoordinatorProvider : IPersonInsuranceDataCoordinatorProvider, IPersonInsuranceDataCoordinatorForSchedulerExtensionProvider, IPersonInsuranceDataCoordinatorForDDRSchedulerExtensionProvider
{
    private readonly IDbSet dbSet;

    /// <summary>
    /// ایجاد شی دریافت کننده اطلاعات هعماهنگ کننده
    /// دریافت سرویس پایگاه داده جهت واکشی داده ها
    /// </summary>
    /// <param name="dbSet"></param>
    public PersonInsuranceDataCoordinatorProvider(IDbSet dbSet)
    {
        this.dbSet = dbSet;
    }

    /// <summary>
    /// <see cref="IPersonInsuranceDataCoordinatorProvider.FindByPersonIdAsync(string)"/>
    /// </summary>
    /// <param name="personId"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<List<PersonInsuranceIdentifiersDto>> FindIdentifiersByPersonIdAsync(string personId)
    {
        //TODO: personType به این دلیل اضافه نشده است چون به غلط رشته ای بودن کارایی ایندکس را پایین می اورد و احتمال نیاز به آن هم کم است
        return await dbSet.Get<PersonInsuranceDataCoordinator>()!.AsNoTracking()
                    .Where(x => x.PersonId == personId.Trim() && x.Status >= InsuranceDataStatus.SavePersonInopenEHRRepositoryIsSucceessful)
                    .Select(x => new PersonInsuranceIdentifiersDto()
                    {
                        Id = x.Id,
                        PersonId = x.PersonId,
                        PersonIdType = x.PersonIdType,
                        openEHRPartyId = x.openEHRPartyId,
                        openEHRPartyRelationshipId = x.openEHRPartyRelationshipId,
                        Status = x.Status,
                        RegisterUID = x.RegisterUID
                    }).ToListAsync().ConfigureAwait(false);
    }
    /// <summary>
    /// <see cref="IPersonInsuranceDataCoordinatorProvider.FindIdentifiersAtLeastHasSavePersonInopenEHRSuccessfulStatusByRegisterUIDAsync(Guid)"/>
    /// </summary>
    /// <param name="PersonId"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<List<PersonInsuranceIdentifiersDto>> FindIdentifiersAtLeastHasSavePersonInopenEHRSuccessfulStatusByRegisterUIDAsync(Guid registerUID)
    {
        return await dbSet.Get<PersonInsuranceDataCoordinator>()!.AsNoTracking()
                    .Where(x => x.RegisterUID == registerUID && x.Status >= InsuranceDataStatus.SavePersonInopenEHRRepositoryIsSucceessful)
                    .Select(x => new PersonInsuranceIdentifiersDto()
                    {
                        Id = x.Id,
                        PersonId = x.PersonId,
                        PersonIdType = x.PersonIdType,
                        openEHRPartyId = x.openEHRPartyId,
                        openEHRPartyRelationshipId = x.openEHRPartyRelationshipId,
                        Status = x.Status,
                        RegisterUID = x.RegisterUID
                    }).ToListAsync().ConfigureAwait(false);
    }
    /// <summary>
    /// <see cref="IPersonInsuranceDataCoordinatorProvider.FindByPersonIdAndInsurerIdAndPolicyUniqueCodeAsync(string, int, string)"/>
    /// </summary>
    /// <param name="personId"></param>
    /// <param name="insurerId"></param>
    /// <param name="policyUniqueCode"></param>
    /// <returns></returns>
    public async Task<List<PersonInsuranceSaveIdentifiersDto>> FindByPersonIdAndInsurerIdAndPolicyUniqueCodeAsync(string personId, int insurerId, string policyUniqueCode)
    {
        return await dbSet.Get<PersonInsuranceDataCoordinator>()!.AsNoTracking()
            .Where(x => x.PersonId == personId && x.InsurerId == insurerId && x.PolicyUniqueCode == policyUniqueCode)
            .Select(x => new PersonInsuranceSaveIdentifiersDto()
            {
                Id = x.Id,
                RegisterUID = x.RegisterUID,
                MessageUID = x.MessageUID,
                Version = x.Version
            }).ToListAsync().ConfigureAwait(false);
    }
    /// <summary>
    /// <see cref="IPersonInsuranceDataCoordinatorProvider.FindByPersonIdAndInsurerIdAndAccountIdAsync(string, int, string)"/>
    /// </summary>
    /// <param name="personId"></param>
    /// <param name="insurerId"></param>
    /// <param name="accountID"></param>
    /// <returns></returns>
    public async Task<List<PersonInsuranceSaveIdentifiersDto>> FindByPersonIdAndInsurerIdAndAccountIdAsync(string personId, int insurerId, string accountID)
    {
        return await dbSet.Get<PersonInsuranceDataCoordinator>()!.AsNoTracking()
            .Where(x => x.PersonId == personId && x.InsurerId == insurerId && x.AccountID == accountID)
            .Select(x => new PersonInsuranceSaveIdentifiersDto()
            {
                Id = x.Id,
                RegisterUID = x.RegisterUID,
                MessageUID = x.MessageUID,
                Version = x.Version
            }).ToListAsync().ConfigureAwait(false);
    }
    /// <summary>
    /// <see cref="IPersonInsuranceDataCoordinatorProvider.FindByRegisterUIDAsync(Guid)"/>
    /// </summary>
    /// <param name="registerUID"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<List<PersonInsuranceDataCoordinator>> FindByRegisterUIDAsync(Guid registerUID)
    {
        return await dbSet.Get<PersonInsuranceDataCoordinator>()!.AsNoTracking()
                    .Where(x => x.RegisterUID == registerUID)
                    .ToListAsync().ConfigureAwait(false);
    }
    /// <summary>
    /// <see cref="IPersonInsuranceDataCoordinatorProvider.FindByCreatedDateAsync(DateTime)"/>
    /// </summary>
    /// <param name="registerUID"></param>
    /// <param name="date"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<List<PersonInsuranceDataCoordinator>> FindByCreatedDateAsync(DateTime date, int? InsurerId)
    {
        var createdDateStart = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
        var createdDateEnd = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);
        IQueryable<PersonInsuranceDataCoordinator> conditions = dbSet.Get<PersonInsuranceDataCoordinator>()!.AsNoTracking().Where(x => x.CreatedDate >= createdDateStart && x.CreatedDate <= createdDateEnd);
        if (InsurerId.HasValue)
            conditions.Where(x => x.InsurerId == InsurerId.Value);
        return await conditions.ToListAsync().ConfigureAwait(false);
    }
    /// <summary>
    /// <see cref="IPersonInsuranceDataCoordinatorProvider.FindInsurancesWhichEncountersErrorByCreatedDateAsync(DateTime)"/>
    /// </summary>
    /// <param name="date"></param>
    /// <param name="InsurerId"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<List<PersonInsuranceDataCoordinator>> FindInsurancesWhichEncountersErrorByCreatedDateAsync(DateTime date, int? InsurerId)
    {
        var createdDateStart = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
        var createdDateEnd = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);
        IQueryable<PersonInsuranceDataCoordinator> conditions = dbSet.Get<PersonInsuranceDataCoordinator>()!.AsNoTracking()
                                                                     .Where(x => x.CreatedDate >= createdDateStart && x.CreatedDate <= createdDateEnd && x.Status == InsuranceDataStatus.SentToGSBServiceIsUnSucceessful);
        if (InsurerId.HasValue)
            conditions.Where(x => x.InsurerId == InsurerId.Value);
        return await conditions.ToListAsync().ConfigureAwait(false);
    }
    /// <summary>
    /// <see cref="IPersonInsuranceDataCoordinatorProvider.FindByPersonIdAndPersonTypeAsync(string PersonId, string PersonType)"/>
    /// </summary>
    /// <param name="PersonId"></param>
    /// <param name="PersonType"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<List<PersonInsuranceDataCoordinator>> FindByPersonIdAndPersonTypeAsync(string PersonId, string PersonType)
    {
        return await dbSet.Get<PersonInsuranceDataCoordinator>()!.AsNoTracking().Where(x => x.PersonId == PersonId && x.PersonIdType == PersonType).ToListAsync().ConfigureAwait(false);
    }
    /// <summary>
    /// <see cref="IPersonInsuranceDataCoordinatorForSchedulerExtensionProvider.FindAllInsurancesWhichIsNotSendingDataToGSBBeforeTheCreatedDateAndSortedByCreatedDate(DateTime, int, int)"/>
    /// </summary>
    /// <param name="createdDate"></param>
    /// <param name="recordsPerPage"></param>
    /// <param name="page"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<List<GSBSchedulerDto>> FindAllInsurancesWhichIsNotSendingDataToGSBBeforeTheCreatedDateAndSortedByCreatedDate(DateTime createdDate, int recordsPerPage, int page = 1)
    {
        page = page < 0 ? 1 : page;
        return await dbSet.Get<PersonInsuranceDataCoordinator>()!.AsNoTracking()
                                                                  .Where(x => x.CreatedDate <= createdDate && (x.Status == InsuranceDataStatus.SentToGSBServiceIsUnSucceessful || x.Status == InsuranceDataStatus.Recieved))
                                                                  .OrderByDescending(x => x.CreatedDate).Skip((page - 1) * recordsPerPage).Take(recordsPerPage)
                                                                  .Select(x=> new GSBSchedulerDto(x.Id, x.PersonInsuranceCreatedEventId, x.Version, x.CreatedDate)).ToListAsync().ConfigureAwait(false);
    }
    /// <summary>
    /// <see cref="IPersonInsuranceDataCoordinatorForSchedulerExtensionProvider.FindAllInsurancesWhichIsNotSendingDataToGSBBeforeTheCreatedDateAndSortedByCreatedDate(DateTime, int, int)"/>
    /// </summary>
    /// <param name="createdDate"></param>
    /// <param name="recordsPerPage"></param>
    /// <param name="page"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<List<DDRSchedulerDto>> FindAllInsurancesWhichIsNotSendingDataToDDRBeforeTheCreatedDateAndSortedByCreatedDate(DateTime createdDate, int recordsPerPage, int page = 1)
    {
        page = page < 0 ? 1 : page; 
        return await dbSet.Get<PersonInsuranceDataCoordinator>()!.AsNoTracking()
                                                                  .Where(x => x.CreatedDate <= createdDate && (x.Status == InsuranceDataStatus.SentToGSBServiceIsSucceessful || 
                                                                                                               x.Status == InsuranceDataStatus.SavePersonInopenEHRRepositoryIsUnSucceessful ||
                                                                                                               x.Status == InsuranceDataStatus.SavePersonInopenEHRRepositoryIsSucceessful ||
                                                                                                               x.Status == InsuranceDataStatus.SaveInsurnaceDataInopenEHRRepositoryIsUnSucceessful))
                                                                  .OrderBy(x => x.CreatedDate).Skip((page - 1) * recordsPerPage).Take(recordsPerPage)
                                                                  .Select(x => new DDRSchedulerDto(x.Id, x.Version, x.CreatedDate)).ToListAsync().ConfigureAwait(false);
    }
}
