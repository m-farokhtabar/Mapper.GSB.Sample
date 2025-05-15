using MediatR;
using Services.Authorization;

namespace Mapper.GSB.Application.Authorization;
/// <summary>
/// انجام بررسی دسترسی 
/// </summary>
/// <typeparam name="TRequest">درخواست</typeparam>
/// <typeparam name="TResponse">جواب</typeparam>
public class CommandQueryAuhtorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IAuthorizationService authorizationService;
    /// <summary>
    /// بررسی سطح دسترسی
    /// </summary>
    /// <param name="authorizationService">سرویس بررسی سطح دسترسی</param>
    public CommandQueryAuhtorizationBehavior(IAuthorizationService authorizationService)
    {        
        this.authorizationService = authorizationService;
    }
    /// <summary>
    /// انجام پیش عملیات قبل از انجام عملیات اصلی
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <param name="next"></param>
    /// <returns></returns>
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {        
        await authorizationService.HasUserPermissionToUseThisOperation(request.GetType().Name).ConfigureAwait(false);
        return await next();
    }
}
