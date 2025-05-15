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
    public partial class GeographicalCoordinatesVO
    {

        private double? latitudeField;

        private double? longitudeField;

        /// <remarks/>
        [XmlElement(IsNullable = true)]
        public double? Latitude
        {
            get
            {
                return latitudeField;
            }
            set
            {
                latitudeField = value;
            }
        }

        /// <remarks/>
        [XmlElement(IsNullable = true)]
        public double? Longitude
        {
            get
            {
                return longitudeField;
            }
            set
            {
                longitudeField = value;
            }
        }
    }
}