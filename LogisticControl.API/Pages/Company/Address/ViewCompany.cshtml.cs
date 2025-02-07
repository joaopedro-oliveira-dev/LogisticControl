using LogisticControl.Core.Helpers;
using LogisticControl.Domain.DTOs;
using LogisticControl.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LogisticControl.Api.Pages.Company.Address;

public class ViewCompanyModel : PageModel
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<CreateCompanyModel> _logger;

    public ViewCompanyModel(HttpClient httpClient, ILogger<CreateCompanyModel> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }
    public CompanyGetDTO? Company { get; set; } = new();
    public List<PartnershipTypeEnum> PartnershipTypes { get; set; } = new();
    public List<AddressGetDTO>? Addresses { get; set; } = new();
    public List<StateEnum> States { get; set; } = new();
    [BindProperty]
    public AddressPostDTO Address { get; set; } = new();

    public async Task OnGetAsync()
    {
        Company = await _httpClient.GetFromJsonAsync<CompanyGetDTO>($"https://localhost:7235/Company/{Id}");
        //if (Company == null )
        //{
        //    return RedirectToPage("/EmpresaInexistente");
        //}
        PartnershipTypes = EnumExtensions.GetAllEnums<PartnershipTypeEnum>();
        Addresses = await _httpClient.GetFromJsonAsync<List<AddressGetDTO>>($"https://localhost:7235/Address/Company/{Id}");
        States = EnumExtensions.GetAllEnums<StateEnum>();
    }
    public async Task<IActionResult> OnPostAsync()
    {
        try
        {
            Address.CompanyId = Id;
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7235/Address", Address);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage();
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Erro ao cadastrar endereço.");
                return Page();
            }
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Erro ao cadastrar endereço.");
            ModelState.AddModelError(string.Empty, "Erro ao conectar-se ao servidor.");
            return Page();
        }
    }
}