using Dapper;
using Mapper.GSB.Application.Services.Terminology;
using Mapper.GSB.Infrastructure.Data.Read;

namespace Mapper.GSB.Infrastructure.Provider.Terminology
{
    /// <summary>
    /// <see cref = "ITerminologyProvider" />
    /// </summary>
    public class TerminologyProvider : ITerminologyProvider
    {
        private IReadDbConnection DbConnection { get; }
        /// <summary>
        /// تنظیمات جهت ارتباط با پایگاه داده
        /// </summary>        
        /// <param name="DbConnection"></param>
        public TerminologyProvider(IReadDbConnection DbConnection)
        {
            this.DbConnection = DbConnection;
        }
        /// <summary>
        /// <see cref="ITerminologyProvider.Get(string, string)"/>
        /// </summary>
        /// <param name="CodeSystemUrl">آدرس مجموعه کد سیستم</param>
        /// <param name="CodeSystemVersion">نسخه</param>
        /// <returns></returns>
        public async Task<List<TerminologyDto>> Get(string CodeSystemUrl, string CodeSystemVersion)
        {
            const string Fields = "[TerminologyCode].[Id], [Valueset_URL],[Valueset_Version],[ConceptDefinition_Code],[Language],[Display]";
            const string Join = "LEFT JOIN [TerminologyCodeDetails] ON [TerminologyCode].[Id] = [TerminologyCodeDetails].[TerminologyCodeId]";
            string Where = "[CodeSystem_URL]='" + CodeSystemUrl + "' AND [CodeSystem_Version]='" + CodeSystemVersion + "'";
            string Query = "SELECT " + Fields + " FROM [TerminologyCode] WITH (SNAPSHOT) " + Join + " WHERE " + Where;

            Dictionary<long, TerminologyDto> Result = new();
            using var DbSet = new ReadDbSet(DbConnection.DbConnectionString);
            var Terms = (await DbSet.GetDbEntities().QueryAsync<TerminologyDto, TerminologyCodeDetailsDto, TerminologyDto>(Query,
                (Terminology, CodeDetails) =>
                {
                    if (!Result.TryGetValue(Terminology.Id, out TerminologyDto? CurrentTerminology))
                    {
                        CurrentTerminology = Terminology;
                        Result.Add(Terminology.Id, CurrentTerminology);
                    }
                    if (CodeDetails != null)
                        CurrentTerminology.CodeDetails!.Add(CodeDetails);
                    return CurrentTerminology;
                }, splitOn: "Language").ConfigureAwait(false)).Distinct().ToList();
            return Terms;
        }
    }
}
