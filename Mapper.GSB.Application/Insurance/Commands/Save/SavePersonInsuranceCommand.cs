using MediatR;
using MOHME.Lib.Shared;

namespace Mapper.GSB.Application.Insurance.Commands.Save;
/// <summary>
/// ثبت اطلاعات فردی و بیمه نامه
/// </summary>
/// <param name="MsgId"></param>
/// <param name="Person"></param>
/// <param name="PersonPolicy"></param>
/// <param name="ServiceDateTime"></param>
/// <param name="MessageUID"></param>
public record SavePersonInsuranceCommand(MessageIdentifierVODto? MsgId, PersonInfoVODto? Person, PersonPolicyVODto? PersonPolicy, DO_DATE_TIME? ServiceDateTime, Guid MessageUID): IRequest<DataVO>;