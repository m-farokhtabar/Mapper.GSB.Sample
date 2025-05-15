namespace MOHME.Lib.Shared
{
    public partial class CredentialsVO
    {
        private DO_CODED_TEXT _credential;

        public DO_CODED_TEXT Credential
        {
            get
            {
                return _credential;
            }
            set
            {
                _credential = value;
            }
        }

        private DO_IDENTIFIER _issuingInstitution;

        public DO_IDENTIFIER IssuingInstitution
        {
            get
            {
                return _issuingInstitution;
            }
            set
            {
                _issuingInstitution = value;
            }
        }

        private DO_DATE _startDate = new DO_DATE();

        public DO_DATE StartDate
        {
            get
            {
                return _startDate;
            }
            set
            {
                _startDate = value;
            }
        }

        private DO_DATE _expiryDate = new DO_DATE();

        public DO_DATE ExpiryDate
        {
            get
            {
                return _expiryDate;
            }
            set
            {
                _expiryDate = value;
            }
        }
    }
}