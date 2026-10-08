using System.Diagnostics.CodeAnalysis;

namespace ps_oson_service.Model;

public record Result
{
    public bool IsSuccess { get; private set; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; private set; }
    
    private protected Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None)
            throw new ArgumentException("Error cannot be provided when result is success");
        
        if (!isSuccess && error == Error.None)
            throw new ArgumentException("Error must be provided when result is failure");
        
        IsSuccess = isSuccess;
        Error = error;
    }
    
    public static Result Success() => new(true, Error.None);
    public static Result Failure(Error error) => new(false, error);
}

public record Result<T> : Result
{
    public T? Value { get; private set; }

    private Result(T value) : base(true, Error.None) => Value = value;
    private Result(Error error) : base(false, error) => Value = default;
    
    [MemberNotNullWhen(false, nameof(Value))]
    public new bool IsFailure => !IsSuccess;

    public static implicit operator Result<T>(T value) => new(value);
    public static implicit operator Result<T>(Error error) => new(error);
}