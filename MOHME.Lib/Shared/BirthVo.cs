namespace MOHME.Lib.Shared
{
    public class BirthVo
    {
        //Added in 2023/01/11 after Dr. Nasimi's request in 1401/11/17
        private DO_IDENTIFIER _personID;
        public DO_IDENTIFIER PersonID
        {
            get
            {
                return _personID;
            }
            set
            {
                _personID = value;
            }
        }

        //Added in 2023/01/11 after Dr. Nasimi's request in 1401/11/17
        private int _birthOrder;
        public int BirthOrder
        {
            get
            {
                return _birthOrder;
            }
            set
            {
                _birthOrder = value;
            }
        }
        //Added in 2023/01/11 after Dr. Nasimi's request in 1401/11/17
        private DO_QUANTITY _labourSecondStageDuration;
        public DO_QUANTITY LabourSecondStageDuration
        {
            get
            {
                return _labourSecondStageDuration;
            }
            set
            {
                _labourSecondStageDuration = value;
            }
        }

        //Added in 2023/01/11 after Dr. Nasimi's request in 1401/11/17
        private DO_CODED_TEXT _birthMode;
        public DO_CODED_TEXT BirthMode
        {
            get
            {
                return _birthMode;
            }
            set
            {
                _birthMode = value;
            }
        }
        //Added in 2023/01/11 after Dr. Nasimi's request in 1401/11/17
        private DO_CODEABLE_CONCEPT _presentingPart;
        public DO_CODEABLE_CONCEPT PresentingPart
        {
            get
            {
                return _presentingPart;
            }
            set
            {
                _presentingPart = value;
            }
        }
        //Added in 2023/01/11 after Dr. Nasimi's request in 1401/11/17
        private DO_CODEABLE_CONCEPT _babyOutcome;
        public DO_CODEABLE_CONCEPT BabyOutcome
        {
            get
            {
                return _babyOutcome;
            }
            set
            {
                _babyOutcome = value;
            }
        }
        //Added in 2023/01/11 after Dr. Nasimi's request in 1401/11/17
        private DO_CODED_TEXT _gender;
        public DO_CODED_TEXT Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
            }
        }
        private DO_DATE_TIME _birthDateTime;
        public DO_DATE_TIME BirthDateTime
        {
            get
            {
                return _birthDateTime;
            }
            set
            {
                _birthDateTime = value;
            }
        }
        private DO_CODEABLE_CONCEPT _birthPlace;
        public DO_CODEABLE_CONCEPT BirthPlace
        {
            get
            {
                return _birthPlace;
            }
            set
            {
                _birthPlace = value;
            }
        }
        private DO_QUANTITY _gestationalAge;
        public DO_QUANTITY GestationalAge
        {
            get
            {
                return _gestationalAge;
            }
            set
            {
                _gestationalAge = value;
            }
        }
        private string _apgarDescription;
        public string ApgarDescription
        {
            get
            {
                return _apgarDescription;
            }
            set
            {
                _apgarDescription = value;
            }
        }
        private DO_CODEABLE_CONCEPT _birthComplication;
        public DO_CODEABLE_CONCEPT BirthComplication
        {
            get
            {
                return _birthComplication;
            }
            set
            {
                _birthComplication = value;
            }
        }

        private DO_QUANTITY _birthHeight;
        public DO_QUANTITY BirthHeight
        {
            get
            {
                return _birthHeight;
            }
            set
            {
                _birthHeight = value;
            }
        }

        private DO_QUANTITY _birthWeight;
        public DO_QUANTITY BirthWeight
        {
            get
            {
                return _birthWeight;
            }
            set
            {
                _birthWeight = value;
            }
        }
        private DO_QUANTITY _headCircumference;
        public DO_QUANTITY HeadCircumference
        {
            get
            {
                return _headCircumference;
            }
            set
            {
                _headCircumference = value;
            }
        }
        private string _labourDescription;
        public string LabourDescription
        {
            get
            {
                return _labourDescription;
            }
            set
            {
                _labourDescription = value;
            }
        }
    }
}