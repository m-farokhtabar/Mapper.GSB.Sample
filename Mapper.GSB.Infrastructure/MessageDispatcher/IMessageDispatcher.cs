using Mapper.GSB.Application.SeedWorks;
using Mapper.GSB.Domain.SeedWorks;

namespace Mapper.GSB.Infrastructure.MessageDispatcher;

/// <summary>
/// رابط جهت ارسال رویداد ها
/// </summary>
public interface IMessageDispatcher
{
    /// <summary>
    /// ارسال پیام برای رویداد مورد نظر
    /// </summary>
    /// <param name="event"></param>
    /// <returns></returns>
    Task Publish<T>(T @event) where T: Event;
}
