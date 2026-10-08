namespace ps_oson_service.Model.Oson;

[PublicAPI]
public record OsonResponse
{
    [JsonPropertyName("message")] 
    public string Message { get; init; } = string.Empty;
    
    [JsonPropertyName("success")]
    public bool Success { get; init; }
    
    [JsonPropertyName("status")]
    public OsonStatusCode Status { get; init; }
    
    [JsonIgnore]
    public bool IsFailure => !Success;

    [JsonIgnore]
    public Error Error
    {
        get
        {
            return Status switch
            {
                OsonStatusCode.Unauthorized => OsonErrors.Unauthorized,
                OsonStatusCode.MissingParameters => OsonErrors.MissingParameters,
                OsonStatusCode.InvalidParameters => OsonErrors.InvalidParameters,
                OsonStatusCode.MerchantNotFound => OsonErrors.MerchantNotFound,
                OsonStatusCode.MerchantPaymentNotAllowed => OsonErrors.MerchantPaymentNotAllowed,
                OsonStatusCode.AmountLessThanMinimum => OsonErrors.AmountLessThanMinimum,
                OsonStatusCode.AmountGreaterThanMaximum => OsonErrors.AmountGreaterThanMaximum,
                OsonStatusCode.TransactionNotFound => OsonErrors.TransactionNotFound,
                OsonStatusCode.FailedTransaction => OsonErrors.FailedTransaction,
                OsonStatusCode.InvalidTransaction => OsonErrors.InvalidTransaction,
                OsonStatusCode.AccountNotFound => OsonErrors.AccountNotFound,
                OsonStatusCode.InsufficientDeposit => OsonErrors.InsufficientDeposit,
                OsonStatusCode.PaymentNotAuthorized => OsonErrors.PaymentNotAuthorized,
                OsonStatusCode.InvalidIdentification => OsonErrors.InvalidIdentification,
                OsonStatusCode.InvalidAmount => OsonErrors.InvalidAmount,
                OsonStatusCode.ForbiddenMethod => OsonErrors.ForbiddenMethod,
                OsonStatusCode.DepositNotFound => OsonErrors.DepositNotFound,
                OsonStatusCode.OldTransaction => OsonErrors.OldTransaction,
                OsonStatusCode.DuplicateTransaction => OsonErrors.DuplicateTransaction,
                OsonStatusCode.InactiveAgent => OsonErrors.InactiveAgent,
                OsonStatusCode.TechnicalError => OsonErrors.TechnicalError,
                OsonStatusCode.InsufficientGiftCards => OsonErrors.InsufficientGiftCards,
                OsonStatusCode.LimitExceeded => OsonErrors.LimitExceeded,
                OsonStatusCode.IncompleteSubmission => OsonErrors.IncompleteSubmission,
                OsonStatusCode.MonthlyLimitExceeded => OsonErrors.MonthlyLimitExceeded,
                OsonStatusCode.DailyLimitExceeded => OsonErrors.DailyLimitExceeded,
                OsonStatusCode.InactiveService => OsonErrors.InactiveService,
                OsonStatusCode.UnavailableBranch => OsonErrors.UnavailableBranch,
                OsonStatusCode.MerchantError => OsonErrors.MerchantError,
                OsonStatusCode.PayTimeExceeded => OsonErrors.PayTimeExceeded,
                OsonStatusCode.AlreadyPaid => OsonErrors.AlreadyPaid,
                OsonStatusCode.UnknownError => OsonErrors.UnknownError,
                _ => Error.None
            };
        }
    }
    
    public string ToJson() => JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
}