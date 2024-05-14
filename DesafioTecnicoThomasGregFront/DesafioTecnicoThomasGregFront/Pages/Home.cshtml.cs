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

            // Incluir a token no cabeçalho da requisição
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Fazer uma requisição à API
            var response = await _httpClient.GetAsync("https://localhost:44394/api/Clients");

            // Verificar se a requisição foi bem-sucedida
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
            // Aqui você pode escrever o código que deseja executar após o clique do botão
            // Por exemplo, você pode chamar outro método, manipular dados do formulário, etc.
        }

        public IActionResult OnPost(ClientDTO client)
        {
            // Processar o modelo do cliente
            return RedirectToAction("EditClient"); // Ou outra ação após a edição
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
