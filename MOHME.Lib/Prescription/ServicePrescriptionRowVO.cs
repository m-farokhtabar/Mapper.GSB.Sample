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
    public partial class ServicePrescriptionRowVO
    {

        private bool? doNotPerformField;

        private DO_CODED_TEXT serviceField;

        private int? serviceAmountField;

        private DO_CODED_TEXT methodField;

        private AnatomicalLocationVO[] anatomicalLocationField;

        private DO_CODEABLE_CONCEPT[] asNeededField;

        private DO_CODEABLE_CONCEPT[] reasonCodeField;

        private string noteField;

        private string patientInstructionField;

        /// <remarks/>
        [XmlElement(IsNullable = true)]
        public bool? DoNotPerform
        {
            get
            {
                return doNotPerformField;
            }
            set
            {
                doNotPerformField = value;
            }
        }

        /// <remarks/>
        public DO_CODED_TEXT Service
        {
            get
            {
                return serviceField;
            }
            set
            {
                serviceField = value;
            }
        }

        /// <remarks/>
        [XmlElement(IsNullable = true)]
        public int? ServiceAmount
        {
            get
            {
                return serviceAmountField;
            }
            set
            {
                serviceAmountField = value;
            }
        }

        /// <remarks/>
        public DO_CODED_TEXT Method
        {
            get
            {
                return methodField;
            }
            set
            {
                methodField = value;
            }
        }

        /// <remarks/>
        public AnatomicalLocationVO[] AnatomicalLocation
        {
            get
            {
                return anatomicalLocationField;
            }
            set
            {
                anatomicalLocationField = value;
            }
        }

        /// <remarks/>
        public DO_CODEABLE_CONCEPT[] AsNeeded
        {
            get
            {
                return asNeededField;
            }
            set
            {
                asNeededField = value;
            }
        }

        /// <remarks/>
        public DO_CODEABLE_CONCEPT[] ReasonCode
        {
            get
            {
                return reasonCodeField;
            }
            set
            {
                reasonCodeField = value;
            }
        }

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
        public string PatientInstruction
        {
            get
            {
                return patientInstructionField;
            }
            set
            {
                patientInstructionField = value;
            }
        }
    }
}