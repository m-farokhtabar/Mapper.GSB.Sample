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
    public partial class MedicationPrescriptionRowVO
    {

        private DO_CODEABLE_CONCEPT asNeededField;

        private DO_CODED_TEXT priorityField;

        private DO_CODED_TEXT substitutionField;

        private DO_CODEABLE_CONCEPT siteField;

        private DO_CODEABLE_CONCEPT methodField;

        private DO_CODEABLE_CONCEPT reasonCodeField;

        private string patientInstructionField;

        private IngredientVO[] ingredientField;

        private DO_CODED_TEXT shapeField;

        private DO_CODED_TEXT drugNameField;

        private DO_CODED_TEXT productCodeField;

        private string drugNameDescriptionField;

        private DO_QUANTITY dosageField;

        private DO_CODED_TEXT frequencyField;

        private DO_CODED_TEXT routeField;

        private string descriptionField;

        private DO_QUANTITY totalNumberField;

        /// <remarks/>
        public DO_CODEABLE_CONCEPT AsNeeded
        {
            get
            {
                return asNeededField;
            }
            set
            {
                asNeededField = value;
            }
        }

        /// <remarks/>
        public DO_CODED_TEXT Priority
        {
            get
            {
                return priorityField;
            }
            set
            {
                priorityField = value;
            }
        }

        /// <remarks/>
        public DO_CODED_TEXT Substitution
        {
            get
            {
                return substitutionField;
            }
            set
            {
                substitutionField = value;
            }
        }

        /// <remarks/>
        public DO_CODEABLE_CONCEPT Site
        {
            get
            {
                return siteField;
            }
            set
            {
                siteField = value;
            }
        }

        /// <remarks/>
        public DO_CODEABLE_CONCEPT Method
        {
            get
            {
                return methodField;
            }
            set
            {
                methodField = value;
            }
        }

        /// <remarks/>
        public DO_CODEABLE_CONCEPT ReasonCode
        {
            get
            {
                return reasonCodeField;
            }
            set
            {
                reasonCodeField = value;
            }
        }

        /// <remarks/>
        public string PatientInstruction
        {
            get
            {
                return patientInstructionField;
            }
            set
            {
                patientInstructionField = value;
            }
        }

        /// <remarks/>
        public IngredientVO[] Ingredient
        {
            get
            {
                return ingredientField;
            }
            set
            {
                ingredientField = value;
            }
        }

        /// <remarks/>
        public DO_CODED_TEXT Shape
        {
            get
            {
                return shapeField;
            }
            set
            {
                shapeField = value;
            }
        }

        /// <remarks/>
        public DO_CODED_TEXT DrugName
        {
            get
            {
                return drugNameField;
            }
            set
            {
                drugNameField = value;
            }
        }

        /// <remarks/>
        public DO_CODED_TEXT ProductCode
        {
            get
            {
                return productCodeField;
            }
            set
            {
                productCodeField = value;
            }
        }

        /// <remarks/>
        public string DrugNameDescription
        {
            get
            {
                return drugNameDescriptionField;
            }
            set
            {
                drugNameDescriptionField = value;
            }
        }

        /// <remarks/>
        public DO_QUANTITY Dosage
        {
            get
            {
                return dosageField;
            }
            set
            {
                dosageField = value;
            }
        }

        /// <remarks/>
        public DO_CODED_TEXT Frequency
        {
            get
            {
                return frequencyField;
            }
            set
            {
                frequencyField = value;
            }
        }

        /// <remarks/>
        public DO_CODED_TEXT Route
        {
            get
            {
                return routeField;
            }
            set
            {
                routeField = value;
            }
        }

        /// <remarks/>
        public string Description
        {
            get
            {
                return descriptionField;
            }
            set
            {
                descriptionField = value;
            }
        }

        /// <remarks/>
        public DO_QUANTITY TotalNumber
        {
            get
            {
                return totalNumberField;
            }
            set
            {
                totalNumberField = value;
            }
        }
    }
}