using Services.Authorization;
using Services.ExceptionManager;
using System.Security.Claims;
using static Services.ExceptionManager.Resources.ExceptionsMessages;

namespace Mapper.GSB.Rest.API.StartupConfig.Services.Authorization
{
    /// <summary>
    /// بدست آوردن اطلاعات دسترسی کاربر
    /// </summary>
    public class AuthorizedUserDetails : IAuthorizedUserDetails
    {
        private readonly IHttpContextAccessor HttpContextAccessor;
        /// <summary>
        /// دریافت سرویس 
        /// Context
        /// جهت بدست آوردن اطلاعات کاربر
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        public AuthorizedUserDetails(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }
        /// <summary>
        /// شناسه کاربر
        /// </summary>
        public Guid UserId
        {
            get
            {
                try
                {
                    string? Id = HttpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                    if (!string.IsNullOrWhiteSpace(Id))
                        return Guid.Parse(Id);
                    else
                        throw new ManualException(User_is_not_authenticated, ExceptionType.UnAuthorized, "Authenticated");
                }
                catch (Exception Ex)
                {
                    throw new ManualException(User_is_not_authenticated, ExceptionType.UnAuthorized, "Authenticated", Ex);
                }
            }

        }
        /// <summary>
        /// نقش های کاربر
        /// </summary>
        public string[]? Roles => HttpContextAccessor.HttpContext?.User?.Claims.Where(x => x.Type == ClaimTypes.Role)?.Select(x => x.Value)?.ToArray();
        /// <summary>
        /// شناسه سازمان کاربر
        /// </summary>
        public string? OrganizationId => HttpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type == "OrganizationIdentifier")?.Value;
    }
}
