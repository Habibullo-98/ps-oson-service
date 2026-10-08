namespace ps_oson_service.Client;

public interface IGetRequest<in TRequest, TResponse>
{
    public Task<Result<TResponse>> GetAsync(TRequest request);
}