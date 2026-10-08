namespace ps_oson_service.Model.Oson;

[PublicAPI]
public record OsonPaymentResponse : OsonResponse
{
    [JsonPropertyName("data")]
    public object? Data { get; init; }
        
    public override string ToString() => JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true } );
}