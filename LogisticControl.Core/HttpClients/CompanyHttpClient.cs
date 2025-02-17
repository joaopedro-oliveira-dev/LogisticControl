using LogisticControl.Domain.DTOs;

namespace LogisticControl.Core.HttpClients;

public class CompanyHttpClient
{
    private readonly ApiHttpClient _httpClient;
    private const string BaseEndpoint = "Company";

    public CompanyHttpClient(ApiHttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<CompanyGetDTO>> GetAllCompaniesAsync()
    {
        return await _httpClient.GetAsync<List<CompanyGetDTO>>(BaseEndpoint) ?? new List<CompanyGetDTO>();
    }
    public async Task<CompanyGetDTO?> GetCompanyAsyncById(int id)
    {
        return await _httpClient.GetAsync<CompanyGetDTO>($"{BaseEndpoint}/{id}");
    }
    public async Task<HttpResponseMessage> CreateCompanyAsync(CompanyPostDTO model)
    {
        return await _httpClient.PostAsync(BaseEndpoint, model);
    }
    public async Task<HttpResponseMessage> UpdateCompanyAsync(int id, CompanyPutDTO model)
    {
        return await _httpClient.PutAsync($"{BaseEndpoint}/{id}", model);
    }
    public async Task<HttpResponseMessage> DeleteCompanyAsync(int id)
    {
        return await _httpClient.DeleteAsync($"{BaseEndpoint}/{id}");
    }
}