using LogisticControl.Domain.DTOs;

namespace LogisticControl.Core.HttpClients;

public class AddressHttpClient
{
    private readonly ApiHttpClient _httpClient;
    private const string BaseEndpoint = "Address";
    public AddressHttpClient(ApiHttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<AddressGetDTO>> GetAllAddressesAsync()
    {
        return await _httpClient.GetAsync<List<AddressGetDTO>>(BaseEndpoint) ?? new List<AddressGetDTO>();
    }
    public async Task<AddressGetDTO?> GetAddressAsyncById(int id)
    {
        return await _httpClient.GetAsync<AddressGetDTO>($"{BaseEndpoint}/{id}");
    }
    public async Task<HttpResponseMessage> CreateAddressAsync(AddressPostDTO model)
    {
        return await _httpClient.PostAsync(BaseEndpoint, model);
    }
    public async Task<HttpResponseMessage> UpdateAddressAsync(int id, AddressPutDTO model)
    {
        return await _httpClient.PutAsync($"{BaseEndpoint}/{id}", model);
    }
    public async Task<HttpResponseMessage> DeleteAddressAsync(int id)
    {
        return await _httpClient.DeleteAsync($"{BaseEndpoint}/{id}");
    }
}