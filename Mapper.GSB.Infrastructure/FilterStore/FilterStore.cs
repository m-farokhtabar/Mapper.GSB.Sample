using Mapper.GSB.Application.Filter;
using Mapper.GSB.Domain.Insurance;
using System.Data.SqlClient;

namespace Mapper.GSB.Infrastructure.FilterStore;

/// <summary>
/// مدیریت اطلاعات 
/// BI
/// در پایگاه داده
/// </summary>
public class FilterStore : IFilterStore
{
    private readonly IFilterDbConnection connector;

    public FilterStore(IFilterDbConnection connector)
    {
        this.connector = connector;
    }
    /// <summary>
    /// درج اطلاعات در پایگاه داده
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task Insert(PersonInsuranceCreatedEvent entity)
    {
        using SqlConnection conn = new(connector.DbConnectionString);
        await conn.OpenAsync().ConfigureAwait(false);
        SqlCommand cmd = new()
        {
            Connection = conn,
            CommandText = @"INSERT INTO GSBFilter 
                                (PersonIDId, PersonIDType, BirthDate, gender, genderValue, nationality, NationalityValue, 
                                province, provinceValue, city, cityValue, mobileNumber, ResponsibleID, ResponsibleIDtype, 
                                ResponsibleGender, RelationType, RelationTypeValue, InsurerCoded_string, PolicyTypeCoded_string, 
                                PolicyUnqiueCode, effectiveDate, InsuranceExpirationDate, companyPolicyId, companyInsuredId, 
                                InsuredType, insurerName, insurerNationalCode, policyIssueDate, ProvinceBranch, cityBranch, 
                                branch, branchCode, IsCoverageUnlimited, registerDateTime, 
                                recordVersion, RegisterUID, MessageUID, snapshotId) 
                                VALUES 
                                (@PersonIDId, @PersonIDType, @BirthDate, @gender, @genderValue, @nationality, @NationalityValue, 
                                @province, @provinceValue, @city, @cityValue, @mobileNumber, @ResponsibleID, @ResponsibleIDtype, 
                                @ResponsibleGender, @RelationType, @RelationTypeValue, @InsurerCoded_string, @PolicyTypeCoded_string, 
                                @PolicyUnqiueCode, @effectiveDate, @InsuranceExpirationDate, @companyPolicyId, @companyInsuredId, 
                                @InsuredType, @insurerName, @insurerNationalCode, @policyIssueDate, @ProvinceBranch, @cityBranch, 
                                @branch, @branchCode, @IsCoverageUnlimited, @registerDateTime, 
                                @recordVersion, @RegisterUID, @MessageUID, @snapshotId)"
        };

        cmd.Parameters.AddWithValue("@PersonIDId", entity.Person.PersonId.ID);
        cmd.Parameters.AddWithValue("@PersonIDType", entity.Person.PersonId.Type);
        cmd.Parameters.AddWithValue("@BirthDate", entity.Person.BirthDate?.ToDateTime());
        cmd.Parameters.AddWithValue("@gender", entity.Person.Gender.Coded_string);
        cmd.Parameters.AddWithValue("@genderValue", entity.Person.Gender.Value);
        cmd.Parameters.AddWithValue("@nationality", entity.Person.Nationality?.Coded_string ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@NationalityValue", entity.Person.Nationality?.Value ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@province", entity.Person.Province?.Coded_string ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@provinceValue", entity.Person.Province?.Value ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@city", entity.Person.City?.Coded_string ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@cityValue", entity.Person.City?.Value ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@mobileNumber", entity.Person.MobileNumber ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@ResponsibleID", entity.PersonPolicy.ResponsibleID?.ID ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@ResponsibleIDtype", entity.PersonPolicy.ResponsibleID?.Type ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@ResponsibleGender", entity.PersonPolicy.ResponsibleGender?.Coded_string ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@RelationType", entity.PersonPolicy.RelationType?.Coded_string ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@RelationTypeValue", entity.PersonPolicy.RelationType?.Value ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@InsurerCoded_string", entity.PersonPolicy.Insurer?.Coded_string ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@PolicyTypeCoded_string", entity.PersonPolicy.PolicyType?.Coded_string ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@PolicyUnqiueCode", entity.PersonPolicy.PolicyUniqueCode ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@effectiveDate", entity.PersonPolicy.EffectiveDate?.ToDateTime() ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@InsuranceExpirationDate", entity.PersonPolicy.InsuranceExpirationDate?.ToDateTime() ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@companyPolicyId", entity.PersonPolicy.CompanyPolicyId ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@companyInsuredId", entity.PersonPolicy.CompanyInsuredId ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@InsuredType", entity.PersonPolicy.InsuredType);
        cmd.Parameters.AddWithValue("@insurerName", entity.PersonPolicy.InsurerName ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@insurerNationalCode", entity.PersonPolicy.insurerNationalCode ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@policyIssueDate", entity.PersonPolicy.PolicyIssueDate?.ToDateTime() ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@ProvinceBranch", entity.PersonPolicy.ProvinceBranch?.Coded_string ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@cityBranch", entity.PersonPolicy.CityBranch?.Coded_string ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@branch", entity.PersonPolicy.Branch.Value ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@branchCode", entity.PersonPolicy.Branch?.Coded_string ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@IsCoverageUnlimited", entity.PersonPolicy.IsCoverageUnlimited);
        //cmd.Parameters.AddWithValue("@GSBRegisterID", entity.MsgId.GSBDataVO.RegisterID);
        //cmd.Parameters.AddWithValue("@RegisterDate", entity.GSBDataVO.RegisterDate ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@registerDateTime", entity.CreateDate);
        cmd.Parameters.AddWithValue("@recordVersion", entity.MsgId.Version);
        cmd.Parameters.AddWithValue("@RegisterUID", entity.MsgId.RegisterUID);
        cmd.Parameters.AddWithValue("@MessageUID", entity.MsgId.MessageUID);
        cmd.Parameters.AddWithValue("@snapshotId", entity.AggregateRootId);
        //cmd.Parameters.AddWithValue("@openEHRPartyId", entity.);
        //cmd.Parameters.AddWithValue("@openEHRDocId", entity.openEHRDocId);

        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
    }
    /// <summary>
    /// به روز وضعیت درخواست GSB server
    /// </summary>
    /// <param name="snapshotId"></param>
    /// <param name="GSBRegisterID"></param>
    /// <param name="RegisterDate"></param>
    /// <returns></returns>
    public async Task UpdateGSB(Guid snapshotId, string? GSBRegisterID, DateTime? RegisterDate)
    {
        using SqlConnection conn = new(connector.DbConnectionString);
        await conn.OpenAsync().ConfigureAwait(false);
        SqlCommand cmd = new()
        {
            Connection = conn,
            CommandText = @"UPDATE GSBFilter
                                SET GSBRegisterID = @GSBRegisterID,
                                    RegisterDate = @RegisterDate
                                WHERE snapshotId = @snapshotId"
        };

        cmd.Parameters.AddWithValue("@GSBRegisterID", GSBRegisterID ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@RegisterDate", RegisterDate ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@snapshotId", snapshotId);

        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="snapshotId"></param>
    /// <param name="openEHRPartyId"></param>
    /// <returns></returns>
    public async Task UpdateopenEHRPartyId(Guid snapshotId, string openEHRPartyId)
    {
        using SqlConnection conn = new(connector.DbConnectionString);
        await conn.OpenAsync().ConfigureAwait(false);
        SqlCommand cmd = new()
        {
            Connection = conn,
            CommandText = @"UPDATE GSBFilter SET openEHRPartyId = @openEHRPartyId  WHERE snapshotId = @snapshotId"
        };

        cmd.Parameters.AddWithValue("@openEHRPartyId", openEHRPartyId);        
        cmd.Parameters.AddWithValue("@snapshotId", snapshotId);

        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="snapshotId"></param>
    /// <param name="openEHRDocId"></param>
    /// <returns></returns>
    public async Task UpdateopenEHRDocId(Guid snapshotId, string openEHRDocId)
    {
        using SqlConnection conn = new(connector.DbConnectionString);
        await conn.OpenAsync().ConfigureAwait(false);
        SqlCommand cmd = new()
        {
            Connection = conn,
            CommandText = @"UPDATE GSBFilter SET openEHRDocId = @openEHRDocId WHERE snapshotId = @snapshotId"
        };
        
        cmd.Parameters.AddWithValue("@openEHRDocId", openEHRDocId);
        cmd.Parameters.AddWithValue("@snapshotId", snapshotId);

        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);

    }
}
