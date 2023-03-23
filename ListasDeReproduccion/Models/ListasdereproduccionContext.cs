using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoListasdeReproduccion.Models;

public partial class ListasdereproduccionContext : DbContext
{
    public ListasdereproduccionContext()
    {
    }

    public ListasdereproduccionContext(DbContextOptions<ListasdereproduccionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Canciones> Canciones { get; set; }

    public virtual DbSet<Listas> Listas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;database=listasdereproduccion;password=9hn2425s2O", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Canciones>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("canciones");

            entity.HasIndex(e => e.ListaId, "ListaId");

            entity.Property(e => e.Artista).HasMaxLength(60);
            entity.Property(e => e.Duracion).HasMaxLength(10);
            entity.Property(e => e.Genero).HasMaxLength(60);
            entity.Property(e => e.Titulo).HasMaxLength(60);

            entity.HasOne(d => d.Lista).WithMany(p => p.Canciones)
                .HasForeignKey(d => d.ListaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("canciones_ibfk_1");
        });

        modelBuilder.Entity<Listas>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("listas");

            entity.Property(e => e.Creador).HasMaxLength(60);
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(60);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
