using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MaderasProveedores.API.Models
{
    public partial class MaderasProveedoresContext : DbContext
    {
        public MaderasProveedoresContext()
        {
        }

        public MaderasProveedoresContext(DbContextOptions<MaderasProveedoresContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Areas { get; set; } = null!;
        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<Madera> Maderas { get; set; } = null!;
        public virtual DbSet<Proveedore> Proveedores { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MaderasProveedores;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>(entity =>
            {
                entity.ToTable("Area");

                entity.Property(e => e.Descripción).HasMaxLength(50);
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.Property(e => e.Apellido).HasMaxLength(50);

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdArea)
                    .HasConstraintName("FK_Empleados_Area");
            });

            modelBuilder.Entity<Madera>(entity =>
            {
                entity.Property(e => e.Maderas).HasMaxLength(50);

                entity.HasOne(d => d.IdProveedoresNavigation)
                    .WithMany(p => p.Maderas)
                    .HasForeignKey(d => d.IdProveedores)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Maderas_Proveedores");
            });

            modelBuilder.Entity<Proveedore>(entity =>
            {
                entity.Property(e => e.Proveedor).HasMaxLength(50);

                entity.Property(e => e.Rfc)
                    .HasMaxLength(50)
                    .HasColumnName("RFC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
