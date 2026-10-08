using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace ps_oson_service.Logger;

public static partial class Logger
{
    [LoggerMessage(LogLevel.Information, Message = "Account query: {query}")]
    public static partial void LogAccountQuery(this ILogger logger, AccountQuery query);
    
    [LoggerMessage(LogLevel.Information, Message = "Calculate query: {query}")]
    public static partial void LogCalculateQuery(this  ILogger logger, CalculateQuery query);
    
    [LoggerMessage(LogLevel.Information, Message = "Services query: {query}")]   
    public static partial void LogServicesQuery(this ILogger logger, ServicesQuery query);

    [LoggerMessage(LogLevel.Information, Message = "Transactions query {query}")]
    public static partial void LogTransactionsQuery(this ILogger logger, TransactionsQuery query);

    [LoggerMessage(LogLevel.Information, Message = "Deposit query: {query}")]   
    public static partial void LogDepositQuery(this ILogger logger, DepositQuery query);

    [LoggerMessage(LogLevel.Information, Message = "Status query: {query}")]
    public static partial void LogStatusQuery(this ILogger logger, StatusQuery query);

    [LoggerMessage(LogLevel.Information, Message = "Pay command: {command}")]
    public static partial void LogPayCommand(this ILogger logger, PayCommand command);
    
    [LoggerMessage(LogLevel.Information, Message = "POST {url}\n{request}")]
    public static partial void LogRequest(this ILogger logger, string url, OsonRequest request);

    [LoggerMessage(LogLevel.Information, Message = "Response\n{response}")]
    public static partial void LogResponse(this ILogger logger, OsonResponse response);

    [LoggerMessage(LogLevel.Error, Message = "Error sending request to OSON")]
    public static partial void LogRequestError(this ILogger logger, Exception exception);

    [LoggerMessage(LogLevel.Information, Message = "GET {url}")]
    public static partial void LogGetRequest(this ILogger logger, string url);
}