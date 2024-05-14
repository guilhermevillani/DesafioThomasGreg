using System.ComponentModel.DataAnnotations;

namespace DesafioTecnicoThomasGregAPI.Models.Models.DbModels
{
    public class AddressType
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
    }
}
