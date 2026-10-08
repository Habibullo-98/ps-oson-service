namespace ps_oson_service.Controllers;

[ApiController]
[Route("[controller]")]
public class ServicesController(IQueryHandler<ServicesQuery, List<OsonServiceResponse>> handler) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<VaslResponse>> Services()
    {
        var query = new ServicesQuery();
        var result = await handler.HandleAsync(query);
        return new VaslResponse(result);
    }
}