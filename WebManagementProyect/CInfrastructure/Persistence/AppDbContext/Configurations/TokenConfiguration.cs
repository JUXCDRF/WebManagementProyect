﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using WebManagementProyect.CInfrastructure.Persistence.AppDbContext;

namespace WebManagementProyect.CInfrastructure.Persistence.AppDbContext.Configurations
{
    public partial class TokenConfiguration : IEntityTypeConfiguration<Token>
    {
        public void Configure(EntityTypeBuilder<Token> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK__Token__3214EC07AAB7B48D");

            entity.ToTable("Token");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.TokenHash)
                .IsRequired()
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.Anulado)
                .IsRequired();
            entity.Property(e => e.FechaAnulado)
                .HasColumnType("datetime");
            entity.Property(e => e.MotivoAnulado)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.FechaCreacion)
                .IsRequired()
                .HasColumnType("datetime");
            entity.Property(e => e.Eliminado)
               .IsRequired();
            entity.Property(e => e.FechaEliminado)
                .HasColumnType("datetime");
            entity.Property(e => e.MotivoEliminado)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasIndex(e => e.TokenHash).IsUnique();
            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Token> entity);
    }
}
