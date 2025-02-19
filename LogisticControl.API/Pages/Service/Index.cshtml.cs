using LogisticControl.Core.HttpClients;
using LogisticControl.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LogisticControl.Api.Pages.Service;

public class IndexModel : PageModel
{
    private readonly ServiceHttpClient _serviceHttpClient;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ServiceHttpClient httpClient)
    {
        _serviceHttpClient = httpClient;
    }

    public List<ServiceGetDTO> Services { get; set; } = new();

    public async Task OnGetAsync()
    {
        try
        {
            Services = await _serviceHttpClient.GetAllServicesAsync();
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Erro ao buscar dados dos serviços.");
        }
    }
}