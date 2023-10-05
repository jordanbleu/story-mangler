using System.Globalization;

namespace ManglerAPI.Extensions;

public static class StringExtensions
{
    public static string ToTitleCase(this string str)
    {
        if (str is null)
            return string.Empty;
        
        TextInfo info = CultureInfo.CurrentCulture.TextInfo;
        return info.ToTitleCase(str.ToLower());

    }
}