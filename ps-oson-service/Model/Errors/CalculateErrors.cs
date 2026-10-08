namespace ps_oson_service.Model.Errors;

public static class CalculateErrors
{
    public static Error ServiceTypeNotAllowed => new("CalculateErrors.ServiceTypeNotAllowed", "Service type not allowed");
}