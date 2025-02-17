using LogisticControl.Core.HttpClients;
using LogisticControl.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LogisticControl.Api.Pages.Driver;

public class IndexModel : PageModel
{
    private readonly DriverHttpClient _httpClient;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(DriverHttpClient httpClient, ILogger<IndexModel> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public List<DriverGetDTO> Drivers { get; set; } = new();

    public async Task OnGet()
    {
        try
        {
            Drivers = await _httpClient.GetAllDriversAsync();
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Erro ao buscar dados dos motoristas.");
        }
    }
}