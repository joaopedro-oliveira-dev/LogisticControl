using LogisticControl.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LogisticControl.Api.Pages.Driver;

public class IndexModel : PageModel
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(HttpClient httpClient, ILogger<IndexModel> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public List<DriverGetDTO> Drivers { get; set; } = new();

    public async Task OnGet()
    {
        try
        {
            Drivers = await _httpClient.GetFromJsonAsync<List<DriverGetDTO>>("https://localhost:7235/Driver") ?? new List<DriverGetDTO>();
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Erro ao buscar dados dos motoristas.");
        }
    }
}