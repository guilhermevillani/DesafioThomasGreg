using Microsoft.AspNetCore.Identity;

namespace DesafioTecnicoThomasGregAPI.Models.Models.DbModels
{
    public class Admin : IdentityUser
    {
        public virtual IEnumerable<Client> Clients { get; set; }
    }
}
