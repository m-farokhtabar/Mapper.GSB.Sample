using Logging.Setting;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using Serilog.Exceptions;

namespace Logging
{
    /// <summary>
    /// تنظیمات لاگ
    /// </summary>
    public static class LoggingConfiguration
    {
        /// <summary>
        /// تنظیمات مربوط به لاگ با
        /// Serilog - console and elastic
        /// </summary>
        /// <remarks>
        /// <para>
        /// برای تنظیمات بایستی در فایل 
        /// appSetting
        /// مدخل زیر را داشته باشیم
        /// SerilogSetting
        /// </para>
        /// <para>
        /// پکیج های 
        /// Serilog.AspNetCore/Serilog.Sinks.Elasticsearch/Serilog.Enrichers.ClientInfo/Serilog.Enrichers.Environment/Serilog.Exceptions/Serilog.Sinks.Elasticsearch
        /// مورد نیاز است
        /// </para>
        /// </remarks>
        public static Action<HostBuilderContext, IServiceProvider, LoggerConfiguration> SeriLogConfiguration =>
               (context, services, configuration) =>
               {
                   var Setting = context.Configuration.GetSection("SeriLogSettting").Get<SeriLogSettting>()!;
                   configuration
                   .MinimumLevel.Is(Setting.MinimumLevel)
                   .ReadFrom.Services(services)
                   .Enrich.FromLogContext()
                   .Enrich.WithExceptionDetails()
                   .Enrich.WithMachineName()
                   .Enrich.WithEnvironmentName()
                   .Enrich.WithEnvironmentUserName()
                   .Enrich.WithProcessName()
                   .Enrich.WithProcessId()
                   .Enrich.WithCorrelationId()
                   .Enrich.WithClientIp()                                      
                   .WriteTo.Console()
                   .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(Setting.ElasticConfig!.NodeUris))
                   {
                       AutoRegisterTemplate = true,
                       AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv7,
                       //باید با این پارامتر باشد در غیر صورت لاگ عمل نمی کند
                       BatchAction = ElasticOpType.Create,
                       //logevent <= پیش فرض
                       TypeName = null,
                       IndexFormat = Setting.ElasticConfig.IndexFormat,
                       MinimumLogEventLevel = Setting.ElasticConfig.RestrictedToMinimumLevel
                   });
               };
    }
}
