using Mapper.GSB.Application.Insurance.Queries.LastPersonInsuranceInfo;
using MediatR;

namespace Mapper.GSB.Application.Insurance.Queries.Status.ByRegisterUID;

/// <summary>
/// خلاصه اطلاعات آخرین وضعیت بیمه نامه
/// </summary>
/// <param name="Id">َشناسه</param>
/// <param name="Issuer">صادر کننده</param>
/// <param name="Assigner">اختصاص دهنده</param>
/// <param name="Type">نوع شناسه</param>
/// <param name="JustLast"></param>
///<remarks>فقط برای بیمه مرکزی باید استفاده شود</remarks>
public record PersonInsuranceInfoByPersonIdQuery(string Id,string Assigner, string Issuer, string Type,bool JustLast = true) : IRequest<List<PersonInsuranceInfoDto>>;
