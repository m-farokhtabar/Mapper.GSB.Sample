using Microsoft.Data.SqlClient;
using System.Data;

namespace Mapper.GSB.Infrastructure.Data.Read;

/// <summary>
/// دریافت اطلاعات مورد نیاز
/// Mapper
/// از پایگاه داده
/// </summary>
public class ReadDbSet : IDisposable
{
    private IDbConnection? Connection = null;
    private readonly string ConnectionString;
    /// <summary>
    /// دریافت اطلاعات آدرس پایگاه داده
    /// </summary>
    /// <param name="connectionString"></param>
    public ReadDbSet(string connectionString)
    {
        ConnectionString = connectionString;
    }
    /// <summary>
    /// دریافت رابط جهت استفاده برای درخواست
    /// </summary>
    /// <returns></returns>
    public IDbConnection GetDbEntities()
    {
        if (Connection is null || Connection.State != ConnectionState.Open)
        {
            Connection = new SqlConnection(ConnectionString);
            Connection.Open();
        }
        return Connection;
    }
    /// <summary>
    /// قطع ارتباط و آزاد سازی منابع
    /// </summary>
    public void Dispose()
    {
        if (Connection is not null)
        {
            if (Connection.State == ConnectionState.Open)
                Connection.Close();
            Connection.Dispose();
        }
    }
}
