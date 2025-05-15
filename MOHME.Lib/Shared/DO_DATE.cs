using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Xml.Serialization;

namespace MOHME.Lib.Shared
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.1")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://thrita.behdasht.gov.ir/VM/")]
    public partial class DO_DATE
    {

        private int? yearField;

        private int? monthField;

        private int? dayField;
            
        private string iSOStringField;

        /// <remarks/>
        [XmlElement(IsNullable = true)]
        public int? Year
        {
            get
            {
                return yearField;
            }
            set
            {
                yearField = value;
            }
        }

        /// <remarks/>
        [XmlElement(IsNullable = true)]
        public int? Month
        {
            get
            {
                return monthField;
            }
            set
            {
                monthField = value;
            }
        }

        /// <remarks/>
        [XmlElement(IsNullable = true)]
        public int? Day
        {
            get
            {
                return dayField;
            }
            set
            {
                dayField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
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
        /// <summary>
        /// نبدیل به تاریخ میلادی
        /// </summary>
        /// <returns></returns>
        public DateTime? ToDateTime()
        {
            PersianCalendar pc = new PersianCalendar();
            if (Year.HasValue && Month.HasValue && Day.HasValue)
                return pc.ToDateTime(Year.Value, Month.Value, Day.Value, 0, 0, 0, 0);
            else
                return null;
        }
    }
}