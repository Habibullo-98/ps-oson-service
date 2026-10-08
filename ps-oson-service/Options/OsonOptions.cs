namespace ps_oson_service.Options;

public class OsonOptions
{
    public required Urls Urls { get; init; }
    public required string Token { get; init; }
}

[UsedImplicitly]
public class Urls
{
    public required string Base { get; init; }
    public required string Calculate { get; init; }
    public required string Check { get; init; }
    public required string Pay { get; init; }
    public required string Status { get; init; }
    public required string Service { get; init; }
    public required string Transaction { get; init; }
    public required string Deposit { get; init; }
}