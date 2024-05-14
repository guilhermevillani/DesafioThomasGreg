using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace DesafioTecnicoThomasGregFront.Pages
{
	public class RegisterModel : PageModel
	{
		[BindProperty]
		public string Name { get; set; }

		[BindProperty]
		public string Email { get; set; }

		[BindProperty]
		public string Password { get; set; }
		public IEnumerable<string>? ErrorMessage { get; set; } = new List<string>();

		private readonly System.Net.Http.HttpClient _httpClient;

		public RegisterModel(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<IActionResult> OnPostAsync()
		{
			var loginData = new
			{
				name = Name,
				email = Email,
				password = Password
			};

			var content = new StringContent(JsonSerializer.Serialize(loginData), System.Text.Encoding.UTF8, "application/json");

			var response = await _httpClient.PostAsync("http://localhost:44394/api/AuthManagement/Register", content);

			if (response.IsSuccessStatusCode)
			{
				return RedirectToPage("Login");
			}
			else
			{
				var responseBody = await response.Content.ReadAsStringAsync();
				var responseObject = JsonSerializer.Deserialize<IEnumerable<string>>(responseBody);
				ErrorMessage = responseObject ?? ErrorMessage;
				return Page();
			}
		}
	}
}
