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
    public partial class DateTimePointVO
    {

        private DO_CODED_TEXT pointField;

        private DO_DATE pointDateField;

        private DO_TIME pointTimeField;

        /// <remarks/>
        public DO_CODED_TEXT Point
        {
            get
            {
                return pointField;
            }
            set
            {
                pointField = value;
            }
        }

        /// <remarks/>
        public DO_DATE PointDate
        {
            get
            {
                return pointDateField;
            }
            set
            {
                pointDateField = value;
            }
        }

        /// <remarks/>
        public DO_TIME PointTime
        {
            get
            {
                return pointTimeField;
            }
            set
            {
                pointTimeField = value;
            }
        }
    }
}