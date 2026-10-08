namespace ps_oson_service.Model.Oson;

[PublicAPI]
public record OsonPaymentRequest : OsonRequest
{
    [JsonPropertyName("agent_transaction_id")]
    public string AgentTransactionId { get; }
    
    public OsonPaymentRequest(PayCommand command)
    {
        AgentTransactionId = command.TransactionId;
    }
    
    public override string ToString() => JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true } );
}