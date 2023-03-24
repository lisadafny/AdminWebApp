using Admin.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Data.Mappings
{
    public partial class VendorMapping : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");
            builder.Property(x => x.Document)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.HasOne(x => x.Address)
                .WithOne(y => y.Vendor);

            builder.HasMany(x => x.Products)
                .WithOne(y => y.Vendor)
                .HasForeignKey(y => y.VendorId);

            builder.ToTable("Vendors");
        }
    }
}
