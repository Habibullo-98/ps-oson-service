namespace ps_oson_service.Model.Oson;

[PublicAPI]
public record OsonCalculateResponse : OsonResponse
{
    [JsonPropertyName("account")] 
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string Account { get; init; } = string.Empty;
    
    [JsonPropertyName("amount")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public decimal Amount { get; init; }
    
    [JsonPropertyName("transaction_id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public long TransactionId { get; init; }
    
    [JsonPropertyName("amount_in_currency")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public decimal AmountInCurrency { get; init; }
    
    [JsonPropertyName("comission")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int Commission { get; init; }
    
    [JsonPropertyName("fixed_amount")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public decimal FixedAmount { get; init; }    

    public override string ToString() => JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true } );
}