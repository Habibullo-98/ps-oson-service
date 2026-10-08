namespace ps_oson_service.Model.Query;

public record StatusQuery : BaseQuery<OsonStatusResponse>
{
    public string TransactionId { get; }

    public StatusQuery(VaslStatusRequest request)
    {
        TransactionId = request.Id.ToString(); // TODO Check whether transaction id comes from this field
    }

    public override string ToString() => ToLogString();
}