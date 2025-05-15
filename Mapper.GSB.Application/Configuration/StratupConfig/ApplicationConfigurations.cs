using Mapper.GSB.Application.Services.Terminology.openEHR;
using Mapper.openEHR.StratupConfig;
using Microsoft.Extensions.DependencyInjection;
using Mapper.openEHR.Infrastructure.StratupConfig;
using Mapper.openEHR.SeedWork.Cache;
using Mapper.GSB.Application.Authorization;
using MediatR;
using Mapper.GSB.Application.Insurance.Commands.Save;

namespace Mapper.GSB.Application.Configuration.StratupConfig
{
    /// <summary>
    /// انواع تنظیمات برنامه
    /// </summary>
    public class ApplicationConfigurations
    {
        private readonly IServiceCollection services;
        /// <summary>
        /// تنظیمات برنامه ها
        /// </summary>
        /// <param name="services"></param>
        public ApplicationConfigurations(IServiceCollection services)
        {
            this.services = services;
        }
        /// <summary>
        /// تنظیمات برای حالت پیش فرض
        /// </summary>
        public void DefaultConfiguration()
        {
            //دادن اسمبلی برنامه که کلاس هایی که قرار است با MediatR کنند
            //فرق نمی کنه کدوم کلاس رو بدید فقط اسمبلی مهمه
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<SavePersonInsuranceCommand>());
            /*
             * ثبت پایپ لاین های مورد نظر
             * <list type="bullet">
             * <item>جهت بررسی مجوز دسترسی به فرمان و پرس وجو ها</item>
             * </list>
             */
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(CommandQueryAuhtorizationBehavior<,>));            
        }
        /// <summary>
        /// تنظیمات سرویس های مرتبط با سیستم 
        /// ترمینولوژی
        /// </summary>
        public void OpenEHRTerminologyServiceConfiguration()
        {
            services.AddScoped<IOpenEHRTerminologyService, OpenEHRTerminologyService>();
        }
    }
}
