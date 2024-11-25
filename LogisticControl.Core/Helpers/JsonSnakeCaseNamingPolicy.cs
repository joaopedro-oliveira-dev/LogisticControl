using System.Text.Json;

namespace LogisticControl.Core.Helpers;

public class JsonSnakeCaseNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name)
    {
        return name.ToUnderscoreCase();
    }
}