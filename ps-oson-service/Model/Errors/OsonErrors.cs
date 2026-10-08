namespace ps_oson_service.Model.Errors;

public static class OsonErrors
{
    public static Error InvalidResponse => new("OsonErrors.InvalidResponse", "Invalid response from OSON");
    public static Error HttpError(string message) => new("OsonErrors.HttpError", message);
    public static Error Unauthorized => new("OsonErrors.Unauthorized", "Unauthorized");
    public static Error MissingParameters => new("OsonErrors.MissingParameters", "Parameters are missing");
    public static Error InvalidParameters => new("OsonErrors.InvalidParameters", "Parameters are invalid");
    public static Error MerchantNotFound => new("OsonErrors.MerchantNotFound", "Merchant not found");
    public static Error MerchantPaymentNotAllowed => new("OsonErrors.MerchantPaymentNotAllowed", "Merchant payment not allowed");
    public static Error AmountLessThanMinimum => new("OsonErrors.AmountLessThanMinimum", "Amount less than minimum");
    public static Error AmountGreaterThanMaximum => new("OsonErrors.AmountGreaterThanMaximum", "Amount greater than maximum");
    public static Error TransactionNotFound => new("OsonErrors.TransactionNotFound", "Transaction not found");
    public static Error FailedTransaction => new("OsonErrors.FailedTransaction", "Failed transaction");
    public static Error InvalidTransaction => new("OsonErrors.InvalidTransaction", "Invalid transaction");
    public static Error InvalidIdentification => new("OsonErrors.InvalidIdentification", "Invalid identification");
    public static Error InvalidAmount => new("OsonErrors.InvalidAmount", "Invalid amount");
    public static Error ForbiddenMethod => new("OsonErrors.ForbiddenMethod", "Forbidden method");
    public static Error DepositNotFound => new("OsonErrors.DepositNotFound", "Deposit not found");
    public static Error OldTransaction => new("OsonErrors.OldTransaction", "Old transaction");
    public static Error DuplicateTransaction => new("OsonErrors.DuplicateTransaction", "Duplicate transaction");
    public static Error InactiveAgent => new("OsonErrors.InactiveAgent", "Inactive agent");
    public static Error TechnicalError => new("OsonErrors.TechnicalError", "Technical error");
    public static Error InsufficientGiftCards => new("OsonErrors.InsufficientGiftCards", "Insufficient gift cards");
    public static Error LimitExceeded => new("OsonErrors.LimitExceeded", "Limit exceeded");
    public static Error IncompleteSubmission => new("OsonErrors.IncompleteSubmission", "Incomplete submission");
    public static Error MonthlyLimitExceeded => new("OsonErrors.MonthlyLimitExceeded", "Monthly limit exceeded");
    public static Error DailyLimitExceeded => new("OsonErrors.DailyLimitExceeded", "Daily limit exceeded");
    public static Error InactiveService => new("OsonErrors.InactiveService", "Inactive service");
    public static Error UnavailableBranch => new("OsonErrors.UnavailableBranch", "Unavailable branch");
    public static Error MerchantError => new("OsonErrors.MerchantError", "Merchant error");
    public static Error PayTimeExceeded => new("OsonErrors.PayTimeExceeded", "Pay time exceeded");
    public static Error AlreadyPaid => new("OsonErrors.AlreadyPaid", "Already paid");
    public static Error UnknownError => new("OsonErrors.UnknownError", "Unknown error");
    public static Error AccountNotFound => new("OsonErrors.AccountNotFound", "Account not found");
    public static Error InsufficientDeposit => new("OsonErrors.InsufficientDeposit", "Insufficient deposit");
    public static Error PaymentNotAuthorized => new("OsonErrors.PaymentNotAuthorized", "Payment not authorized");
}