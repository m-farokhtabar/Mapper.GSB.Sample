using MassTransit;
using openEHR.DDR.Command.Party.Create;
using openEHR.DDR.Command.Party.Update;
using openEHR.DDR.Command.PartyRelationship.Create;
using openEHR.DDR.Command.PartyRelationship.Update;
using openEHR.DDR.Command.SeedWork;
using openEHR.DDR.Exceptions.ErrorResult;
using openEHR.Library.Base.BaseTypes.Identification;
using openEHR.Library.Base.FoundationTypes.Terminology;
using openEHR.Library.Sm.Platform.Common;
using System.Text.Json;

namespace Mapper.GSB.Infrastructure.DDR;

using global::openEHR.DDR.Query.Party.Details;
using global::openEHR.DDR.Query.PartyRelationship.Details;
using global::openEHR.Helper.JsonConvertor.Rm;
using global::openEHR.Library.Rm.Demographic;
using Mapper.GSB.Application.DDRAPICaller.Services.DDR;
using Mapper.GSB.Share.Resource;
using Services.ExceptionManager;
using Services.ExceptionManager.Resources;



/// <summary>
/// <see cref="IDDRRepository"/>
/// </summary>
public class DDRRepository : IDDRRepository
{
    private readonly IDDRRepositorySettings repositorySettings;

    private readonly IRequestClient<CreatePartyCommand> CreatePartyRequest;
    private readonly IRequestClient<CreatePartyRelationshipCommand> CreatePartyRelationshipRequest;
    private readonly IRequestClient<UpdatePartyCommand> UpdatePartyRequest;
    private readonly IRequestClient<UpdatePartyRelationshipCommand> UpdatePartyRelationshipRequest;
    private readonly IRequestClient<PartyDetailsQuery> PartyDetailsRequest;
    private readonly IRequestClient<PartyRelationshipDetailsQuery> PartyRelationshipDetailsRequest;
    private readonly JsonSerializerOptions Option = new() { Converters = { { new RmJsonConverterFactory() } } };

    /// <summary>
    /// سرویس درخواست های مورد نیاز جهت ارسال داده ها به ریپو
    /// </summary>
    /// <param name="repositorySettings"></param>
    /// <param name="CreatePartyRequest"></param>
    /// <param name="CreatePartyRelationshipRequest"></param>
    /// <param name="UpdatePartyRequest"></param>
    /// <param name="UpdatePartyRelationshipRequest"></param>
    /// <param name="PartyDetailsRequest"></param>
    /// <param name="PartyRelationshipDetailsRequest"></param>
    public DDRRepository(IDDRRepositorySettings repositorySettings,
                             IRequestClient<CreatePartyCommand> CreatePartyRequest,
                             IRequestClient<CreatePartyRelationshipCommand> CreatePartyRelationshipRequest,
                             IRequestClient<UpdatePartyCommand> UpdatePartyRequest,
                             IRequestClient<UpdatePartyRelationshipCommand> UpdatePartyRelationshipRequest,
                             IRequestClient<PartyDetailsQuery> PartyDetailsRequest,
                             IRequestClient<PartyRelationshipDetailsQuery> PartyRelationshipDetailsRequest)
    {
        this.repositorySettings = repositorySettings;
        this.CreatePartyRequest = CreatePartyRequest;
        this.CreatePartyRelationshipRequest = CreatePartyRelationshipRequest;
        this.UpdatePartyRequest = UpdatePartyRequest;
        this.UpdatePartyRelationshipRequest = UpdatePartyRelationshipRequest;
        this.PartyDetailsRequest = PartyDetailsRequest;
        this.PartyRelationshipDetailsRequest = PartyRelationshipDetailsRequest;
    }
    /// <summary>
    /// <see cref="IDDRRepository.GetParty(string)"/>
    /// </summary>
    /// <param name="VersionUid"></param>
    /// <returns></returns>
    public async Task<Party?> GetParty(string VersionUid)
    {
        try
        {
            var PartyDetailsRequestInstance = PartyDetailsRequest.Create(new PartyDetailsQuery(VersionUid));
            var Response = await PartyDetailsRequestInstance.GetResponse<PartyDetailsQuery, PartyDetails, DDRErrorRespond>(x => x.Headers.Set(PartyDetailsQuery.ACCEPT_HEADER, FormatTypes.FORMAT_TYPE_JSON));
            if (Response.Is(out Response<PartyDetails>? Result))
            {
                if (Result is not null)
                    return JsonSerializer.Deserialize<Party>(Result.Message.Party, Option);
                else
                    throw new ManualException(ExceptionsMessages.RESPONSE_FROM_RESOURCE_IS_NOT_VALID.Replace("{0}", Names.REPOSITORY), ExceptionType.InternalServerError, nameof(Names.REPOSITORY));
            }
            else
            {
                Response.Is(out Response<DDRErrorRespond>? ErrorResult);
                if (ErrorResult is not null)
                    throw DDRRespondToManalException(ErrorResult);
                else
                    throw new ManualException(ExceptionsMessages.RESPONSE_FROM_RESOURCE_IS_NOT_VALID.Replace("{0}", Names.REPOSITORY), ExceptionType.InternalServerError, nameof(Names.REPOSITORY));
            }
        }
        catch (ManualException)
        {
            throw;
        }
        catch (RequestTimeoutException Ex)
        {
            throw new ManualException(ExceptionsMessages.REQUEST_TIME_OUT_FROM_RESOURCE.Replace("{0}", Names.REPOSITORY), ExceptionType.TimeOut, nameof(Names.REPOSITORY), Ex);
        }
        catch (global::openEHR.Helper.CustomException.openEHRException)
        {
            throw;
        }
        catch (Exception Ex)
        {
            throw new ManualException(ExceptionsMessages.Cannot_connect_to_resource.Replace("{0}", Names.REPOSITORY), ExceptionType.TimeOut, nameof(Names.REPOSITORY), Ex);
        }
    }
    /// <summary>
    /// <see cref="IDDRRepository.GetPartyRelationship(string)"/>
    /// </summary>
    /// <param name="VersionUid"></param>
    /// <returns></returns>
    public async Task<PartyRelationship?> GetPartyRelationship(string VersionUid)
    {
        try
        {
            var PartyRelationshipDetailsRequestInstance = PartyRelationshipDetailsRequest.Create(new PartyRelationshipDetailsQuery(VersionUid));
            var Response = await PartyRelationshipDetailsRequestInstance.GetResponse<PartyRelationshipDetailsQuery, PartyRelationshipDetails, DDRErrorRespond>(x => x.Headers.Set(PartyRelationshipDetailsQuery.ACCEPT_HEADER, FormatTypes.FORMAT_TYPE_JSON));
            if (Response.Is(out Response<PartyRelationshipDetails>? Result))
            {
                if (Result is not null)
                    return JsonSerializer.Deserialize<PartyRelationship>(Result.Message.PartyRelationship, Option);
                else
                    throw new ManualException(ExceptionsMessages.RESPONSE_FROM_RESOURCE_IS_NOT_VALID.Replace("{0}", Names.REPOSITORY), ExceptionType.InternalServerError, nameof(Names.REPOSITORY));
            }
            else
            {
                Response.Is(out Response<DDRErrorRespond>? ErrorResult);
                if (ErrorResult is not null)
                    throw DDRRespondToManalException(ErrorResult);
                else
                    throw new ManualException(ExceptionsMessages.RESPONSE_FROM_RESOURCE_IS_NOT_VALID.Replace("{0}", Names.REPOSITORY), ExceptionType.InternalServerError, nameof(Names.REPOSITORY));
            }
        }
        catch (ManualException)
        {
            throw;
        }
        catch (RequestTimeoutException Ex)
        {
            throw new ManualException(ExceptionsMessages.REQUEST_TIME_OUT_FROM_RESOURCE.Replace("{0}", Names.REPOSITORY), ExceptionType.TimeOut, nameof(Names.REPOSITORY), Ex);
        }
        catch (global::openEHR.Helper.CustomException.openEHRException)
        {
            throw;
        }
        catch (Exception Ex)
        {
            throw new ManualException(ExceptionsMessages.Cannot_connect_to_resource.Replace("{0}", Names.REPOSITORY), ExceptionType.TimeOut, nameof(Names.REPOSITORY), Ex);
        }
    }

    /// <summary>
    /// <see cref="IDDRRepository.CreateParty(global::openEHR.DDR.Command.Party.Base.Party, UpdateAudit, TerminologyCode)"/>
    /// </summary>
    /// <param name="Party"></param>
    /// <param name="UpdateAudit"></param>
    /// <param name="VersionLifecycleState"></param>
    /// <returns></returns>
    public async Task<ObjectVersionId> CreateParty(global::openEHR.DDR.Command.Party.Base.Party Party, UpdateAudit UpdateAudit, TerminologyCode VersionLifecycleState)
    {
        try
        {
            var PartyRequestInstance = CreatePartyRequest.Create(new(VersionLifecycleState, null, Party, UpdateAudit));
            var Response = await PartyRequestInstance.GetResponse<CreatePartyCommand, PartyCreated, DDRErrorRespond>(x =>
            {
                x.Headers.Set(CreatePartyCommand.ACCEPT_HEADER, FormatTypes.FORMAT_TYPE_JSON);
                x.Headers.Set(CreatePartyCommand.PREFER_HEADER, repositorySettings.PreferMinimal);
            });
            if (Response.Is(out Response<PartyCreated>? Result))
            {
                if (Result is not null)
                    return new ObjectVersionId(Result.Headers.Get<string>(PartyCreated.VERSIONID_HEADER));
                else
                    throw new ManualException(ExceptionsMessages.RESPONSE_FROM_RESOURCE_IS_NOT_VALID.Replace("{0}", Names.REPOSITORY), ExceptionType.InternalServerError, nameof(Names.REPOSITORY));
            }
            else
            {

                Response.Is(out Response<DDRErrorRespond>? ErrorResult);
                if (ErrorResult is not null)
                    throw DDRRespondToManalException(ErrorResult);
                else
                    throw new ManualException(ExceptionsMessages.RESPONSE_FROM_RESOURCE_IS_NOT_VALID.Replace("{0}", Names.REPOSITORY), ExceptionType.InternalServerError, nameof(Names.REPOSITORY));
            }
        }
        catch (ManualException)
        {
            throw;
        }
        catch (RequestTimeoutException Ex)
        {
            throw new ManualException(ExceptionsMessages.REQUEST_TIME_OUT_FROM_RESOURCE.Replace("{0}", Names.REPOSITORY), ExceptionType.TimeOut, nameof(Names.REPOSITORY), Ex);
        }
        catch (global::openEHR.Helper.CustomException.openEHRException)
        {
            throw;
        }
        catch (Exception Ex)
        {
            throw new ManualException(ExceptionsMessages.Cannot_connect_to_resource.Replace("{0}", Names.REPOSITORY), ExceptionType.TimeOut, nameof(Names.REPOSITORY), Ex);
        }

    }
    /// <summary>
    /// <see cref="IDDRRepository.UpdateParty(global::openEHR.DDR.Command.Party.Base.Party, ObjectVersionId, UpdateAudit, TerminologyCode)"/>
    /// </summary>
    /// <param name="Party"></param>
    /// <param name="PrecedingVersionUid"></param>
    /// <param name="UpdateAudit"></param>
    /// <param name="VersionLifecycleState"></param>
    /// <returns></returns>
    public async Task<ObjectVersionId> UpdateParty(global::openEHR.DDR.Command.Party.Base.Party Party, ObjectVersionId PrecedingVersionUid, UpdateAudit UpdateAudit, TerminologyCode VersionLifecycleState)
    {
        try
        {
            var PartyRequestInstance = UpdatePartyRequest.Create(new(PrecedingVersionUid, VersionLifecycleState, null, Party, UpdateAudit));
            var Response = await PartyRequestInstance.GetResponse<UpdatePartyCommand, PartyUpdated, DDRErrorRespond>(x =>
            {
                x.Headers.Set(UpdatePartyCommand.ACCEPT_HEADER, FormatTypes.FORMAT_TYPE_JSON);
                x.Headers.Set(UpdatePartyCommand.PREFER_HEADER, repositorySettings.PreferMinimal);
            });
            if (Response.Is(out Response<PartyUpdated>? Result))
            {
                if (Result is not null)
                    return new ObjectVersionId(Result.Headers.Get<string>(PartyUpdated.VERSIONID_HEADER));
                else
                    throw new ManualException(ExceptionsMessages.RESPONSE_FROM_RESOURCE_IS_NOT_VALID.Replace("{0}", Names.REPOSITORY), ExceptionType.InternalServerError, nameof(Names.REPOSITORY));
            }
            else
            {
                Response.Is(out Response<DDRErrorRespond>? ErrorResult);
                if (ErrorResult is not null)
                    throw DDRRespondToManalException(ErrorResult);
                else
                    throw new ManualException(ExceptionsMessages.RESPONSE_FROM_RESOURCE_IS_NOT_VALID.Replace("{0}", Names.REPOSITORY), ExceptionType.InternalServerError, nameof(Names.REPOSITORY));

            }
        }
        catch (ManualException)
        {
            throw;
        }
        catch (RequestTimeoutException Ex)
        {
            throw new ManualException(ExceptionsMessages.REQUEST_TIME_OUT_FROM_RESOURCE.Replace("{0}", Names.REPOSITORY), ExceptionType.TimeOut, nameof(Names.REPOSITORY), Ex);
        }
        catch (global::openEHR.Helper.CustomException.openEHRException)
        {
            throw;
        }
        catch (Exception Ex)
        {
            throw new ManualException(ExceptionsMessages.Cannot_connect_to_resource.Replace("{0}", Names.REPOSITORY), ExceptionType.TimeOut, nameof(Names.REPOSITORY), Ex);
        }
    }
    /// <summary>
    /// <see cref="IDDRRepository.CreatePartyRelationship(PartyRelationship, UpdateAudit, TerminologyCode)"/>
    /// </summary>
    /// <param name="Relationship"></param>
    /// <param name="UpdateAudit"></param>
    /// <param name="VersionLifecycleState"></param>
    /// <returns></returns>
    public async Task<ObjectVersionId> CreatePartyRelationship(PartyRelationship Relationship, UpdateAudit UpdateAudit, TerminologyCode VersionLifecycleState)
    {
        try
        {
            var PartyRelationshipRequest = CreatePartyRelationshipRequest.Create(new(VersionLifecycleState, null, Relationship, UpdateAudit));
            var Response = await PartyRelationshipRequest.GetResponse<CreatePartyRelationshipCommand, PartyRelationshipCreated, DDRErrorRespond>(x =>
            {
                x.Headers.Set(CreatePartyRelationshipCommand.ACCEPT_HEADER, FormatTypes.FORMAT_TYPE_JSON);
                x.Headers.Set(CreatePartyRelationshipCommand.PREFER_HEADER, repositorySettings.PreferMinimal);
            });
            if (Response.Is(out Response<PartyRelationshipCreated>? Result))
            {
                if (Result is not null)
                    return new ObjectVersionId(Result.Headers.Get<string>(PartyRelationshipCreated.VERSIONID_HEADER));
                else
                    throw new ManualException(ExceptionsMessages.RESPONSE_FROM_RESOURCE_IS_NOT_VALID.Replace("{0}", Names.REPOSITORY), ExceptionType.InternalServerError, nameof(Names.REPOSITORY));
            }
            else
            {
                Response.Is(out Response<DDRErrorRespond>? ErrorResult);
                if (ErrorResult is not null)
                    throw DDRRespondToManalException(ErrorResult);
                else
                    throw new ManualException(ExceptionsMessages.RESPONSE_FROM_RESOURCE_IS_NOT_VALID.Replace("{0}", Names.REPOSITORY), ExceptionType.InternalServerError, nameof(Names.REPOSITORY));
            }
        }
        catch (ManualException)
        {
            throw;
        }
        catch (RequestTimeoutException Ex)
        {
            throw new ManualException(ExceptionsMessages.REQUEST_TIME_OUT_FROM_RESOURCE.Replace("{0}", Names.REPOSITORY), ExceptionType.TimeOut, nameof(Names.REPOSITORY), Ex);
        }
        catch (global::openEHR.Helper.CustomException.openEHRException)
        {
            throw;
        }
        catch (Exception Ex)
        {
            throw new ManualException(ExceptionsMessages.REQUEST_TIME_OUT_FROM_RESOURCE.Replace("{0}", Names.REPOSITORY), ExceptionType.TimeOut, nameof(Names.REPOSITORY), Ex);
        }
    }
    /// <summary>
    /// <see cref="IDDRRepository.UpdatePartyRelationship(PartyRelationship, ObjectVersionId, UpdateAudit, TerminologyCode)"/>
    /// </summary>
    /// <param name="Relationship"></param>
    /// <param name="PrecedingVersionUid"></param>
    /// <param name="UpdateAudit"></param>
    /// <param name="VersionLifecycleState"></param>
    /// <returns></returns>
    public async Task<ObjectVersionId> UpdatePartyRelationship(PartyRelationship Relationship, ObjectVersionId PrecedingVersionUid, UpdateAudit UpdateAudit, TerminologyCode VersionLifecycleState)
    {
        try
        {
            var PartyRelationshipRequest = UpdatePartyRelationshipRequest.Create(new(PrecedingVersionUid, VersionLifecycleState, null, Relationship, UpdateAudit));
            var Response = await PartyRelationshipRequest.GetResponse<UpdatePartyRelationshipCommand, PartyRelationshipUpdated, DDRErrorRespond>(x =>
            {
                x.Headers.Set(UpdatePartyRelationshipCommand.ACCEPT_HEADER, FormatTypes.FORMAT_TYPE_JSON);
                x.Headers.Set(UpdatePartyRelationshipCommand.PREFER_HEADER, repositorySettings.PreferMinimal);
            });
            if (Response.Is(out Response<PartyRelationshipUpdated>? Result))
            {
                if (Result is not null)
                    return new ObjectVersionId(Result.Headers.Get<string>(PartyRelationshipUpdated.VERSIONID_HEADER));
                else
                    throw new ManualException(ExceptionsMessages.RESPONSE_FROM_RESOURCE_IS_NOT_VALID.Replace("{0}", Names.REPOSITORY), ExceptionType.InternalServerError, nameof(Names.REPOSITORY));
            }
            else
            {
                Response.Is(out Response<DDRErrorRespond>? ErrorResult);
                if (ErrorResult is not null)
                    throw DDRRespondToManalException(ErrorResult);
                else
                    throw new ManualException(ExceptionsMessages.RESPONSE_FROM_RESOURCE_IS_NOT_VALID.Replace("{0}", Names.REPOSITORY), ExceptionType.InternalServerError, nameof(Names.REPOSITORY));
            }
        }
        catch (ManualException)
        {
            throw;
        }
        catch (RequestTimeoutException Ex)
        {
            throw new ManualException(ExceptionsMessages.REQUEST_TIME_OUT_FROM_RESOURCE.Replace("{0}", Names.REPOSITORY), ExceptionType.TimeOut, nameof(Names.REPOSITORY), Ex);
        }
        catch (global::openEHR.Helper.CustomException.openEHRException)
        {
            throw;
        }
        catch (Exception Ex)
        {
            throw new ManualException(ExceptionsMessages.Cannot_connect_to_resource.Replace("{0}", Names.REPOSITORY), ExceptionType.TimeOut, nameof(Names.REPOSITORY), Ex);
        }
    }
    private static ManualException DDRRespondToManalException(Response<DDRErrorRespond> ErrorResult)
    {
        string Message = "";
        foreach (var Msg in ErrorResult.Message.Errors[0].Messages)
        {
            if (!string.IsNullOrWhiteSpace(Msg))
                Message = Msg + ", ";
        }
        if (string.IsNullOrWhiteSpace(Message))
            Message = Message[0..^1];
        return new ManualException(Message, (ExceptionType)(int)ErrorResult.Message.Status, ErrorResult.Message.Errors[0].Code);
    }
}
