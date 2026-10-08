namespace ps_oson_service.Model.Oson;

[PublicAPI]
public record OsonCalculateRequest : OsonRequest
{
    [JsonPropertyName("service_id")]
    public int ServiceId { get; }
    
    [JsonPropertyName("account")]
    public string Account { get; }
    
    [JsonPropertyName("agent_transaction_id")]
    public string AgentTransactionId { get; }
    
    [JsonPropertyName("params")]
    public Dictionary<string, object> Params { get; }

    public OsonCalculateRequest(AccountQuery query)
    {
        ServiceId = query.ServiceId;
        Account = query.Account;
        AgentTransactionId = query.TransactionId;
        Params = query.Params;
    }
    
    public OsonCalculateRequest(CalculateQuery query)
    {
        ServiceId = query.ServiceId;
        Account = query.Account;
        AgentTransactionId = query.AgentTransactionId;
        Params = query.Params;
    }
    
    public override string ToString() => JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true } );
}