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
    public partial class DO_QUANTITY
    {

        private double? magnitudeField;

        private string? magnitudeStatusField;

        private string? unitField;

        /// <remarks/>
        [XmlElement(IsNullable = true)]
        public double? Magnitude
        {
            get
            {
                return magnitudeField;
            }
            set
            {
                magnitudeField = value;
            }
        }

        /// <remarks/>
        public string? MagnitudeStatus
        {
            get
            {
                return magnitudeStatusField;
            }
            set
            {
                magnitudeStatusField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string? Unit
        {
            get
            {
                return unitField;
            }
            set
            {
                unitField = value;
            }
        }
    }
}