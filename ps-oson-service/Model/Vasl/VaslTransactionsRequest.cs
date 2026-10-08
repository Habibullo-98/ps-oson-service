namespace ps_oson_service.Model.Vasl;

[PublicAPI]
public record VaslTransactionsRequest : VaslRequest
{
    [FromQuery(Name = "date")] 
    public string Date { get; init; } = string.Empty;

    public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrEmpty(Date))
            yield return new ValidationResult("Date is required");
    }
}