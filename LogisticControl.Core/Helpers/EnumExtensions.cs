namespace LogisticControl.Core.Helpers;

public static class EnumExtensions
{
    public static string GetFormattedName(this Enum value)
    {
        var name = value.ToString();
        return string.Concat(name.Select((x, i) => i > 0 && char.IsUpper(x) ? " " + x : x.ToString()));
    }
}