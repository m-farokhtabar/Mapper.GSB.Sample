namespace Mapper.GSB.Infrastructure.FilterStore;

/// <summary>
/// جهت تزریق اطلاعات پایگاه داده
/// Filter
/// </summary>
public interface IFilterDbConnection
{
    /// <summary>
    /// اطلاعات پایگاه داده جهت اتصال
    /// </summary>
    string DbConnectionString { get; set; }
}
