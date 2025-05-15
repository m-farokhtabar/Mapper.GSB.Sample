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
    public partial class SpecimenDetailsVO
    {

        private DO_CODED_TEXT specimenTissueTypeField;

        private DO_CODED_TEXT adequacyForTestingField;

        private DO_CODED_TEXT collectionProcedureField;

        private DO_DATE dateofCollectionField;

        private DO_TIME timeofCollectionField;

        private string specimenIdentifierField;

        /// <remarks/>
        public DO_CODED_TEXT SpecimenTissueType
        {
            get
            {
                return specimenTissueTypeField;
            }
            set
            {
                specimenTissueTypeField = value;
            }
        }

        /// <remarks/>
        public DO_CODED_TEXT AdequacyForTesting
        {
            get
            {
                return adequacyForTestingField;
            }
            set
            {
                adequacyForTestingField = value;
            }
        }

        /// <remarks/>
        public DO_CODED_TEXT CollectionProcedure
        {
            get
            {
                return collectionProcedureField;
            }
            set
            {
                collectionProcedureField = value;
            }
        }

        /// <remarks/>
        public DO_DATE DateofCollection
        {
            get
            {
                return dateofCollectionField;
            }
            set
            {
                dateofCollectionField = value;
            }
        }

        /// <remarks/>
        public DO_TIME TimeofCollection
        {
            get
            {
                return timeofCollectionField;
            }
            set
            {
                timeofCollectionField = value;
            }
        }

        /// <remarks/>
        public string SpecimenIdentifier
        {
            get
            {
                return specimenIdentifierField;
            }
            set
            {
                specimenIdentifierField = value;
            }
        }
    }
}