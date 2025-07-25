﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using WebManagementProyect.CInfrastructure.Persistence.AppDbContext;

namespace WebManagementProyect.CInfrastructure.Persistence.AppDbContext.Configurations
{
    public partial class ProyectoConfiguration : IEntityTypeConfiguration<Proyecto>
    {
        public void Configure(EntityTypeBuilder<Proyecto> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK__Proyecto__3214EC070B5017C5");

            entity.ToTable("Proyecto");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.NombreProyecto).IsRequired().HasMaxLength(100);
            
            
            entity.Property(e => e.FechaCreacion)
                .IsRequired()
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Eliminado)
                .IsRequired();
            entity.Property(e => e.FechaEliminado)
                .HasColumnType("datetime");
            entity.Property(e => e.MotivoEliminado)
                .HasMaxLength(50)
                .IsUnicode(false);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Proyecto> entity);
    }
}
