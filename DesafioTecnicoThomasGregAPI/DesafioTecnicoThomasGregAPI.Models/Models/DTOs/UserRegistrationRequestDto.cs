﻿namespace DesafioTecnicoThomasGregAPI.Models.DTOs
{
    public class UserRegistrationRequestDto
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
