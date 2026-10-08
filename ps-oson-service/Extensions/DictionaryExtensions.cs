using System.Text;

namespace ps_oson_service.Extensions;

public static class DictionaryExtensions
{
    public static string ToLogString(this Dictionary<string, object> dictionary)
    {
        var sb = new StringBuilder();
        foreach (var keyValue in dictionary)
        {
            sb.Append(keyValue.Key);
            sb.Append(string.Empty.PadRight(43 - keyValue.Key.Length - keyValue.Value?.ToString()?.Length ?? 0));
            sb.Append(keyValue.Value);
            sb.AppendLine();
        }

        return sb.ToString();
    }
}