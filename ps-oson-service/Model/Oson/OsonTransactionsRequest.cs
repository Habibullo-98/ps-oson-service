namespace ps_oson_service.Model.Oson;

[PublicAPI]
public record OsonTransactionsRequest : OsonRequest, IQueryParameterable
{
    public string Date { get; }

    public OsonTransactionsRequest(TransactionsQuery query)
    {
        Date = query.Date;
    }

    public string ToQueryString()
    {
        return "?date=" + Date;
    }
    
    public override string ToString() => JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true } );
}