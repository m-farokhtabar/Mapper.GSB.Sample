namespace Mapper.GSB.Infrastructure.MessageDispatcher;

/// <summary>
/// نوع ارسال پیام
/// </summary>
internal enum MessageDispatcherType
{
    /// <summary>
    /// ارسال پیام داخلی
    /// </summary>
    Internal,
    /// <summary>
    /// ارسلا پیام به صورت خارجی
    /// </summary>
    External
}
