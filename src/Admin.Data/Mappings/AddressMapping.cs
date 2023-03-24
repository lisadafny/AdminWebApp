using Admin.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Data.Mappings
{
    public partial class VendorMapping
    {
        public class AddressMapping : IEntityTypeConfiguration<Address>
        {
            public void Configure(EntityTypeBuilder<Address> builder)
            {
                builder.HasKey(x => x.Id);

                builder.Property(x => x.Street)
                    .IsRequired()
                    .HasColumnType("varchar(200)");

                builder.Property(x => x.Number)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                builder.Property(x => x.AdditionalInfo)
                    .HasColumnType("varchar(250)");

                builder.Property(x => x.PostalCode)
                    .IsRequired()
                    .HasColumnType("varchar(8)");

                builder.Property(x => x.City)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                builder.Property(x => x.State)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                builder.ToTable("Adresses");
            }
        }
    }
}
