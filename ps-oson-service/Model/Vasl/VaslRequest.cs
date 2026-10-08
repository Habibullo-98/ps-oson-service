namespace ps_oson_service.Model.Vasl;

[PublicAPI]
public abstract record VaslRequest : IValidatableObject
{
    public int Id { get; init; }

    [JsonPropertyName("CallsigNumber")]
    public string CallSign { get; init; } = string.Empty;

    public decimal Amount { get; init; }

    public int ServiceId { get; init; }

    public List<VaslRequestParam> Params { get; init; } = [];

    public string PayType => Params.FirstOrDefault(param => param.Comment == "type", new VaslRequestParam()).Values
        ?? "TOP_UP";

    public abstract IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
}

[PublicAPI]
public record VaslRequestParam
{
    public string Comment { get; init; } = string.Empty;
    public string? Values { get; init; }
}