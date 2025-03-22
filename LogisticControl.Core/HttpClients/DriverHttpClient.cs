using LogisticControl.Domain.DTOs;

namespace LogisticControl.Core.HttpClients;

public class DriverHttpClient
{
    private readonly ApiHttpClient _httpClient;
    private const string BaseEndpoint = "Driver";

    public DriverHttpClient(ApiHttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<DriverGetDTO>> GetAllDriversAsync()
    {
        return await _httpClient.GetAsync<List<DriverGetDTO>>(BaseEndpoint) ?? new List<DriverGetDTO>();
    }
    public async Task<DriverGetDTO?> GetDriverAsyncById(int id)
    {
        return await _httpClient.GetAsync<DriverGetDTO>($"{BaseEndpoint}/{id}");
    }
    public async Task<HttpResponseMessage> CreateDriverAsync(DriverPostDTO model)
    {
        return await _httpClient.PostAsync(BaseEndpoint, model);
    }
    public async Task<HttpResponseMessage> UpdateDriverAsync(int id, DriverPutDTO model)
    {
        return await _httpClient.PutAsync($"{BaseEndpoint}/{id}", model);
    }
    public async Task<HttpResponseMessage> DeleteDriverAsync(int id)
    {
        return await _httpClient.DeleteAsync($"{BaseEndpoint}/{id}");
    }
}