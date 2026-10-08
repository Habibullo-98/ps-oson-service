using System.Text;

namespace ps_oson_service.Model.Command;

public record PayCommand : ICommand<OsonPaymentResponse>
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


    public PayCommand(VaslPaymentRequest request)
    {
        TransactionId = request.Id.ToString();
        Account = request.CallSign;
        Amount = request.Amount;
        ServiceId = request.ServiceId;
        PayType = request.PayType;

        foreach (var param in request.Params)
        {
            Params.Add(param.Comment, param.Values);
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine();
        sb.AppendLine("-------------------------------------------");
        sb.AppendLine("               Payment Request             ");
        var type = GetType();
        var properties = type.GetProperties();
        foreach (var propertyInfo in properties)
        {
            if (propertyInfo.Name == "Params") continue;
            int padding = 43 - propertyInfo.Name.Length - propertyInfo.GetValue(this)?.ToString()?.Length ?? 0;
            sb.Append(propertyInfo.Name);
            sb.Append(string.Empty.PadRight(padding));
            sb.Append(propertyInfo.GetValue(this));
            sb.AppendLine();
        }

        sb.Append(Params.ToLogString());
        sb.AppendLine("-------------------------------------------");

        return sb.ToString();
    }
}