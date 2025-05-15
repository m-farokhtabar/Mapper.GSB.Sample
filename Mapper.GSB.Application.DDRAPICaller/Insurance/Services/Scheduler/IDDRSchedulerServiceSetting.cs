namespace Mapper.GSB.Application.DDRAPICaller.Insurance.Services.Scheduler;

/// <summary>
/// تنظیمات تایمر سرویس کنترک کننده وضعیت ارسال داده ها به
/// DDR
/// </summary>
public interface IDDRSchedulerServiceSetting
{
    /// <summary>
    /// زمانی که باید سرویس صبر کند و بعد از آن اجازه دارد چک کند این رکورد کارش درس انجام شده یا نه
    /// <para>واحد زمانی این فیلد دقیقه است</para>
    /// </summary>
    /// <remarks>دقت شود واحد پایه زمان برای مقایسه زمان ایجاد رکورد است</remarks>
    int WatingTimeForFetchingTheRecord { get; }
    /// <summary>
    /// پس از پیدا کردن رکوردهایی که قبلا ثبت نشده حالا بایستی انها را جهت عملیات ثبت مجدد ارسال نماییم
    /// زمان مابین هر ارسال درخواست می باشد
    /// واحد آن به میلی ثانیه است
    /// </summary>
    /// <remarks>قرار داد 0 به معنی این است که ارسال ها بدون تاخیر انجام شود</remarks>
    int DelayBetweenSendingRequest { get; }
    /// <summary>
    /// میزان تاخیر مابین شماره نسخه
    /// یعنی وقتی تمام رکوردهای نسخه یک تمام شد چقدر صبر کند برای اینکه نسخه های 2 را شروع کند
    /// واحد آن ثانیه است
    /// </summary>
    int DelayBetweenSendingBatchResponse { get; }
    /// <summary>
    /// تعداد واکشی رکورد به ازای انجام هر بار
    /// یعنی مثلا 100 رکورد مشکل دار رو پیدا کند وارسال کند در هر مرحله یا 500 تا
    /// </summary>
    int RecordsCountPerFetch { get; }
}
