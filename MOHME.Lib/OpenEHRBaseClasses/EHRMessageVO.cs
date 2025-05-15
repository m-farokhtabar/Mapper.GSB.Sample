using MOHME.Lib.Prescription;

namespace MOHME.Lib.OpenEHRBaseClasses
{
    /// <summary>
    /// کلاس جنریک داده پیام سرویس های سپاس
    /// </summary>

    public class EHRMessageVO<TComposition> : EHRMessageHeaderVO where TComposition : PrescriptionCommonCompositionDataModel
    {

        /// <summary>
        /// داده پیام سرویس
        /// </summary>
        public virtual TComposition Composition { get; set; }
    }
}