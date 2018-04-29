using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace bS.Sked.Shared.Extensions
{
    public static class StringExtension
    {
        public static Guid ToGuid(this string value)
        {
            Guid result;
            if (!Guid.TryParse(value, out result)) return Guid.Empty;
            return result;
        }

        /// <summary>
        /// Cleans the name (trim and remove extra spaces and invalid filename path).
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string CleanName(this string value)
        {
            string result;
            // Trim
            result = value.Trim();

            // Remove extra spaces
            result = Regex.Replace(result, @"\s+", " ");

            // Remove invalid filename chars
            Path.GetInvalidFileNameChars().Aggregate(result, (current, c) => current.Replace(c.ToString(), string.Empty));

            return result;
        }
    }
}
