using Mapper.GSB.Domain.Helper;
using Mapper.GSB.Domain.SeedWorks;
using Services.ExceptionManager;
using Services.ExceptionManager.Resources;
using Mapper.GSB.Share.Resource;
using MOHME.Lib.Shared;
using MOHME.Lib.Helper.Validator;

namespace Mapper.GSB.Domain.Insurance;

/// <summary>
/// اطلاعات بیمه نامه تکمیلی یا بیمه نامه فول به همراه اطلاعات فرد
/// </summary>
public sealed class PersonInsurance : EventSourcedAggregateRoot
{
    /// <summary>
    /// ایجاد شی بیمه نامه
    /// </summary>
    /// <param name="msgId"></param>
    /// <param name="person"></param>
    /// <param name="personPolicy"></param>
    /// <param name="serviceDateTime"></param>
    /// <param name="isInsert"></param>
    public PersonInsurance(MessageIdentifierVO? msgId, PersonInfoVO? person, PersonPolicyVO? personPolicy, DO_DATE_TIME? serviceDateTime, bool isInsert) : base(createDateTime: null)
    {
        if (msgId is null)
            throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonInsurance).Replace("{1}", Names.MessageIdentifierVO), ExceptionType.InValid, typeof(PersonInsurance).FullName + "." + nameof(MsgId));
        if (person is null)
            throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonInsurance).Replace("{1}", Names.PersonInfoVO), ExceptionType.InValid, typeof(PersonInsurance).FullName + "." + nameof(Person));
        if (personPolicy is null)
            throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonInsurance).Replace("{1}", Names.PersonPolicyVO), ExceptionType.InValid, typeof(PersonInsurance).FullName + "." + nameof(PersonPolicy));
        if (serviceDateTime is null)
            throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonInsurance).Replace("{1}", Names.PersonInsurance_ServiceDateTime), ExceptionType.InValid, typeof(PersonInsurance).FullName + "." + nameof(ServiceDateTime));
        else
            serviceDateTime.Validate(Names.PersonInsurance, Names.PersonInsurance_ServiceDateTime, typeof(PersonInfoVO).FullName + "." + nameof(ServiceDateTime));

        var newMsgId = new MessageIdentifierVO(msgId.VersionLifecycleState, msgId.IS_Queriable, msgId.CompositionSignature, msgId.SystemID, msgId.HealthCareFacilityID,
                                               msgId.PatientUID, msgId.CompositionUID, msgId.Committer, msgId.LocalId, msgId.UniversityID, msgId.Deactivate, msgId.WithoutId, msgId.Version, msgId.RegisterUID, msgId.MessageUID, isInsert);
        var newPerson = new PersonInfoVO(person.PersonId, person.Province, person.City, person.PictureB64, person.OtherContacts, person.OtherIdentifier, person.BirthPlaceArea, person.Religion, person.MaritalStatus,
                            person.Nationality, person.BirthDate, person.BirthTime, person.BirthdateAccuracy, person.Father_FirstName, person.Father_LastName, person.Mother_FirstName,
                            person.Mother_LastName, person.FullName, person.PostalCode, person.Gender, person.Job, person.JobDescribtion, person.FullAddress, person.LivingPlaceArea,
                            person.IDCardNumber, person.IDIssueArea, person.HomeTel, person.MobileNumber, person.EducationLevel, person.FirstName, person.LastName, person.NationalCode, person.Languages, person.DeathDetail, person.BirthDetail);

        var newPersonPolicy = new PersonPolicyVO(personPolicy.Insurer, personPolicy.PolicyType, personPolicy.PolicyUniqueCode, personPolicy.EffectiveDate, personPolicy.InsuranceExpirationDate, personPolicy.InsuranceBox,
                                          personPolicy.RelationType, personPolicy.PolicyPrintNumber, personPolicy.CompanyPolicyId, personPolicy.CompanyInsuredId, personPolicy.InsuredType,
                                          personPolicy.ResponsibleID, personPolicy.ResponsibleGender, personPolicy.ResponsibleFirstName, personPolicy.ResponsibleLastName, personPolicy.InsurerName,
                                          personPolicy.insurerNationalCode, personPolicy.PolicyIssueDate, personPolicy.BaseInsurer, personPolicy.ProvinceBranch, personPolicy.CityBranch, personPolicy.Branch,
                                          personPolicy.RecommendationMessage, personPolicy.PlanId, personPolicy.RequestReason, personPolicy.IsCoverageUnlimited, personPolicy.PolicyVerNo, personPolicy.PolicyVerUniqueCode,
                                          personPolicy.ContractType, personPolicy.ShebaNo, personPolicy.BankAcc, personPolicy.AccNo, personPolicy.DeathDate, personPolicy.WorkShop, personPolicy.Feranshiz, personPolicy.Account);
        AddEvent(new PersonInsuranceCreatedEvent(Id, newMsgId, newPerson, newPersonPolicy, serviceDateTime, Version + 1, CreatedDate));
    }
    /// <summary>
    /// <see cref="EventSourcedAggregateRoot.EventSourcedAggregateRoot(Queue{Event})"/>
    /// </summary>
    /// <param name="historyEvents"></param>
    public PersonInsurance(Queue<Event> historyEvents) : base(historyEvents) { }

    /// <summary>
    /// اطلاعات مورد استفاده در تبادل داده با سرویس‌های پرونده الکترونیکی سلامت می‌باشد.
    /// </summary>
    public MessageIdentifierVO? MsgId { get; private set; }
    /// <summary>
    /// اطلاعات هويتي بیمه شده و اطلاعات تماس
    /// </summary>
    public PersonInfoVO? Person { get; private set; }
    /// <summary>
    /// اطلاعات بیمه نامه
    /// </summary>
    public PersonPolicyVO? PersonPolicy { get; private set; }
    /// <summary>
    /// پاسخ ثبت اطلاعات 
    /// GSB
    /// </summary>
    public GSBDataVO? GSBDataVO { get; private set; }
    /// <summary>
    /// زمان ثبت/الحاقیه بیمه شده در شرکت بیمه تکمیلی- زمان ارائه خدمت
    /// </summary>
    public DO_DATE_TIME? ServiceDateTime { get; private set; }
    private DO_DATE? _serviceDate;
    /// <summary>
    /// زمان ثبت/الحاقیه بیمه شده در شرکت بیمه تکمیلی- زمان ارائه خدمت
    /// به فرمت وزارت بهداشت
    /// </summary>
    public DO_DATE? ServiceDate
    {
        get
        {
            if (_serviceDate is null && ServiceDateTime is not null)
            {
                return new DO_DATE()
                {
                    Year = ServiceDateTime.Year,
                    Month = ServiceDateTime.Month,
                    Day = ServiceDateTime.Day
                };
            }
            return _serviceDate;
        }
        private set
        {
            _serviceDate = value;
        }
    }
    private DO_TIME? _serviceTime;
    /// <summary>
    /// زمان ثبت/الحاقیه بیمه شده در شرکت بیمه تکمیلی- زمان ارائه خدمت
    /// به فرمت وزارت بهداشت
    /// </summary>
    public DO_TIME? ServiceTime
    {
        get
        {
            if (_serviceTime is null && ServiceDateTime is not null)
            {
                return new DO_TIME()
                {
                    Hour = ServiceDateTime.Hour,
                    Minute = ServiceDateTime.Minute,
                    Second = ServiceDateTime.Second
                };
            }
            return _serviceTime;
        }
        private set
        {
            _serviceTime = value;
        }
    }
    /// <summary>
    /// زمان ایجاد داده
    /// </summary>
    public DO_DATE_TIME RegisterDateTime => CreatedDate.GetPersianDoDateTime();
    /// <summary>
    /// تنظمیم اطلاعات دریافتی از سرویس 
    /// GSB
    /// </summary>
    /// <param name="jsonStringifyResult"></param>
    /// <param name="gSBDataVO"></param>
    public void SetGSBDataVO(string jsonStringifyResult, GSBDataVO? gSBDataVO)
    {
        GSBDataVO = gSBDataVO;
        AddEvent(new PersonInsuranceGSBResultChangedEvent(Id, jsonStringifyResult, gSBDataVO, Version + 1, CreatedDate));
    }
    /// <summary>
    /// <see cref="EventSourcedAggregateRoot.Apply(Event)"/>
    /// </summary>
    /// <param name="event"></param>
    /// <exception cref="NotImplementedException"></exception>
    private protected override void Apply(Event @event)
    {
        switch (@event)
        {
            case PersonInsuranceCreatedEvent e:
                Id = e.AggregateRootId;
                MsgId = e.MsgId;
                Person = e.Person;
                PersonPolicy = e.PersonPolicy;
                ServiceDateTime = e.ServiceDateTime;
                ServiceDate = new DO_DATE() { Year = e.ServiceDateTime.Year, Month = e.ServiceDateTime.Month, Day = e.ServiceDateTime.Day };
                ServiceTime = new DO_TIME() { Hour = e.ServiceDateTime.Hour, Minute = e.ServiceDateTime.Month, Second = e.ServiceDateTime.Second };
                CreatedDate = e.CreateDate;
                ModifiedDate = e.CreateDate;
                GSBDataVO = null;
                break;
            case PersonInsuranceGSBResultChangedEvent e:
                GSBDataVO = e.GSBDataVO;
                ModifiedDate = e.CreateDate;
                break;
        }
    }
}