using Mapper.GSB.Domain.InsuranceDataCoordinator;
using Mapper.GSB.Domain.SeedWork;
using Mapper.GSB.Domain.SeedWorks;
using Mapper.GSB.Infrastructure.Data;
using Mapper.GSB.Infrastructure.MessageDispatcher;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Mapper.GSB.Infrastructure.Domain
{
    /// <summary>
    /// <see cref="IUnitOfWork"/>
    /// </summary>
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly GSBDbContext dbContext;
        private readonly MessageDispatcherFactory messageDispatcherFactory;
        private IDbContextTransaction? transaction;
        /// <summary>
        /// ایجاد واحد کاری جهت هماهنگ سازی ثبت اطلاعات
        /// </summary>
        /// <param name="dbContext"></param>
        public UnitOfWork(GSBDbContext dbContext, MessageDispatcherFactory messageDispatcherFactory)
        {
            this.dbContext = dbContext;
            this.messageDispatcherFactory = messageDispatcherFactory;
            transaction = null;
        }
        /// <summary>
        /// <see cref="IUnitOfWork.CommitAsync"/>
        /// </summary>
        /// <returns></returns>
        /// <param name="cancellationToken"></param>
        /// <exception cref="NotImplementedException"></exception>
        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                /**
                 * این متغییر برای این استفاده می شود که اگر این متد چند بار صدا زده شد در حالتی که  می خواهیم داده های رویداد های داخلی نیز با داده های موجودیت اصلی با هم ذخیره شود به ازای هر بار صدا زدن یک تراکنش ایجاد نکند
                 * در عمل فقط اولین بار که این متد صدا زده می شود این تراکنش ایجاد شده و در نهایت بقیه متد ها داخلی که آن را صدا می زنند فقط داده های خود را ثبت میکنند 
                 **/
                bool currentCreateTransaction = false;
                if (transaction is null)
                {
                    transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken).ConfigureAwait(false);
                    currentCreateTransaction = true;
                }
                List<AggregateRoot> aggregates = dbContext.ChangeTracker.Entries<AggregateRoot>().Select(x => x.Entity).ToList();
                List<Event> events = GetEvents(aggregates);
                //به علت همزمانی بهتر است اینجا باشد
                ClearAllEvents(aggregates);
                
                await dbContext.SaveChangesAsync(cancellationToken);

                if (currentCreateTransaction)
                {
                    await transaction.CommitAsync(cancellationToken);
                    //ارسال رویداده های خارجی توسط سرویس صف که اینجا ربیت هستش                    
                    await PublishAllExternalEvents(events, messageDispatcherFactory.GetDispatcher(MessageDispatcherType.External));
                }
            }
            catch (Exception)
            {
                if (transaction is not null)
                    await transaction.RollbackAsync(cancellationToken);
                throw;
            }
            finally
            {
                if (transaction is not null)
                {
                    transaction.Dispose();
                    transaction = null;
                }
            }
        }
        /// <summary>
        /// دریافت تمام رویداد ها
        /// </summary>
        /// <param name="aggregates"></param>
        /// <returns></returns>
        private List<Event> GetEvents(List<AggregateRoot>? aggregates)
        {
            List<Event> events = new();
            if (aggregates?.Count > 0)
                events.AddRange(aggregates.Where(x => x?.Events.Count() > 0).SelectMany(x => x.Events).ToList());
            return events;
        }
        /// <summary>
        /// پاک کردن رویداد ها
        /// </summary>
        /// <param name="aggregates"></param>
        private void ClearAllEvents(List<AggregateRoot>? aggregates)
        {
            if (aggregates?.Count > 0)
                foreach (var aggregate in aggregates)
                    aggregate.ClearEvents();
        }
        /// <summary>
        /// ارسال تمام رویداد هایی که به صورت خارجی ارسال می گردد
        /// </summary>
        private static async Task PublishAllExternalEvents(List<Event> events, IMessageDispatcher messageDispatcher)
        {
            if (events?.Count > 0)
            {
                foreach (var @event in events)
                {
                    switch (@event)
                    {
                        case PersonInsuranceDataRecievedEvent e:
                            await messageDispatcher.Publish(e);
                            break;
                        case PersonInsuranceDataSentToGSBServiceSucceessfullyEvent e:
                            await messageDispatcher.Publish(e);
                            break;
                    }
                }
            }
        }        
    }
}
