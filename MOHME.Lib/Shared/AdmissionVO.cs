using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MOHME.Lib.Shared
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.1")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://thrita.behdasht.gov.ir/VM/")]
    public partial class AdmissionVO
    {

        private DO_CODEABLE_CONCEPT arrivalModeField;

        private List<HealthcareProviderVO> otherParticipationField;

        private DO_IDENTIFIER eMSIDField;

        private List<DateTimePointVO> otherDateTimeField;

        private DO_DATE admissionDateField;

        private DO_TIME admissionTimeField;

        private DO_CODED_TEXT admissionTypeField;

        private string medicalRecordNumberField;

        private OrganizationVO instituteField;

        private DO_CODED_TEXT reasonForEncounterField;

        private HealthcareProviderVO admittingDoctorField;

        private HealthcareProviderVO referringDoctorField;

        private HealthcareProviderVO attendingDoctorField;

        private HospitalWardVO admissionWardField;

        private LocationVO patientLocationField;
        private List<DO_IDENTIFIER> otherIDsField;
        /// <remarks/>
        public DO_CODEABLE_CONCEPT ArrivalMode
        {
            get
            {
                return arrivalModeField;
            }
            set
            {
                arrivalModeField = value;
            }
        }

        /// <remarks/>
        public List<HealthcareProviderVO> OtherParticipation
        {
            get
            {
                return otherParticipationField;
            }
            set
            {
                otherParticipationField = value;
            }
        }

        /// <remarks/>
        public DO_IDENTIFIER EMSID
        {
            get
            {
                return eMSIDField;
            }
            set
            {
                eMSIDField = value;
            }
        }

        /// <remarks/>
        public List<DateTimePointVO> OtherDateTime
        {
            get
            {
                return otherDateTimeField;
            }
            set
            {
                otherDateTimeField = value;
            }
        }

        /// <remarks/>

        public DO_DATE AdmissionDate
        {
            get
            {
                return admissionDateField;
            }
            set
            {
                admissionDateField = value;
            }
        }

        /// <remarks/>
        public DO_TIME AdmissionTime
        {
            get
            {
                return admissionTimeField;
            }
            set
            {
                admissionTimeField = value;
            }
        }


        public DO_CODED_TEXT AdmissionType
        {
            get
            {
                return admissionTypeField;
            }
            set
            {
                admissionTypeField = value;
            }
        }

        /// <remarks/>
        public string MedicalRecordNumber
        {
            get
            {
                return medicalRecordNumberField;
            }
            set
            {
                medicalRecordNumberField = value;
            }
        }

        /// <remarks/>
        public OrganizationVO Institute
        {
            get
            {
                return instituteField;
            }
            set
            {
                instituteField = value;
            }
        }

        /// <remarks/>
        public DO_CODED_TEXT ReasonForEncounter
        {
            get
            {
                return reasonForEncounterField;
            }
            set
            {
                reasonForEncounterField = value;
            }
        }

        /// <remarks/>
        public HealthcareProviderVO AdmittingDoctor
        {
            get
            {
                return admittingDoctorField;
            }
            set
            {
                admittingDoctorField = value;
            }
        }

        /// <remarks/>
        public HealthcareProviderVO ReferringDoctor
        {
            get
            {
                return referringDoctorField;
            }
            set
            {
                referringDoctorField = value;
            }
        }

        /// <remarks/>
        public HealthcareProviderVO AttendingDoctor
        {
            get
            {
                return attendingDoctorField;
            }
            set
            {
                attendingDoctorField = value;
            }
        }

        /// <remarks/>
        public HospitalWardVO AdmissionWard
        {
            get
            {
                return admissionWardField;
            }
            set
            {
                admissionWardField = value;
            }
        }

        /// <remarks/>
        public LocationVO PatientLocation
        {
            get
            {
                return patientLocationField;
            }
            set
            {
                patientLocationField = value;
            }
        }
        //Added in 2023/01/11 after Dr. Nasimi's request
        /// <summary>
        /// گواهی تولد، کروکی نیروی انتظامی، گواهی فوت و غیره
        /// </summary>
        public List<DO_IDENTIFIER> OtherIDs
        {
            get => otherIDsField;
            set => otherIDsField = value;
        }
    }
}