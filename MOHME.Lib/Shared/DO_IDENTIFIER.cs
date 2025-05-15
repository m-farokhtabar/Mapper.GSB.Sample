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
    public partial class DO_IDENTIFIER
    {

        private string? issuerField;

        private string? assignerField;

        private string? idField;

        private string? typeField;

        /// <remarks/>
        [XmlAttribute()]
        public string? Issuer
        {
            get
            {
                return issuerField;
            }
            set
            {
                issuerField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string? Assigner
        {
            get
            {
                return assignerField;
            }
            set
            {
                assignerField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string? ID
        {
            get
            {
                return idField;
            }
            set
            {
                idField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string? Type
        {
            get
            {
                return typeField;
            }
            set
            {
                typeField = value;
            }
        }
    }
}