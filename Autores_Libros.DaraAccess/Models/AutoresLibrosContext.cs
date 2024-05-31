using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Autores_Libros.DaraAccess.Models
{
    public partial class AutoresLibrosContext : DbContext
    {
        public AutoresLibrosContext()
        {
        }

        public AutoresLibrosContext(DbContextOptions<AutoresLibrosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autore> Autores { get; set; } = null!;
        public virtual DbSet<Configuracione> Configuraciones { get; set; } = null!;
        public virtual DbSet<Libro> Libros { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=;Database=AutoresLibros;user=;password=");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autore>(entity =>
            {
                entity.HasKey(e => e.IdAutor);

                entity.Property(e => e.CiudadNacimiento)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.PrimerApellido)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PrimerNombre)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SegundoApellido)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SegundoNombre)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Configuracione>(entity =>
            {
                entity.HasKey(e => e.IdConfig);

                entity.Property(e => e.DescripcionConfiguracion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NombreConfiguracion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ValorConfiguracion)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasKey(e => e.Titulo);

                entity.Property(e => e.Titulo)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Género)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                //entity.HasOne(d => d.IdAutorNavigation)
                //    .WithMany(p => p.Libros)
                //    .HasForeignKey(d => d.IdAutor)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Libros_Autores");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
