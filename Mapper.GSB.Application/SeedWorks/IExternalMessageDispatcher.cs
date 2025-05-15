using Mapper.GSB.Domain.SeedWorks;

namespace Mapper.GSB.Application.SeedWorks;

/// <summary>
/// ارسال رویداد از طریق سسیتم صف خارجی
/// </summary>
public interface IExternalMessageDispatcher
{
    /// <summary>
    /// ارسال پیام برای رویداد مورد نظر
    /// </summary>
    /// <param name="event"></param>
    /// <returns></returns>
    Task Publish<T>(T @event) where T : Event;
}
