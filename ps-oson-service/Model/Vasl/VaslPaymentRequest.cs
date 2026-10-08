namespace ps_oson_service.Model.Vasl;

[PublicAPI]
public record VaslPaymentRequest : VaslRequest
{
    public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrEmpty(CallSign))
            yield return new ValidationResult("Call sign is required");
    }
}