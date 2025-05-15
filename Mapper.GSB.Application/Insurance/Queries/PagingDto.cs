namespace Mapper.GSB.Application.Insurance.Queries
{
    /// <summary>
    /// صفحه بندهی اطلاعات
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagingDto<T> where T : class
    {
        /// <summary>
        /// کل داده های موجود
        /// </summary>
        public int TotalCountOfRecords { get; init; }
        /// <summary>
        /// تعداد صفحات موجود
        /// </summary>
        public int TotalPages { get; init; }
        /// <summary>
        /// شماره صفحه
        /// </summary>
        public int PageNumber { get; init; }
        /// <summary>
        /// داده مورد نظر
        /// </summary>
        public T? Result { get; init; }
    }
}
