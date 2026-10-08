namespace ps_oson_service.Handler;

public class DepositQueryHandler(
    ILogger<DepositQueryHandler> logger,
    IOsonClient client) : IQueryHandler<DepositQuery, OsonDepositResponse>
{
    public async Task<Result<OsonDepositResponse>> HandleAsync(DepositQuery query)
    {
        logger.LogDepositQuery(query);
        var request = new OsonDepositRequest();
        var result = await client.GetAsync(request);
        return result;
    }
}