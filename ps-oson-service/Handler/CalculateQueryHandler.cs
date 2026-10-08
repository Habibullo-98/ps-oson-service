namespace ps_oson_service.Handler;

public class CalculateQueryHandler(
    IOsonClient client,
    ILogger<CalculateQueryHandler> logger) : IQueryHandler<CalculateQuery, OsonCalculateResponse>
{
    public async Task<Result<OsonCalculateResponse>> HandleAsync(CalculateQuery query)
    {
        logger.LogCalculateQuery(query);
        if (query.IsTopUp) return CalculateErrors.ServiceTypeNotAllowed;
        
        var calculateRequest = new OsonCalculateRequest(query);
        var calculateResult = await client.SendAsync(calculateRequest);
        if (calculateResult.IsFailure) return calculateResult;
        if (calculateResult.Value.IsFailure) return calculateResult.Value.Error;

        return calculateResult;
    }
}