using MOHME.Lib.Shared;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MOHME.Lib.Prescription
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.1")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://thrita.behdasht.gov.ir/VM/")]
    public partial class ServicePrescriptionsCompositionVO : PrescriptionCommonCompositionDataModel
    {
        private List<DiagnosisVO> diagnosisField;
        public List<DiagnosisVO> Diagnosis
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
        private ServicePrescriptionsVO servicePrescriptionsField;
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