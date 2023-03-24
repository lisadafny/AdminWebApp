﻿using Admin.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Data.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");
            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnType("varchar(1000)");
            builder.Property(x => x.Image)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.ToTable("Products");
        }
    }
}
