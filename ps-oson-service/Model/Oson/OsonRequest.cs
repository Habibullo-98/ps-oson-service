namespace ps_oson_service.Model.Oson;

[PublicAPI]
public abstract record OsonRequest
{
    public string ToJson() => JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
}

[PublicAPI]
public record OsonRequestParams
{
    public string ToJson() => JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
}