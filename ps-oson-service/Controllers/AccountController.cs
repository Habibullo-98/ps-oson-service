namespace ps_oson_service.Controllers;

[ApiController]
[Route("CheckAccount")]
public class AccountController(IQueryHandler<CalculateQuery, OsonCalculateResponse> handler) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<VaslResponse>> Check(VaslAccountRequest request)
    {
        var query = new CalculateQuery(request);
        var result = await handler.HandleAsync(query);
        return new VaslResponse(result);
    }
}