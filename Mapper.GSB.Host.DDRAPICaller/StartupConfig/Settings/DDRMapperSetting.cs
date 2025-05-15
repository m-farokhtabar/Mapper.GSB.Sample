using Mapper.GSB.Application.DDRAPICaller.Services.DDR;
using Mapper.openEHR.ModelToOPT.SeedWork;

namespace Mapper.GSB.Host.DDRAPICaller.StartupConfig.Settings
{
    /// <summary>
    /// تنظیمات مبدل
    /// </summary>
    public class DDRMapperSetting : IDDRMapperSetting, IMapperSetting
    {
        /// <summary>
        /// شناسه قالب عملیاتی جدید تبدیل اطلاعات بیمار
        /// </summary>
        public Guid OPT_Person_Id { get; init; }

        #region آدرس مبدل جهت تبدیل به کلاس شخص یا فرد در ریپو openEHR.DDR
        /// <summary>
        /// شناسه مبدل 
        /// به آرکی تایپ
        /// تبدیل اطلاعات افراد به رفرنس مدل بر اساس قالب عملیاتی
        /// </summary>
        public string Mapper_PersonToOPT_Url { get; init; } = string.Empty;
        /// <summary>
        /// نسخه مبدل
        /// </summary>
        public string Mapper_PersonToOPT_Version { get; init; } = string.Empty;
        #endregion

        #region آدرس مبدل جهت تبدیل از کلاس شخص یا فرد ریپو openEHR.DDR
        /// <summary>
        /// شناسه مبدل 
        /// به آرکی تایپ
        /// تبدیل اطلاعات قالب عملیاتی به مدل شخص
        /// </summary>
        public string Mapper_OPTToPerson_Url { get; init; } = string.Empty;
        /// <summary>
        /// نسخه مبدل
        /// </summary>
        public string Mapper_OPTToPerson_Version { get; init; } = string.Empty;
        #endregion


        /// <summary>
        /// شناسه قالب عملیاتی جدید تبدیل اطلاعات روکش سند
        /// </summary>
        public Guid OPT_Composition_Id { get; init; }
        #region آدرس مبدل جهت تبدیل به کلاس ارتباطات به ریپو openEHR.DDR
        /// <summary>
        /// شناسه مبدل 
        /// به آرکی تایپ
        /// تبدیل اطلاعات روکش سند به رفرنس مدل بر اساس قالب عملیاتی
        /// </summary>
        public string Mapper_CompositionToOPT_Url { get; init; } = string.Empty;
        /// <summary>
        /// نسخه مبدل
        /// </summary>
        public string Mapper_CompositionToOPT_Version { get; init; } = string.Empty;
        #endregion

        #region آدرس مبدل جهت تبدیل از ریپو به کلاس ارتباطات
        /// <summary>
        /// شناسه مبدل 
        /// به آرکی تایپ
        /// تبدیل رفرنس مدل قالب عملیاتی به مدل روکش سند
        /// </summary>
        public string Mapper_OPTToComposition_Url { get; init; } = string.Empty;
        /// <summary>
        /// نسخه مبدل
        /// </summary>
        public string Mapper_OPTToComposition_Version { get; init; } = string.Empty;
        #endregion


        #region اطلاعات مربوط به سیستم مبدل
        /// <summary>
        /// شناسه سیستم مبدل
        /// //TODO این شناسه باید در سیستم به عنوان یک ایجنت ذخیره شده باشد
        /// opneEHR Demographic Agent
        /// </summary>
        public string MapperSystemId { get; init; } = string.Empty;
        /// <summary>
        /// شناسه سازمانی که مسئول نگهداری سیستم نرم افزاری مبدل است
        /// //TODO این شناسه باید در سیستم به عنوان یک ایجنت ذخیره شده باشد
        /// opneEHR Demographic Organization
        /// </summary>
        public string MapperOrganizationId { get; init; } = string.Empty;
        /// <summary>
        /// نام سازمانی که مسئول نگهداری سیستم نرم افزاری مبدل است
        /// </summary>
        public string MapperOrganizationName { get; init; } = string.Empty;
        #endregion

        /// <summary>
        ///  نوع ترمینولوژی کدینگ 
        /// </summary>
        public string CharacterSetsTerminology_Id { get; init; } = string.Empty;
        /// <summary>
        /// نوع کدینگ داده های برنامه
        /// </summary>
        public string DefaultCharacterSet { get; init; } = string.Empty;
        /// <summary>
        /// نوع ترمینولوژی زبان
        /// </summary>
        public string LanguagesTerminology_Id { get; init; } = string.Empty;
        /// <summary>
        /// زبان پیش فرض داده ها
        /// </summary>
        public string DataFaLanguage { get; init; } = string.Empty;
        /// <summary>
        /// زبان ثانویه داده ها
        /// </summary>
        public string DataEnLanguage { get; init; } = string.Empty;
    }
}
