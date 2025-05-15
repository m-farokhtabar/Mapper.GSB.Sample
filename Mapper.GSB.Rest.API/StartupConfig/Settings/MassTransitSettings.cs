namespace Mapper.GSB.Rest.API.StartupConfig.Settings;
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
}
