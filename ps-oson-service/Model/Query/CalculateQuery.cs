namespace ps_oson_service.Model.Query;

public record CalculateQuery : BaseQuery<OsonCalculateResponse>
{
    public int ServiceId { get; init; }
    public string Account { get; init; }
    public string AgentTransactionId { get; init; }
    public string PayType { get; init; }
    public Dictionary<string, object> Params { get; } = new();


    public bool IsFixed => PayType == "TOP_UP_FIXED";
    public bool IsPin => PayType == "PIN";
    public bool IsVoucher => PayType == "VOUCHER";
    public bool IsTopUp => PayType == "TOP_UP";

    public CalculateQuery(VaslAccountRequest request)
    {
        ServiceId = request.ServiceId;
        Account = request.CallSign;
        AgentTransactionId = request.Id.ToString();
        PayType = request.PayType;

        foreach (var param in request.Params)
        {
            Params.Add(param.Comment, param.Values);
        }
    }

    public override string ToString() => ToLogString();
}