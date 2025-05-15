namespace Mapper.GSB.Infrastructure.BIStore;

/// <summary>
/// جهت تزریق اطلاعات پایگاه داده
/// BI
/// </summary>
public class BIDbConnection : IBIDbConnection
{
    /// <summary>
    /// دریافت کانکشن
    /// </summary>
    /// <param name="dbConnectionString"></param>
    public BIDbConnection(string dbConnectionString)
    {
        DbConnectionString = dbConnectionString;
    }

    /// <summary>
    /// اطلاعات پایگاه داده جهت اتصال
    /// </summary>
    public string DbConnectionString { get; set; }
}
