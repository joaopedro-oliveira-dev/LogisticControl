using LogisticControl.Domain.DTOs;
using LogisticControl.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LogisticControl.Api.Pages.Driver;

public class UpdateDriverModel : PageModel
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<UpdateDriverModel> _logger;

    public UpdateDriverModel(HttpClient httpClient, ILogger<UpdateDriverModel> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }
    public DriverGetDTO? Driver { get; set; } = new();

    public async Task OnGetAsync()
    {
        try
        {
            Driver = await _httpClient.GetFromJsonAsync<DriverGetDTO>($"https://localhost:7235/Driver/{Id}");
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Erro ao buscar dados dos motoristas.");
        }
    }
    [BindProperty]
    public DriverPutDTO DriverPut { get; set; }
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"https://localhost:7235/Driver/{Id}", DriverPut);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("Index");
            }
            else
            {
                var errors = await response.Content.ReadFromJsonAsync<Dictionary<string, string[]>>();
                if (errors != null)
                {
                    foreach(var error in errors)
                    {
                        foreach (var message in error.Value)
                        {
                            ModelState.AddModelError(error.Key, message);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Erro ao editar motorista.");
                    return Page();
                }
            }
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Erro ao editar motorista.");
            ModelState.AddModelError(string.Empty, "Erro ao conectar-se ao servidor.");
        }

        return Page();
    }
}