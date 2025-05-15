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
    public partial class DO_ORDINAL
    {

        private DO_CODED_TEXT? symbolField;

        private int? valueField;

        /// <remarks/>
        public DO_CODED_TEXT? Symbol
        {
            get
            {
                return symbolField;
            }
            set
            {
                symbolField = value;
            }
        }

        /// <remarks/>
        [XmlElement(IsNullable = true)]
        public int? Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }
}