using Mapper.GSB.Application.SeedWorks.BI;
using MOHME.Lib.Shared;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace Mapper.GSB.Infrastructure.BIStore;

/// <summary>
/// مدیریت اطلاعات 
/// BI
/// در پایگاه داده
/// </summary>
public class BIStore : IBIStore
{
    private readonly IBIDbConnection connector;

    public BIStore(IBIDbConnection connector)
    {
        this.connector = connector;
    }
    /// <summary>
    /// درج اطلاعات در پایگاه داده
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task Insert(BIModel entity)
    {
        using SqlConnection conn = new(connector.DbConnectionString);
        await conn.OpenAsync().ConfigureAwait(false);
        SqlCommand cmd = new()
        {
            Connection = conn,
            CommandText = @"INSERT INTO [GSB.BI] 
                                    ([DataCoordinatorId], [ReceiveDate], [RegisterUID], [MessageUID], [InsurerCoded_string], 
                                    [PolicyUnqiueCode], [PolicyType], [ProvinceBranchCoded_string], [InsuredType], 
                                    [RelationTypeValue], [RelationTypeCoded_string],[ResponsibleGenderValue], [ResponsibleGenderCoded_string], 
                                    [InsuranceExpirationDate], [InsurerType], [IsCoverageUnlimited], [PersonIdType], 
                                    [BirthDate], [MaritalStatusCoded_string], [NationalityValue], [NationalCode], 
                                    [RegisterIDStatus], [RegisterDate]) 
                                    VALUES 
                                    (@DataCoordinatorId, @ReceiveDate, @RegisterUID, @MessageUID, @InsurerCoded_string, 
                                    @PolicyUnqiueCode, @PolicyType, @ProvinceBranchCoded_string, @InsuredType, 
                                    @RelationTypeValue, @RelationTypeCoded_string, @ResponsibleGenderValue,
                                    @ResponsibleGenderCoded_string, 
                                    @InsuranceExpirationDate, @InsurerType, @IsCoverageUnlimited, @PersonIdType, 
                                    @BirthDate, @MaritalStatusCoded_string, @NationalityValue, @NationalCode, 
                                    @RegisterIDStatus, @RegisterDate)"
        };
        cmd.Parameters.AddWithValue("@DataCoordinatorId", entity.DataCoordinatorId);
        cmd.Parameters.AddWithValue("@ReceiveDate", entity.ReceiveDate);
        cmd.Parameters.AddWithValue("@RegisterUID", entity.RegisterUID);
        cmd.Parameters.AddWithValue("@MessageUID", entity.MessageUID);
        cmd.Parameters.AddWithValue("@InsurerCoded_string", entity.InsurerCoded_string);
        cmd.Parameters.AddWithValue("@PolicyUnqiueCode", entity.PolicyUnqiueCode);
        cmd.Parameters.AddWithValue("@PolicyType", entity.PolicyType);
        cmd.Parameters.AddWithValue("@ProvinceBranchCoded_string", entity.ProvinceBranchCoded_string);
        cmd.Parameters.AddWithValue("@InsuredType", entity.InsuredType);
        cmd.Parameters.AddWithValue("@RelationTypeValue", entity.RelationTypeValue);
        cmd.Parameters.AddWithValue("@RelationTypeCoded_string", entity.RelationTypeCoded_string);
        cmd.Parameters.AddWithValue("@ResponsibleGenderValue", entity.ResponsibleGenderValue);
        cmd.Parameters.AddWithValue("@ResponsibleGenderCoded_string", entity.ResponsibleGenderCoded_string);
        cmd.Parameters.AddWithValue("@InsuranceExpirationDate", entity.InsuranceExpirationDate);
        cmd.Parameters.AddWithValue("@InsurerType", entity.InsurerType);
        cmd.Parameters.AddWithValue("@IsCoverageUnlimited", entity.IsCoverageUnlimited);
        cmd.Parameters.AddWithValue("@PersonIdType", entity.PersonIdType);
        cmd.Parameters.AddWithValue("@BirthDate", entity.BirthDate);
        cmd.Parameters.AddWithValue("@MaritalStatusCoded_string", entity.MaritalStatusCoded_string);
        cmd.Parameters.AddWithValue("@NationalityValue", entity.NationalityValue ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@NationalCode", entity.NationalCode);
        cmd.Parameters.AddWithValue("@RegisterIDStatus", entity.RegisterIDStatus);
        cmd.Parameters.AddWithValue("@RegisterDate", entity.RegisterDate ?? (object)DBNull.Value);

        await cmd.ExecuteNonQueryAsync();

        await UpdateGSBBINumberOFInsurred(entity.PolicyUnqiueCode, entity.InsurerCoded_string, entity.ProvinceBranchCoded_string);
        await UpdateGSBBIBirthDateRange(entity.PolicyUnqiueCode, entity.InsurerCoded_string, entity.ProvinceBranchCoded_string, entity.BirthDate);
    }
    /// <summary>
    /// به روز رسانی اطلاعات
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task Update(BIModel entity)
    {
        using SqlConnection conn = new(connector.DbConnectionString);
        await conn.OpenAsync().ConfigureAwait(false);

        SqlCommand cmd = new()
        {
            Connection = conn,
            CommandText = @"UPDATE [GSB.BI]
                        SET
                            [DataCoordinatorId] = @DataCoordinatorId,
                            [ReceiveDate] = @ReceiveDate,
                            [RegisterUID] = @RegisterUID,
                            [MessageUID] = @MessageUID,
                            [InsurerCoded_string] = @InsurerCoded_string,
                            [PolicyUnqiueCode] = @PolicyUnqiueCode,
                            [PolicyType] = @PolicyType,
                            [ProvinceBranchCoded_string] = @ProvinceBranchCoded_string,
                            [InsuredType] = @InsuredType,
                            [RelationTypeValue] = @RelationTypeValue,
                            [RelationTypeCoded_string] = @RelationTypeCoded_string,
                            [ResponsibleGenderValue] = @ResponsibleGenderValue,
                            [ResponsibleGenderCoded_string] = @ResponsibleGenderCoded_string,
                            [InsuranceExpirationDate] = @InsuranceExpirationDate,
                            [InsurerType] = @InsurerType,
                            [IsCoverageUnlimited] = @IsCoverageUnlimited,
                            [PersonIdType] = @PersonIdType,
                            [BirthDate] = @BirthDate,
                            [MaritalStatusCoded_string] = @MaritalStatusCoded_string,
                            [NationalityValue] = @NationalityValue,
                            [NationalCode] = @NationalCode,
                            [RegisterIDStatus] = @RegisterIDStatus,
                            [RegisterDate] = @RegisterDate
                        WHERE [RegisterUID] = @RegisterUID"
        };
        cmd.Parameters.AddWithValue("@DataCoordinatorId", entity.DataCoordinatorId);
        cmd.Parameters.AddWithValue("@ReceiveDate", entity.ReceiveDate);
        cmd.Parameters.AddWithValue("@RegisterUID", entity.RegisterUID);
        cmd.Parameters.AddWithValue("@MessageUID", entity.MessageUID);
        cmd.Parameters.AddWithValue("@InsurerCoded_string", entity.InsurerCoded_string);
        cmd.Parameters.AddWithValue("@PolicyUnqiueCode", entity.PolicyUnqiueCode);
        cmd.Parameters.AddWithValue("@PolicyType", entity.PolicyType);
        cmd.Parameters.AddWithValue("@ProvinceBranchCoded_string", entity.ProvinceBranchCoded_string);
        cmd.Parameters.AddWithValue("@InsuredType", entity.InsuredType);
        cmd.Parameters.AddWithValue("@RelationTypeValue", entity.RelationTypeValue);
        cmd.Parameters.AddWithValue("@RelationTypeCoded_string", entity.RelationTypeCoded_string);
        cmd.Parameters.AddWithValue("@ResponsibleGenderValue", entity.ResponsibleGenderValue);
        cmd.Parameters.AddWithValue("@ResponsibleGenderCoded_string", entity.ResponsibleGenderCoded_string);
        cmd.Parameters.AddWithValue("@InsuranceExpirationDate", entity.InsuranceExpirationDate);
        cmd.Parameters.AddWithValue("@InsurerType", entity.InsurerType);
        cmd.Parameters.AddWithValue("@IsCoverageUnlimited", entity.IsCoverageUnlimited);
        cmd.Parameters.AddWithValue("@PersonIdType", entity.PersonIdType);
        cmd.Parameters.AddWithValue("@BirthDate", entity.BirthDate);
        cmd.Parameters.AddWithValue("@MaritalStatusCoded_string", entity.MaritalStatusCoded_string);
        cmd.Parameters.AddWithValue("@NationalityValue", entity.NationalityValue ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@NationalCode", entity.NationalCode);
        cmd.Parameters.AddWithValue("@RegisterIDStatus", entity.RegisterIDStatus);
        cmd.Parameters.AddWithValue("@RegisterDate", entity.RegisterDate ?? (object)DBNull.Value);

        int result = await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
        if (result == 0)
            await Insert(entity).ConfigureAwait(false);
        
        //await UpdateGSBBINumberOFInsurred(entity.PolicyUnqiueCode, entity.InsurerCoded_string, entity.ProvinceBranchCoded_string);
    }
    /// <summary>
    /// به روز رسانی وضعیت آمار قسمت مربوط به داده های ارسال شده به
    /// GSB
    /// </summary>
    /// <param name="dataCoordinatorId"></param>
    /// <param name="registerDate"></param>
    /// <returns></returns>
    public async Task UpdateGSB(Guid dataCoordinatorId, DateTime? registerDate)
    {
        using SqlConnection conn = new(connector.DbConnectionString);
        await conn.OpenAsync().ConfigureAwait(false);

        string updateQuery = @"
                UPDATE [dbo].[GSB.BI]
                SET RegisterIDStatus = @RegisterIDStatus,RegisterDate = @RegisterDate WHERE DataCoordinatorId = @DataCoordinatorId";

        SqlCommand cmd = new(updateQuery, conn);
        cmd.Parameters.Add("@DataCoordinatorId", SqlDbType.UniqueIdentifier).Value = dataCoordinatorId;
        cmd.Parameters.Add("@RegisterIDStatus", SqlDbType.TinyInt).Value = registerDate.HasValue ? 1 : 0;
        cmd.Parameters.Add("@RegisterDate", SqlDbType.DateTime2).Value = registerDate ?? (object)DBNull.Value;
        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
    }
    /// <summary>
    /// به روز رسانی یا درج اطلاعات مربوط به آمار بیمه شدگان
    /// </summary>
    /// <returns></returns>
    private async Task UpdateGSBBINumberOFInsurred(string policyUniqueCode, int insurerCodedString, string ProvinceBranchCoded_string)
    {
        using SqlConnection conn = new(connector.DbConnectionString);
        await conn.OpenAsync().ConfigureAwait(false);
        SqlTransaction transaction = conn.BeginTransaction();
        try
        {
            SqlCommand cmd = new();
            cmd.Connection = conn;
            cmd.Transaction = transaction;


            cmd.CommandText = "SELECT [NumberOfRegisterUIDInPolicyUnqiueCode] FROM [dbo].[GSB.BI.NumberOfInsured] WITH (UPDLOCK,ROWLOCK) WHERE [PolicyUnqiueCode] = @PolicyUnqiueCode AND [InsurerCoded_string] = @InsurerCoded_string";
            cmd.Parameters.AddWithValue("@PolicyUnqiueCode", policyUniqueCode);
            cmd.Parameters.AddWithValue("@InsurerCoded_string", insurerCodedString);
            int? count = (int?)cmd.ExecuteScalar();

            if (count.HasValue)
            {
                int classType = GetClassType(count);
                cmd.CommandText = "UPDATE [dbo].[GSB.BI.NumberOfInsured] SET [NumberOfRegisterUIDInPolicyUnqiueCode] = [NumberOfRegisterUIDInPolicyUnqiueCode] + 1, [ClassType] = @ClassType WHERE [PolicyUnqiueCode] = @PolicyUnqiueCode AND [InsurerCoded_string] = @InsurerCoded_string";
                cmd.Parameters.AddWithValue("@ClassType", classType);
                cmd.ExecuteNonQuery();
            }
            else
            {
                cmd.CommandText = "INSERT INTO [dbo].[GSB.BI.NumberOfInsured] ([PolicyUnqiueCode], [InsurerCoded_string], [ProvinceBranchCoded_string], [NumberOfRegisterUIDInPolicyUnqiueCode], [ClassType]) VALUES (@PolicyUnqiueCode, @InsurerCoded_string, @ProvinceBranchCoded_string, 1, 0)";
                cmd.Parameters.AddWithValue("@ProvinceBranchCoded_string", ProvinceBranchCoded_string);
                cmd.ExecuteNonQuery();
            }
            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
    /// <summary>
    /// به روز رسانی یا درج اطلاعات مربوط به رده سنی بیمه شدگان
    /// </summary>
    /// <returns></returns>
    private async Task UpdateGSBBIBirthDateRange(string policyUniqueCode, int insurerCodedString, string ProvinceBranchCoded_string, DateTime birthDate)
    {
        using SqlConnection conn = new(connector.DbConnectionString);
        await conn.OpenAsync().ConfigureAwait(false);
        SqlTransaction transaction = conn.BeginTransaction();
        try
        {
            DateTime CurrentDate = DateTime.Now;
            SqlCommand cmd = new();
            cmd.Connection = conn;
            cmd.Transaction = transaction;
            string classType = GetBirthDateClassType(GetDifferenceInYears(CurrentDate, birthDate));

            cmd.CommandText = $"SELECT {classType} FROM [dbo].[GSB.BI.BirthDateRange] WITH (UPDLOCK,ROWLOCK) WHERE [PolicyUnqiueCode] = @PolicyUnqiueCode AND [InsurerCoded_string] = @InsurerCoded_string";
            cmd.Parameters.AddWithValue("@PolicyUnqiueCode", policyUniqueCode);
            cmd.Parameters.AddWithValue("@InsurerCoded_string", insurerCodedString);
            int? count = (int?)cmd.ExecuteScalar();

            if (count.HasValue)
            {                
                cmd.CommandText = $"UPDATE [dbo].[GSB.BI.BirthDateRange] SET {classType} = {classType} + 1 WHERE [PolicyUnqiueCode] = @PolicyUnqiueCode AND [InsurerCoded_string] = @InsurerCoded_string";                
                cmd.ExecuteNonQuery();
            }
            else
            {
                (int from0To2, int from2To10, int from10To20, int from20To40, int from40To60, int from60To70, int more70) = GetBirthDateInitialClassNumber(GetDifferenceInYears(CurrentDate, birthDate));
                cmd.CommandText = $"INSERT INTO [dbo].[GSB.BI.BirthDateRange] ([PolicyUnqiueCode], [InsurerCoded_string], [ProvinceBranchCoded_string],[From0To2],[From2To10],[From10To20],[From20To40],[From40To60],[From60To70],[More70]) " +
                                  $"VALUES (@PolicyUnqiueCode, @InsurerCoded_string, @ProvinceBranchCoded_string, {from0To2},{from2To10},{from10To20},{from20To40},{from40To60},{from60To70},{more70})";
                cmd.Parameters.AddWithValue("@ProvinceBranchCoded_string", ProvinceBranchCoded_string);
                cmd.ExecuteNonQuery();
            }
            await transaction.CommitAsync();
        }
        catch(Exception Ex)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
    /// <summary>
    /// محاسبه سن
    /// </summary>
    /// <param name="date1"></param>
    /// <param name="date2"></param>
    /// <returns></returns>
    private  int GetDifferenceInYears(DateTime date1, DateTime date2)
    {
        int years = date1.Year - date2.Year;
        if (years != 0)
        {
            // Check if the second date hasn't occurred yet in the current year
            if (date1.Month > date2.Month || (date1.Month == date2.Month && date1.Day > date2.Day))
            {
                years--;
            }
        }

        return years;
    }
    /// <summary>
    /// نوع دسته بندی بر اساس رده سنی بیمه شده
    /// </summary>
    /// <param name="year"></param>
    /// <returns></returns>
    private static (int from0To2, int from2To10, int from10To20, int from20To40, int from40To60, int from60To70,int more70) GetBirthDateInitialClassNumber(int? year)
    {
        int from0To2 = 0;
        int from2To10 = 0;
        int from10To20 = 0;
        int from20To40 = 0;
        int from40To60 = 0;
        int from60To70 = 0;
        int more70 = 0;

        if (year < 2)
            from0To2 = 1;
        else if (year < 10)
            from2To10 = 1;
        else if (year < 20)
            from10To20 = 1;
        else if (year < 40)
            from20To40 = 1;
        else if (year < 60)
            from40To60 = 1;
        else if (year < 70)
            from60To70 = 1;
        else
            more70 = 1;

        return (from0To2, from2To10, from10To20, from20To40, from40To60, from60To70, more70);
    }
    /// <summary>
    /// نوع دسته بندی بر اساس رده سنی بیمه شده
    /// </summary>
    /// <param name="year"></param>
    /// <returns></returns>
    private static string GetBirthDateClassType(int? year)
    {
        if (year < 2)
            return "[From0To2]";
        else if (year < 10)
            return "[From2To10]";
        else if (year < 20)
            return "[From10To20]";
        else if (year < 40)
            return "[From20To40]";
        else if (year < 60)
            return "[From40To60]";
        else if (year < 70)
            return "[From60To70]";
        else
            return "[More70]";        
    }
    /// <summary>
    /// نوع دسته بندی بر اساس تعدادبیمه شده
    /// </summary>
    /// <param name="count"></param>
    /// <returns></returns>
    private static int GetClassType(int? count)
    {
        int classType;
        if (count <= 1000)
            classType = 0;
        else if (count <= 5000)
            classType = 1;
        else if (count <= 10000)
            classType = 2;
        else if (count <= 15000)
            classType = 3;
        else if (count <= 20000)
            classType = 4;
        else
            classType = 5;
        return classType;
    }
}
