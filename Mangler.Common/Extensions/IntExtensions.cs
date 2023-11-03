namespace Mangler.Common.Extensions;

public static class IntExtensions
{
    public static bool IsBetween(this int value, int min, int max, bool exclusive = false)
    {
        if (exclusive)
        {
            return value > min && value < max;
        }

        return value >= min && value <= max;
    }
}