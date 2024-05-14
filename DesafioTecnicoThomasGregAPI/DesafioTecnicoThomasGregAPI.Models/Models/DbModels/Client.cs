using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioTecnicoThomasGregAPI.Models.Models.DbModels
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Logotipo { get; set; }

        [ForeignKey("AspNetUsersId")]
        public Guid AdminId { get; set; }

        // Navigation property
        public virtual IEnumerable<Address> Addresses { get; set; }
        public virtual Admin Admin { get; set; }
    }
}
