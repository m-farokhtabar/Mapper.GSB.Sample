namespace Mapper.GSB.Application.GSBAPICaller.SeedWorks;

/// <summary>
/// نگاشت کد استان ها بیمه تکمیلی به کد استان ها
/// GSB
/// </summary>
public interface IStatesMapping
{
    /// <summary>
    /// کد نگاشت استان ها
    /// </summary>
    Dictionary<int, int>? StatesMap { get; }
}
