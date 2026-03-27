using System;
using System.Collections.Generic;
using ConnectPlus.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ConnectPlus.WebApi.DBContextConnect;

public partial class ConnectContext : DbContext
{
    public ConnectContext()
    {
    }

    public ConnectContext(DbContextOptions<ConnectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contato> Contatos { get; set; }

    public virtual DbSet<TipoContato> TipoContatos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ConnectPlus;Trusted_Connection=True;trustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contato>(entity =>
        {
            entity.HasKey(e => e.IdContato).HasName("PK__Contato__2AC4F0643C4C640B");

            entity.Property(e => e.IdContato).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.IdTipoContatoNavigation).WithMany(p => p.Contatos).HasConstraintName("FK__Contato__IdTipoC__60A75C0F");
        });

        modelBuilder.Entity<TipoContato>(entity =>
        {
            entity.HasKey(e => e.IdTipoContato).HasName("PK__TipoCont__8D18FEBD37DE83EF");

            entity.Property(e => e.IdTipoContato).HasDefaultValueSql("(newid())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
