using MediatR;

namespace Mapper.GSB.Application.Insurance.Queries.Status.ByRegisterUID;

/// <summary>
/// وضعیت درخواست ثبت یا ویرایش اطلاعات بیمه شده و بیمه نام
/// </summary>
public record PersonInsuranceStatusByRegisterUIDQuery(Guid RegisterUID) : IRequest<PersonInsuranceStatusDto>;
