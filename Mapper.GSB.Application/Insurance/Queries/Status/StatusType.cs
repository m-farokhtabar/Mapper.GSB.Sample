using Mapper.GSB.Share.Resource;
using System.ComponentModel.DataAnnotations;

namespace Mapper.GSB.Application.Insurance.Queries.Status;

/// <summary>
/// وضعیت درخواست
/// </summary>
public enum StatusType
{
    /// <summary>
    /// عملیات با موفقیت انجام شده
    /// </summary>    
    [Display(Name = "The_operation_has_done_sucessfully", ResourceType = typeof(Messages))]
    Success,
    /// <summary>
    /// در حال انجام عملیات
    /// </summary>
    [Display(Name = "The_operation_is_in_progress", ResourceType = typeof(Messages))]
    InProcessing,
    /// <summary>
    /// در زمان ارسال درخواست به سرور بیمه سلامت خطایی رخ داده است
    /// </summary>
    [Display(Name = "An_error_occurred_while_performing_the_operation_during_the_data_transmission_to_the_GSB_server", ResourceType = typeof(Messages))]
    GSBFail,
    /// <summary>
    /// در زمان ارسال درخواست به سرور مخزن داده بیمه مرکزی خطایی رخ داده است
    /// </summary>
    [Display(Name = "An_error_occurred_while_performing_the_operation_during_the_data_transmission_to_the_Central_Insurance_Repository", ResourceType = typeof(Messages))]
    DDRFail
}
