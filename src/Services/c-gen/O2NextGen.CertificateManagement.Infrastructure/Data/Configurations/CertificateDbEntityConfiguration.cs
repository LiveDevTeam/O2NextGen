﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using O2NextGen.CertificateManagement.Domain.Entities;

namespace O2NextGen.CertificateManagement.Infrastructure.Data.Configurations
{

    public class CertificateDbEntityConfiguration : IEntityTypeConfiguration<Certificate>
    {
        public void Configure(EntityTypeBuilder<Certificate> builder)
        {
            builder.ToTable("Certificate");

            builder.Property(ci => ci.Id)
                .HasColumnType("bigint")
                .UseHiLo("certificate_hilo")
                .IsRequired();
        }
    }
}

