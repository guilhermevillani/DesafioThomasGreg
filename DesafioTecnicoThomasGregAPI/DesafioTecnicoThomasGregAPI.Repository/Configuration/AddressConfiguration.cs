using DesafioTecnicoThomasGregAPI.Models.Models.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioTecnicoThomasGregAPI.Repository.Configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);
            builder.HasOne(a => a.Client)
                   .WithMany(c => c.Addresses)
                   .HasForeignKey(a => a.ClientId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(a => a.AddressType)
                   .WithMany()
                   .HasForeignKey(a => a.AddressTypeId)
                   .IsRequired();
        }
    }
}
