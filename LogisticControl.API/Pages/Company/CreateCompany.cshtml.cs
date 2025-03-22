using LogisticControl.Core.Helpers.Extensions;
using LogisticControl.Core.HttpClients;
using LogisticControl.Domain.DTOs;
using LogisticControl.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LogisticControl.Api.Pages.Company;

public class CreateCompanyModel : PageModel
{
    private readonly CompanyHttpClient _httpClient;
    private readonly ILogger<CreateCompanyModel> _logger;

    public CreateCompanyModel(CompanyHttpClient httpClient, ILogger<CreateCompanyModel> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }
    public List<PartnershipTypeEnum> PartnershipTypes { get; set; } = new();
    public void OnGet()
    {
        PartnershipTypes = EnumExtensions.GetAllEnums<PartnershipTypeEnum>();
    }
    [BindProperty]
    public CompanyPostDTO Company { get; set; } = new();
    public async Task<IActionResult> OnPostAsync()
    {
        try
        {
            var response = await _httpClient.CreateCompanyAsync(Company);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Erro ao cadastrar empresa.");
                return Page();
            }
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Erro ao cadastrar empresa.");
            ModelState.AddModelError(string.Empty, "Erro ao conectar-se ao servidor.");
            return Page();
        }
    }
}