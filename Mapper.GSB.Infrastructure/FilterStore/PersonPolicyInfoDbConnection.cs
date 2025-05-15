namespace Mapper.GSB.Infrastructure.FilterStore;

/// <summary>
/// جهت تزریق اطلاعات پایگاه داده
/// PersonPolicyInfo
/// </summary>
public class PersonPolicyInfoDbConnection : IPersonPolicyInfoDbConnection
{
    /// <summary>
    /// دریافت کانکشن
    /// </summary>
    /// <param name="dbConnectionString"></param>
    public PersonPolicyInfoDbConnection(string dbConnectionString)
    {
        DbConnectionString = dbConnectionString;
    }

    /// <summary>
    /// اطلاعات پایگاه داده جهت اتصال
    /// </summary>
    public string DbConnectionString { get; set; }
}
