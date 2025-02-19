using LogisticControl.Domain.DTOs;

namespace LogisticControl.Core.HttpClients;

public class ServiceHttpClient
{
    private readonly ApiHttpClient _httpClient;
    private const string BaseEndpoint = "Service";

    public ServiceHttpClient(ApiHttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ServiceGetDTO>> GetAllServicesAsync()
    {
        return await _httpClient.GetAsync<List<ServiceGetDTO>>(BaseEndpoint) ?? new List<ServiceGetDTO>();
    }
    public async Task<ServiceGetDTO?> GetServiceAsyncById(int id)
    {
        return await _httpClient.GetAsync<ServiceGetDTO>($"{BaseEndpoint}/{id}");
    }
    public async Task<HttpResponseMessage> CreateServiceAsync(ServicePostDTO model)
    {
        return await _httpClient.PostAsync(BaseEndpoint, model);
    }
    public async Task<HttpResponseMessage> UpdateServiceAsync(int id, ServicePutDTO model)
    {
        return await _httpClient.PutAsync($"{BaseEndpoint}/{id}", model);
    }
    public async Task<HttpResponseMessage> DeleteServiceAsync(int id)
    {
        return await _httpClient.DeleteAsync($"{BaseEndpoint}/{id}");
    }
}