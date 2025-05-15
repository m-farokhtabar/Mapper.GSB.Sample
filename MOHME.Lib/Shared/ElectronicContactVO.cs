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
    public partial class ElectronicContactVO
    {

        private DO_CODED_TEXT mediumTypeField;

        private DO_CODED_TEXT usageField;

        private string detailField;

        /// <remarks/>
        public DO_CODED_TEXT MediumType
        {
            get
            {
                return mediumTypeField;
            }
            set
            {
                mediumTypeField = value;
            }
        }

        /// <remarks/>
        public DO_CODED_TEXT Usage
        {
            get
            {
                return usageField;
            }
            set
            {
                usageField = value;
            }
        }

        /// <remarks/>
        public string Detail
        {
            get
            {
                return detailField;
            }
            set
            {
                detailField = value;
            }
        }
    }
}