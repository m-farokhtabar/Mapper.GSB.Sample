using System.ComponentModel.DataAnnotations;

namespace Mapper.GSB.Application.Services.Terminology;

/// <summary>
/// اطلاعات تکمیلی کد تعریف شده
/// </summary>
/// <remarks>
/// Each code system can define one or more concept properties. Each concept defined by the code system may have one or more values for each concept property defined by the code system
/// <para>
/// Tracking administrative status (inactive, deprecation date)
/// Providing additional statements about the meaning of the concept
/// Defining structured relationships with other concepts in the code system
/// Assigning scoring values to the concepts</para>
/// </remarks>
public class TerminologyPropertyDto
{
    /// <summary>
    /// شناسه خاصیت
    /// </summary>
    public string Code { get; set; } = string.Empty;
    /// <summary>
    /// مقدار خاصیت
    /// </summary>
    public string Value { get; set; } = string.Empty;
    /// <summary>
    /// نوع مقداری خصوصیت
    /// </summary>
    /// <remarks>اجباری</remarks>
    public PropertyType Type { get; set; }
}
/// <summary>
/// نوع مقدار یک خاصیت
/// </summary>
public enum PropertyType : byte
{
    /// <summary>
    /// code (internal reference)
    /// </summary>
    [Display(Name = "نوع شناسه داخلی")]
    Code,
    /// <summary>
    /// Coding (external reference)
    /// </summary>
    [Display(Name = "نوع شناسه خارجی")]
    Coding,
    /// <summary>
    /// The property value is a string.
    /// </summary>
    [Display(Name = "نوع متنی")]
    String,
    /// <summary>
    /// The property value is a string (often used to assign ranking values to concepts for supporting score assessments).
    /// </summary>
    [Display(Name = "نوع عددی")]
    Integer,
    /// <summary>
    /// The property value is a boolean true | false.
    /// </summary>
    [Display(Name = "نوع منطقی")]
    Boolean,
    /// <summary>
    /// The property is a date or a date + time.
    /// </summary>
    [Display(Name = "نوع تاریخ")]
    DateTime,
    /// <summary>
    /// The property value is a decimal number.
    /// </summary>
    [Display(Name = "نوع اعضاری")]
    Decimal
}
