namespace ps_oson_service.Model.Oson;

[PublicAPI]
public record OsonStatusRequest : OsonRequest
{
    [JsonPropertyName("agent_transaction_id")]
    public string AgentTransactionId { get; }

    public OsonStatusRequest(StatusQuery query)
    {
        AgentTransactionId = query.TransactionId;
    }
    
    public override string ToString() => JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true } );
}