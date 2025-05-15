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
    public partial class AnatomicalLocationVO
    {

        private DO_CODED_TEXT bodySiteField;

        private DO_CODED_TEXT lateralityField;

        /// <remarks/>
        public DO_CODED_TEXT BodySite
        {
            get
            {
                return bodySiteField;
            }
            set
            {
                bodySiteField = value;
            }
        }

        /// <remarks/>
        public DO_CODED_TEXT Laterality
        {
            get
            {
                return lateralityField;
            }
            set
            {
                lateralityField = value;
            }
        }
    }
}