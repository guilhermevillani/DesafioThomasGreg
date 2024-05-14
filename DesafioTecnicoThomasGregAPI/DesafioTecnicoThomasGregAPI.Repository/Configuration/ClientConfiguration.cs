using DesafioTecnicoThomasGregAPI.Models.Models.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioTecnicoThomasGregAPI.Repository.Configuration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.Admin)
                   .WithMany()
                   .HasForeignKey(c => c.AdminId)
                   .IsRequired();
        }
    }
}
