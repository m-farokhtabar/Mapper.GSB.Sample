using MOHME.Lib.OpenEHRBaseClasses;
using MOHME.Lib.Shared;

namespace MOHME.Lib.Prescription
{
    /// <summary>
    /// 
    /// </summary>
    public class PrescriptionCommonCompositionDataModel : EHRCommonCompositionDataModel
    {


        private AdmissionVO admissionField;

        private List<InsuranceVO> insuranceField;

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
        public List<InsuranceVO> Insurance
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
    }
}