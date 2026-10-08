namespace ps_oson_service.Model.Oson;

[PublicAPI]
public record OsonTransactionsResponse : OsonResponse
{
    [JsonPropertyName("data")]
    public List<OsonTransactionResponse> Data { get; init; } = [];

    public override string ToString() => JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
}

[PublicAPI]
public record OsonTransactionResponse
{
    [JsonPropertyName("account")]
    public string Account { get; init; } = string.Empty;

    [JsonPropertyName("transaction_id")]
    public long TransactionId { get; init; }

    [JsonPropertyName("agent_transaction_id")]
    public string AgentTransactionId { get; init; } = string.Empty;

    [JsonPropertyName("amount")]
    public decimal Amount { get; init; }

    [JsonPropertyName("time")]
    public string Date { get; init; } = string.Empty;

    [JsonPropertyName("service_id")]
    public int ServiceId { get; init; }

    [JsonPropertyName("service_name")]
    public string ServiceName { get; init; } = string.Empty;

    public override string ToString() => JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
}
