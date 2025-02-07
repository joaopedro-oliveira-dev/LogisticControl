using LogisticControl.Core.Helpers;
using LogisticControl.Domain.DTOs;
using LogisticControl.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LogisticControl.Api.Pages.Company.Address
{
    public class UpdateAddressModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<UpdateAddressModel> _logger;

        public UpdateAddressModel(HttpClient httpClient, ILogger<UpdateAddressModel> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public AddressGetDTO? Address { get; set; } = new();
        public List<StateEnum> States { get; set; } = new();

        public async Task OnGet()
        {
            try
            {
                Address = await _httpClient.GetFromJsonAsync<AddressGetDTO>($"https://localhost:7235/Address/{Id}");
                States = EnumExtensions.GetAllEnums<StateEnum>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar endereço.");
            }
        }
        [BindProperty]
        public AddressPutDTO AddressPut { get; set; } = new();
        public int CompanyId { get; set; } = new();
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"https://localhost:7235/Address/{Id}", AddressPut);

                if (response.IsSuccessStatusCode)
                {
                    Address = await _httpClient.GetFromJsonAsync<AddressGetDTO>($"https://localhost:7235/Address/{Id}");
                    return RedirectToPage("ViewCompany", new { id = Address.CompanyId });
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
}