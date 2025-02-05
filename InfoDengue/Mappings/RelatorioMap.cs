using InfoDengue.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfoDengue.Mappings;

public class RelatorioMap : IEntityTypeConfiguration<Relatorio>
{
    public void Configure(EntityTypeBuilder<Relatorio> builder)
    {
        builder.HasKey(e => e.IdSolicitanteRelatorio).HasName("PK__Relatori__16E464897A64619E");

        builder.Property(e => e.Arbovirose)
            .HasMaxLength(50)
            .IsUnicode(false);
        builder.Property(e => e.CodIbge).HasColumnName("Cod_Ibge");
        builder.Property(e => e.CpfSolicitante)
            .HasMaxLength(11)
            .IsUnicode(false)
            .IsFixedLength();
        builder.Property(e => e.DataSolicitacao).HasColumnName("Data_Solicitacao");
        builder.Property(e => e.Municipio)
            .HasMaxLength(100)
            .IsUnicode(false);
        builder.Property(e => e.SemInicio).HasColumnName("Sem_Inicio");
        builder.Property(e => e.SemTermino).HasColumnName("Sem_Termino");

        builder.HasOne(d => d.CpfSolicitanteNavigation).WithMany(p => p.Relatorios)
            .HasPrincipalKey(p => p.Cpf)
            .HasForeignKey(d => d.CpfSolicitante)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Relatorio__CpfSo__398D8EEE");
    }
}