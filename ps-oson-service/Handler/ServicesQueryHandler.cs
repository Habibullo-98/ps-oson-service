using ps_oson_service.Client;

namespace ps_oson_service.Handler;

public class ServicesQueryHandler(
    ILogger<ServicesQueryHandler> logger,
    IOsonClient client) : IQueryHandler<ServicesQuery, List<OsonServiceResponse>>
{
    public async Task<Result<List<OsonServiceResponse>>> HandleAsync(ServicesQuery query)
    {
        logger.LogServicesQuery(query);
        var request = new OsonServicesRequest(); 
        var result = await client.GetAsync(request);
        return result;
    }
}