using openEHR.Library.Base.BaseTypes.Identification;
using Mapper.openEHR.Service.Mapper;
using Mapper.GSB.Domain.Insurance;
using Mapper.GSB.Share.Resource;
using MOHME.Lib.Shared;
using global::openEHR.Library.Base.FoundationTypes.Terminology;
using global::openEHR.Library.Sm.Platform.Common;
using global::openEHR.Library.Rm.Common.Archetyped;
using Mapper.GSB.Application.Services.Terminology.openEHR;

namespace Mapper.GSB.Application.DDRAPICaller.Services.DDR
{
    using global::openEHR.Library.Rm.Demographic;
    using global::Services.ExceptionManager;
    using global::Services.ExceptionManager.Resources;
    using Mapper.GSB.Application.DDRAPICaller.Services.DDR.Helper;
    using MediatR;


    /// <summary>
    /// سرویس ثبت اطلاعات در 
    /// DDR
    /// </summary>
    public class DDRService : IDDRService
    {
        private readonly IMapperService mapperService;
        private readonly IOpenEHRTerminologyService openEHRTerminologyService;
        private readonly IDDRRepository dDRRepository;
        private readonly IDDRMapperSetting dDRMapperSetting;

        /// <summary>
        /// سرویس های مورد نیاز
        /// </summary>
        /// <param name="mapperService"></param>
        /// <param name="openEHRTerminologyService"></param>
        /// <param name="dDRRepository"></param>
        /// <param name="dDRMapperSetting"></param>
        public DDRService(IMapperService mapperService,
                          IOpenEHRTerminologyService openEHRTerminologyService,
                          IDDRRepository dDRRepository,
                          IDDRMapperSetting dDRMapperSetting)
        {
            this.mapperService = mapperService;
            this.openEHRTerminologyService = openEHRTerminologyService;
            this.dDRRepository = dDRRepository;
            this.dDRMapperSetting = dDRMapperSetting;
        }
        /// <summary>
        /// ایجاد بیمار
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="PrevopenEHRPartyId"></param>
        /// <returns></returns>
        public async Task<ObjectVersionId> SavePatient(PersonInsurance entity, ObjectVersionId? PrevopenEHRPartyId)
        {
            //تبدیل به رفرنس مدل
            Person person;
            try
            {
                person = (Person)await mapperService.ConvertModelToTemplateBasedModel(entity.Person!, dDRMapperSetting.OPT_Person_Id, dDRMapperSetting.Mapper_PersonToOPT_Url, dDRMapperSetting.Mapper_PersonToOPT_Version).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new ManualException(ExceptionsMessages.Cannot_Convert_source_Model_To_Destination_Model.Replace("{0}", Names.PersonInfoVO).Replace("{1}", nameof(Names.DDR_Person)) + "[Id]:["+ entity.Id + "]", ExceptionType.InternalServerError, nameof(DDRService) + "." + nameof(SavePatient) + "()", null, ex);
            }
            SubjectInfo PersonInfo;
            DataAuditDetails audit;
            global::openEHR.DDR.Command.Party.Base.Person NewPerson;
            TerminologyCode VersionLifecycleState;
            UpdateAudit updateAudit;
            try
            {
                (PersonInfo, audit) = CreateSubjectInfoAndAudit(entity, PrevopenEHRPartyId?.Root().Value);
                TerminologyCode AuditChange;
                FeederAudit feederAudit;
                if (PrevopenEHRPartyId is null)
                    (AuditChange, VersionLifecycleState, feederAudit) = await DDRObjectCreatorHelper.GetMetaDataCreate(openEHRTerminologyService, audit, PersonInfo, audit.VersionLifecycleState?.Coded_string, dDRMapperSetting.MapperSystemId, dDRMapperSetting.MapperOrganizationId, dDRMapperSetting.MapperOrganizationName).ConfigureAwait(false);
                else
                    (AuditChange, VersionLifecycleState, feederAudit) = await DDRObjectCreatorHelper.GetMetaDataUpdate(openEHRTerminologyService, audit, PersonInfo, audit.VersionLifecycleState?.Coded_string, dDRMapperSetting.MapperSystemId, dDRMapperSetting.MapperOrganizationId, dDRMapperSetting.MapperOrganizationName).ConfigureAwait(false);
                (NewPerson, updateAudit) = DDRObjectCreatorHelper.CreatePerson(audit.Committer, AuditChange, feederAudit, person);
            }
            catch (Exception ex)
            {
                throw new ManualException(ExceptionsMessages.An_error_occurred_while_processing_the_request_from_this_service.Replace("{0}", Names.PrepareMetaData).Replace("{1}", Names.SavePersonInDDR), ExceptionType.InternalServerError, nameof(DDRService) + "." + nameof(SavePatient) + "()", null, ex);
            }
            ObjectVersionId PartyId;
            try
            {
                if (PrevopenEHRPartyId is null)
                    PartyId = await dDRRepository.CreateParty(NewPerson, updateAudit, VersionLifecycleState).ConfigureAwait(false);
                else
                    PartyId = await dDRRepository.UpdateParty(NewPerson, PrevopenEHRPartyId, updateAudit, VersionLifecycleState).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                string InsertOrUpdateName = PrevopenEHRPartyId is null ? Names.DDR_Insert : Names.DDR_Update;
                throw new ManualException(ExceptionsMessages.An_error_occurred_while_processing_the_request_from_this_service.Replace("{0}", InsertOrUpdateName).Replace("{1}", Names.SavePersonInDDR), ExceptionType.InternalServerError, nameof(DDRService) + "." + nameof(SavePatient) + "()", null, ex);
            }
            return PartyId;
        }
        /// <summary>
        /// ایجاد اطلاعات نسخه و اطلاعات تکمیلی سند
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="SourceId"></param>
        /// <param name="PrevopenEHRPartyRelationshipId"></param>
        /// <returns></returns>
        public async Task<ObjectVersionId> SaveCompositon(PersonInsurance entity, string SourceId, ObjectVersionId? PrevopenEHRPartyRelationshipId)
        {
            //تبدیل به رفرنس مدل
            PartyRelationship composition;
            try
            {
                composition = (PartyRelationship)await mapperService.ConvertModelToTemplateBasedModel(entity, dDRMapperSetting.OPT_Composition_Id, dDRMapperSetting.Mapper_CompositionToOPT_Url, dDRMapperSetting.Mapper_CompositionToOPT_Version).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new ManualException(ExceptionsMessages.Cannot_Convert_source_Model_To_Destination_Model.Replace("{0}", Names.PersonPolicyVO).Replace("{1}", nameof(Names.DDR_Relationship)), ExceptionType.InternalServerError, nameof(DDRService) + "." + nameof(SaveCompositon) + "()", null, ex);
            }
            SubjectInfo PersonInfo;
            DataAuditDetails audit;
            PartyRelationship NewMedicalBill;
            TerminologyCode VersionLifecycleState;
            UpdateAudit UpdateAudit;
            try
            {
                (PersonInfo, audit) = CreateSubjectInfoAndAudit(entity, "", PrevopenEHRPartyRelationshipId?.Root().Value);
                TerminologyCode AuditChange;
                FeederAudit FeederAudit;
                if (PrevopenEHRPartyRelationshipId is null)
                    (AuditChange, VersionLifecycleState, FeederAudit) = await DDRObjectCreatorHelper.GetMetaDataCreate(openEHRTerminologyService, audit, PersonInfo, audit.VersionLifecycleState?.Coded_string, dDRMapperSetting.MapperSystemId, dDRMapperSetting.MapperOrganizationId, dDRMapperSetting.MapperOrganizationName).ConfigureAwait(false);
                else
                    (AuditChange, VersionLifecycleState, FeederAudit) = await DDRObjectCreatorHelper.GetMetaDataUpdate(openEHRTerminologyService, audit, PersonInfo, audit.VersionLifecycleState?.Coded_string, dDRMapperSetting.MapperSystemId, dDRMapperSetting.MapperOrganizationId, dDRMapperSetting.MapperOrganizationName).ConfigureAwait(false);
                (NewMedicalBill, UpdateAudit) = DDRObjectCreatorHelper.CreatePartyRelationship(audit.Committer, AuditChange, FeederAudit, SourceId, entity.MsgId!.SystemID!.ID!, composition);
            }
            catch (Exception ex)
            {
                throw new ManualException(ExceptionsMessages.An_error_occurred_while_processing_the_request_from_this_service.Replace("{0}", Names.PrepareMetaData).Replace("{1}", Names.SaveRelationshipInDDR), ExceptionType.InternalServerError, nameof(DDRService) + "." + nameof(SaveCompositon) + "()", null, ex);
            }
            ObjectVersionId PartyRelationshipId;
            try
            {
                if (PrevopenEHRPartyRelationshipId is null)
                    PartyRelationshipId = await dDRRepository.CreatePartyRelationship(NewMedicalBill, UpdateAudit, VersionLifecycleState).ConfigureAwait(false);
                else
                    PartyRelationshipId = await dDRRepository.UpdatePartyRelationship(NewMedicalBill, PrevopenEHRPartyRelationshipId, UpdateAudit, VersionLifecycleState).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                string InsertOrUpdateName = PrevopenEHRPartyRelationshipId is null ? Names.DDR_Insert : Names.DDR_Update;
                throw new ManualException(ExceptionsMessages.An_error_occurred_while_processing_the_request_from_this_service.Replace("{0}", InsertOrUpdateName).Replace("{1}", Names.SaveRelationshipInDDR), ExceptionType.InternalServerError, nameof(DDRService) + "." + nameof(SaveCompositon) + "()", null, ex);
            }
            return PartyRelationshipId;
        }
        /// <summary>
        /// ایجاد اطلاعات مورد نیاز جهت ثبت داده ها
        /// شامل اطلاعات اولیه بیمار و داده های تکمیلی برای ثبت
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="PatientUID"></param>
        /// <param name="CompositionUID"></param>
        /// <returns></returns>
        private (SubjectInfo PersonInfo, DataAuditDetails audit) CreateSubjectInfoAndAudit(PersonInsurance entity, string? PatientUID, string? CompositionUID = "")
        {
            PersonInfoVO person = entity.Person!;
            MessageIdentifierVO msgId = entity.MsgId!;
            PersonPolicyVO personPolicy = entity.PersonPolicy!;
            SubjectInfo personInfo = new(person.NationalCode, PatientUID, CompositionUID, person.FirstName, person.LastName, person.FullName);
            Committer commiter;
            if (msgId.Committer is not null)
                commiter = new Committer(msgId.Committer.Identifier, msgId.Committer.FirstName, msgId.Committer.LastName, msgId.Committer.FullName);
            else
                commiter = new Committer(null, "", "", "نامشخص");
            string organizationName = personPolicy.Insurer!.Value!;
            DO_IDENTIFIER healthCareFacilityID = msgId.HealthCareFacilityID ?? new DO_IDENTIFIER() { ID = dDRMapperSetting.MapperOrganizationId, Assigner = "", Issuer = "", Type = "" };
            DataAuditDetails audit = new(msgId.SystemID!, healthCareFacilityID, organizationName, msgId.VersionLifecycleState, commiter, null);
            return (personInfo, audit);
        }
    }
}
