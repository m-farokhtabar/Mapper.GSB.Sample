using Mapper.GSB.Share.Helper;

namespace MOHME.Lib.Helper
{
    /// <summary>
    /// Validate IR National Code
    /// </summary>
    public static class NationalCodeValidator
    {
        /// <summary>
        ///     بررسی صحت کد کلی
        /// </summary>
        /// <param name="nationalCode">National Code</param>
        /// <returns></returns>
        public static bool IsValidIranianNationalCode(this string? nationalCode)
        {
            if (string.IsNullOrWhiteSpace(nationalCode))
            {
                return false;
            }

            nationalCode = nationalCode.ToEnglishNumbers();

            const int initialZeros = 2;
            const int nationalCodeLength = 10;
            if (nationalCode.Length < nationalCodeLength - initialZeros || nationalCode.Length > nationalCodeLength)
            {
                return false;
            }

            nationalCode = nationalCode.PadLeft(10, '0');

            if (!nationalCode.IsNumber())
            {
                return false;
            }

            var j = nationalCodeLength;
            var sum = 0;
            for (var i = 0; i < nationalCode.Length - 1; i++)
            {
                sum += (int)char.GetNumericValue(nationalCode[i]) * j--;
            }

            var remainder = sum % 11;
            var controlNumber = (int)char.GetNumericValue(nationalCode[9]);
            return (remainder < 2 && controlNumber == remainder) ||
                   (remainder >= 2 && controlNumber == 11 - remainder);
        }
        /// <summary>
        /// بررسی اینکه رشته عددی است یا خیر
        /// </summary>
        private static bool IsNumber(this string? data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                return false;
            }

            return data.ToEnglishNumbers().All(char.IsDigit);
        }
    }
}
