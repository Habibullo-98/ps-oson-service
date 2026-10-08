namespace ps_oson_service.Controllers;

[ApiController]
[Route("[controller]")]
public class PayController(ICommandHandler<PayCommand, OsonPaymentResponse> handler) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<VaslResponse>> Pay(VaslPaymentRequest request)
    {
        var command = new PayCommand(request);
        var result = await handler.HandleAsync(command);
        return new VaslResponse(result);
    }
}