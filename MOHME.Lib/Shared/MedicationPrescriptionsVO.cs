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
    public partial class MedicationPrescriptionsVO
    {

        private ProviderInfoVO prescriberField;

        private DO_DATE issueDateField;

        private DO_TIME issueTimeField;

        private string ePrescriptionIDField;

        private MedicationPrescriptionRowVO[] ordersField;

        private DO_DATE expiryDateField;

        private int? repeatsField;

        /// <remarks/>
        public ProviderInfoVO Prescriber
        {
            get
            {
                return prescriberField;
            }
            set
            {
                prescriberField = value;
            }
        }

        /// <remarks/>
        public DO_DATE IssueDate
        {
            get
            {
                return issueDateField;
            }
            set
            {
                issueDateField = value;
            }
        }

        /// <remarks/>
        public DO_TIME IssueTime
        {
            get
            {
                return issueTimeField;
            }
            set
            {
                issueTimeField = value;
            }
        }

        /// <remarks/>
        public string ePrescriptionID
        {
            get
            {
                return ePrescriptionIDField;
            }
            set
            {
                ePrescriptionIDField = value;
            }
        }

        /// <remarks/>
        public MedicationPrescriptionRowVO[] Orders
        {
            get
            {
                return ordersField;
            }
            set
            {
                ordersField = value;
            }
        }

        /// <remarks/>
        public DO_DATE ExpiryDate
        {
            get
            {
                return expiryDateField;
            }
            set
            {
                expiryDateField = value;
            }
        }

        /// <remarks/>
        [XmlElement(IsNullable = true)]
        public int? Repeats
        {
            get
            {
                return repeatsField;
            }
            set
            {
                repeatsField = value;
            }
        }
    }
}