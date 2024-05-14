using DesafioTecnicoThomasGregFront.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;

namespace DesafioTecnicoThomasGregFront.Pages
{
    public class EditClientModel : PageModel
    {
        [BindProperty]
        public ClientDTO Client { get; set; } = new ClientDTO();

        [BindProperty]
        public string AllAddresses { get; set; }

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Email { get; set; }

        public string ErrorMessage { get; set; }
        [BindProperty]
        public string LogotipoBase64 { get; set; }

        private readonly HttpClient _httpClient;

        public EditClientModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public void OnGet(int clientId)
        {
            var clientsJson = HttpContext.Session.GetString("Clients");
            if (clientsJson != null)
            {
                var clientsObj = JsonSerializer.Deserialize<List<ClientDTO>>(clientsJson);
                var currentClient = clientsObj.FirstOrDefault(c => c.Id == clientId);
                Client = currentClient;
                Name = Client.Name;
                Email = Client.Email;

            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var updatedClient = Client;

            updatedClient.Name = Name;
            updatedClient.Email = Email;
            updatedClient.Logotipo = LogotipoBase64;
            updatedClient.Addresses = JsonSerializer.Deserialize<IEnumerable<AddressDTO>>(AllAddresses);

            var token = HttpContext.Session.GetString("Token");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var content = new StringContent(JsonSerializer.Serialize(updatedClient), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PatchAsync("http://localhost:44394/api/Clients", content);

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
