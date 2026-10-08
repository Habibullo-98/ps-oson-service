namespace ps_oson_service.Model.Query;

public interface IQueryHandler<in TQuery, TResponse> where TQuery : IQuery<TResponse>
{
    public Task<Result<TResponse>> HandleAsync(TQuery query);
}