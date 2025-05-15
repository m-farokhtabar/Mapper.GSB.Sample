namespace MOHME.Lib.Shared
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "2.0.50727.42")]
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(Namespace = "http://thrita.behdasht.gov.ir/VM/")]
    public partial class SignatureVO
    {





        private byte[] _SignatureValue;
        private string _SignatureMethod;
        private DateTime? _TimeStamp;
        private byte[] _Certificate;
        private string _SubjectDN;
        private string _Thumbprint;
        private string _OrderType; // ?? Canonicalization Method
        private DO_CODED_TEXT _SignerRole;



        /// <remarks/>
        public byte[] SignatureValue
        {
            get
            {
                return _SignatureValue;
            }
            set
            {
                _SignatureValue = value;
            }
        }

        /// <remarks/>
        public string SignatureMethod
        {
            get
            {
                return _SignatureMethod;
            }
            set
            {
                _SignatureMethod = value;
            }
        }

        /// <remarks/>
        public DateTime? TimeStamp
        {
            get
            {
                return _TimeStamp;
            }
            set
            {
                _TimeStamp = value;
            }
        }

        /// <remarks/>
        public byte[] Certificate
        {
            get
            {
                return _Certificate;
            }
            set
            {
                _Certificate = value;
            }
        }

        /// <remarks/>
        public string SubjectDN
        {
            get
            {
                return _SubjectDN;
            }
            set
            {
                _SubjectDN = value;
            }
        }

        /// <remarks/>
        public string Thumbprint
        {
            get
            {
                return _Thumbprint;
            }
            set
            {
                _Thumbprint = value;
            }
        }

        /// <remarks/>
        public string OrderType
        {
            get
            {
                return _OrderType;
            }
            set
            {
                _OrderType = value;
            }
        }

        /// <remarks/>
        public DO_CODED_TEXT SignerRole
        {
            get
            {
                return _SignerRole;
            }
            set
            {
                _SignerRole = value;
            }
        }




        // ??
        // Public Function test() As String
        // Dim x_signed_xml As System.Security.Cryptography.Xml.SignedXml = New SignedXml()
        // Dim s As New System.Security.Cryptography.SignatureDescription

        // x_signed_xml.Ad()
        // End Function

    }
}