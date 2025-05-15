namespace Mapper.GSB.Domain.SeedWorks;

/// <summary>
/// مدل برای ایجاد موجودیت
/// </summary>
public abstract class Entity
{
    /// <summary>
    /// فقط جهت
    /// entityframework
    /// </summary>
    protected private Entity()
    {

    }
    /// <summary>
    /// ایجاد موجودیت
    /// </summary>
    public Entity(DateTime? createDate)
    {
        CreatedDate = createDate ?? DateTime.Now;
        ModifiedDate = CreatedDate;
        RowVersion = null;
    }
    /// <summary>
    /// تاریخ و زمان ایجاد
    /// </summary>
    public DateTime CreatedDate { get; protected set; }
    /// <summary>
    /// تاریخ آخرین ویرایش
    /// </summary>
    public DateTime ModifiedDate { get; protected set; }
    /// <summary>
    /// نسخه رکورد جهت ثبت اطلاعات به صورت خوشبینانه
    /// </summary>
    public byte[]? RowVersion { get; private set; }
}
