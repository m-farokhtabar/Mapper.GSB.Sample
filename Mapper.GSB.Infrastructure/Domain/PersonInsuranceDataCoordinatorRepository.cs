using Mapper.GSB.Domain.InsuranceDataCoordinator;
using Mapper.GSB.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Mapper.GSB.Infrastructure.Domain;

/// <summary>
/// <see cref="IPersonInsuranceDataCoordinatorRepository"/>
/// </summary>
internal class PersonInsuranceDataCoordinatorRepository : IPersonInsuranceDataCoordinatorRepository
{
    private readonly IDbSet dbSet;

    public PersonInsuranceDataCoordinatorRepository(IDbSet dbSet)
    {
        this.dbSet = dbSet;
    }
    /// <summary>
    /// <see cref="IPersonInsuranceDataCoordinatorRepository.AddAsync(PersonInsuranceDataCoordinator)"/>
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task AddAsync(PersonInsuranceDataCoordinator entity)
    {
        await dbSet.Get<PersonInsuranceDataCoordinator>()!.AddAsync(entity).ConfigureAwait(false);
    }
    /// <summary>
    /// <see cref="IPersonInsuranceDataCoordinatorRepository.FindByIdAsync(Guid)"/>
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    public async Task<PersonInsuranceDataCoordinator?> FindByIdAsync(Guid Id) => await dbSet.Get<PersonInsuranceDataCoordinator>()!.FindAsync(Id).ConfigureAwait(false);


    ///// <summary>
    ///// <see cref="IPersonInsuranceDataCoordinatorRepository.FindByRegisterUIDAsync(Guid)"/>
    ///// </summary>
    ///// <param name="RegisterUID"></param>
    ///// <returns></returns>
    ///// <exception cref="NotImplementedException"></exception>
    //public async Task<List<PersonInsuranceDataCoordinator>> FindByRegisterUIDAsync(Guid RegisterUID)
    //{
    //     return await dbSet.Get<PersonInsuranceDataCoordinator>()!.Where(x => x.RegisterUID == RegisterUID).ToListAsync().ConfigureAwait(false);
    //}

    public async Task UpdateLowerVersionForGsb(int version, Guid RegsiterUID)
    {       
        await dbSet.Get<PersonInsuranceDataCoordinator>()!.Where(x => x.RegisterUID == RegsiterUID && x.Version < version && x.Status < InsuranceDataStatus.SentToGSBServiceIsSucceessful)
            .ExecuteUpdateAsync(x => x
            .SetProperty(e => e.Status, InsuranceDataStatus.SentToGSBServiceIsSucceessful)
            .SetProperty(e => e.GSBRegisterID , $"notsend-v{version}")
            .SetProperty(e=>e.ModifiedDate, DateTime.Now)
            );
    }
}
