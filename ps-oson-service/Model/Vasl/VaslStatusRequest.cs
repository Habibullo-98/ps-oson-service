namespace ps_oson_service.Model.Vasl;

[PublicAPI]
public record VaslStatusRequest : VaslRequest
{
    public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        return [];
    }
}