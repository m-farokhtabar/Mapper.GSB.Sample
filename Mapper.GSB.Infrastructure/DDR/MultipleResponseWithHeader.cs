using MassTransit;
namespace Mapper.GSB.Infrastructure.DDR;
/// <summary>
/// این کلاس کمک می کند تا بتوانیم برای یک درخواست چندین جواب را داشته باشیم البته در نسخه های جدید 
/// Massstransit
/// این مشکل حل شده
/// </summary>
/// <remarks>masstransit ver (8,net6) support this issue and it will no longer need to use this method</remarks>
public static class MultipleResponseWithHeader
{
    /// <summary>
    /// Send a request and wait for multiple response types
    /// </summary>
    /// <typeparam name="TRequest">Request type</typeparam>
    /// <param name="RequestHandler">request handler which is created by IRequestClient.Create</param>
    /// <typeparam name="T1">First type of response expected</typeparam>
    /// <typeparam name="T2">Second type of response expected</typeparam>
    /// <param name="callback">Context setting callback</param>
    /// <returns>One of the expected response types or timeout exception</returns>
    public static async Task<Response<T1, T2>> GetResponse<TRequest, T1, T2>(this RequestHandle<TRequest> RequestHandler, Action<SendContext<TRequest>> callback)
        where TRequest : class
        where T1 : class
        where T2 : class
    {
        if (callback != null)
            RequestHandler.UseExecute(callback);

        Task<Response<T1>> Response1 = RequestHandler.GetResponse<T1>(false);
        Task<Response<T2>> Response2 = RequestHandler.GetResponse<T2>();

        var Response = await Task.WhenAny(Response1, Response2).ConfigureAwait(false);
        await Response.ConfigureAwait(false);

        return new Response<T1, T2>(Response1, Response2);
    }
}
