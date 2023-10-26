using System.Globalization;

namespace Mangler.Common.Extensions;

public static class StringExtensions
{
    public static string ToTitleCase(this string str)
    {
        if (str is null)
            return string.Empty;
        
        TextInfo info = CultureInfo.CurrentCulture.TextInfo;
        return info.ToTitleCase(str.ToLower());
    }

    /// <summary>
    /// Returns true if the length of <paramref name="str"/> is between <paramref name="min"/> and <paramref name="max"/> (exclusive)
    /// </summary>
    public static bool LengthIsInRange(this string str, int min, int max, bool exclusive = false)
    {
        var len = str.Length;
        if (exclusive)
        {
            return len > min && len < max;
        }

        return len >= min && len <= max;
    }

   // str.Length > min & str.Length < max;
}