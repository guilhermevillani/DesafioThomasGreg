using DesafioTecnicoThomasGregAPI.Models.Models.DbModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DesafioTecnicoThomasGregAPI.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Client> Clients { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<AddressType> AddressTypes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=desafio-tecnico-thomas-greg.database.windows.net,1433;Database=desafio-tecnico-thomas-greg;User ID=GuilhermeVillani@desafio-tecnico-thomas-greg;Password=#desafio-tecnico!-thomas@-greg1;Trusted_Connection=False;MultipleActiveResultSets=false"
);
        }
    }
}
