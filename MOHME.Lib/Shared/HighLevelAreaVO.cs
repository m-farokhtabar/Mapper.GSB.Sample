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
    public partial class HighLevelAreaVO
    {

        private DO_CODED_TEXT nationalAreaCodeField;

        private DO_CODED_TEXT countryField;

        private DO_CODED_TEXT provinceField;

        private DO_CODED_TEXT cityField;

        private DO_CODED_TEXT townField;

        private DO_CODED_TEXT districtField;

        private DO_CODED_TEXT ruralAreaField;

        private DO_CODED_TEXT villageField;

        /// <remarks/>
        public DO_CODED_TEXT NationalAreaCode
        {
            get
            {
                return nationalAreaCodeField;
            }
            set
            {
                nationalAreaCodeField = value;
            }
        }

        /// <remarks/>
        public DO_CODED_TEXT Country
        {
            get
            {
                return countryField;
            }
            set
            {
                countryField = value;
            }
        }

        /// <remarks/>
        public DO_CODED_TEXT Province
        {
            get
            {
                return provinceField;
            }
            set
            {
                provinceField = value;
            }
        }

        /// <remarks/>
        public DO_CODED_TEXT City
        {
            get
            {
                return cityField;
            }
            set
            {
                cityField = value;
            }
        }

        /// <remarks/>
        public DO_CODED_TEXT Town
        {
            get
            {
                return townField;
            }
            set
            {
                townField = value;
            }
        }

        /// <remarks/>
        public DO_CODED_TEXT District
        {
            get
            {
                return districtField;
            }
            set
            {
                districtField = value;
            }
        }

        /// <remarks/>
        public DO_CODED_TEXT RuralArea
        {
            get
            {
                return ruralAreaField;
            }
            set
            {
                ruralAreaField = value;
            }
        }

        /// <remarks/>
        public DO_CODED_TEXT Village
        {
            get
            {
                return villageField;
            }
            set
            {
                villageField = value;
            }
        }
    }
}