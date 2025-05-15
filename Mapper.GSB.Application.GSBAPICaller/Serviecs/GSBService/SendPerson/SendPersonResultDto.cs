using Mapper.GSB.Application.GSBAPICaller.Serviecs.GSBService.ResponseBody;
using MOHME.Lib.Shared;

namespace Mapper.GSB.Application.GSBAPICaller.Serviecs.GSBService.SendPerson
{
    /// <summary>
    /// پاسخ دریافتی بایت ارسال اطلاعات فول درممان و تکمیلی 
    /// </summary>
    public class SendPersonResultDto : IBodyData
    {
        /// <summary>
        /// شناسه منحصر بفرد بیمه شده در بانک تجمیع بیمه سلامت
        /// </summary>
        public DO_IDENTIFIER? Igin { get; set; }
        /// <summary>
        /// در صورت موفق بودن پاسخ الزامی است
        /// </summary>
        public string? RegisterID { get; set; }
        /// <summary>
        /// توضیحات تکمیلی
        /// </summary>
        public string? RecommandMessage { get; set; }
        /// <summary>
        /// تاریخ و ساعت ثبت
        /// </summary>
        public DO_DATE_TIME? RegisterDate { get; set; }
    }
}
