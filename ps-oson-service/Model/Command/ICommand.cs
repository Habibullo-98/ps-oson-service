namespace ps_oson_service.Model.Command;

public interface IBaseCommand {}

public interface ICommand : IBaseCommand {}

public interface ICommand<TResponse> : IBaseCommand { }