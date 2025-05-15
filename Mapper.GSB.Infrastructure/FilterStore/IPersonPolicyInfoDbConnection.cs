namespace Mapper.GSB.Infrastructure.FilterStore;

/// <summary>
/// جهت تزریق اطلاعات پایگاه داده
/// PersonPolicyInfoDb
/// </summary>
public interface IPersonPolicyInfoDbConnection
{
    /// <summary>
    /// اطلاعات پایگاه داده جهت اتصال
    /// </summary>
    string DbConnectionString { get; set; }
}
