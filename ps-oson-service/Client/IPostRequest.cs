namespace ps_oson_service.Client;

public interface IPostRequest<in TRequest, TResponse>
{
    public Task<Result<TResponse>> SendAsync(TRequest request);
}