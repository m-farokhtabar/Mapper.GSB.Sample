using Mapper.GSB.Domain.Insurance;
using Mapper.GSB.Infrastructure.EventStore;

namespace Mapper.GSB.Infrastructure.Domain;

/// <summary>
/// <see cref="IPersonInsuranceRepository"/>
/// </summary>
public class PersonInsuranceRepository : IPersonInsuranceRepository
{        
    private readonly IEventStore eventStore;
    /// <summary>
    /// ایجاد شی ریپو و دریافت سرویس های مورد نیاز
    /// </summary>
    /// <param name="eventStore"></param>
    public PersonInsuranceRepository(IEventStore eventStore)
    {            
        this.eventStore = eventStore;
    }

    /// <summary>
    /// <see cref="AddAsync(PersonInsurance)"/>
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task AddAsync(PersonInsurance entity)
    {
        if (entity.Events is not null)
            await eventStore.SaveAsync(entity.Events);
    }
    /// <summary>
    /// <see cref="UpdateAsync(PersonInsurance)"/>
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task UpdateAsync(PersonInsurance entity)
    {
        if (entity.Events is not null)
            await eventStore.SaveAsync(entity.Events);
    }
}
