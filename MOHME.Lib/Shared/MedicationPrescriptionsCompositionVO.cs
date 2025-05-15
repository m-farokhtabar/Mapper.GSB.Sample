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
    public partial class MedicationPrescriptionsCompositionVO
    {

        private AdmissionVO admissionField;

        private InsuranceVO insuranceField;

        private MedicationPrescriptionsVO medicationPrescriptionsField;

        private DiagnosisVO[] diagnosisField;

        /// <remarks/>
        public AdmissionVO Admission
        {
            get
            {
                return admissionField;
            }
            set
            {
                admissionField = value;
            }
        }

        /// <remarks/>
        public InsuranceVO Insurance
        {
            get
            {
                return insuranceField;
            }
            set
            {
                insuranceField = value;
            }
        }

        /// <remarks/>
        public MedicationPrescriptionsVO MedicationPrescriptions
        {
            get
            {
                return medicationPrescriptionsField;
            }
            set
            {
                medicationPrescriptionsField = value;
            }
        }

        /// <remarks/>
        public DiagnosisVO[] Diagnosis
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
    }
}