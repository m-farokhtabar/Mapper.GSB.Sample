namespace Mapper.GSB.Application.Services.Terminology;

/// <summary>
/// جزییات کد ترمینولوژی مورد نظر
/// </summary>
public class TerminologyCodeDetailsDto
{
    /// <summary>
    /// زبان نمایش اطلاعات
    /// </summary>
    public string Language { get; set; } = String.Empty;
    /// <summary>
    /// نام نمایش اطلاعات
    /// </summary>
    public string? Display { get; set; }
}
