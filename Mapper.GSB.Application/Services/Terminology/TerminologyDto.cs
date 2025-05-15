using System.Text.Json;

namespace Mapper.GSB.Application.Services.Terminology;

/// <summary>
/// اطلاعات کلی یک ترمینولوژی
/// </summary>
public class TerminologyDto
{
    /// <summary>
    /// مقدار دهی اولیه لیست ها
    /// </summary>
    public TerminologyDto()
    {
        CodeDetails = new List<TerminologyCodeDetailsDto>();
        Valueset_URL = "";
        Valueset_Version = "";
        ConceptDefinition_Code = "";
    }
    /// <summary>
    /// شناسه ترمینولوژی
    /// </summary>
    public long Id { get; set; }
    /// <summary>
    /// آدرس مجموعه کد ترمینولوژی
    /// </summary>
    public string Valueset_URL { get; set; }
    /// <summary>
    /// نسخه مجموعه
    /// </summary>
    public string Valueset_Version { get; set; }
    /// <summary>
    /// کد مورد نظر
    /// </summary>
    public string ConceptDefinition_Code { get; set; }
    /// <summary>
    /// اطلاعات جانبی یک کد مثل زبان یا نمایش آن
    /// </summary>
    public List<TerminologyCodeDetailsDto>? CodeDetails { get; set; }
    /// <summary>
    /// لیست خصوصیات مورد نیاز این کد
    /// </summary>
    public string? Property { get; set; }
    /// <summary>
    /// لیست خصوصیات مورد نیاز این کد
    /// </summary>
    public List<TerminologyPropertyDto>? Properties => !string.IsNullOrWhiteSpace(Property) ? JsonSerializer.Deserialize<List<TerminologyPropertyDto>>(Property) : null;
}
