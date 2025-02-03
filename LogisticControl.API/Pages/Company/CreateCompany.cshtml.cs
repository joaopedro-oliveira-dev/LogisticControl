using LogisticControl.Core.Helpers;
using LogisticControl.Domain.DTOs;
using LogisticControl.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LogisticControl.Api.Pages.Company;

public class CreateCompanyModel : PageModel
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<CreateCompanyModel> _logger;

    public CreateCompanyModel(HttpClient httpClient, ILogger<CreateCompanyModel> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }
    public List<string> PartnershipTypes { get; set; } = new();
    public void OnGet()
    {
        PartnershipTypes = Enum.GetValues(typeof(PartnershipTypeEnum))
            .Cast<PartnershipTypeEnum>()
            .Select(e => e.GetFormattedName())
            .ToList();
    }
    [BindProperty]
    public CompanyPostDTO Company { get; set; } = new();
    public async Task OnPostAsync()
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7235/Company", Company);

            if (response.IsSuccessStatusCode)
            {
                return;
                //return RedirectToPage("Success"); // Redireciona para uma página de sucesso
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Erro ao cadastrar empresa.");
            }
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Erro ao cadastrar empresa.");
            ModelState.AddModelError(string.Empty, "Erro ao conectar-se ao servidor.");
        }
    }
}