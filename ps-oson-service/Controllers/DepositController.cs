namespace ps_oson_service.Controllers;

[ApiController]
[Route("[controller]")]
public class DepositController(IQueryHandler<DepositQuery, OsonDepositResponse> handler) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<VaslResponse>> Deposit()
    {
        var query = new DepositQuery();
        var result = await handler.HandleAsync(query);
        return new VaslResponse(result);
    }
}