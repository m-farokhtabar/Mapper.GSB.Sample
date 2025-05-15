namespace Mapper.GSB.Rest.API.StartupConfig.Applications
{
    /// <summary>
    /// اجیازه دسترسی به سرویس
    /// </summary>
    public static class CorsAllowAnyApplicationExtension
    {
        /// <summary>
        /// اجازه دسترسی فراخوانی سرویس ها از طریق مرورگر و از هر سایتی
        /// </summary>
        /// <param name="App"></param>
        public static void UseCorsAllowAny(this IApplicationBuilder App)
        {
            App.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
        }
    }
}
