namespace Mapper.GSB.Infrastructure.DDR;

/// <summary>
/// تنظیمات مربوط به نحوه اتصال به ریپو
/// DDR
/// </summary>
public interface IDDRRepositorySettings
{
    #region انواع خروجی بر اساس استاندارد
    /// <summary>
    /// نوع خروجی داده های ریپو
    /// فقط شناسه
    /// </summary>
    string PreferMinimal { get; }
    /// <summary>
    /// نوع خروجی داده های ریپو
    /// همه داده
    /// </summary>
    string PreferRepresentation { get; }
    #endregion
}
