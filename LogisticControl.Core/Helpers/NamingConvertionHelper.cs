using System.Runtime.CompilerServices;

namespace LogisticControl.Core.Helpers;

public static class NamingConvertionHelper
{
    public static string ToUnderscoreCase(this string str)
    {
        if (string.IsNullOrWhiteSpace(str))
            return str;

        return string.Concat(
            str.Select((x, i) => i > 0 && char.IsUpper(x)
                ? "_" + x
                : x.ToString())
        ).ToLower();
    }
}