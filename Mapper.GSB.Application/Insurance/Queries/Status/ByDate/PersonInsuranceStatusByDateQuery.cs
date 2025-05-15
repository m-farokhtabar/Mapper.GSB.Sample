using MediatR;

namespace Mapper.GSB.Application.Insurance.Queries.Status;

/// <summary>
/// وضعیت درخواست ثبت یا ویرایش اطلاعات بیمه شده و بیمه نام
/// از طریق تاریخ
/// </summary>
/// <param name="Year"></param>
/// <param name="Month"></param>
/// <param name="Day"></param>
/// <param name="pageNumber">از 0 شروع می شود</param>
/// <param name="JustErrorStatus"></param>
public record PersonInsuranceStatusByDateQuery(int Year, int Month,int Day, int pageNumber, bool JustErrorStatus = true) : IRequest<PagingDto<List<PersonInsuranceStatusDetailsDto>>>;
