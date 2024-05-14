using DesafioTecnicoThomasGregFront.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace DesafioTecnicoThomasGregFront.Pages
{
	public class LoginModel : PageModel
	{
		[BindProperty]
		public string Username { get; set; }

		[BindProperty]
		public string Password { get; set; }

		public string Token { get; set; }

		public string ErrorMessage { get; set; }


		private readonly System.Net.Http.HttpClient _httpClient;

		public LoginModel(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<IActionResult> OnPostAsync()
		{
			var loginData = new
			{
				email = Username,
				password = Password
			};

			var content = new StringContent(JsonSerializer.Serialize(loginData), System.Text.Encoding.UTF8, "application/json");

			var response = await _httpClient.PostAsync("http://localhost:44394/api/AuthManagement/Login", content);

			if (response.IsSuccessStatusCode)
			{
				var responseBody = await response.Content.ReadAsStringAsync();
				var responseObject = JsonSerializer.Deserialize<AuthResult>(responseBody);

				HttpContext.Session.SetString("Token", responseObject.Token);


				return RedirectToPage("Home");

			}
			else
			{
				ErrorMessage = "Usu�rio ou senha incorretos.";
				return Page();              // Lidar com erro de autentica��o
			}
		}
	}
}
