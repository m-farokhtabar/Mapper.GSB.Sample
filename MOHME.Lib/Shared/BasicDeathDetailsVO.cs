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
    public partial class BasicDeathDetailsVO
    {

        private DO_DATE deathDateField;

        private DO_TIME deathTimeField;

        private DO_CODED_TEXT deathLocationField;

        private DO_CODED_TEXT hospitalWardField;

        private CauseVO[] causeField;

        /// <remarks/>
        public DO_DATE DeathDate
        {
            get
            {
                return deathDateField;
            }
            set
            {
                deathDateField = value;
            }
        }

        /// <remarks/>
        public DO_TIME DeathTime
        {
            get
            {
                return deathTimeField;
            }
            set
            {
                deathTimeField = value;
            }
        }

        /// <remarks/>
        public DO_CODED_TEXT DeathLocation
        {
            get
            {
                return deathLocationField;
            }
            set
            {
                deathLocationField = value;
            }
        }

        /// <remarks/>
        public DO_CODED_TEXT HospitalWard
        {
            get
            {
                return hospitalWardField;
            }
            set
            {
                hospitalWardField = value;
            }
        }

        /// <remarks/>
        [XmlArrayItem(IsNullable = false)]
        public CauseVO[] Cause
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

        //Added in 2023/01/11 after Dr. Nasimi's request in 1401/11/17
        private bool _deceased;
        public bool Deceased
        {
            get
            {
                return _deceased;
            }
            set
            {
                _deceased = value;
            }
        }
    }
}