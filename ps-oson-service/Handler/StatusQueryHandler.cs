using ps_oson_service.Client;

namespace ps_oson_service.Handler;

public class StatusQueryHandler(
    ILogger<StatusQueryHandler> logger,
    IOsonClient client) : IQueryHandler<StatusQuery, OsonStatusResponse>
{
    public async Task<Result<OsonStatusResponse>> HandleAsync(StatusQuery query)
    {
        logger.LogStatusQuery(query);
        var request = new OsonStatusRequest(query);
        var result = await client.SendAsync(request);
        if (result.IsFailure) return result.Error;
        if (result.Value.IsFailure) return result.Value.Error;

        return result;
    }
}