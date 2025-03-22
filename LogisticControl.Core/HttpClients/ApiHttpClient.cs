using System.Net.Http.Json;

namespace LogisticControl.Core.HttpClients;

public class ApiHttpClient
{
    private readonly HttpClient _httpClient;

    public ApiHttpClient(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("LogisticControlApi");
    }

    public async Task<TResult?> GetAsync<TResult>(string endpoint) where TResult : class
    {
        return await _httpClient.GetFromJsonAsync<TResult>(endpoint);
    }
    public async Task<HttpResponseMessage> PostAsync<TData>(string endpoint, TData data) where TData : class
    {
        return await _httpClient.PostAsJsonAsync(endpoint, data);
    }
    public async Task<HttpResponseMessage> PutAsync<TData>(string endpoint, TData data) where TData : class
    {
        return await _httpClient.PutAsJsonAsync(endpoint, data);
    }
    public async Task<HttpResponseMessage> DeleteAsync(string endpoint)
    {
        return await _httpClient.DeleteAsync(endpoint);
    }
}