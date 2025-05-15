using Microsoft.EntityFrameworkCore;

namespace Mapper.GSB.Infrastructure.Data;

/// <summary>
/// تحویل دهنده موجودیت مورد نظر جهت اعمال تغییرات
/// </summary>
/// <typeparam name="T"></typeparam>
internal interface IDbSet
{
    /// <summary>
    /// دریافت موجودیت مورد نظر
    /// </summary>
    /// <typeparam name="T">نوع موجودیت مورد نظر</typeparam>
    /// <returns></returns>
    DbSet<TEntity>? Get<TEntity>() where TEntity : class;
}
