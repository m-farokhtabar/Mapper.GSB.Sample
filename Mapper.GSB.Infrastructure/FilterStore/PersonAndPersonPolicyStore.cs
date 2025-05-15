using Mapper.GSB.Application.FilterStore;
using Mapper.GSB.Domain.Insurance;
using System.Data.SqlClient;

namespace Mapper.GSB.Infrastructure.FilterStore
{
    public class PersonAndPersonPolicyStore : IPersonAndPersonPolicyStore
    {
        private readonly IPersonPolicyInfoDbConnection connector;

        public PersonAndPersonPolicyStore(IPersonPolicyInfoDbConnection connector)
        {
            this.connector = connector;
        }

        public async Task InsertPersonInfo(PersonInsuranceCreatedEvent entity)
        {
            using SqlConnection conn = new(connector.DbConnectionString);
            await conn.OpenAsync().ConfigureAwait(false);
            SqlCommand cmd = new()
            {
                Connection = conn,
                CommandText = @"INSERT INTO PersonInfo 
                            (PersonIDId, PersonIDType, BirthDate, FirstName, LastName, FullName, father_FirstName, 
                            iDCardNumber, pictureB64, gender, genderValue, nationality, NationalityValue, 
                            MaritalStatusCoded_string, provinceValue, province, city, postalCode, fullAddress, 
                            mobileNumber, homeTel, ResponsibleID, ResponsibleIDtype, ResponsibleFirstName, 
                            ResponsibleLastName, ResponsibleGenderCoded_string, ResponsibleGenderValue, 
                            RelationTypeCoded_string, RelationTypeValue, shebaNo, bankAcc, accNo, InsurerCoded_string, 
                            PolicyUnqiueCode, InsuranceExpirationDate, companyInsuredId, recordVersion, 
                            registerDateTime,  snapshotId, MessageUID, 
                            RegisterUID)
                            VALUES 
                            (@PersonIDId, @PersonIDType, @BirthDate, @FirstName, @LastName, @FullName, @father_FirstName, 
                            @iDCardNumber, @pictureB64, @gender, @genderValue, @nationality, @NationalityValue, 
                            @MaritalStatusCoded_string, @provinceValue, @province, @city, @postalCode, @fullAddress, 
                            @mobileNumber, @homeTel, @ResponsibleID, @ResponsibleIDtype, @ResponsibleFirstName, 
                            @ResponsibleLastName, @ResponsibleGenderCoded_string, @ResponsibleGenderValue, 
                            @RelationTypeCoded_string, @RelationTypeValue, @shebaNo, @bankAcc, @accNo, 
                            @InsurerCoded_string, @PolicyUnqiueCode, @InsuranceExpirationDate, @companyInsuredId, 
                            @recordVersion, @registerDateTime,
                            @snapshotId, @MessageUID, @RegisterUID)"
            };

            cmd.Parameters.AddWithValue("@PersonIDId", entity.Person.PersonId.ID);
            cmd.Parameters.AddWithValue("@PersonIDType", entity.Person.PersonId.Type);
            cmd.Parameters.AddWithValue("@BirthDate", entity.Person.BirthDate.ToDateTime());
            cmd.Parameters.AddWithValue("@FirstName", entity.Person.FirstName ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@LastName", entity.Person.LastName ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@FullName", entity.Person.FullName ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@father_FirstName", entity.Person.Father_FirstName ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@iDCardNumber", entity.Person.IDCardNumber ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@pictureB64", entity.Person.PictureB64 ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@gender", entity.Person.Gender?.Coded_string ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@genderValue", entity.Person.Gender?.Value ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@nationality", entity.Person.Nationality?.Coded_string ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@NationalityValue", entity.Person.Nationality?.Value ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@MaritalStatusCoded_string", entity.Person.MaritalStatus?.Coded_string ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@provinceValue", entity.Person.Province?.Value ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@province", entity.Person.Province?.Coded_string ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@city", entity.Person.City?.Coded_string ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@postalCode", entity.Person.PostalCode ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@fullAddress", entity.Person.FullAddress ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@mobileNumber", entity.Person.MobileNumber ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@homeTel", entity.Person.HomeTel ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@ResponsibleID", entity.PersonPolicy.ResponsibleID?.ID ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@ResponsibleIDtype", entity.PersonPolicy.ResponsibleID?.Type ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@ResponsibleFirstName", entity.PersonPolicy.ResponsibleFirstName ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@ResponsibleLastName", entity.PersonPolicy.ResponsibleLastName ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@ResponsibleGenderCoded_string", entity.PersonPolicy.ResponsibleGender?.Coded_string ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@ResponsibleGenderValue", entity.PersonPolicy.ResponsibleGender?.Value ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@RelationTypeCoded_string", entity.PersonPolicy.RelationType?.Coded_string ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@RelationTypeValue", entity.PersonPolicy.RelationType?.Value ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@shebaNo", entity.PersonPolicy.ShebaNo ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@bankAcc", entity.PersonPolicy.BankAcc?.Coded_string ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@accNo", entity.PersonPolicy.AccNo ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@InsurerCoded_string", entity.PersonPolicy.Insurer?.Coded_string ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@PolicyUnqiueCode", entity.PersonPolicy.PolicyUniqueCode ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@InsuranceExpirationDate", entity.PersonPolicy.InsuranceExpirationDate?.ToDateTime() ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@companyInsuredId", entity.PersonPolicy.CompanyInsuredId ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@recordVersion", entity.MsgId.Version);
            cmd.Parameters.AddWithValue("@snapshotId", entity.AggregateRootId);
            cmd.Parameters.AddWithValue("@MessageUID", entity.MsgId.MessageUID);
            cmd.Parameters.AddWithValue("@RegisterUID", entity.MsgId.RegisterUID);
            cmd.Parameters.AddWithValue("@registerDateTime", entity.CreateDate);


            //cmd.Parameters.AddWithValue("@RegisterDate", entity.MsgId.GSBDataVO.RegisterID ?? (object)DBNull.Value);


            //cmd.Parameters.AddWithValue("@openEHRDocId", entity.PersonPolicy.openEHRDocId ?? (object)DBNull.Value);
            //cmd.Parameters.AddWithValue("@openEHRPartyId", entity.PersonPolicy.openEHRPartyId ?? (object)DBNull.Value);

            await cmd.ExecuteNonQueryAsync();
        }
        /// <summary>
        /// به روز وضعیت درخواست GSB server
        /// </summary>
        /// <param name="snapshotId"></param>
        /// <param name="GSBRegisterID"></param>
        /// <param name="RegisterDate"></param>
        /// <returns></returns>
        public async Task UpdateGSBPersonInfo(Guid snapshotId, DateTime? RegisterDate)
        {
            using SqlConnection conn = new(connector.DbConnectionString);
            await conn.OpenAsync().ConfigureAwait(false);
            SqlCommand cmd = new()
            {
                Connection = conn,
                CommandText = @"UPDATE PersonInfo
                                SET RegisterDate = @RegisterDate
                                WHERE snapshotId = @snapshotId"
            };

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
        public async Task UpdateopenEHRPartyIdPersonInfo(Guid snapshotId, string openEHRPartyId)
        {
            using SqlConnection conn = new(connector.DbConnectionString);
            await conn.OpenAsync().ConfigureAwait(false);
            SqlCommand cmd = new()
            {
                Connection = conn,
                CommandText = @"UPDATE PersonInfo SET openEHRPartyId = @openEHRPartyId WHERE snapshotId = @snapshotId"
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
        public async Task UpdateopenEHRDocIdPersonInfo(Guid snapshotId, string openEHRDocId)
        {
            using SqlConnection conn = new(connector.DbConnectionString);
            await conn.OpenAsync().ConfigureAwait(false);
            SqlCommand cmd = new()
            {
                Connection = conn,
                CommandText = @"UPDATE PersonInfo SET openEHRDocId = @openEHRDocId WHERE snapshotId = @snapshotId"
            };            
            cmd.Parameters.AddWithValue("@openEHRDocId", openEHRDocId);
            cmd.Parameters.AddWithValue("@snapshotId", snapshotId);
            await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// درج اطلاعات PersonPolicy در پایگاه داده
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task InsertPersonPolicy(PersonInsuranceCreatedEvent entity)
        {
            using SqlConnection conn = new(connector.DbConnectionString);
            await conn.OpenAsync().ConfigureAwait(false);
            SqlCommand cmd = new()
            {
                Connection = conn,
                CommandText = @"INSERT INTO PersonPolicy 
                                (InsurerCoded_string, PolicyTypeCoded_string, PolicyUnqiueCode, effectiveDate, InsuranceExpirationDate, 
                                insuranceBox, policyPrintNumber, companyPolicyId, companyInsuredId, InsuredType, ResponsibleID, 
                                RelationTypeValue, RelationTypeCoded_string, insurerName, insurerNationalCode, policyIssueDate, 
                                BaseInsurer, ProvinceBranch, cityBranch, branch, branchCode, recommendationMessage, planIdValue, 
                                planId, requestReason, IsCoverageUnlimited, policyVerNo, policyVerUniqueCode, contractType, 
                                workShopName, workShop, franchise, accountID, accountType, activeFrom, activeTo, accountStatus, 
                                RegisterUID, MessageUID, registerDateTime, localId, recordVersion, operation,
                                snapshotId) 
                                VALUES 
                                (@InsurerCoded_string, @PolicyTypeCoded_string, @PolicyUnqiueCode, @effectiveDate, @InsuranceExpirationDate, 
                                @insuranceBox, @policyPrintNumber, @companyPolicyId, @companyInsuredId, @InsuredType, @ResponsibleID, 
                                @RelationTypeValue, @RelationTypeCoded_string, @insurerName, @insurerNationalCode, @policyIssueDate, 
                                @BaseInsurer, @ProvinceBranch, @cityBranch, @branch, @branchCode, @recommendationMessage, @planIdValue, 
                                @planId, @requestReason, @IsCoverageUnlimited, @policyVerNo, @policyVerUniqueCode, @contractType, 
                                @workShopName, @workShop, @franchise, @accountID, @accountType, @activeFrom, @activeTo, @accountStatus, 
                                @RegisterUID, @MessageUID, @registerDateTime, @localId, @recordVersion, @operation,
                                @snapshotId)"
            };

            cmd.Parameters.AddWithValue("@InsurerCoded_string", entity.PersonPolicy.Insurer?.Coded_string ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@PolicyTypeCoded_string", entity.PersonPolicy.PolicyType?.Coded_string ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@PolicyUnqiueCode", entity.PersonPolicy.PolicyUniqueCode ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@effectiveDate", entity.PersonPolicy.EffectiveDate?.ToDateTime() ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@InsuranceExpirationDate", entity.PersonPolicy.InsuranceExpirationDate?.ToDateTime() ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@insuranceBox", entity.PersonPolicy.InsuranceBox?.Coded_string ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@policyPrintNumber", entity.PersonPolicy.PolicyPrintNumber ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@companyPolicyId", entity.PersonPolicy.CompanyPolicyId ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@companyInsuredId", entity.PersonPolicy.CompanyInsuredId ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@InsuredType", entity.PersonPolicy.InsuredType);
            cmd.Parameters.AddWithValue("@ResponsibleID", entity.PersonPolicy.ResponsibleID?.ID ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@RelationTypeValue", entity.PersonPolicy.RelationType?.Value ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@RelationTypeCoded_string", entity.PersonPolicy.RelationType?.Coded_string ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@insurerName", entity.PersonPolicy.InsurerName ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@insurerNationalCode", entity.PersonPolicy.insurerNationalCode ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@policyIssueDate", entity.PersonPolicy.PolicyIssueDate?.ToDateTime() ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@BaseInsurer", entity.PersonPolicy.BaseInsurer?.Coded_string ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@ProvinceBranch", entity.PersonPolicy.ProvinceBranch?.Coded_string ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@cityBranch", entity.PersonPolicy.CityBranch?.Coded_string ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@branch", entity.PersonPolicy.Branch?.Value ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@branchCode", entity.PersonPolicy.Branch?.Coded_string ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@recommendationMessage", entity.PersonPolicy.RecommendationMessage ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@planIdValue", entity.PersonPolicy.PlanId?.Value ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@planId", entity.PersonPolicy.PlanId?.Coded_string ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@requestReason", entity.PersonPolicy.RequestReason?.Coded_string ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@IsCoverageUnlimited", entity.PersonPolicy.IsCoverageUnlimited);
            cmd.Parameters.AddWithValue("@policyVerNo", entity.PersonPolicy.PolicyVerNo ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@policyVerUniqueCode", entity.PersonPolicy.PolicyVerUniqueCode ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@contractType", entity.PersonPolicy.ContractType?.Coded_string ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@workShopName", entity.PersonPolicy.WorkShop?.Value ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@workShop", entity.PersonPolicy.WorkShop?.Coded_string ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@franchise", entity.PersonPolicy.Feranshiz ?? (object)DBNull.Value);

            if (entity.PersonPolicy.Account?.Count > 0)
            {
                cmd.Parameters.AddWithValue("@accountID", entity.PersonPolicy.Account[0].AccountID ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@accountType", entity.PersonPolicy.Account[0].AccountType?.Coded_string ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@activeFrom", entity.PersonPolicy.Account[0].ActiveFrom?.ToDateTime() ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@activeTo", entity.PersonPolicy.Account[0].ActiveTo?.ToDateTime() ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@accountStatus", entity.PersonPolicy.Account[0].AccountStatus?.Coded_string ?? (object)DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@accountID", (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@accountType", (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@activeFrom", (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@activeTo", (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@accountStatus", (object)DBNull.Value);
            }

            cmd.Parameters.AddWithValue("@RegisterUID", entity.MsgId.RegisterUID);
            cmd.Parameters.AddWithValue("@MessageUID", entity.MsgId.MessageUID);
            cmd.Parameters.AddWithValue("@registerDateTime", entity.CreateDate);

            cmd.Parameters.AddWithValue("@localId", entity.MsgId.LocalId ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@recordVersion", entity.MsgId.Version);
            cmd.Parameters.AddWithValue("@operation", entity.MsgId.Version == 1 ? 1 : 2);
            cmd.Parameters.AddWithValue("@snapshotId", entity.AggregateRootId);

            //cmd.Parameters.AddWithValue("@GSBIgin", entity.PersonPolicy.GSBDataVO.Igin.id);
            //cmd.Parameters.AddWithValue("@GSBRegisterID", entity.PersonPolicy.GSBDataVO.RegisterID);
            //cmd.Parameters.AddWithValue("@RegisterDate", entity.PersonPolicy.GSBDataVO.RegisterDate);            
            //cmd.Parameters.AddWithValue("@errorMessage", entity.PersonPolicy.MessageIdentifierVO.errorMessage);


            await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
        }
        /// <summary>
        /// به روز رسانی فیلدهای GSBIgin، GSBRegisterID، RegisterDate، و errorMessage بر اساس snapshotId
        /// </summary>
        /// <param name="snapshotId"></param>
        /// <param name="GSBIgin"></param>
        /// <param name="GSBRegisterID"></param>
        /// <param name="RegisterDate"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public async Task UpdateGSBPersonPolicyFields(Guid snapshotId, string? GSBIgin, string? GSBRegisterID, DateTime? RegisterDate, string? errorMessage)
        {
            using SqlConnection conn = new(connector.DbConnectionString);
            await conn.OpenAsync().ConfigureAwait(false);
            SqlCommand cmd = new()
            {
                Connection = conn,
                CommandText = @"UPDATE PersonPolicy
                                SET GSBIgin = @GSBIgin,
                                    GSBRegisterID = @GSBRegisterID,
                                    RegisterDate = @RegisterDate,
                                    errorMessage = @errorMessage
                                WHERE snapshotId = @snapshotId"
            };

            cmd.Parameters.AddWithValue("@GSBIgin", GSBIgin ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@GSBRegisterID", GSBRegisterID ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@RegisterDate", RegisterDate ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@errorMessage", errorMessage ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@snapshotId", snapshotId);

            await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
        }
    }

}
