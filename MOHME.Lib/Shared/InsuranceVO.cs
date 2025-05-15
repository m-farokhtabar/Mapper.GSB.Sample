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
    public partial class InsuranceVO
    {

        private DO_QUANTITY insuranceContributionField;

        private DO_QUANTITY[] insuranceOtherCostsField;

        private DO_CODED_TEXT insurerField;

        private DO_CODED_TEXT insuranceBoxField;

        private string insuranceBookletSerialNumberField;

        private DO_DATE insuranceExpirationDateField;

        private string insuredNumberField;

        private DO_IDENTIFIER sHEBADField;

        /// <remarks/>
        public DO_QUANTITY InsuranceContribution
        {
            get
            {
                return insuranceContributionField;
            }
            set
            {
                insuranceContributionField = value;
            }
        }

        /// <remarks/>
        public DO_QUANTITY[] InsuranceOtherCosts
        {
            get
            {
                return insuranceOtherCostsField;
            }
            set
            {
                insuranceOtherCostsField = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public DO_CODED_TEXT Insurer
        {
            get
            {
                return insurerField;
            }
            set
            {
                insurerField = value;
            }
        }

        public DO_CODED_TEXT InsuranceBox
        {
            get
            {
                return insuranceBoxField;
            }
            set
            {
                insuranceBoxField = value;
            }
        }

        /// <remarks/>
        public string InsuranceBookletSerialNumber
        {
            get
            {
                return insuranceBookletSerialNumberField;
            }
            set
            {
                insuranceBookletSerialNumberField = value;
            }
        }

        /// <remarks/>
        public DO_DATE InsuranceExpirationDate
        {
            get
            {
                return insuranceExpirationDateField;
            }
            set
            {
                insuranceExpirationDateField = value;
            }
        }

        /// <remarks/>
        public string InsuredNumber
        {
            get
            {
                return insuredNumberField;
            }
            set
            {
                insuredNumberField = value;
            }
        }

        /// <remarks/>
        public DO_IDENTIFIER SHEBAD
        {
            get
            {
                return sHEBADField;
            }
            set
            {
                sHEBADField = value;
            }
        }
    }
}