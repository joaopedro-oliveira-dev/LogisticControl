using LogisticControl.Core.Helpers;
using LogisticControl.Domain.DTOs;
using LogisticControl.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LogisticControl.Api.Pages.Company;

public class UpdateCompanyModel : PageModel
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<CreateCompanyModel> _logger;

    public UpdateCompanyModel(HttpClient httpClient, ILogger<CreateCompanyModel> logger)
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
        Company = await _httpClient.GetFromJsonAsync<CompanyGetDTO>($"https://localhost:7235/Company/{Id}");
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
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"https://localhost:7235/Company/{Id}", CompanyPut);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/Company/Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Erro ao cadastrar empresa.");
                return Page();
            }
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Erro ao editar empresa.");
            ModelState.AddModelError(string.Empty, "Erro ao conectar-se ao servidor.");
            return Page();
        }
    }
}