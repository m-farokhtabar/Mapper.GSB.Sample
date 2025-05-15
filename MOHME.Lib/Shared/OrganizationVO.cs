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
    public partial class OrganizationVO
    {

        private string nameField;

        private DO_IDENTIFIER idField;

        private DO_CODED_TEXT typeField;

        private HighLevelAreaVO locationField;

        private string portablePositionField;

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
        public DO_IDENTIFIER ID
        {
            get
            {
                return idField;
            }
            set
            {
                idField = value;
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
        public HighLevelAreaVO Location
        {
            get
            {
                return locationField;
            }
            set
            {
                locationField = value;
            }
        }

        /// <remarks/>
        public string PortablePosition
        {
            get
            {
                return portablePositionField;
            }
            set
            {
                portablePositionField = value;
            }
        }
    }
}