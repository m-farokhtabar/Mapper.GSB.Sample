using Mapper.GSB.Rest.API.StartupConfig.Services.Authorization;
using Mapper.GSB.Rest.API.StartupConfig.Settings;
using Services.Authorization.StartupConfig;

namespace Mapper.GSB.Rest.API.StartupConfig.Services;
/// <summary>
/// تنظیمات سطح دسترسی
/// </summary>
public static class AuthenticationServiceExtension
{
    /// <summary>
    /// تنظیمات سطح دسترسی
    /// جهت دریافت توکن
    /// IDP
    /// </summary>
    /// <param name="services"></param>
    /// <param name="authSettings"></param>
    /// <param name="idpDbConnection"></param>
    /// <param name="userAccountDbConnection"></param>
    public static void ConfigureAuthentcation(this IServiceCollection services, AuthSettings authSettings, string idpDbConnection, string userAccountDbConnection)
    {
        services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    // URL of our identity server
                    options.Authority = authSettings.Authority;
                    // HTTPS required for the authority (defaults to true but disabled for development).
                    options.RequireHttpsMetadata = authSettings.RequireHttpsMetadata;
                    // the name of this API - note: matches the API resource name configured above
                    options.Audience = authSettings.Audience;
                });
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.ConfigureAuthorizationServices(idpDbConnection, userAccountDbConnection, authSettings, new AuthorizedUserDetails(services.BuildServiceProvider().GetRequiredService<IHttpContextAccessor>()));
    }
}
