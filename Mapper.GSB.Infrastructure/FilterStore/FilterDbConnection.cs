namespace Mapper.GSB.Infrastructure.FilterStore;

/// <summary>
/// جهت تزریق اطلاعات پایگاه داده
/// Filter
/// </summary>
public class FilterDbConnection : IFilterDbConnection
{
    /// <summary>
    /// دریافت کانکشن
    /// </summary>
    /// <param name="dbConnectionString"></param>
    public FilterDbConnection(string dbConnectionString)
    {
        DbConnectionString = dbConnectionString;
    }

    /// <summary>
    /// اطلاعات پایگاه داده جهت اتصال
    /// </summary>
    public string DbConnectionString { get; set; }
}
