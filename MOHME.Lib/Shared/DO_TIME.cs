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
    public partial class DO_TIME
    {

        private string iSOStringField;

        private int? hourField;

        private int? minuteField;

        private int? secondField;

        /// <remarks/>
        public string ISOString
        {
            get
            {
                return iSOStringField;
            }
            set
            {
                iSOStringField = value;
            }
        }

        /// <remarks/>
        [XmlElement(IsNullable = true)]
        public int? Hour
        {
            get
            {
                return hourField;
            }
            set
            {
                hourField = value;
            }
        }

        /// <remarks/>
        [XmlElement(IsNullable = true)]
        public int? Minute
        {
            get
            {
                return minuteField;
            }
            set
            {
                minuteField = value;
            }
        }

        /// <remarks/>
        [XmlElement(IsNullable = true)]
        public int? Second
        {
            get
            {
                return secondField;
            }
            set
            {
                secondField = value;
            }
        }
    }
}