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
    public partial class IngredientVO
    {

        private DO_CODEABLE_CONCEPT itemField;

        private DO_CODED_TEXT roleField;

        private DO_QUANTITY amountField;

        private DO_QUANTITY amountMaxField;

        /// <remarks/>
        public DO_CODEABLE_CONCEPT Item
        {
            get
            {
                return itemField;
            }
            set
            {
                itemField = value;
            }
        }

        /// <remarks/>
        public DO_CODED_TEXT Role
        {
            get
            {
                return roleField;
            }
            set
            {
                roleField = value;
            }
        }

        /// <remarks/>
        public DO_QUANTITY Amount
        {
            get
            {
                return amountField;
            }
            set
            {
                amountField = value;
            }
        }

        /// <remarks/>
        public DO_QUANTITY AmountMax
        {
            get
            {
                return amountMaxField;
            }
            set
            {
                amountMaxField = value;
            }
        }
    }
}