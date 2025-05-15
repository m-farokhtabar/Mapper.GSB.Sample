using Mapper.GSB.Domain.Insurance;
using Mapper.GSB.Domain.SeedWorks;
using System.Text.Json;

namespace Mapper.GSB.Infrastructure.Provider.EventProviders;

/// <summary>
/// ایجاد رویداد با استفاده رشته جی سان و بر اساس نام رویداد
/// </summary>
internal class EventFactory
{
    /// <summary>
    /// ایجاد شی رویداد بر اساس نام و داده مورد نظر
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    public static Event? GetEvent(string eventName, string data)
    {
        return eventName switch
        {
            nameof(PersonInsuranceCreatedEvent) => JsonSerializer.Deserialize<PersonInsuranceCreatedEvent>(data),
            nameof(PersonInsuranceGSBResultChangedEvent) => JsonSerializer.Deserialize<PersonInsuranceGSBResultChangedEvent>(data),
            _ => null
        };
    }
}
