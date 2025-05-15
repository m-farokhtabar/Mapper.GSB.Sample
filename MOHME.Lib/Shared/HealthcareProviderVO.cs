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
    public partial class HealthcareProviderVO
    {

        private DO_CODED_TEXT specialtyField;

        private DO_IDENTIFIER identifierField;

        private DO_CODED_TEXT roleField;

        private ElectronicContactVO[] contactPointField;

        private string firstNameField;

        private string lastNameField;

        private string fullNameField;
        // Start Added By Mohsen Barahmand in 2021-06-16  Darman Request
        private List<CredentialsVO> _credentials = new List<CredentialsVO>();

        /// <summary>
        /// مچوزها
        /// </summary>
        /// <returns></returns>
        public List<CredentialsVO> Credentials
        {
            get
            {
                return _credentials;
            }
            set
            {
                _credentials = value;
            }
        }
        // End
        public DO_CODED_TEXT Specialty
        {
            get
            {
                return specialtyField;
            }
            set
            {
                specialtyField = value;
            }
        }

        /// <remarks/>
        public DO_IDENTIFIER Identifier
        {
            get
            {
                return identifierField;
            }
            set
            {
                identifierField = value;
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
        public ElectronicContactVO[] ContactPoint
        {
            get
            {
                return contactPointField;
            }
            set
            {
                contactPointField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string FirstName
        {
            get
            {
                return firstNameField;
            }
            set
            {
                firstNameField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string LastName
        {
            get
            {
                return lastNameField;
            }
            set
            {
                lastNameField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string FullName
        {
            get
            {
                return fullNameField;
            }
            set
            {
                fullNameField = value;
            }
        }
    }
}