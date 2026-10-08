namespace ps_oson_service.Model.Command;

public interface ICommandHandler<in TCommand, TResponse> where TCommand : ICommand<TResponse>
{
    public Task<Result<TResponse>> HandleAsync(TCommand command);
}