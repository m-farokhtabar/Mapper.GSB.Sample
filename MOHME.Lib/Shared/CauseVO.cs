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
    public partial class CauseVO
    {

        private DO_CODED_TEXT causeField;

        private DO_CODED_TEXT statusField;

        /// <remarks/>
        public DO_CODED_TEXT Cause
        {
            get
            {
                return causeField;
            }
            set
            {
                causeField = value;
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
    }
}