using LogisticControl.Core.HttpClients;
using LogisticControl.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LogisticControl.Api.Pages.Driver;

public class CreateDriverModel : PageModel
{
    private readonly DriverHttpClient _httpClient;
    private readonly ILogger<CreateDriverModel> _logger;

    public CreateDriverModel(DriverHttpClient httpClient, ILogger<CreateDriverModel> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    [BindProperty]
    public DriverPostDTO Driver { get; set; } = new();
    
    public async Task<IActionResult> OnPostAsync()
    {
        try
        {
            var response = await _httpClient.CreateDriverAsync(Driver);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Erro ao cadastrar motorista.");
                return Page();
            }
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Erro ao cadastrar motorista.");
            ModelState.AddModelError(string.Empty, "Erro ao conectar-se ao servidor.");
            return Page();
        }
    }
}