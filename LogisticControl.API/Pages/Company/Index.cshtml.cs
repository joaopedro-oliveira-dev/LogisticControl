using LogisticControl.Core.HttpClients;
using LogisticControl.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LogisticControl.Api.Pages.Company;

public class IndexModel : PageModel
{
    private readonly CompanyHttpClient _httpClient;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(CompanyHttpClient httpClient, ILogger<IndexModel> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public List<CompanyGetDTO> Companies { get; set; } = new();
    public async Task OnGetAsync()
    {
        try
        {
            Companies = await _httpClient.GetAllCompaniesAsync();
        }
        catch (HttpRequestException ex) 
        {
            _logger.LogError(ex, "Erro ao buscar dados das empresas.");
        }
    }
}