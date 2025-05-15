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
    public partial class DO_INTERVALINT
    {

        private int? lowerValueField;

        private int? upperValueField;

        /// <remarks/>
        [XmlElement(IsNullable = true)]
        public int? lowerValue
        {
            get
            {
                return lowerValueField;
            }
            set
            {
                lowerValueField = value;
            }
        }

        /// <remarks/>
        [XmlElement(IsNullable = true)]
        public int? upperValue
        {
            get
            {
                return upperValueField;
            }
            set
            {
                upperValueField = value;
            }
        }
    }
}