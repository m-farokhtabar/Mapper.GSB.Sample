namespace Mapper.GSB.Infrastructure.Data.Read
{
    /// <summary>
    /// جهت تزریق اطلاعات پایگاه داده
    /// </summary>
    public interface IReadDbConnection
    {
        /// <summary>
        /// اطلاعات پایگاه داده جهت اتصال
        /// </summary>
        string DbConnectionString { get; set; }
    }
}
