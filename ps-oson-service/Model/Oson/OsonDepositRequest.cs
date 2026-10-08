namespace ps_oson_service.Model.Oson;

[PublicAPI]
public record OsonDepositRequest : OsonRequest, IQueryParameterable
{
    public string ToQueryString()
    {
        return string.Empty;
    }
    
    public override string ToString() => JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true } );
}