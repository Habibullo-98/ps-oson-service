namespace ps_oson_service.Controllers;

[ApiController]
[Route("CheckPaymentStatus")]
public class StatusController(IQueryHandler<StatusQuery, OsonStatusResponse> handler) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<VaslResponse>> Check(VaslStatusRequest request)
    {
        var query = new StatusQuery(request);
        var result = await handler.HandleAsync(query);
        return new VaslResponse(result);
    }
}