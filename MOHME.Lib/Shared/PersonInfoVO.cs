using Services.ExceptionManager;
using Services.ExceptionManager.Resources;
using Mapper.GSB.Share.Resource;
using MOHME.Lib.Helper;
using MOHME.Lib.Helper.Validator;
//using MOHME.Lib.Shared.SDKResources;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Reflection;

namespace MOHME.Lib.Shared
{
    /// <summary>
    /// اطلاعات هویتی بیمه شده
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.1")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://thrita.behdasht.gov.ir/VM/")]
    public partial class PersonInfoVO
    {
        /// <summary>
        ///فقط برای مبدل
        ///جی سان
        /// </summary>
        private PersonInfoVO()
        {

        }
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
        public PersonInfoVO(DO_IDENTIFIER personId, DO_CODED_TEXT? province, DO_CODED_TEXT? city, string? pictureB64, ElectronicContactVO[]? otherContacts, DO_IDENTIFIER[]? otherIdentifier, HighLevelAreaVO? birthPlaceArea, DO_CODED_TEXT? religion, DO_CODED_TEXT? maritalStatus,
                            DO_CODED_TEXT? nationality, DO_DATE birthDate, DO_TIME? birthTime, DO_CODED_TEXT? birthdateAccuracy, string? father_FirstName, string? father_LastName, string? mother_FirstName,
                            string? mother_LastName, string? fullName, string postalCode, DO_CODED_TEXT gender, DO_CODED_TEXT? job, string? jobDescribtion, string? fullAddress, HighLevelAreaVO? livingPlaceArea,
                            string? iDCardNumber, HighLevelAreaVO? iDIssueArea, string? homeTel, string? mobileNumber, DO_CODED_TEXT? educationLevel, string firstName, string lastName, string? nationalCode, DO_CODEABLE_CONCEPT? languages, BasicDeathDetailsVO? deathDetail, BirthVo? birthDetail)
        {
            Validate(personId, firstName, lastName, gender, birthDate, maritalStatus, province, city, postalCode, fullAddress, nationality, mobileNumber,father_FirstName, father_LastName,mother_FirstName,mother_LastName);
            personId.ID = personId!.ID!.Trim();
            personId.Type = !string.IsNullOrWhiteSpace(personId.Type) ? personId.Type.Trim() : personId.Type;
            PersonId = personId;
            Province = province;
            City = city;
            PictureB64 = pictureB64;
            this.otherContactsField = otherContacts;
            this.otherIdentifierField = otherIdentifier;
            this.birthPlaceAreaField = birthPlaceArea;
            this.religionField = religion;
            this.maritalStatusField = maritalStatus;
            this.nationalityField = nationality;
            this.birthDateField = birthDate;
            this.birthTimeField = birthTime;
            this.birthdateAccuracyField = birthdateAccuracy;
            this.father_FirstNameField = father_FirstName;
            this.father_LastNameField = father_LastName;
            this.mother_FirstNameField = mother_FirstName;
            this.mother_LastNameField = mother_LastName;
            this.fullNameField = fullName;
            this.postalCodeField = postalCode;
            this.genderField = gender;
            this.jobField = job;
            this.jobDescribtionField = jobDescribtion;
            this.fullAddressField = fullAddress;
            this.livingPlaceAreaField = livingPlaceArea;
            this.iDCardNumberField = iDCardNumber;
            this.iDIssueAreaField = iDIssueArea;
            this.homeTelField = homeTel;
            this.mobileNumberField = mobileNumber;
            this.educationLevelField = educationLevel;
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

        private DO_DATE birthDateField;

        private DO_TIME? birthTimeField;

        private DO_CODED_TEXT? birthdateAccuracyField;

        private string? father_FirstNameField;

        private string? father_LastNameField;

        private string? mother_FirstNameField;

        private string? mother_LastNameField;

        private string? fullNameField;

        private string postalCodeField;

        private DO_CODED_TEXT genderField;

        private DO_CODED_TEXT? jobField;

        private string? jobDescribtionField;

        private string? fullAddressField;

        private HighLevelAreaVO? livingPlaceAreaField;

        private string? iDCardNumberField;

        private HighLevelAreaVO? iDIssueAreaField;

        private string? homeTelField;

        private string? mobileNumberField;

        private DO_CODED_TEXT? educationLevelField;

        private string firstNameField;

        private string lastNameField;

        private string? nationalCodeField;
        private DO_CODEABLE_CONCEPT? languages;

        /// <summary>
        /// شناسه ملی فرد یا شناسه اتباع بیگانه یا پاسپورت  (مطابق با شناسه های حوزه سلامت)
        /// </summary>
        public DO_IDENTIFIER PersonId { get; private set; }
        /// <summary>
        /// استان بیمه شده
        /// </summary>
        public DO_CODED_TEXT? Province { get; private set; }
        /// <summary>
        /// شهر بیمه شده
        /// </summary>
        public DO_CODED_TEXT? City { get; private set; }
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
        //[Display(Name = "Birthdate", ResourceType = typeof(SDKMessages))]
        //[Required(ErrorMessageResourceName = "FieldRequiredError",
        //    ErrorMessageResourceType = typeof(SDKValidationMessages))]
        public DO_DATE BirthDate
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

        /// <remarks/>
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

        /// <remarks/>
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

        /// <remarks/>
        public string PostalCode
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

        /// <remarks/>
        public DO_CODED_TEXT Gender
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

        /// <remarks/>
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

        /// <remarks/>
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

        /// <remarks/>
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

        /// <remarks/>
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

        /// <remarks/>
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
        [XmlAttribute()]
        public string FirstName
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
        [XmlAttribute()]
        public string LastName
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
        [XmlAttribute()]
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
        //[Display(Name = "PhoneNumber", ResourceType = typeof(SDKMessages))]
        //[StringLength(256, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(SDKValidationMessages))]
        [JsonIgnore]
        //[PersianMobileNumberValidator]
        public string? PhoneNumber { get; set; }

        //Added in 2023/01/11 after Dr. Nasimi's request in 1401/11/17
        /// <summary>
        /// 
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
        /// <summary>
        /// اعتبار سنجی مقادیر 
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="gender"></param>
        /// <param name="birthDate"></param>
        /// <param name="maritalStatus"></param>
        /// <param name="province"></param>
        /// <param name="city"></param>
        /// <param name="postalCode"></param>
        /// <param name="fullAddress"></param>
        /// <param name="nationality"></param>
        /// <param name="mobileNumber"></param>
        /// <param name="fatherName"></param>
        /// <param name="fatherLastName"></param>
        /// <param name="motherName"></param>
        /// <param name="motherLastName"><</param>
        /// <exception cref="ManualException"></exception>
        private static void Validate(DO_IDENTIFIER? personId, string firstName, string lastName, DO_CODED_TEXT gender, DO_DATE birthDate, DO_CODED_TEXT? maritalStatus, 
                                     DO_CODED_TEXT? province, DO_CODED_TEXT? city, string postalCode, string? fullAddress, DO_CODED_TEXT? nationality, string? mobileNumber,string? fatherName, string? fatherLastName,
                                     string? motherName, string? motherLastName)
        {
            if (personId is not null)
                personId.Validate(Names.PersonInfoVO, Names.PersonInfoVO_PersonID, typeof(PersonInfoVO).FullName + "." + nameof(PersonId));
            else
                throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonInfoVO).Replace("{1}", Names.PersonInfoVO_PersonID), ExceptionType.InValid, typeof(PersonInfoVO).FullName + "." + nameof(PersonId));
            if (string.Equals(personId.Type, "National_Code", StringComparison.InvariantCultureIgnoreCase) && !NationalCodeValidator.IsValidIranianNationalCode(personId.ID))
                throw new ManualException(ExceptionsMessages.Data_is_not_valid_Value_is_wrong.Replace("{0}", Names.PersonInfoVO).Replace("{1}", Names.PersonInfoVO_PersonID), ExceptionType.InValid, typeof(PersonInfoVO).FullName + "." + nameof(PersonId));
            
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonInfoVO).Replace("{1}", Names.PersonInfoVO_FirstName), ExceptionType.InValid, typeof(PersonInfoVO).FullName + "." + nameof(FirstName));
            if (firstName.Length> 50)
                throw new ManualException(ExceptionsMessages.DATA_IS_NOT_VALID_FIELD_LENGTH_EXCEED.Replace("{0}", Names.PersonInfoVO).Replace("{1}", Names.PersonInfoVO_FirstName).Replace("{2}", "50"), ExceptionType.InValid, typeof(PersonInfoVO).FullName + "." + nameof(FirstName));

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonInfoVO).Replace("{1}", Names.PersonInfoVO_LastName), ExceptionType.InValid, typeof(PersonInfoVO).FullName + "." + nameof(LastName));
            if (lastName.Length > 50)
                throw new ManualException(ExceptionsMessages.DATA_IS_NOT_VALID_FIELD_LENGTH_EXCEED.Replace("{0}", Names.PersonInfoVO).Replace("{1}", Names.PersonInfoVO_LastName).Replace("{2}", "50"), ExceptionType.InValid, typeof(PersonInfoVO).FullName + "." + nameof(LastName));
            if (!string.IsNullOrWhiteSpace(fatherName) && fatherName.Length > 50)
                throw new ManualException(ExceptionsMessages.DATA_IS_NOT_VALID_FIELD_LENGTH_EXCEED.Replace("{0}", Names.PersonInfoVO).Replace("{1}", "Father Name").Replace("{2}", "50"), ExceptionType.InValid, typeof(PersonInfoVO).FullName + "." + nameof(Father_FirstName));
            if (!string.IsNullOrWhiteSpace(fatherLastName) &&  fatherLastName.Length > 50)
                throw new ManualException(ExceptionsMessages.DATA_IS_NOT_VALID_FIELD_LENGTH_EXCEED.Replace("{0}", Names.PersonInfoVO).Replace("{1}", "Father LastName").Replace("{2}", "50"), ExceptionType.InValid, typeof(PersonInfoVO).FullName + "." + nameof(Father_LastName));
            if (!string.IsNullOrWhiteSpace(motherName) && motherName.Length > 50)
                throw new ManualException(ExceptionsMessages.DATA_IS_NOT_VALID_FIELD_LENGTH_EXCEED.Replace("{0}", Names.PersonInfoVO).Replace("{1}", "Mother Name").Replace("{2}", "50"), ExceptionType.InValid, typeof(PersonInfoVO).FullName + "." + nameof(Mother_FirstName));
            if (!string.IsNullOrWhiteSpace(motherLastName) && motherLastName.Length > 50)
                throw new ManualException(ExceptionsMessages.DATA_IS_NOT_VALID_FIELD_LENGTH_EXCEED.Replace("{0}", Names.PersonInfoVO).Replace("{1}", "Mother LastName").Replace("{2}", "50"), ExceptionType.InValid, typeof(PersonInfoVO).FullName + "." + nameof(Mother_LastName));

            //mother
            if (gender is not null)
                gender.Validate(Names.PersonInfoVO, Names.PersonInfoVO_Gender, typeof(PersonInfoVO).FullName + "." + nameof(Gender));
            else
                throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonInfoVO).Replace("{1}", Names.PersonInfoVO_Gender), ExceptionType.InValid, typeof(PersonInfoVO).FullName + "." + nameof(Gender));

            if (birthDate is not null)
                birthDate.Validate(Names.PersonInfoVO, Names.PersonInfoVO_BirthDate, typeof(PersonInfoVO).FullName + "." + nameof(BirthDate));
            else
                throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonInfoVO).Replace("{1}", Names.PersonInfoVO_BirthDate), ExceptionType.InValid, typeof(PersonInfoVO).FullName + "." + nameof(BirthDate));

            if (maritalStatus is not null)
                maritalStatus.Validate(Names.PersonInfoVO, Names.PersonInfoVO_MaritalStatus, typeof(PersonInfoVO).FullName + "." + nameof(MaritalStatus));
            else
                throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonInfoVO).Replace("{1}", Names.PersonInfoVO_MaritalStatus), ExceptionType.InValid, typeof(PersonInfoVO).FullName + "." + nameof(MaritalStatus));

            if (string.IsNullOrWhiteSpace(postalCode))
                throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonInfoVO).Replace("{1}", Names.PersonInfoVO_PostalCode), ExceptionType.InValid, typeof(PersonInfoVO).FullName + "." + nameof(PostalCode));
            if (postalCode.Length != 10)
                throw new ManualException(ExceptionsMessages.Data_is_not_valid_Value_is_wrong.Replace("{0}", Names.PersonInfoVO).Replace("{1}", Names.PersonInfoVO_PostalCode), ExceptionType.InValid, typeof(PersonInfoVO).FullName + "." + nameof(PostalCode));

            //if (string.IsNullOrWhiteSpace(fullAddress))
            //    throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonInfoVO).Replace("{1}", Names.PersonInfoVO_FullAddress), ExceptionType.InValid, typeof(PersonInfoVO).FullName + "." + nameof(FullAddress));

            if (province is not null)
                province.Validate(Names.PersonInfoVO, Names.PersonInfoVO_Province, typeof(PersonInfoVO).FullName + "." + nameof(Province));
            else
                throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonInfoVO).Replace("{1}", Names.PersonInfoVO_Province), ExceptionType.InValid, typeof(PersonInfoVO).FullName + "." + nameof(Province));
            if (city is not null)
                city.Validate(Names.PersonInfoVO, Names.PersonInfoVO_City, typeof(PersonInfoVO).FullName + "." + nameof(City));
            else
                throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonInfoVO).Replace("{1}", Names.PersonInfoVO_City), ExceptionType.InValid, typeof(PersonInfoVO).FullName + "." + nameof(City));
            if (nationality is not null)
                nationality.Validate(Names.PersonInfoVO, Names.PersonInfoVO_Nationality, typeof(PersonInfoVO).FullName + "." + nameof(Nationality));


            if (string.IsNullOrWhiteSpace(mobileNumber))
            {
                //mobileNumber = "11111111111";
                throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.PersonInfoVO).Replace("{1}", Names.PersonInfoVO_Mobile), ExceptionType.InValid, typeof(PersonInfoVO).FullName + "." + nameof(MobileNumber));
            }
        }
    }
    //Added in 2023/01/11 after Dr. Nasimi's request in 1401/11/17
}