using LogisticControl.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LogisticControl.Api.Pages.Company;

public class IndexModel : PageModel
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(HttpClient httpClient, ILogger<IndexModel> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public List<CompanyGetDTO> Companies { get; set; } = new();
    public async Task OnGetAsync()
    {
        try
        {
            Companies = await _httpClient.GetFromJsonAsync<List<CompanyGetDTO>>("https://localhost:7235/Company") ?? new List<CompanyGetDTO>();
        }
        catch (HttpRequestException ex) 
        {
            _logger.LogError(ex, "Erro ao buscar dados das empresas.");
        }
    }
}