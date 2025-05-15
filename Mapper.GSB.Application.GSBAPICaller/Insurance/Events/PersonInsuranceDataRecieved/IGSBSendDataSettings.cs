namespace Mapper.GSB.Application.GSBAPICaller.Insurance.Events.PersonInsuranceDataRecieved
{
    /// <summary>
    ///داده های مورر نیاز جهت ارسال درخواست به سرویس دهنده 
    ///GSB
    /// </summary>
    public interface IGSBSendDataSettings
    {
        /// <summary>
        /// نام کاربری که در نرم افزار موسسه درخواست کننده سرویس وارد شده است
        /// </summary>
        string AppUser { get; }
        /// <summary>
        /// آدرس IPموسسه استفاده کننده از سرویس
        /// </summary>
        string ClientIP { get; }
    }
}
