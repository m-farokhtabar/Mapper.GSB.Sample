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
    public partial class ServicePrescriptionsVO
    {

        private string noteField;

        private DO_CODED_TEXT statusField;

        private DO_CODED_TEXT intentField;

        private DO_CODEABLE_CONCEPT categoryField;

        private DO_CODED_TEXT priorityField;

        private DO_CODEABLE_CONCEPT locationCodeField;

        private SpecimenDetailsVO specimenField;

        private ProviderInfoVO prescriberField;

        private DO_DATE_TIME issueDateTimeField;

        private DO_IDENTIFIER ePrescriptionIDField;

        private ServicePrescriptionRowVO[] ordersField;

        private DO_DATE expiryDateField;

        private int? repeatsField;

        /// <remarks/>
        public string Note
        {
            get
            {
                return noteField;
            }
            set
            {
                noteField = value;
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
        public DO_CODED_TEXT Intent
        {
            get
            {
                return intentField;
            }
            set
            {
                intentField = value;
            }
        }

        /// <remarks/>
        public DO_CODEABLE_CONCEPT Category
        {
            get
            {
                return categoryField;
            }
            set
            {
                categoryField = value;
            }
        }

        /// <remarks/>
        public DO_CODED_TEXT Priority
        {
            get
            {
                return priorityField;
            }
            set
            {
                priorityField = value;
            }
        }

        /// <remarks/>
        public DO_CODEABLE_CONCEPT LocationCode
        {
            get
            {
                return locationCodeField;
            }
            set
            {
                locationCodeField = value;
            }
        }

        /// <remarks/>
        public SpecimenDetailsVO Specimen
        {
            get
            {
                return specimenField;
            }
            set
            {
                specimenField = value;
            }
        }

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
        public DO_DATE_TIME IssueDateTime
        {
            get
            {
                return issueDateTimeField;
            }
            set
            {
                issueDateTimeField = value;
            }
        }

        /// <remarks/>
        public DO_IDENTIFIER ePrescriptionID
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
        public ServicePrescriptionRowVO[] Orders
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