namespace DesafioTecnicoThomasGregFront.Models
{
    public class AddressDTO
    {
        public int? Id { get; set; }
        public int ClientId { get; set; }
        public int AddressTypeId { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public string AddressDetail { get; set; }
        public string ZipCode { get; set; }
    }
}
