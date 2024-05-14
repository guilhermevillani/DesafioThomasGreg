using DesafioTecnicoThomasGregFront.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;

namespace DesafioTecnicoThomasGregFront.Pages
{
    public class HomeModel : PageModel
    {
        public string ErrorMessage { get; set; }

        [BindProperty]
        public IEnumerable<ClientDTO>? clients { get; set; } = new List<ClientDTO>();

        private readonly HttpClient _httpClient;

        [BindProperty]
        public ClientDTO currentClient { get; set; }

        public HomeModel(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }
        public async Task<IActionResult> OnGet()
        {
            var token = HttpContext.Session.GetString("Token");

            // Incluir a token no cabe�alho da requisi��o
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Fazer uma requisi��o � API
            var response = await _httpClient.GetAsync("http://localhost:44394/api/Clients");

            // Verificar se a requisi��o foi bem-sucedida
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var responseObject = JsonSerializer.Deserialize<IEnumerable<ClientDTO>>(responseBody);
                clients = responseObject;
                HttpContext.Session.SetString("Clients", JsonSerializer.Serialize(clients));

                return Page();
            }
            else
            {
                return Redirect("Login");
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Aqui voc� pode escrever o c�digo que deseja executar ap�s o clique do bot�o
            // Por exemplo, voc� pode chamar outro m�todo, manipular dados do formul�rio, etc.
        }

        public IActionResult OnPost(ClientDTO client)
        {
            // Processar o modelo do cliente
            return RedirectToAction("EditClient"); // Ou outra a��o ap�s a edi��o
        }
        public async Task OnPostButton()
        {

            var currentCliensat = currentClient;


        }

        public IActionResult OnPostEdit(ClientDTO model)
        {

            // Access the client data from the 'model' parameter (including Id, Name, Email)
            // ... update the client data
            // ... return a view or redirect
            return RedirectToPage("/EditClient", new { clientId = model.Id });
        }
    }
}
