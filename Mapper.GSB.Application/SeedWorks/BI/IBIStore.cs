namespace Mapper.GSB.Application.SeedWorks.BI;
/// <summary>
/// مدیریت اطلاعات 
/// BI
/// در پایگاه داده
/// </summary>
public interface IBIStore
{
    /// <summary>
    /// درج اطلاعات در پایگاه داده
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task Insert(BIModel entity);
    /// <summary>
    /// به روز رسانی اطلاعات
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task Update(BIModel entity);
    /// <summary>
    /// به روز رسانی وضعیت آمار قسمت مربوط به داده های ارسال شده به
    /// GSB
    /// </summary>
    /// <param name="dataCoordinatorId"></param>
    /// <param name="registerDate"></param>
    /// <returns></returns>
    Task UpdateGSB(Guid dataCoordinatorId, DateTime? registerDate);
}