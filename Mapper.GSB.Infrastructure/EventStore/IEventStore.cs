using Mapper.GSB.Domain.SeedWorks;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper.GSB.Infrastructure.EventStore
{
    /// <summary>
    /// ثبت رویداد ها در پایگاه داده
    /// </summary>
    public interface IEventStore
    {
        /// <summary>
        /// ثبت رویداد های مورد نظر
        /// </summary>
        /// <param name="domainEvents"></param>
        public Task SaveAsync(ImmutableQueue<Event> domainEvents);
    }
}
