using LogisticControl.Core.Helpers.Extensions;
using LogisticControl.Core.HttpClients;
using LogisticControl.Domain.DTOs;
using LogisticControl.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LogisticControl.Api.Pages.Company;

public class UpdateCompanyModel : PageModel
{
    private readonly CompanyHttpClient _httpClient;
    private readonly ILogger<CreateCompanyModel> _logger;

    public UpdateCompanyModel(CompanyHttpClient httpClient, ILogger<CreateCompanyModel> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }
    public CompanyGetDTO? Company { get; set; } = new();
    public List<PartnershipTypeEnum> PartnershipTypes { get; set; } = new();
    public async Task OnGetAsync()
    {
        Company = await _httpClient.GetCompanyAsyncById(Id);
        //if (Company == null )
        //{
        //    return RedirectToPage("/EmpresaInexistente");
        //}
        PartnershipTypes = EnumExtensions.GetAllEnums<PartnershipTypeEnum>();
    }
    [BindProperty]
    public CompanyPutDTO CompanyPut { get; set; } = new();
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        try
        {
            var response = await _httpClient.UpdateCompanyAsync(Id, CompanyPut);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("Index");
            }
            else
            {
                var errors = await response.Content.ReadFromJsonAsync<Dictionary<string, string[]>>();
                if (errors != null)
                {
                    foreach (var error in errors)
                    {
                        foreach (var message in error.Value)
                        {
                            ModelState.AddModelError(error.Key, message);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Erro ao editar empresa.");
                    return Page();
                }
            }
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Erro ao editar empresa.");
            ModelState.AddModelError(string.Empty, "Erro ao conectar-se ao servidor.");
        }

        return Page();
    }
}