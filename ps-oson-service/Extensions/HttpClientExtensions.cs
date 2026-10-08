namespace ps_oson_service.Extensions;

public static class HttpClientExtensions
{
    public static async Task<TResponse?> PostAndGetJsonAsync<TRequest, TResponse>(
        this HttpClient client, string uri, TRequest request)
    {
        var response = await client.PostAsJsonAsync(uri, request);
        return await response.Content.ReadFromJsonAsync<TResponse>();
    }
}