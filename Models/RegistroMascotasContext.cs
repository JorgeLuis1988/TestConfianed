using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ApiConfiamed.Models;

public partial class RegistroMascotasContext : DbContext
{
    public RegistroMascotasContext()
    {
    }

    public RegistroMascotasContext(DbContextOptions<RegistroMascotasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Mascota> Mascota { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Mascota>(entity =>
        {
            entity.HasKey(e => e.IdMascota);

            entity.Property(e => e.Color).HasMaxLength(50);
            entity.Property(e => e.Especie).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Raza).HasMaxLength(50);

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Mascota)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK_Mascota_Usuario");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.ToTable("Usuario");

            entity.Property(e => e.Estatura).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");
            entity.Property(e => e.Identificacion).HasMaxLength(13);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
