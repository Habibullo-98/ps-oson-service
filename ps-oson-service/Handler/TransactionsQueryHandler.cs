namespace ps_oson_service.Handler;

public class TransactionsQueryHandler(
    ILogger<TransactionsQueryHandler> logger,
    IOsonClient client) : IQueryHandler<TransactionsQuery, OsonTransactionsResponse>
{
    public async Task<Result<OsonTransactionsResponse>> HandleAsync(TransactionsQuery query)
    {
        logger.LogTransactionsQuery(query);
        var request = new OsonTransactionsRequest(query);
        var result = await client.GetAsync(request);
        return result;
    }
}