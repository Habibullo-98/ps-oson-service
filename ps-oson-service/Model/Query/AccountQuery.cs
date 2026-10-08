namespace ps_oson_service.Model.Query;

public record AccountQuery : BaseQuery<OsonAccountResponse>
{
    public string Account { get; }
    public string TransactionId { get; }
    public decimal Amount { get; }
    public int ServiceId { get; }
    public string PayType { get; }

    public Dictionary<string, object> Params { get; } = new();

    public bool IsFixed => PayType == "TOP_UP_FIXED";
    public bool IsPin => PayType == "PIN";
    public bool IsVoucher => PayType == "VOUCHER";
    public bool IsTopUp => PayType == "TOP_UP";

    public AccountQuery(VaslAccountRequest request)
    {
        Account = request.CallSign;
        TransactionId = request.Id.ToString();
        Amount = request.Amount;
        ServiceId = request.ServiceId;
        PayType = request.PayType;

        foreach (var param in request.Params)
        {
            Params.Add(param.Comment, param.Values);
        }
    }

    public override string ToString() => ToLogString();
}