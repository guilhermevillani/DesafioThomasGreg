namespace DesafioTecnicoThomasGregFront.Models
{
    public class ClientDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Logotipo { get; set; }
        public virtual IEnumerable<AddressDTO?>? Addresses { get; set; }
    }
}
