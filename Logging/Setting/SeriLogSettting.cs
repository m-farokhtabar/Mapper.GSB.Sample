namespace Logging.Setting
{
    /// <summary>
    /// تنظیمات لاگ
    /// </summary>
    public class SeriLogSettting
    {
        /// <summary>
        /// سطوج مجاز پیام
        /// Console
        /// </summary>
        public Serilog.Events.LogEventLevel MinimumLevel { get; set; }
        /// <summary>
        /// تنظیمات
        /// Elastic
        /// </summary>
        public SeriLogSinkElastic? ElasticConfig { get; set; }
    }
    /// <summary>
    /// تنظیمات مربوط به
    /// Elastic
    /// </summary>
    public class SeriLogSinkElastic
    {
        /// <summary>
        /// آدرس سرویس
        /// Elastic
        /// </summary>
        public string NodeUris { get; set; } = string.Empty;
        /// <summary>
        /// نام ایندکس یا همان شاخصی که داده ها تحت این شاخص ذخیره می گردد
        /// </summary>
        public string IndexFormat { get; set; } = string.Empty;
        /// <summary>
        /// سطوح مجاز پیام جهت ارسال
        /// </summary>
        public Serilog.Events.LogEventLevel RestrictedToMinimumLevel { get; set; }
    }
}