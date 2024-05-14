using DesafioTecnicoThomasGregFront.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;

namespace DesafioTecnicoThomasGregFront.Pages
{
    public class RegisterClientModel : PageModel
    {
        [BindProperty]
        public ClientDTO Client { get; set; } = new ClientDTO();

        [BindProperty]
        public virtual IEnumerable<AddressDTO?>? Addresses { get; set; } = new List<AddressDTO>();
        public string ErrorMessage { get; set; }

        private readonly HttpClient _httpClient;

        public RegisterClientModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> OnPostAsync()
        {

            var newClient = Client;

            newClient.Logotipo = "teste";

            var token = HttpContext.Session.GetString("Token");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var content = new StringContent(JsonSerializer.Serialize(newClient), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:44394/api/Clients", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("Home");
            }
            else
            {
                ErrorMessage = "Erro ao adicionar Cliente, tente novamente mais tarde!";
                return Page();
            }
        }
    }
}
