namespace Mapper.GSB.Application.DDRAPICaller.Services.DDR
{
    /// <summary>
    /// تنظیمات مبدل 
    /// DDR
    /// </summary>
    public interface IDDRMapperSetting
    {
        /// <summary>
        /// شناسه قالب عملیاتی جدید تبدیل اطلاعات بیمار
        /// </summary>
        Guid OPT_Person_Id { get; }

        #region آدرس مبدل جهت تبدیل به کلاس شخص یا فرد در ریپو openEHR.DDR
        /// <summary>
        /// شناسه مبدل 
        /// به آرکی تایپ
        /// تبدیل اطلاعات افراد به رفرنس مدل بر اساس قالب عملیاتی
        /// </summary>
        string Mapper_PersonToOPT_Url { get; }
        /// <summary>
        /// نسخه مبدل
        /// </summary>
        string Mapper_PersonToOPT_Version { get; }
        #endregion

        #region آدرس مبدل جهت تبدیل از کلاس شخص یا فرد ریپو openEHR.DDR
        /// <summary>
        /// شناسه مبدل 
        /// به آرکی تایپ
        /// تبدیل اطلاعات قالب عملیاتی به مدل شخص
        /// </summary>
        string Mapper_OPTToPerson_Url { get; }
        /// <summary>
        /// نسخه مبدل
        /// </summary>
        string Mapper_OPTToPerson_Version { get; }
        #endregion


        /// <summary>
        /// شناسه قالب عملیاتی جدید تبدیل اطلاعات روکش سند
        /// </summary>
        Guid OPT_Composition_Id { get; }
        #region آدرس مبدل جهت تبدیل به کلاس ارتباطات به ریپو openEHR.DDR
        /// <summary>
        /// شناسه مبدل 
        /// به آرکی تایپ
        /// تبدیل اطلاعات روکش سند به رفرنس مدل بر اساس قالب عملیاتی
        /// </summary>
        string Mapper_CompositionToOPT_Url { get; }
        /// <summary>
        /// نسخه مبدل
        /// </summary>
        string Mapper_CompositionToOPT_Version { get; }
        #endregion

        #region آدرس مبدل جهت تبدیل از ریپو به کلاس ارتباطات
        /// <summary>
        /// شناسه مبدل 
        /// به آرکی تایپ
        /// تبدیل رفرنس مدل قالب عملیاتی به مدل روکش سند
        /// </summary>
        string Mapper_OPTToComposition_Url { get; }
        /// <summary>
        /// نسخه مبدل
        /// </summary>
        string Mapper_OPTToComposition_Version { get; }
        #endregion


        #region اطلاعات مربوط به سیستم مبدل
        /// <summary>
        /// شناسه سیستم مبدل
        /// //TODO این شناسه باید در سیستم به عنوان یک ایجنت ذخیره شده باشد
        /// opneEHR Demographic Agent
        /// </summary>
        string MapperSystemId { get; }
        /// <summary>
        /// شناسه سازمانی که مسئول نگهداری سیستم نرم افزاری مبدل است
        /// //TODO این شناسه باید در سیستم به عنوان یک ایجنت ذخیره شده باشد
        /// opneEHR Demographic Organization
        /// </summary>
        string MapperOrganizationId { get; }
        /// <summary>
        /// نام سازمانی که مسئول نگهداری سیستم نرم افزاری مبدل است
        /// </summary>
        string MapperOrganizationName { get; }
        #endregion

    }
}
