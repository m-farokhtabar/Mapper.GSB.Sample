namespace Mapper.GSB.Infrastructure.Data.Read;

/// <summary>
/// جهت تزریق اطلاعات پایگاه داده
/// </summary>
public class ReadDbConnection : IReadDbConnection
{
    /// <summary>
    /// دریافت کانکشن
    /// </summary>
    /// <param name="dbConnectionString"></param>
    public ReadDbConnection(string dbConnectionString)
    {
        DbConnectionString = dbConnectionString;
    }

    /// <summary>
    /// اطلاعات پایگاه داده جهت اتصال
    /// </summary>
    public string DbConnectionString { get; set; }
}
