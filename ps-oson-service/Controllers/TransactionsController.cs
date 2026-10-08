namespace ps_oson_service.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionsController(IQueryHandler<TransactionsQuery, OsonTransactionsResponse> handler) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<VaslResponse>> Transactions(VaslTransactionsRequest request)
    {
        var query = new TransactionsQuery(request);
        var result = await handler.HandleAsync(query);
        return new VaslResponse(result);
    }
}