using MOHME.Lib.Shared;
using MOHME.Lib.Helper.Validator;
namespace Mapper.GSB.Application.Insurance.Commands.Save;


/// <summary>
/// اطلاعات هویتی بیمه شده
/// </summary>
public class PersonInfoVODto
{
    /// <summary>
    /// ایجاد اطلاعات شخصی بیمار یا بیمه شونده
    /// </summary>
    /// <param name="personId"></param>
    /// <param name="province"></param>
    /// <param name="city"></param>
    /// <param name="pictureB64"></param>
    /// <param name="otherContacts"></param>
    /// <param name="otherIdentifier"></param>
    /// <param name="birthPlaceArea"></param>
    /// <param name="religion"></param>
    /// <param name="maritalStatus"></param>
    /// <param name="nationality"></param>
    /// <param name="birthDate"></param>
    /// <param name="birthTime"></param>
    /// <param name="birthdateAccuracy"></param>
    /// <param name="father_FirstName"></param>
    /// <param name="father_LastName"></param>
    /// <param name="mother_FirstName"></param>
    /// <param name="mother_LastName"></param>
    /// <param name="fullName"></param>
    /// <param name="postalCode"></param>
    /// <param name="gender"></param>
    /// <param name="job"></param>
    /// <param name="jobDescribtion"></param>
    /// <param name="fullAddress"></param>
    /// <param name="livingPlaceArea"></param>
    /// <param name="iDCardNumber"></param>
    /// <param name="iDIssueArea"></param>
    /// <param name="homeTel"></param>
    /// <param name="mobileNumber"></param>
    /// <param name="educationLevel"></param>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    /// <param name="nationalCode"></param>
    /// <param name="languages"></param>
    /// <param name="deathDetail"></param>
    /// <param name="birthDetail"></param>
    public PersonInfoVODto(DO_IDENTIFIER? personId, DO_CODED_TEXT? province, DO_CODED_TEXT? city, string? pictureB64, ElectronicContactVO[]? otherContacts, DO_IDENTIFIER[]? otherIdentifier, HighLevelAreaVO? birthPlaceArea,
                        DO_CODED_TEXT? religion, DO_CODED_TEXT? maritalStatus,
                        DO_CODED_TEXT? nationality, DO_DATE birthDate, DO_TIME? birthTime, DO_CODED_TEXT? birthdateAccuracy, string? father_FirstName, string? father_LastName, string? mother_FirstName,
                        string? mother_LastName, string? fullName, string postalCode, DO_CODED_TEXT gender, DO_CODED_TEXT? job, string? jobDescribtion, string? fullAddress, HighLevelAreaVO? livingPlaceArea,
                        string? iDCardNumber, HighLevelAreaVO? iDIssueArea, string? homeTel, string? mobileNumber, DO_CODED_TEXT? educationLevel, string firstName, string lastName, string? nationalCode,
                        DO_CODEABLE_CONCEPT? languages, BasicDeathDetailsVO? deathDetail, BirthVo? birthDetail)
    {
        PersonId = personId is not null && personId.areAllPropsNullOrEmpty() ? null : personId;
        Province = province is not null && province.areAllPropsNullOrEmpty() ? null : province;
        City = city is not null && city.areAllPropsNullOrEmpty() ? null : city;
        PictureB64 = pictureB64;
        this.otherContactsField = otherContacts;
        this.otherIdentifierField = otherIdentifier;
        this.birthPlaceAreaField = birthPlaceArea;
        this.religionField = religion is not null && religion.areAllPropsNullOrEmpty() ? null : religion;
        this.maritalStatusField = maritalStatus is not null && maritalStatus.areAllPropsNullOrEmpty() ? null : maritalStatus;
        this.nationalityField = nationality is not null && nationality.areAllPropsNullOrEmpty() ? null : nationality;
        this.birthDateField = birthDate is not null && birthDate.areAllPropsNullOrEmpty() ? null : birthDate;
        this.birthTimeField = birthTime is not null && birthTime.areAllPropsNullOrEmpty() ? null : birthTime;
        this.birthdateAccuracyField = birthdateAccuracy is not null && birthdateAccuracy.areAllPropsNullOrEmpty() ? null : birthdateAccuracy;
        this.father_FirstNameField = father_FirstName;
        this.father_LastNameField = father_LastName;
        this.mother_FirstNameField = mother_FirstName;
        this.mother_LastNameField = mother_LastName;
        this.fullNameField = fullName;
        this.postalCodeField = postalCode;
        this.genderField = gender is not null && gender.areAllPropsNullOrEmpty() ? null : gender;
        this.jobField = job is not null && job.areAllPropsNullOrEmpty() ? null : job;
        this.jobDescribtionField = jobDescribtion;
        this.fullAddressField = fullAddress;
        this.livingPlaceAreaField = livingPlaceArea;
        this.iDCardNumberField = iDCardNumber;
        this.iDIssueAreaField = iDIssueArea;
        this.homeTelField = homeTel;
        this.mobileNumberField = mobileNumber;
        this.educationLevelField = educationLevel is not null && educationLevel.areAllPropsNullOrEmpty() ? null : educationLevel;
        this.firstNameField = firstName;
        this.lastNameField = lastName;
        this.nationalCodeField = nationalCode;
        this.languages = languages;
        this._deathDetail = deathDetail;
        this._birthDetail = birthDetail;
    }
    private ElectronicContactVO[]? otherContactsField;

    private DO_IDENTIFIER[]? otherIdentifierField;

    private HighLevelAreaVO? birthPlaceAreaField;

    private DO_CODED_TEXT? religionField;

    private DO_CODED_TEXT? maritalStatusField;

    private DO_CODED_TEXT? nationalityField;

    private DO_DATE? birthDateField;

    private DO_TIME? birthTimeField;

    private DO_CODED_TEXT? birthdateAccuracyField;

    private string? father_FirstNameField;

    private string? father_LastNameField;

    private string? mother_FirstNameField;

    private string? mother_LastNameField;

    private string? fullNameField;

    private string? postalCodeField;

    private DO_CODED_TEXT? genderField;

    private DO_CODED_TEXT? jobField;

    private string? jobDescribtionField;

    private string? fullAddressField;

    private HighLevelAreaVO? livingPlaceAreaField;

    private string? iDCardNumberField;

    private HighLevelAreaVO? iDIssueAreaField;

    private string? homeTelField;

    private string? mobileNumberField;

    private DO_CODED_TEXT? educationLevelField;

    private string? firstNameField;

    private string? lastNameField;

    private string? nationalCodeField;
    private DO_CODEABLE_CONCEPT? languages;

    /// <summary>
    /// شناسه ملی فرد یا شناسه اتباع بیگانه یا پاسپورت  (مطابق با شناسه های حوزه سلامت)
    /// </summary>
    public DO_IDENTIFIER? PersonId { get; private set; }
    /// <summary>
    /// استان بیمه شده
    /// </summary>
    public DO_CODED_TEXT? Province { get; set; }
    /// <summary>
    /// شهر بیمه شده
    /// </summary>
    public DO_CODED_TEXT? City { get; set; }
    /// <summary>
    /// تصویر بیمه شده
    /// </summary>
    public string? PictureB64 { get; private set; }
    /// <remarks/>
    public ElectronicContactVO[]? OtherContacts
    {
        get
        {
            return otherContactsField;
        }
        private set
        {
            otherContactsField = value;
        }
    }

    /// <remarks/>
    public DO_IDENTIFIER[]? OtherIdentifier
    {
        get
        {
            return otherIdentifierField;
        }
        private set
        {
            otherIdentifierField = value;
        }
    }

    /// <remarks/>
    public HighLevelAreaVO? BirthPlaceArea
    {
        get
        {
            return birthPlaceAreaField;
        }
        private set
        {
            birthPlaceAreaField = value;
        }
    }

    /// <remarks/>
    public DO_CODED_TEXT? Religion
    {
        get
        {
            return religionField;
        }
        private set
        {
            religionField = value;
        }
    }

    /// <remarks/>
    public DO_CODED_TEXT? MaritalStatus
    {
        get
        {
            return maritalStatusField;
        }
        private set
        {
            maritalStatusField = value;
        }
    }

    /// <remarks/>
    public DO_CODED_TEXT? Nationality
    {
        get
        {
            return nationalityField;
        }
        private set
        {
            nationalityField = value;
        }
    }

    /// <summary>
    /// تاریح تولد
    /// </summary>
    public DO_DATE? BirthDate
    {
        get
        {
            return birthDateField;
        }
        private set
        {
            birthDateField = value;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public DO_TIME? BirthTime
    {
        get
        {
            return birthTimeField;
        }
        private set
        {
            birthTimeField = value;
        }
    }

    /// <remarks/>
    public DO_CODED_TEXT? BirthdateAccuracy
    {
        get
        {
            return birthdateAccuracyField;
        }
        private set
        {
            birthdateAccuracyField = value;
        }
    }

    /// <remarks/>
    public string? Father_FirstName
    {
        get
        {
            return father_FirstNameField;
        }
        private set
        {
            father_FirstNameField = value;
        }
    }

    /// <remarks/>
    public string? Father_LastName
    {
        get
        {
            return father_LastNameField;
        }
        private set
        {
            father_LastNameField = value;
        }
    }

    /// <remarks/>
    public string? Mother_FirstName
    {
        get
        {
            return mother_FirstNameField;
        }
        private set
        {
            mother_FirstNameField = value;
        }
    }

    /// <remarks/>
    public string? Mother_LastName
    {
        get
        {
            return mother_LastNameField;
        }
        private set
        {
            mother_LastNameField = value;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public string? FullName
    {
        get
        {
            return fullNameField;
        }
        private set
        {
            fullNameField = value;
        }
    }
    /// <summary>
    /// کد پستی
    /// </summary>
    public string? PostalCode
    {
        get
        {
            return postalCodeField;
        }
        private set
        {
            postalCodeField = value;
        }
    }

    /// <summary>
    /// جنسیت
    /// </summary>
    public DO_CODED_TEXT? Gender
    {
        get
        {
            return genderField;
        }
        private set
        {
            genderField = value;
        }
    }

    /// <summary>
    /// شغل
    /// </summary>
    public DO_CODED_TEXT? Job
    {
        get
        {
            return jobField;
        }
        private set
        {
            jobField = value;
        }
    }

    /// <summary>
    /// توضیحات شغلی
    /// </summary>
    public string? JobDescribtion
    {
        get
        {
            return jobDescribtionField;
        }
        private set
        {
            jobDescribtionField = value;
        }
    }

    /// <summary>
    /// آدرس کامل
    /// </summary>
    public string? FullAddress
    {
        get
        {
            return fullAddressField;
        }
        private set
        {
            fullAddressField = value;
        }
    }

    /// <summary>
    /// محل زندگی
    /// </summary>
    public HighLevelAreaVO? LivingPlaceArea
    {
        get
        {
            return livingPlaceAreaField;
        }
        private set
        {
            livingPlaceAreaField = value;
        }
    }

    /// <summary>
    /// شناسه کارت
    /// </summary>
    public string? IDCardNumber
    {
        get
        {
            return iDCardNumberField;
        }
        private set
        {
            iDCardNumberField = value;
        }
    }

    /// <remarks/>
    public HighLevelAreaVO? IDIssueArea
    {
        get
        {
            return iDIssueAreaField;
        }
        private set
        {
            iDIssueAreaField = value;
        }
    }

    /// <remarks/>
    public string? HomeTel
    {
        get
        {
            return homeTelField;
        }
        private set
        {
            homeTelField = value;
        }
    }

    /// <remarks/>
    public string? MobileNumber
    {
        get
        {
            return mobileNumberField;
        }
        private set
        {
            mobileNumberField = value;
        }
    }

    /// <remarks/>
    public DO_CODED_TEXT? EducationLevel
    {
        get
        {
            return educationLevelField;
        }
        private set
        {
            educationLevelField = value;
        }
    }

    /// <remarks/>
    public string? FirstName
    {
        get
        {
            return firstNameField;
        }
        private set
        {
            firstNameField = value;
        }
    }

    /// <remarks/>
    public string? LastName
    {
        get
        {
            return lastNameField;
        }
        private set
        {
            lastNameField = value;
        }
    }

    /// <remarks/>
    public string? NationalCode
    {
        get
        {
            return nationalCodeField;
        }
        private set
        {
            nationalCodeField = value;
        }
    }
    /// <summary>
    /// شماره تلفن همراه فرد.
    /// </summary>
    public string? PhoneNumber { get; set; }

    //Added in 2023/01/11 after Dr. Nasimi's request in 1401/11/17
    /// <summary>
    /// زبان
    /// </summary>
    public DO_CODEABLE_CONCEPT? Languages
    {
        get
        {
            return languages;
        }
        private set
        {
            languages = value;
        }
    }

    //Added in 2023/01/11 after Dr. Nasimi's request in 1401/11/17
    private BasicDeathDetailsVO? _deathDetail;
    /// <summary>
    /// 
    /// </summary>
    public BasicDeathDetailsVO? DeathDetail
    {
        get
        {
            return _deathDetail;
        }
        private set
        {
            _deathDetail = value;
        }
    }

    //Added in 2023/01/11 after Dr. Nasimi's request in 1401/11/17
    private BirthVo? _birthDetail;
    /// <summary>
    /// 
    /// </summary>
    public BirthVo? BirthDetail
    {
        get
        {
            return _birthDetail;
        }
        private set
        {
            _birthDetail = value;
        }
    }
}