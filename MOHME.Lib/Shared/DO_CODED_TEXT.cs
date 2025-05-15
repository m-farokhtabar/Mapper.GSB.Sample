using System.Diagnostics;
using System.Numerics;

namespace MOHME.Lib.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "2.0.50727.42")]
    [Serializable()]
    [DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(Namespace = "http://thrita.behdasht.gov.ir/ClinicalClass/")]
    public partial class DO_CODED_TEXT
    {

        private string? valueField;

        private string? terminology_idField;

        private string? coded_stringField;

        /// <remarks/>
        public string? Value
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

        /// <remarks/>
        public string? Terminology_id
        {
            get
            {
                return terminology_idField;
            }
            set
            {
                terminology_idField = value;
            }
        }

        /// <remarks/>
        public string? Coded_string
        {
            get
            {
                return coded_stringField;
            }
            set
            {
                coded_stringField = value;
            }
        }
        public DO_CODED_TEXT() { }

        public DO_CODED_TEXT(string codedString, string value, string terminologyID)
        {
            this.Coded_string = codedString;
            this.Value = value;
            this.Terminology_id = terminologyID;
        }
    }
}