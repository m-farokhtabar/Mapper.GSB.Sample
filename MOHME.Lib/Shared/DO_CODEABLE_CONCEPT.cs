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
    public partial class DO_CODEABLE_CONCEPT
    {

        private string textField;

        private DO_CODED_TEXT codingField;

        /// <remarks/>
        public string Text
        {
            get
            {
                return textField;
            }
            set
            {
                textField = value;
            }
        }

        /// <remarks/>
        public DO_CODED_TEXT Coding
        {
            get
            {
                return codingField;
            }
            set
            {
                codingField = value;
            }
        }
    }
}