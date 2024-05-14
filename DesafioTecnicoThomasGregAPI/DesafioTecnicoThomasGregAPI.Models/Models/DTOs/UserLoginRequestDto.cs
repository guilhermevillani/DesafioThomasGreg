namespace DesafioTecnicoThomasGregAPI.Models.DTOs
{
    public class UserLoginRequestDto
    {
        public required string Email { get; set; } = string.Empty;
        public required string Password { get; set; } = string.Empty;
    }
}
