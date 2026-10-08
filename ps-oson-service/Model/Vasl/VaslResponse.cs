using Serilog;

namespace ps_oson_service.Model.Vasl;

[PublicAPI]
public record VaslResponse
{
    public VaslResultCode Result { get; private set; } = VaslResultCode.Success;
    public VaslStatusCode Status { get; private set; } = VaslStatusCode.InProcess;
    public string Comment { get; private set; } = "Ok";
    public int PartnerTransactionId { get; private set; }
    public List<VaslResponseParams> Params { get; private set; } = [];
    
    public object? Data { get; private set; }

    public VaslResponse(Error error)
    {
        if (error == Error.None) return;
        
        Result = VaslResultCode.Success;
        Status = VaslStatusCode.Failure;
        Comment = error.Description;
        Log.Logger.Error(error.Description);
    }

    public VaslResponse(Result<OsonAccountResponse> result) : this(result.Error)
    {
        if (result.IsFailure) return;
        if (result.Value.IsFailure) return;
        
        Result = VaslResultCode.Success;
        Status = VaslStatusCode.InProcess;
        Comment = "Ok";
    }

    public VaslResponse(Result<OsonCalculateResponse> result) : this(result.Error)
    {
        if (result.Error == CalculateErrors.ServiceTypeNotAllowed)
        {
            Result = VaslResultCode.Success;
            Status = VaslStatusCode.InProcess;
            Comment = "Ok";
            return;
        }

        if (result.IsFailure) return;
        if (result.Value.IsFailure) return;
        
        Result = VaslResultCode.Success;
        Status = VaslStatusCode.InProcess;
        Comment = "Ok";
        Params.Add(new VaslResponseParams($"Сумма: {result.Value.FixedAmount}", result.Value.Account, result.Value.FixedAmount));
    }

    public VaslResponse(Result<OsonPaymentResponse> result) : this(result.Error)
    {
        if (result.IsFailure) return;
        if (result.Value.IsFailure) return;

        if (result.Value.Status == OsonStatusCode.Success)
        {
            Status = VaslStatusCode.Success;
            Comment = "Payment Successful";
        }

        if (result.Value.Status == OsonStatusCode.InProcess)
        {
            Comment = "Payment in process";
        }
        
        Data = result.Value.Data;
    }

    public VaslResponse(Result<OsonStatusResponse> result) : this(result.Error)
    {
        if (result.IsFailure) return;
        if (result.Value.IsFailure) return;
        
        if (result.Value.Status == OsonStatusCode.Success)
        {
            Status = VaslStatusCode.Success;
            Comment = "Payment Successful";
        }

        if (result.Value.Status == OsonStatusCode.InProcess)
        {
            Comment = "Payment in process";
        }
        
        Data = result.Value.Data;
    }

    public VaslResponse(Result<OsonTransactionsResponse> result) : this(result.Error)
    {
        if (result.IsFailure) return;
        
        Result = VaslResultCode.Success;
        Status = VaslStatusCode.InProcess;
        Comment = "Ok";
        Data = result.Value;
    }

    public VaslResponse(Result<OsonDepositResponse> result) : this(result.Error)
    {
        if (result.IsFailure) return;
        
        Result = VaslResultCode.Success;
        Status = VaslStatusCode.InProcess;
        Comment = "Ok";
        Data = result.Value;
    }

    public VaslResponse(Result<List<OsonServiceResponse>> result) : this(result.Error)
    {
        if (result.IsFailure) return;
        
        Result = VaslResultCode.Success;
        Status = VaslStatusCode.InProcess;
        Comment = "Ok";
        Data = result.Value;
    }
}

[PublicAPI]
public class VaslResponseParams(string comment, string contractNumber, decimal amount = 0)
{
    public string Comment { get; set; } = comment;
    public decimal FixAmount { get; set; } = amount;
    public string ContractNumber { get; set; } = contractNumber;
}