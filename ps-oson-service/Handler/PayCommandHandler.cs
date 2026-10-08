namespace ps_oson_service.Handler;

public class PayCommandHandler(
    ILogger<PayCommandHandler> logger,
    IOsonClient client) : ICommandHandler<PayCommand, OsonPaymentResponse>
{
    public async Task<Result<OsonPaymentResponse>> HandleAsync(PayCommand command)
    {
        logger.LogPayCommand(command);

        var checkRequest = new OsonAccountRequest(command);
        var checkResult = await client.SendAsync(checkRequest);
        if (checkResult.IsFailure) return checkResult.Error;
        if (checkResult.Value.IsFailure) return checkResult.Value.Error;
        
        var payRequest = new OsonPaymentRequest(command);
        var payResult = await client.SendAsync(payRequest);
        if (payResult.IsFailure) return payResult.Error;
        if (payResult.Value.IsFailure) return payResult.Value.Error;

        return payResult;
    }
}