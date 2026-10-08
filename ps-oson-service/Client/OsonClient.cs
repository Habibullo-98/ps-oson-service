namespace ps_oson_service.Client;

public class OsonClient : IOsonClient
{
    private readonly OsonOptions _oson;
    private readonly HttpClient _client;
    private readonly ILogger<OsonClient> _logger;
    
    private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions { WriteIndented = true };

    public OsonClient(HttpClient client, IOptions<OsonOptions> options, ILogger<OsonClient> logger)
    {
        _client = client;
        _logger = logger;
        _oson = options.Value;

        _client.BaseAddress = new Uri(_oson.Urls.Base);
        _client.DefaultRequestHeaders.Add("token", _oson.Token);
    }

    public async Task<Result<OsonCalculateResponse>> SendAsync(OsonCalculateRequest request)
    {
        return await SendAsync<OsonCalculateRequest, OsonCalculateResponse>(_oson.Urls.Calculate, request);
    }

    public async Task<Result<OsonAccountResponse>> SendAsync(OsonAccountRequest request)
    {
        return await SendAsync<OsonAccountRequest, OsonAccountResponse>(_oson.Urls.Check, request);
    }

    public async Task<Result<OsonPaymentResponse>> SendAsync(OsonPaymentRequest request)
    {
        return await SendAsync<OsonPaymentRequest, OsonPaymentResponse>(_oson.Urls.Pay, request);
    }

    public async Task<Result<OsonStatusResponse>> SendAsync(OsonStatusRequest request)
    {
        return await SendAsync<OsonStatusRequest, OsonStatusResponse>(_oson.Urls.Status, request);
    }

    public async Task<Result<OsonTransactionsResponse>> GetAsync(OsonTransactionsRequest request)
    {
        return await GetAsync<OsonTransactionsRequest, OsonTransactionsResponse>(_oson.Urls.Transaction, request);
    }

    public async Task<Result<List<OsonServiceResponse>>> GetAsync(OsonServicesRequest request)
    {
        return await GetAsync<OsonServicesRequest, List<OsonServiceResponse>>(_oson.Urls.Service, request);
    }

    public async Task<Result<OsonDepositResponse>> GetAsync(OsonDepositRequest request)
    {
        return await GetAsync<OsonDepositRequest, OsonDepositResponse>(_oson.Urls.Deposit, request);
    }

    private async Task<Result<TResponse>> SendAsync<TRequest, TResponse>(string url, TRequest request)
    where TRequest : OsonRequest
    where TResponse : OsonResponse
    {
        try
        {
            _logger.LogInformation($"POST {url}");
            _logger.LogInformation(JsonSerializer.Serialize(request, _jsonOptions));
            var response = await _client.PostAndGetJsonAsync<TRequest, TResponse>(url, request);
            if (response is null) return OsonErrors.InvalidResponse;
            _logger.LogInformation($"Response:\n{JsonSerializer.Serialize(response, _jsonOptions)}");
            return response;
        }
        catch (Exception e)
        {
            _logger.LogRequestError(e);
            return OsonErrors.HttpError(e.Message);
        }
    }

    private async Task<Result<TResponse>> GetAsync<TRequest, TResponse>(string url, TRequest request)
    where TRequest : OsonRequest, IQueryParameterable
    {
        try
        {
            _logger.LogInformation($"GET {url}");
            _logger.LogInformation(JsonSerializer.Serialize(request, _jsonOptions));
            var response = await _client.GetFromJsonAsync<TResponse>(url + request.ToQueryString());
            if (response is null) return OsonErrors.InvalidResponse;
            _logger.LogInformation($"Response:\n{JsonSerializer.Serialize(response, _jsonOptions)}");
            return response;
        }
        catch (Exception e)
        {
            _logger.LogRequestError(e);
            return OsonErrors.HttpError(e.Message);
        }
    }
}