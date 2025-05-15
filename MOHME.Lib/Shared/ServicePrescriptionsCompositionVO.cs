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
    public partial class ServicePrescriptionsCompositionVO
    {

        private DiagnosisVO[] diagnosisField;

        private AdmissionVO admissionField;

        private InsuranceVO insuranceField;

        private ServicePrescriptionsVO servicePrescriptionsField;

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
        public ServicePrescriptionsVO ServicePrescriptions
        {
            get
            {
                return servicePrescriptionsField;
            }
            set
            {
                servicePrescriptionsField = value;
            }
        }
    }
}