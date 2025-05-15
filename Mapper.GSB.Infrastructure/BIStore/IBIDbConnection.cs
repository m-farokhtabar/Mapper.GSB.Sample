namespace Mapper.GSB.Infrastructure.BIStore;

/// <summary>
/// جهت تزریق اطلاعات پایگاه داده
/// BI
/// </summary>
public interface IBIDbConnection
{
    /// <summary>
    /// اطلاعات پایگاه داده جهت اتصال
    /// </summary>
    string DbConnectionString { get; set; }
}
