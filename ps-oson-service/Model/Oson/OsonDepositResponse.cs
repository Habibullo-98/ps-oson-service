namespace ps_oson_service.Model.Oson;

[PublicAPI]
public record OsonDepositResponse
{
    [JsonPropertyName("balance")]
    public decimal Balance { get; init; }

    [JsonPropertyName("currency")]
    public int Currency { get; init; }
    
    [JsonPropertyName("over_balance")]
    public decimal OverBalance { get; init; }
    
    [JsonPropertyName("over_limit")]
    public decimal OverLimit { get; init; }    
    
    public override string ToString() => JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true } );
}