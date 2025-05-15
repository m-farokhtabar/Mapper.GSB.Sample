namespace Mapper.GSB.Domain.SeedWork
{
    /// <summary>
    /// جهت یکپارچه سازی عملیات ها در پایگاه
    /// برای نوشتن استفاده می شود
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        ///اعمال تمامی تغییرات به صورت اتمیک
        ///به صورت ناهمگام
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task CommitAsync(CancellationToken cancellationToken = default);        
    }
}
