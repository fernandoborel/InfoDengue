using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InfoDengue.Context;

public partial class InfoDengueDbContext : DbContext
{
    public InfoDengueDbContext()
    {
    }

    public InfoDengueDbContext(DbContextOptions<InfoDengueDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Relatorio> Relatorios { get; set; }

    public virtual DbSet<Solicitante> Solicitantes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=FIO32002125;Initial Catalog=InfoDengueDB;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Relatorio>(entity =>
        {
            entity.HasKey(e => e.IdSolicitanteRelatorio).HasName("PK__Relatori__16E464897A64619E");

            entity.Property(e => e.Arbovirose)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CodIbge).HasColumnName("Cod_Ibge");
            entity.Property(e => e.CpfSolicitante)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DataSolicitacao).HasColumnName("Data_Solicitacao");
            entity.Property(e => e.Municipio)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SemInicio).HasColumnName("Sem_Inicio");
            entity.Property(e => e.SemTermino).HasColumnName("Sem_Termino");

            entity.HasOne(d => d.CpfSolicitanteNavigation).WithMany(p => p.Relatorios)
                .HasPrincipalKey(p => p.Cpf)
                .HasForeignKey(d => d.CpfSolicitante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Relatorio__CpfSo__398D8EEE");
        });

        modelBuilder.Entity<Solicitante>(entity =>
        {
            entity.HasKey(e => e.IdSolicitante).HasName("PK__Solicita__B6EB1200E2457044");

            entity.ToTable("Solicitante");

            entity.HasIndex(e => e.Cpf, "UQ__Solicita__C1FF930913C8D22D").IsUnique();

            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
