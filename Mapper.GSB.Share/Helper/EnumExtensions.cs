using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Mapper.GSB.Share.Helper
{
    /// <summary>
    /// متدهای کمکی برای نوع
    /// enum
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// دریافت نام نمایشی برای نوع شمارشی
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string? GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
              .GetMember(enumValue.ToString())
              .First()
              .GetCustomAttribute<DisplayAttribute>()
              ?.GetName();
        }
    }
}
