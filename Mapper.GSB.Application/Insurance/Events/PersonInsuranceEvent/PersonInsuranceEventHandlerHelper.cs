using Mapper.GSB.Domain.Insurance;
using Mapper.GSB.Domain.SeedWorks;

namespace Mapper.GSB.Application.Insurance.Events.PersonInsuranceEvent
{
    /// <summary>
    /// متدهای مورد نیاز و مشترک مابین تمامی 
    /// PersonInsurance Event Handlers 
    /// </summary>
    public class PersonInsuranceEventHandlerHelper
    {
        /// <summary>
        /// ایجاد موجودیت سند بیمه بر اساس زمانی که اطلاعات بیمه و فرد ثبت شده است
        /// </summary>
        /// <param name="event"></param>
        /// <returns></returns>
        public static PersonInsurance GetPersonInsurance(PersonInsuranceCreatedEvent @event)
        {
            Queue<Event> events = new();
            events.Enqueue(@event);
            return new(events);
        }
        /// <summary>
        /// ایجاد موجودیت سند بیمه بر اساس تمام رویدادهای موجود
        /// </summary>
        /// <param name="events"></param>
        /// <returns></returns>
        public static PersonInsurance GetPersonInsurance(Queue<Domain.SeedWorks.Event> events) => new (events);
    }
}
