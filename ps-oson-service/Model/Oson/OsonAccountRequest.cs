namespace ps_oson_service.Model.Oson;

[PublicAPI]
public record OsonAccountRequest : OsonRequest
{
    [JsonPropertyName("service_id")]
    public int ServiceId { get; }

    [JsonPropertyName("account")]
    public string Account { get; }

    [JsonPropertyName("amount")]
    public decimal Amount { get; }

    [JsonPropertyName("agent_transaction_id")]
    public string AgentTransactionId { get; }

    public Dictionary<string, object> Params { get; }
    
    public OsonAccountRequest(AccountQuery query)
    {
        ServiceId = query.ServiceId;
        Account = query.Account;
        Amount = query.Amount;
        AgentTransactionId = query.TransactionId;
        Params = query.Params;
    }

    public OsonAccountRequest(PayCommand command)
    {
        ServiceId = command.ServiceId;
        Account = command.Account;
        Amount = command.Amount;
        AgentTransactionId = command.TransactionId;
        Params = command.Params;
    }

    public override string ToString() => JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true } );
}