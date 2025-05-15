using MOHME.Lib.Shared;
using Newtonsoft.Json;

namespace MOHME.Lib.Prescription
{
    /// <summary>
    /// اطلاعات پرونده نسخه پیچی فرد
    /// </summary>
    [Serializable, JsonObject]
    public partial class MedicationPrescriptionsCompositionVO : PrescriptionCommonCompositionDataModel
    {
        private List<DiagnosisVO> diagnosisField;
        /// <summary>
        /// 
        /// </summary>
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

        private MedicationPrescriptionsVO medicationPrescriptionsField;
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


    }
}