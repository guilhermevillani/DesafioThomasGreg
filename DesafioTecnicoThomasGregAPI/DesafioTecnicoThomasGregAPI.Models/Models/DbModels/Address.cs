using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioTecnicoThomasGregAPI.Models.Models.DbModels
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }

        [ForeignKey("AddressType")]
        public int AddressTypeId { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public string AddressDetail { get; set; }
        public string ZipCode { get; set; }

        // Navigation properties
        public virtual Client Client { get; set; }
        public virtual AddressType AddressType { get; set; }
    }
}
