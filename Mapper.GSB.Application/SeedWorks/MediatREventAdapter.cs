using Mapper.GSB.Domain.SeedWorks;
using MediatR;

namespace Mapper.GSB.Application.SeedWorks
{
    /// <summary>
    /// ایجاد یک آداپتر جهت اینکه هسته سیستم که همان دامنه است به تکنولوژِی خاصی وابسته نشود
    /// برای قسمت رویداد ها
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="Event">رویداد مورد نظر</param>
    public record MediatREventAdapter<T>(T Event) : INotification where T : Event;
}
