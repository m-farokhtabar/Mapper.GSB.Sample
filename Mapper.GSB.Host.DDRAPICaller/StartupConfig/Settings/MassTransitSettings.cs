namespace Mapper.GSB.Host.DDRAPICaller.StartupConfig.Settings;
/// <summary>
/// تنظیمات مربوط به سرویس مدیریت پیام
/// </summary>
public class MassTransitSettings
{
    /// <summary>
    /// آدرس 
    /// Rabbit
    /// </summary>
    public string RabbitMQConnection { get; set; } = String.Empty;
    /// <summary>
    /// زمان انتظار جهت دریافت پاسخ
    /// به ثانیه
    /// </summary>
    public int TimeOutForCommand { get; set; }
    /// <summary>
    /// در صف باقی بماند
    /// </summary>
    public bool Durable { get; set; }
    /// <summary>
    /// در زمان شروع تمام آیتم های صف را خالی کند
    /// </summary>
    public bool PurgeOnStartup { get; set; }
}
