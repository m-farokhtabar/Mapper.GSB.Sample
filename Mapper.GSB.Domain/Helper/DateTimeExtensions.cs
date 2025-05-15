using MOHME.Lib.Shared;
using System.Globalization;

namespace Mapper.GSB.Domain.Helper;

/// <summary>
/// متدهای مورد نیاز تاریخ فارسی
/// </summary>
public static class DateTimeExtensions
{
    /// <summary>
    /// تبدیل تاریخ میلادی به تاریخ میلادی به فرمت وزارت بهداشت
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public static DO_DATE_TIME GetPersianDoDateTime(this DateTime dateTime)
    {
        PersianCalendar pc = new();
        return new DO_DATE_TIME()
        {
            Year = pc.GetYear(dateTime),
            Month = pc.GetMonth(dateTime),
            Day = pc.GetDayOfMonth(dateTime),
            Hour = pc.GetHour(dateTime),
            Minute = pc.GetMinute(dateTime),
            Second = pc.GetSecond(dateTime)
        };
    }
    /// <summary>
    /// تبدیل تاریخ میلادی به تاریخ میلادی به فرمت وزارت بهداشت
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public static DO_DATE GetPersianDoDate(this DateTime dateTime)
    {
        PersianCalendar pc = new();
        return new DO_DATE()
        {
            Year = pc.GetYear(dateTime),
            Month = pc.GetMonth(dateTime),
            Day = pc.GetDayOfMonth(dateTime)
        };
    }
    /// <summary>
    /// تبدیل زمان میلادی به زمان به فرمت وزارت بهداشت
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public static DO_TIME GetPersianDoTime(this DateTime dateTime)
    {
        PersianCalendar pc = new();
        return new DO_TIME()
        {
            Hour = pc.GetHour(dateTime),
            Minute = pc.GetMinute(dateTime),
            Second = pc.GetSecond(dateTime)
        };
    }
}
