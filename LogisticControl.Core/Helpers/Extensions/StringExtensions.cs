using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace LogisticControl.Core.Helpers.Extensions;

public static class StringExtensions
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
    public static string ToSpacedPascalCase(this string str)
    {
        return string.Concat(str.Select((x, i) => i > 0 && char.IsUpper(x) ? " " + x : x.ToString()));
    }
}