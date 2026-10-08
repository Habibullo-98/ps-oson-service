namespace ps_oson_service.Model.Errors;

public record Error(string Code, string Description)
{
    public static Error None => new Error(string.Empty, string.Empty);
}