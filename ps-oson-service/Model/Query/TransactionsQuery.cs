namespace ps_oson_service.Model.Query;

public record TransactionsQuery : BaseQuery<OsonTransactionsResponse>
{
    public string Date { get; }
    
    public TransactionsQuery(VaslTransactionsRequest request)
    {
        Date = request.Date;
    }
    
    public override string ToString() => ToLogString();
}