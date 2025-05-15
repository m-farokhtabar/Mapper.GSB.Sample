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
    public partial class DiagnosisVO
    {

        private DO_CODED_TEXT diagnosisField;

        private string commentField;

        private DO_CODED_TEXT statusField;

        private DO_DATE diagnosisDateField;

        private DO_TIME diagnosisTimeField;

        private DO_ORDINAL severityField;
        private DO_CODED_TEXT conditionVerificationStatus;
        private DO_CODED_TEXT conditionClinicalStatus;
        private DO_DATE_TIME resolutionDateTime;
        private List<AnatomicalLocationVO> bodySiteField;
        private DO_CODED_TEXT clinicalStatusField;
        private DO_CODED_TEXT verificationStatusField;
        /// <remarks/>
        public DO_CODED_TEXT Diagnosis
        {
            get
            {
                return diagnosisField;
            }
            set
            {
                diagnosisField = value;
            }
        }

        /// <remarks/>
        public string Comment
        {
            get
            {
                return commentField;
            }
            set
            {
                commentField = value;
            }
        }

        /// <remarks/>
        public DO_CODED_TEXT Status
        {
            get
            {
                return statusField;
            }
            set
            {
                statusField = value;
            }
        }

        /// <remarks/>
        public DO_DATE DiagnosisDate
        {
            get
            {
                return diagnosisDateField;
            }
            set
            {
                diagnosisDateField = value;
            }
        }

        /// <remarks/>
        public DO_TIME DiagnosisTime
        {
            get
            {
                return diagnosisTimeField;
            }
            set
            {
                diagnosisTimeField = value;
            }
        }

        /// <remarks/>
        public DO_ORDINAL Severity
        {
            get
            {
                return severityField;
            }
            set
            {
                severityField = value;
            }
        }
        //Added in 2023/01/11 after Dr. Nasimi's request
        /// <summary>
        /// https://www.hl7.org/fhir/valueset-condition-ver-status.html
        /// Thrita
        /// </summary>
        /// <example>
        /// Differential
        /// </example>

        public DO_CODED_TEXT ConditionVerificationStatus
        {
            get
            {
                return conditionVerificationStatus;
            }
            set
            {
                conditionVerificationStatus = value;
            }
        }
        //Added in 2023/01/11 after Dr. Nasimi's request
        /// <summary>
        /// https://www.hl7.org/fhir/valueset-condition-clinical.html
        /// Thrita
        /// </summary>
        /// <example>
        /// Relapse
        /// </example>
        public DO_CODED_TEXT ConditionClinicalStatus
        {
            get
            {
                return conditionClinicalStatus;
            }
            set
            {
                conditionClinicalStatus = value;
            }
        }

        //Added in 2023/01/11 after Dr. Nasimi's request
        /// <summary>
        /// 
        /// </summary>
        public DO_DATE_TIME ResolutionDateTime
        {
            get
            {
                return resolutionDateTime;
            }
            set
            {
                resolutionDateTime = value;
            }
        }
        //Added in 2023/01/11 after Dr. Nasimi's request
        /// <remarks/>
        public List<AnatomicalLocationVO> BodySite
        {
            get
            {
                return bodySiteField;
            }
            set
            {
                bodySiteField = value;
            }
        }
        //Added in 2023/01/21 after Dr. Nasimi's request
        /// <remarks/>
        public DO_CODED_TEXT ClinicalStatus
        {
            get
            {
                return clinicalStatusField;
            }
            set
            {
                clinicalStatusField = value;
            }
        }
        //Added in 2023/01/21 after Dr. Nasimi's request
        /// <remarks/>
        public DO_CODED_TEXT VerificationStatus
        {
            get
            {
                return verificationStatusField;
            }
            set
            {
                verificationStatusField = value;
            }
        }
    }
}