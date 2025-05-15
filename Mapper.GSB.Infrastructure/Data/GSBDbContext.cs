using Mapper.GSB.Domain.InsuranceDataCoordinator;
using Mapper.GSB.Infrastructure.Data.Config;
using Mapper.GSB.Infrastructure.EventStore;
using Microsoft.EntityFrameworkCore;
using Services.ExceptionManager;
using Services.ExceptionManager.Resources;

namespace Mapper.GSB.Infrastructure.Data
{
    /// <summary>
    /// مدیریت اتصال و ارتباط با پایگاه داده
    /// </summary>
    public class GSBDbContext : DbContext, IDbSet
    {
        /// <summary>
        /// فقط برای
        /// Migration
        /// </summary>
        public GSBDbContext()
        {

        }
        /// <summary>
        /// این سازنده فقط برای زمان راه اندازی استفاده می شود
        /// AddDbContext
        /// </summary>
        /// <param name="Options"></param>
        public GSBDbContext(DbContextOptions<GSBDbContext> Options) : base(Options)
        {
        }
        /// <summary>
        /// اطلاعات هماهنگ کننده
        /// </summary>
        public DbSet<PersonInsuranceDataCoordinator> PersonsInsurancesDataCoordinator { get; set; }
        /// <summary>
        /// رویداد ها
        /// </summary>
        public DbSet<EventModel> Events { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonInsuranceDataCoordinatorConfig).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }
        /// <summary>
        /// تنظیمات مربوط به ارتباط با پایگاه داده
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //زمانی که می خواهیم مایگرشن را انجام دهیم این کد  فعال می شود
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Data Source =.; Initial Catalog = Mapper.GSB; Integrated Security = true;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
        /// <summary>
        /// <see cref="IDbSet.Get{TEntity}"/>
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public DbSet<TEntity>? Get<TEntity>() where TEntity : class
        {
            return typeof(TEntity).Name switch
            {
                nameof(PersonInsuranceDataCoordinator) => (DbSet<TEntity>)(object)PersonsInsurancesDataCoordinator,
                nameof(EventModel) => (DbSet<TEntity>)(object)Events,
                _ => throw new ManualException(ExceptionsMessages.there_is_no_such_an_entity.Replace("{0}", typeof(TEntity).Name), ExceptionType.InternalServerError, nameof(GSBDbContext) + ".Get<TEntity>()")
            };
        }
    }
}
