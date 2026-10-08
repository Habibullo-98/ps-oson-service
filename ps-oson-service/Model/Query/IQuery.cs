namespace ps_oson_service.Model.Query;

public interface IQuery<TResponse> { }

public abstract record BaseQuery<TResponse> : IQuery<TResponse> 
{
    protected string ToLogString()
    {
        var sb = new StringBuilder();
        sb.AppendLine();
        sb.AppendLine("-------------------------------------------");
        sb.AppendLine($"               {nameof(TResponse)}");
        var type = GetType();
        var properties = type.GetProperties();
        foreach (var propertyInfo in properties)
        {
            if (propertyInfo.PropertyType == typeof(Dictionary<string, object>))
            {
                sb.Append(propertyInfo.GetValue(this));
                continue;
            }
            int padding = 43 - propertyInfo.Name.Length - propertyInfo.GetValue(this)?.ToString()?.Length ?? 0;
            sb.Append(propertyInfo.Name);
            sb.Append(string.Empty.PadRight(padding));
            sb.Append(propertyInfo.GetValue(this));
            sb.AppendLine();
        }
        sb.AppendLine("-------------------------------------------");
        
        return sb.ToString();
    }
}