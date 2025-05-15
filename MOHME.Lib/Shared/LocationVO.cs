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
    public partial class LocationVO
    {

        private string nameField;

        private DO_CODED_TEXT typeField;

        private GeographicalCoordinatesVO coordinationField;

        private HighLevelAreaVO areaAddressField;

        private string fullAddressField;

        /// <remarks/>
        public string Name
        {
            get
            {
                return nameField;
            }
            set
            {
                nameField = value;
            }
        }

        /// <remarks/>
        public DO_CODED_TEXT Type
        {
            get
            {
                return typeField;
            }
            set
            {
                typeField = value;
            }
        }

        /// <remarks/>
        public GeographicalCoordinatesVO Coordination
        {
            get
            {
                return coordinationField;
            }
            set
            {
                coordinationField = value;
            }
        }

        /// <remarks/>
        public HighLevelAreaVO AreaAddress
        {
            get
            {
                return areaAddressField;
            }
            set
            {
                areaAddressField = value;
            }
        }

        /// <remarks/>
        public string FullAddress
        {
            get
            {
                return fullAddressField;
            }
            set
            {
                fullAddressField = value;
            }
        }
    }
}